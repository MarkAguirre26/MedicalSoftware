using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport.Report
{
    
    public partial class Report_PrintOuts : Form
    {
        public bool MLC; public bool XRAY; public bool Ultrasound; public bool HIV;
        public bool Summary_Sea; public bool MER_Sea; public bool Detailed_Sea;
        public bool Summary_Land; public bool MER_Land; public bool Detailed_Land; public bool MLC_Land;
        public bool PsychEval;

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;





        public Report_PrintOuts()
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

        private void Report_PrintOuts_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            if (MLC)
            { Load_MLC(); wizard1.SelectedTab = tabPage1; }
            else if (XRAY)
            { Load_XRay(); wizard1.SelectedTab = tabPage3; }
            else if (Ultrasound)
            { Load_ULtraSound(); wizard1.SelectedTab = tabPage2; }
            else if (HIV)
            { Load_HIV(); wizard1.SelectedTab = tabPage4; }
            else if (Summary_Land)
            {  Summary_LAND(); wizard1.SelectedTab = tabPage9;  }
            else if (MER_Land)
            { MER_LAND(); wizard1.SelectedTab = tabPage10; }
            else if (Detailed_Land)
            { Detailed_LAND(); wizard1.SelectedTab = tabPage12; }
            else if (MLC_Land)
            { MLC_LAND(); wizard1.SelectedTab = tabPage13; }
            else if (Summary_Sea)
            { Summary_SEA(); wizard1.SelectedTab = tabPage6; }
            else if (MER_Sea)
            { MER_SEA(); wizard1.SelectedTab = tabPage7; }
            else if (Detailed_Sea)
            { Detailed_SEA(); wizard1.SelectedTab = tabPage8; }
            else if (PsychEval)
            { Psych_Eval(); wizard1.SelectedTab = tabPage5; }
          
        }

        void Load_MLC()
        {
          
            this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            R_Seabase_MLC1.Load(@"C:\Report\R_Seabase_MLC.rpt");
            crystalReportViewer1.ReportSource = R_Seabase_MLC1;
            crystalReportViewer1.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '14'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '14'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            //TextObject CompanyName = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_CompanyName"];
            //TextObject CompanyAdd = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_CompanyAdd"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            //CompanyName.Text = Properties.Settings.Default.CompanyName.ToString();
            //CompanyAdd.Text = Properties.Settings.Default.CompanyAdd.ToString();
          //  R_Seabase_MLC1.Refresh();
            crystalReportViewer1.RefreshReport();
            RemoveTab(crystalReportViewer1);
           // wizard1.SelectedTab = tabPage1;

        }
        void Load_ULtraSound()
        {
            this.Text = "Ultra Sound Report Print-Out";
            R_Ultrasound1.Load(@"C:\Report\R_Ultrasound.rpt");
            crystalReportViewer2.ReportSource = R_Ultrasound1;
            crystalReportViewer2.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '19'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '19'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Ultrasound1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Ultrasound1.ReportDefinition.ReportObjects["txt_RevNo"];

            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            crystalReportViewer2.RefreshReport();
            RemoveTab(crystalReportViewer2);
           // wizard1.SelectedTab = tabPage2;
        }
        void Load_XRay()
        {
            this.Text = "X-Ray Report Print-Out";
            R_Xray1.Load(@"C:\Report\R_Xray.rpt");
            crystalReportViewer3.ReportSource = R_Xray1;
            crystalReportViewer3.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '20'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '20'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Xray1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Xray1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            crystalReportViewer3.RefreshReport();
            RemoveTab(crystalReportViewer3);
           // wizard1.SelectedTab = tabPage3;
        }
        void Load_HIV()
        {
            this.Text = "Human Immunodeficiency Virus (HIV) Screening Certificate";
            R_HIV1.Load(@"C:\Report\R_HIV.rpt");
            crystalReportViewer4.ReportSource = R_HIV1;
            crystalReportViewer4.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '7'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '7'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_HIV1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_HIV1.ReportDefinition.ReportObjects["txt_RevNo"];

            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            crystalReportViewer4.RefreshReport();
            RemoveTab(crystalReportViewer4);
           // wizard1.SelectedTab = tabPage4;
        }

        void Summary_SEA()
        {
            this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            R_Seabase_Summary1.Load(@"C:\Report\R_Seabase_Summary.rpt");
            crystalReportViewer6.ReportSource = R_Seabase_Summary1;
            crystalReportViewer6.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_RevNo"];
            //R_Seabase_Summary1.Refresh();
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;


            crystalReportViewer6.RefreshReport();
            RemoveTab(crystalReportViewer6);
           // wizard1.SelectedTab = tabPage6;
        
        }
        void MER_SEA()
        {

            this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            R_Seabase_MER1.Load(@"C:\Report\R_Seabase_MER.rpt");
            crystalReportViewer7.ReportSource = R_Seabase_MER1;
            crystalReportViewer7.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '13'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '13'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Seabase_MER1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_MER1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            //R_Seabase_MER1.Refresh();
            crystalReportViewer7.RefreshReport();
            RemoveTab(crystalReportViewer7);

           // this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            Seabase_MER_Page21.Load(@"C:\Report\Seabase_MER_Page2.rpt");
            crystalReportViewer14.ReportSource = Seabase_MER_Page21;
            crystalReportViewer14.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
           
            //R_Seabase_MER1.Refresh();
            crystalReportViewer14.RefreshReport();
            RemoveTab(crystalReportViewer14);

           // wizard1.SelectedTab = tabPage7;
        
        }
        void Detailed_SEA()
        {


            this.Text = "Seafarer's Medical Examination Certificate Print-Out";

            R_SeabaseDetailed1.Load(@"C:\Report\R_SeabaseDetailed.rpt");
            crystalReportViewer8.ReportSource = R_SeabaseDetailed1;
            crystalReportViewer8.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            //R_SeabaseDetailed1.Refresh();
            crystalReportViewer8.RefreshReport();
            RemoveTab(crystalReportViewer8);
          //  wizard1.SelectedTab = tabPage8;

        }

        void Summary_LAND()
        {
            this.Text = "Landbase Medical Examination Certificate Print-Out";
            R_lanabase_Summary1.Load(@"C:\Report\R_lanabase_Summary.rpt");
            crystalReportViewer9.ReportSource = R_lanabase_Summary1;
            crystalReportViewer9.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            //R_lanabase_Summary1.Refresh();
            crystalReportViewer9.RefreshReport();
            RemoveTab(crystalReportViewer9);
            //wizard1.SelectedTab = tabPage9;
        }
        void MER_LAND()
        {
            this.Text = "Landbase Medical Examination Certificate Print-Out";
            R_Landbade_MER1.Load(@"C:\Report\R_Landbade_MER.rpt");
            crystalReportViewer10.ReportSource = R_Landbade_MER1;
            crystalReportViewer10.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_RevNo, "Revision");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ISO, "ISO");
            TextObject FormNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            Iso.Text = txt_ISO.Text;          
            crystalReportViewer10.RefreshReport();
            RemoveTab(crystalReportViewer10);

          //  this.Text = "Landbase Medical Examination Certificate Print-Out";
            LandBase_MER21.Load(@"C:\Report\LandBase_MER2.rpt");
            crystalReportViewer11.ReportSource = LandBase_MER21;
            crystalReportViewer11.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            crystalReportViewer11.RefreshReport();
            RemoveTab(crystalReportViewer11);

        }
        void Detailed_LAND()
        {
            this.Text = "Landbase Medical Examination Certificate Print-Out";
            R_Landbase_Detailed1.Load(@"C:\Report\R_Landbase_Detailed.rpt");
            crystalReportViewer12.ReportSource = R_Landbase_Detailed1;
            crystalReportViewer12.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_RevNo, "Revision");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_ISO, "ISO");
            TextObject FormNo = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            Iso.Text = txt_ISO.Text;

            //R_Landbase_Detailed1.Refresh();
            crystalReportViewer12.RefreshReport();
            RemoveTab(crystalReportViewer12);
           // wizard1.SelectedTab = tabPage12;

        }
        void MLC_LAND()
        {

            this.Text = "Landbase Medical Examination Certificate Print-Out";
            R_landbaseMLC1.Load(@"C:\Report\R_landbaseMLC.rpt");
            crystalReportViewer13.ReportSource = R_landbaseMLC1;
            crystalReportViewer13.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            //R_landbaseMLC1.Refresh();
            crystalReportViewer13.RefreshReport();
            RemoveTab(crystalReportViewer13);
           // wizard1.SelectedTab = tabPage13;


        }

        void Psych_Eval()
        {

            this.Text = "Landbase Medical Examination Certificate Print-Out";
            R_PsychEval1.Load(@"C:\Report\R_PsychEval.rpt");
            crystalReportViewer5.ReportSource = R_PsychEval1;
            //crystalReportViewer5.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "' and {t_result_main1.resulttype} = '" + "PSYCHO " + "'";
            crystalReportViewer5.SelectionFormula = "{t_result_main1.resultid} ='" + this.Tag.ToString() + "' and {t_result_main1.resulttype} = '" + "PSYCHO " + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '10'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '10'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_PsychEval1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_PsychEval1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            //R_PsychEval1.Refresh();
            crystalReportViewer5.RefreshReport();
            RemoveTab(crystalReportViewer5);
            wizard1.SelectedTab = tabPage5;


        }




        void RemoveTab(CrystalReportViewer rpt)
        {

            foreach (Control control in rpt.Controls)
            {
                if (control is PageView)
                {
                    TabControl tab = (TabControl)((PageView)control).Controls[0];
                    tab.ItemSize = new Size(0, 1);
                    tab.SizeMode = TabSizeMode.Fixed;
                    tab.Appearance = TabAppearance.Buttons;
                }
            }

        }

        private void Report_PrintOuts_FormClosing(object sender, FormClosingEventArgs e)
        {
            MLC = false;
            Ultrasound = false;
            XRAY = false;
            HIV = false;
            Summary_Sea = false;
            MER_Sea = false;
            Detailed_Sea = false;
            Summary_Land = false;
            MER_Land = false;
            Detailed_Land = false;
            MER_Land = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //R_Seabase_MLC1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            //R_Seabase_MLC1.PrintToPrinter(1, false, 0, 0);
            //Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            R_Ultrasound1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Ultrasound1.PrintToPrinter(1, false, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            R_Xray1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Xray1.PrintToPrinter(1, false, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            R_HIV1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_HIV1.PrintToPrinter(1, false, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            R_Seabase_Summary1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Seabase_Summary1.PrintToPrinter(1, false, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            R_Seabase_MER1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Seabase_MER1.PrintToPrinter(1, false, 0, 0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            R_SeabaseDetailed1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_SeabaseDetailed1.PrintToPrinter(1, false, 0, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            R_lanabase_Summary1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_lanabase_Summary1.PrintToPrinter(1, false, 0, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            R_Landbade_MER1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Landbade_MER1.PrintToPrinter(1, false, 0, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            R_Landbase_Detailed1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Landbase_Detailed1.PrintToPrinter(1, false, 0, 0);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            R_landbaseMLC1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_landbaseMLC1.PrintToPrinter(1, false, 0, 0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            R_PsychEval1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_PsychEval1.PrintToPrinter(1, false, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_PrintOuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

        private void cmd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
