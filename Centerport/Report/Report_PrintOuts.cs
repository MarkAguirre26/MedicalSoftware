using Centerport.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Ini;
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
        public bool PsychEval; public bool Psycho_eval_Form; public bool isvisit;

        public string Physch_cn;

        public string Name_from, Employer_from, Date, Position_from, Psychometrician, Psychometrician_license, Psychologist, Psychologist_License, comment1, comment2;

        public int remark;

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
            { Summary_LAND(); wizard1.SelectedTab = tabPage9; }
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
            { backgroundWorker1.RunWorkerAsync(); wizard1.SelectedTab = tabPage5; }
            else if (Psycho_eval_Form)
            { Psych_Eval_form(); wizard1.SelectedTab = tabPage17; }
            else if (isvisit)
            { visit_Report(); wizard1.SelectedTab = visit; }
        }

        void Load_MLC()
        {

            this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            R_Seabase_MLC R_Seabase_MLC1 = new R_Seabase_MLC();
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            //R_Seabase_MLC1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            //R_Seabase_MLC1.Load(@"C:\Report\R_Seabase_MLC.rpt");

            //Viewer_MLC_Sea.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            TextObject FormNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject CompanyName = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_CompanyName"];
            TextObject CompanyAdd = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_CompanyAdd"];
            TextObject Iso = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Seafarer_MLC");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_MLC");
            Iso.Text = ini.IniReadValue("ISO", "Seafarer_MLC");

            CompanyName.Text = "CENTERPORT MEDICAL SERVICES, INC.";
            CompanyAdd.Text = "Address 4/F Victoria BLdg. 429 U.N. Ave. Ermita, Manila";
            //  R_Seabase_MLC1.Refresh();
            Viewer_MLC_Sea.ReportSource = R_Seabase_MLC1;
            Viewer_MLC_Sea.RefreshReport();
            RemoveTab(Viewer_MLC_Sea);
            // wizard1.SelectedTab = tabPage1;

        }
        void Load_ULtraSound()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Ultrasound1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            this.Text = "Ultra Sound Report Print-Out";
            R_Ultrasound1.Load(@"C:\Report\R_Ultrasound.rpt");
            Viewer_ULTZ.ReportSource = R_Ultrasound1;
            Viewer_ULTZ.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '19'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '19'", txt_RevNo, "Revision");
            //IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)R_Ultrasound1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Ultrasound1.ReportDefinition.ReportObjects["txt_RevNo"];

            FormNo.Text = ini.IniReadValue("FORM", "Ultrasound");
            RevNo.Text = ini.IniReadValue("REVISION", "Ultrasound");

            Viewer_ULTZ.RefreshReport();
            RemoveTab(Viewer_ULTZ);
            // wizard1.SelectedTab = tabPage2;
        }
        void Load_XRay()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            //IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Xray1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            this.Text = "X-Ray Report Print-Out";
            R_Xray1.Load(@"C:\Report\R_Xray.rpt");
            Viewer_XRAY.ReportSource = R_Xray1;
            Viewer_XRAY.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();

            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '20'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '20'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Xray1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Xray1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "XRAY");
            RevNo.Text = ini.IniReadValue("REVISION", "XRAY");

            Viewer_XRAY.RefreshReport();
            RemoveTab(Viewer_XRAY);
            // wizard1.SelectedTab = tabPage3;
        }
        void Load_HIV()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_HIV1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            this.Text = "Human Immunodeficiency Virus (HIV) Screening Certificate";
            R_HIV1.Load(@"C:\Report\R_HIV.rpt");
            Viewer_HIV.ReportSource = R_HIV1;
            Viewer_HIV.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '7'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '7'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_HIV1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_HIV1.ReportDefinition.ReportObjects["txt_RevNo"];

            FormNo.Text = ini.IniReadValue("FORM", "HIV");
            RevNo.Text = ini.IniReadValue("REVISION", "HIV");

            Viewer_HIV.RefreshReport();
            RemoveTab(Viewer_HIV);
            // wizard1.SelectedTab = tabPage4;
        }

        void Summary_SEA()
        {
            this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Seabase_Summary1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            //SeaSummary1.Load(@"C:\Report\SeaSummary.rpt");
            //Viewer_summary_Sea.ReportSource = SeaSummary1;
            //Viewer_summary_Sea.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            R_Seabase_Summary1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            R_Seabase_Summary1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            R_Seabase_Summary1.Load(@"C:\Report\R_Seabase_Summary.rpt");
            Viewer_summary_Sea.ReportSource = R_Seabase_Summary1;
            Viewer_summary_Sea.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_ISO, "ISO");
            TextObject FormNo = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_iso"];
            //TextObject CompanyName = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_CompanyName"];
            //TextObject CompanyAdd = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_CompanyAdd"];
            FormNo.Text = ini.IniReadValue("FORM", "Seafarer_Summary");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_Summary");
            Iso.Text = ini.IniReadValue("ISO", "Seafarer_Summary");


            Viewer_summary_Sea.RefreshReport();
            RemoveTab(Viewer_summary_Sea);
            // wizard1.SelectedTab = tabPage6;

        }
        void MER_SEA()
        {

            // this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            // IniFile ini = new IniFile(ClassSql.MMS_Path);
            // R_Seabase_MER R_Seabase_mer1 = new R_Seabase_MER();
            // R_Seabase_mer1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            // R_Seabase_mer1.Load(@"C:\Report\R_Seabase_MER.rpt");
            // Viewer_MER_P1.ReportSource = R_Seabase_mer1;
            // Viewer_MER_P1.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            // TextObject FormNo = (TextObject)R_Seabase_mer1.ReportDefinition.ReportObjects["txt_formNo"];
            // TextObject RevNo = (TextObject)R_Seabase_mer1.ReportDefinition.ReportObjects["txt_RevNo"];
            // TextObject Iso = (TextObject)R_Seabase_mer1.ReportDefinition.ReportObjects["txt_iso"];
            // FormNo.Text = ini.IniReadValue("FORM", "Seafarer_MER");
            // RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_MER");
            // Iso.Text = ini.IniReadValue("ISO", "Seafarer_MER");
            // //R_Seabase_MER1.Refresh();
            // Viewer_MER_P1.RefreshReport();
            // RemoveTab(Viewer_MER_P1);

            // Seabase_MER_Page21.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            //// this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            // Seabase_MER_Page21.Load(@"C:\Report\Seabase_MER_Page2.rpt");
            // Viewer_MER_P2.ReportSource = Seabase_MER_Page21;
            // Viewer_MER_P2.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            // //R_Seabase_MER1.Refresh();
            // //crystalReportViewer14.RefreshReport();
            // RemoveTab(Viewer_MER_P2);

            //// wizard1.SelectedTab = tabPage7;

        }
        void Detailed_SEA()
        {


            this.Text = "Seafarer's Medical Examination Certificate Print-Out";
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_SeabaseDetailed1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_SeabaseDetailed1.Load(@"C:\Report\R_SeabaseDetailed.rpt");
            Viewer_Detailed_Sea.ReportSource = R_SeabaseDetailed1;
            Viewer_Detailed_Sea.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_ISO, "ISO");

            TextObject FormNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject ISO = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Seafarer_Detailed");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_Detailed");
            ISO.Text = ini.IniReadValue("ISO", "Seafarer_Detailed");
            //R_SeabaseDetailed1.Refresh();
            Viewer_Detailed_Sea.RefreshReport();
            RemoveTab(Viewer_Detailed_Sea);
            //  wizard1.SelectedTab = tabPage8;

        }

        void Summary_LAND()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            this.Text = "Landbase Medical Examination Certificate Print-Out";
            R_lanabase_Summary1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_lanabase_Summary1.Load(@"C:\Report\R_lanabase_Summary.rpt");
            Viewer_Summary.ReportSource = R_lanabase_Summary1;
            Viewer_Summary.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_ISO, "ISO");

            TextObject FormNo = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_Summary");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_Summary");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_Summary");

            //R_lanabase_Summary1.Refresh();
            Viewer_Summary.RefreshReport();
            RemoveTab(Viewer_Summary);
            //wizard1.SelectedTab = tabPage9;
        }
        void MER_LAND()
        {
            this.Text = "Landbase Medical Examination Certificate Print-Out";
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Landbade_MER1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_Landbade_MER1.Load(@"C:\Report\R_Landbade_MER.rpt");
            MER_Land1.ReportSource = R_Landbade_MER1;
            MER_Land1.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ISO, "ISO");

            TextObject FormNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_MER");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_MER");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_MER");
            MER_Land1.RefreshReport();
            RemoveTab(MER_Land1);

            LandBase_MER21.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            //  this.Text = "Landbase Medical Examination Certificate Print-Out";
            LandBase_MER21.Load(@"C:\Report\LandBase_MER2.rpt");
            MER_Land2.ReportSource = LandBase_MER21;
            MER_Land2.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            //crystalReportViewer11.RefreshReport();
            RemoveTab(MER_Land2);

        }
        void Detailed_LAND()
        {
            this.Text = "Landbase Medical Examination Certificate Print-Out";
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Landbase_Detailed1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_Landbase_Detailed1.Load(@"C:\Report\R_Landbase_Detailed.rpt");
            Viewer_land_detailed.ReportSource = R_Landbase_Detailed1;
            Viewer_land_detailed.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_ISO, "ISO");

            TextObject FormNo = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_Detailed");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_Detailed");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_Detailed");

            //R_Landbase_Detailed1.Refresh();
            Viewer_land_detailed.RefreshReport();
            RemoveTab(Viewer_land_detailed);
            // wizard1.SelectedTab = tabPage12;

        }
        void MLC_LAND()
        {

            this.Text = "Landbase Medical Examination Certificate Print-Out";
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_landbaseMLC1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_landbaseMLC1.Load(@"C:\Report\R_landbaseMLC.rpt");
            VIEWER_LAND_MLC.ReportSource = R_landbaseMLC1;
            VIEWER_LAND_MLC.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_ISO, "ISO");

            TextObject FormNo = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_MLC");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_MLC");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_MLC");
            //R_landbaseMLC1.Refresh();
            VIEWER_LAND_MLC.RefreshReport();
            RemoveTab(VIEWER_LAND_MLC);
            // wizard1.SelectedTab = tabPage13;


        }

        void Psych_Eval()
        {
            this.Text = "Medical Examination Certificate Print-Out";
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report1.t_psychology1DataTable();
            PsychoFinal PsychoFinal1 = new PsychoFinal();


            var list = db.t_psychology1(this.Tag.ToString()).ToList();
            foreach (var i in list)
            {

                dt.Rows.Add(i.intelectual_level, i.res_persevering, i.res_obedient, i.res_selfdiscipline, i.res_enthusiastic, i.res_venturesome, i.emo_isolation_boredom, i.emo_noise_vibration_temp, i.emo_reality, i.emo_confident, i.emo_relaxed, i.obj_realistic, i.obj_adaptable, i.obj_practicalminded, i.mot_assertive, i.mot_independent, i.mot_resourceful, i.goal_orientation, i.iapa_rel_peer, i.iapa_rel_superior, i.iapa_self_esteem, i.iapa_aggressive_tendencies, i.intel_result, i.person_result, i.other_result);
            }
            PsychoFinal1.SetDataSource(dt);
            // PsychoFinal1.Load(@"C:\Report\PsychoFinal.rpt");
            //VIEWER_PsychEval.ReportSource = PsychoFinal1;
            // VIEWER_PsychEval.SelectionFormula = "{t_psychology1.cn} = " + this.Tag.ToString() + "";           

            TextObject FormNo = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_RevNo"];

            TextObject name = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_name"];
            TextObject Employer = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_employer"];
            TextObject Date_r = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_date"];
            TextObject Position = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_position"];

            TextObject med1 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_Psycho_Med"];
            TextObject med1_license = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txtTititlePrcMedtech"];
            TextObject med2 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_Psychologist"];
            TextObject med2license = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txtTititlePrcPatho"];



            TextObject ValidityMedTech = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txtvalidity_Medtech"];
            TextObject ptr_medtech = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_ptr_medtech"];

            TextObject ValidityPatho = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txtvalidity_Patho"];
            TextObject PRTPatho = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_ptr_patho"];

            TextObject com1 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_comment1"];
            TextObject com2 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_comment2"];

            TextObject rmk1 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_remark1"];
            TextObject rmk2 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_remark2"];
            TextObject rmk3 = (TextObject)PsychoFinal1.ReportDefinition.ReportObjects["txt_remark3"];


            if (remark == 1)
            {
                rmk1.Text = "X";
                rmk2.Text = "";
                rmk3.Text = "";
            }
            else if (remark == 2)
            {
                rmk1.Text = "";
                rmk2.Text = "X";
                rmk3.Text = "";
            }
            else if (remark == 3)
            {
                rmk1.Text = "";
                rmk2.Text = "";
                rmk3.Text = "X";
            }
            else
            {
                rmk1.Text = "";
                rmk2.Text = "";
                rmk3.Text = "";

            }


            name.Text = Name_from;
            Employer.Text = Employer_from;
            Date_r.Text = Date.ToUpper();
            Position.Text = Position_from.ToUpper();

            med1.Text = Psychometrician;
            med1_license.Text = "Lic. No.: " + Psychometrician_license;
            med2.Text = Psychologist;
            med2license.Text = "Lic. No.: " + Psychologist_License;



            FormNo.Text = ini.IniReadValue("FORM", "Psycho_Evaluation");
            RevNo.Text = ini.IniReadValue("REVISION", "Psycho_Evaluation");

            ValidityMedTech.Text = "Lic. Validity: " + ini.IniReadValue("MEDICAL", "Psychometrician_Validity");
            ptr_medtech.Text = "PTR Nos: " + ini.IniReadValue("MEDICAL", "Psychometrician_ptr");

            ValidityPatho.Text = "Lic. Validity: " + ini.IniReadValue("MEDICAL", "Psychologist_Validity");
            PRTPatho.Text = "PTR Nos: " + ini.IniReadValue("MEDICAL", "Psychologist_Ptr");


            com1.Text = comment1;
            com2.Text = comment2;




            //R_PsychEval1.Refresh();
            // VIEWER_PsychEval.RefreshReport();
            VIEWER_PsychEval.ReportSource = PsychoFinal1;
            RemoveTab(VIEWER_PsychEval);
            wizard1.SelectedTab = tabPage5;


        }

        async void Psych_Eval_form()
        {
            // DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            // DataTable dt = new ds_report1.t_psychology1DataTable();
            this.Text = "Medical Examination Certificate Print-Out";
            Psych_Eval Psych_Eval1 = new Psych_Eval();
            await Task.Run(() =>
            {
                // var list = db.t_psychology1(this.Tag.ToString()).ToList();
                //foreach (var i in list)
                //{
                //    dt.Rows.Add(


                //        );

                //}
                //this.Invoke(new Action(() => { Psych_Eval1.SetDataSource(dt); }));

                //Psych_Eval1.Load(@"C:\Report\Psych_Eval.rpt");


                IniFile ini = new IniFile(ClassSql.MMS_Path);
                TextObject FormNo = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txt_formNo"];
                TextObject RevNo = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txt_RevNo"];

                TextObject PsychoMet = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txt_psychoMet"];
                TextObject TitleLicMed = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txtTititlePrcMedtech"];
                TextObject ValidityMedTech = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txtvalidity_Medtech"];
                TextObject ptr_medtech = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txt_ptr_medtech"];

                TextObject Psychologist = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txt_psychologist"];
                TextObject TitleLicPath = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txtTititlePrcPatho"];
                TextObject ValidityPatho = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txtvalidity_Patho"];
                TextObject PRTPatho = (TextObject)Psych_Eval1.ReportDefinition.ReportObjects["txt_ptr_patho"];

                FormNo.Text = ini.IniReadValue("FORM", "Psycho_Evaluation");
                RevNo.Text = ini.IniReadValue("REVISION", "Psycho_Evaluation");

                PsychoMet.Text = ini.IniReadValue("MEDICAL", "Psychometrician");
                TitleLicMed.Text = "Lic No.: " + ini.IniReadValue("MEDICAL", "Psychometrician_license");

                ValidityMedTech.Text = "Lic. Vilidity: " + ini.IniReadValue("MEDICAL", "Psychometrician_Validity");
                ptr_medtech.Text = "PTR Nos.: " + ini.IniReadValue("MEDICAL", "Psychometrician_ptr");

                Psychologist.Text = ini.IniReadValue("MEDICAL", "Psychologist");
                TitleLicPath.Text = "Lic No.: " + ini.IniReadValue("MEDICAL", "Psychologist_license");
                ValidityPatho.Text = "Lic. VAlidity: " + ini.IniReadValue("MEDICAL", "Psychologist_Validity");
                PRTPatho.Text = "PTR Nos: " + ini.IniReadValue("MEDICAL", "Psychologist_Ptr");
            });


            ///////////////




            VIEWER_Psycho.ReportSource = Psych_Eval1;
            VIEWER_Psycho.RefreshReport();
            RemoveTab(VIEWER_Psycho);



        }

        async void visit_Report()
        {
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report1.sp_visitReportDataTable();
            Visit_Report rpt = new Visit_Report();

            await Task.Run(() =>
            {
                var list = db.sp_visitReport(this.Tag.ToString()).ToList();
                foreach (var i in list)
                {
                    DateTime TimeIn = DateTime.Parse(i.trans_date);
                    dt.Rows.Add(i.papin, i.PatientName, i.gender, i.pxtype, TimeIn.ToShortDateString() + " " + TimeIn.ToShortTimeString(), i.diagnosis);

                }
                this.Invoke(new Action(() => { rpt.SetDataSource(dt); }));
                TextObject txt_printRange = (TextObject)rpt.ReportDefinition.ReportObjects["txt_printRange"];
                txt_printRange.Text = "Date Range From  " + Convert.ToDateTime(this.Tag.ToString()).ToShortDateString() + " - " + Convert.ToDateTime(this.Tag.ToString()).ToShortDateString();



            });
            this.visit_reportViewer.ReportSource = rpt;
            RemoveTab(visit_reportViewer);

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





        private void Report_PrintOuts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                PrintNow();
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PrintNow();
        }

        void PrintNow()
        {
            if (wizard1.SelectedIndex == 0)
            {

                Viewer_MLC_Sea.PrintReport();
            }
            else if (wizard1.SelectedIndex == 1)
            {

                Viewer_ULTZ.PrintReport();
            }
            else if (wizard1.SelectedIndex == 2)
            {

                Viewer_XRAY.PrintReport();
            }
            else if (wizard1.SelectedIndex == 3)
            {


                Viewer_HIV.PrintReport();
            }
            else if (wizard1.SelectedIndex == 4)
            {

                Viewer_summary_Sea.PrintReport();
            }
            else if (wizard1.SelectedIndex == 5)
            {
                if (tabControl1.SelectedIndex == 0)
                { Viewer_MER_P1.PrintReport(); }
                else if (tabControl1.SelectedIndex == 1)
                { Viewer_MER_P2.PrintReport(); }



            }
            else if (wizard1.SelectedIndex == 6)
            {

                Viewer_Detailed_Sea.PrintReport();
            }
            else if (wizard1.SelectedIndex == 7)
            {

                Viewer_Summary.PrintReport();
            }
            else if (wizard1.SelectedIndex == 8)
            {

                if (tabControl_Landbase.SelectedIndex == 0)
                { MER_Land1.PrintReport(); }
                else if (tabControl_Landbase.SelectedIndex == 1)
                {
                    MER_Land2.PrintReport();
                }
            }
            else if (wizard1.SelectedIndex == 9)
            {

                Viewer_land_detailed.PrintReport();
            }
            else if (wizard1.SelectedIndex == 10)
            {

                VIEWER_LAND_MLC.PrintReport();
            }
            else if (wizard1.SelectedIndex == 11)
            {
                VIEWER_PsychEval.PrintReport();
            }
            else if (wizard1.SelectedIndex == 12)
            {
                VIEWER_Psycho.PrintReport();
            }
            else if (wizard1.SelectedIndex == 13)
            {
                visit_reportViewer.PrintReport();
            }

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { Psych_Eval(); }));
        }


    }
}
