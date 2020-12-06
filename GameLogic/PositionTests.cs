using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeirdUnitBE.GameLogic.Tests
{
    [TestClass()]
    public class PositionTests
    {
        [TestMethod()]
        public void DistanceToPositionTest()
        {
            Position fromPosition = new Position(0,0);
            Position toPosition = new Position(0,5);

            double calculatedDistance = fromPosition.DistanceToPosition(toPosition);


            Assert.AreEqual(calculatedDistance, 5);
        }
    }
}