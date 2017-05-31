using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace InstalledPrograms32bitsScanner
{
    class InstalledProgram32bitsScanner : ComponentScanner
    {
        public InstalledProgram32bitsScanner(){ }

        protected override string Name { get { return "Programs and features (32 bits)"; } }

        public override string ComponentName { get { return "InstalledProgram32bits"; } }
        public override string ComponentNamespace { get { return "InstalledPrograms32bitsScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> installedPrograms = new List<Component>();

            //32 bits
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] subKeyNames = key.GetSubKeyNames();

            sendMessageToUI("Scanning 32 bits programs and features from the registry");
            foreach (string subKeyName in subKeyNames)
            {
                RegistryKey installedProgramKey = key.OpenSubKey(subKeyName);

                string[] keyValueNames = installedProgramKey.GetValueNames();

                if (keyValueNames.Contains("DisplayName"))
                    installedPrograms.Add(new InstalledProgram32bits(installedProgramKey, 32));
            }
            sendMessageToUI($"Scan completed, {key.SubKeyCount} keys scanned.");

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
