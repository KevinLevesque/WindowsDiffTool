using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DiffResultType Type { get; set;}



        private DiffResult(){ }


        public static DiffResult Added(string value)
        {
            DiffResult result = new DiffResult();
            result.OldValue = "N/A";
            result.NewValue = value;
            result.Type = DiffResultType.Added;

            return result;
        }

        public static DiffResult Modified(string oldValue, string newValue)
        {
            DiffResult result = new DiffResult();
            result.OldValue = oldValue;
            result.NewValue = newValue;
            result.Type = DiffResultType.Modified;

            return result;
        }

        public static DiffResult Removed(string oldValue)
        {
            DiffResult result = new DiffResult();
            result.OldValue = oldValue;
            result.NewValue = "N/A";
            result.Type = DiffResultType.Removed;

            return result;
        }

    }
}
