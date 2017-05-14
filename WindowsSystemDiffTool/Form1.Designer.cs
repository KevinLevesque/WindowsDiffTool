namespace WindowsSystemDiffTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.lstCompare = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.chkListScans = new System.Windows.Forms.CheckedListBox();
            this.chkToggle = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblAfterCompare = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnCompareAfter = new System.Windows.Forms.Button();
            this.lblBeforeCompare = new System.Windows.Forms.Label();
            this.lstSnapshots = new System.Windows.Forms.ListBox();
            this.txtCompareBefore = new System.Windows.Forms.Button();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.txtCompareLogs = new System.Windows.Forms.RichTextBox();
            this.progressBarCompare = new System.Windows.Forms.ProgressBar();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSaveExcel);
            this.tabPage3.Controls.Add(this.lstCompare);
            this.tabPage3.Controls.Add(this.txtResult);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(664, 576);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Results";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(3, 3);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(477, 428);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // lstCompare
            // 
            this.lstCompare.FormattingEnabled = true;
            this.lstCompare.Location = new System.Drawing.Point(486, 3);
            this.lstCompare.Name = "lstCompare";
            this.lstCompare.Size = new System.Drawing.Size(175, 550);
            this.lstCompare.TabIndex = 1;
            this.lstCompare.SelectedIndexChanged += new System.EventHandler(this.lstCompare_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.chkToggle);
            this.tabPage1.Controls.Add(this.chkListScans);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.btnStartScan);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(664, 576);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scan";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnStartScan
            // 
            this.btnStartScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScan.Location = new System.Drawing.Point(15, 307);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(643, 64);
            this.btnStartScan.TabIndex = 1;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.UseVisualStyleBackColor = true;
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 390);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(646, 142);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // chkListScans
            // 
            this.chkListScans.CheckOnClick = true;
            this.chkListScans.FormattingEnabled = true;
            this.chkListScans.Location = new System.Drawing.Point(12, 26);
            this.chkListScans.Name = "chkListScans";
            this.chkListScans.Size = new System.Drawing.Size(646, 259);
            this.chkListScans.TabIndex = 5;
            // 
            // chkToggle
            // 
            this.chkToggle.AutoSize = true;
            this.chkToggle.Location = new System.Drawing.Point(15, 6);
            this.chkToggle.Name = "chkToggle";
            this.chkToggle.Size = new System.Drawing.Size(73, 17);
            this.chkToggle.TabIndex = 6;
            this.chkToggle.Text = "Toggle All";
            this.chkToggle.UseVisualStyleBackColor = true;
            this.chkToggle.Click += new System.EventHandler(this.chkToggle_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 538);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(646, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(672, 602);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBarCompare);
            this.tabPage2.Controls.Add(this.txtCompareLogs);
            this.tabPage2.Controls.Add(this.lblAfterCompare);
            this.tabPage2.Controls.Add(this.btnCompare);
            this.tabPage2.Controls.Add(this.btnCompareAfter);
            this.tabPage2.Controls.Add(this.lblBeforeCompare);
            this.tabPage2.Controls.Add(this.lstSnapshots);
            this.tabPage2.Controls.Add(this.txtCompareBefore);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(664, 576);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compare";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // lblAfterCompare
            // 
            this.lblAfterCompare.AutoSize = true;
            this.lblAfterCompare.Location = new System.Drawing.Point(174, 185);
            this.lblAfterCompare.Name = "lblAfterCompare";
            this.lblAfterCompare.Size = new System.Drawing.Size(10, 13);
            this.lblAfterCompare.TabIndex = 10;
            this.lblAfterCompare.Text = "-";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(10, 451);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(149, 62);
            this.btnCompare.TabIndex = 11;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnCompareAfter
            // 
            this.btnCompareAfter.Location = new System.Drawing.Point(165, 159);
            this.btnCompareAfter.Name = "btnCompareAfter";
            this.btnCompareAfter.Size = new System.Drawing.Size(118, 23);
            this.btnCompareAfter.TabIndex = 8;
            this.btnCompareAfter.Text = "After";
            this.btnCompareAfter.UseVisualStyleBackColor = true;
            this.btnCompareAfter.Click += new System.EventHandler(this.btnCompareAfter_Click);
            // 
            // lblBeforeCompare
            // 
            this.lblBeforeCompare.AutoSize = true;
            this.lblBeforeCompare.Location = new System.Drawing.Point(174, 91);
            this.lblBeforeCompare.Name = "lblBeforeCompare";
            this.lblBeforeCompare.Size = new System.Drawing.Size(10, 13);
            this.lblBeforeCompare.TabIndex = 9;
            this.lblBeforeCompare.Text = "-";
            // 
            // lstSnapshots
            // 
            this.lstSnapshots.FormattingEnabled = true;
            this.lstSnapshots.Location = new System.Drawing.Point(6, 6);
            this.lstSnapshots.Name = "lstSnapshots";
            this.lstSnapshots.Size = new System.Drawing.Size(153, 420);
            this.lstSnapshots.TabIndex = 6;
            // 
            // txtCompareBefore
            // 
            this.txtCompareBefore.Location = new System.Drawing.Point(165, 65);
            this.txtCompareBefore.Name = "txtCompareBefore";
            this.txtCompareBefore.Size = new System.Drawing.Size(118, 23);
            this.txtCompareBefore.TabIndex = 7;
            this.txtCompareBefore.Text = "Before";
            this.txtCompareBefore.UseVisualStyleBackColor = true;
            this.txtCompareBefore.Click += new System.EventHandler(this.txtCompareBefore_Click);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(177, 456);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(111, 38);
            this.btnSaveExcel.TabIndex = 2;
            this.btnSaveExcel.Text = "Save as Excel File";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // txtCompareLogs
            // 
            this.txtCompareLogs.Location = new System.Drawing.Point(314, 3);
            this.txtCompareLogs.Name = "txtCompareLogs";
            this.txtCompareLogs.Size = new System.Drawing.Size(334, 507);
            this.txtCompareLogs.TabIndex = 12;
            this.txtCompareLogs.Text = "";
            // 
            // progressBarCompare
            // 
            this.progressBarCompare.Location = new System.Drawing.Point(10, 520);
            this.progressBarCompare.Name = "progressBarCompare";
            this.progressBarCompare.Size = new System.Drawing.Size(638, 38);
            this.progressBarCompare.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 627);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.Text = "WindowsDiffTool";
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lstCompare;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkToggle;
        private System.Windows.Forms.CheckedListBox chkListScans;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAfterCompare;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnCompareAfter;
        private System.Windows.Forms.Label lblBeforeCompare;
        private System.Windows.Forms.ListBox lstSnapshots;
        private System.Windows.Forms.Button txtCompareBefore;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.ProgressBar progressBarCompare;
        private System.Windows.Forms.RichTextBox txtCompareLogs;
    }
}

