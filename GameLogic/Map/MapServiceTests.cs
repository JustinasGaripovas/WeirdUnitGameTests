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
            IDictionary<Position, Position[]> expectedConnections = new Dictionary<Position, Position[]>
            {
                [new Position(0, 4)] =
                new Position[]
                {
                    new Position(0, 2),
                    new Position(2, 2),
                    new Position(2, 6),
                },

                [new Position(0, 2)] =
                new Position[]
                {
                    new Position(0, 4),
                    new Position(2, 2),
                },

                [new Position(2, 2)] =
                new Position[]
                {
                    new Position(0, 4),
                    new Position(0, 2),
                    new Position(4, 1),
                    new Position(3, 4),
                },

                [new Position(4, 1)] =
                new Position[]
                {
                    new Position(7, 3),
                    new Position(2, 2),
                    new Position(3, 4),
                },

                [new Position(3, 4)] =
                new Position[]
                {
                    new Position(4, 1),
                    new Position(2, 2),
                    new Position(6, 5),
                    new Position(2, 6),
                },

                [new Position(2, 6)] =
                new Position[]
                {
                    new Position(3, 4),
                    new Position(0, 4),
                    new Position(5, 8),
                },

                [new Position(7, 3)] =
                new Position[]
                {
                    new Position(4, 1),
                    new Position(9, 5),
                    new Position(6, 5),
                },

                [new Position(9, 5)] =
                new Position[]
                {
                    new Position(9, 7),
                    new Position(7, 7),
                    new Position(7, 3),
                },

                [new Position(9, 7)] =
                new Position[]
                {
                    new Position(9, 5),
                    new Position(7, 7),
                },

                [new Position(7, 7)] =
                new Position[]
                {
                    new Position(6, 5),
                    new Position(9, 5),
                    new Position(9, 7),
                    new Position(5, 8),
                },

                [new Position(5, 8)] =
                new Position[]
                {
                    new Position(2, 6),
                    new Position(6, 5),
                    new Position(7, 7),
                },

                [new Position(6, 5)] =
                new Position[]
                {
                    new Position(7, 3),
                    new Position(7, 7),
                    new Position(5, 8),
                    new Position(3, 4),
                }
            };

            Assert.AreEqual(conenctionsBetweenTowers, expectedConnections);
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

            Assert.AreEqual(expectedPositions, MapService.GetDefaultMap());
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