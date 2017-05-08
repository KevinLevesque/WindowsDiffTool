using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsSystemDiffToolsCore;
using WindoesSystemDiffToolsCore;

namespace WindowsSystemDiffToolsScanner
{
    class Scanner : ScannerCore, IComponentScanner
    {
    
        public Scanner(){ }

        public Scanner(UIListener listener) : base(listener)
        {
            this.addUIListener(listener);
        }

        public void addUIListener(UIListener listener)
        {
            base.Listener = listener;
        }

        public List<ComponentCore> Scan()
        {
            List<ComponentCore> installedPrograms = new List<ComponentCore>();

            //64 bits
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            string[] subKeyNames = key.GetSubKeyNames();

            sendMessageToUI("Début du scan des clés de registre 64 bits...");
            foreach (string subKeyName in subKeyNames)
            {
                RegistryKey installedProgramKey = key.OpenSubKey(subKeyName);

                string[] keyValueNames = installedProgramKey.GetValueNames();

                if (keyValueNames.Contains("DisplayName"))
                    installedPrograms.Add(new Component(installedProgramKey, 64));
            }
            sendMessageToUI($"Fin du scan des clés 64 bits, {key.SubKeyCount} clés scannées.");

            //32 bits
            key = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            subKeyNames = key.GetSubKeyNames();

            sendMessageToUI("Début du scan des clés de registre 32 bits...");
            foreach (string subKeyName in subKeyNames)
            {
                RegistryKey installedProgramKey = key.OpenSubKey(subKeyName);

                string[] keyValueNames = installedProgramKey.GetValueNames();

                if (keyValueNames.Contains("DisplayName"))
                    installedPrograms.Add(new Component(installedProgramKey, 32));
            }
            sendMessageToUI($"Fin du scan des clés 32 bits, {key.SubKeyCount} clés scannées.");

            return installedPrograms;
        }

        public void sendMessageToUI(string message)
        {
            Listener.sendStringToUI(message);
        }

        public override string ToString()
        {
            return "Programmes et fonctionnalités";
        }

        public Type typeOfComponent()
        {
            return typeof(Component);
        }

        public string XmlAttributeComponentName()
        {
            return "InstalledPrograms";
        }
    }
}
