using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Deployment.Application;
using System.Reflection;
using Ini;
using System.Diagnostics;
using System.Threading;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using Centerport.Class;



namespace Centerport
{


    public partial class Main : Form
    {
        private string path; private string datelastaccess;
        public static bool Releasing = true;
        public bool f_PatientInfo = true;
        public static bool f_visit = true;
        public bool laboratory = true;
        public bool landbase = true;
        public bool bseaferer = true;
        public bool MedCertificate = true;
        public bool Ultrasount = true;
        public bool Xray = true;
        public bool HIV = true;
        public bool Evaulation = true;
        public bool Approval = true;
        public bool Tumor = true;

        public int PatientPageCount;
        public int PatientTotalCount;
        public static bool FormPrint = true;
        //public string DefaultPass
        public static ToolStrip Strip_visit_;
        public static ToolStrip Strip_Profile_;
        public static ToolStrip Strip_Lab_;

        public static ToolStripButton tb_visit_add; public static ToolStripButton tb_visit_Print;
        public static ToolStripButton tb_add_profil; public static ToolStripButton tb_edit_profile; public static ToolStripButton tb_del_profile; public static ToolStripButton tb_Save_profile; public static ToolStripButton tb_Cancel_profile; public static ToolStripButton tb_Search_profile; public static ToolStripButton tb_Print_profile; public static ToolStripButton tb_Close_profile; public static ToolStripButton tb_Exit_profile;

        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        public bool isfromLogin;
        public int UserLevel;
        public int UserCn;
        public Main()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {



            this.Text = Properties.Settings.Default.SystemName + Tool.version;
            Cursor.Current = Cursors.WaitCursor;
            Tool.PrinterPath();
            //OpenConnection();
            new frm_login(this).ShowDialog();

            
        }

        private void overseasLandBasedWorkersMedicalCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLandBase();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            VisitQueue();



        }


