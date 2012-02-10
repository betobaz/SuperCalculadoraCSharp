using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class MathRegex
    {
        public static string operators = @"[\+|\-|/|\*]";

        public static bool IsExpressionValid(string expression)
        {
            Regex fullRegex = new Regex(@"^\-?\d+((\s+)" + operators + @"(\s+)\-?\d+)+$");
            Regex singleOperator = new Regex(@"^" + operators + "$");
            Regex singleNumber = new Regex(@"^\d$");
            //Console.Out.WriteLine("hola: " + expression);
            return (fullRegex.IsMatch(expression, 0) || singleOperator.IsMatch(expression, 0) || singleNumber.IsMatch(expression, 0));
        }        

        public static bool IsNumberAndOperator(string expression)
        {
            Regex startsWithOperator = new Regex(@"^(\s*)(" + operators + @")(\s+)");
            Regex endsWithOperator = new Regex(@"(\s+)(" + operators + @")(\s+)$");
            string exp = expression;            
            if (startsWithOperator.IsMatch(exp) || endsWithOperator.IsMatch(exp))
            {                
                return true;
            }
            return false;
        }

        public static bool IsSubExpression(string exp)
        {
            Regex operatorRegex = new Regex(operators);
            Regex numberRegex = new Regex(@"\d+");
            if (numberRegex.IsMatch(exp) && operatorRegex.IsMatch(exp))
                return true;
            return false;
        }

        public static bool IsNumber(string token)
        {
            return IsExactMatch(token, @"\d+");
        }

        public static bool isOperator(string token)
        {            
            return IsExactMatch(token, operators);
        }

        public static bool IsExactMatch(string token, string regex)
        {
            Regex exactRegex = new Regex(@"^" + regex + "$");
            return exactRegex.IsMatch(token, 0);
        }
    }
}
