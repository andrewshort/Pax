using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;

namespace ServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckSumTests()
        {
            var checkSum = new CheckSum();
            var avsys = "AVSYS,80003757,150,4035239305,160*4F";

            Assert.IsTrue(checkSum.IsValid(avsys));

            Assert.AreEqual(checkSum.Calculate(avsys), "4F");

        }
    }
}
