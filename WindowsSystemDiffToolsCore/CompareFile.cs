using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
