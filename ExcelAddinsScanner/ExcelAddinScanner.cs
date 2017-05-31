using Microsoft.Win32;
using System;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;

namespace ExcelAddinsScanner
{
    class ExcelAddinScanner : ComponentScanner
    {
        public ExcelAddinScanner(){ }

        protected override string Name { get { return "Excel Addins"; } }

        public override string ComponentName { get { return "ExcelAddin"; } }
        public override string ComponentNamespace { get { return "ExcelAddinsScanner"; } }


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
                RegistryKey addins = baseKey.OpenSubKey(@"Software\Microsoft\Office\Excel\Addins");

                if (addins == null)
                    continue;

                foreach(string subKey in addins.GetSubKeyNames())
                {
                    RegistryKey addin = addins.OpenSubKey(subKey);

                    officeAddins.Add(new ExcelAddin(addin, subKey, (addin.Name.StartsWith("HKEY_LOCAL_MACHINE")) ? "Machine" : "User", (addin.View == RegistryView.Registry64) ? 64 : 32));
                }
            }

            Listener.sendStringToUI($"Scanned {officeAddins.Count} Excel addins");

            return officeAddins;    
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(ExcelAddin);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(ExcelAddinDiff);
        }

    }
}
