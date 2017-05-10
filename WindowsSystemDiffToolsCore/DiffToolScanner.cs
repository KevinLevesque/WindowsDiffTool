using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsSystemDiffToolsCore
{
    public class DiffToolScanner
    {
        [XmlIgnore]
        public UIListener Listener;

        [XmlIgnore]
        public List<Type> AllComponentsTypes { get; set; }

        public List<ComponentGroup> ScanResults;


        public DiffToolScanner(UIListener listener)
        {
            ScanResults = new List<ComponentGroup>();
            Listener = listener;
            AllComponentsTypes = new List<Type>();
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
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool");

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.ScanResults.GetType(), AllComponentsTypes.ToArray());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this.ScanResults);
                    stream.Position = 0;
                    xmlDocument.Load(stream);

                    xmlDocument.Save(@"C:\Temp\WindowsDiffTool\" + DateTime.Now.ToString("yyyy-MM-dd_H_mm_ss") + ".xml");


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
            XmlSerializer serializer = new XmlSerializer(this.ScanResults.GetType(), AllComponentsTypes.ToArray());
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

            /*
            foreach(ComponentGroup cg in ScanResults)
            {
                return cg.Components;
            }
            */

            return null;
        }
    }
}
