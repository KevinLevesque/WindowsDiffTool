using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace DiskRootScanner
{
    public class DiskRootItemScanner : ComponentScanner
    {



        protected override string Name { get { return "Root directory of drive"; } }

        public override string ComponentName { get { return "DiskRootItem"; } }
        public override string ComponentNamespace { get { return "DiskRootScanner"; } }

        

        public override List<Component> Scan()
        {
            List<Component> items = new List<Component>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed && drive.IsReady)
                {
                    foreach(FileSystemInfo fsi in drive.RootDirectory.GetFileSystemInfos())
                    {
                        items.Add(new DiskRootItem(fsi));
                    }
                    Listener.sendStringToUI($"Scanned drive '{drive.VolumeLabel} ({drive.Name})' root directory");
                }                
            }

            Listener.sendStringToUI($"Scanned {items.Count} files and folders");

            return items;
        }

 
        public override Type TypeOfComponent()
        {
            return typeof(DiskRootItem);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(DiskRootItemDiff);
        }
    }
}
