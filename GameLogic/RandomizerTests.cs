using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeirdUnitBE.GameLogic.Tests
{
    [TestClass()]
    public class RandomizerTests
    {
        [TestMethod()]
        [DataRow(155552, 3)]
        [DataRow(16484135, 14)]
        [DataRow(468, 22)]
        public void ReturnRandomIntegerTest(int seed, int expectedInt)
        {
            Randomizer randomizer = new Randomizer();

            int randomNumber = randomizer.ReturnRandomInteger(1, 100, seed);

            Assert.AreEqual(expectedInt, randomNumber);
        }
    }
}