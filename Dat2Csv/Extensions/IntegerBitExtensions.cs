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
    }
}
