using System.IO;

namespace WindowsSystemDiffToolsCore
{
    public class CompareFile
    {

        public FileInfo Info { get; set; }

        public CompareFile(string path)
        {
            Info = new FileInfo(path);
        }

        public override string ToString()
        {
            return this.Info.Name;
        }

    }
}
