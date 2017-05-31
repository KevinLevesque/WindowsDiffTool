using ClosedXML.Excel;
using System.Collections.Generic;

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
            int row = 2;

            for (int x=0; x<results.Count; x++)
            {

                ws.Cell($"A{row}").Value = "Before";
                if (results[x].BeforeComponent != null)
                {
                    ws.Cell($"B{row}").Value = results[x].BeforeComponent.getDisplayName();
                    WriteComponent(results[x].BeforeComponent, ws, row, results[x].Type);
                }
                else
                {
                    ws.Cell($"B{row}").Value = "---ADDED---";
                }

                row++;

                ws.Cell($"A{row}").Value = "After";
                if (results[x].AfterComponent != null)
                {
                    ws.Cell($"B{row}").Value = results[x].AfterComponent.getDisplayName();
                    WriteComponent(results[x].AfterComponent, ws, row, results[x].Type);
                }
                else
                {
                    ws.Cell($"B{row}").Value = "---DELETED---";
                }

                row += 2;

            }
        }

        private void WriteComponent(Component c, IXLWorksheet ws, int row, DiffResultType diffType)
        {
            int y = 2;
            foreach (KeyValuePair<string, string> item in c.getItems())
            {
                ws.Cell($"{columns[y]}{row}").Value = item.Value;
                y++;
            }
        }

        private void WriteHeader(IXLWorksheet ws, DiffResult diff)
        {
            Component comp = diff.AfterComponent;

            if (comp == null)
                comp = diff.BeforeComponent;

            int x = 2;
            foreach(KeyValuePair<string, string> item in comp.getItems())
            {
                ws.Cell($"{columns[x]}1").Value = item.Key;
                x++;
            }
        }

        public void Save()
        {
            wb.SaveAs(this.filepath);
        }
    }
}
