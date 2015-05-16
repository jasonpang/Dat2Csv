using System;
using Dat2Csv.Extensions;
using NUnit.Framework;

namespace Dat2Csv.Tests
{
    [TestFixture]
    public class IntegerBitExtensionTests
    {
        [Test]
        public void TestGetBit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((byte)0).GetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((byte)0).GetBit(sizeof(byte) * 8));
            for (int i = 0; i < 7; i++, Assert.AreEqual(((byte)170).GetBit(i), i % 2 != 0)) ;

            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).GetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).GetBit(sizeof(short) * 8));
            for (int i = 0; i < 7; i++, Assert.AreEqual(((short)-21846).GetBit(i), i % 2 != 0)) ;

            Assert.Throws<ArgumentOutOfRangeException>(() => ((ushort)0).GetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ushort)0).GetBit(sizeof(ushort) * 8));
            for (int i = 0; i < 7; i++, Assert.AreEqual(((ushort)43690).GetBit(i), i % 2 != 0)) ;
        }
    }
}
