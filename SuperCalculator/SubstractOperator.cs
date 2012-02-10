using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class SubstractOperator: MathOperator
    {
        public SubstractOperator()
            : base(2)
        {
            _token = "-";
        }

        public override int Resolve(int a, int b)
        {

            return _calcProxy.BinaryOperation(_calcProxy.Calculator.Substract, a, b);
        }
    }
}
