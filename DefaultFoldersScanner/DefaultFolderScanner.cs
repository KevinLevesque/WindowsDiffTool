using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowsSystemDiffToolsCore;

namespace DefaultFolder
{
    class DefaultFolderDiffScanner : ComponentScanner
    {
        public DefaultFolderDiffScanner(){ }

        protected override string Name { get { return "Default folders"; } }

        public override string ComponentName { get { return "DefaultFolder"; } }
        public override string ComponentNamespace { get { return "DefaultFolderDiffScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> defaultFolders = new List<Component>();

            //32 bits
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);


            sendMessageToUI("Scanning for default folders from the registry...");

            RegistryKey key = hklm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders");
            
            foreach (string subKeyName in key.GetValueNames())
            {
                defaultFolders.Add(new DefaultFolder(subKeyName, key.GetValue(subKeyName).ToString()));
            }

            key = hkcu.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders");

            foreach (string subKeyName in key.GetValueNames())
            {
                defaultFolders.Add(new DefaultFolder(subKeyName, key.GetValue(subKeyName).ToString()));
            }
            sendMessageToUI($"Scan completed, {defaultFolders.Count} default folders scanned.");

            return defaultFolders;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(DefaultFolder);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(DefaultFolderDiff);
        }

    }
}
