using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat2Csv
{
    /// <summary>
    /// Represents one set of the binary file's data.
    /// </summary>
    public class Dataset
    {
        public ushort SequenceNumber { get; set; }
        public short[] X { get; set; }
        public short[] Y { get; set; }
        public short[] Z { get; set; }

        public Dataset()
        {
            X = new short[4];
            Y = new short[4];
            Z = new short[4];
        }
    }
}
