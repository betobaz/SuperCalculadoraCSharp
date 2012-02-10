using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTests
{
    public class NotFoundPath: MultiPlatform
    {
        public override string GetPOSIXpath()
        {
            return "/asdflwiejawseras/data.txt";
        }

        public override string GetWindowsPath()
        {
            return @"C:\asdfalsdfkwjerasdfas\data.txt";
        }
    }
}
