using System;
using System.Collections.Generic;
using System.Text;

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
            StringBuilder sb = new StringBuilder();

            sb.Append($"[{Group.Name}]" + Environment.NewLine);

            if(Group.DiffResults == null)
            {
                sb.Append("-- Component not scanned in one of both scans --" + Environment.NewLine);
            }
            else if (Group.DiffResults.Count == 0)
            {
                sb.Append("-- No change --" + Environment.NewLine);
            }
            else
            {
                foreach (DiffResult result in Group.DiffResults)
                {
                    if (result.Type == DiffResultType.Added)
                    {
                        sb.Append($"{result.AfterComponent} ---- Added" + Environment.NewLine);
                    }
                    else if (result.Type == DiffResultType.Modified)
                    {
                        sb.Append($"{result.BeforeComponent} ---> {changedItemString(result)} ---- Modified" + Environment.NewLine);
                    }
                    else if (result.Type == DiffResultType.Removed)
                    {
                        sb.Append($"{result.BeforeComponent} ---- Deleted" + Environment.NewLine);
                    }
                }
            }


            sb.Append(Environment.NewLine + Environment.NewLine);
            return sb.ToString();
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
