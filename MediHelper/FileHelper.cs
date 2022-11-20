using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediHelper
{
    public class FileHelper
    {
        public static string ReadFileData(string fileName)
        {
            string filetext = "";
            if (File.Exists(fileName))
            {
                filetext = File.ReadAllText(fileName);
            }
            else
            {
                using (var stream = File.Create(fileName)) { }
            }
            return filetext;

        }

        public static void FlushFile(string filename)
        {
            File.WriteAllText(filename, string.Empty);
        }

        public static void WriteFileData(string fileName, string fileData)
        {
            using (FileStream aFile = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(aFile))
                {
                    sw.WriteLine(fileData);
                }
            }
        }
    }
}
