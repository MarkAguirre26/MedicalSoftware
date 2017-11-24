using Centerport.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_FormPrinting : Form
    {

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;

        public frm_FormPrinting()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Report.lab_printOut_Form P_lab = new Report.lab_printOut_Form();          
            //P_lab.R_lab06.Select();
            //P_lab.ShowDialog();

            using (frm_LabPrintChoices f = new frm_LabPrintChoices())
            { 
             f.resultid = "";
            f.Age = "";
            f.ShowImage = "1";
            f.ShowDialog();
            }

        }


        private void button14_Click(object sender, EventArgs e)
        {
           

            try
            {

               // pic_.Image.Save(ClassSql.HIV_TempImage + "\\tmp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
                {
                    f.ShowImage = "1";
                    f.Tag = "0";
                    f.isHIV = true;
                    f.age = "";
                    f.imgpath = "";
                    f.PatientName = "";
                    f.ExaminigPhysycian = "";
                    f.ExaminigPhysycian_lic = "";
                    //DateTime dt = Convert.ToDateTime(dt_result_date.Text);
                    f.resultDate = "";
                    f.Address = "";
                    f.Sex = "";
                    f.CivilStatus = "";
                    f.Medtech = "";
                    f.MedTech_lic = "";
                    //DateTime dt_expiry = Convert.ToDateTime(dt_expire_date.Text);
                    f.ExpiryDate = "";
                    f.Pathologist = "";
                    f.rapid = "0";
                    f.Particle = "0";
                    f.EIA = "0";
                    f.Nonrecative = "0";
                    f.result = "";
                    f.other = "";
                    f.Reactive = "0";                


                    f.ShowDialog();
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }





        }

        private void button13_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.Ultrasound = true;
            //frm_print.ShowDialog();
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isUltrasound = true;
                f.Tag = "";
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isXRAY = true;
                f.Tag = "";
                f.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.MLC = true;
            //frm_print.ShowDialog();
            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.isSeaMLC = true;
            //    f.Tag = "";
            //    f.ShowDialog();
            //}
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.MLC1 = true;
            print.Tag = "0";
            print.ShowDialog();
        }

        private void frm_FormPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.FormPrint = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.Summary_Sea = true;
            //frm_print.ShowDialog();
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.Summary = true;
            print.Tag = "0";
            print.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.MER = true;
            print.recomendation = "";
            print.Tag = "0";
            print.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.Detailed_Sea = true;
            //frm_print.ShowDialog();
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.Detail = true;
            print.Tag = "0";
            print.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.Summary_Land = true;
            //frm_print.ShowDialog();
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.Summary = true;
            print.Tag = "0";
            print.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.MER_Land = true;
            //frm_print.ShowDialog();
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.MER = true;
            print.Tag = "0";
            print.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = "";
            //frm_print.Detailed_Land = true;
            //frm_print.ShowDialog();
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.Detailed = true;
            print.Tag = "0";
            print.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ////Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            ////frm_print.Tag = "";
            ////frm_print.MLC_Land = true;
            ////frm_print.ShowDialog();

            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.isLandMLC = true;
            //    f.Tag = "";
            //    f.age = "";               
            //    f.ShowDialog();
            //}
            Cursor.Current = Cursors.WaitCursor;
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.MLC = true;
            print.Tag = "0";
            print.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            frm_print.Tag = "0";
            frm_print.Psycho_eval_Form = true;
            frm_print.ShowDialog();
            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.isPsycho = true;
            //    f.age = "";
            //    f.Tag = "";
            //    f.ShowDialog();

            //}
        }

        private void frm_FormPrinting_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void frm_FormPrinting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report.lab_printOut_Form P_lab = new Report.lab_printOut_Form();
            P_lab.R_lab06.Select();
            P_lab.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.isXRAY = true;
            //    f.Tag = "";
            //    f.ShowDialog();
            //}
            Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            frm_print.Tag = "0";
            frm_print.XRAY = true;
            frm_print.ShowDialog();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            frm_print.Tag = "0";
            frm_print.HIV = true;
            frm_print.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            frm_print.Tag = "0";
            frm_print.Ultrasound = true;
            frm_print.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            frm_print.Tag = "0";
            frm_print.MLC = true;
            frm_print.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            frm_print.Tag = "0";
            frm_print.MLC_Land = true;
            frm_print.ShowDialog();
        }
    }
}
