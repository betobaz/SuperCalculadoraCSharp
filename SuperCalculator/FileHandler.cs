using System;
namespace SuperCalculator
{
    public interface FileHandler<T> where T:DataFile
    {        
        T CreateFile(string path);
    }
}
