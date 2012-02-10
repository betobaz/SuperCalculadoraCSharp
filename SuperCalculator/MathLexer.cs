using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class MathLexer : Lexer
    {        
        ExpressionFixer _fixer;

        static char OPEN_SUBEXPRESSION = '(';
        static char CLOSE_SUBEXPRESSION = ')';

        public MathLexer(ExpressionFixer fixer)
        {            
            _fixer = fixer;
        }
        public List<MathToken> GetTokens(string expression)
        {            
            string[] items = splitExpression(expression);            
            return createTokensFromString(items);
        }

        private string[] splitExpression(string expression)
        {
            return expression.Split((new char[] { ' ', '\t' }), StringSplitOptions.RemoveEmptyEntries);
        }

        private List<MathToken> createTokensFromString(string[] items)
        {
            List<MathToken> tokens = new List<MathToken>();
            foreach (String item in items)
            {
                if (MathRegex.isOperator(item))
                    tokens.Add(OperatorFactory.Create(item));
                else
                    tokens.Add(new MathNumber(item));
            }
            return tokens;
        }

        public List<MathExpression> GetExpressions(string expression)
        {
            int openedParanthesis = 0;
            ExpressionBuilder expBuilder = ExpressionBuilder.Create();
            expBuilder.InputText = expression;
            getExpressions(expBuilder, ref openedParanthesis);

            if (openedParanthesis != 0)
                throw new InvalidOperationException("Parenthesis do not match");
            _fixer.FixExpressions(expBuilder.AllExpressions);
            expBuilder.AllExpressions.Sort();
            return expBuilder.AllExpressions;                       
        }      

        private void getExpressions(ExpressionBuilder expBuilder, ref int openedParanthesis)
        {
            while (expBuilder.ThereAreMoreChars())
            {
                char currentChar = expBuilder.GetCurrentChar();
                if (currentChar == OPEN_SUBEXPRESSION)
                {
                    openedParanthesis++;
                    getExpressions(expBuilder.ProcessNewSugExpression(), ref openedParanthesis);
                }
                else if (currentChar == CLOSE_SUBEXPRESSION)
                {
                    expBuilder.SubExpressionEndFound();
                    openedParanthesis--;
                    return;
                }
                else
                    expBuilder.AddSubExpressionChar();

            }
            expBuilder.SubExpressionEndFound();            
            //console.Out.WriteLine()
        }

        
    }
}
