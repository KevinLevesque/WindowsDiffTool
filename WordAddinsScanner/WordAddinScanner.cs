using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace WordAddinsScanner
{
    class WordAddinScanner : ComponentScanner
    {
        public WordAddinScanner(){ }

        protected override string Name { get { return "Word Addins"; } }

        public override string ComponentName { get { return "WordAddin"; } }
        public override string ComponentNamespace { get { return "WordAddinsScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> officeAddins = new List<Component>();

            List<RegistryKey> baseKeys = new List<RegistryKey>()
            {
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64),
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32),
                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64),
                RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32)
            };

            

            foreach (RegistryKey baseKey in baseKeys)
            {
                RegistryKey addins = baseKey.OpenSubKey(@"Software\Microsoft\Office\Word\Addins");

                if (addins == null)
                    continue;

                foreach(string subKey in addins.GetSubKeyNames())
                {
                    RegistryKey addin = addins.OpenSubKey(subKey);

                    officeAddins.Add(new WordAddin(addin, subKey, (addin.Name.StartsWith("HKEY_LOCAL_MACHINE")) ? "Machine" : "User", (addin.View == RegistryView.Registry64) ? 64 : 32));
                }
            }

            Listener.sendStringToUI($"Scanned {officeAddins.Count} outlook addins");

            return officeAddins;    
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(WordAddin);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(WordAddinDiff);
        }

    }
}
