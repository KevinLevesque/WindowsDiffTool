using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;

namespace InstalledPrograms64bitsScanner
{
    class InstalledProgram64bitsScanner : ComponentScanner
    {
        public InstalledProgram64bitsScanner(){ }

        protected override string Name { get { return "Programmes et fonctionnalités (64 bits)"; } }

        public override string ComponentName { get { return "InstalledProgram64bits"; } }
        public override string ComponentNamespace { get { return "InstalledPrograms64bitsScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> installedPrograms = new List<Component>();

            //64 bits
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] subKeyNames = key.GetSubKeyNames();

            sendMessageToUI("Scan des clés de registre 64 bits...");
            foreach (string subKeyName in subKeyNames)
            {
                RegistryKey installedProgramKey = key.OpenSubKey(subKeyName);

                string[] keyValueNames = installedProgramKey.GetValueNames();

                if (keyValueNames.Contains("DisplayName"))
                    installedPrograms.Add(new InstalledProgram64bits(installedProgramKey, 64));
            }
            sendMessageToUI($"Scan des clés 64 bits terminé, {key.SubKeyCount} clés scannées.");


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
