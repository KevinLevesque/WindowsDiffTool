using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSystemDiffToolsCore;

namespace WindowsSystemDiffTool
{
    public partial class Form1 : Form, UIListener
    {
        DiffToolScanner diffToolScanner;


        public Form1()
        {
            InitializeComponent();
            LoadScanners();
            diffToolScanner = new DiffToolScanner(this);
        }

        private void LoadScanners()
        {
            string fullPath = System.Reflection.Assembly.GetAssembly(typeof(Form1)).Location;
            string directory = Path.GetDirectoryName(fullPath);

            foreach (string filePath in Directory.GetFiles(directory))
            {
                FileInfo fileInfo = new FileInfo(filePath);

                if (fileInfo.Name.Contains("Scanner.dll"))
                {
                    Assembly DLL = Assembly.LoadFrom(fileInfo.FullName);
                    IComponentScanner scanner = (IComponentScanner)DLL.CreateInstance("WindowsSystemDiffToolsScanner.Scanner");
                    scanner.addUIListener(this);

                    chkListScans.Items.Add(scanner);
                }
            }
        }
                

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            
            for(int x = 0; x < chkListScans.CheckedItems.Count; x++)
            {
                diffToolScanner.addScanner((IComponentScanner)chkListScans.CheckedItems[x]);
            }

            diffToolScanner.StartScan();
        }

        public void sendStringToUI(string message)
        {
            if (richTextBox1.Text.Length > 0)
                richTextBox1.Text += Environment.NewLine;

            richTextBox1.Text += message;
        }
    }
}
