namespace Centerport
{
    partial class frm_camera
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
            this.cmd_capture = new System.Windows.Forms.Button();
            this.cmd_reset = new System.Windows.Forms.Button();
            this.cmd_save = new System.Windows.Forms.Button();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmd_capture
            // 
            this.cmd_capture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_capture.Location = new System.Drawing.Point(54, 277);
            this.cmd_capture.Name = "cmd_capture";
            this.cmd_capture.Size = new System.Drawing.Size(66, 23);
            this.cmd_capture.TabIndex = 1;
            this.cmd_capture.Text = "Capture";
            this.cmd_capture.UseVisualStyleBackColor = true;
            this.cmd_capture.Click += new System.EventHandler(this.cmd_capture_Click);
            // 
            // cmd_reset
            // 
            this.cmd_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_reset.Enabled = false;
            this.cmd_reset.Location = new System.Drawing.Point(120, 277);
            this.cmd_reset.Name = "cmd_reset";
            this.cmd_reset.Size = new System.Drawing.Size(66, 23);
            this.cmd_reset.TabIndex = 2;
            this.cmd_reset.Text = "Reset";
            this.cmd_reset.UseVisualStyleBackColor = true;
            this.cmd_reset.Click += new System.EventHandler(this.cmd_reset_Click);
            // 
            // cmd_save
            // 
            this.cmd_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_save.Enabled = false;
            this.cmd_save.Location = new System.Drawing.Point(186, 277);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(66, 23);
            this.cmd_save.TabIndex = 3;
            this.cmd_save.Text = "&OK";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // imgCapture
            // 
            this.imgCapture.Location = new System.Drawing.Point(0, 28);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(320, 240);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCapture.TabIndex = 4;
            this.imgCapture.TabStop = false;
            this.imgCapture.Visible = false;
            this.imgCapture.Paint += new System.Windows.Forms.PaintEventHandler(this.imgCapture_Paint);
            this.imgCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgCapture_MouseDown);
            this.imgCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgCapture_MouseMove);
            this.imgCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgCapture_MouseUp);
            // 
            // imgVideo
            // 
            this.imgVideo.Location = new System.Drawing.Point(0, 28);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(320, 240);
            this.imgVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgVideo.TabIndex = 0;
            this.imgVideo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(320, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoFormatToolStripMenuItem,
            this.videoSourceToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveToDiskToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.settingToolStripMenuItem.Text = "File";
            // 
            // videoFormatToolStripMenuItem
            // 
            this.videoFormatToolStripMenuItem.Name = "videoFormatToolStripMenuItem";
            this.videoFormatToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.videoFormatToolStripMenuItem.Text = "Video Format";
            this.videoFormatToolStripMenuItem.Click += new System.EventHandler(this.videoFormatToolStripMenuItem_Click);
            // 
            // videoSourceToolStripMenuItem
            // 
            this.videoSourceToolStripMenuItem.Name = "videoSourceToolStripMenuItem";
            this.videoSourceToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.videoSourceToolStripMenuItem.Text = "Video Source";
            this.videoSourceToolStripMenuItem.Click += new System.EventHandler(this.videoSourceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 6);
            // 
            // saveToDiskToolStripMenuItem
            // 
            this.saveToDiskToolStripMenuItem.Name = "saveToDiskToolStripMenuItem";
            this.saveToDiskToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveToDiskToolStripMenuItem.Text = "Save";
            this.saveToDiskToolStripMenuItem.Click += new System.EventHandler(this.saveToDiskToolStripMenuItem_Click);
            // 
            // frm_camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 308);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.cmd_reset);
            this.Controls.Add(this.cmd_capture);
            this.Controls.Add(this.imgVideo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.imgCapture);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_camera";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_camera_FormClosing);
            this.Load += new System.EventHandler(this.frm_camera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.Button cmd_capture;
        private System.Windows.Forms.Button cmd_reset;
        private System.Windows.Forms.Button cmd_save;
        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToDiskToolStripMenuItem;
    }
}