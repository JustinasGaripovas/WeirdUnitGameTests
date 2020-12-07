using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.Middleware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.WebSockets;
using Moq;
using System.Collections.Concurrent;

namespace WeirdUnitBE.Middleware.Tests
{
    [TestClass()]
    public class WebSocketServerManagerTests
    {
        WebSocketServerManager socketServerManager;
        Mock<WebSocket> socketMock;

        [TestInitialize]
        public void Setup()
        {
            this.socketServerManager = new WebSocketServerManager();
            this.socketMock = new Mock<WebSocket>();
        }

        [TestMethod()]
        public void GetAllSocketsTest_MultipleSockets_ReturnsAllSockets()
        {
            socketServerManager.AddSocketToSocketPool(socketMock.Object);
            socketServerManager.AddSocketToSocketPool(socketMock.Object);
            socketServerManager.AddSocketToSocketPool(socketMock.Object);

            ConcurrentDictionary<string, WebSocket> returnedSockets = socketServerManager.GetAllSockets();

            Assert.AreEqual(3, returnedSockets.Count);
        }

        [TestMethod()]
        public void GetAllSocketsTest_NoSockets_ReturnsNoSockets()
        {
            ConcurrentDictionary<string, WebSocket> returnedSockets = socketServerManager.GetAllSockets();

            Assert.AreEqual(0, returnedSockets.Count);
        }

        [TestMethod()]
        public void GetConnectionIdFromLobbyTest_OneSocket_ConnId()
        {
            string connId = socketServerManager.AddSocketToSocketPool(socketMock.Object);
            socketServerManager.AddClientToLobbyPool(connId);

            Assert.AreEqual(connId, socketServerManager.GetConnectionIdFromLobby());
        }

        [TestMethod()]
        [ExpectedException(typeof(EnemyNotFoundException),
        "Still waiting for another player to join the room...")]
        public void GetConnectionIdFromLobbyTest_NoSockets_EnemyNotFoundException()
        {
            socketServerManager.GetConnectionIdFromLobby();
        }

        [TestMethod()]
        public void GetSocketFromSocketPoolTest_SocketConnId_ValidSocket()
        {
            string connId = socketServerManager.AddSocketToSocketPool(socketMock.Object);
            WebSocket returnedSocket = socketServerManager.GetSocketFromSocketPool(connId);

            Assert.IsNotNull(returnedSocket);
            Assert.AreEqual(socketMock.Object, returnedSocket);
        }

        [TestMethod()]
        public void AddSocketToSocketPoolTest_Socket_SocketAdded()
        {
            string connId = socketServerManager.AddSocketToSocketPool(socketMock.Object);
            WebSocket returnedSocket = socketServerManager.GetSocketFromSocketPool(connId);

            Assert.IsTrue(connId.Length > 0);
            Assert.IsNotNull(returnedSocket);
        }

        [TestMethod()]
        public void AddClientToLobbyPoolTest_ConnId_SocketAdded()
        {
            string connId = socketServerManager.AddSocketToSocketPool(socketMock.Object);
            socketServerManager.AddClientToLobbyPool(connId);

            Assert.AreEqual(connId, socketServerManager.GetConnectionIdFromLobby());
        }

        [TestMethod()]
        public void RemoveSocketFromAllPoolsTest_ConnId_SocketRemovedFromPools()
        {
            string connId = socketServerManager.AddSocketToSocketPool(socketMock.Object);
            socketServerManager.AddClientToLobbyPool(connId);

            socketServerManager.RemoveSocketFromAllPools(connId);

            Assert.ThrowsException <EnemyNotFoundException> (() =>
            {
                socketServerManager.GetConnectionIdFromLobby();
            });

            Assert.ThrowsException<System.Collections.Generic.KeyNotFoundException>(() =>
            {
                socketServerManager.GetSocketFromSocketPool(connId);
            });
        }

        [TestMethod()]
        public void RemoveSocketsFromLobbyPoolTest_MultipleIds_ReturnsEmptySockets()
        {
            string connId1 = socketServerManager.AddSocketToSocketPool(socketMock.Object);
            string connId2 = socketServerManager.AddSocketToSocketPool(socketMock.Object);

            string[] connIds = { connId1, connId2 };

            socketServerManager.RemoveSocketsFromLobbyPool(connIds);

            Assert.ThrowsException<EnemyNotFoundException>(() =>
            {
                socketServerManager.GetConnectionIdFromLobby();
            });

            Assert.ThrowsException<EnemyNotFoundException>(() =>
            {
                socketServerManager.GetConnectionIdFromLobby();
            });
        }
    }
}