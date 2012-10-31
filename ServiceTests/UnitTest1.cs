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
            var avsys = "$AVSYS,80003757,150,4035239305,160*4F";

            Assert.IsTrue(checkSum.IsValid(avsys));

            Assert.IsFalse(checkSum.IsValid(string.Empty));
            Assert.IsFalse(checkSum.IsValid(null));
            Assert.IsFalse(checkSum.IsValid("AVSYS,80003757,150,4035239305,160*3F"));
            Assert.IsFalse(checkSum.IsValid("AVSYS,80003757,150,4035239305,1604F"));


            Assert.AreEqual(checkSum.Calculate(avsys), "4F");
        }

        [TestMethod]
        public void ConfigManagerTests()
        {
            var configManager = new ConfigManager();
            Assert.AreEqual(configManager.GetServerPort(), 12345);
        }

        [TestMethod]
        public void EncodingAdapterTests()
        {
            var encoding = new EncodingAdapter();
            //encoding.GetString(
        }
    }
}
