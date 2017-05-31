using System.Collections.Generic;

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
