using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public class DiffResultTextWriter
    {

        DiffResultsGroup Group;

        /// if results is null, differential was not made. Most likely component was only scanned in one of both files.
        public DiffResultTextWriter(DiffResultsGroup group)
        {
            Group = group;
        }



        public string GetText()
        {
            string text = $"[{Group.Name}]" + Environment.NewLine;

            if(Group.DiffResults == null)
            {
                text += "-- Component not scanned in one of both scans --" + Environment.NewLine;
            }
            else if (Group.DiffResults.Count == 0)
            {
                text += "-- No change --" + Environment.NewLine;
            }
            else
            {
                foreach (DiffResult result in Group.DiffResults)
                {
                    if (result.Type == DiffResultType.Added)
                    {
                        text += $"{result.AfterComponent} ---- Added" + Environment.NewLine;
                    }
                    else if (result.Type == DiffResultType.Modified)
                    {
                        text += $"{result.BeforeComponent} ---> {changedItemString(result)} ---- Modified" + Environment.NewLine;
                    }
                    else if (result.Type == DiffResultType.Removed)
                    {
                        text += $"{result.BeforeComponent} ---- Deleted" + Environment.NewLine;
                    }
                }
            }
            

            text += Environment.NewLine + Environment.NewLine;
            return text;
        }

        private string changedItemString(DiffResult res)
        {
            string value = "";

            foreach(KeyValuePair<string, string> item in res.getChangedItems())
            {
                if (value.Length > 0) value += " ";

                value += $"[{item.Key} '{item.Value}']";
            }

            return value;
        }
    }
}
