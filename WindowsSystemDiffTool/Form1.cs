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
using System.Threading;
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

            richTextBox1.ReadOnly = true;
            progressBar1.Maximum = 100;


            foreach(Library lib in librariesLoader.GetLibraries())
            {
                chkListScans.Items.Add(lib);
                diffToolScanner.AllComponentsTypes.Add(lib.Scanner.TypeOfComponent());
            }
        }
        


        private void btnStartScan_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text = string.Empty;
                progressBar1.Value = 0;
            }
            

            

            List<Library> librairies = new List<Library>();   
            for(int x = 0; x < chkListScans.CheckedItems.Count; x++)
            {
                librairies.Add((Library)chkListScans.CheckedItems[x]);
            }

            diffToolScanner.StartScan(librairies);
        }

        public void sendStringToUI(string message)
        {
            if (richTextBox1.Text.Length > 0)
                richTextBox1.Text += Environment.NewLine;

            richTextBox1.Text += message;

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
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
                ComponentGroup afterGroup = afterComponentGroup.FirstOrDefault(x => x.ComponentName == beforeGroup.ComponentName);

                try
                {
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
                    else
                        diffWriters.Add(new DiffResultWriter(null, beforeGroup.ComponentName));
                }
                catch
                {
                    diffWriters.Add(new DiffResultWriter(null, beforeGroup.ComponentName));
                }

            }

            foreach (ComponentGroup afterGroup in afterComponentGroup)
            {
                ComponentGroup beforeGroup = beforeComponentGroup.FirstOrDefault(x => x.ComponentName == afterGroup.ComponentName);

                //If beforegroup is null, component was only scanned in the "after" scan. 
                if (beforeGroup == null)
                {
                    diffWriters.Add(new DiffResultWriter(null, afterGroup.ComponentName));
                }
                
            }

            Directory.CreateDirectory(@"C:\Temp\WindowsDiffTool\Compare");

            string filePath = @"C:\Temp\WindowsDiffTool\Compare\" + DateTime.Now.ToString("yyyy-MM-dd_H_mm_ss") + ".txt";

            using (StreamWriter sr = new StreamWriter(filePath))
            {
                foreach (DiffResultWriter reswriter in diffWriters)
                {
                    sr.Write(reswriter.GetText());
                }
            }

            System.Diagnostics.Process.Start(filePath);

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chkToggle_Click(object sender, EventArgs e)
        {
            

            for(int x = 0; x<chkListScans.Items.Count; x++)
            {
                chkListScans.SetItemChecked(x, chkToggle.Checked);
            }
        }

        public void UpdatePercentComplete(int percentComplete)
        {
            progressBar1.Value = percentComplete;
        }
    }
}
