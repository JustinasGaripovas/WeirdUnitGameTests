using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.GameLogic.Strategies;
using WeirdUnitBE.GameLogic.TowerPackage.Towers;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeirdUnitBE.GameLogic.Strategies.Tests
{
    [TestClass()]
    public class AttackStrategyTests
    {
        [TestMethod()]
        public void ExecuteStrategyTest_MoreAttackingUnits_OwnerChangesAndUnitCountCorrect()
        {
            AttackStrategy strategy = new AttackStrategy();

            Tower fromTower = new AttackingTower();
            Tower toTower = new AttackingTower();

            fromTower.owner = "Owner1";
            toTower.owner = "Owner2";

            toTower.unitCount = 5;

            strategy.ExecuteStrategy(fromTower, toTower, 10);

            Assert.AreEqual("Owner1", toTower.owner);
            Assert.AreEqual(5, toTower.unitCount);
        }

        [TestMethod()]
        public void ExecuteStrategyTest_MoreAttackingUnits_OwnerStaysTheSameAndUnitCountCorrect()
        {
            AttackStrategy strategy = new AttackStrategy();

            Tower fromTower = new AttackingTower();
            Tower toTower = new AttackingTower();

            fromTower.owner = "Owner1";
            toTower.owner = "Owner2";

            toTower.unitCount = 10;

            strategy.ExecuteStrategy(fromTower, toTower, 5);

            Assert.AreEqual("Owner2", toTower.owner);
            Assert.AreEqual(5, toTower.unitCount);
        }

    }
}