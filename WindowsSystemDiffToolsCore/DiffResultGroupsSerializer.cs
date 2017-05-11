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
    public static class DiffResultGroupsSerializer
    {


        public static CompareFile Save(List<DiffResultsGroup> results, string filePath, Type[] types)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(List<DiffResultsGroup>), types);
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, results);
                    stream.Position = 0;
                    xmlDocument.Load(stream);

                    xmlDocument.Save(filePath);

                    stream.Close();

                    return new CompareFile(filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<DiffResultsGroup> Load(CompareFile file, Type[] types)
        {
            List<DiffResult> results = new List<DiffResult>();

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(List<DiffResultsGroup>), types);
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(file.Info.FullName))))
            {
                try
                {
                    return (List<DiffResultsGroup>)serializer.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
