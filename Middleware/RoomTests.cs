using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.Middleware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.WebSockets;

namespace WeirdUnitBE.Middleware.Tests
{
    [TestClass()]
    public class RoomTests
    {
        [TestMethod()]
        public void GenerateRoomUUIDTest()
        {
            Assert.IsTrue(Room.GenerateRoomUUID().Length > 0);
        }
    }
}