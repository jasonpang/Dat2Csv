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

        /// <summary>
        /// Returns a short with a subset of its bits populated from a subset of a byte's bits.
        /// </summary>
        /// <param name="number">The number's bits to modify.</param>
        /// <param name="source">The source containing the bits we want to copy over.</param>
        /// <param name="sourceBit">The bit position in the source to begin copying over. 0 represents the LSB.</param>
        /// <param name="destinationBit">The bit position in the number to copy to. 0 represents the number's LSB.</param>
        /// <param name="count">The number of bits to copy from the source and to the destination.</param>
        /// <returns></returns>
        public static short PopulateBits(this short number, byte source, int sourceBit, int destinationBit, int count)
        {
            if (sourceBit < 0 || destinationBit < 0 || count < 0 ||
                sourceBit >= sizeof(byte) * 8 || destinationBit >= sizeof(byte) * 8 || count > sizeof(byte) * 8)
                throw new ArgumentOutOfRangeException("Check sourceBit, destinationBit, and count to not exceed [0 .. 8]");
            for (int i = sourceBit; i < sourceBit + count; i++)
                number = number.SetBit(i - sourceBit + destinationBit, source.GetBit(i));
            return number;
        }

        /// <summary>
        /// Returns a short with the bits between the MSB and the leftmost 1 turned on.
        /// </summary>
        /// <param name="number"></param>
        /// <remarks>A number can only be sign extended once.</remarks>
        /// <example>
        /// Before sign-extend: 0000101011
        /// After  sign-extend: 1111101011
        /// </example>
        /// <returns></returns>
        public static short SignExtend(this short number)
        {
            for (int i = sizeof(short) * 8 - 1; i >= 0; i--)
            {
                if (number.GetBit(i))
                {
                    for (int j = i; j < sizeof(short) * 8; j++)
                    {
                        number = number.SetBit(j, true);
                    }
                }
            }
            return number;
        }
    }
}
