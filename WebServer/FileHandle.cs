using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer
{
    public class FileHandle
    {
        public static string ReadFile(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }
    }
}
