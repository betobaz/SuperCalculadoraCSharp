using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SuperCalculator;
namespace TestUnit
{
    [TestFixture]
    public class ExpressionFixerTests
    {
        ExpressionFixer _fixer;
        List<MathExpression> _expressions;

        [SetUp]
        public void SetUp()
        {
            _fixer = new ExpressionFixer();
            _expressions = new List<MathExpression>();
        }

        /*[Test]
        public void SplitExpressionWhenOperatorAtTheEnd()
        {
            _expressions.Add(new MathExpression("2 +"));
            _fixer.FixExpressions(_expressions);
            List<string> expressions = new List<string>();
            for (int item = 0; item < _expressions.Count; item++)
            {
                Console.Out.WriteLine(_expressions[item].Expression);
                expressions.Add(_expressions[item].Expression);
            }
            Assert.Contains("2", _expressions);
            Assert.Contains("+", _expressions);
        }*/

        [Test]
        public void Trim()
        {
            _expressions.Add(new MathExpression(" * "));
            _fixer.FixExpressions(_expressions);
            Assert.AreEqual("*", _expressions[0].Expression);
        }        
        
    }
}
