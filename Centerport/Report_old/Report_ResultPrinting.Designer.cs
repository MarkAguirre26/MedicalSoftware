namespace Centerport.Report
{
    partial class Report_ResultPrinting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmd_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.dg_result = new System.Windows.Forms.DataGridView();
            this.cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmd_retrieve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_retrieve = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.cmd_print = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dg_result)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmd_cancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_cancel.Location = new System.Drawing.Point(668, 356);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.Size = new System.Drawing.Size(78, 25);
            this.cmd_cancel.TabIndex = 24;
            this.cmd_cancel.Text = "Close";
            this.toolTip1.SetToolTip(this.cmd_cancel, "Close");
            this.cmd_cancel.UseVisualStyleBackColor = true;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Search by Name:";
            // 
            // txt_search
            // 
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_search.Location = new System.Drawing.Point(128, 357);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(383, 22);
            this.txt_search.TabIndex = 23;
            this.toolTip1.SetToolTip(this.txt_search, "Search by: Lastname, Firstname Middle Name");
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // dg_result
            // 
            this.dg_result.AllowUserToAddRows = false;
            this.dg_result.AllowUserToDeleteRows = false;
            this.dg_result.AllowUserToResizeColumns = false;
            this.dg_result.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dg_result.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_result.BackgroundColor = System.Drawing.Color.White;
            this.dg_result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_result.ColumnHeadersHeight = 28;
            this.dg_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cn,
            this.result_id,
            this.Column1,
            this.Result_Type,
            this.Column3,
            this.Status});
            this.dg_result.Location = new System.Drawing.Point(11, 84);
            this.dg_result.Name = "dg_result";
            this.dg_result.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_result.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_result.RowHeadersVisible = false;
            this.dg_result.RowHeadersWidth = 45;
            this.dg_result.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_result.Size = new System.Drawing.Size(735, 259);
            this.dg_result.TabIndex = 19;
            this.dg_result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_result_CellClick);
            // 
            // cn
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cn.HeaderText = "cn";
            this.cn.Name = "cn";
            this.cn.ReadOnly = true;
            this.cn.Visible = false;
            // 
            // result_id
            // 
            this.result_id.HeaderText = "ResultId";
            this.result_id.Name = "result_id";
            this.result_id.ReadOnly = true;
            this.result_id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Result Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Result_Type
            // 
            this.Result_Type.HeaderText = "Type of Exam";
            this.Result_Type.Name = "Result_Type";
            this.Result_Type.ReadOnly = true;
            this.Result_Type.Width = 150;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Patient\'s Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.Width = 150;
            // 
            // cmd_retrieve
            // 
            this.cmd_retrieve.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_retrieve.Location = new System.Drawing.Point(228, 9);
            this.cmd_retrieve.Name = "cmd_retrieve";
            this.cmd_retrieve.Size = new System.Drawing.Size(75, 25);
            this.cmd_retrieve.TabIndex = 2;
            this.cmd_retrieve.Text = "Retrieve";
            this.cmd_retrieve.UseVisualStyleBackColor = true;
            this.cmd_retrieve.Click += new System.EventHandler(this.cmd_retrieve_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Retrieve Date:";
            // 
            // dt_retrieve
            // 
            this.dt_retrieve.CustomFormat = "yyyy-MM-dd";
            this.dt_retrieve.Font = new System.Drawing.Font("Arial", 11.25F);
            this.dt_retrieve.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_retrieve.Location = new System.Drawing.Point(105, 10);
            this.dt_retrieve.Name = "dt_retrieve";
            this.dt_retrieve.ShowUpDown = true;
            this.dt_retrieve.Size = new System.Drawing.Size(117, 25);
            this.dt_retrieve.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmd_retrieve);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dt_retrieve);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 38);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.BackgroundImage = global::Centerport.Properties.Resources.medic;
            this.panel2.Controls.Add(this.label46);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 42);
            this.panel2.TabIndex = 20;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(6, 10);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(175, 22);
            this.label46.TabIndex = 16;
            this.label46.Text = "Results Releasing";
            // 
            // cmd_print
            // 
            this.cmd_print.Enabled = false;
            this.cmd_print.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_print.Location = new System.Drawing.Point(671, 51);
            this.cmd_print.Name = "cmd_print";
            this.cmd_print.Size = new System.Drawing.Size(75, 25);
            this.cmd_print.TabIndex = 3;
            this.cmd_print.Text = "Print";
            this.cmd_print.UseVisualStyleBackColor = true;
            this.cmd_print.Click += new System.EventHandler(this.cmd_print_Click);
            // 
            // Report_ResultPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmd_cancel;
            this.ClientSize = new System.Drawing.Size(758, 393);
            this.Controls.Add(this.cmd_print);
            this.Controls.Add(this.cmd_cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dg_result);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(774, 431);
            this.MinimumSize = new System.Drawing.Size(774, 431);
            this.Name = "Report_ResultPrinting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results Releasing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Report_ResultPrinting_FormClosing);
            this.Load += new System.EventHandler(this.Report_ResultPrinting_Load);
            this.ResizeEnd += new System.EventHandler(this.Report_ResultPrinting_ResizeEnd);
            this.Move += new System.EventHandler(this.Report_ResultPrinting_Move);
            ((System.ComponentModel.ISupportInitialize)(this.dg_result)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.DataGridView dg_result;
        private System.Windows.Forms.Button cmd_retrieve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_retrieve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_print;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn result_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}