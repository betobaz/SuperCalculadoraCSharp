using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Castle.Windsor;
//using Castle.Windsor.Configuration.Interpreters;

namespace SuperCalculator
{
    public abstract class MathOperator : MathToken
    {        
        protected CalculatorProxy _calcProxy;
        
        public MathOperator(int precedence)
            : base(precedence)
        {            
            _calcProxy = new CalcProxy(new Validator(-100, 100), new Calculator());          
        }
        
        public CalculatorProxy CalcProxy
        {
            get { return _calcProxy; }
            set { _calcProxy = value; }
        }

        public override int Resolve()
        {
            return Resolve(_previousToken.Resolve(), _nextToken.Resolve());
        }

        public abstract int Resolve(int a, int b);        
    }
    
}
