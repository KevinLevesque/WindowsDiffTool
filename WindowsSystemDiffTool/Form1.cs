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
        DiffToolController diffToolScanner;
        LibrariesLoader librariesLoader;

        SnapshotFile beforeCompare;
        SnapshotFile afterCompare;

        public Form1()
        {
            InitializeComponent();

            librariesLoader = new LibrariesLoader(this);
            librariesLoader.LoadAllAssemblies(System.Reflection.Assembly.GetAssembly(this.GetType()).Location);

            diffToolScanner = new DiffToolController(this);

            richTextBox1.ReadOnly = true;
            progressBar1.Maximum = 100;

            txtCompareLogs.ReadOnly = true;
            progressBarCompare.Maximum = 100;

            txtResult.ReadOnly = true;

            foreach(Library lib in librariesLoader.GetLibraries())
            {
                chkListScans.Items.Add(lib);
                diffToolScanner.ComponentsTypes.Add(lib.Scanner.TypeOfComponent());
            }
        }
        


        private void btnStartScan_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
                    

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


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadCompareTab();
        }

        private void LoadCompareTab()
        {
            lstSnapshots.Items.Clear();
            foreach(SnapshotFile file in SnapshotFilesLoader.GetFiles())
            {
                lstSnapshots.Items.Add(file);
            }
        }

        private void txtCompareBefore_Click(object sender, EventArgs e)
        {
            lblBeforeCompare.Text = lstSnapshots.SelectedItem.ToString();
            beforeCompare = (SnapshotFile)lstSnapshots.SelectedItem;
        }

        private void btnCompareAfter_Click(object sender, EventArgs e)
        {
            lblAfterCompare.Text = lstSnapshots.SelectedItem.ToString();
            afterCompare = (SnapshotFile)lstSnapshots.SelectedItem;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            progressBarCompare.Value = 0;
            txtCompareLogs.Text = string.Empty;

            diffToolScanner.CreateCompareFileFromSnapshots(this.beforeCompare, this.afterCompare);
            tabControl.SelectTab(2);
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

        public void UpdateCompareFilesList()
        {
            throw new NotImplementedException();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            LoadResultsTab();
        }

        private void LoadResultsTab()
        {
            lstCompare.Items.Clear();
            foreach (CompareFile file in CompareFilesLoader.GetFiles().OrderByDescending(x => x.Info.ToString()))
            {
                lstCompare.Items.Add(file);
            }

            if (lstCompare.Items.Count > 0)
                lstCompare.SelectedIndex = 0;
        }

        private void lstCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            diffToolScanner.LoadCompareFile((CompareFile)lstCompare.SelectedItem);
            txtResult.Text = diffToolScanner.GetTextFromSelectedCompareFile();
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDiag = new SaveFileDialog();

            saveDiag.Filter = "Excel File|*.xlsx";

            DialogResult result = saveDiag.ShowDialog();           


            if (result == DialogResult.OK)
            {
                diffToolScanner.SaveSelectedCompareFileToExcel(saveDiag.FileName);

                System.Diagnostics.Process.Start($"{saveDiag.FileName}");
            }
        }

        public void UpdateCompareMessage(string message)
        {
            if (txtCompareLogs.Text.Length > 0)
                txtCompareLogs.Text += Environment.NewLine;

            txtCompareLogs.Text += message;

            txtCompareLogs.SelectionStart = txtCompareLogs.Text.Length;
            txtCompareLogs.ScrollToCaret();

            Application.DoEvents();
        }

        public void UpdateComparePercentComplete(int percentComplete)
        {
            progressBarCompare.Value = percentComplete;
            progressBarCompare.Refresh();
        }
    }
}
