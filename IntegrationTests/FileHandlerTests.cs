using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using SuperCalculator;
using System.IO;

namespace IntegrationTests
{
    [TestFixture]
    public class FileHandlerTests
    {             
        [Test]
        public void CreateFileMultiPlatform()
        {
            string path = new EasyPath().GetPlatformPath();
            UserFileHandler handler = new UserFileHandler();

            DataFile dataFile = handler.CreateFile(path);            
            if (!File.Exists(path))
            {
                Assert.Fail("File was not created");
            }
            Console.Out.WriteLine(dataFile.Stream);
            Assert.IsNotNull(dataFile.Stream);
        }

        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void CreateFileDirectoryNotFound()
        {
            string path = new NotFoundPath().GetPlatformPath();
            Console.Out.WriteLine(path);
            UserFileHandler handler = new UserFileHandler();

            DataFile dataFile = handler.CreateFile(path);
        }
    }
}
