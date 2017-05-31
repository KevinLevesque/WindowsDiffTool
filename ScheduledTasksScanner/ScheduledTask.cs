using System;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;

namespace ScheduledTasksScanner
{
    public class ScheduledTask : Component
    {

        public ScheduledTask() { }

        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public ScheduledTask(string path, string name, DateTime lastModifiedDate)
        {
            this.Path = path;
            this.Name = name;
            this.LastModifiedDate = lastModifiedDate;
        }

        public override string getDisplayName()
        {
            return this.Name;
        }

        public override Dictionary<string, string> getItems()
        {
            return new Dictionary<string, string>()
            {
                { "Last modified date", this.LastModifiedDate.ToString("yyyy-MM-dd HH:mm:ss") }
            };
        }
    }
}
