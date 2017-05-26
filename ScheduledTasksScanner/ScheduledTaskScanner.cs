using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ScheduledTasksScanner
{
    public class ScheduledTaskScanner : ComponentScanner
    {
        protected override string Name { get { return "Task Scheduler"; } }

        public override string ComponentName { get { return "ScheduledTask"; } }
        public override string ComponentNamespace { get { return "ScheduledTasksScanner"; } }

        List<Component> items = new List<Component>();

        public override List<Component> Scan()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            Process process = new Process();

                            process.StartInfo = new ProcessStartInfo("takeown", $@"{path + @"\System32\Tasks"} /A /R");
                process.Start();

                process.StartInfo = new ProcessStartInfo("takeown", $@"{path + @"\SysWow64\Tasks"} /A /R");
                process.Start();

                process.StartInfo = new ProcessStartInfo("icacls", $@"{path + @"\System32\Tasks"} /T /grant {System.Security.Principal.WindowsIdentity.GetCurrent().Name}:F");
                process.Start();

                process.StartInfo = new ProcessStartInfo("icacls", $@"{path + @"\SysWow64\Tasks"} /T /grant {System.Security.Principal.WindowsIdentity.GetCurrent().Name}:F");
                process.Start();


            if (Directory.Exists(path + @"\Sysnative"))
            {
                process.StartInfo = new ProcessStartInfo("takeown", $@"{path + @"\Sysnative\Tasks"} /A /R");
                process.Start();

                process.StartInfo = new ProcessStartInfo("takeown", $@"{path + @"\System32\Tasks"} /A /R");
                process.Start();

                process.StartInfo = new ProcessStartInfo("icacls", $@"{path + @"\Sysnative\Tasks"} /T /grant {System.Security.Principal.WindowsIdentity.GetCurrent().Name}:F");
                process.Start();

                process.StartInfo = new ProcessStartInfo("icacls", $@"{path + @"\System32\Tasks"} /T /grant {System.Security.Principal.WindowsIdentity.GetCurrent().Name}:F");
                process.Start();

                GetItems(path + @"\Sysnative\Tasks");
                GetItems(path + @"\System32\Tasks");
            }
            else
            {



                

                GetItems(path + @"\System32\Tasks");
                GetItems(path + @"\SysWow64\Tasks");
            }
            

            Listener.sendStringToUI($"Scanned {items.Count} items in the Task Scheduler");

            return items;
        }

        private void GetItems(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Attributes.HasFlag(FileAttributes.ReparsePoint))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    GetItems(d.FullName);

                foreach (FileInfo file in dir.GetFiles())
                {
                    items.Add(new ScheduledTask(file.FullName, file.Name, file.LastWriteTime));
                }
            }
        }


        public override Type TypeOfComponent()
        {
            return typeof(ScheduledTask);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(ScheduledTaskDiff);
        }
    }
}
