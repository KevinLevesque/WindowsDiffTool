using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsSystemDiffToolsCore;

namespace InstalledPrograms32bitsScanner
{
    public class InstalledProgram32bits : Component
    {
        public string DisplayName { get; set; }
        public string DisplayVersion { get; set; }
        public int Bitness { get; set; }
        public string UninstallKey { get; set; }




        public InstalledProgram32bits(RegistryKey key, int bitness)
        {
            this.DisplayName = key.GetValue("DisplayName").ToString();
            this.UninstallKey = key.Name;
            this.Bitness = bitness;

            if(key.GetValue("DisplayVersion") != null)
                this.DisplayVersion = key.GetValue("DisplayVersion").ToString();
        }

        public InstalledProgram32bits()
        {

        }

        public override string ToString()
        {
            return $"{this.DisplayName} [Version {this.DisplayVersion}]";
        }

    }
}
