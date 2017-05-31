using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsSystemDiffToolsCore
{
    public class DiffToolController
    {
        public UIListener Listener;
        public List<Type> ComponentsTypes { get; set; }

        private List<ComponentGroup> ScanResults;
        private List<DiffResultsGroup> CurrentCompareFileSelectedResult;
        private DiffComparator DiffComparator;


        public DiffToolController(UIListener listener)
        {
            ScanResults = new List<ComponentGroup>();
            Listener = listener;
            ComponentsTypes = new List<Type>();
            DiffComparator = new DiffComparator(Listener);
        }



        public void StartScan(List<Library> LibrariesToScan)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = 0;
            Listener.UpdatePercentComplete(count);

            foreach (Library lib in LibrariesToScan)
            {
                Listener.sendStringToUI("Launching scan for for library " + lib.Scanner.ToString());
                Listener.sendStringToUI("***************************************");
                ScanResults.Add(new ComponentGroup()
                {
                    ComponentName = lib.Scanner.ComponentName,
                    ComponentNameSpace = lib.Scanner.ComponentNamespace,
                    Components = lib.Scanner.Scan()
                });
                Listener.sendStringToUI("***************************************");
                Listener.sendStringToUI(Environment.NewLine);

                count++;

                Listener.UpdatePercentComplete((count / LibrariesToScan.Count) * 100);
            }

            WriteToFile();
            ScanResults.Clear();
            
            Listener.sendStringToUI("Scan completed in " + sw.Elapsed.ToString("c")); 
        }

        private void WriteToFile()
        {
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Snapshots");

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.ScanResults.GetType(), ComponentsTypes.ToArray());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this.ScanResults);
                    stream.Position = 0;
                    xmlDocument.Load(stream);

                    xmlDocument.Save(@"C:\Temp\WindowsDiffTool\Snapshots\" + DateTime.Now.ToString("yyyy-MM-dd_H_mm_ss") + ".xml");


                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ComponentGroup> ReadFromFile(string filepath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.ScanResults.GetType(), ComponentsTypes.ToArray());
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(filepath))))
            {
                try
                {
                    return (List<ComponentGroup>)serializer.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }



        public CompareFile CreateCompareFileFromSnapshots(SnapshotFile beforeFile, SnapshotFile afterFile)
        {
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Compare");

            List<DiffResultsGroup> diffResultGroups =  DiffComparator.Compare(this.ReadFromFile(beforeFile.Info.FullName), this.ReadFromFile(afterFile.Info.FullName));
            return DiffResultGroupsSerializer.Save(diffResultGroups, $@"C:\Temp\WindowsDiffTool\Compare\{DateTime.Now.ToString("yyyy-MM-dd_H_mm_ss")}.xml", ComponentsTypes.ToArray());
        }


        public void LoadCompareFile(CompareFile file)
        {
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Compare");

            CurrentCompareFileSelectedResult = DiffResultGroupsSerializer.Load(file, ComponentsTypes.ToArray());
        }

        public string GetTextFromSelectedCompareFile()
        {
            return DiffResultGroupsTextWriter.GetText(this.CurrentCompareFileSelectedResult);
        }

        public void SaveTextToTempTxtFile()
        {
            using (StreamWriter sr = new StreamWriter(@"C:\Temp\WindowsDiffTool\temp.txt"))
            {
                sr.Write(DiffResultGroupsTextWriter.GetText(this.CurrentCompareFileSelectedResult));
            }
        }

        public void SaveSelectedCompareFileToExcel(string filePath)
        {
            DiffResultGroupsExcelWriter excelwriter = new DiffResultGroupsExcelWriter(filePath);
            excelwriter.GenerateExcel(CurrentCompareFileSelectedResult);
            excelwriter.Save();
        }


    }
}
