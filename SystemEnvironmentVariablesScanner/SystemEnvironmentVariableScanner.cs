using System;
using System.Collections;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;

namespace SystemEnvironmentVariablesScanner
{
    class SystemEnvironmentVariableScanner : ComponentScanner
    {
        public SystemEnvironmentVariableScanner(){ }

        protected override string Name { get { return "System environment variables"; } }

        public override string ComponentName { get { return "SystemEnvironmentVariable"; } }
        public override string ComponentNamespace { get { return "SystemEnvironmentVariablesScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> variables = new List<Component>();

            foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine))
                variables.Add(new SystemEnvironmentVariable(entry));

            Listener.sendStringToUI($"Scanned {variables.Count} system environment variables");


            return variables;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(SystemEnvironmentVariable);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(SystemEnvironmentVariableDiff);
        }

    }
}
