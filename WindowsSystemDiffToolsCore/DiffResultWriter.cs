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

        public DiffResultWriter(List<DiffResult> results, string componentGroupName)
        {
            this.Results = results;
            this.ComponentGroupName = componentGroupName;
        }


        public string GetText()
        {
            string text = $"[{ComponentGroupName}]" + Environment.NewLine;


            foreach(DiffResult result in Results)
            {
                if(result.Type == DiffResultType.Added)
                {
                    text += $"{result.NewValue} ---- Added" + Environment.NewLine;
                }
                else if(result.Type == DiffResultType.Modified)
                {
                    text += $"{result.OldValue} ---> {result.NewValue} ---- Modified" + Environment.NewLine;
                }
                else if (result.Type == DiffResultType.Removed)
                {
                    text += $"{result.OldValue} ---- Deleted" + Environment.NewLine;
                }
            }

            return text;
        }


        


    }
}
