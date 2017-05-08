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
        public List<IComponentScanner> Scanners { get; set; }

        public List<ComponentGroup> ScanResults;


        public DiffToolScanner(UIListener listener)
        {
            Scanners = new List<IComponentScanner>();
            ScanResults = new List<ComponentGroup>();
            Listener = listener;
        }


        public void addScanner(IComponentScanner scanner)
        {
            Scanners.Add(scanner);
        }


        public void StartScan()
        {
            foreach(IComponentScanner scanner in Scanners)
            {
                Listener.sendStringToUI("Début du scan pour " + scanner.ToString());
                ScanResults.Add(new ComponentGroup() {
                    Name = scanner.XmlAttributeComponentName(),
                    Components = scanner.Scan()
                });
            }

            WriteToFile();
        }

        private void WriteToFile()
        {

            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool");
            try
            {

                List<Type> types = new List<Type>();
                foreach (IComponentScanner scanner in Scanners)
                {
                    types.Add(scanner.typeOfComponent());
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
                throw;
            }
        }
    }
}
