using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTests
{
    public abstract class MultiPlatform
    {
        public abstract string GetPOSIXpath();

        public abstract string GetWindowsPath();

        public string GetPlatformPath()
        {
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            string path = String.Empty;
            switch (osInfo.Platform)
            {
                case System.PlatformID.Unix:
                    {
                        path = "/tmp/data.txt";
                        break;
                    }
                case System.PlatformID.MacOSX:
                    {
                        path = "/tmp/data.txt";
                        break;
                    }
                default:
                    {
                        path = @"C:\data.txt";
                        break;
                    }
            }
            return path;
        }
    }
}
