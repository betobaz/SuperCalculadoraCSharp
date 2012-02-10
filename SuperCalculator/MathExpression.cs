using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class MathExpression : IComparable
    {
        private string _expression;
        private int _order;

        public MathExpression(string expression)
        {            
            _expression = expression;
            _order = -1;
        }
        public MathExpression(string expression, int order)
        {            
            _expression = expression;
            _order = order;
        }

        public string Expression
        {
            get { return _expression; }
            set { _expression = value; }
        }

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public bool IsEmpty()
        {
            return _expression.Length == 0;
        }

        public int CompareTo(Object obj)
        {
            MathExpression exp = (MathExpression)obj;
            return _order.CompareTo(exp.Order);
        }
    }
}
