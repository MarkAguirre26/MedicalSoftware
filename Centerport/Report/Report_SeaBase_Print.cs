using Centerport.Dataset;
using Centerport.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;

namespace Centerport
{
    public partial class Report_SeaBase_Print : Form
    {
        public static bool Summary, Detail, MER, MLC1, MLC2, krpan;

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;

        public string MedCertNumber;
        public string recomendation;

        public Report_SeaBase_Print()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Load_Summary();
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


        void Load_Summary()
        {
            wizard1.SelectedTab = tabPage1;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_Seabase_SummaryDataTable();
            R_Seabase_Summary R_Seabase_summary = new R_Seabase_Summary();

            var list = db.sp_Seabase_Summary(this.Tag.ToString()).ToList();
            foreach (var i in list)
            {

                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.nationality, i.religion, i.sirb, i.designation, i.picture.ToArray(), i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.recommendation, i.medtech, i.restriction, i.ISHIHARA_C, i.SATISFACTORY_HEARING, i.SATISFACTORY_SIGHT_UNAID, i.VISUAL_AIDS, i.FIT_FOR_LOOKOUT);

            }
            //

            R_Seabase_summary.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_Seabase_summary.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_summary.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Seabase_summary.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Seafarer_Summary");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_Summary");
            Iso.Text = ini.IniReadValue("ISO", "Seafarer_Summary");


