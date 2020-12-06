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
<<<<<<< HEAD
            RepeatedRegex repeatedExpression = new RepeatedRegex();

            Regex repeatedRegex = new Regex("a"+repeatedExpression.GetExpression());  

            string repeatedString = "aaaaa";  

            MatchCollection matchedLetters = repeatedRegex.Matches(repeatedString);

            Assert.AreEqual(matchedLetters.Count, 2);
=======
            UpperCaseRegex upperCase = new UpperCaseRegex();

            Assert.Fail();
>>>>>>> 7c3dcacf40749b89dfc777e1ac64f91c18cd0932
        }
    }
}