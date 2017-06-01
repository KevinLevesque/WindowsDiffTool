using System;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;
using System.IO;

namespace StartMenuScanner
{
    public class StartMenuItemScanner : ComponentScanner
    {
        protected override string Name { get { return "Start Menu"; } }

        public override string ComponentName { get { return "StartMenuItem"; } }
        public override string ComponentNamespace { get { return "StartMenuScanner"; } }

        List<Component> items;

        public override List<Component> Scan()
        {
            items = new List<Component>();

            GetItems(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            GetItems(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu));



            Listener.sendStringToUI($"Scanned {items.Count} items in the Start Menu");

            return items;
        }

        private void GetItems(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Attributes.HasFlag(FileAttributes.ReparsePoint))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    GetItems(d.FullName);

                foreach (FileSystemInfo file in dir.GetFileSystemInfos())
                {
                    items.Add(new StartMenuItem(file.FullName, file.Name, file.LastWriteTime));
                }
            }
        }


        public override Type TypeOfComponent()
        {
            return typeof(StartMenuItem);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(StartMenuItemDiff);
        }
    }
}
