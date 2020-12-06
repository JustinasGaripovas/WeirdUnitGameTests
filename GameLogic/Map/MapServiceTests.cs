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

            Assert.Equals(initialTowerPosition, new Position(0, 4));
        }

        [TestMethod()]
        public void GetInitialEnemyTowerPositionTest()
        {
            Position initialTowerPosition = MapService.GetInitialEnemyTowerPosition();

            Assert.Equals(initialTowerPosition, new Position(9, 5));
        }

        [TestMethod()]
        public void GetDefaultMapConnectionsTest()
        {
            IDictionary<Position, Position[]> conenctionsBetweenTowers = MapService.GetDefaultMapConnections();
            IDictionary<Position, Position[]> expectedConnections = new Dictionary<Position, Position[]>();

            expectedConnections[new Position(0, 4)] =
                new Position[]
                {
                    new Position(0, 2),
                    new Position(2, 2),
                    new Position(2, 6),
                };

            expectedConnections[new Position(0, 2)] =
                new Position[]
                {
                    new Position(0, 4),
                    new Position(2, 2),
                };

            expectedConnections[new Position(2, 2)] =
                new Position[]
                {
                    new Position(0, 4),
                    new Position(0, 2),
                    new Position(4, 1),
                    new Position(3, 4),
                };

            expectedConnections[new Position(4, 1)] =
                new Position[]
                {
                    new Position(7, 3),
                    new Position(2, 2),
                    new Position(3, 4),
                };

            expectedConnections[new Position(3, 4)] =
                new Position[]
                {
                    new Position(4, 1),
                    new Position(2, 2),
                    new Position(6, 5),
                    new Position(2, 6),
                };

            expectedConnections[new Position(2, 6)] =
                new Position[]
                {
                    new Position(3, 4),
                    new Position(0, 4),
                    new Position(5, 8),
                };

            expectedConnections[new Position(7, 3)] =
                new Position[]
                {
                    new Position(4, 1),
                    new Position(9, 5),
                    new Position(6, 5),
                };

            expectedConnections[new Position(9, 5)] =
                new Position[]
                {
                    new Position(9, 7),
                    new Position(7, 7),
                    new Position(7, 3),
                };

            expectedConnections[new Position(9, 7)] =
                new Position[]
                {
                    new Position(9, 5),
                    new Position(7, 7),
                };

            expectedConnections[new Position(7, 7)] =
                new Position[]
                {
                    new Position(6, 5),
                    new Position(9, 5),
                    new Position(9, 7),
                    new Position(5, 8),
                };

            expectedConnections[new Position(5, 8)] =
                new Position[]
                {
                    new Position(2, 6),
                    new Position(6, 5),
                    new Position(7, 7),
                };

            expectedConnections[new Position(6, 5)] =
                new Position[]
                {
                    new Position(7, 3),
                    new Position(7, 7),
                    new Position(5, 8),
                    new Position(3, 4),
                };

            Assert.AreSame(conenctionsBetweenTowers, expectedConnections);
        }

        [TestMethod()]
        public void GetDefaultMapTest()
        {
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

            Assert.AreSame(expectedPositions, MapService.GetDefaultMap());
        }

        [TestMethod()]
        public void GetDefaultMapDimensionsTest()
        {
            Assert.AreSame((10, 10), MapService.GetDefaultMapDimensions());
        }

        [TestMethod()]
        public void GetDefaultGameSpeedTest()
        {
            Assert.AreSame(0.3f, MapService.GetDefaultGameSpeed());
        }

        [TestMethod()]
        public void GetDefaultMapWithoutInitialTowersTest()
        {
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


            Assert.AreSame(expectedPositions, MapService.GetDefaultMapWithoutInitialTowers());
        }
    }
}