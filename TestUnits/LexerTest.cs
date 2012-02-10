using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using SuperCalculator;

namespace TestUnit
{
    [TestFixture]
    public class LexerTest
    {
        private MathLexer _lexer;
        private MathRegex _expressionValidator;
        private ExpressionFixer _fixer;
        private Resolver _resolve;
        private CalculatorProxy _calcProxy;        
        private Precedence _precedence;
        private BasicCalculator _calculator;
        private Validator _validator;
        [SetUp]
        public void SetUp()
        {
            _expressionValidator = new MathRegex();
            _fixer = new ExpressionFixer();
            _lexer = new MathLexer(_fixer);
            _calculator = new Calculator();
            _validator = new Validator(-20, 20);
            _calcProxy = new CalcProxy(_validator, _calculator);

        }
        [Test]
        public void GetExpressionsWithNestedParentesis()
        {
            List<MathExpression> expressions = _lexer.GetExpressions("((2) + 2)");
            failIfOtherSubExpressionThan(expressions, "2", "+");
        }
        [Test]
        public void GetNestedExpression()
        {
            List<MathExpression> expressions = _lexer.GetExpressions("((2 + 1) + 2)");
            Assert.AreEqual(3, expressions.Count);
            failIfOtherSubExpressionThan(expressions, "2 + 1", "+", "2");
        }

        [Test]
        public void GetExpressionWithParenthesisAthTheEnd()
        {
            List<MathExpression> expressions = _lexer.GetExpressions("2 + (3 * 1)");
            Console.Out.WriteLine("trae:" + expressions.Count);
            Console.Out.WriteLine("expresion1:" + expressions[0].Expression);
            Console.Out.WriteLine("expresion2:" + expressions[1].Expression);
            Assert.AreEqual(2, expressions.Count);
            failIfOtherSubExpressionThan(expressions, "2 +", "3 * 1");
        }

        [Test]
        public void ThrowExceptionOnOpenParenthesis()
        {
            try
            {
                List<MathExpression> expression = _lexer.GetExpressions("(2 + 3 * 1");
                Assert.Fail("Exception didn't arise!");
            }
            catch(InvalidOperationException)
            {

            }
        }

        [Test]
        public void GetExpressionWithTwoGroups()
        {
            List<MathExpression> expressions = _lexer.GetExpressions("(2 + 2) * (3 + 1)");
            Assert.AreEqual(3, expressions.Count);
            failIfOtherSubExpressionThan(expressions, "3 + 1", "2 + 2" , "*");
        }
        [Test]
        public void GetSeveralParenthessExpressionInOrder()
        {
            List<MathExpression> expressions = _lexer.GetExpressions("(2 + 2) * (3 + 1)");
            foreach (MathExpression exp in expressions)
                Console.Out.WriteLine("x: " + exp + " .");
            Assert.AreEqual("2 + 2", expressions[0].Expression);
            Assert.AreEqual("*", expressions[1].Expression);
            Assert.AreEqual("3 + 1", expressions[2].Expression);
        }

        [Test]
        public void GetTokensRightSubClasses()
        {
            List<MathToken> tokens = _lexer.GetTokens("2 + 2");
            Assert.IsTrue(tokens[0] is MathNumber);
            Assert.IsTrue(tokens[1] is MathOperator);
        }

        
       
        /*[Test]
        public void GetTokensWrongExpression()
        {
            try
            {
                List<MathExpression> tokens = _lexer.GetExpressions("2 - 1 ++ 3");
                Assert.Fail("Exception did not arise!");
            }
            catch (InvalidOperationException)
            { }
        }*/

        private void failIfOtherSubExpressionThan(List<MathExpression> expressions, params string[] expectedSubExpressions)
        {
            bool isSubExpression = false;
            Console.Out.WriteLine("cuantos lista:" + expressions.Count);
            foreach (string subExpression in expectedSubExpressions)
            {
                Console.Out.WriteLine("sub expresion esperada:" + subExpression);
                isSubExpression = false;
                foreach (MathExpression exp in expressions)
                {
                    Console.Out.WriteLine(exp.Expression);
                    if (exp.Expression == subExpression)
                    {
                        isSubExpression = true;
                        break;
                    }
                }
                if (!isSubExpression)
                    Assert.Fail("Wrong expression split:" + subExpression);
            }
        }

        

    }

}
