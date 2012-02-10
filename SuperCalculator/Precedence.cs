using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class Precedence : TokenProcedence
    {
        public MathOperator GetMaxPrecedence(List<MathToken> tokens)
        {
            int precedence = 0;
            MathToken maxPrecedenceToken = null;

            int index = -1;
            foreach (MathToken token in tokens)
            {
                index++;
                if (token.Precedence >= precedence)
                {
                    precedence = token.Precedence;
                    maxPrecedenceToken = token;
                    maxPrecedenceToken.Index = index;
                }

            }
            return (MathOperator)maxPrecedenceToken;
        }
    }
}
