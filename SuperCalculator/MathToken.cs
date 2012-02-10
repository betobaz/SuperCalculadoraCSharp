using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperCalculator
{
    public abstract class MathToken
    {
        protected int _precedence = 0;
        protected string _token = String.Empty;
        protected int _index = -1;
        protected MathToken _previousToken, _nextToken;
        

        public MathToken(string token)
        {            
            _token = token;
        }

        public MathToken(int precedence)
        {
            _precedence = precedence;
        }

        public MathToken PreviousToken
        {
            get { return _previousToken; }
            set { _previousToken = value; }
        }

        public MathToken NextToken
        {
            get { return _nextToken; }
            set { _nextToken = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public string Token {
            get { return _token; }
        }

        public int Precedence
        {
            get { return _precedence; } 
        }
        
        public abstract int Resolve();
    }
}
