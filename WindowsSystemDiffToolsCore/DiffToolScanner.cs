using System;
using System.Collections.Generic;
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
        public List<ComponentScanner> Scanners { get; set; }

        public List<ComponentGroup> ScanResults;


        public DiffToolScanner(UIListener listener)
        {
            Scanners = new List<ComponentScanner>();
            ScanResults = new List<ComponentGroup>();
            Listener = listener;
        }


        public void addScanner(ComponentScanner scanner)
        {
            if(!Scanners.Contains(scanner))
                Scanners.Add(scanner);
        }


        public void StartScan()
        {
            foreach (ComponentScanner scanner in Scanners)
            {
                Listener.sendStringToUI("Lancement du scan de la librairie " + scanner.ToString());
                Listener.sendStringToUI("***************************************");
                ScanResults.Add(new ComponentGroup()
                {
                    ComponentName = scanner.ComponentName,
                    ComponentNameSpace = scanner.ComponentNamespace,
                    Components = scanner.Scan()
                });
                Listener.sendStringToUI("***************************************");
            }

            WriteToFile();
            ScanResults.Clear();
        }

        private void WriteToFile()
        {
            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool");

            try
            {
                List<Type> types = new List<Type>();
                foreach (ComponentScanner scanner in Scanners)
                {
                    types.Add(scanner.TypeOfComponent());
                }

                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(this.ScanResults.GetType(), types.ToArray<Type>());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, this.ScanResults);
                    stream.Position = 0;
                    xmlDocument.Load(stream);

                    xmlDocument.Save(@"C:\Temp\WindowsDiffTool\" + DateTime.Now.ToString("yyyyMMddHmmss") + ".compare");


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
            List<Type> types = new List<Type>();
            foreach (ComponentScanner scanner in Scanners)
            {
                types.Add(scanner.TypeOfComponent());
            }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(this.ScanResults.GetType(), types.ToArray<Type>());
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
