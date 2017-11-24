namespace Centerport
{
    partial class Report_SeaBase_Print
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.wizard1 = new Centerport.Class.Wizard();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Viewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Viewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Viewer3 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.Viewer4_1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Viewer4_2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker6 = new System.ComponentModel.BackgroundWorker();
            this.wizard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(775, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(669, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "Printer setup";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(569, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 9;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.tabPage1);
            this.wizard1.Controls.Add(this.tabPage2);
            this.wizard1.Controls.Add(this.tabPage3);
            this.wizard1.Controls.Add(this.tabPage4);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.SelectedIndex = 0;
            this.wizard1.Size = new System.Drawing.Size(878, 394);
            this.wizard1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.Viewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // Viewer1
            // 
            this.Viewer1.ActiveViewIndex = -1;
            this.Viewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer1.DisplayStatusBar = false;
            this.Viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer1.Location = new System.Drawing.Point(3, 3);
            this.Viewer1.Name = "Viewer1";
            this.Viewer1.ShowCloseButton = false;
            this.Viewer1.ShowLogo = false;
            this.Viewer1.Size = new System.Drawing.Size(864, 362);
            this.Viewer1.TabIndex = 0;
            this.Viewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.Viewer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // Viewer2
            // 
            this.Viewer2.ActiveViewIndex = -1;
            this.Viewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer2.DisplayStatusBar = false;
            this.Viewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer2.Location = new System.Drawing.Point(3, 3);
            this.Viewer2.Name = "Viewer2";
            this.Viewer2.ShowCloseButton = false;
            this.Viewer2.ShowLogo = false;
            this.Viewer2.Size = new System.Drawing.Size(864, 362);
            this.Viewer2.TabIndex = 1;
            this.Viewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.Viewer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // Viewer3
            // 
            this.Viewer3.ActiveViewIndex = -1;
            this.Viewer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer3.DisplayStatusBar = false;
            this.Viewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer3.Location = new System.Drawing.Point(3, 3);
            this.Viewer3.Name = "Viewer3";
            this.Viewer3.ShowCloseButton = false;
            this.Viewer3.ShowLogo = false;
            this.Viewer3.Size = new System.Drawing.Size(864, 362);
            this.Viewer3.TabIndex = 1;
            this.Viewer3.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.tabControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(870, 368);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 362);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.Viewer4_1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(856, 336);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Page 1";
            // 
            // Viewer4_1
            // 
            this.Viewer4_1.ActiveViewIndex = -1;
            this.Viewer4_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer4_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer4_1.DisplayStatusBar = false;
            this.Viewer4_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer4_1.Location = new System.Drawing.Point(3, 3);
            this.Viewer4_1.Name = "Viewer4_1";
            this.Viewer4_1.ShowCloseButton = false;
            this.Viewer4_1.ShowLogo = false;
            this.Viewer4_1.Size = new System.Drawing.Size(850, 330);
            this.Viewer4_1.TabIndex = 1;
            this.Viewer4_1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.Viewer4_2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(856, 336);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Page 2";
            // 
            // Viewer4_2
            // 
            this.Viewer4_2.ActiveViewIndex = -1;
            this.Viewer4_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer4_2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer4_2.DisplayStatusBar = false;
            this.Viewer4_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer4_2.Location = new System.Drawing.Point(3, 3);
            this.Viewer4_2.Name = "Viewer4_2";
            this.Viewer4_2.ShowCloseButton = false;
            this.Viewer4_2.ShowLogo = false;
            this.Viewer4_2.Size = new System.Drawing.Size(850, 330);
            this.Viewer4_2.TabIndex = 2;
            this.Viewer4_2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // backgroundWorker5
            // 
            this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker5_DoWork);
            // 
            // backgroundWorker6
            // 
            this.backgroundWorker6.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker6_DoWork);
            // 
            // Report_SeaBase_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 430);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wizard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(894, 464);
            this.MinimumSize = new System.Drawing.Size(894, 464);
            this.Name = "Report_SeaBase_Print";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seafare\'s Medical Examination Certificate Print-Out";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Report_SeaBase_Print_FormClosing);
            this.Load += new System.EventHandler(this.Report_SeaBase_Print_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Report_SeaBase_Print_KeyDown);
            this.wizard1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer4_1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TabPage tabPage2;
        public Class.Wizard wizard1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer4_2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
        private System.ComponentModel.BackgroundWorker backgroundWorker6;
        //private Centerport.Report.R_Seabase_MER R_Seabase_MER1;
        //private Report.R_SeabaseDetailed R_SeabaseDetailed1;
        //private Report.R_SeabaseDetailed R_SeabaseDetailed1;
        //private Report.R_Seabase_Summary R_Seabase_Summary1;
        //private Report.R_Seabase_Summary R_Seabase_Summary1;
    }
}