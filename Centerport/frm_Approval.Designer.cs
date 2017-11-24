namespace Centerport
{
    partial class frm_Approval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmd_retrieve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_retrieve = new System.Windows.Forms.DateTimePicker();
            this.dg_result = new System.Windows.Forms.DataGridView();
            this.cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.cmd_search = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmd_retrieve);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dt_retrieve);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 38);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cmd_retrieve
            // 
            this.cmd_retrieve.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_retrieve.Location = new System.Drawing.Point(228, 10);
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
            this.resultid,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Status});
            this.dg_result.Location = new System.Drawing.Point(11, 71);
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
            this.dg_result.TabIndex = 11;
            this.dg_result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_result_CellClick);
            this.dg_result.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_result_CellEndEdit);
            this.dg_result.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dg_result_DataError);
            this.dg_result.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dg_result_EditingControlShowing);
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
            // resultid
            // 
            this.resultid.HeaderText = "ResultId";
            this.resultid.Name = "resultid";
            this.resultid.ReadOnly = true;
            this.resultid.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Result Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Type of Exam";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
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
            this.Status.Items.AddRange(new object[] {
            "PENDING",
            "APPROVED",
            "ON-HOLD",
            "CANCELLED"});
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label2.Location = new System.Drawing.Point(11, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Search by Name:";
            // 
            // txt_search
            // 
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_search.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_search.Location = new System.Drawing.Point(126, 343);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(431, 22);
            this.txt_search.TabIndex = 16;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // cmd_search
            // 
            this.cmd_search.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_search.Location = new System.Drawing.Point(668, 342);
            this.cmd_search.Name = "cmd_search";
            this.cmd_search.Size = new System.Drawing.Size(78, 25);
            this.cmd_search.TabIndex = 17;
            this.cmd_search.Text = "Close";
            this.cmd_search.UseVisualStyleBackColor = true;
            this.cmd_search.Click += new System.EventHandler(this.cmd_search_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label46.Location = new System.Drawing.Point(11, 9);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(167, 22);
            this.label46.TabIndex = 16;
            this.label46.Text = "Results Approval";
            // 
            // frm_Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 372);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.cmd_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dg_result);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_Approval";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results Approval Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Approval_FormClosing);
            this.Load += new System.EventHandler(this.frm_Approval_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Approval_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_retrieve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_retrieve;
        private System.Windows.Forms.DataGridView dg_result;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button cmd_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
    }
}