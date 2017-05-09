using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public class CompareFilesLoader
    {

        private CompareFilesLoader() { }

        //ToDo : Allow to load from another directory, maybe a config file ??
        public static List<CompareFile> GetFiles()
        {
            List<CompareFile> files = new List<CompareFile>();
            
            foreach (string filePath in Directory.GetFiles(@"C:\Temp\WindowsDiffTool"))
            {
                FileInfo file = new FileInfo(filePath);

                if(file.Extension == ".compare")
                files.Add(new CompareFile(filePath));
            }

            return files;
        }

    }
}
