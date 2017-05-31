using System.Collections.Generic;

namespace WindowsSystemDiffToolsCore
{
    public abstract class Component
    {
        public abstract string getDisplayName();
        public abstract Dictionary<string, string> getItems();
        
        
        public override string ToString()
        {
            string value = $"{getDisplayName()}";

            foreach(KeyValuePair<string, string> item in getItems())
            {
                value += $" [{item.Key} '{item.Value}']";
            }

            return value;
        } 

    }
}
