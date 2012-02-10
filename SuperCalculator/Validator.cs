using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class Validator: LimitsValidator
    {
        private int _upperLimit;
        private int _lowerLimit;
        /*private int p;
        private int p_2;        */

        public Validator(int lowerLimit, int upperLimit)
        {
            SetLimits(lowerLimit, upperLimit);            
        }

        /*public Validator(int lowerLimit, int upperLimit)
        {
            // TODO: Complete member initialization
            _upperLimit = lowerLimit;
            _lowerLimit = upperLimit;
        }*/
        public int LowerLimit
        {
            get { return _lowerLimit; }
            set { _lowerLimit = value; }
        }

        public int UpperLimit
        {
            get { return _upperLimit; }
            set { _upperLimit = value; }
        }

        public void SetLimits(int arg1, int arg2)
        {
            _lowerLimit = arg1;
            _upperLimit = arg2;
        }

        public void ValidateArgs(int arg1, int arg2)
        {
            breakIfOverflow(arg1, "First artument exceeds limits");
            breakIfOverflow(arg2, "Second artument exceeds limits");
        }
        
        private void breakIfOverflow(int arg, string msg)
        {
            if(ValueExceedLimits(arg))
                throw new OverflowException();
        }
       bool ValueExceedLimits(int arg)
        {
            if (arg > _upperLimit)
                return true;
            if (arg < _lowerLimit)
                return true;
            return false;
        }

        public void ValidateResult(int result)
        {
            breakIfOverflow(result, "Result exceeds limits");
        }
    }
}
