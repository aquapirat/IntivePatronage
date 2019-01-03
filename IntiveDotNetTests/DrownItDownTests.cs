using System;
using System.IO;
using IntiveDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntiveDotNet.Tests
{
    [TestClass]
    public class DrownItDownTests
    {
        [TestMethod]
        public void FileExistenceTest()
        {
            DeepDive dd = new DeepDive();
            DrownItDown did = new DrownItDown(dd);

            dd.Create(4);
            did.Drown("test", 3);

            Assert.IsTrue(File.Exists(did.FilePath));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentExceptionTest()
        {
            DeepDive dd = new DeepDive();
            DrownItDown did = new DrownItDown(dd);

            did.Drown(null, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionTest()
        {
            DeepDive dd = new DeepDive();
            DrownItDown did = new DrownItDown(dd);

            dd.Create(4);

            did.Drown(null, 8);
        }
    }
}
