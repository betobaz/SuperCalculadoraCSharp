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
    public class UnitTests
    {
        [Test]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TryCreateFileWhenDirectoryNotFound()
        {
            FileHandler<UserFile> handlerMock = MockRepository.GenerateStub<FileHandler<UserFile>>();
            handlerMock.Expect(x => x.CreateFile("")).Throw(new DirectoryNotFoundException());
            UserStorageManager manager = new UserStorageManager(handlerMock);
            manager.SetUserFile("");
        }
    }
}
