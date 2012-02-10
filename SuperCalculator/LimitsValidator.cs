using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public interface LimitsValidator
    {
        void SetLimits(int a, int b);
        void ValidateArgs(int a, int b);
        void ValidateResult(int a);
    }
}
