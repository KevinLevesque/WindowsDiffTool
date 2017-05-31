using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace InstalledPrograms64bitsScanner
{
    class InstalledProgram64bitsScanner : ComponentScanner
    {
        public InstalledProgram64bitsScanner(){ }

        protected override string Name { get { return "Programs and features (64 bits)"; } }

        public override string ComponentName { get { return "InstalledProgram64bits"; } }
        public override string ComponentNamespace { get { return "InstalledPrograms64bitsScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> installedPrograms = new List<Component>();

            //64 bits
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] subKeyNames = key.GetSubKeyNames();

            sendMessageToUI("Scanning 64 bits programs and features from the registry");
            foreach (string subKeyName in subKeyNames)
            {
                RegistryKey installedProgramKey = key.OpenSubKey(subKeyName);

                string[] keyValueNames = installedProgramKey.GetValueNames();

                if (keyValueNames.Contains("DisplayName"))
                    installedPrograms.Add(new InstalledProgram64bits(installedProgramKey, 64));
            }
            sendMessageToUI($"Scan completed, {key.SubKeyCount} keys scanned.");


            return installedPrograms;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(InstalledProgram64bits);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(InstalledProgram64bitsDiff);
        }

    }
}
