using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using SuperCalculator;

namespace SuperCalculator
{
    public class CalcProxy: CalculatorProxy
    {
        private BasicCalculator _calculator;
        private LimitsValidator _validator;
                

        public CalcProxy(Validator validator, BasicCalculator calculator)
        {
            // TODO: Complete member initialization
            _validator = validator;
            _calculator = calculator;
        }

        public BasicCalculator Calculator
        {
            get { return _calculator; }
            set { _calculator = value; }
        }

        public int BinaryOperation(SingleBinaryOperation operation, int arg1, int arg2)
        {
            if(_validator != null)
                _validator.ValidateArgs(arg1, arg2);
            int result = 0;
            MethodInfo[] calculatorMethods = _calculator.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo method in calculatorMethods)
            {
                if (method == operation.Method)
                {
                    result = (int)method.Invoke(_calculator, new object[] { arg1, arg2 });
                }
            }
            if (_validator != null)
                _validator.ValidateResult(result);
            return result;
        }
    }
}
