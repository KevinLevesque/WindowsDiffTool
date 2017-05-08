using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsSystemDiffToolsCore
{
    public abstract class ComponentCore
    {

        [XmlAttribute]
        string ComponentType = "";

    }
}
