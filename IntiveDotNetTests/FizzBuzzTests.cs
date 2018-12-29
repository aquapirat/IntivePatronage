using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntiveDotNet.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void ValuesTest()
        {
            string expected = String.Empty;

            for (var i = 0; i <= 1000; ++i)
            {
                expected = String.Empty;
                if (i % 2 == 0)
                {
                    expected = "Fizz";
                }
                else if (i % 3 == 0)
                {
                    expected = "Buzz";
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    expected = "FizzBuzz";
                }

                Assert.AreEqual(expected, Program.FizzBuzz(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionTest()
        {
            Program.FizzBuzz(-5);
        }
    }
}