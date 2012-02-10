using System;
using System.Collections.Generic;
namespace SuperCalculator
{
    public interface TokenProcedence
    {
        MathOperator GetMaxPrecedence(List<MathToken> tokens);
    }
}
