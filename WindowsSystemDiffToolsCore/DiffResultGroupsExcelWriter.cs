using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSystemDiffToolsCore
{
    public class DiffResultGroupsExcelWriter
    {
        List<string> columns = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        XLWorkbook wb { get; set; }
        string filepath { get; set; }

        public DiffResultGroupsExcelWriter(string _filePath)
        {
            wb = new XLWorkbook();
            this.filepath = _filePath;
        }

        public void GenerateExcel(List<DiffResultsGroup> groups)
        {
            foreach(DiffResultsGroup group in groups)
            {
                IXLWorksheet ws = wb.Worksheets.Add(group.Name);

                if (group.DiffResults.Count > 0)
                {
                    WriteHeader(ws, group.DiffResults[0]);
                    WriteData(ws, group.DiffResults);
                }

                ws.Columns().AdjustToContents();
                
            }

           
        }

        private void WriteData(IXLWorksheet ws, List<DiffResult> results)
        {
            for (int x=0; x<results.Count; x++)
            {
                ws.Cell($"A{x+2}").Value = results[x].AfterComponent.getDisplayName();

                int y = 1;
                foreach (KeyValuePair<string, string> item in results[x].AfterComponent.getItems())
                {
                    ws.Cell($"{columns[y]}{x + 2}").Value = item.Value;
                    y++;
                }

                ws.Cell($"{columns[y]}{x + 2}").Value = results[x].Type.ToString();
            }
        }

        private void WriteHeader(IXLWorksheet ws, DiffResult diff)
        {

            int x = 1;
            foreach(KeyValuePair<string, string> item in diff.AfterComponent.getItems())
            {
                ws.Cell($"{columns[x]}1").Value = item.Key;
                x++;
            }
            ws.Cell($"{columns[x]}1").Value = "DiffType";
        }

        public void Save()
        {
            wb.SaveAs(this.filepath);
        }
    }
}
