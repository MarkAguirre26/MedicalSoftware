using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCam_Capture;
using WinFormCharpWebCam;

namespace Centerport
{
       



    public partial class frm_camera : Form
    {
       // private Drawing2D _interpolationMode;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        public string path = @"C:\Users\Mark\AppData\Roaming\tmp.jpg";

        public frm_camera()
        {
            InitializeComponent();
        }
        WebCam webcam;    
        private void frm_camera_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
            webcam.Start();

            if (File.Exists(path))
            {
                File.Delete(path);

            }

        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            //Check the state of the Left Mouse Button
            if ((long)m.Msg == BUTTON_DOWN_CODE)
                left_button_down = true;
            else if ((long)m.Msg == BUTTON_UP_CODE)
                left_button_down = false;

            if (left_button_down)
            {
                if ((long)m.Msg == WM_MOVING)
                {
                    //Set the forms opacity to 50% if user is moving
                    if (this.Opacity != 0.5)
                        this.Opacity = 0.5;
                }
            }

            else if (!left_button_down)
                if (this.Opacity != 1.0)
                    this.Opacity = 1.0;

            base.DefWndProc(ref m);
        }

        private void frm_camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                webcam.Stop();
                //imgCapture.Image.Dispose();
                //imgCapture.Image = null;


            }
            catch
            { }


           
        }

        public void RecursiveDelete(string path, string name)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                if (directory.EndsWith("\\" + name))
                {
                    Directory.Delete(directory, true);
                }
                else
                {
                    RecursiveDelete(directory, name);
                }
            }
        }

        private void cmd_capture_Click(object sender, EventArgs e)
        {

            imgCapture.Image = imgVideo.Image;
            imgVideo.Visible = false;
            imgCapture.Visible = true;
            cmd_reset.Enabled = true; cmd_save.Enabled = true; cmd_capture.Enabled = false;

            //if (File.Exists(path))
            //{
            //    if (imgCapture.Image != null)
            //    {
            //        imgCapture.Image.Dispose();
            //        imgCapture.Image = null;
            //        File.Delete(path);

            //    }
                                      

          
            //}
            //else
            //{
               
            //    using (Bitmap bmp =
            //       new Bitmap(imgCapture.ClientSize.Width, imgCapture.ClientSize.Height))
            //    {
            //        imgCapture.DrawToBitmap(bmp, imgCapture.ClientRectangle);
            //        bmp.Save(path);

            //        imgCapture.Image = Image.FromFile(path);

            //        imgCapture.Image = imgVideo.Image;
            //        imgVideo.Visible = false;
            //        imgCapture.Visible = true;
            //        cmd_reset.Enabled = true; cmd_save.Enabled = true; cmd_capture.Enabled = false;
            //    }
            //}



            

           

        }

        private void cmd_reset_Click(object sender, EventArgs e)
        {
            try
            {
               
                imgCapture.Image = null;
                imgVideo.Visible = true;
                imgCapture.Visible = false;
               
               

                cmd_reset.Enabled = false; cmd_save.Enabled = false; cmd_capture.Enabled = true;
            }
            catch
            { }

        }
       
     
        private void cmd_save_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["frm_addPatient"] != null)
            {
             //   (System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();
                frm_addPatient.img.Image = imgCapture.Image;     
            }
            else if (System.Windows.Forms.Application.OpenForms["frm_patientInfo"] != null)
            {
                frm_patientInfo.img.Image = imgCapture.Image;
            
            }

                   
          
            this.Close();
          
        }


        //void KillProcess(string path)
        //{
        //    Process[] runningProcesses = Process.GetProcesses();
        //    foreach (Process process in runningProcesses)
        //    {
        //        // now check the modules of the process
        //        foreach (ProcessModule module in process.Modules)
        //        {
        //            if (module.FileName.Equals(path))
        //            {
        //                process.Kill();
        //            }
        //        }
        //    }
        //}

        private void videoFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcam.ResolutionSetting();
        }

        private void videoSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }

        private void saveToDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.SaveImageCapture(imgCapture.Image);
        }

        private void imgCapture_MouseDown(object sender, MouseEventArgs e)
        {
        //    if (e.Button == MouseButtons.Left)//here i have use mouse click left button only
        //    {
        //        imgCapture.Refresh();
        //        cropX = e.X;
        //        cropY = e.Y;
        //        Cursor = Cursors.Cross;
        //    }
        //    imgCapture.Refresh();
        }

        private void imgCapture_MouseUp(object sender, MouseEventArgs e)
        {
   
        }
        

        private void imgCapture_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
      

        private void imgCapture_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_camera_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
        }
       
     


    }
}
