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
    public class ParserTests
    {
        
        private MathLexer _lexer;
        private MathRegex _expressionValidator;
        private ExpressionFixer _fixer;
        private MathParser _parser;
        private BasicCalculator _calculator;
        private CalculatorProxy _calcProxy;
        private Validator _validator;
        private Resolver _resolver;
        private Precedence _precedence;
        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
            _validator = new Validator(-20, 20);
            _calcProxy = new CalcProxy(_validator, _calculator);
            _expressionValidator = new MathRegex();
            _fixer = new ExpressionFixer();
            _lexer = new MathLexer(_fixer);
            _precedence = new Precedence();
            _resolver = new Resolver(_lexer, _calcProxy, _precedence);
            _parser = new MathParser(_lexer, _expressionValidator, _resolver);
        }

        [Test]
        public void GetTokens()
        {            
            List<MathToken> tokens = _lexer.GetTokens("2 + 2");
            Assert.AreEqual(3, tokens.Count);
            Assert.AreEqual("2", tokens[0].Token);
            Assert.AreEqual("+", tokens[1].Token);
            Assert.AreEqual("2", tokens[2].Token);
        }        

        [Test]
        public void ValidateMoreThanOneDigitExpression()
        {
            string expression = "25 + 287";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateSimpleExpressionWithAllOperators()
        {
            string operators = "+-*/";
            string expression = String.Empty;
            foreach (char operatorChar in operators)
            {
                expression = "2 " + operatorChar + " 2";
                Assert.IsTrue(MathRegex.IsExpressionValid(expression), "Failure with operator: " + operatorChar);
            }
        }

        [Test]
        public void ValidateWithSpaces()
        {
            string expression = "2    +   287";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsTrue(result);
        }

        /*[Test]
        public void ValidateFailsNoSpaces()
        {
            string expression = "2+7";
            bool result = _expressionValidator.IsExpressionValid(expression);
            Assert.IsTrue(result);
        }*/

        [Test]
        public void ValidateComplexExpression()
        {
            string expression = "2 + 7 - 2 * 4";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateComplexWrongExpression()
        {
            string expression = "2 + 7 a 2 b 4";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateSimpleWrongExpression()
        {
            string expression = "2a7";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateWrongExpressionWithValidaSubexpression()
        {
            string expression = "2 + 7 - 2 a 3 b";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateWithSeveralOperatorsTogether()
        {
            string expression = "+ + 7";
            bool result = MathRegex.IsExpressionValid(expression);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateWithNegativeNumers()
        {
            Assert.IsTrue(MathRegex.IsExpressionValid("-7 + 1"));
        }

        [Test]
        public void ValidateWithNegativeNumersAtTheEnd()
        {
            Assert.IsTrue(MathRegex.IsExpressionValid("7 - -1"));
        }

        [Test]
        public void GetTokensLognExpression()
        {
            List<MathToken> tokens = _lexer.GetTokens("2 - 1 + 3");
            Assert.AreEqual(5, tokens.Count);
            Assert.AreEqual("+", tokens[3].Token);
            Assert.AreEqual("3", tokens[4].Token);
        }

        /*[Test]
        public void GetTokensWrongExpression()
        {
            try
            {
                List<MathToken> tokens = _lexer.GetTokens("2 - 1 ++ 3");
                Assert.Fail("Exception did not arise!");
            }
            catch (InvalidOperationException) 
            { }
        }*/

        [Test]
        public void GetTokensWithSpaces()
        {
            List<MathToken> tokens = _lexer.GetTokens("5 -   88");
            Assert.AreEqual("5", tokens[0].Token);
            Assert.AreEqual("-", tokens[1].Token);
            Assert.AreEqual("88", tokens[2].Token);
        }


        [Test]
        public void processExpression20Operator()
        {
            Assert.AreEqual(6, _parser.ProcessExpression("3 + 1 + 2"));
        }

        [Test]
        public void ProcessExpressionWithPrecedence()
        {
            Assert.AreEqual(9, _parser.ProcessExpression("3 + 3 * 2"));
        }

        [Test]
        public void GetMaxPrecedence()
        {
            List<MathToken> tokens = _lexer.GetTokens("3 + 3 * 2");
            MathToken op = _precedence.GetMaxPrecedence(tokens);
            Assert.AreEqual(op.Token, "*");
        }

        [Test]
        public void ProcessAcceptanceExpression()
        {
            Assert.AreEqual(9, _parser.ProcessExpression("5 + 4 * 2 / 2"));
        }

        [Test]
        public void ProcessAcceptanceExpressionWithAllOperators()
        {
            Assert.AreEqual(8, _parser.ProcessExpression("5 + 4 - 1 * 2 / 2"));
        }

        [Test]
        public void ProcessAcceptanceExpressionWithParenthesis()
        {
            Assert.AreEqual(16, _parser.ProcessExpression("(2 + 2) * (3 + 1)"));
        }

        [Test]
        public void ProcessComplexNestedExpressions()
        {
            Assert.AreEqual(20, _parser.ProcessExpression("((2 + 2) + 1)  * (3 + 1)"));
        }

        [Test]
        public void ErrorAlProcesarDivisionResultaFraccion()
        {
            _parser.ProcessExpression("3 / 2");
            Assert.Fail("Error obtiene fracción");
        }

        [Test]
        public void ProcessExpressionWithNegative()
        {
            Assert.AreEqual(0, _parser.ProcessExpression("2 + -2"));
        }
    }

}
