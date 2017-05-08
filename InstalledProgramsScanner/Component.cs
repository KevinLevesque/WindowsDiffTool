using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsSystemDiffToolsCore;

namespace WindowsSystemDiffToolsScanner
{
 
    public class Component : ComponentCore
    {
        
        string ComponentType = "InstalledProgram";


        public string DisplayName { get; set; }
        public string DisplayVersion { get; set; }
        public int Bitness { get; set; }
        public string UninstallKey { get; set; }




        public Component(RegistryKey key, int bitness)
        {
            this.DisplayName = key.GetValue("DisplayName").ToString();
            this.UninstallKey = key.Name;
            this.Bitness = bitness;

            if(key.GetValue("DisplayVersion") != null)
                this.DisplayVersion = key.GetValue("DisplayVersion").ToString();
        }

        public Component()
        {

        }

    }
}
