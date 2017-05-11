using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsSystemDiffToolsCore
{
    public enum DiffResultType
    {
        Added,
        Modified,
        Removed
    }

    public class DiffResult
    {

        public Component BeforeComponent { get; set; }
        public Component AfterComponent { get; set; }

        [XmlAttribute]
        public DiffResultType Type { get; set;}



        private DiffResult(){ }


        public static DiffResult Added(Component component)
        {
            DiffResult result = new DiffResult();
            result.BeforeComponent = null;
            result.AfterComponent = component;
            result.Type = DiffResultType.Added;

            return result;
        }

        public static DiffResult Modified(Component beforeComponent, Component afterComponent)
        {
            DiffResult result = new DiffResult();
            result.BeforeComponent = beforeComponent;
            result.AfterComponent = afterComponent;
            result.Type = DiffResultType.Modified;

            return result;
        }

        public static DiffResult Removed(Component oldValue)
        {
            DiffResult result = new DiffResult();
            result.BeforeComponent = oldValue;
            result.AfterComponent = null;
            result.Type = DiffResultType.Removed;

            return result;
        }


        public Dictionary<string, string> getChangedItems()
        {
            if (Type != DiffResultType.Modified)
                return null;

            Dictionary<string, string> items = new Dictionary<string, string>();

            Dictionary<string, string> beforeComponentItems = BeforeComponent.getItems();
            Dictionary<string, string> afterComponentItems = AfterComponent.getItems();


            return afterComponentItems.Where(entry => beforeComponentItems[entry.Key] != entry.Value).ToDictionary(entry => entry.Key, entry => entry.Value);
        }

    }
}
