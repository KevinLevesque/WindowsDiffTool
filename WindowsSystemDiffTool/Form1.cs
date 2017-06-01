using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
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

        Thread threadProcess;

        public Form1()
        {
            InitializeComponent();

            librariesLoader = new LibrariesLoader(this);
            librariesLoader.LoadAllAssemblies(System.Reflection.Assembly.GetAssembly(this.GetType()).Location);

            diffToolScanner = new DiffToolController(this);

            richTextBox1.ReadOnly = true;
            progressBar1.Maximum = 100;
            
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

            btnStartScan.Enabled = false;
            btnStartScan.Text = "Scan running, please wait...";

            threadProcess = new Thread(() =>
            {
                diffToolScanner.StartScan(librairies);

                btnStartScan.Invoke((MethodInvoker)(() =>
                {
                    btnStartScan.Enabled = true;
                    btnStartScan.Text = "Start Scan";
                }));
            });
            threadProcess.Start();       
        }

        public void sendStringToUI(string message)
        {
            richTextBox1.Invoke((MethodInvoker)(() =>
           {
               if (richTextBox1.Text.Length > 0)
                   richTextBox1.Text += Environment.NewLine;

               richTextBox1.Text += message;

               richTextBox1.SelectionStart = richTextBox1.Text.Length;
               richTextBox1.ScrollToCaret();
           }));
        }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            LoadCompareTab();
        }

        private void LoadCompareTab()
        {
            btnCompare.Enabled = false;
            progressBarCompare.Value = 0;

            cboBeforeFile.Items.Clear();
            cboAfterFile.Items.Clear();

            cboBeforeFile.Items.Add("<Before snapshot>");
            cboAfterFile.Items.Add("<After snapshot>");
            beforeCompare = null;
            afterCompare = null;

            cboBeforeFile.SelectedIndex = 0;
            cboAfterFile.SelectedIndex = 0;

            foreach (SnapshotFile file in SnapshotFilesLoader.GetFiles().OrderByDescending(x => x.Info.Name))
            {
                cboBeforeFile.Items.Add(file);
                cboAfterFile.Items.Add(file);
            }
        }

  

        private void btnCompare_Click(object sender, EventArgs e)
        {
            btnCompare.Enabled = false;
            btnCompare.Text = "Compare running, please wait...";

            progressBarCompare.Value = 0;

            threadProcess = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                diffToolScanner.CreateCompareFileFromSnapshots(this.beforeCompare, this.afterCompare);

                Thread.Sleep(1000);

                btnCompare.Invoke((MethodInvoker) (() =>
                {
                    btnCompare.Enabled = true;
                    btnCompare.Text = "Compare";
                }));

                tabControl.Invoke((MethodInvoker)(() =>
                {
                    tabControl.SelectTab(2);
                }));
            });
            threadProcess.Start();



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
            progressBar1.Invoke((MethodInvoker)(() =>
            {
                progressBar1.Value = percentComplete;
            }));

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
            txtResult.Text = "Currently loading diff results, please wait...";

            CompareFile compareFile = (CompareFile)lstCompare.SelectedItem;



            threadProcess = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                diffToolScanner.LoadCompareFile(compareFile);

                string res = diffToolScanner.GetTextFromSelectedCompareFile();

                txtResult.Invoke((MethodInvoker)(() =>
                {
                    txtResult.Text = res;                    
                }));
            });
            threadProcess.Start();
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
                  
        }

        public void UpdateComparePercentComplete(int percentComplete)
        {
            progressBarCompare.Invoke((MethodInvoker)(() =>
            {
                progressBarCompare.Value = percentComplete;
                progressBarCompare.Refresh();
            }));



        }

        private void btnIOpenTxtFile_Click(object sender, EventArgs e)
        {
            diffToolScanner.SaveTextToTempTxtFile();

            System.Diagnostics.Process.Start(@"C:\Temp\WindowsDiffTool\temp.txt");
        }



        private void cboBeforeFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBeforeCompare.Text = string.Empty;

            if (cboBeforeFile.SelectedIndex == 0)
            {
                beforeCompare = null;
                btnCompare.Enabled = false;
                return;
            }               

            beforeCompare = (SnapshotFile)cboBeforeFile.SelectedItem;

            txtBeforeCompare.Text = "Currently loading snapshot, please wait...";

            (new Thread(() =>
            {
                txtBeforeCompare.Invoke((MethodInvoker)(() =>
                {                  
                    txtBeforeCompare.Text = diffToolScanner.GetTextFromSnapshotFile(beforeCompare);

                    if (beforeCompare != null && afterCompare != null)
                        btnCompare.Enabled = true;
                }));
            })).Start();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAfterCompare.Text = string.Empty;

            if (cboAfterFile.SelectedIndex == 0)
            {
                afterCompare = null;
                btnCompare.Enabled = false;
                return;
            }

            afterCompare = (SnapshotFile)cboAfterFile.SelectedItem;
            txtAfterCompare.Text = "Currently loading snapshot, please wait...";
            
            (new Thread(() =>
            {
                txtAfterCompare.Invoke((MethodInvoker)(() =>
                {
                    txtAfterCompare.Text = diffToolScanner.GetTextFromSnapshotFile(afterCompare);

                    if (beforeCompare != null && afterCompare != null)
                        btnCompare.Enabled = true;
                }));
            })).Start();


        }
    }
}
