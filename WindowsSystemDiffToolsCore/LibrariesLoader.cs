using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WindowsSystemDiffToolsCore
{
    public class LibrariesLoader
    {
        public UIListener Listener;

        public LibrariesLoader(UIListener listener)
        {
            this.Listener = listener;
        }


        private List<Library> libraries;

        public List<Library> GetLibraries()
        {
            if (libraries != null)
                return libraries;

            return new List<Library>();
        }


        public void LoadAllAssemblies(string path)
        {
            libraries = new List<Library>();

            string directory = Path.GetDirectoryName(path);
            foreach (string filePath in Directory.GetFiles(directory))
            {
                FileInfo fileInfo = new FileInfo(filePath);

                if (fileInfo.Extension == ".dll")
                {
                    Assembly DLL = Assembly.LoadFrom(fileInfo.FullName);
                    ComponentScanner scanner = null;
                    DiffCore diff = null;

                    try {
                        scanner = (ComponentScanner)DLL.CreateInstance(DLL.DefinedTypes.First(x => x.Name.EndsWith("Scanner")).FullName);
                        scanner.SetUIListener(Listener);
                    }
                    catch(Exception ex) { }

                    try { diff = (DiffCore)DLL.CreateInstance(DLL.DefinedTypes.First(x => x.Name.EndsWith("Diff")).FullName); }
                    catch (Exception ex) { }


                    if (scanner != null && diff != null)
                    {
                        libraries.Add(new Library(scanner, diff));
                    }
                }
            }
        }
    }
}
