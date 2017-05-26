using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsSystemDiffToolsCore;
using System.Collections;

namespace UserEnvironmentVariablesScanner
{

    public class UserVariable : Component
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public UserVariable() { }

        public UserVariable(DictionaryEntry entry)
        {
            this.Name = entry.Key.ToString();
            this.Value = entry.Value.ToString();
        }

 

        public override string getDisplayName()
        {
            return this.Name;
        }

        public override Dictionary<string, string> getItems()
        {
            return new Dictionary<string, string>()
            {
                { "Value", Value }
            };
        }



    }
}
