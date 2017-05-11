using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public static class DiffResultGroupsTextWriter
    {

        public static string GetText(List<DiffResultsGroup> groups)
        {
            string value = "";

            foreach(DiffResultsGroup group in groups)
            {
                value += (new DiffResultTextWriter(group)).GetText();
            }

            return value;
        }


    }
}
