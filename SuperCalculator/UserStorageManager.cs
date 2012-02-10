using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCalculator
{
    public class UserStorageManager
    {
        FileHandler<UserFile> _handler;
        private FileHandler<UserFile> handlerMock;

        public UserStorageManager(FileHandler<UserFile> handler)
        {
            _handler = handler;
        }

        public void SetUserFile(string path)
        {
            _handler.CreateFile(path);
        }
    }
}
