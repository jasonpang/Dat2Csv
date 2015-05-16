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
            for (int i = 0; i < sizeof(byte) * 8; i++)
                Assert.AreEqual(((byte)170).GetBit(i), i % 2 != 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).GetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).GetBit(sizeof(short) * 8));
            for (int i = 0; i < sizeof(short) * 8; i++)
                Assert.AreEqual(((short)-21846).GetBit(i), i % 2 != 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => ((ushort)0).GetBit(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ushort)0).GetBit(sizeof(ushort) * 8));
            for (int i = 0; i < sizeof(ushort) * 8; i++)
                Assert.AreEqual(((ushort)43690).GetBit(i), i % 2 != 0);
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
        [Test]
        public void TestPopulateFrom()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, -1, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, 0, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, 0, 0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, -1, -1, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, sizeof(byte) * 8, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, 0, sizeof(byte) * 8, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, 0, 0, (sizeof(byte) * 8) + 1));
            Assert.Throws<ArgumentOutOfRangeException>(() => ((short)0).PopulateBits(239, sizeof(byte) * 8, sizeof(byte) * 8, (sizeof(byte) * 8) + 1));

            byte v170 = 170;
            short v170Test = 0, v170Sol = 170;
            v170Test = v170Test.PopulateBits(v170, 0, 0, sizeof(byte) * 8);
            Assert.AreEqual(v170Sol, v170Test);

            short test2 = 0, test2Sol = 160;
            test2 = test2.PopulateBits(v170, 2, 4, 4);
            Assert.AreEqual(test2Sol, test2);

            byte v50 = 50;
            short test3 = 0, test3Sol = 50;
            test3 = test3.PopulateBits(v50, 0, 0, 6);
            Assert.AreEqual(test3Sol, test3);
        }
        [Test]
        public void TestSignExtend()
        {
            Assert.AreEqual(short.MinValue.SignExtend(), short.MinValue);

            short v0 = 0;
            short v0SE = v0.SignExtend();
            Assert.AreEqual(v0SE, 0);
            Assert.AreEqual(v0SE.SignExtend(), 0);

            short v50 = 50;
            short v50SE = v50.SignExtend();
            Assert.AreEqual(v50SE, (short)(v50 * -1));
            Assert.AreEqual(v50SE.SignExtend(), (short)(v50 * -1));

            short vn21846 = -21846;
            short vn21846SE = vn21846.SignExtend();
            Assert.AreEqual(vn21846, vn21846SE);
            Assert.AreEqual(vn21846.SignExtend(), vn21846SE);

            Assert.AreEqual(short.MaxValue.SignExtend(), short.MinValue);
            Assert.AreEqual(short.MaxValue.SignExtend().SignExtend(), short.MinValue);
        }
    }
}
