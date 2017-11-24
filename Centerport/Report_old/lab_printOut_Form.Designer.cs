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
            this.button1 = new System.Windows.Forms.Button();
            this.Fecal_sub1 = new Centerport.Report.Fecal_sub();
            this.Urine_sub1 = new Centerport.Report.Urine_sub();
            this.Chem_sub1 = new Centerport.Report.Chem_sub();
            this.Hema_Sub1 = new Centerport.Report.Hema_Sub();
            this.lab06_sub1 = new Centerport.Report.lab06_sub();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.wizard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(798, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.R_Urine);
            this.groupBox1.Controls.Add(this.R_Fecal);
            this.groupBox1.Controls.Add(this.R_lab06);
            this.groupBox1.Controls.Add(this.R_Chem);
            this.groupBox1.Controls.Add(this.R_lab08);
            this.groupBox1.Controls.Add(this.R_Hema);
            this.groupBox1.Location = new System.Drawing.Point(18, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 34);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // R_Urine
            // 
            this.R_Urine.AutoSize = true;
            this.R_Urine.Location = new System.Drawing.Point(366, 11);
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
            this.R_Fecal.Location = new System.Drawing.Point(440, 11);
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
            this.R_Chem.Location = new System.Drawing.Point(291, 11);
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
            this.R_lab08.Location = new System.Drawing.Point(106, 11);
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
            this.R_Hema.Location = new System.Drawing.Point(205, 11);
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
            this.wizard1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.wizard1.Controls.Add(this.tabPage1);
            this.wizard1.Controls.Add(this.tabPage2);
            this.wizard1.Controls.Add(this.tabPage3);
            this.wizard1.Controls.Add(this.tabPage4);
            this.wizard1.Controls.Add(this.tabPage5);
            this.wizard1.Controls.Add(this.tabPage6);
            this.wizard1.Location = new System.Drawing.Point(2, 33);
            this.wizard1.Name = "wizard1";
            this.wizard1.SelectedIndex = 0;
            this.wizard1.Size = new System.Drawing.Size(875, 495);
            this.wizard1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crystalReportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(867, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(861, 463);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crystalReportViewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(867, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.ShowCloseButton = false;
            this.crystalReportViewer2.ShowLogo = false;
            this.crystalReportViewer2.Size = new System.Drawing.Size(861, 463);
            this.crystalReportViewer2.TabIndex = 1;
            this.crystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crystalReportViewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(867, 469);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer3
            // 
            this.crystalReportViewer3.ActiveViewIndex = -1;
            this.crystalReportViewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer3.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer3.Name = "crystalReportViewer3";
            this.crystalReportViewer3.ShowCloseButton = false;
            this.crystalReportViewer3.ShowLogo = false;
            this.crystalReportViewer3.Size = new System.Drawing.Size(861, 463);
            this.crystalReportViewer3.TabIndex = 1;
            this.crystalReportViewer3.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.crystalReportViewer4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(867, 469);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer4
            // 
            this.crystalReportViewer4.ActiveViewIndex = -1;
            this.crystalReportViewer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer4.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer4.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer4.Name = "crystalReportViewer4";
            this.crystalReportViewer4.ShowCloseButton = false;
            this.crystalReportViewer4.ShowLogo = false;
            this.crystalReportViewer4.Size = new System.Drawing.Size(861, 463);
            this.crystalReportViewer4.TabIndex = 1;
            this.crystalReportViewer4.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.crystalReportViewer5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(867, 469);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer5
            // 
            this.crystalReportViewer5.ActiveViewIndex = -1;
            this.crystalReportViewer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer5.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer5.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer5.Name = "crystalReportViewer5";
            this.crystalReportViewer5.ShowCloseButton = false;
            this.crystalReportViewer5.ShowLogo = false;
            this.crystalReportViewer5.Size = new System.Drawing.Size(861, 463);
            this.crystalReportViewer5.TabIndex = 1;
            this.crystalReportViewer5.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.crystalReportViewer6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(867, 469);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // crystalReportViewer6
            // 
            this.crystalReportViewer6.ActiveViewIndex = -1;
            this.crystalReportViewer6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer6.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer6.Location = new System.Drawing.Point(3, 3);
            this.crystalReportViewer6.Name = "crystalReportViewer6";
            this.crystalReportViewer6.ShowCloseButton = false;
            this.crystalReportViewer6.ShowLogo = false;
            this.crystalReportViewer6.Size = new System.Drawing.Size(861, 463);
            this.crystalReportViewer6.TabIndex = 1;
            this.crystalReportViewer6.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // lab_printOut_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 527);
            this.Controls.Add(this.button1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
    }
}