using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntiveDotNet.Tests
{
    [TestClass]
    public class DeepDiveTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionTest()
        {
            DeepDive dd = new DeepDive();
            dd.Create(15);
        }

        [TestMethod]
        public void PathCreationTest()
        {
            try
            {
                DeepDive dd = new DeepDive();
                dd.Create(3);

                Assert.IsTrue(Directory.Exists($"{dd.MainPath}\\ dd.FullPath"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
