using System;
using System.Collections;
using System.Collections.Generic;
using WindowsSystemDiffToolsCore;

namespace UserEnvironmentVariablesScanner
{
    class UserVariableScanner : ComponentScanner
    {
        public UserVariableScanner(){ }

        protected override string Name { get { return "User environment variables"; } }

        public override string ComponentName { get { return "UserVariable"; } }
        public override string ComponentNamespace { get { return "UserEnvironmentVariablesScanner"; } }


        public override List<Component> Scan()
        {
            List<Component> variables = new List<Component>();

            foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User))
                variables.Add(new UserVariable(entry));

            Listener.sendStringToUI($"Scanned {variables.Count} user environment variables");


            return variables;
        }
        
        public override Type TypeOfComponent()
        {
            return typeof(UserVariable);
        }

        public override Type TypeOfComponentDiff()
        {
            return typeof(UserVariableDiff);
        }

    }
}
