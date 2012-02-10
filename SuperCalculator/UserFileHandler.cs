using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SuperCalculator
{
    public class UserFileHandler: FileHandler<UserFile>
    {
        public UserFile CreateFile(string path)
        {
            FileStream stream = File.Create(path);
            UserFile userFile = new UserFile();
            userFile.Stream = stream;
            return userFile;
        }        
    }
}
