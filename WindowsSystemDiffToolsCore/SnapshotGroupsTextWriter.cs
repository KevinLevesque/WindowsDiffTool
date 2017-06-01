using System.Collections.Generic;
using System.Text;

namespace WindowsSystemDiffToolsCore
{
    public static class SnapshotGroupsTextWriter
    {

        public static string GetText(List<ComponentGroup> groups)
        {
            StringBuilder sb = new StringBuilder();

            foreach(ComponentGroup group in groups)
            {
                sb.Append((new SnapshotTextWriter(group)).GetText());
            }

            return sb.ToString();
        }


    }
}
