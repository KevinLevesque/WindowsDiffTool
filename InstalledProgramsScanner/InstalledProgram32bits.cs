using Microsoft.Win32;
using System.Collections.Generic;
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


        public override string getDisplayName()
        {
            return this.DisplayName;
        }

        public override Dictionary<string, string> getItems()
        {
            return new Dictionary<string, string>()
            {
                { "Name", DisplayName },
                { "Version", DisplayVersion }
            };
        }
    }
}
