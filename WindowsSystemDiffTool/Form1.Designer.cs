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
            this.btnOpenTxtFile = new System.Windows.Forms.Button();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.lstCompare = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkToggle = new System.Windows.Forms.CheckBox();
            this.chkListScans = new System.Windows.Forms.CheckedListBox();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBarCompare = new System.Windows.Forms.ProgressBar();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtBeforeCompare = new System.Windows.Forms.TextBox();
            this.cboBeforeFile = new System.Windows.Forms.ComboBox();
            this.cboAfterFile = new System.Windows.Forms.ComboBox();
            this.txtAfterCompare = new System.Windows.Forms.TextBox();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtResult);
            this.tabPage3.Controls.Add(this.btnOpenTxtFile);
            this.tabPage3.Controls.Add(this.btnSaveExcel);
            this.tabPage3.Controls.Add(this.lstCompare);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(664, 576);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Results";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // btnOpenTxtFile
            // 
            this.btnOpenTxtFile.Location = new System.Drawing.Point(84, 456);
            this.btnOpenTxtFile.Name = "btnOpenTxtFile";
            this.btnOpenTxtFile.Size = new System.Drawing.Size(107, 37);
            this.btnOpenTxtFile.TabIndex = 4;
            this.btnOpenTxtFile.Text = "Open in txt file";
            this.btnOpenTxtFile.UseVisualStyleBackColor = true;
            this.btnOpenTxtFile.Click += new System.EventHandler(this.btnIOpenTxtFile_Click);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(250, 455);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(111, 38);
            this.btnSaveExcel.TabIndex = 2;
            this.btnSaveExcel.Text = "Save as Excel File";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
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
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.chkToggle);
            this.tabPage1.Controls.Add(this.chkListScans);
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 378);
            this.richTextBox1.Multiline = true;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(643, 154);
            this.richTextBox1.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 538);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(646, 23);
            this.progressBar1.TabIndex = 7;
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
            // chkListScans
            // 
            this.chkListScans.CheckOnClick = true;
            this.chkListScans.FormattingEnabled = true;
            this.chkListScans.Location = new System.Drawing.Point(12, 26);
            this.chkListScans.Name = "chkListScans";
            this.chkListScans.Size = new System.Drawing.Size(646, 259);
            this.chkListScans.TabIndex = 5;
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
            this.tabPage2.Controls.Add(this.txtAfterCompare);
            this.tabPage2.Controls.Add(this.cboAfterFile);
            this.tabPage2.Controls.Add(this.cboBeforeFile);
            this.tabPage2.Controls.Add(this.txtBeforeCompare);
            this.tabPage2.Controls.Add(this.progressBarCompare);
            this.tabPage2.Controls.Add(this.btnCompare);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(664, 576);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compare";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // progressBarCompare
            // 
            this.progressBarCompare.Location = new System.Drawing.Point(10, 520);
            this.progressBarCompare.Name = "progressBarCompare";
            this.progressBarCompare.Size = new System.Drawing.Size(638, 38);
            this.progressBarCompare.TabIndex = 13;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(126, 457);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(393, 62);
            this.btnCompare.TabIndex = 11;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(4, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(476, 445);
            this.txtResult.TabIndex = 5;
            // 
            // txtBeforeCompare
            // 
            this.txtBeforeCompare.Location = new System.Drawing.Point(5, 24);
            this.txtBeforeCompare.Multiline = true;
            this.txtBeforeCompare.Name = "txtBeforeCompare";
            this.txtBeforeCompare.ReadOnly = true;
            this.txtBeforeCompare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBeforeCompare.Size = new System.Drawing.Size(325, 427);
            this.txtBeforeCompare.TabIndex = 14;
            this.txtBeforeCompare.WordWrap = false;
            // 
            // cboBeforeFile
            // 
            this.cboBeforeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBeforeFile.FormattingEnabled = true;
            this.cboBeforeFile.Location = new System.Drawing.Point(5, 4);
            this.cboBeforeFile.Name = "cboBeforeFile";
            this.cboBeforeFile.Size = new System.Drawing.Size(325, 21);
            this.cboBeforeFile.TabIndex = 16;
            this.cboBeforeFile.SelectedIndexChanged += new System.EventHandler(this.cboBeforeFile_SelectedIndexChanged);
            // 
            // cboAfterFile
            // 
            this.cboAfterFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAfterFile.FormattingEnabled = true;
            this.cboAfterFile.Location = new System.Drawing.Point(336, 4);
            this.cboAfterFile.Name = "cboAfterFile";
            this.cboAfterFile.Size = new System.Drawing.Size(325, 21);
            this.cboAfterFile.TabIndex = 17;
            this.cboAfterFile.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txtAfterCompare
            // 
            this.txtAfterCompare.Location = new System.Drawing.Point(336, 24);
            this.txtAfterCompare.Multiline = true;
            this.txtAfterCompare.Name = "txtAfterCompare";
            this.txtAfterCompare.ReadOnly = true;
            this.txtAfterCompare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAfterCompare.Size = new System.Drawing.Size(325, 427);
            this.txtAfterCompare.TabIndex = 18;
            this.txtAfterCompare.WordWrap = false;
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
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkToggle;
        private System.Windows.Forms.CheckedListBox chkListScans;
        private System.Windows.Forms.Button btnStartScan;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.ProgressBar progressBarCompare;
        private System.Windows.Forms.TextBox richTextBox1;
        private System.Windows.Forms.Button btnOpenTxtFile;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtAfterCompare;
        private System.Windows.Forms.ComboBox cboAfterFile;
        private System.Windows.Forms.ComboBox cboBeforeFile;
        private System.Windows.Forms.TextBox txtBeforeCompare;
    }
}

