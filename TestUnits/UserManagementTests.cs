using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using SuperCalculator;

namespace TestUnit
{
    [TestFixture]
    public class UserManagementTests
    {
        [Test]
        public void configUserFile()
        {
            string filePath = "C:\\Users\\pbazan\\data.txt";
            FileHandler<UserFile> handlerMock = MockRepository.GenerateMock<FileHandler<UserFile>>();
            handlerMock.Expect(x => x.CreateFile(filePath)).Return(new UserFile());

            UserStorageManager manager = new UserStorageManager(handlerMock);
            manager.SetUserFile(filePath);

            handlerMock.VerifyAllExpectations();
        }
    }
}
