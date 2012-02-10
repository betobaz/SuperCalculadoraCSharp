using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public class ExpressionFixer
    {
        MathRegex _mathRegex;
        public ExpressionFixer(MathRegex mathRegex)
        {
            _mathRegex = mathRegex; 
        }

        public ExpressionFixer()
        {
            // TODO: Complete member initialization
            _mathRegex = new MathRegex();
        }

        public void FixExpressions(List<MathExpression> expressions)
        {
            bool listHasChanged = true;
            while (listHasChanged)
            {
                listHasChanged = false;
                for (int i = 0; i < expressions.Count; i++)
                {
                    expressions[i].Expression = expressions[i].Expression.Trim();
                    if (MathRegex.IsNumberAndOperator(expressions[i].Expression))
                    {
                        splitByOperator(expressions, expressions[i].Expression, i);
                        listHasChanged = true;
                        break;
                    }
                    if(expressions[i].IsEmpty())
                    {
                        expressions.RemoveAt(i);
                        listHasChanged = true;
                        break;
                    }
                        
                }
            }
        }

       
        
        private void splitByOperator(List<MathExpression> expressions, string inputExpression, int position)
        {
            string[] nextExps = Regex.Split(inputExpression, @"(\+|\-|/|\*)");
            int j = position;
            expressions.RemoveAt(j);
            foreach (string subExp in nextExps)
            {
                expressions.Insert(j, new MathExpression(subExp.Trim()));
                j++;
            }
        }

        private bool isNumberAndOperatorThenSplit(List<MathExpression> expressions, int index)
        {

            Regex startsWithOperator = new Regex(@"^(\s*)([\+|\-|/|\*])(\s+)");
            Regex endsWithOperator = new Regex(@"(\s+)([\+|\-|/|\*])(\s+)$");

            string exp = expressions[index].Expression;
            exp = exp.Trim();
            if (startsWithOperator.IsMatch(exp) || endsWithOperator.IsMatch(exp))
            {
                splitByOperator(expressions, exp, index);
                return true;
            }
            return false;
        }

        private bool IsEmptyExpressionThenRemove(List<MathExpression> expressions, int index)
        {
            if (expressions[index].Expression.Length == 0)
            {
                expressions.RemoveAt(index);
                return true;
            }
            return false;
        }

        private bool DoesExpressionStartsWitOperator(List<string> expressions, int index)
        {
            Regex regex = new Regex(@"^(\s*)[+|\-|/|\*](\s+)");
            if (regex.IsMatch(expressions[index]))
            {
                string exp = expressions[index];
                exp = exp.Trim();
                string[] nexExps = exp.Split(new char[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                expressions[index] = nexExps[0];
                expressions.Insert(index + 1, nexExps[1]);
                return true;
            }
            return false;
        }

        public void CleanEmptyExpressions(List<string> expressions)
        {
            bool endOfList = false;
            while (!endOfList)
            {
                endOfList = true;
                for (int i = 0; i < expressions.Count; i++)
                {
                    if (expressions[i].Length == 0)
                    {
                        expressions.RemoveAt(i);
                        endOfList = false;
                        break;
                    }
                }
            }
        }

        public  void SplitExpressionStartWithOperator(List<string> expressions)
        {
            Regex regex = new Regex(@"^(\s*)[\+|\-|/|\*](\s+)");
            bool endOfList = false;
            while (!endOfList)
            {
                endOfList = true;
                for (int i = 0; i < expressions.Count; i++)
                {
                    Console.WriteLine("indice:" + i);
                    Console.WriteLine("expresion:" + expressions[i]);
                    string exp = expressions[i];
                    exp = exp.Trim();
                    string[] nexExps = exp.Split(new char[] { ' ', '\t' }, 
                        2, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine("nexExps:" + nexExps[0]);
                    expressions[i] = nexExps[0];
                    expressions.Insert(i + 1, nexExps[1]);
                    endOfList = false;
                }
            }

        }
        
    }
}
