using System.Collections.Generic;
using System.IO;

namespace WindowsSystemDiffToolsCore
{
    public class SnapshotFilesLoader
    {

        private SnapshotFilesLoader() { }

        //ToDo : Allow to load from another directory, maybe a config file ??
        public static List<SnapshotFile> GetFiles()
        {
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Snapshots");

            List<SnapshotFile> files = new List<SnapshotFile>();
            
            foreach (string filePath in Directory.GetFiles(@"C:\Temp\WindowsDiffTool\Snapshots"))
            {
                FileInfo file = new FileInfo(filePath);

                if(file.Extension == ".xml")
                    files.Add(new SnapshotFile(filePath));
            }

            return files;
        }

    }
}
