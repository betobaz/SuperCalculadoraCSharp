using System;

namespace SuperCalculator
{
    public class Calculator: BasicCalculator
    {                

        public int Add(int arg1, int arg2)
        {
            int result = arg1 + arg2;
            return result;
        }

        public int Substract(int arg1, int arg2)
        {
            int result = arg1 - arg2;
            return result;
        }

        public int Multiply(int arg1, int arg2)
        {
            return arg1 * arg2;            
        }

        public int Divide(int arg1, int arg2)
        {
            return arg1 / arg2;
        }
    }
}
