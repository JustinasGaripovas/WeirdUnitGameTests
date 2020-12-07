using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeirdUnitBE.Middleware.XmlHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeirdUnitBE.Middleware.XmlHandling.Tests
{
    [TestClass()]
    public class AdapterTests
    {
        [TestMethod()]
        public void ConvertToJsonTest_XMLMessage_JsonMessage()
        {
            Adapter adapter = new Adapter();
            string xmlMessage =
                @"<?xml version='1.0'?><TemperatureC>-1</TemperatureC>";

            string converted = adapter.ConvertToJson(xmlMessage);
            Console.WriteLine(converted);
            string expectedJsonMessage = "{\"?xml\":{\"@version\":\"1.0\"},\"TemperatureC\":\"-1\"}";
            Assert.AreEqual(expectedJsonMessage, converted);
        }

        [TestMethod()]
        public void ConvertToJsonTest_JsonMessage_JsonMessage()
        {
            Adapter adapter = new Adapter();
            string jsonMessage =
                @"{"",""TemperatureC"":-1,""Summary"":""Cold""} ";

            string converted = adapter.ConvertToJson(jsonMessage);

            Assert.AreEqual(jsonMessage, converted);
        }
    }
}