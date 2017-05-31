using System;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;
using System.IO;

namespace FreeDiskSpaceScanner
{
    class FreeDiskSpaceScanner : ComponentScanner
    {
        public FreeDiskSpaceScanner(){ }

        protected override string Name { get { return "Free disk space"; } }

        public override string ComponentName { get { return "FreeDiskSpace"; } }
        public override string ComponentNamespace { get { return "FreeDiskSpaceScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> drives = new List<Component>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if(drive.DriveType == DriveType.Fixed && drive.IsReady)
                    drives.Add(new FreeDiskSpace(drive));
            }
                
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
