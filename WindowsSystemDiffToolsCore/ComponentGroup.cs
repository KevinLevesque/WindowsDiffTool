using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsSystemDiffToolsCore
{
    public class ComponentGroup
    {
        [XmlAttribute]
        public string ComponentName { get; set; }
        [XmlAttribute]
        public string ComponentNameSpace { get; set; }

        public List<Component> Components { get; set; }

        public ComponentGroup()
        {
            Components = new List<Component>();
        }
    }
}
