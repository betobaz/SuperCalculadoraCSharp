using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class MathParser
    {
        
        Lexer _lexer;
        MathRegex _mathRegex;
        Resolver _resolver;        

        public MathParser(Lexer lexer, MathRegex mathRegex, Resolver resolver)
        {            
            _lexer = lexer;
            _resolver = resolver;
            _mathRegex = mathRegex;
        }        

        public int ProcessExpression(string expression)
        {
            Console.Out.WriteLine("ProcessExpression:" + expression);
            List<MathExpression> subExpressions = _lexer.GetExpressions(expression);
            String flatExpression = String.Empty;
            foreach (MathExpression subExp in subExpressions)
            {
                Console.Out.WriteLine("ProcessExpression:" + subExp.Expression);
                if (MathRegex.IsSubExpression(subExp.Expression))
                    flatExpression += _resolver.ResolveSimpleExpression(subExp.Expression);
                else
                    flatExpression += " " + subExp.Expression + " ";
            }
            return _resolver.ResolveSimpleExpression(flatExpression);
        }        
    }
}
