using System.Collections.Generic;
using System.IO;

namespace WindowsSystemDiffToolsCore
{
    public class CompareFilesLoader
    {

        private CompareFilesLoader() { }

        //ToDo : Allow to load from another directory, maybe a config file ??
        public static List<CompareFile> GetFiles()
        {
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Compare");

            List<CompareFile> files = new List<CompareFile>();
            
            foreach (string filePath in Directory.GetFiles(@"C:\Temp\WindowsDiffTool\Compare"))
            {
                FileInfo file = new FileInfo(filePath);

                if(file.Extension == ".xml")
                    files.Add(new CompareFile(filePath));
            }

            return files;
        }



    }
}
