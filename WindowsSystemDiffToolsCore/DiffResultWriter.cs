using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public class DiffResultWriter
    {

        List<DiffResult> Results { get; set; }
        string ComponentGroupName { get; set; }


        /// if results is null, differential was not made. Most likely component was only scanned in one of both files.
        public DiffResultWriter(List<DiffResult> results, string componentGroupName)
        {
            this.Results = results;
            this.ComponentGroupName = componentGroupName;
        }



        public string GetText()
        {
            string text = $"[{ComponentGroupName}]" + Environment.NewLine;

            if(Results == null)
            {
                text += "-- Component was only scanned in one of both scans, can't display differential or unable to load libraty--" + Environment.NewLine;
            }
            else if (Results.Count == 0)
            {
                text += "-- No known change between the two scans for this component --" + Environment.NewLine;
            }
            else
            {
                foreach (DiffResult result in Results)
                {
                    if (result.Type == DiffResultType.Added)
                    {
                        text += $"{result.NewValue} ---- Added" + Environment.NewLine;
                    }
                    else if (result.Type == DiffResultType.Modified)
                    {
                        text += $"{result.OldValue} ---> {result.NewValue} ---- Modified" + Environment.NewLine;
                    }
                    else if (result.Type == DiffResultType.Removed)
                    {
                        text += $"{result.OldValue} ---- Deleted" + Environment.NewLine;
                    }
                }
            }
            

            text += Environment.NewLine + Environment.NewLine;
            return text;
        }


        


    }
}
