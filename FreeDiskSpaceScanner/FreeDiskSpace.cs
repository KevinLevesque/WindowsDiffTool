using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsSystemDiffToolsCore;

namespace FreeDiskSpaceScanner
{

    public class FreeDiskSpace : Component
    {

        public FreeDiskSpace() { }

        public string Name { get; set; }
        public long AvailaibleSpace { get; set; }

        public FreeDiskSpace(DriveInfo drive)
        {
            this.Name = drive.Name;
            this.AvailaibleSpace = (long)(drive.AvailableFreeSpace / 1024f);
        }




        public override string getDisplayName()
        {
            return this.Name;
        }

        public override Dictionary<string, string> getItems()
        {
            return new Dictionary<string, string>()
            {
                { "AvailaibleSpace", $"{AvailaibleSpace.ToString()} kB" }
            };
        }


    }
}
