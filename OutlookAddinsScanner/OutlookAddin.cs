using Microsoft.Win32;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;

namespace OutlookAddinsScanner
{

    public class OutlookAddin : Component
    {
        public OutlookAddin() { }

        public OutlookAddin(RegistryKey key, string name, string type, int bitness)
        {
            this.Id = $"{name} [Type:{type} | Bitness:{bitness.ToString()}]";
            this.Name = key.GetValue("FriendlyName") != null ? key.GetValue("FriendlyName").ToString() : "N/A";
            this.Type = type;
            this.Bitness = bitness;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Bitness { get; set; }

        public override string getDisplayName()
        {
            return this.Name;
        }

        public override Dictionary<string, string> getItems()
        {
            return new Dictionary<string, string>()
            {
                { "Name", this.Name },
                { "Type", this.Type },
                { "Bitness", this.Bitness.ToString() }
            };
        }

    }
    
}