        void VisitQueue()
        {
            if (f_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                f_visit = false;
                frm_visit fVisit = new frm_visit(this);
                fVisit.MdiParent = this;
                fVisit.Show();
            }
            else
            {
                (Application.OpenForms["frm_visit"] as frm_visit).BringToFront();
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        public void CountTotalPatient()
        {
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            PatientTotalCount = (from m in db.view_patients select new { m.cn }).Count();
            PatientPageCount = 2;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CountTotalPatient();
            PatientProfile();

        }
        void PatientProfile()
        {
            if (f_PatientInfo)
            {
                f_PatientInfo = false;
                Cursor.Current = Cursors.WaitCursor;

                frm_patientInfo p_info = new frm_patientInfo(this);
                p_info.Opacity = 0;
                p_info.MdiParent = this;
                //p_info.Search_JumpRecord();
                p_info.Show();

                // frm_patientInfo.OrderBy = "DESC";
                //(Application.OpenForms["frm_patientInfo"] as frm_patientInfo).Search_JumpRecord();


            }
            else
            {
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             //   return;
                (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).BringToFront();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            ShowLaboratory();

        }
        void ShowLabExtra()
        {

            if (Tumor)
            {
                Cursor.Current = Cursors.WaitCursor;
                Tumor = false;
                Cursor.Current = Cursors.WaitCursor;
                frm_Tumor_Immunological lab = new frm_Tumor_Immunological(this);
                lab.MdiParent = this;
                lab.Show();
            }
            else
            {
                MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        void ShowLaboratory()
        {
            if (laboratory)
            {
                Cursor.Current = Cursors.WaitCursor;
                laboratory = false;
                Cursor.Current = Cursors.WaitCursor;
                frm_lab lab = new frm_lab(this);
                lab.MdiParent = this;
                lab.Show();
            }
            else
            {
                (Application.OpenForms["frm_lab"] as frm_lab).BringToFront();
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return;
            }
        }
        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {



            ShowLandBase();


        }

        void ShowLandBase()
        {
            if (landbase)
            {
                Cursor.Current = Cursors.WaitCursor;
                landbase = false;
                //   Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                frm_Landbase flandbase = new frm_Landbase(this);
                flandbase.MdiParent = this;
                flandbase.Show();
            }
            else
            {
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).BringToFront();

               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  return;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            showSeabase();

        }
        void showSeabase()
        {
            if (bseaferer)
            {
                bseaferer = false;
                //   Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                Cursor.Current = Cursors.WaitCursor;
                frm_seafarer_MEC seaferer = new frm_seafarer_MEC(this);
                seaferer.MdiParent = this;
                seaferer.Show();

            }
            else
            {
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return;
                (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).BringToFront();
            }
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            ShowMLC();
        }

        void ShowMLC()
        {
            if (MedCertificate)
            {
                MedCertificate = false;
                Cursor.Current = Cursors.WaitCursor;
                // Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                frm_Seafarer_MLC med = new frm_Seafarer_MLC(this);
                med.MdiParent = this;
                med.Show();
            }
            else
            {
                (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).BringToFront();
                
                // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            showUltrasound();
        }

        void showUltrasound()
        {
            if (Ultrasount)
            {
                Ultrasount = false;
                Cursor.Current = Cursors.WaitCursor;
                // Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                frm_Ultrasound ultras = new frm_Ultrasound(this);
                ultras.MdiParent = this;
                ultras.Show();
            }
            else
            {
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return;
                (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).BringToFront();
            }
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ShowXray();
        }

        void ShowXray()
        {
            if (Xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                Xray = false;
                // Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                frm_xray f_xray = new frm_xray(this);
                f_xray.MdiParent = this;
                f_xray.Show();
            }
            else
            {
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  return;
                (Application.OpenForms["frm_xray"] as frm_xray).BringToFront();
            }
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            showHIV();
        }

        void showHIV()
        {
            if (HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                HIV = false;
                //  Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                frm_HIV f_HIV = new frm_HIV(this);
                f_HIV.MdiParent = this;
                f_HIV.Show();
            }
            else
            {
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return;
                (Application.OpenForms["frm_HIV"] as frm_HIV).BringToFront();
            }
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            showPyschoEval();
        }

        void showPyschoEval()
        {
            if (Evaulation)
            {
                Cursor.Current = Cursors.WaitCursor;
                Evaulation = false;
                //Strip_sub.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                frm_Psych_Evaluation f_Psych = new frm_Psych_Evaluation(this);
                f_Psych.MdiParent = this;
                f_Psych.Show();
            }
            else
            {
               // MessageBox.Show("Form already opened!", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // return;
                (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).BringToFront();
            }
        }

        public void NewPatient()
        {
            MessageBox.Show("Add");
        }

        //private void ts_add_Click(object sender, EventArgs e)
        //{
        //    if (!f_PatientInfo)
        //    {
        //        ts_add.Enabled = false;
        //        ts_edit.Enabled = false;
        //        ts_save.Enabled = true;
        //        ts_cancel.Enabled = true;
        //        ts_closewindow.Enabled = true;
        //        ts_exit.Enabled = true;
        //        NewPatient();
        //    }

        //}

        //private void ts_cancel_Click(object sender, EventArgs e)
        //{
        //    if (!f_PatientInfo)
        //    {
        //        ts_add.Enabled = true;
        //        ts_edit.Enabled = true;
        //        ts_save.Enabled = false;
        //        ts_cancel.Enabled = false;
        //        ts_closewindow.Enabled = true;
        //        ts_exit.Enabled = true;
        //        ts_search.Enabled = true;
        //    }



        //}

        //private void ts_edit_Click(object sender, EventArgs e)
        //{
        //    if (!f_PatientInfo)
        //    {
        //        ts_add.Enabled = false;
        //        ts_edit.Enabled = false;
        //        ts_save.Enabled = true;
        //        ts_cancel.Enabled = true;
        //        ts_closewindow.Enabled = true;
        //        ts_exit.Enabled = true;
        //        ts_search.Enabled = false;
        //    }
        //}

        //private void ts_save_Click(object sender, EventArgs e)
        //{
        //    if (!f_PatientInfo)
        //    {
        //        ts_add.Enabled = true;
        //        ts_edit.Enabled = true;
        //        ts_save.Enabled = false;
        //        ts_cancel.Enabled = false;
        //        ts_search.Enabled = true;
        //        ts_closewindow.Enabled = true;
        //        ts_exit.Enabled = true;

        //    }

        //}

        private void ts_search_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {


        }

        private void ts_add_Click(object sender, EventArgs e)
        {






        }

        private void ts_edit_Click(object sender, EventArgs e)
        {

        }

        private void ts_cancel_Click(object sender, EventArgs e)
        {

        }

        private void ts_search_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click_1(object sender, EventArgs e)
        {

        }



        private void ts_print_visit_Click(object sender, EventArgs e)
        {

        }

        private void ts_closewindow_visit_Click(object sender, EventArgs e)
        {

        }

        private void ts_search_Profile_Click(object sender, EventArgs e)
        {



        }

        private void ts_cancel_Profile_Click(object sender, EventArgs e)
        {




        }



        private void ts_edit_Profile_Click(object sender, EventArgs e)
        {

        }

        private void ts_save_Profile_Click(object sender, EventArgs e)
        {








        }

        private void ts_delete_Profile_Click(object sender, EventArgs e)
        {

        }
        public void add_Seabase()
        {
            Cursor.Current = Cursors.WaitCursor;
            ////((MyInter)this.ActiveMdiChild).New();
            //frm_search_Patient_Queuing f_que = new frm_search_Patient_Queuing(this);
            //f_que.seafarer = true;
            //f_que.ShowDialog();
            frm_seafarer_MEC.NewSeabase = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).SeabaseAdd_model;
            queue.Landbase = false;
            queue.lab = false;
            queue.queue = false;
            queue.seafarer = true;
            queue.tumor = false;
            queue.mlc = false;
            queue.xray = false;
            queue.ultraS = false;
            queue.hiv = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();

        }
        private void ts_add_sea_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                add_Seabase();

            }




        }
        public void Search_seabase()
        {
            Cursor.Current = Cursors.WaitCursor;
            //  ((MyInter)this.ActiveMdiChild).Search();
            frm_seafarer_MEC.NewSeabase = false;
            frm_search_SeaBase frm_search = new frm_search_SeaBase(this);
            frm_search.ShowDialog();

        }
        private void ts_search_sea_Click(object sender, EventArgs e)
        {



            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {

                Search_seabase();
            }




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_visit)
            {
                Strip_Visit.Visible = true;
                strip_Tumor.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;
            }
            else if (this.ActiveMdiChild is frm_patientInfo)
            {
                Strip_Visit.Visible = false;
                strip_Tumor.Visible = false;
                strip_profil.Visible = true;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;

            }
            else if (this.ActiveMdiChild is frm_lab)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = true;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;
            }
            else if (this.ActiveMdiChild is frm_Landbase)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = true;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;
            }
            else if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = true;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;
            }
            else if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = true;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;

            }
            else if (this.ActiveMdiChild is frm_Ultrasound)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = true;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;

            }
            else if (this.ActiveMdiChild is frm_xray)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = true;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;

            }
            else if (this.ActiveMdiChild is frm_HIV)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = true;
                strip_Psy_eval.Visible = false;

            }
            else if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = true;

            }
            else if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                strip_Tumor.Visible = true;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;

            }
            else
            {
                strip_Tumor.Visible = false;
                Strip_Visit.Visible = false;
                strip_profil.Visible = false;
                Strip_lab.Visible = false;
                Strip_Land.Visible = false;
                Strip_Sea.Visible = false;
                Strip_Seafarer_MLC.Visible = false;
                Strip_Ultra.Visible = false;
                Strip_Xray.Visible = false;
                Strip_hiv.Visible = false;
                strip_Psy_eval.Visible = false;
            }
        }
        public void add_Visit()
        {

            if (UserLevel == 1 || UserLevel == 2 || UserLevel == 4)
            {

                Cursor.Current = Cursors.WaitCursor;
                frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
                queue.queueSearchList_Model = (Application.OpenForms["frm_visit"] as frm_visit).Visit_Add_model;
                queue.queue = true;
                queue.Landbase = false;
                queue.lab = false;
                queue.seafarer = false;
                queue.mlc = false;
                queue.xray = false;
                queue.ultraS = false;
                queue.hiv = false;
                queue.isfromVisit = true;
                queue.Psych_Evaluation = false;
                queue.ShowDialog();

            }
            else
            {
                if (MessageBox.Show("You do not have enough access privileges for this operation, Please use RELEASING account. \n Would you like to continue?", "Action Denied!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) 
                {
                    new frm_login(this).ShowDialog();
                }
               

            }

          
        }
        private void ts_add_visit_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_visit)
            {
                add_Visit();

            }
        }

        private void toolStripButton11_Click_2(object sender, EventArgs e)
        {


            if (this.ActiveMdiChild is frm_patientInfo)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).New();

            }

        }

        private void ts_edit_visit_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();

            }
        }

        private void ts_delete_visit_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();

            }
        }

        private void ts_save_visit_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();

            }
        }

        private void ts_cancel_visit_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();

            }
        }

        private void ts_search_visit_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Search();

            }
        }

        private void ts_print_visit_Click_1(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_visit)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();

            }
        }

        private void ts_edit_sea_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();

            }
        }

        private void ts_delete_sea_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();

            }
        }

        private void ts_save_sea_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();

            }
        }

        private void ts_cancel_sea_Click(object sender, EventArgs e)
        {

            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();

            }
        }

        private void ts_print_sea_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_seafarer_MEC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();

            }
        }

        private void ts_cancel_profile_Click_1(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_patientInfo)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();
                //   frm_patientInfo.OrderBy = "DESC";
                (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).loadPatient_ByPage(PatientPageCount);
            }
        }

        private void ts_edit_profile_Click_1(object sender, EventArgs e)
        {

        }

        private void ts_del_profile_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_patientInfo)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();

            }
        }

        private void ts_save_profile_Click_1(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_patientInfo)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        public void Search_Profile()
        {

            Cursor.Current = Cursors.WaitCursor;
            frm_patientInfo.NewPatient = false;
            frm_search_Patient plist = new frm_search_Patient(this);
            plist.ShowDialog();
        }
        private void ts_search_profile_Click_1(object sender, EventArgs e)
        {
            // List<PatientSearchList_Model> patientSearchList_= new List<PatientSearchList_Model>();
            //  patientSearchList_ = (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).patientSearchList_Model;
            if (this.ActiveMdiChild is frm_patientInfo)
            {

                Search_Profile();
            }
        }

        private void ts_print_profile_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_patientInfo)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();

            }
        }


        public void Add_lab()
        {

            Cursor.Current = Cursors.WaitCursor;
            frm_lab.newlab = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_lab"] as frm_lab).QueueSearchList_Model;
            queue.lab = true;
            queue.Landbase = false;
            queue.queue = false;
            queue.seafarer = false;
            queue.mlc = false;
            queue.xray = false;
            queue.ultraS = false;
            queue.hiv = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();
        }
        private void ts_add_lab_Click(object sender, EventArgs e)
        {

            //  List<QueueSearchList_Model> QueueSearchList_Model = new List<QueueSearchList_Model>();
            // QueueSearchList_Model = (Application.OpenForms["frm_lab"] as frm_lab).QueueSearchList_Model;
            if (this.ActiveMdiChild is frm_lab)
            {
                Add_lab();

            }
        }

        private void ts_edit_lab_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_lab)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();

            }
        }

        private void ts_delete_lab_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_lab)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();

            }
        }

        private void ts_save_lab_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_lab)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();

            }
        }

        private void ts_cancel_lab_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_lab)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();

            }
        }
        public void Search_Lab()
        {
            Cursor.Current = Cursors.WaitCursor;
            //((MyInter)this.ActiveMdiChild).Search();
            frm_lab.newlab = false;
            frm_search_Lab f_lab = new frm_search_Lab(this);
            // f_lab.labsearch = labsearch;
            f_lab.FillDataGridView();
            f_lab.ShowDialog();
        }
        private void ts_search_lab_Click(object sender, EventArgs e)
        {
            // List<laboratory_search> labsearch = new List<laboratory_search>();
            // labsearch = (Application.OpenForms["frm_lab"] as frm_lab).labsearch;
            if (this.ActiveMdiChild is frm_lab)
            {
                Search_Lab();


            }
        }

        private void ts_print_lab_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_lab)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();

            }
        }
        public void Add_landbase()
        {
            Cursor.Current = Cursors.WaitCursor;
            //((MyInter)this.ActiveMdiChild).Print();
            frm_Landbase.newLandbase = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_Landbase"] as frm_Landbase).LandBaseAdd_model;
            queue.Landbase = true;
            queue.lab = false;
            queue.queue = false;
            queue.seafarer = false;
            queue.mlc = false;
            queue.xray = false;

            queue.ultraS = false;
            queue.hiv = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();

        }
        private void ts_add_land_Click(object sender, EventArgs e)
        {


            if (this.ActiveMdiChild is frm_Landbase)
            {
                Add_landbase();

            }



        }
        public void Search_landbase()
        {

            Cursor.Current = Cursors.WaitCursor;
            // ((MyInter)this.ActiveMdiChild).Search();
            frm_Landbase.newLandbase = false;
            frm_search_Land frm_land = new frm_search_Land(this);
            frm_land.ShowDialog();
        }
        private void ts_search_land_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Landbase)
            {

                Search_landbase();

            }
        }

        private void ts_edit_land_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Landbase)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_land_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Landbase)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void ts_save_land_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Landbase)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_land_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Landbase)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }

        private void ts_print_land_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Landbase)
            {

                ((MyInter)this.ActiveMdiChild).Print();


            }
        }
        public void add_mlc()
        {

            Cursor.Current = Cursors.WaitCursor;
            //((MyInter)this.ActiveMdiChild).Print();
            frm_Seafarer_MLC.NewSeafarer = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).SeafarerAdd_model;
            queue.Sea_mlc = true;
            queue.Landbase = false;
            queue.lab = false;
            queue.queue = false;
            queue.seafarer = false;
            queue.mlc = false;
            queue.xray = false;
            queue.ultraS = false;
            queue.hiv = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();
        }

        private void ts_add_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {

                add_mlc();
            }
        }

        private void ts_edit_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void ts_save_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }
        public void Search_MLC()
        {

            Cursor.Current = Cursors.WaitCursor;
            //  ((MyInter)this.ActiveMdiChild).Search();
            frm_Seafarer_MLC.NewSeafarer = false;
            frm_search_MLC frm_search = new frm_search_MLC(this);
            frm_search.ShowDialog();
        }
        private void ts_search_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {

                Search_MLC();

            }
        }

        private void ts_print_mlc_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Seafarer_MLC)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();


            }
        }
        public void add_ultrasound()
        {
            Cursor.Current = Cursors.WaitCursor;

            frm_Ultrasound.NewULtrasound = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).UltrasoundAdd_model;
            queue.Landbase = false;
            queue.lab = false;
            queue.queue = false;
            queue.seafarer = false;
            queue.mlc = false;
            queue.xray = false;
            queue.ultraS = true;
            queue.hiv = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();
        }

        private void ts_add_ultrasound_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                add_ultrasound();

            }

        }

        private void ts_edit_ultrasound_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_ultrasound_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void ts_save_ultrasound_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_ultrasound_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }
        public void Search_Ultrasound()
        {
            Cursor.Current = Cursors.WaitCursor;
            // ((MyInter)this.ActiveMdiChild).Search();
            frm_Ultrasound.NewULtrasound = false;
            frm_search_ultrasound frm_search = new frm_search_ultrasound(this);
            frm_search.ShowDialog();

        }
        private void ts_search_ultrasound_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {

                Search_Ultrasound();

            }
        }

        private void ts_print_ultrasound_Click(object sender, EventArgs e)
        {
            //if (this.ActiveMdiChild is frm_Ultrasound)
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //  // ((MyInter)this.ActiveMdiChild).Print();
            //    string AppPath = (Path.GetDirectoryName(Application.StartupPath));
            //    IniFile ini = new IniFile(ClassSql.MMS_Path);
            //    DataTable dt = ClassSql.GetData_Data_proc("RDLC_XRAY", (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).txt_resultID.Text);
            //    LocalReport reportViewer1 = new LocalReport();
            //    reportViewer1.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Ultrasound.rdlc";
            //    reportViewer1.DataSources.Add(new ReportDataSource("DataSet1", dt));
            //    ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "XRAY"));
            //    ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "XRAY"));
            //    ReportParameter p3 = new ReportParameter("Patient_Age", (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).txt_age.Text);
            //    reportViewer1.SetParameters(new ReportParameter[] { p1, p2, p3 });
            //    Export(reportViewer1);
            //    Print();
            //}
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();
            }
        }
        public void add_xray()
        {

            Cursor.Current = Cursors.WaitCursor;
            frm_xray.NewXray = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_xray"] as frm_xray).xrayAdd_model;
            queue.Landbase = false;
            queue.lab = false;
            queue.queue = false;
            queue.seafarer = false;
            queue.mlc = false;
            queue.xray = true;
            queue.hiv = false;
            queue.ultraS = false;
            queue.hiv = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();

        }
        private void ts_add_xray_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {

                add_xray();
            }
        }

        private void ts_edit_xray_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_xray_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void ts_save_xray_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_xray_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }
        public void search_xray()
        {

            Cursor.Current = Cursors.WaitCursor;
            // ((MyInter)this.ActiveMdiChild).Search();
            frm_xray.NewXray = false;
            frm_search_xray frm_search = new frm_search_xray(this);
            frm_search.ShowDialog();
        }
        private void ts_search_xray_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {

                search_xray();

            }
        }

        private void ts_print_xray_Click(object sender, EventArgs e)
        {
            //if (this.ActiveMdiChild is frm_xray)
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //   // ((MyInter)this.ActiveMdiChild).Print();
            //    string AppPath = (Path.GetDirectoryName(Application.StartupPath));
            //    IniFile ini = new IniFile(ClassSql.MMS_Path);
            //    DataTable dt = ClassSql.GetData_Data_proc("RDLC_XRAY", (Application.OpenForms["frm_xray"] as frm_xray).txt_resultID.Text);
            //    LocalReport reportViewer1 = new LocalReport();
            //    reportViewer1.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_XRAY.rdlc";
            //    reportViewer1.DataSources.Add(new ReportDataSource("DataSet1", dt));
            //    ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "XRAY"));
            //    ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "XRAY"));
            //    ReportParameter p3 = new ReportParameter("Patient_Age", (Application.OpenForms["frm_xray"] as frm_xray).txt_age.Text);
            //    reportViewer1.SetParameters(new ReportParameter[] { p1, p2, p3 });
            //    Export(reportViewer1);
            //    Print();



            //}


            if (this.ActiveMdiChild is frm_xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();
            }

        }
        public void add_hiv()
        {
            Cursor.Current = Cursors.WaitCursor;
            frm_HIV.NewHiv = true;
            frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
            queue.queueSearchList_Model = (Application.OpenForms["frm_HIV"] as frm_HIV).hivAdd_model;
            queue.Landbase = false;
            queue.lab = false;
            queue.queue = false;
            queue.seafarer = false;
            queue.mlc = false;
            queue.xray = false;
            queue.hiv = true;
            queue.ultraS = false;
            queue.Psych_Evaluation = false;
            queue.ShowDialog();

        }
        private void ts_add_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {

                add_hiv();

            }
        }

        private void td_edit_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void ts_save_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }
        public void search_hiv()
        {
            //  ((MyInter)this.ActiveMdiChild).Search();
            Cursor.Current = Cursors.WaitCursor;
            frm_HIV.NewHiv = false;
            frm_search_hiv frm_search = new frm_search_hiv(this);
            frm_search.ShowDialog();

        }
        private void ts_search_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {

                search_hiv();


            }
        }

        private void ts_print_hiv_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                // ((MyInter)this.ActiveMdiChild).Print();
                string AppPath = (Path.GetDirectoryName(Application.StartupPath));
                IniFile ini = new IniFile(ClassSql.MMS_Path);
                DataTable dt = ClassSql.GetData_Data_proc("RDLC_Report_HIV", (Application.OpenForms["frm_HIV"] as frm_HIV).txt_resultID.Text);
                LocalReport reportViewer1 = new LocalReport();
                reportViewer1.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_HIV.rdlc";
                reportViewer1.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "HIV"));
                ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "HIV"));
                ReportParameter p3 = new ReportParameter("Age", (Application.OpenForms["frm_HIV"] as frm_HIV).txt_age.Text);
                reportViewer1.SetParameters(new ReportParameter[] { p1, p2, p3 });
                Export(reportViewer1);
                Print();

            }
        }

        private void ts_edit_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void ts_save_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }
        public void Search_Psycho()
        {
            Cursor.Current = Cursors.WaitCursor;
            // ((MyInter)this.ActiveMdiChild).Search();
            frm_Psych_Evaluation.NewPsych_Eval = false;
            frm_search_Psych_Eval frm_search = new frm_search_Psych_Eval(this);
            frm_search.ShowDialog();

        }
        private void ts_search_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {

                Search_Psycho();

            }
        }

        private void ts_print_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();



            }
        }
        public void add_psycho()
        {
            frm_Psych_Evaluation.NewPsych_Eval = true;
            using (frm_NewPatient f = new frm_NewPatient(this))
            {
                f.ShowDialog();
            }

        }
        private void ts_add_Eval_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Psych_Evaluation)
            {

                add_psycho();


            }
        }

        private void ts_next_Record_Click(object sender, EventArgs e)
        {


            if (PatientPageCount < PatientTotalCount)
            {
                PatientPageCount += 1;
                (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).loadPatient_ByPage(PatientPageCount);

            }






        }

        private void ts_prev_record_Click(object sender, EventArgs e)
        {



            if (PatientPageCount > 2)
            {
                PatientPageCount -= 1;
                (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).loadPatient_ByPage(PatientPageCount);

            }




        }

        private void ts_First_Record_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).loadPatient_ByPage(2);
            PatientPageCount = 2;
        }

        private void ts_last_Record_Click(object sender, EventArgs e)
        {

            (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).loadPatient_ByPage(PatientTotalCount);
            PatientPageCount = PatientTotalCount;

        }

        private void resultApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Approval)
            {
                Cursor.Current = Cursors.WaitCursor;
                Approval = false;
                frm_Approval frm_approval = new frm_Approval(this);
                frm_approval.MdiParent = this;
                frm_approval.Show();

            }
        }

        private void formsPrintingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormPrint)
            {
                Cursor.Current = Cursors.WaitCursor;
                FormPrint = false;
                frm_FormPrinting frm_print = new frm_FormPrinting();
                frm_print.MdiParent = this;
                frm_print.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Shown(object sender, EventArgs e)
        {

        }

        private void serverSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_server server = new frm_server();
            server.ShowDialog();

        }




        private void patientVisitQuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisitQueue();
        }

        private void patientProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientProfile();
        }

        private void resultPrintingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Releasing)
            {
                Releasing = false;
                Cursor.Current = Cursors.WaitCursor;
                Report.Report_ResultPrinting Printing = new Report.Report_ResultPrinting();
                Printing.MdiParent = this;
                Printing.Show();
            }
        }

        private void laboratoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLaboratory();
        }

        private void seaferersMedicalExaminationCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSeabase();
        }

        private void seaferersMLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMLC();
        }

        private void ultrasoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showUltrasound();
        }

        private void xRayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowXray();
        }

        private void hIVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHIV();
        }

        private void psychologicalEvaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPyschoEval();
        }

        private void checkUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // CheckUpdate(true);
            InstallUpdateSyncWithInfo();
        }
        private void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
            }
        }
        //void CheckUpdate(bool bl)
        //{

        //    try
        //    {

        //        ClassSql.DbConnect();
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table("Select * from tbl_path where cn = '1'");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            path = dr["Path"].ToString();
        //            datelastaccess = dr["Description"].ToString();

        //        }

        //        string NewPath = path.Replace("-", @"\");

        //        if (File.Exists(NewPath))
        //            {

        //                DateTime LastModified = File.GetLastWriteTime(NewPath);

        //                if (bl)
        //                {
        //                    if (LastModified.ToString() != datelastaccess)
        //                    {

        //                        if (MessageBox.Show("New update is available. Would you like to install it now?", "Install Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                        {
        //                            this.Close();
        //                            System.Diagnostics.Process.Start(NewPath);
        //                            string UpdatePath = NewPath.Replace(@"\", "-");
        //                            a.ExecuteQuery("UPDATE `tbl_path` SET `Path`='" + UpdatePath.ToString() + "', `Description`='" + LastModified + "' WHERE (`cn`='1')");
        //                        }

        //                    }
        //                    else
        //                    {
        //                        Cursor.Current = Cursors.Default;
        //                        MessageBox.Show("Installed version is fully updated", "Check Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                    }
        //                }
        //                else
        //                {
        //                    if (LastModified.ToString() != datelastaccess)
        //                    {

        //                        if (MessageBox.Show("New update is available. Would you like to install it now?", "Install Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                        {
        //                            this.Close();
        //                            System.Diagnostics.Process.Start(NewPath);
        //                            string UpdatePath = NewPath.Replace(@"\", "-");
        //                            a.ExecuteQuery("UPDATE `tbl_path` SET `Path`='" + UpdatePath.ToString() + "', `Description`='" + LastModified + "' WHERE (`cn`='1')");
        //                        }

        //                    }
        //                }





        //            }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format("An error occured {0}", ex.Message), "Unexpected error" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    finally
        //    { if (ClassSql.cnn != null) { ClassSql.DbClose(); } }


        //}



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {



        }

        private void Strip_hiv_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Strip_Sea_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton11_Click_3(object sender, EventArgs e)
        {


            //  isAppLicationExit();
            Application.Exit();

        }

        //void isAppLicationExit()
        // {
        //     if (MessageBox.Show("You're about to exit the application. Are you sure?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //     {
        //         Application.Exit();
        //     }
        //     else
        //     { 
        //         return; 
        //     }
        // }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            try
            { this.ActiveMdiChild.Close(); }
            catch
            { MessageBox.Show("No active form", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Backup bck = new frm_Backup(this);
            bck.ShowDialog();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_about about = new frm_about();
            about.ShowDialog();

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isfromLogin)
            {
                if (MessageBox.Show("You're about to exit the application. Are you sure?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //EndProcess.EndProcessQueryManagerr();
                    e.Cancel = false;

                }
                else
                {
                    e.Cancel = true;
                }

            }

        }

        private void normalValueHivExpiryDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NormalValues frm_norm = new frm_NormalValues();
            frm_norm.ShowDialog();
        }

        private void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void basicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frm_printers().ShowDialog();

        }

        private void ts_add_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                Cursor.Current = Cursors.WaitCursor;
                frm_Tumor_Immunological.newTumor = true;
                frm_search_Patient_Queuing queue = new frm_search_Patient_Queuing(this);
                queue.tumor = true;
                queue.lab = false;
                queue.Landbase = false;
                queue.queue = false;
                queue.seafarer = false;
                queue.mlc = false;
                queue.xray = false;
                queue.ultraS = false;
                queue.hiv = false;
                queue.Psych_Evaluation = false;
                queue.ShowDialog();

            }
        }

        private void ts_edit_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();


            }
        }

        private void ts_delete_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Delete();


            }
        }

        private void tx_save_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Save();


            }
        }

        private void ts_cancel_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Cancel();


            }
        }

        private void ts_search_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {


                Cursor.Current = Cursors.WaitCursor;
                frm_Tumor_Immunological.newTumor = false;
                frm_searchTumor frm_search = new frm_searchTumor(this);
                frm_search.ShowDialog();


            }
        }

        private void ts_print_tumor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Tumor_Immunological)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();


            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            ShowLabExtra();
        }

        private void labOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLabExtra();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_HIV"] as frm_HIV).Close();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_lab"] as frm_lab).Close();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Close();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).Close();
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Close();
        }

        private void toolStripButton19_Click_1(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Close();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Close();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Close();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).Close();
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_xray"] as frm_xray).Close();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["frm_visit"] as frm_visit).Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (File.Exists(ClassSql.MMS_Path))
                {

                    int i = 0;
                    int p = 1;
                    while (i < p)
                    {
                        IniFile ini = new IniFile(ClassSql.MMS_Path);
                        double total = Convert.ToDouble(ini.IniReadValue("Process", "Total"));
                        double current = Convert.ToDouble(ini.IniReadValue("Process", "Current"));
                        double total_in_Percent = (current / total) * 100;
                        backgroundWorker1.ReportProgress(Convert.ToInt32(total_in_Percent));
                        i++;
                        p++;

                        //Thread.Sleep(500);

                        //if (total_in_Percent == 100)
                        //{

                        //    {
                        //        ini.IniWriteValue("Process", "Total", "1");
                        //        ini.IniWriteValue("Process", "Current", "0");

                        //    }
                        //}


                    }
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                //ProgressBar_QuryProcess.Value = e.ProgressPercentage;
                //lbl_percent.Text = e.ProgressPercentage.ToString();
                //if (ProgressBar_QuryProcess.Value == 100)
                //{

                //    progressBar_label.Text = "Complete";


                //}
                //else if (ProgressBar_QuryProcess.Value > 1)
                //{
                //    progressBar_label.Text = "Process...";
                //}
                //else if (ProgressBar_QuryProcess.Value == 1)
                //{
                //    progressBar_label.Text = "";
                //}

            }




        }

        private void toolStripButton12_Click_1(object sender, EventArgs e)
        {


        }
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }


        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.5in</MarginLeft>
                <MarginRight>0.5in</MarginRight>
                <MarginBottom>0.5in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private Stream CreateStream(string name,
     string fileNameExtension, Encoding encoding,
     string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_HIV)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();
            }
        }

        private void toolStripButton12_Click_2(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_xray)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();
            }
        }

        private void toolStripButton25_Click_1(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_Ultrasound)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Print();
            }
        }

        void OpenConnection()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                db.Connection.OpenAsync();


            }
            catch
            {


                new frm_server().ShowDialog();

            }



        }

        private void ts_edit_profile_Click_2(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is frm_patientInfo)
            {
                Cursor.Current = Cursors.WaitCursor;
                ((MyInter)this.ActiveMdiChild).Edit();

            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0 && e.Modifiers == Keys.Control)
            {
                VisitQueue();
            }
            else if (e.KeyCode == Keys.NumPad1 && e.Modifiers == Keys.Control)
            {
                CountTotalPatient();
                PatientProfile();
            }
            else if (e.KeyCode == Keys.NumPad2 && e.Modifiers == Keys.Control)
            {
                ShowLaboratory();
            }
            else if (e.KeyCode == Keys.NumPad3 && e.Modifiers == Keys.Control)
            {
                ShowLandBase();
            }
            else if (e.KeyCode == Keys.NumPad4 && e.Modifiers == Keys.Control)
            {
                showSeabase();
            }
            else if (e.KeyCode == Keys.NumPad5 && e.Modifiers == Keys.Control)
            {
                ShowMLC();
            }
            else if (e.KeyCode == Keys.NumPad6 && e.Modifiers == Keys.Control)
            {
                showUltrasound();
            }
            else if (e.KeyCode == Keys.NumPad7 && e.Modifiers == Keys.Control)
            {
                ShowXray();
            }

            else if (e.KeyCode == Keys.NumPad8 && e.Modifiers == Keys.Control)
            {
                showHIV();
            }

            else if (e.KeyCode == Keys.NumPad9 && e.Modifiers == Keys.Control)
            {
                showPyschoEval();
            }





        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frm_user f = new frm_user(this))
            {
                f.Tag = UserCn;
                f.ShowDialog();
            }
        }

        private void toolStripButton12_Click_3(object sender, EventArgs e)
        {
            new frm_login(this).ShowDialog();
        }


    }
}
