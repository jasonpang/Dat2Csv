using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dat2Csv.Extensions;

namespace Dat2Csv
{
    /// <summary>
    /// Provides methods to conveniently read in the dataset format.
    /// </summary>
    public class DatasetReader : BinaryReader
    {
        public DatasetReader(Stream input) : base(input) { }

        /// <summary>
        /// Reads one dataset from the stream.
        /// </summary>
        public Dataset ReadDataset()
        {
            var dataset = new Dataset();

            // Ignore the first 2 bytes
            this.ReadBytes(2);

            // Read the sequence number
            byte[] sequenceNumberBytes = this.ReadBytes(2);
            dataset.SequenceNumber = dataset.SequenceNumber.PopulateBits(sequenceNumberBytes[0], 0, 8, 8);
            dataset.SequenceNumber = dataset.SequenceNumber.PopulateBits(sequenceNumberBytes[1], 0, 0, 8);

            // Read x0 and y0
            byte[] x0y0 = this.ReadBytes(3);
            dataset.X[0] = dataset.X[0].PopulateBits(x0y0[0], sourceBit: 0, destinationBit: 4, count: 8);
            dataset.X[0] = dataset.X[0].PopulateBits(x0y0[1], sourceBit: 4, destinationBit: 0, count: 4);
            dataset.X[0] = dataset.X[0].SignExtend();
            dataset.Y[0] = dataset.Y[0].PopulateBits(x0y0[1], sourceBit: 0, destinationBit: 8, count: 4);
            dataset.Y[0] = dataset.Y[0].PopulateBits(x0y0[2], sourceBit: 0, destinationBit: 0, count: 8);
            dataset.Y[0] = dataset.Y[0].SignExtend();

            // Read z0 and x1
            byte[] z0x1 = this.ReadBytes(3);
            dataset.Z[0] = dataset.Z[0].PopulateBits(z0x1[0], sourceBit: 0, destinationBit: 4, count: 8);
            dataset.Z[0] = dataset.Z[0].PopulateBits(z0x1[1], sourceBit: 4, destinationBit: 0, count: 4);
            dataset.Z[0] = dataset.Z[0].SignExtend();
            dataset.X[1] = dataset.X[1].PopulateBits(z0x1[1], sourceBit: 0, destinationBit: 8, count: 4);
            dataset.X[1] = dataset.X[1].PopulateBits(z0x1[2], sourceBit: 0, destinationBit: 0, count: 8);
            dataset.X[1] = dataset.X[1].SignExtend();

            // Read y1 and z1
            byte[] y1z1 = this.ReadBytes(3);
            dataset.Y[1] = dataset.Y[1].PopulateBits(y1z1[0], sourceBit: 0, destinationBit: 4, count: 8);
            dataset.Y[1] = dataset.Y[1].PopulateBits(y1z1[1], sourceBit: 4, destinationBit: 0, count: 4);
            dataset.Y[1] = dataset.Y[1].SignExtend();
            dataset.Z[1] = dataset.Z[1].PopulateBits(y1z1[1], sourceBit: 0, destinationBit: 8, count: 4);
            dataset.Z[1] = dataset.Z[1].PopulateBits(y1z1[2], sourceBit: 0, destinationBit: 0, count: 8);
            dataset.Z[1] = dataset.Z[1].SignExtend();

            // Read x2 and y2
            byte[] x2y2 = this.ReadBytes(3);
            dataset.X[2] = dataset.X[2].PopulateBits(x2y2[0], sourceBit: 0, destinationBit: 4, count: 8);
            dataset.X[2] = dataset.X[2].PopulateBits(x2y2[1], sourceBit: 4, destinationBit: 0, count: 4);
            dataset.X[2] = dataset.X[2].SignExtend();
            dataset.Y[2] = dataset.Y[2].PopulateBits(x2y2[1], sourceBit: 0, destinationBit: 8, count: 4);
            dataset.Y[2] = dataset.Y[2].PopulateBits(x2y2[2], sourceBit: 0, destinationBit: 0, count: 8);
            dataset.Y[2] = dataset.Y[2].SignExtend();

            // Read z2 and x3
            byte[] z2x3 = this.ReadBytes(3);
            dataset.Z[2] = dataset.Z[2].PopulateBits(z2x3[0], sourceBit: 0, destinationBit: 4, count: 8);
            dataset.Z[2] = dataset.Z[2].PopulateBits(z2x3[1], sourceBit: 4, destinationBit: 0, count: 4);
            dataset.Z[2] = dataset.Z[2].SignExtend();
            dataset.X[3] = dataset.X[3].PopulateBits(z2x3[1], sourceBit: 0, destinationBit: 8, count: 4);
            dataset.X[3] = dataset.X[3].PopulateBits(z2x3[2], sourceBit: 0, destinationBit: 0, count: 8);
            dataset.X[3] = dataset.X[3].SignExtend();

            // Read y3 and z3
            byte[] y3z3 = this.ReadBytes(3);
            dataset.Y[3] = dataset.Y[3].PopulateBits(y3z3[0], sourceBit: 0, destinationBit: 4, count: 8);
            dataset.Y[3] = dataset.Y[3].PopulateBits(y3z3[1], sourceBit: 4, destinationBit: 0, count: 4);
            dataset.Y[3] = dataset.Y[3].SignExtend();
            dataset.Z[3] = dataset.Z[3].PopulateBits(y3z3[1], sourceBit: 0, destinationBit: 8, count: 4);
            dataset.Z[3] = dataset.Z[3].PopulateBits(y3z3[2], sourceBit: 0, destinationBit: 0, count: 8);
            dataset.Z[3] = dataset.Z[3].SignExtend();

            return dataset;
        }
    }
}
