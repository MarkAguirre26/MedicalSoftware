using Centerport.Dataset;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport.Report
{
    public partial class Report_Landbase : Form
    {

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        public static bool Summary, Detailed, MLC, MER;


        public Report_Landbase()
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


        private void button2_Click(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void PrintNow()
        {
            try
            {
                if (Summary)
                {
                    Viewer1.PrintReport();
                }
                else if (MLC)
                {

                    Viewer2.PrintReport();
                }
                else if (Detailed)
                {
                    Viewer3.PrintReport();
                }
                else if (MER)
                {

                    if (tabControl1.SelectedTab == tabPage5)
                    {
                        Viewer4_1.PrintReport();

                    }
                    else if (tabControl1.SelectedTab == tabPage6)
                    {

                        Viewer4_2.PrintReport();
                    }


                }
            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("{0}" + ex.Message + "@\n Please use the deafualt print button to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)); }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            PrintNow();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            { backgroundWorker4.RunWorkerAsync(); }
            else if (tabControl1.SelectedIndex == 1)
            { backgroundWorker5.RunWorkerAsync(); }
        }

        void load_MER1()
        {
            wizard1.SelectedTab = tabPage4;
            tabControl1.SelectedTab = tabPage5;

        }

        public void load_MER2()
        {


            wizard1.SelectedTab = tabPage4;
            tabControl1.SelectedTab = tabPage6;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report1.sp_landbase_MER2DataTable();
            LandBase_MER2 LandBase_mer2 = new LandBase_MER2();

            var list = db.sp_landbase_MER2(this.Tag.ToString()).ToList();
            foreach (var i in list)
            {
                dt.Rows.Add(i.HEIGHT, i.WEIGHT, i.BP, i.PULSE, i.RESPIRATION, i.BODY_BUILD, i.FAR_OD_U, i.FAR_OD_C, i.FAR_OS_U, i.FAR_OS_C, i.NEAR_ODJ_U, i.NEAR_ODJ_C, i.NEAR_OSJ_U, i.NEAR_OSJ_C, i.ISHIHARA_U, i.ISHIHARA_C, i.HEARING_RIGHT, i.HEARING_LEFT, i.CLARITY_OF_SPEECH, i.BP_DIASTOLIC, i.RHYTHM, i.resultid, i.result_date, i.valid_until, i.remMain, i.recommendation, i.specimen_no, i.medtech, i.medtech_license, i.basic_doh_exam, i.add_lab_tests, i.flag_medlab_req, i.SKIN_TAG, i.SKIN, i.HEAD_NECK_SCALP_TAG, i.HEAD_NECK_SCALP, i.EYES_TAG, i.EYES, i.PUPILS_TAG, i.PUPILS, i.EARS_EARDRUM_TAG, i.EARS_EARDRUM, i.NOSE_SINUSES_TAG, i.NOSE_SINUSES, i.MOUTH_THROAT_TAG, i.MOUTH_THROAT, i.NECK_LN_THYROID_TAG, i.NECK_LN_THYROID, i.CHEST_BREAST_AXILLA_TAG, i.CHEST_BREAST_AXILLA, i.LUNGS_TAG, i.LUNGS, i.HEART_TAG, i.HEART, i.ABDOMEN_TAG, i.ABDOMEN, i.BACK_FLANK_TAG, i.BACK_FLANK, i.ANUS_RECTUM_TAG, i.ANUS_RECTUM, i.GU_SYSTEM_TAG, i.GU_SYSTEM, i.INGUINALS_GENITALS_TAG, i.INGUINALS_GENITALS, i.REFLEXES_TAG, i.REFLEXES, i.EXTREMITIES_TAG, i.EXTREMITIES, i.DENTAL, i.DENTAL_TAG, i.cxr, i.ecg, i.cbc, i.urinalysis, i.stool_exam, i.hbsag, i.hiv, i.rpr, i.blood_type, i.psychological_exam, i.additional_test, i.remarks, i.additional_test2, i.lastname, i.firstname, i.middlename);
            }
            LandBase_mer2.SetDataSource(dt);
            Viewer4_2.ReportSource = LandBase_mer2;
            RemoveTab(Viewer4_2);
            Cursor.Current = Cursors.Default;
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

        public void Load_MER()
        {

            Cursor.Current = Cursors.WaitCursor;
            wizard1.SelectedTab = tabPage4;
            tabControl1.SelectedTab = tabPage5;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_Landbase_MER1DataTable();
            R_Landbade_MER R_Landbase_MER = new R_Landbade_MER();

            var list = db.sp_Landbase_MER1(this.Tag.ToString()).ToList();

            foreach (var i in list)
            {
                dt.Rows.Add(
                    i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.nationality, i.religion, i.country_destination, i.picture.ToArray(), i.resultid, i.head_injury, i.frequent_headaches, i.frequent_dizziness, i.fainting_spells, i.insomnia, i.depression, i.trachoma, i.deafness, i.nose_throat_disorder, i.tuberculosis, i.other_lung_disorder, i.high_blood_pressure, i.heart_disease, i.rheumatic_fever, i.diabetes_mellitus, i.other_endocrine_disorder, i.cancer_tumor, i.blood_disorders, i.stomach_pain, i.other_abdominal_disorder, i.kidney_bladder_disorder, i.back_injury, i.genetic_hereditary, i.sexually_transmit_disease, i.tropical_disease, i.asthma, i.allergies, i.gynecological_disorder, i.operations, i.operations_specify, i.others, i.schistosomiasis, i.last_menstrual_period, i.allergies_specify, i.other_abdominal_specify, i.column1, i.column2, i.column3, i.column4, i.column5, i.column6, i.column7, i.column7_comment, i.column8, i.column8_comment,i.column1_comment,i.column2_comment,i.column3_comment,i.column4_comment,i.column5_comment,i.column6_comment);

            }
            R_Landbase_MER.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_Landbase_MER.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbase_MER.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbase_MER.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_MER");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_MER");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_MER");




            Viewer4_1.ReportSource = R_Landbase_MER;
            RemoveTab(Viewer4_1);
            Cursor.Current = Cursors.Default;

        }

        public void Load_MLC()
        {

            Cursor.Current = Cursors.WaitCursor;
            wizard1.SelectedTab = tabPage2;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_Landbase_MLCDataTable();
            R_landbaseMLC R_landbase_MLC = new R_landbaseMLC();

            var list = db.sp_Landbase_MLC(this.Tag.ToString()).ToList();
            foreach (var i in list)
            {
                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.nationality, i.religion, i.country_destination, i.picture.ToArray(), i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.recommendation, i.medtech, i.ISHIHARA_U, i.ISHIHARA_C, i.SATISFACTORY_HEARING, i.SATISFACTORY_PSYCHO, i.SATISFACTORY_SIGHT_UNAID, i.specimen_no);

            }
            R_landbase_MLC.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_landbase_MLC.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_landbase_MLC.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_landbase_MLC.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_MLC");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_MLC");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_MLC");



            Viewer2.ReportSource = R_landbase_MLC;
            RemoveTab(Viewer2);
            Cursor.Current = Cursors.Default;
        }


        public void load_Detailed()
        {



            Cursor.Current = Cursors.WaitCursor;
            wizard1.SelectedTab = tabPage3;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_landbase_DetailDataTable();
            R_Landbase_Detailed R_Landbase_detailed = new R_Landbase_Detailed();

            var list = db.sp_landbase_Detail(this.Tag.ToString()).ToList();
            var count = list.Count();
            foreach (var i in list)
            {
                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.contact_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.seamansbook_no, i.nationality, i.religion, i.country_destination, i.picture.ToArray(), i.resultid, i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.remMain, i.recommendation, i.specimen_no, i.medtech, i.cxr, i.ecg, i.cbc, i.pregnancy_test, i.urinalysis, i.stool_exam, i.hbsag, i.hiv, i.rpr, i.blood_type, i.blood_chemistries, i.psychological_exam, i.additional_test, i.remarks, i.additional_test2, i.SKIN_TAG, i.SKIN, i.HEAD_NECK_SCALP_TAG, i.HEAD_NECK_SCALP, i.EYES_TAG, i.EYES, i.PUPILS_TAG, i.PUPILS, i.EARS_EARDRUM_TAG, i.EARS_EARDRUM, i.NOSE_SINUSES_TAG, i.NOSE_SINUSES, i.MOUTH_THROAT_TAG, i.MOUTH_THROAT, i.NECK_LN_THYROID_TAG, i.NECK_LN_THYROID, i.CHEST_BREAST_AXILLA_TAG, i.CHEST_BREAST_AXILLA, i.LUNGS_TAG, i.LUNGS, i.HEART_TAG, i.HEART, i.ABDOMEN_TAG, i.ABDOMEN, i.BACK_FLANK_TAG, i.BACK_FLANK, i.ANUS_RECTUM_TAG, i.ANUS_RECTUM, i.GU_SYSTEM_TAG, i.GU_SYSTEM, i.INGUINALS_GENITALS_TAG, i.INGUINALS_GENITALS, i.REFLEXES_TAG, i.REFLEXES, i.EXTREMITIES_TAG, i.EXTREMITIES, i.DENTAL, i.DENTAL_TAG, i.HEIGHT, i.WEIGHT, i.BP, i.PULSE, i.RESPIRATION, i.BODY_BUILD, i.FAR_OD_U, i.FAR_OD_C, i.FAR_OS_U, i.FAR_OS_C, i.NEAR_ODJ_U, i.NEAR_ODJ_C, i.NEAR_OSJ_U, i.NEAR_OSJ_C, i.ISHIHARA_U, i.ISHIHARA_C, i.HEARING_AD, i.HEARING_AS, i.CONVERSATIONAL_AD, i.BP_DIASTOLIC, i.head_injury, i.frequent_headaches, i.frequent_dizziness, i.fainting_spells, i.insomnia, i.depression, i.trachoma, i.deafness, i.nose_throat_disorder, i.tuberculosis, i.other_lung_disorder, i.high_blood_pressure, i.heart_disease, i.rheumatic_fever, i.diabetes_mellitus, i.other_endocrine_disorder, i.cancer_tumor, i.blood_disorders, i.stomach_pain, i.other_abdominal_disorder, i.kidney_bladder_disorder, i.back_injury, i.genetic_hereditary, i.sexually_transmit_disease, i.tropical_disease, i.asthma, i.allergies, i.gynecological_disorder, i.operations, i.operations_specify, i.others, i.consulted, i.consulted_specify, i.maintenance_meds);
            }
            R_Landbase_detailed.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_Landbase_detailed.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbase_detailed.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbase_detailed.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_Detailed");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_Detailed");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_Detailed");



            Viewer3.ReportSource = R_Landbase_detailed;
            RemoveTab(Viewer3);
            Cursor.Current = Cursors.Default;

        }



        public void Load_Summary()
        {

            wizard1.SelectedTab = tabPage1;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_Landbase_SummuryDataTable();
            R_lanabase_Summary R_lanabase_summary = new R_lanabase_Summary();

            var list = db.sp_Landbase_Summury(this.Tag.ToString());
            foreach (var i in list)
            {
                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.nationality, i.religion, i.country_destination,i.picture.ToArray(), i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.recommendation, i.medtech, i.ISHIHARA_C, i.SATISFACTORY_HEARING, i.SATISFACTORY_SIGHT_UNAID, i.VISUAL_AIDS, i.FIT_FOR_LOOKOUT);
            }

            R_lanabase_summary.SetDataSource(dt);


            TextObject FormNo = (TextObject)R_lanabase_summary.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lanabase_summary.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_lanabase_summary.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Landbase_Summary");
            RevNo.Text = ini.IniReadValue("REVISION", "Landbase_Summary");
            Iso.Text = ini.IniReadValue("ISO", "Landbase_Summary");



            Viewer1.ReportSource = R_lanabase_summary;
            RemoveTab(Viewer1);
            Cursor.Current = Cursors.Default;
        }


        private void Report_Landbase_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            //Load_Summary();
            //
            if (Summary)
            { backgroundWorker1.RunWorkerAsync(); }
            else if (Detailed)
            { backgroundWorker2.RunWorkerAsync(); }
            else if (MLC)
            { backgroundWorker3.RunWorkerAsync(); }
            else if (MER)
            {
                backgroundWorker4.RunWorkerAsync();

            }

        }

        private void Report_Landbase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Summary = false; Detailed = false; MLC = false; MER = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { Load_Summary(); }));
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { load_Detailed(); }));
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { Load_MLC(); }));
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { Load_MER(); }));
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { load_MER2(); }));
        }

        private void Report_Landbase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                PrintNow();
            }
        }
    }
}