            Viewer1.ReportSource = R_Seabase_summary;
            RemoveTab(Viewer1);
            Cursor.Current = Cursors.Default;







        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Load_mlc();
        }
        public void Load_mlc()
        {

            wizard1.SelectedTab = tabPage2;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Seabase_MLC R_Seabase_MLC1 = new R_Seabase_MLC();
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_Seabase_MLCDataTable();

            var list = db.sp_Seabase_MLC(this.Tag.ToString()).ToList();
            foreach (var i in list)
            {

                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.nationality, i.religion, i.sirb, i.designation, i.picture.ToArray(), i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.recommendation, i.medtech, i.medtech_license, i.restriction, i.ISHIHARA_C, i.SATISFACTORY_HEARING, i.SATISFACTORY_SIGHT_UNAID, i.VISUAL_AIDS, i.FIT_FOR_LOOKOUT, i.VISUAL_AIDS_REQUIRED, i.UNAIDED_HEARING_SATISFACTORY, i.IDENTITY_CONFIRMED, i.VISUAL_AIDS_WORN);
            }
            R_Seabase_MLC1.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_iso"];
            TextObject TxtMedicalNumber = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_medicalNumber"];

            FormNo.Text = ini.IniReadValue("FORM", "Seafarer_MLC");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_MLC");
            Iso.Text = ini.IniReadValue("ISO", "Seafarer_MLC");
            TxtMedicalNumber.Text = "Medical Certification Number: " + MedCertNumber;

            Viewer2.ReportSource = R_Seabase_MLC1;
            RemoveTab(Viewer2);

        }


        public void Load_Mer()
        {
            wizard1.SelectedTab = tabPage4;
            tabControl1.SelectedTab = tabPage5;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Seabase_MER R_SeabaseMER1 = new R_Seabase_MER();
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report2.sp_Seabase_Mer1_SubDataTable();
            var list = db.sp_Seabase_Mer1_Sub(this.Tag.ToString()).ToList();
            var count = list.Count();
            foreach (var i in list)
            {
                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.seamansbook_no, i.nationality, i.religion, i.designation, i.picture.ToArray(), i.resultid, i.HEIGHT, i.WEIGHT, i.BP, i.PULSE, i.RESPIRATION, i.BODY_BUILD, i.FAR_OD_U, i.FAR_OD_C, i.FAR_OS_U, i.FAR_OS_C, i.NEAR_ODJ_U, i.NEAR_ODJ_C, i.NEAR_OSJ_U, i.NEAR_OSJ_C, i.ISHIHARA_U, i.ISHIHARA_C, i.HEARING_AD, i.HEARING_AS, i.CONVERSATIONAL_AS, i.HEARING_RIGHT, i.HEARING_LEFT, i.CLARITY_OF_SPEECH, i.BP_DIASTOLIC, i.RHYTHM, i.head_injury, i.frequent_headaches, i.frequent_dizziness, i.fainting_spells, i.insomnia, i.depression, i.trachoma, i.deafness, i.nose_throat_disorder, i.tuberculosis, i.other_lung_disorder, i.high_blood_pressure, i.heart_disease, i.rheumatic_fever, i.diabetes_mellitus, i.other_endocrine_disorder, i.cancer_tumor, i.blood_disorders, i.stomach_pain, i.other_abdominal_disorder, i.kidney_bladder_disorder, i.back_injury, i.genetic_hereditary, i.sexually_transmit_disease, i.asthma, i.allergies, i.gynecological_disorder, i.operations, i.operations_specify, i.schistosomiasis, i.last_menstrual_period, i.allergies_specify, i.other_abdominal_specify, i.column1, i.column2, i.column3, i.column4, i.column5, i.column6, i.column7, i.column7_comment, i.column8, i.column8_comment, i.column1_comment, i.column2_comment, i.column3_comment, i.column4_comment, i.column5_comment, i.column6_comment);
            }
            R_SeabaseMER1.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_SeabaseMER1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_SeabaseMER1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_SeabaseMER1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Seafarer_MER");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_MER");
            Iso.Text = ini.IniReadValue("ISO", "Seafarer_MER");
            Viewer4_1.ReportSource = R_SeabaseMER1;
            RemoveTab(Viewer4_1);




        }
        void load_Mer2()
        {
            wizard1.SelectedTab = tabPage4;
            tabControl1.SelectedTab = tabPage6;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            Seabase_MER_Page2 Seabase_MER_Page21 = new Seabase_MER_Page2();
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report1.sp_SeabaseMER2DataTable();

            var list = db.sp_SeabaseMER2(this.Tag.ToString()).ToList();
            foreach (var i in list)
            {
                dt.Rows.Add(i.FIT_FOR_LOOKOUT, i.VISUAL_AIDS_REQUIRED, i.resultid, i.result_date, i.valid_until, i.remMain, i.recommendation, i.specimen_no, i.medtech, i.medtech_license, i.restriction, i.basic_doh_exam, i.add_lab_tests, i.flag_medlab_req, i.deck_srvc_flag, i.engine_srvc_flag, i.catering_srvc_flag, i.other_srvc_flag, i.SKIN_TAG, i.SKIN, i.HEAD_NECK_SCALP_TAG, i.HEAD_NECK_SCALP, i.EYES_TAG, i.EYES, i.PUPILS_TAG, i.PUPILS, i.EARS_EARDRUM_TAG, i.EARS_EARDRUM, i.NOSE_SINUSES_TAG, i.NOSE_SINUSES, i.MOUTH_THROAT_TAG, i.MOUTH_THROAT, i.NECK_LN_THYROID_TAG, i.NECK_LN_THYROID, i.CHEST_BREAST_AXILLA_TAG, i.CHEST_BREAST_AXILLA, i.LUNGS_TAG, i.LUNGS, i.HEART_TAG, i.HEART, i.ABDOMEN_TAG, i.ABDOMEN, i.BACK_FLANK_TAG, i.BACK_FLANK, i.ANUS_RECTUM_TAG, i.ANUS_RECTUM, i.GU_SYSTEM_TAG, i.GU_SYSTEM, i.INGUINALS_GENITALS_TAG, i.INGUINALS_GENITALS, i.REFLEXES_TAG, i.REFLEXES, i.EXTREMITIES_TAG, i.EXTREMITIES, i.DENTAL, i.DENTAL_TAG, i.cxr, i.ecg, i.cbc, i.pregnancy_test, i.urinalysis, i.stool_exam, i.hbsag, i.hiv, i.rpr, i.blood_type, i.blood_chemistries, i.psychological_exam, i.additional_test, i.remarks, i.recommendation, i.additional_test2, i.lastname, i.firstname, i.middlename);
            }
            Seabase_MER_Page21.SetDataSource(dt);
            Seabase_MER_Page21.SetParameterValue("recomendation", recomendation);
            Viewer4_2.ReportSource = Seabase_MER_Page21;
            RemoveTab(Viewer4_2);



        }

        void load_krpan()
        {
            try
            {
                
                wizard1.SelectedTab = tabPage2;
                // tabControl1.SelectedTab = tabPage6;
                IniFile ini = new IniFile(ClassSql.MMS_Path);
                kpan kpan_rpeort = new kpan();
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                DataClasses2DataContext db2 = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
                DataTable dt = new ds_report2.sp_Seabase_MLCDataTable();

                var list = db.sp_Seabase_MLC(this.Tag.ToString()).ToList();
                foreach (var i in list)
                {

                    dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.nationality, i.religion, i.sirb, i.designation, i.picture.ToArray(), i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.recommendation, i.medtech, i.medtech_license, i.restriction, i.ISHIHARA_C, i.SATISFACTORY_HEARING, i.SATISFACTORY_SIGHT_UNAID, i.VISUAL_AIDS, i.FIT_FOR_LOOKOUT, i.VISUAL_AIDS_REQUIRED, i.UNAIDED_HEARING_SATISFACTORY, i.IDENTITY_CONFIRMED, i.VISUAL_AIDS_WORN);
                }

                var d = db.sp_Seabase_Deatail(this.Tag.ToString()).FirstOrDefault();
                var k = db2.sp_krpan_report(this.Tag.ToString()).FirstOrDefault();
                kpan_rpeort.SetDataSource(dt);
                kpan_rpeort.SetParameterValue("recomendation", recomendation);
                kpan_rpeort.SetParameterValue("Height", d.HEIGHT);
                kpan_rpeort.SetParameterValue("Weight", d.WEIGHT);

                string HEARING_LEFT = "";
                if (d.HEARING_LEFT == "A")
                {
                    HEARING_LEFT = "Adequate";
                }
                else
                {
                    HEARING_LEFT = "Indequate";
                }

                string HEARING_RIGHT = "";
                if (d.HEARING_RIGHT == "A")
                {
                    HEARING_RIGHT = "Adequate";
                }
                else
                {
                    HEARING_RIGHT = "Indequate";
                }
                kpan_rpeort.SetParameterValue("Hearing", "LT: " + HEARING_LEFT + "  RT: " + HEARING_RIGHT);
                kpan_rpeort.SetParameterValue("ColourVision", d.ISHIHARA_C);
                string blood_disorders = "";
                if (d.blood_disorders == "N")
                {
                    blood_disorders = "No";
                }
                else
                {
                    blood_disorders = "Yes";
                }
                kpan_rpeort.SetParameterValue("BloodDisoprder", blood_disorders);
                kpan_rpeort.SetParameterValue("Mantaldisorders", k.MentalDisorder);
                kpan_rpeort.SetParameterValue("CardiovascularSystem", k.Cardiovascular);
                kpan_rpeort.SetParameterValue("Geni", d.GU_SYSTEM);

                string diabetes_mellitus = "";
                if (d.diabetes_mellitus == "N")
                {
                    diabetes_mellitus = "No";
                }
                else
                {
                    diabetes_mellitus = "Yes";
                }

                kpan_rpeort.SetParameterValue("Diabetes", diabetes_mellitus);
                kpan_rpeort.SetParameterValue("Respiratoty", d.cxr);
                kpan_rpeort.SetParameterValue("Bp", d.BP);
                kpan_rpeort.SetParameterValue("BpType", d.blood_type);
                kpan_rpeort.SetParameterValue("VisualAcuty", d.VISUAL_AIDS);
                kpan_rpeort.SetParameterValue("CircumferenceChest", d.CHEST_BREAST_AXILLA);
                kpan_rpeort.SetParameterValue("Infections", k.Infection);
                kpan_rpeort.SetParameterValue("SkinDisorder", d.SKIN);
                kpan_rpeort.SetParameterValue("NervousSystem", k.NervousSystem);
                kpan_rpeort.SetParameterValue("DigestiveSystem", k.Digestive);
                kpan_rpeort.SetParameterValue("Liver", k.Liver);
                kpan_rpeort.SetParameterValue("Anemia", k.Anemia);
                kpan_rpeort.SetParameterValue("UrineandSyphilis", k.UrineSyphilisis);
                Viewer2.ReportSource = kpan_rpeort;
                RemoveTab(Viewer2);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Report not available", "No Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
        private void Report_SeaBase_Print_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            // Load_Summary();

            if (Summary)
            { backgroundWorker1.RunWorkerAsync(); }
            else if (Detail)
            { backgroundWorker2.RunWorkerAsync(); }
            else if (MLC1)
            { backgroundWorker3.RunWorkerAsync(); }
            else if (MER)
            { backgroundWorker4.RunWorkerAsync(); }
            else if (krpan)
            { backgroundWorker6.RunWorkerAsync(); }
        }


        void Detailed()
        {
            wizard1.SelectedTab = tabPage3;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            R_SeabaseDetailed R_SeabaseDetailed1 = new R_SeabaseDetailed();
            DataTable dt = new ds_report2.sp_Seabase_DeatailDataTable();
            var list = db.sp_Seabase_Deatail(this.Tag.ToString()).ToList();

            foreach (var i in list)
            {

                dt.Rows.Add(i.lastname, i.firstname, i.middlename, i.address_1, i.contact_1, i.position, i.marital_status, i.gender, i.birthdate, i.place_of_birth, i.employer, i.passport_no, i.seamansbook_no, i.nationality, i.religion, i.picture.ToArray(), i.resultid, i.result_date, i.pathologist, i.fitness_date, i.valid_until, i.remMain, i.recommendation, i.specimen_no, i.medtech, i.cxr, i.ecg, i.cbc, i.pregnancy_test, i.urinalysis, i.stool_exam, i.hbsag, i.hiv, i.rpr, i.blood_type, i.psychological_exam, i.additional_test, i.remarks, i.additional_test2, i.SKIN_TAG, i.SKIN, i.HEAD_NECK_SCALP_TAG, i.HEAD_NECK_SCALP, i.EYES_TAG, i.EYES, i.PUPILS_TAG, i.PUPILS, i.EARS_EARDRUM_TAG, i.EARS_EARDRUM, i.NOSE_SINUSES_TAG, i.NOSE_SINUSES, i.MOUTH_THROAT_TAG, i.MOUTH_THROAT, i.NECK_LN_THYROID_TAG, i.NECK_LN_THYROID, i.CHEST_BREAST_AXILLA_TAG, i.CHEST_BREAST_AXILLA, i.LUNGS_TAG, i.LUNGS, i.HEART_TAG, i.HEART, i.ABDOMEN_TAG, i.ABDOMEN, i.BACK_FLANK_TAG, i.BACK_FLANK, i.ANUS_RECTUM_TAG, i.ANUS_RECTUM, i.GU_SYSTEM_TAG, i.GU_SYSTEM, i.INGUINALS_GENITALS_TAG, i.INGUINALS_GENITALS, i.REFLEXES_TAG, i.REFLEXES, i.EXTREMITIES_TAG, i.EXTREMITIES, i.DENTAL, i.DENTAL_TAG, i.HEIGHT, i.WEIGHT, i.BP, i.PULSE, i.RESPIRATION, i.BODY_BUILD, i.FAR_OD_U, i.FAR_OD_C, i.FAR_OS_U, i.FAR_OS_C, i.NEAR_ODJ_U, i.NEAR_ODJ_C, i.NEAR_OSJ_U, i.NEAR_OSJ_C, i.ISHIHARA_U, i.ISHIHARA_C, i.HEARING_AD, i.HEARING_AS, i.CONVERSATIONAL_AD, i.CONVERSATIONAL_AS, i.BP_DIASTOLIC, i.head_injury, i.frequent_headaches, i.frequent_dizziness, i.fainting_spells, i.insomnia, i.depression, i.trachoma, i.deafness, i.nose_throat_disorder, i.tuberculosis, i.other_lung_disorder, i.high_blood_pressure, i.heart_disease, i.rheumatic_fever, i.diabetes_mellitus, i.other_endocrine_disorder, i.cancer_tumor, i.blood_disorders, i.stomach_pain, i.other_abdominal_disorder, i.kidney_bladder_disorder, i.back_injury, i.genetic_hereditary, i.sexually_transmit_disease, i.tropical_disease, i.asthma, i.allergies, i.gynecological_disorder, i.operations, i.operations_specify, i.others, i.consulted, i.consulted_specify, i.maintenance_meds, i.allergies_specify, i.resultid);

            }

            R_SeabaseDetailed1.SetDataSource(dt);
            TextObject FormNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject ISO = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("REVISION", "Seafarer_Detailed");
            RevNo.Text = ini.IniReadValue("REVISION", "Seafarer_Detailed");
            ISO.Text = ini.IniReadValue("ISO", "Seafarer_Detailed");

            //R_SeabaseDetailed1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));
            //R_SeabaseDetailed1.Load(@"C:\Report\R_SeabaseDetailed.rpt");
            //Viewer3.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            Viewer3.ReportSource = R_SeabaseDetailed1;
            RemoveTab(Viewer3);

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_SeaBase_Print_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                PrintNow();
            }
        }

        private void Report_SeaBase_Print_FormClosing(object sender, FormClosingEventArgs e)
        {
            Summary = false; Detail = false; MLC1 = false; MLC2 = false; MER = false;
        }
        void PrintNow()
        {

            try
            {

                if (Summary)
                {

                    Viewer1.PrintReport();
                }
                else if (MLC1)
                {

                    Viewer2.PrintReport();
                }
                else if (Detail)
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
        private void button3_Click_1(object sender, EventArgs e)
        {
            PrintNow();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            { backgroundWorker4.RunWorkerAsync(); }
            else if (tabControl1.SelectedIndex == 1)
            { backgroundWorker5.RunWorkerAsync(); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { Load_Summary(); }));
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { Detailed(); }));
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { Load_mlc(); }));
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { Load_Mer(); }));
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke(new MethodInvoker(delegate() { load_Mer2(); }));
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { load_krpan(); }));
        }

    }
}
