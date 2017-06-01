using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsSystemDiffToolsCore
{
    public class SnapshotTextWriter
    {

        ComponentGroup Group;

        /// if results is null, differential was not made. Most likely component was only scanned in one of both files.
        public SnapshotTextWriter(ComponentGroup group)
        {
            Group = group;
        }



        public string GetText()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"[{Group.ComponentName}]" + Environment.NewLine);


            foreach (Component component in Group.Components)
            {
                sb.Append($"{component.getDisplayName()}{ComponentItems(component)}" + Environment.NewLine);
           
            }



            sb.Append(Environment.NewLine + Environment.NewLine);
            return sb.ToString();
        }

        private string ComponentItems(Component component)
        {
            string value = "";

            foreach (KeyValuePair<string, string> item in component.getItems())
            {
                if (value.Length > 0) value += " ";

                value += $"[{item.Key} '{item.Value}']";
            }

            return value;
        }
    }
}
