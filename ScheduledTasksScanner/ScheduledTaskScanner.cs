﻿using System;
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

            try
            {
                if (Directory.Exists(path + @"\Sysnative"))
                {
                    GetItems(path + @"\Sysnative\Tasks");
                    GetItems(path + @"\System32\Tasks");
                }
                else
                {
                    GetItems(path + @"\System32\Tasks");
                    GetItems(path + @"\SysWow64\Tasks");
                }
            }
            catch(Exception ex)
            {
                Listener.sendStringToUI($@"You do not have the rights to access the {path}\System32\Tasks and {path}\SysWoW64\Tasks folders");
                return new List<Component>();
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
