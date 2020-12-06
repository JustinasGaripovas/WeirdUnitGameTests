using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WeirdUnitBE.GameLogic;

namespace Tests
{
    [TestClass()]
    public class UpperCaseRegexTests
    {
        [TestMethod()]
        public void GetExpressionTest()
        {
            UpperCaseRegex upperCaseExpression = new UpperCaseRegex();

            Regex upperCaseRegex = new Regex(upperCaseExpression.GetExpression());  

            string smallString = "SMall";  

            MatchCollection matchedUpperCaseLetters = upperCaseRegex.Matches(smallString);

            Assert.AreEqual(matchedUpperCaseLetters.Count, 2);
        }

        
    }
}