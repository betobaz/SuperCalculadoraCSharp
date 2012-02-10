using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTests
{
    public class EasyPath: MultiPlatform
    {
        public override string GetPOSIXpath()
        {
            return "/tmp/data.txt";
        }

        public override string GetWindowsPath()
        {
            return @"C:\data.txt";
        }
    }
}
