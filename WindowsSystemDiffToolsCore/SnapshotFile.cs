using System.IO;

namespace WindowsSystemDiffToolsCore
{
    public class SnapshotFile
    {

        public FileInfo Info { get; set; }

        public SnapshotFile(string path)
        {
            Info = new FileInfo(path);
        }

        public override string ToString()
        {
            return this.Info.Name;
        }

    }
}
