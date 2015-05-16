using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dat2Csv.Extensions;

namespace Dat2Csv.Extensions
{
    public static class BitArrayExtensions
    {
        public static BitArray ToBitArray(this ushort value)
        {
            BitArray bits = new BitArray(sizeof(ushort) * 8);
            for (int i = 0; i < sizeof(ushort) * 8; i++)
            {
                bits[i] = value.GetBit(i);
            }
            return bits;
        }

        public static BitArray ToBitArray(this short value)
        {
            BitArray bits = new BitArray(sizeof(short) * 8);
            for (int i = 0; i < sizeof(short) * 8; i++)
            {
                bits[i] = value.GetBit(i);
            }
            return bits;
        }

        public static BitArray ToBitArray(this byte value)
        {
            BitArray bits = new BitArray(sizeof(byte) * 8);
            for (int i = 0; i < sizeof(byte) * 8; i++)
            {
                bits[i] = value.GetBit(i);
            }
            return bits;
        }
        public static String GetReadableString(this BitArray bitArray)
        {
            StringBuilder sb = new StringBuilder(bitArray.Count);
            for (int i = bitArray.Count - 1; i >= 0; i--)
            {
                sb.Append(bitArray[i] ? "1" : "0");
            }
            return sb.ToString();
        }
    }
}
