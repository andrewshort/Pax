using Common;
using Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using PaxService.Model;
using PaxService.Model.Interfaces;
using PaxService.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    [TestClass]
    public class ParseTests
    {
        private Mock<ICheckSum> _checkSumMock;
        private Mock<ICheckSum> _checkSumInvalidMock;

        [TestInitialize]
        public void Setup()
        {
            if (ContainerManager.Container == null)
            {
                var container = new StandardKernel();
                ContainerManager.Container = container;

                container.Bind<IAvsysObject>().To<AvsysObject>();
                container.Bind<IAvrmcObject>().To<AvrmcObject>();
            }

            _checkSumMock = new Mock<ICheckSum>();
            _checkSumMock.Setup(c => c.IsValid(It.IsAny<string>())).Returns(true);

            _checkSumInvalidMock = new Mock<ICheckSum>();
            _checkSumInvalidMock.Setup(c => c.IsValid(It.IsAny<string>())).Returns(false);
        }

        [TestMethod]
        public void TestAvsys()
        {
            var avsysParser = new AvsysParser(_checkSumMock.Object);

            string sentence = "AVSYS,80003757,150,4035239305,160*4F";

            IAvsysObject o = avsysParser.Parse(sentence);
            Assert.IsNotNull(o);
            Assert.AreEqual(o.UnitID, 80003757);
            Assert.AreEqual(o.FirmwareVersion, "150");
            Assert.AreEqual(o.SerialNumber, "4035239305");
            Assert.AreEqual(o.MemorySize, 160);

            string badSentence = "AVRMC,80003757,150,4035239305,160*4F";

            Assert.IsNull(avsysParser.Parse(badSentence));

            avsysParser = new AvsysParser(_checkSumInvalidMock.Object);
            Assert.IsNull(avsysParser.Parse(sentence));
        }

        [TestMethod]
        public void TestAvrmc()
        {
            var avmrcParser = new AvrmcParser(_checkSumMock.Object);

            string sentence = "AVRMC,90006400,165039,A,4000.4663,N,08556.4742,W,0.10,150.43,301211,0,4033,0  ,1,0,0*1F";

            IAvrmcObject avrmc = avmrcParser.Parse(sentence);

            Assert.AreEqual(avrmc.UnitId, "90006400");


        }
    }
}
