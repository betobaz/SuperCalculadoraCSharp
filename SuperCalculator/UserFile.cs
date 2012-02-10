using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SuperCalculator
{
    public class UserFile: DataFile
    {
        FileStream _stream = null;

        public FileStream Stream
        {
            get { return _stream; }
            set { _stream = value; } 
        }
    }
}
