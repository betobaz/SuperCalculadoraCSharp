using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SuperCalculator
{
    public interface DataFile
    {
        FileStream Stream { get; set; }
    }
}
