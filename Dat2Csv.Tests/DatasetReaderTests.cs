using NUnit.Framework;
using System;
using System.IO;

namespace Dat2Csv.Tests
{
    [TestFixture]
    public class DatasetReaderTests
    {
        [Test]
        public void TestReadSequenceNumberAndFirstTwoDatapoints()
        {
            var reader = new DatasetReader(new MemoryStream(new byte[] { 147, 218, 19, 114, 239, 239, 92, 231, 62, 255, 245, 206, 99, 245, 206, 99, 245, 206, 99, 245, 206, 99 }));
            var dataset = reader.ReadDataset();
            Assert.AreEqual(4978, dataset.SequenceNumber);
            Assert.AreEqual(-258, dataset.X[0]);
            Assert.AreEqual(-164, dataset.Y[0]);
            Assert.AreEqual(-397, dataset.Z[0]);
            Assert.AreEqual(-257, dataset.X[1]);
            Assert.AreEqual(-164, dataset.Y[1]);
            Assert.AreEqual(-413, dataset.Z[1]);
        }
    }
}
