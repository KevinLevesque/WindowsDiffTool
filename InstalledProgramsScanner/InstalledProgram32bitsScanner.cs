using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;
using WindoesSystemDiffToolsCore;

namespace InstalledPrograms32bitsScanner
{
    class InstalledProgram32bitsScanner : ComponentScanner
    {
        public InstalledProgram32bitsScanner(){ }

        protected override string Name { get { return "Programmes et fonctionnalités (32 bits)"; } }

        public override string ComponentName { get { return "InstalledProgram32bits"; } }
        public override string ComponentNamespace { get { return "InstalledPrograms32bitsScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> installedPrograms = new List<Component>();

            //32 bits
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] subKeyNames = key.GetSubKeyNames();

            sendMessageToUI("Scan des clés de registre 32 bits...");
            foreach (string subKeyName in subKeyNames)
            {
                RegistryKey installedProgramKey = key.OpenSubKey(subKeyName);

                string[] keyValueNames = installedProgramKey.GetValueNames();

                if (keyValueNames.Contains("DisplayName"))
                    installedPrograms.Add(new InstalledProgram32bits(installedProgramKey, 32));
            }
            sendMessageToUI($"Scan des clés 32 bits terminé, {key.SubKeyCount} clés scannées.");

            return installedPrograms;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(InstalledProgram32bits);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(InstalledProgram32bitsDiff);
        }

    }
}
