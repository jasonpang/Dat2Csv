using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat2Csv.Extensions
{
    /// <summary>
    /// Provides methods to manipulate individual bits in primitive data types.
    /// </summary>
    public static class IntegerBitExtensions
    {
        /// <summary>
        /// Returns the bit at position <see cref="bit"/>.
        /// </summary>
        /// <param name="number">The byte value.</param>
        /// <param name="bit">The bit position to retrieve, where 0 is the LSB and 7 is the MSB.</param>
        public static bool GetBit(this byte number, int bit)
        {
            if (bit < 0 || bit >= sizeof(byte) * 8)
                throw new ArgumentOutOfRangeException("bit");
            return (number & (1 << bit)) != 0;
        }

        /// <summary>
        /// Returns the bit at position <see cref="bit"/>.
        /// </summary>
        /// <param name="number">The short value.</param>
        /// <param name="bit">The bit position to retrieve, where 0 is the LSB and 7 is the MSB.</param>
        public static bool GetBit(this short number, int bit)
        {
            if (bit < 0 || bit >= sizeof(short) * 8)
                throw new ArgumentOutOfRangeException("bit");
            return (number & (1 << bit)) != 0;
        }

        /// <summary>
        /// Returns the bit at position <see cref="bit"/>.
        /// </summary>
        /// <param name="number">The unsigned short value.</param>
        /// <param name="bit">The bit position to retrieve, where 0 is the LSB and 7 is the MSB.</param>
        public static bool GetBit(this ushort number, int bit)
        {
            if (bit < 0 || bit >= sizeof(ushort) * 8)
                throw new ArgumentOutOfRangeException("bit");
            return (number & (1 << bit)) != 0;
        }

        /// <summary>
        /// Returns the number with the bit at position <see cref="bit"/> set to the specified value.
        /// </summary>
        /// <param name="number">The byte value.</param>
        /// <param name="bit">The bit position to set, where 0 is the LSB and 7 is the MSB.</param>
        /// <param name="value">The value to set the bit to. Defaults to true.</param>
        public static byte SetBit(this byte number, int bit, bool value=true)
        {
            if (bit < 0 || bit >= sizeof(byte) * 8)
                throw new ArgumentOutOfRangeException("bit");
            return value ?
                (byte)(number | (1 << bit)) :
                (byte)(number & ~(1 << bit));
        }

        /// <summary>
        /// Returns the number with the bit at position <see cref="bit"/> set to the specified value.
        /// </summary>
        /// <param name="number">The short value.</param>
        /// <param name="bit">The bit position to set, where 0 is the LSB and 7 is the MSB.</param>
        /// <param name="value">The value to set the bit to. Defaults to true.</param>
        public static short SetBit(this short number, int bit, bool value = true)
        {
            if (bit < 0 || bit >= sizeof(short) * 8)
                throw new ArgumentOutOfRangeException("bit");
            return value ?
                (short)(number | (short)(1 << bit)) :
                (short)(number & ~(1 << bit));
        }

        /// <summary>
        /// Returns the number with the bit at position <see cref="bit"/> set to the specified value.
        /// </summary>
        /// <param name="number">The unsigned short value.</param>
        /// <param name="bit">The bit position to set, where 0 is the LSB and 7 is the MSB.</param>
        /// <param name="value">The value to set the bit to. Defaults to true.</param>
        public static ushort SetBit(this ushort number, int bit, bool value = true)
        {
            if (bit < 0 || bit >= sizeof(ushort) * 8)
                throw new ArgumentOutOfRangeException("bit");
            return value ?
                (ushort)(number | (1 << bit)) :
                (ushort)(number & ~(1 << bit));
        }
    }
}
