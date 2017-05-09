using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSystemDiffToolsCore;

namespace WindowsSystemDiffTool
{
    public partial class Form1 : Form, UIListener
    {
        DiffToolScanner diffToolScanner;
        LibrariesLoader librariesLoader;

        CompareFile beforeCompare;
        CompareFile afterCompare;

        public Form1()
        {
            InitializeComponent();

            librariesLoader = new LibrariesLoader(this);
            librariesLoader.LoadAllAssemblies(System.Reflection.Assembly.GetAssembly(this.GetType()).Location);

            diffToolScanner = new DiffToolScanner(this);


            foreach(Library lib in librariesLoader.GetLibraries())
            {
                chkListScans.Items.Add(lib);
            }
        }
        


        private void btnStartScan_Click(object sender, EventArgs e)
        {
            
            for(int x = 0; x < chkListScans.CheckedItems.Count; x++)
            {
                diffToolScanner.addScanner(((Library)chkListScans.CheckedItems[x]).Scanner);
            }

            diffToolScanner.StartScan();
        }

        public void sendStringToUI(string message)
        {
            if (richTextBox1.Text.Length > 0)
                richTextBox1.Text += Environment.NewLine;

            richTextBox1.Text += message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LoadDiff();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadCompareTab();
        }

        private void LoadCompareTab()
        {
            listBox1.Items.Clear();
            foreach(CompareFile file in CompareFilesLoader.GetFiles())
            {
                listBox1.Items.Add(file);
            }
        }

        private void txtCompareBefore_Click(object sender, EventArgs e)
        {
            lblBeforeCompare.Text = listBox1.SelectedItem.ToString();
            beforeCompare = (CompareFile)listBox1.SelectedItem;
        }

        private void btnCompareAfter_Click(object sender, EventArgs e)
        {
            lblAfterCompare.Text = listBox1.SelectedItem.ToString();
            afterCompare = (CompareFile)listBox1.SelectedItem;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            List<DiffResultWriter> diffWriters = new List<DiffResultWriter>();

            List<ComponentGroup> beforeComponentGroup = diffToolScanner.ReadFromFile(beforeCompare.Info.FullName);
            List<ComponentGroup> afterComponentGroup = diffToolScanner.ReadFromFile(afterCompare.Info.FullName);

            foreach(ComponentGroup beforeGroup in beforeComponentGroup)
            {
                ComponentGroup afterGroup = afterComponentGroup.First(x => x.ComponentName == beforeGroup.ComponentName);

                //Group exists in both lists
                if (afterGroup != null)
                {
                    ObjectHandle obj = Activator.CreateInstance(beforeGroup.ComponentNameSpace, beforeGroup.ComponentNameSpace + "." + beforeGroup.ComponentName + "Diff");
                    DiffCore diff = (DiffCore)obj.Unwrap();

                    diff.beforeData = beforeGroup.Components;
                    diff.afterData = afterGroup.Components;

                    List<DiffResult> diffResults = diff.Start();

                    diffWriters.Add(new DiffResultWriter(diffResults, beforeGroup.ComponentName));
                }
            }

            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Compare");

            using (StreamWriter sr = new StreamWriter(@"C:\Temp\WindowsDiffTool\Compare\compare.txt"))
            {
                foreach (DiffResultWriter reswriter in diffWriters)
                {
                    sr.Write(reswriter.GetText());
                }
            }

        }
    }
}
