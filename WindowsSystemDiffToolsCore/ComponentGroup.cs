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
        public string Name { get; set; }
        public List<ComponentCore> Components { get; set; }


        public ComponentGroup()
        {
            Components = new List<ComponentCore>();
        }
    }
}
