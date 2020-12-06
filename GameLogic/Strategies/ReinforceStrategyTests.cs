using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.GameLogic.Strategies;
using WeirdUnitBE.GameLogic.TowerPackage.Towers;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeirdUnitBE.GameLogic.Strategies.Tests
{
    [TestClass()]
    public class ReinforceStrategyTests
    {
        [TestMethod()]
        public void ExecuteStrategyTest_DefaultCase_DefaultBehaviour()
        {
            ReinforceStrategy strategy = new ReinforceStrategy();

            Tower fromTower = new AttackingTower();
            Tower toTower = new AttackingTower();

            toTower.unitCount = 5;

            strategy.ExecuteStrategy(fromTower, toTower, 10);

            Assert.AreEqual(15, toTower.unitCount);
        }

        [TestMethod()]
        public void ExecuteStrategyTest_OverMaxInt_NegativeUnitCount()
        {
            ReinforceStrategy strategy = new ReinforceStrategy();

            Tower fromTower = new AttackingTower();
            Tower toTower = new AttackingTower();

            toTower.unitCount = 2147483647;

            strategy.ExecuteStrategy(fromTower, toTower, 10);

            Assert.IsTrue(0 > toTower.unitCount);
        }
    }
}