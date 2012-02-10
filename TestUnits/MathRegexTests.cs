using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SuperCalculator;

namespace TestUnit
{
    [TestFixture]
    public class MathRegexTests
    {
        MathRegex _mathRegex;

        [SetUp]
        public void SetUp()
        {
            _mathRegex = new MathRegex();
        }

        [Test]
        public void isSubExpression()
        {
            Assert.IsTrue(MathRegex.IsSubExpression("2 + 2"));
        }

        [Test]
        public void IsNumber()
        {
            Assert.IsTrue(MathRegex.IsNumber("22"));
        }

        [Test]
        public void IsOperator()
        {
            string operators = "*+/-";
            foreach (char op in operators)
                Assert.IsTrue(MathRegex.isOperator(op.ToString()));
        }
    }

}
