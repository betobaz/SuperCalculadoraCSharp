using System;
using System.Collections.Generic;
namespace SuperCalculator
{
    public interface Lexer
    {
        List<MathToken> GetTokens(string expression);
        List<MathExpression> GetExpressions(string expression);
        //List<MathExpression> GetTokens(string expression);
    }
}
