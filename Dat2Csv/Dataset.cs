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
        public ushort[] X { get; set; }
        public ushort[] Y { get; set; }
        public ushort[] Z { get; set; }

        public Dataset()
        {
            X = new ushort[4];
            Y = new ushort[4];
            Z = new ushort[4];
        }
    }
}
