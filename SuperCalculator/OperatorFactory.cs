using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class OperatorFactory
    {
        public static MathOperator Create(MathToken token)
        {
            return Create(token.Token);
        }
        public static MathOperator Create(string token)
        {
            switch (token)
            {
                case "*":
                    return new MultiplyOperator();
                case "/":
                    return new DivideOperator();
                case "+":
                    return new AddOperator();
                case "-":
                    return new SubstractOperator();
            }
            throw new InvalidOperationException("The given token is not a valid operator:" + token.ToString());
        }
    }
}
