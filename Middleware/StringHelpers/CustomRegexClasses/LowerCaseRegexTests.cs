using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WeirdUnitBE.GameLogic;

namespace Tests
{
    [TestClass()]
    public class LowerCaseRegexTests
    {
        [TestMethod()]
        public void GetExpressionTest()
        {
            LowerCaseRegex lowerCaseExpression = new LowerCaseRegex();

            Regex lowerCaseRegex = new Regex(lowerCaseExpression.GetExpression());  

            string bigString = "Big";  

            MatchCollection matchedLowerCaseLetters = lowerCaseRegex.Matches(bigString);

            Assert.AreEqual(matchedLowerCaseLetters.Count, 2);
        }
    }
}