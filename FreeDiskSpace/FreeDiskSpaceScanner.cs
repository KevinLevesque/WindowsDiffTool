using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;
using WindoesSystemDiffToolsCore;
using System.IO;

namespace FreeDiskSpace
{
    class FreeDiskSpaceScanner : ComponentScanner
    {
        public FreeDiskSpaceScanner(){ }

        protected override string Name { get { return "Free disk space"; } }

        public override string ComponentName { get { return "FreeDiskSpace"; } }
        public override string ComponentNamespace { get { return "FreeDiskSpace"; } }


        public override List<Component> Scan()
        {
            List<Component> drives = new List<Component>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
                drives.Add(new FreeDiskSpace(drive));

            Listener.sendStringToUI($"Scanned {drives.Count} drives availaible space");

            return drives;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(FreeDiskSpace);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(FreeDiskSpaceDiff);
        }

    }
}
