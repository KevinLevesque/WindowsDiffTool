using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsSystemDiffToolsCore;
using System.Collections;

namespace SystemEnvironmentVariable
{

    public class SystemEnvironmentVariable : Component
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SystemEnvironmentVariable() { }

        public SystemEnvironmentVariable(DictionaryEntry entry)
        {
            this.Name = entry.Key.ToString();
            this.Value = entry.Value.ToString();
        }

 
        public override string ToString()
        {
            return $"{this.Name} [Value '{this.Value}']";
        }



    }
}
