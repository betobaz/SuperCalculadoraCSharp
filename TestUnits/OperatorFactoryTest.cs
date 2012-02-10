using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperCalculator;
using NUnit.Framework;

namespace TestUnit
{
    public class OperatorFactoryTest
    {
        [Test]
        public void CreateMultiplyOperator()
        {
            MathOperator op = OperatorFactory.Create("*");
            Assert.AreEqual(op.Precedence, 2);
        }

        [Test]
        public void CreateDivisionOperator()
        {
            MathOperator op = OperatorFactory.Create("/");
            Assert.AreEqual(op.Precedence, 2);
        }
    }
}
