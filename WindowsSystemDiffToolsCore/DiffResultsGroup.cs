using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsSystemDiffToolsCore
{
    public class DiffResultsGroup
    {
        public List<DiffResult> DiffResults { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        public DiffResultsGroup() { }

        public DiffResultsGroup(List<DiffResult> results, string name)
        {
            DiffResults = results;
            Name = name;
        }
    }
}
