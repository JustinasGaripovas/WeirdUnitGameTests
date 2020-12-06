using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using WeirdUnitGame.GameLogic;
using WeirdUnitBE.GameLogic.PowerUpPackage;
using WeirdUnitBE.GameLogic.PowerUpPackage.ConcretePowerUps;

namespace WeirdUnitBE.GameLogic.Tests
{
    [TestClass()]
    public class HelperFacadeTests
    {
        Mock<IClassAnalyzer> classAnalyzer;
        Mock<IRandomizer> randomizerMock;

        [TestInitialize]
        public void Setup()
        {
            this.randomizerMock = new Mock<IRandomizer>();
            this.classAnalyzer = new Mock<IClassAnalyzer>();
        }

        [TestMethod()]
        public void ReturnRandomIntegerTest()
        {
            this.randomizerMock
                .Setup(mock => mock.ReturnRandomInteger(It.IsAny<int>(), It.IsAny<int>(), null))
                .Returns(10);

            HelperFacade helperFacade = new HelperFacade(this.randomizerMock.Object, this.classAnalyzer.Object);

            int randomIntFromFacade = helperFacade.ReturnRandomInteger(0, 100);

            Assert.AreEqual(randomIntFromFacade, 10);
        }

        [TestMethod()]
        public void GetAllLeafClassesTest()
        {
            this.classAnalyzer
                            .Setup(mock => mock.GetAllLeafClasses(typeof(PowerUp)))
                            .Returns(new List<Type>() { 
                                typeof(AttackingTowerPowerUp),
                                typeof(RegeneratingTowerPowerUp),
                                typeof(TowerDefencePowerUp),
                                typeof(UnitBuffPowerUp)
                            });

            HelperFacade helperFacade = new HelperFacade(this.randomizerMock.Object, this.classAnalyzer.Object);

            List<Type> randomIntFromFacade = helperFacade.GetAllLeafClasses(typeof(PowerUp));

            Assert.AreEqual(typeof(AttackingTowerPowerUp), randomIntFromFacade[0]);
            Assert.AreEqual(typeof(RegeneratingTowerPowerUp), randomIntFromFacade[1]);
            Assert.AreEqual(typeof(TowerDefencePowerUp), randomIntFromFacade[2]);
            Assert.AreEqual(typeof(UnitBuffPowerUp), randomIntFromFacade[3]);
        }
    }
}