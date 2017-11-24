namespace Centerport
{
    partial class frm_VisitDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_type = new System.Windows.Forms.ComboBox();
            this.txt_transdate = new System.Windows.Forms.TextBox();
            this.txt_tracking = new System.Windows.Forms.TextBox();
            this.cmd_ok = new System.Windows.Forms.Button();
            this.cmd_cancel = new System.Windows.Forms.Button();
            this.txt_purpose = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Purpose of Visit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trans Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tracking No.";
            // 
            // cbo_type
            // 
            this.cbo_type.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_type.FormattingEnabled = true;
            this.cbo_type.Items.AddRange(new object[] {
            "BNI",
            "BMA",
            "OPD"});
            this.cbo_type.Location = new System.Drawing.Point(124, 17);
            this.cbo_type.Name = "cbo_type";
            this.cbo_type.Size = new System.Drawing.Size(111, 23);
            this.cbo_type.TabIndex = 1;
            // 
            // txt_transdate
            // 
            this.txt_transdate.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_transdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_transdate.Font = new System.Drawing.Font("Arial", 10F);
            this.txt_transdate.Location = new System.Drawing.Point(317, 17);
            this.txt_transdate.Name = "txt_transdate";
            this.txt_transdate.Size = new System.Drawing.Size(136, 23);
            this.txt_transdate.TabIndex = 5;
            // 
            // txt_tracking
            // 
            this.txt_tracking.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_tracking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tracking.Font = new System.Drawing.Font("Arial", 10F);
            this.txt_tracking.Location = new System.Drawing.Point(542, 17);
            this.txt_tracking.Name = "txt_tracking";
            this.txt_tracking.Size = new System.Drawing.Size(162, 23);
            this.txt_tracking.TabIndex = 6;
            // 
            // cmd_ok
            // 
            this.cmd_ok.Location = new System.Drawing.Point(280, 127);
            this.cmd_ok.Name = "cmd_ok";
            this.cmd_ok.Size = new System.Drawing.Size(75, 25);
            this.cmd_ok.TabIndex = 3;
            this.cmd_ok.Text = "&OK";
            this.cmd_ok.UseVisualStyleBackColor = true;
            this.cmd_ok.Click += new System.EventHandler(this.cmd_ok_Click);
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmd_cancel.Location = new System.Drawing.Point(361, 127);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.Size = new System.Drawing.Size(75, 25);
            this.cmd_cancel.TabIndex = 4;
            this.cmd_cancel.Text = "&Cancel";
            this.cmd_cancel.UseVisualStyleBackColor = true;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_cancel_Click);
            // 
            // txt_purpose
            // 
            this.txt_purpose.Location = new System.Drawing.Point(124, 49);
            this.txt_purpose.Name = "txt_purpose";
            this.txt_purpose.Size = new System.Drawing.Size(580, 69);
            this.txt_purpose.TabIndex = 2;
            this.txt_purpose.Text = "";
            // 
            // frm_VisitDetail
            // 
            this.AcceptButton = this.cmd_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmd_cancel;
            this.ClientSize = new System.Drawing.Size(716, 157);
            this.ControlBox = false;
            this.Controls.Add(this.txt_purpose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmd_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmd_ok);
            this.Controls.Add(this.txt_tracking);
            this.Controls.Add(this.cbo_type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_transdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_VisitDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Visit Details";
            this.Load += new System.EventHandler(this.frm_VisitDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_type;
        private System.Windows.Forms.TextBox txt_transdate;
        private System.Windows.Forms.TextBox txt_tracking;
        private System.Windows.Forms.Button cmd_ok;
        private System.Windows.Forms.Button cmd_cancel;
        private System.Windows.Forms.RichTextBox txt_purpose;
    }
}