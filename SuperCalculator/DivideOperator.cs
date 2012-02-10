using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class DivideOperator: MathOperator
    {
        public DivideOperator()
            : base(2)
        {
            _token = "/";
        }

        public override int Resolve(int a, int b)
        {
            int result = _calcProxy.BinaryOperation(_calcProxy.Calculator.Divide, a, b);
            Console.Out.WriteLine("DivideOperator result:" + result);
            return result;
        }
    }
}
