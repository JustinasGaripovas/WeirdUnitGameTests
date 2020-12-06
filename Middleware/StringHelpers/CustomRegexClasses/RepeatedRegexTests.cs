using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WeirdUnitBE.GameLogic;

namespace Tests
{
    [TestClass()]
    public class RepeatedRegexTests
    {
        [TestMethod()]
        public void GetExpressionTest()
        {
            RepeatedRegex repeatedExpression = new RepeatedRegex();

            Regex repeatedRegex = new Regex("a"+repeatedExpression.GetExpression());  

            string repeatedString = "aaaaa";  

            MatchCollection matchedLetters = repeatedRegex.Matches(repeatedString);

            Assert.AreEqual(matchedLetters.Count, 2);
        }
    }
}