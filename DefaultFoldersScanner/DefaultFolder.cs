using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace DefaultFolder
{
    public class DefaultFolder : Component
    {
        public string Name { get; set; }
        public string Path { get; set; }



        public DefaultFolder(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }

        public DefaultFolder()
        {

        }


        public override string getDisplayName()
        {
            return this.Name;
        }

        public override Dictionary<string, string> getItems()
        {
            return new Dictionary<string, string>()
            {
                { "Path", this.Path }
            };
        }
    }
}
