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
        [Test]
        public void TestSetBit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((byte)0).SetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((byte)0).SetBit(sizeof(byte) * 8));
            byte v170Test = 0, v170Sol = 170;
            for (int i = 0; i < sizeof(byte) * 8; i++)
                v170Test = v170Test.SetBit(i, i % 2 != 0);
            Assert.AreEqual(v170Test, v170Sol);

            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).SetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).SetBit(sizeof(short) * 8));
            short vn21846Test = 0, vn21846Sol = -21846;
            for (int i = 0; i < sizeof(short) * 8; i++)
                vn21846Test = vn21846Test.SetBit(i, i % 2 != 0);
            Assert.AreEqual(vn21846Test, vn21846Sol);

            Assert.Throws<ArgumentOutOfRangeException>(() => ((ushort)0).SetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ushort)0).SetBit(sizeof(ushort) * 8));
            ushort v43690Test = 0, v43690Sol = 43690;
            for (int i = 0; i < sizeof(ushort) * 8; i++)
                v43690Test = v43690Test.SetBit(i, i % 2 != 0);
            Assert.AreEqual(v43690Test, v43690Sol);
        }
    }
}
