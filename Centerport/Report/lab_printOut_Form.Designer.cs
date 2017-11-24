namespace Centerport.Report
{
    partial class lab_printOut_Form
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
            this.Fecal_sub1 = new Centerport.Report.Fecal_sub();
            this.Urine_sub1 = new Centerport.Report.Urine_sub();
            this.Chem_sub1 = new Centerport.Report.Chem_sub();
            this.Hema_Sub1 = new Centerport.Report.Hema_Sub();
            this.lab06_sub1 = new Centerport.Report.lab06_sub();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.r_lab34 = new System.Windows.Forms.RadioButton();
            this.R_Urine = new System.Windows.Forms.RadioButton();
            this.R_Fecal = new System.Windows.Forms.RadioButton();
            this.R_lab06 = new System.Windows.Forms.RadioButton();
            this.R_Chem = new System.Windows.Forms.RadioButton();
            this.R_lab08 = new System.Windows.Forms.RadioButton();
            this.R_Hema = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lab08_sub1 = new Centerport.Report.lab08_sub();
            this.wizard1 = new Centerport.Class.Wizard();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer4 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer5 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.crystalReportViewer6 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.viewer34 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lab34_sub1 = new Centerport.Report.lab34_sub();
            this.groupBox1.SuspendLayout();
            this.wizard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.r_lab34);
            this.groupBox1.Controls.Add(this.R_Urine);
            this.groupBox1.Controls.Add(this.R_Fecal);
            this.groupBox1.Controls.Add(this.R_lab06);
            this.groupBox1.Controls.Add(this.R_Chem);
            this.groupBox1.Controls.Add(this.R_lab08);
            this.groupBox1.Controls.Add(this.R_Hema);
            this.groupBox1.Location = new System.Drawing.Point(2, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 34);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // r_lab34
            // 
            this.r_lab34.AutoSize = true;
            this.r_lab34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.r_lab34.Location = new System.Drawing.Point(481, 11);
            this.r_lab34.Name = "r_lab34";
            this.r_lab34.Size = new System.Drawing.Size(84, 17);
            this.r_lab34.TabIndex = 6;
            this.r_lab34.TabStop = true;
            this.r_lab34.Text = "Form Lab 34";
            this.r_lab34.UseVisualStyleBackColor = true;
            this.r_lab34.Visible = false;
            this.r_lab34.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // R_Urine
            // 
            this.R_Urine.AutoSize = true;
            this.R_Urine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Urine.Location = new System.Drawing.Point(345, 11);
            this.R_Urine.Name = "R_Urine";
            this.R_Urine.Size = new System.Drawing.Size(69, 17);
            this.R_Urine.TabIndex = 5;
            this.R_Urine.TabStop = true;
            this.R_Urine.Text = "Urinalysis";
            this.R_Urine.UseVisualStyleBackColor = true;
            this.R_Urine.CheckedChanged += new System.EventHandler(this.R_Urine_CheckedChanged);
            // 
            // R_Fecal
            // 
            this.R_Fecal.AutoSize = true;
            this.R_Fecal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Fecal.Location = new System.Drawing.Point(414, 11);
            this.R_Fecal.Name = "R_Fecal";
            this.R_Fecal.Size = new System.Drawing.Size(68, 17);
            this.R_Fecal.TabIndex = 4;
            this.R_Fecal.TabStop = true;
            this.R_Fecal.Text = "Fecalysis";
            this.R_Fecal.UseVisualStyleBackColor = true;
            this.R_Fecal.CheckedChanged += new System.EventHandler(this.R_Fecal_CheckedChanged);
            // 
            // R_lab06
            // 
            this.R_lab06.AutoSize = true;
            this.R_lab06.Checked = true;
            this.R_lab06.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_lab06.Location = new System.Drawing.Point(7, 11);
            this.R_lab06.Name = "R_lab06";
            this.R_lab06.Size = new System.Drawing.Size(94, 17);
            this.R_lab06.TabIndex = 0;
            this.R_lab06.TabStop = true;
            this.R_lab06.Text = "FORM LAB-06";
            this.R_lab06.UseVisualStyleBackColor = true;
            this.R_lab06.CheckedChanged += new System.EventHandler(this.R_lab06_CheckedChanged);
            // 
            // R_Chem
            // 
            this.R_Chem.AutoSize = true;
            this.R_Chem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Chem.Location = new System.Drawing.Point(276, 11);
            this.R_Chem.Name = "R_Chem";
            this.R_Chem.Size = new System.Drawing.Size(70, 17);
            this.R_Chem.TabIndex = 3;
            this.R_Chem.TabStop = true;
            this.R_Chem.Text = "Chemistry";
            this.R_Chem.UseVisualStyleBackColor = true;
            this.R_Chem.CheckedChanged += new System.EventHandler(this.R_Chem_CheckedChanged);
            // 
            // R_lab08
            // 
            this.R_lab08.AutoSize = true;
            this.R_lab08.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_lab08.Location = new System.Drawing.Point(103, 11);
            this.R_lab08.Name = "R_lab08";
            this.R_lab08.Size = new System.Drawing.Size(94, 17);
            this.R_lab08.TabIndex = 1;
            this.R_lab08.TabStop = true;
            this.R_lab08.Text = "FORM LAB-08";
            this.R_lab08.UseVisualStyleBackColor = true;
            this.R_lab08.CheckedChanged += new System.EventHandler(this.R_lab08_CheckedChanged);
            // 
            // R_Hema
            // 
            this.R_Hema.AutoSize = true;
            this.R_Hema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.R_Hema.Location = new System.Drawing.Point(198, 11);
            this.R_Hema.Name = "R_Hema";
            this.R_Hema.Size = new System.Drawing.Size(81, 17);
            this.R_Hema.TabIndex = 2;
            this.R_Hema.TabStop = true;
            this.R_Hema.Text = "Hematology";
            this.R_Hema.UseVisualStyleBackColor = true;
            this.R_Hema.CheckedChanged += new System.EventHandler(this.R_Hema_CheckedChanged);
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.tabPage1);
            this.wizard1.Controls.Add(this.tabPage2);
            this.wizard1.Controls.Add(this.tabPage3);
            this.wizard1.Controls.Add(this.tabPage4);
            this.wizard1.Controls.Add(this.tabPage5);
            this.wizard1.Controls.Add(this.tabPage6);
            this.wizard1.Controls.Add(this.tabPage7);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.SelectedIndex = 0;
            this.wizard1.Size = new System.Drawing.Size(878, 394);
            this.wizard1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crystalReportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(864, 362);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crystalReportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.DisplayStatusBar = false;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.ShowCloseButton = false;
            this.crystalReportViewer2.ShowLogo = false;
            this.crystalReportViewer2.Size = new System.Drawing.Size(864, 362);
            this.crystalReportViewer2.TabIndex = 1;
            this.crystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crystalReportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.DisplayStatusBar = false;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.ShowCloseButton = false;
            this.crystalReportViewer3.ShowLogo = false;
            this.crystalReportViewer3.Size = new System.Drawing.Size(864, 362);
            this.crystalReportViewer3.TabIndex = 1;
            this.crystalReportViewer3.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.crystalReportViewer4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(870, 368);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer4
            // 
            this.crystalReportViewer4.ActiveViewIndex = -1;
            this.crystalReportViewer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer4.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer4.DisplayStatusBar = false;
            this.crystalReportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer4.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer4.Name = "crystalReportViewer4";
            this.crystalReportViewer4.ShowCloseButton = false;
            this.crystalReportViewer4.ShowLogo = false;
            this.crystalReportViewer4.Size = new System.Drawing.Size(864, 362);
            this.crystalReportViewer4.TabIndex = 1;
            this.crystalReportViewer4.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.crystalReportViewer5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(870, 368);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer5
            // 
            this.crystalReportViewer5.ActiveViewIndex = -1;
            this.crystalReportViewer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer5.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer5.DisplayStatusBar = false;
            this.crystalReportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer5.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer5.Name = "crystalReportViewer5";
            this.crystalReportViewer5.ShowCloseButton = false;
            this.crystalReportViewer5.ShowLogo = false;
            this.crystalReportViewer5.Size = new System.Drawing.Size(864, 362);
            this.crystalReportViewer5.TabIndex = 1;
            this.crystalReportViewer5.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.crystalReportViewer6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(870, 368);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer6
            // 
            this.crystalReportViewer6.ActiveViewIndex = -1;
            this.crystalReportViewer6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer6.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer6.DisplayStatusBar = false;
            this.crystalReportViewer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer6.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer6.Name = "crystalReportViewer6";
            this.crystalReportViewer6.ShowCloseButton = false;
            this.crystalReportViewer6.ShowLogo = false;
            this.crystalReportViewer6.Size = new System.Drawing.Size(864, 362);
            this.crystalReportViewer6.TabIndex = 1;
            this.crystalReportViewer6.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.viewer34);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(870, 368);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // viewer34
            // 
            this.viewer34.ActiveViewIndex = -1;
            this.viewer34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer34.Cursor = System.Windows.Forms.Cursors.Default;
            this.viewer34.DisplayStatusBar = false;
            this.viewer34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer34.Location = new System.Drawing.Point(3, 3);
            this.viewer34.Name = "viewer34";
            this.viewer34.ShowCloseButton = false;
            this.viewer34.ShowLogo = false;
            this.viewer34.Size = new System.Drawing.Size(864, 362);
            this.viewer34.TabIndex = 2;
            this.viewer34.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(569, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 18;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(669, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 17;
            this.button2.Text = "Printer setup";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(775, 397);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 30);
            this.button4.TabIndex = 16;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lab_printOut_Form
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
            this.Name = "lab_printOut_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laboratory  Report Print-Out";
            this.Load += new System.EventHandler(this.lab_printOut_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wizard1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer6;
        public System.Windows.Forms.TabPage tabPage6;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer5;
        public System.Windows.Forms.TabPage tabPage5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer4;
        public System.Windows.Forms.TabPage tabPage4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer3;
        public System.Windows.Forms.TabPage tabPage3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        public System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        public System.Windows.Forms.TabPage tabPage1;
        public Class.Wizard wizard1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton R_Urine;
        public System.Windows.Forms.RadioButton R_Fecal;
        public System.Windows.Forms.RadioButton R_lab06;
        public System.Windows.Forms.RadioButton R_Chem;
        public System.Windows.Forms.RadioButton R_lab08;
        public System.Windows.Forms.RadioButton R_Hema;
        private System.Windows.Forms.ToolTip toolTip1;
        private lab06_sub lab06_sub1;
        private Fecal_sub Fecal_sub1;
        private Urine_sub Urine_sub1;
        private Chem_sub Chem_sub1;
        private Hema_Sub Hema_Sub1;
        private lab08_sub lab08_sub1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.RadioButton r_lab34;
        private System.Windows.Forms.TabPage tabPage7;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer34;
        private lab34_sub lab34_sub1;
    }
}