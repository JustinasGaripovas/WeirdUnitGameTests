using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.GameLogic.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeirdUnitBE.GameLogic.Map.Tests
{
    [TestClass()]
    public class MapServiceTests
    {
        [TestMethod()]
        public void GetInitialTowerPositionTest()
        {
            Position initialTowerPosition = MapService.GetInitialTowerPosition();

            Assert.AreEqual(initialTowerPosition, new Position(0, 4));
        }

        [TestMethod()]
        public void GetInitialEnemyTowerPositionTest()
        {
            Position initialTowerPosition = MapService.GetInitialEnemyTowerPosition();

            Assert.AreEqual(initialTowerPosition, new Position(9, 5));
        }

        [TestMethod()]
        public void GetDefaultMapConnectionsTest()
        {
            IDictionary<Position, Position[]> conenctionsBetweenTowers = MapService.GetDefaultMapConnections();

            Assert.IsInstanceOfType(conenctionsBetweenTowers, typeof(IDictionary<Position, Position[]>));
        }

        [TestMethod()]
        public void GetDefaultMapTest()
        {
            List<Position> givenPositions = MapService.GetDefaultMap();

            List<Position> expectedPositions = new List<Position>();

            expectedPositions.Add(new Position(0, 4));
            expectedPositions.Add(new Position(0, 2));
            expectedPositions.Add(new Position(2, 2));
            expectedPositions.Add(new Position(4, 1));
            expectedPositions.Add(new Position(3, 4));
            expectedPositions.Add(new Position(2, 6));
            expectedPositions.Add(new Position(7, 3));
            expectedPositions.Add(new Position(9, 5));
            expectedPositions.Add(new Position(9, 7));
            expectedPositions.Add(new Position(7, 7));
            expectedPositions.Add(new Position(5, 8));
            expectedPositions.Add(new Position(6, 5));

            for (int i = 0; i < expectedPositions.Count; i++)
            {
                Assert.AreEqual(expectedPositions[i], givenPositions[i]);
            }
        }

        [TestMethod()]
        public void GetDefaultMapDimensionsTest()
        {
            Assert.AreEqual((10, 10), MapService.GetDefaultMapDimensions());
        }

        [TestMethod()]
        public void GetDefaultGameSpeedTest()
        {
            Assert.AreEqual(0.3, MapService.GetDefaultGameSpeed());
        }

        [TestMethod()]
        public void GetDefaultMapWithoutInitialTowersTest()
        {
            List<Position> givenPositions = MapService.GetDefaultMapWithoutInitialTowers();
            List<Position> expectedPositions = new List<Position>();

            expectedPositions.Add(new Position(0, 4));
            expectedPositions.Add(new Position(0, 2));
            expectedPositions.Add(new Position(2, 2));
            expectedPositions.Add(new Position(4, 1));
            expectedPositions.Add(new Position(3, 4));
            expectedPositions.Add(new Position(2, 6));
            expectedPositions.Add(new Position(7, 3));
            expectedPositions.Add(new Position(9, 5));
            expectedPositions.Add(new Position(9, 7));
            expectedPositions.Add(new Position(7, 7));
            expectedPositions.Add(new Position(5, 8));
            expectedPositions.Add(new Position(6, 5));

            expectedPositions.Remove(new Position(0, 4));
            expectedPositions.Remove(new Position(9, 5));

            for (int i = 0; i < expectedPositions.Count; i++)
            {
                Assert.AreEqual(expectedPositions[i], givenPositions[i]);
            }

        }
    }
}