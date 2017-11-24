namespace Centerport.Report
{
    partial class Report_Lab
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
            this.components = new System.ComponentModel.Container();
            this.R_lab06 = new System.Windows.Forms.RadioButton();
            this.R_lab08 = new System.Windows.Forms.RadioButton();
            this.R_Hema = new System.Windows.Forms.RadioButton();
            this.R_Chem = new System.Windows.Forms.RadioButton();
            this.R_Fecal = new System.Windows.Forms.RadioButton();
            this.R_Urine = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.r_lab34 = new System.Windows.Forms.RadioButton();
            this.R_lab_061 = new Centerport.Report.R_lab_06();
            this.R_Chemistry1 = new Centerport.Report.R_Chemistry();
            this.R_lab_081 = new Centerport.Report.R_lab_08();
            this.R_HemaLab011 = new Centerport.Report.R_HemaLab01();
            this.R_Urinalysis1 = new Centerport.Report.R_Urinalysis();
            this.R_Fecalysis1 = new Centerport.Report.R_Fecalysis();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.R_chemistry_Form341 = new Centerport.Report.R_chemistry_Form34();
            this.wizard1 = new Centerport.Class.Wizard();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Viewer_01 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Viewer_02 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Viewer_03 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Viewer_04 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Viewer_05 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Viewer_06 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tab_lab34 = new System.Windows.Forms.TabPage();
            this.crystalReport_lab34 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.wizard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tab_lab34.SuspendLayout();
            this.SuspendLayout();
            // 
            // R_lab06
            // 
            this.R_lab06.AutoSize = true;
            this.R_lab06.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_lab06.Location = new System.Drawing.Point(7, 11);
            this.R_lab06.Name = "R_lab06";
            this.R_lab06.Size = new System.Drawing.Size(94, 17);
            this.R_lab06.TabIndex = 0;
            this.R_lab06.Text = "FORM LAB-06";
            this.R_lab06.UseVisualStyleBackColor = true;
            this.R_lab06.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // R_lab08
            // 
            this.R_lab08.AutoSize = true;
            this.R_lab08.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_lab08.Location = new System.Drawing.Point(100, 11);
            this.R_lab08.Name = "R_lab08";
            this.R_lab08.Size = new System.Drawing.Size(94, 17);
            this.R_lab08.TabIndex = 1;
            this.R_lab08.Text = "FORM LAB-08";
            this.R_lab08.UseVisualStyleBackColor = true;
            this.R_lab08.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // R_Hema
            // 
            this.R_Hema.AutoSize = true;
            this.R_Hema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Hema.Location = new System.Drawing.Point(193, 11);
            this.R_Hema.Name = "R_Hema";
            this.R_Hema.Size = new System.Drawing.Size(81, 17);
            this.R_Hema.TabIndex = 2;
            this.R_Hema.Text = "Hematology";
            this.R_Hema.UseVisualStyleBackColor = true;
            this.R_Hema.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // R_Chem
            // 
            this.R_Chem.AutoSize = true;
            this.R_Chem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Chem.Location = new System.Drawing.Point(272, 11);
            this.R_Chem.Name = "R_Chem";
            this.R_Chem.Size = new System.Drawing.Size(70, 17);
            this.R_Chem.TabIndex = 3;
            this.R_Chem.Text = "Chemistry";
            this.R_Chem.UseVisualStyleBackColor = true;
            this.R_Chem.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // R_Fecal
            // 
            this.R_Fecal.AutoSize = true;
            this.R_Fecal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Fecal.Location = new System.Drawing.Point(410, 11);
            this.R_Fecal.Name = "R_Fecal";
            this.R_Fecal.Size = new System.Drawing.Size(68, 17);
            this.R_Fecal.TabIndex = 4;
            this.R_Fecal.Text = "Fecalysis";
            this.R_Fecal.UseVisualStyleBackColor = true;
            this.R_Fecal.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // R_Urine
            // 
            this.R_Urine.AutoSize = true;
            this.R_Urine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Urine.Location = new System.Drawing.Point(342, 11);
            this.R_Urine.Name = "R_Urine";
            this.R_Urine.Size = new System.Drawing.Size(69, 17);
            this.R_Urine.TabIndex = 5;
            this.R_Urine.Text = "Urinalysis";
            this.R_Urine.UseVisualStyleBackColor = true;
            this.R_Urine.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.r_lab34);
            this.groupBox1.Controls.Add(this.R_Fecal);
            this.groupBox1.Controls.Add(this.R_Urine);
            this.groupBox1.Controls.Add(this.R_Chem);
            this.groupBox1.Controls.Add(this.R_Hema);
            this.groupBox1.Controls.Add(this.R_lab08);
            this.groupBox1.Controls.Add(this.R_lab06);
            this.groupBox1.Location = new System.Drawing.Point(2, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 34);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // r_lab34
            // 
            this.r_lab34.AutoSize = true;
            this.r_lab34.Checked = true;
            this.r_lab34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.r_lab34.Location = new System.Drawing.Point(476, 11);
            this.r_lab34.Name = "r_lab34";
            this.r_lab34.Size = new System.Drawing.Size(84, 17);
            this.r_lab34.TabIndex = 6;
            this.r_lab34.TabStop = true;
            this.r_lab34.Text = "Form Lab 34";
            this.r_lab34.UseVisualStyleBackColor = true;
            this.r_lab34.Visible = false;
            this.r_lab34.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(569, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 15;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(669, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 14;
            this.button2.Text = "Printer setup";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(775, 397);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 30);
            this.button4.TabIndex = 13;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.tabPage1);
            this.wizard1.Controls.Add(this.tabPage2);
            this.wizard1.Controls.Add(this.tabPage3);
            this.wizard1.Controls.Add(this.tabPage4);
            this.wizard1.Controls.Add(this.tabPage5);
            this.wizard1.Controls.Add(this.tabPage6);
            this.wizard1.Controls.Add(this.tab_lab34);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.SelectedIndex = 0;
            this.wizard1.Size = new System.Drawing.Size(878, 394);
            this.wizard1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Viewer_01);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Viewer_01
            // 
            this.Viewer_01.ActiveViewIndex = -1;
            this.Viewer_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer_01.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer_01.DisplayStatusBar = false;
            this.Viewer_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer_01.Location = new System.Drawing.Point(3, 3);
            this.Viewer_01.Name = "Viewer_01";
            this.Viewer_01.ShowCloseButton = false;
            this.Viewer_01.ShowLogo = false;
            this.Viewer_01.Size = new System.Drawing.Size(864, 362);
            this.Viewer_01.TabIndex = 0;
            this.Viewer_01.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Viewer_02);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Viewer_02
            // 
            this.Viewer_02.ActiveViewIndex = -1;
            this.Viewer_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer_02.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer_02.DisplayStatusBar = false;
            this.Viewer_02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer_02.Location = new System.Drawing.Point(3, 3);
            this.Viewer_02.Name = "Viewer_02";
            this.Viewer_02.ShowCloseButton = false;
            this.Viewer_02.ShowLogo = false;
            this.Viewer_02.Size = new System.Drawing.Size(864, 362);
            this.Viewer_02.TabIndex = 1;
            this.Viewer_02.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Viewer_03);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Viewer_03
            // 
            this.Viewer_03.ActiveViewIndex = -1;
            this.Viewer_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer_03.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer_03.DisplayStatusBar = false;
            this.Viewer_03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer_03.Location = new System.Drawing.Point(3, 3);
            this.Viewer_03.Name = "Viewer_03";
            this.Viewer_03.ShowCloseButton = false;
            this.Viewer_03.ShowLogo = false;
            this.Viewer_03.Size = new System.Drawing.Size(864, 362);
            this.Viewer_03.TabIndex = 1;
            this.Viewer_03.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Viewer_04);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(870, 368);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Viewer_04
            // 
            this.Viewer_04.ActiveViewIndex = -1;
            this.Viewer_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer_04.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer_04.DisplayStatusBar = false;
            this.Viewer_04.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer_04.Location = new System.Drawing.Point(3, 3);
            this.Viewer_04.Name = "Viewer_04";
            this.Viewer_04.ShowCloseButton = false;
            this.Viewer_04.ShowLogo = false;
            this.Viewer_04.Size = new System.Drawing.Size(864, 362);
            this.Viewer_04.TabIndex = 1;
            this.Viewer_04.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Viewer_05);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(870, 368);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Viewer_05
            // 
            this.Viewer_05.ActiveViewIndex = -1;
            this.Viewer_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer_05.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer_05.DisplayStatusBar = false;
            this.Viewer_05.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer_05.Location = new System.Drawing.Point(3, 3);
            this.Viewer_05.Name = "Viewer_05";
            this.Viewer_05.ShowCloseButton = false;
            this.Viewer_05.ShowLogo = false;
            this.Viewer_05.Size = new System.Drawing.Size(864, 362);
            this.Viewer_05.TabIndex = 1;
            this.Viewer_05.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Viewer_06);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(870, 368);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Viewer_06
            // 
            this.Viewer_06.ActiveViewIndex = -1;
            this.Viewer_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer_06.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer_06.DisplayStatusBar = false;
            this.Viewer_06.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer_06.Location = new System.Drawing.Point(3, 3);
            this.Viewer_06.Name = "Viewer_06";
            this.Viewer_06.ShowCloseButton = false;
            this.Viewer_06.ShowLogo = false;
            this.Viewer_06.Size = new System.Drawing.Size(864, 362);
            this.Viewer_06.TabIndex = 1;
            this.Viewer_06.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tab_lab34
            // 
            this.tab_lab34.Controls.Add(this.crystalReport_lab34);
            this.tab_lab34.Location = new System.Drawing.Point(4, 22);
            this.tab_lab34.Name = "tab_lab34";
            this.tab_lab34.Padding = new System.Windows.Forms.Padding(3);
            this.tab_lab34.Size = new System.Drawing.Size(870, 368);
            this.tab_lab34.TabIndex = 6;
            this.tab_lab34.Text = "lab34";
            this.tab_lab34.UseVisualStyleBackColor = true;
            // 
            // crystalReport_lab34
            // 
            this.crystalReport_lab34.ActiveViewIndex = -1;
            this.crystalReport_lab34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReport_lab34.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReport_lab34.DisplayStatusBar = false;
            this.crystalReport_lab34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReport_lab34.Location = new System.Drawing.Point(3, 3);
            this.crystalReport_lab34.Name = "crystalReport_lab34";
            this.crystalReport_lab34.ShowCloseButton = false;
            this.crystalReport_lab34.ShowLogo = false;
            this.crystalReport_lab34.Size = new System.Drawing.Size(864, 362);
            this.crystalReport_lab34.TabIndex = 2;
            this.crystalReport_lab34.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Report_Lab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 430);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.wizard1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(894, 464);
            this.MinimumSize = new System.Drawing.Size(894, 464);
            this.Name = "Report_Lab";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratory  Report Print-Out";
            this.Load += new System.EventHandler(this.Report_Lab_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Report_Lab_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wizard1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tab_lab34.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer_01;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer_02;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer_03;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer_04;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer_05;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer_06;
        private R_lab_08 R_lab_081;
        private R_HemaLab01 R_HemaLab011;
        private R_lab_06 R_lab_061;
        private R_Chemistry R_Chemistry1;
        private R_Urinalysis R_Urinalysis1;
        private R_Fecalysis R_Fecalysis1;
        public System.Windows.Forms.RadioButton R_Urine;
        public System.Windows.Forms.RadioButton R_Fecal;
        public System.Windows.Forms.RadioButton R_Chem;
        public System.Windows.Forms.RadioButton R_Hema;
        public System.Windows.Forms.RadioButton R_lab08;
        public System.Windows.Forms.RadioButton R_lab06;
        public Class.Wizard wizard1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TabPage tab_lab34;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReport_lab34;
        private R_chemistry_Form34 R_chemistry_Form341;
        public System.Windows.Forms.RadioButton r_lab34;
        //private R_Urinalysis R_Urinalysis1;
        //private R_Fecalysis R_Fecalysis1;
       // private R_hema R_hema1;
    }
}