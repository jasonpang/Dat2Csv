using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat2Csv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please use the program as follows: \n \t <program> <input-file>");
                Environment.Exit(1);
            }

            var inputFilename = args[0];
            var outputFilename = Path.GetFileNameWithoutExtension(inputFilename) + ".csv";

            bool firstRead = true;
            ushort lastSequenceNumber = 0;

            try
            {
                using (var outputStream = new FileStream(outputFilename, FileMode.Create, FileAccess.Write))
                using (var writer = new StreamWriter(outputStream))
                {
                    using (var inputStream = new FileStream(inputFilename, FileMode.Open, FileAccess.Read))
                    using (var reader = new DatasetReader(inputStream))
                    {
                        writer.WriteLine("x,y,z");
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            var dataset = reader.ReadDataset();

                            if (firstRead)
                            {
                                firstRead = false;
                                lastSequenceNumber = dataset.SequenceNumber;
                            }
                            else
                            {
                                if (lastSequenceNumber + 1 != dataset.SequenceNumber)
                                {
                                    Console.WriteLine(String.Format("Failed: Last sequence number was {0} but current sequence number is {1}.", lastSequenceNumber, dataset.SequenceNumber));
                                    Console.WriteLine("Exiting...");
                                    Environment.Exit(1);
                                }
                                lastSequenceNumber = dataset.SequenceNumber;
                            }
                            for (int i = 0; i < dataset.X.Length; i++)
                                writer.WriteLine(String.Format("{0},{1},{2}", dataset.X[i], dataset.Y[i], dataset.Z[i]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error: {0}", e.ToString()));
            }

            Console.WriteLine("Program finished!");
        }
    }
}
