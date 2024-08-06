namespace PaperSearch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtKey = new DevExpress.XtraEditors.TextEdit();
            labKey = new DevExpress.XtraEditors.LabelControl();
            btnImport = new DevExpress.XtraEditors.SimpleButton();
            btnExport = new DevExpress.XtraEditors.SimpleButton();
            btnSearch = new DevExpress.XtraEditors.SimpleButton();
            openFileDialog1 = new OpenFileDialog();
            lstLog = new DevExpress.XtraEditors.ListBoxControl();
            lstPaper = new DevExpress.XtraEditors.ListBoxControl();
            btnClr = new DevExpress.XtraEditors.SimpleButton();
            lstRes = new DevExpress.XtraEditors.ListBoxControl();
            cmbxExport = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)txtKey.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lstLog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lstPaper).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lstRes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbxExport.Properties).BeginInit();
            SuspendLayout();
            // 
            // txtKey
            // 
            txtKey.Location = new Point(976, 134);
            txtKey.Name = "txtKey";
            txtKey.Properties.AutoHeight = false;
            txtKey.Size = new Size(622, 89);
            txtKey.TabIndex = 2;
            // 
            // labKey
            // 
            labKey.Location = new Point(976, 64);
            labKey.Name = "labKey";
            labKey.Size = new Size(72, 29);
            labKey.TabIndex = 3;
            labKey.Text = "关键词";
            labKey.MouseLeave += keyLabel_MouseLeave;
            labKey.MouseHover += keyLabel_MouseHover;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(257, 295);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(202, 55);
            btnImport.TabIndex = 5;
            btnImport.Text = "导入论文";
            btnImport.Click += btnImport_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(509, 295);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(202, 55);
            btnExport.TabIndex = 6;
            btnExport.Text = "导出结果";
            btnExport.Click += btnExport_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(976, 295);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(202, 55);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "查找";
            btnSearch.Click += btnSearch_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lstLog
            // 
            lstLog.Location = new Point(12, 373);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(1149, 477);
            lstLog.TabIndex = 8;
            // 
            // lstPaper
            // 
            lstPaper.Location = new Point(12, 64);
            lstPaper.Name = "lstPaper";
            lstPaper.Size = new Size(895, 199);
            lstPaper.TabIndex = 9;
            // 
            // btnClr
            // 
            btnClr.Location = new Point(751, 295);
            btnClr.Name = "btnClr";
            btnClr.Size = new Size(202, 55);
            btnClr.TabIndex = 10;
            btnClr.Text = "清空日志";
            btnClr.Click += btnClr_Click;
            // 
            // lstRes
            // 
            lstRes.Location = new Point(1176, 373);
            lstRes.Name = "lstRes";
            lstRes.Size = new Size(422, 477);
            lstRes.TabIndex = 11;
            // 
            // cmbxExport
            // 
            cmbxExport.Location = new Point(1208, 295);
            cmbxExport.Name = "cmbxExport";
            cmbxExport.Properties.AutoHeight = false;
            cmbxExport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbxExport.Size = new Size(202, 55);
            cmbxExport.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1612, 906);
            Controls.Add(cmbxExport);
            Controls.Add(lstRes);
            Controls.Add(btnClr);
            Controls.Add(lstPaper);
            Controls.Add(lstLog);
            Controls.Add(btnSearch);
            Controls.Add(btnExport);
            Controls.Add(btnImport);
            Controls.Add(labKey);
            Controls.Add(txtKey);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "效率极低完全不考虑性能的O(n2)论文查找器";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)txtKey.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lstLog).EndInit();
            ((System.ComponentModel.ISupportInitialize)lstPaper).EndInit();
            ((System.ComponentModel.ISupportInitialize)lstRes).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbxExport.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtKey;
        private DevExpress.XtraEditors.LabelControl labKey;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.ListBoxControl lstLog;
        private DevExpress.XtraEditors.ListBoxControl lstPaper;
        private DevExpress.XtraEditors.SimpleButton btnClr;
        private DevExpress.XtraEditors.ListBoxControl lstRes;
        private DevExpress.XtraEditors.LookUpEdit cmbxExport;
    }
}
