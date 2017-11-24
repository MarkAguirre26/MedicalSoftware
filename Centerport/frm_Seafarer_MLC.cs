using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ini;
using System.IO;
using Centerport.Class;


namespace Centerport
{
    public partial class frm_Seafarer_MLC : Form, MyInter
    {
        Main fmain; public static bool NewSeafarer; public static TextBox pin; public static TextBox LabID;
        public static string cn_MLCFromResultMain;
        public static string Action; public static bool Count;
        private string MedtectLicence = "-";
        private string IDENTITY_CONFIRMED_ = "-";
        private string SATISFACTORY_HEARING_ = "-";
        private string UNAIDED_HEARING_SATISFACTORY_ = "-";
        private string VISUAL_AIDS_ = "-";
        private string ISHIHARA_C_ = "-";
        private string VISUAL_AIDS_WORN_ = "-";
        private string FIT_FOR_LOOKOUT_ = "-";
        private string VISUAL_AIDS_REQUIRED_ = "-";
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public List<Seafarer_SearchList_MLC> Seafarer_SearchList_model = new List<Seafarer_SearchList_MLC>();
        public List<QueueSearchList_Model> SeafarerAdd_model = new List<QueueSearchList_Model>();

        public frm_Seafarer_MLC(Main mainn)
        {
            InitializeComponent();
            pin = txt_Papin;
            LabID = txt_resultID;
            fmain = mainn;
        }


        public void New()
        {

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            cbo_medtech.Text = ini.IniReadValue("MEDICAL", "PEME_Physician");
            txt_pathologist.Text = ini.IniReadValue("MEDICAL", "PEME MedicalDirector");
            MedtectLicence = ini.IniReadValue("MEDICAL", "PEME_Physician_license");
            cbo_recomendation.Text = "FIT FOR SEA DUTY";
           
          



        }
        public void Save()
        {


            if (NewSeafarer)
            {
                insert();
            }
            else
            {

                Update_MLC();





            }




        }

        void insert()
        {
            try
            {


                //if (r1_Y.Checked == true) { IDENTITY_CONFIRMED_ = "YES"; } else { IDENTITY_CONFIRMED_ = "NO"; }
                //if (r2_Y.Checked == true) { SATISFACTORY_HEARING_ = "YES"; } else { SATISFACTORY_HEARING_ = "NO"; }
                //if (r3_Y.Checked == true) { UNAIDED_HEARING_SATISFACTORY_ = "YES"; } else { UNAIDED_HEARING_SATISFACTORY_ = "NO"; }
                //if (r4_Y.Checked == true) { VISUAL_AIDS_ = "YES"; } else { VISUAL_AIDS_ = "NO"; }
                //if (r5_Y.Checked == true) { ISHIHARA_C_ = "YES"; } else { ISHIHARA_C_ = "NO"; }
                //if (r6_Y.Checked == true) { VISUAL_AIDS_WORN_ = "SPECTACLES"; } else { VISUAL_AIDS_WORN_ = "CONTACTLENS"; }
                //if (r7_Y.Checked == true) { FIT_FOR_LOOKOUT_ = "YES"; } else { FIT_FOR_LOOKOUT_ = "NO"; }
                //if (r8_Y.Checked == true) { VISUAL_AIDS_REQUIRED_ = "YES"; } else { VISUAL_AIDS_REQUIRED_ = "NO"; }

                if (r1_Y.Checked == true) { IDENTITY_CONFIRMED_ = "YES"; } else if (r1_N.Checked == true) { IDENTITY_CONFIRMED_ = "NO"; } else { IDENTITY_CONFIRMED_ = "-"; }
                if (r2_Y.Checked == true) { SATISFACTORY_HEARING_ = "YES"; } else if (r2_N.Checked == true) { SATISFACTORY_HEARING_ = "NO"; } else { SATISFACTORY_HEARING_ = "-"; }
                if (r3_Y.Checked == true) { UNAIDED_HEARING_SATISFACTORY_ = "YES"; } else if (r3_N.Checked == true) { UNAIDED_HEARING_SATISFACTORY_ = "NO"; } else { UNAIDED_HEARING_SATISFACTORY_ = "-"; }
                if (r4_Y.Checked == true) { VISUAL_AIDS_ = "YES"; } else if (r4_N.Checked == true) { VISUAL_AIDS_ = "NO"; } else { VISUAL_AIDS_ = "-"; }
                if (r5_Y.Checked == true) { ISHIHARA_C_ = "YES"; } else if (r5_N.Checked == true) { ISHIHARA_C_ = "NO"; } else { ISHIHARA_C_ = "-"; }
                if (r6_Y.Checked == true) { VISUAL_AIDS_WORN_ = "SPECTACLES"; } else if (r6_N.Checked == true) { VISUAL_AIDS_WORN_ = "CONTACTLENS"; } else { VISUAL_AIDS_WORN_ = "-"; }
                if (r7_Y.Checked == true) { FIT_FOR_LOOKOUT_ = "YES"; } else if (r7_N.Checked == true) { FIT_FOR_LOOKOUT_ = "NO"; } else { FIT_FOR_LOOKOUT_ = "-"; }
                if (r8_Y.Checked == true) { VISUAL_AIDS_REQUIRED_ = "YES"; } else if (r8_N.Checked == true) { VISUAL_AIDS_REQUIRED_ = "NO"; } else { VISUAL_AIDS_REQUIRED_ = "-"; }

                //`resultid`,    `HEIGHT`, `WEIGHT`, `BP`, `PULSE`, `RESPIRATION`, `BODY_BUILD`, `FAR_OD_U`, `FAR_OD_C`, `FAR_OS_U`, `FAR_OS_C`, `NEAR_ODJ_U`, `NEAR_ODJ_C`, `NEAR_OSJ_U`, `NEAR_OSJ_C`, `ISHIHARA_U`, `ISHIHARA_C`,                    `HEARING_AD`, `HEARING_AS`, `SPEECH`, `CONVERSATIONAL_AD`, `CONVERSATIONAL_AS`, `SATISFACTORY_HEARING`,                      `SATISFACTORY_SIGHT_AID`,         `SATISFACTORY_SIGHT_UNAID`,                     `SATISFACTORY_PSYCHO`, `VISUAL_AIDS`,                    `FIT_FOR_LOOKOUT`,              `HEARING_RIGHT`, `HEARING_LEFT`, `CLARITY_OF_SPEECH`, `VISUAL_AIDS_REQUIRED`, `BP_DIASTOLIC`, `RHYTHM`, `VISUAL_AIDS_WORN`, `COLOR_VISION_DATE_TAKEN`, `UNAIDED_HEARING_SATISFACTORY`, `IDENTITY_CONFIRMED`
                //string a = "INSERT INTO `t_phy_exam` (`resultid`, `HEIGHT`, `WEIGHT`, `BP`, `PULSE`, `RESPIRATION`, `BODY_BUILD`, `FAR_OD_U`, `FAR_OD_C`, `FAR_OS_U`, `FAR_OS_C`, `NEAR_ODJ_U`, `NEAR_ODJ_C`, `NEAR_OSJ_U`, `NEAR_OSJ_C`, `ISHIHARA_U`, `ISHIHARA_C`, `HEARING_AD`, `HEARING_AS`, `SPEECH`, `CONVERSATIONAL_AD`, `CONVERSATIONAL_AS`, `SATISFACTORY_HEARING`, `SATISFACTORY_SIGHT_AID`, `SATISFACTORY_SIGHT_UNAID`, `SATISFACTORY_PSYCHO`, `VISUAL_AIDS`, `FIT_FOR_LOOKOUT`, `HEARING_RIGHT`, `HEARING_LEFT`, `CLARITY_OF_SPEECH`, `VISUAL_AIDS_REQUIRED`, `BP_DIASTOLIC`, `RHYTHM`, `VISUAL_AIDS_WORN`, `COLOR_VISION_DATE_TAKEN`, `UNAIDED_HEARING_SATISFACTORY`, `IDENTITY_CONFIRMED`) VALUES ('" + LabID.Text + "', '',      '',        '',   '',         '',            '',          '',        '',         '',         '',         '',             '',          '',             '',        '',       '" + ISHIHARA_C_.ToString() + "',      '',          '',        '',         '',                     '',          '" + SATISFACTORY_HEARING_.ToString() + "',            '',                        '"+VISUAL_AIDS_REQUIRED_+"',                          '',        '" + VISUAL_AIDS_.ToString() + "', '" + FIT_FOR_LOOKOUT_.ToString() + "', '',               '',                    '',      '',          '',                   '',       '" + VISUAL_AIDS_WORN_.ToString() + "',          '" + dt_date.Text + "', '" + UNAIDED_HEARING_SATISFACTORY_.ToString() + "', '" + IDENTITY_CONFIRMED_.ToString() + "' )";
                // string b = "INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + LabID.Text + "', 'SEAMLC', '" + pin.Text + "', '" + dt_ResDate.Text + "', '" + Tool.ReplaceString(txt_pathologist.Text) + "', 'PENDING',   '" + dt_fitness_Date.Text + "',      '" + dt_ValidUntil.Text + "',            '',                  '" + Tool.ReplaceString(cbo_recomendation.Text) + "',               '',                 '" + Tool.ReplaceString(txt_specimen.Text) + "',               '" + Tool.ReplaceString(cbo_medtech.Text) + "', '" + MedtectLicence.ToString() + "',                '',                 '" + LabID.Text + "',              '" + Tool.ReplaceString(txt_restriction.Text) + "',             '',                  '',            '',             '',                 '',                 '',                     '')";
                db.ExecuteCommand("INSERT INTO t_phy_exam (resultid, HEIGHT, WEIGHT, BP, PULSE, RESPIRATION, BODY_BUILD, FAR_OD_U, FAR_OD_C, FAR_OS_U, FAR_OS_C, NEAR_ODJ_U, NEAR_ODJ_C, NEAR_OSJ_U, NEAR_OSJ_C, ISHIHARA_U, ISHIHARA_C, HEARING_AD, HEARING_AS, SPEECH, CONVERSATIONAL_AD, CONVERSATIONAL_AS, SATISFACTORY_HEARING, SATISFACTORY_SIGHT_AID, SATISFACTORY_SIGHT_UNAID, SATISFACTORY_PSYCHO, VISUAL_AIDS, FIT_FOR_LOOKOUT, HEARING_RIGHT, HEARING_LEFT, CLARITY_OF_SPEECH, VISUAL_AIDS_REQUIRED, BP_DIASTOLIC, RHYTHM, VISUAL_AIDS_WORN, COLOR_VISION_DATE_TAKEN, UNAIDED_HEARING_SATISFACTORY, IDENTITY_CONFIRMED) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37})", LabID.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ISHIHARA_C_.ToString(), "", "", "", "", "", SATISFACTORY_HEARING_.ToString(), "", VISUAL_AIDS_REQUIRED_, "", VISUAL_AIDS_.ToString(), FIT_FOR_LOOKOUT_.ToString(), "", "", "", "", "", "", VISUAL_AIDS_WORN_.ToString(), dt_date.Text, UNAIDED_HEARING_SATISFACTORY_.ToString(), IDENTITY_CONFIRMED_.ToString());
                db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", LabID.Text, "SEAMLC", pin.Text, dt_ResDate.Text, txt_pathologist.Text, "PENDING", dt_fitness_Date.Text, dt_ValidUntil.Text, "", cbo_recomendation.Text, "", txt_specimen.Text, cbo_medtech.Text, MedtectLicence.ToString(), "", LabID.Text, txt_restriction.Text, "", "", "", "", "", "", "");
                //var arr = new[] { a, b };
                //File.WriteAllLines(ClassSql.tmp_path, arr);
                Seafarer_SearchList_model.Clear();
                SeafarerAdd_model.Clear();
                if (!backgroundWorker1.IsBusy)
                { backgroundWorker1.RunWorkerAsync(); }

                //Tool.MessageBoxSave();
                Availability(false);
                fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = true; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}





        }

        public void Update_MLC()
        {
            try
            {

                if (r1_Y.Checked == true) { IDENTITY_CONFIRMED_ = "YES"; } else if (r1_N.Checked == true) { IDENTITY_CONFIRMED_ = "NO"; } else { IDENTITY_CONFIRMED_ = "-"; }
                if (r2_Y.Checked == true) { SATISFACTORY_HEARING_ = "YES"; } else if (r2_N.Checked == true) { SATISFACTORY_HEARING_ = "NO"; } else { SATISFACTORY_HEARING_ = "-"; }
                if (r3_Y.Checked == true) { UNAIDED_HEARING_SATISFACTORY_ = "YES"; } else if (r3_N.Checked == true) { UNAIDED_HEARING_SATISFACTORY_ = "NO"; } else { UNAIDED_HEARING_SATISFACTORY_ = "-"; }
                if (r4_Y.Checked == true) { VISUAL_AIDS_ = "YES"; } else if (r4_N.Checked == true) { VISUAL_AIDS_ = "NO"; } else { VISUAL_AIDS_ = "-"; }
                if (r5_Y.Checked == true) { ISHIHARA_C_ = "YES"; } else if (r5_N.Checked == true) { ISHIHARA_C_ = "NO"; } else { ISHIHARA_C_ = "-"; }
                if (r6_Y.Checked == true) { VISUAL_AIDS_WORN_ = "SPECTACLES"; } else if (r6_N.Checked == true) { VISUAL_AIDS_WORN_ = "CONTACTLENS"; } else { VISUAL_AIDS_WORN_ = "-"; }
                if (r7_Y.Checked == true) { FIT_FOR_LOOKOUT_ = "YES"; } else if (r7_N.Checked == true) { FIT_FOR_LOOKOUT_ = "NO"; } else { FIT_FOR_LOOKOUT_ = "-"; }
                if (r8_Y.Checked == true) { VISUAL_AIDS_REQUIRED_ = "YES"; } else if (r8_N.Checked == true) { VISUAL_AIDS_REQUIRED_ = "NO"; } else { VISUAL_AIDS_REQUIRED_ = "-"; }

                //ClassSql a = new ClassSql();              //IDENTITY_CONFIRMED                                     //SATISFACTORY_HEARING                                     //UNAIDED_HEARING_SATISFACTORY                                     //VISUAL_AIDS                                     //ISHIHARA_C                                     //VISUAL_AIDS_WORN                                      //FIT_FOR_LOOKOUT                                     //VISUAL_AIDS_REQUIRED
                // string a = "UPDATE `t_phy_exam`  SET `ISHIHARA_C`={0}, `SATISFACTORY_HEARING`={1},`VISUAL_AIDS`={2}, `FIT_FOR_LOOKOUT`={3}, `SATISFACTORY_SIGHT_UNAID`={4},  `VISUAL_AIDS_WORN`={5}, `COLOR_VISION_DATE_TAKEN`={6}, `UNAIDED_HEARING_SATISFACTORY`={7}, `IDENTITY_CONFIRMED`={8} WHERE (`resultid`={9})";
                //string b = "UPDATE `t_result_main` SET `recommendation`='" + Tool.ReplaceString(cbo_recomendation.Text) + "',`restriction`='" + Tool.ReplaceString(txt_restriction.Text) + "',`result_date`='" + Tool.ReplaceString(dt_ResDate.Text) + "',  `fitness_date`='" + Tool.ReplaceString(dt_fitness_Date.Text) + "', `valid_until`='" + Tool.ReplaceString(dt_ValidUntil.Text) + "',`medtech`='" + Tool.ReplaceString(cbo_medtech.Text) + "', `medtech_license` = '" + MedtectLicence.ToString() + "',`pathologist`='" + Tool.ReplaceString(txt_pathologist.Text) + "',`specimen_no`='" + Tool.ReplaceString(txt_specimen.Text) + "' WHERE (`cn`='" + cn_MLCFromResultMain + "') LIMIT 1";
                db.ExecuteCommand("UPDATE t_phy_exam  SET ISHIHARA_C={0}, SATISFACTORY_HEARING={1},VISUAL_AIDS={2}, FIT_FOR_LOOKOUT={3}, SATISFACTORY_SIGHT_UNAID={4},  VISUAL_AIDS_WORN={5}, COLOR_VISION_DATE_TAKEN={6}, UNAIDED_HEARING_SATISFACTORY={7}, IDENTITY_CONFIRMED={8} WHERE resultid={9}", ISHIHARA_C_.ToString(), SATISFACTORY_HEARING_.ToString(), VISUAL_AIDS_.ToString(), FIT_FOR_LOOKOUT_.ToString(), VISUAL_AIDS_REQUIRED_.ToString(), VISUAL_AIDS_WORN_.ToString(), dt_date.Text, UNAIDED_HEARING_SATISFACTORY_.ToString(), IDENTITY_CONFIRMED_.ToString(), LabID.Text);
                db.ExecuteCommand("UPDATE t_result_main SET recommendation={0},restriction={1},result_date={2},  fitness_date={3}, valid_until={4},medtech={5}, medtech_license = {6},pathologist={7},specimen_no={8} WHERE cn={9}", cbo_recomendation.Text, txt_restriction.Text, dt_ResDate.Text, dt_fitness_Date.Text, dt_ValidUntil.Text, cbo_medtech.Text, MedtectLicence.ToString(), txt_pathologist.Text, txt_specimen.Text, cn_MLCFromResultMain);
                //Tool.MessageBoxUpdate();

                //Search_PhyExam(); search_Recomendation();
                //var arr = new[] { a, b };
                // File.WriteAllLines(ClassSql.tmp_path, arr);     

                NewSeafarer = true;
                fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = true; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = true;
                Availability(false);




            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }

        //public void Update_Recomendation()
        //{
        //    try
        //    {

        //        ClassSql a = new ClassSql();
        //                search_Recomendation();



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }


        //}


        public void Edit()
        {
         
            if (fmain.UserLevel == 1 || fmain.UserLevel == 2 )
            {
                NewSeafarer = false;
                Availability(true);
                fmain.ts_add_mlc.Enabled = false; fmain.ts_edit_mlc.Enabled = false; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = true; fmain.ts_cancel_mlc.Enabled = true; fmain.ts_search_mlc.Enabled = false; fmain.ts_print_mlc.Enabled = false;

            }
            else
            {
                if (MessageBox.Show("You do not have enough access privileges for this operation, Please use RELEASING account. \n Would you like to continue?", "Action Denied!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    new frm_login(fmain).ShowDialog();
                }

            }

        }
        public void Delete()
        {
            //Delete_Record();
        }
        //void Delete_Record()
        //{

        //    try
        //    {


        //        ClassSql a = new ClassSql();
        //        a.ExecuteQuery("Delete from t_phy_exam where resultid = '" + LabID.Text + "' and resulttype= 'SEAMLC'");
        //        a.ExecuteQuery("Delete from t_result_main where resultid = '" + LabID.Text + "' and resulttype= 'SEAMLC'");

        //        Tool.MessageBoxDelete();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }

        //}
        public void Cancel()
        {
            if (NewSeafarer)
            {
                Tool.ClearFields(groupBox5);
                txt_Papin.Clear();
                ClearAll();
                Availability(false);

                fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = false; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = false;

            }
            else
            {

                Availability(false);
                ClearAll();
                Search_Patient(); Search_PhyExam(); search_Recomendation();
                fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = true; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = true; fmain.ts_cancel_mlc.Enabled = false;
            }


        }
        public void Print()
        {
            //Report.Report_PrintOuts frm_mlc = new Report.Report_PrintOuts();
            //frm_mlc.Tag = LabID.Text;
            //frm_mlc.MLC = true;
            //frm_mlc.ShowDialog();

            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.Tag = LabID.Text;
            //    f.isSeaMLC = true;
            //    f.age = txt_age.Text;
            //    f.ShowDialog();
            //}

            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print f = new Report_SeaBase_Print();
            Report_SeaBase_Print.MLC1 = true;
            f.MedCertNumber = txt_specimen.Text;
            f.Tag = LabID.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;

            //using (frm_MLC_Print f = new frm_MLC_Print())

            //{

            //    f.resultid = LabID.Text;
            //    f.Age = txt_age.Text;
            //    f.ShowDialog();
            //}   
        }
        public void Search()
        {


        }
        private void frm_MedCertificate_ServiceAtSea_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.MedCertificate = true;
            // fmain.Strip_sub.Visible = true;
            fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = false; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = false;
            ClassSql.DbClose();
        }

        private void frm_MedCertificate_ServiceAtSea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (fmain.ts_cancel_mlc.Enabled == true)
                { Cancel(); }
                else
                { this.Close(); }

            }
            else if (e.KeyCode == Keys.Add && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_add_mlc.Enabled == true)
                {

                    fmain.add_mlc();
                }
            }

            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_save_mlc.Enabled == true)
                {
                    Save();

                }

            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_print_mlc.Enabled == true)
                {
                    Print();
                }
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {

                if (fmain.ts_search_mlc.Enabled == true)
                {
                    fmain.Search_MLC();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (fmain.ts_edit_mlc.Enabled == true)
                {
                    Edit();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (fmain.ts_delete_mlc.Enabled == true)
                {

                    Delete();
                }

            }
        }

        private void frm_MedCertificate_ServiceAtSea_Load(object sender, EventArgs e)
        {
            cbo_recomendation.Text = "FIT FOR SEA DUTY";
            Availability(false);
            Cursor.Current = Cursors.Default;
            Load_Medical();
            //if (!Directory.Exists(ClassSql.SeabaseImage))
            //{
            //    DirectoryInfo di = Directory.CreateDirectory(ClassSql.SeabaseImage);
            //}




        }
        void Load_Medical()
        {

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            List<string> list = new List<string>();
            // ArrayList list = new ArrayList();
            list.Add(ini.IniReadValue("MEDICAL", "PEME_Physician"));
            list.Add(ini.IniReadValue("MEDICAL", "PEME MedicalDirector"));
            foreach (string item in list)
            {
                cbo_medtech.Items.Add(item);
            }

        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }


        //}

        //void Search_Patient_sub()
        //{
        //    try
        //    {

        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.address_1, m_patient.address_2, m_patient.contact_1, m_patient.contact_2,   m_patient.`position`, m_patient.marital_status,  m_patient.gender, m_patient.place_of_birth, m_patient.employer, m_patient.passport_no, m_patient.nationality, m_patient.religion FROM t_result_main  Inner Join m_patient ON t_result_main.papin = m_patient.papin Where t_result_main.papin =  '" + Tool.ReplaceString(this.txt_Papin.Text) + "'");

        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            LabID.Text = dr["resultid"].ToString();
        //            txtlastname.Text = dr["lastname"].ToString();
        //            txtFirstname.Text = dr["firstname"].ToString();
        //            txtMiddleName.Text = dr["middlename"].ToString();
        //            txt_pBirth.Text = dr["place_of_birth"].ToString();
        //            txt_nationality.Text = dr["nationality"].ToString();
        //            txt_add.Text = dr["address_1"].ToString();
        //            txt_employer.Text = dr["employer"].ToString();
        //            txt_passno.Text = dr["passport_no"].ToString();
        //            txt_gender.Text = dr["gender"].ToString();
        //            txt_position.Text = dr["position"].ToString();
        //            txt_rel.Text = dr["religion"].ToString();
        //            txt_status.Text = dr["marital_status"].ToString();
        //            txt_contact.Text = dr["contact_1"].ToString();


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }


        //}

        public void Search_Patient()
        {
            try
            {

                //  ClassSql a = new ClassSql(); DataTable dt;

                ////  dt = a.Table("SELECT * FROM m_patient  WHERE  papin =   '" + Tool.ReplaceString(pin.Text) + "'");
                //  dt = a.Mytable_Proc("SeaMLC_Patient", "@SearchID", pin.Text);
                var i = db.sp_Seafarer_Patient(pin.Text).FirstOrDefault();

                //foreach (DataRow dr in dt.Rows)
                //{


                txtlastname.Text = i.lastname.ToString();
                txtFirstname.Text = i.firstname.ToString();
                txtMiddleName.Text = i.middlename.ToString();


                txt_pBirth.Text = i.place_of_birth.ToString();
                txt_bday.Text = i.birthdate.ToString();


                txt_nationality.Text = i.nationality.ToString();
                txt_add.Text = i.address_1.ToString();
                txt_employer.Text = i.employer.ToString();
                txt_passno.Text = i.passport_no.ToString();
                txt_gender.Text = i.gender.ToString();
                txt_position.Text = i.position.ToString();
                txt_rel.Text = i.religion.ToString();
                txt_status.Text = i.marital_status.ToString();
                txt_contact.Text = i.contact_1.ToString();

                //if (i.picture != null)
                //{
                //    byte[] b = i.picture.ToArray();
                //    MemoryStream ms = new MemoryStream(b);
                //    Image img = Image.FromStream(ms);
                //    using (var newImg = Tool.ScaleImage(img, 150, 200))
                //    {
                //        img.Save(ClassSql.SeabaseImage + "\\tmp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //    }

                //}

                // }
               

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}


        }

        public void Availability(bool bl)
        {

            if (bl == true)
            { overlayShadow1.Visible = false; overlayShadow1.SendToBack(); }
            else
            { overlayShadow1.Visible = true; overlayShadow1.BringToFront(); txt_Papin.Select(); }

        }
        public void ClearAll()
        {

            Tool.ClearFields(panel10);
            Tool.ClearFields(panel45);
            Tool.ClearFields(panel3);
            Tool.ClearFields(panel4);
            Tool.ClearFields(panel5);
            Tool.ClearFields(panel6);
            Tool.ClearFields(panel8);
            Tool.ClearFields(panel7);
            Tool.ClearFields(panel9);
            Tool.ClearFields(groupBox2);


        }

        public void ClearGroupBox()
        {
            //Tool.ClearFields(panel10);
            //Tool.ClearFields(panel45);
            //Tool.ClearFields(panel3);
            //Tool.ClearFields(panel4);
            //Tool.ClearFields(panel5);
            //Tool.ClearFields(panel6);
            //Tool.ClearFields(panel8);
            //Tool.ClearFields(panel7);
            //Tool.ClearFields(panel9);         

            r1_Y.Checked = true;
            r2_Y.Checked = true;
            r3_Y.Checked = true;
            r4_Y.Checked = true;
            r5_Y.Checked = true;
            r7_Y.Checked = true;
            r8_N.Checked = true;

            Tool.ClearFields(groupBox2);
        }

        public void Search_PhyExam()
        {
            try
            {

                //ClassSql a = new ClassSql(); DataTable dt;
                //// dt = a.Table("SELECT * FROM t_phy_exam WHERE  resultid =  '" + Tool.ReplaceString(LabID.Text) + "' ");
                //dt = a.Mytable_Proc("SeaMLC_PhyExam", "@SearchID", LabID.Text);
                var i = db.sp_Seafarer_PhyExam(LabID.Text).FirstOrDefault();
                //foreach (DataRow dr in dt.Rows)
                //{
                lbl_pHy_Exam_Cn.Tag = i.cn.ToString();
                string IDENTITY_CONFIRMED = i.IDENTITY_CONFIRMED.ToString();
                if (IDENTITY_CONFIRMED == "YES") { r1_Y.Checked = true; } else if (IDENTITY_CONFIRMED == "NO") { r1_N.Checked = true; }

                string SATISFACTORY_HEARING = i.SATISFACTORY_HEARING.ToString();
                if (SATISFACTORY_HEARING == "YES") { r2_Y.Checked = true; } else if (SATISFACTORY_HEARING == "NO") { r2_N.Checked = true; }

                string UNAIDED_HEARING_SATISFACTORY = i.UNAIDED_HEARING_SATISFACTORY.ToString();
                if (UNAIDED_HEARING_SATISFACTORY == "YES") { r3_Y.Checked = true; } else if (UNAIDED_HEARING_SATISFACTORY == "NO") { r3_N.Checked = true; }

                string VISUAL_AIDS = i.VISUAL_AIDS.ToString();
                if (VISUAL_AIDS == "YES") { r4_Y.Checked = true; } else if (VISUAL_AIDS == "NO") { r4_N.Checked = true; }

                string ISHIHARA_C = i.ISHIHARA_C.ToString();
                if (ISHIHARA_C == "YES") { r5_Y.Checked = true; } else if (ISHIHARA_C == "NO") { r5_N.Checked = true; }

                //  dt_date.Text = dr["COLOR_VISION_DATE_TAKEN"].ToString();

                DateTime temp;
                if (DateTime.TryParse(i.COLOR_VISION_DATE_TAKEN.ToString(), out temp))
                {
                    dt_date.Format = DateTimePickerFormat.Custom;
                    dt_date.CustomFormat = "MM/dd/yyyy";

                    dt_date.Value = Convert.ToDateTime(i.COLOR_VISION_DATE_TAKEN.ToString()).Date;
                }
                else
                {

                    dt_date.Format = DateTimePickerFormat.Custom;
                    dt_date.CustomFormat = "00/00/0000";

                }

                string VISUAL_AIDS_WORN = i.VISUAL_AIDS_WORN.ToString();
                if (VISUAL_AIDS_WORN == "SPECTACLES") { r6_Y.Checked = true; } else if (VISUAL_AIDS_WORN == "CONTACTLENS") { r6_N.Checked = true; }
                string FIT_FOR_LOOKOUT = i.FIT_FOR_LOOKOUT.ToString();
                if (FIT_FOR_LOOKOUT == "YES") { r7_Y.Checked = true; } else if (FIT_FOR_LOOKOUT == "NO") { r7_N.Checked = true; }
                string VISUAL_AIDS_REQUIRED = i.SATISFACTORY_SIGHT_UNAID.ToString();
                if (VISUAL_AIDS_REQUIRED == "YES") { r8_Y.Checked = true; } else if (VISUAL_AIDS_REQUIRED == "NO") { r8_N.Checked = true; }
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}

        }

        public void search_Recomendation()
        {

            try
            {


                //ClassSql a = new ClassSql(); DataTable dt;             

                //dt = a.Mytable_Proc("SeaMLC_Recomendation", "@SearchID", pin.Text);
                //var i = db.sp_MLC_Recomendation(pin.Text).FirstOrDefault();
                var i = db.sp_MLC_Recomendation(LabID.Text).FirstOrDefault();
                //foreach (DataRow dr in dt.Rows)
                //{

                lbl_reco_cn.Tag = i.cn.ToString();
                cn_MLCFromResultMain = i.cn.ToString();
                cbo_recomendation.Text = i.recommendation.ToString();
                this.txt_restriction.Text = i.restriction.ToString();
                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    dt_ResDate.Format = DateTimePickerFormat.Custom;
                    dt_ResDate.CustomFormat = "MM/dd/yyyy";
                    dt_ResDate.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {

                    dt_ResDate.Format = DateTimePickerFormat.Custom;
                    dt_ResDate.CustomFormat = "00/00/0000";

                }


                DateTime temp2;
                if (DateTime.TryParse(i.fitness_date.ToString(), out temp2))
                {
                    dt_fitness_Date.Format = DateTimePickerFormat.Custom;
                    dt_fitness_Date.CustomFormat = "MM/dd/yyyy";

                    dt_fitness_Date.Value = Convert.ToDateTime(i.fitness_date.ToString()).Date;
                }
                else
                {

                    dt_fitness_Date.Format = DateTimePickerFormat.Custom;
                    dt_fitness_Date.CustomFormat = "00/00/0000";

                }

                DateTime temp3;
                if (DateTime.TryParse(i.valid_until.ToString(), out temp3))
                {
                    dt_ValidUntil.Format = DateTimePickerFormat.Custom;
                    dt_ValidUntil.CustomFormat = "MM/dd/yyyy";

                    dt_ValidUntil.Value = Convert.ToDateTime(i.valid_until.ToString()).Date;
                }
                else
                {

                    dt_ValidUntil.Format = DateTimePickerFormat.Custom;
                    dt_ValidUntil.CustomFormat = "00/00/0000";

                }



                cbo_medtech.Text = i.medtech.ToString();
                txt_pathologist.Text = i.pathologist.ToString();
                txt_specimen.Text = i.specimen_no.ToString();

                //}



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}




        }

        public void search_RecomendationFromSearch()
        {

            try
            {


                var i = db.sp_Seafarer_Recomendation(cn_MLCFromResultMain).FirstOrDefault();
                lbl_reco_cn.Tag = i.cn.ToString();
                cn_MLCFromResultMain = i.cn.ToString();
                cbo_recomendation.Text = i.recommendation.ToString();
                this.txt_restriction.Text = i.restriction.ToString();
                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    dt_ResDate.Format = DateTimePickerFormat.Custom;
                    dt_ResDate.CustomFormat = "MM/dd/yyyy";
                    dt_ResDate.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {

                    dt_ResDate.Format = DateTimePickerFormat.Custom;
                    dt_ResDate.CustomFormat = "00/00/0000";

                }


                DateTime temp2;
                if (DateTime.TryParse(i.fitness_date.ToString(), out temp2))
                {
                    dt_fitness_Date.Format = DateTimePickerFormat.Custom;
                    dt_fitness_Date.CustomFormat = "MM/dd/yyyy";

                    dt_fitness_Date.Value = Convert.ToDateTime(i.fitness_date.ToString()).Date;
                }
                else
                {

                    dt_fitness_Date.Format = DateTimePickerFormat.Custom;
                    dt_fitness_Date.CustomFormat = "00/00/0000";

                }

                DateTime temp3;
                if (DateTime.TryParse(i.valid_until.ToString(), out temp3))
                {
                    dt_ValidUntil.Format = DateTimePickerFormat.Custom;
                    dt_ValidUntil.CustomFormat = "MM/dd/yyyy";

                    dt_ValidUntil.Value = Convert.ToDateTime(i.valid_until.ToString()).Date;
                }
                else
                {

                    dt_ValidUntil.Format = DateTimePickerFormat.Custom;
                    dt_ValidUntil.CustomFormat = "00/00/0000";

                }



                cbo_medtech.Text = i.medtech.ToString();
                txt_pathologist.Text = i.pathologist.ToString();
                txt_specimen.Text = i.specimen_no.ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



        }


        public void GetSpecimenNumber()
        {

            try
            {
                var i = db.sp_GetSpecimen(txt_Papin.Text).FirstOrDefault();
                txt_specimen.Text = i.specimen_no;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



        }


        private void txt_Papin_TextChanged(object sender, EventArgs e)
        {


            txt_Papin.Select();

        }

        //void Medical_personnel()
        //{
        //    ClassSql b = new ClassSql();
        //    b.PutDataTOComboBox("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Type =  'PEME Physician'", cbo_medtech, "Name", "cn");
        //    b.PutDataTOTextBox("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Type =  'PEME MedicalDirector'", txt_pathologist, "Name");
        //    //

        //}

        private void txt_resultID_TextChanged(object sender, EventArgs e)
        {



            //if (NewSeafarer)
            //{
            //    fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = false; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = false;

            //}
            //else
            //{

            //    Search_PhyExam();
            //    search_Recomendation();
            //    fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = true; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = false; fmain.ts_print_mlc.Enabled = true; fmain.ts_search_mlc.Enabled = true;

            //}
        }

        private void cbo_recomendation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_recomendation.Text == "FIT WITH RESTRICTION") { label27.Visible = true; txt_restriction.Visible = true; } else { label27.Visible = false; txt_restriction.Visible = false; txt_restriction.Clear(); }
        }

        private void dt_date_ValueChanged(object sender, EventArgs e)
        {
            //if (dt_date.Checked != true)
            //{
            //    dt_date.Format = DateTimePickerFormat.Custom;
            //    dt_date.CustomFormat = " ";
            //}
            //else
            //{
            //    dt_date.Format = DateTimePickerFormat.Custom;
            //    dt_date.CustomFormat = "yyyy-MM-dd";

            //}
        }

        private void cbo_medtech_SelectedIndexChanged(object sender, EventArgs e)
        {
            string med1; string med2;
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            med1 = ini.IniReadValue("MEDICAL", "PEME_Physician");
            med2 = ini.IniReadValue("MEDICAL", "PEME MedicalDirector");

            if (cbo_medtech.Text == med1)
            { MedtectLicence = ini.IniReadValue("MEDICAL", "PEME_Physician_license"); }
            else
            { MedtectLicence = ini.IniReadValue("MEDICAL", "PEME MedicalDirector_license"); }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt2_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt3_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_date.Format = DateTimePickerFormat.Custom;
                dt_date.CustomFormat = "00/00/0000";
            }

        }

        private void dt_date_MouseDown(object sender, MouseEventArgs e)
        {
            dt_date.Format = DateTimePickerFormat.Custom;
            dt_date.CustomFormat = "MM/dd/yyyy";
            // dt_date.Value = DateTime.Now;

        }

        private void txt_resultDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_ResDate.Format = DateTimePickerFormat.Custom;
                dt_ResDate.CustomFormat = "00/00/0000";
            }
        }

        private void txt_resultDate_MouseDown(object sender, MouseEventArgs e)
        {
            dt_ResDate.Format = DateTimePickerFormat.Custom;
            dt_ResDate.CustomFormat = "MM/dd/yyyy";
            // dt_ResDate.Value = DateTime.Now;

        }

        private void txt_fitness_Date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_fitness_Date.Format = DateTimePickerFormat.Custom;
                dt_fitness_Date.CustomFormat = "00/00/0000";
            }
        }

        private void txt_fitness_Date_MouseDown(object sender, MouseEventArgs e)
        {
            dt_fitness_Date.Format = DateTimePickerFormat.Custom;
            dt_fitness_Date.CustomFormat = "MM/dd/yyyy";
            // dt_fitness_Date.Value = DateTime.Now;

        }

        private void dt_ValidUntil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_ValidUntil.Format = DateTimePickerFormat.Custom;
                dt_ValidUntil.CustomFormat = "00/00/0000";
            }
        }

        private void dt_ValidUntil_MouseDown(object sender, MouseEventArgs e)
        {
            dt_ValidUntil.Format = DateTimePickerFormat.Custom;
            dt_ValidUntil.CustomFormat = "MM/dd/yyyy";
            //dt_ValidUntil.Value = DateTime.Now;
        }

        private void dt_ValidUntil_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }



        private void r1_Y_Click_1(object sender, EventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void r1_Y_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel45);
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel3);
        }

        private void clearToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel4);
        }

        private void contextMenuStrip4_Opening(object sender, CancelEventArgs e)
        {

        }

        private void clearToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel5);
        }

        private void clearToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel6);
        }

        private void clearToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel8);
        }

        private void clearToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel7);
        }

        private void clearToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(panel9);
        }

        private void contextMenuStrip7_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txt_bday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
                int Age = CurrentDate.Year - Convert.ToDateTime(txt_bday.Text).Year;// dtbday.Value.Year;// Convert.ToDateTime(dtbday.Text).Year;
                //this.txt_age.Text = Age.ToString();
                if (CurrentDate.Month < Convert.ToDateTime(txt_bday.Text).Month)
                {
                    Age--;
                }
                else if ((CurrentDate.Month == Convert.ToDateTime(txt_bday.Text).Month) && (CurrentDate.Day < Convert.ToDateTime(txt_bday.Text).Day))
                {

                    Age--;
                }
                this.txt_age.Text = Age.ToString();

            }
            catch
            { }



        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {



                //using (StreamWriter s = File.CreateText(TableListPath.SEAMLCSearchList))
                //{ s.Close(); }

                //TextWriter sw = new StreamWriter(TableListPath.SEAMLCSearchList);
                //ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Mytable_Proc("search_MLC_From_Search", "@SearchID", "%");'
                var list = db.sp_Seafarer_SearchList("%").ToList();
                Cursor.Current = Cursors.WaitCursor;
                // int rowcount = dt.Rows.Count;

                // sw.WriteLine("a \t b \t c \t d \t e \t f");
                foreach (var i in list)
                {


                    //string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();                 
                    //sw.WriteLine(dr["cn"].ToString() + "\t" + dr["papin"].ToString() + "\t" + dr["resultid"].ToString() + "\t" + name.ToString() + "\t" + dr["result_date"].ToString() + "\t" + dr["recommendation"].ToString());
                    Seafarer_SearchList_model.Add(new Seafarer_SearchList_MLC
                    {
                        cn = i.cn,
                        papin = i.papin,
                        resultID = i.resultid,
                        patientName = i.PatientName,
                        resultDate = i.result_date,
                        recommendation = i.recommendation
                    });

                }
                //sw.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

                //this.Invoke((MethodInvoker)delegate()
                //{
                //    MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                //});

            }
            //finally
            //{

            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }

            //}

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {



                var list = db.sp_SeafarerAdd("%").ToList();
                Cursor.Current = Cursors.WaitCursor;
                foreach (var i in list)
                {
                    SeafarerAdd_model.Add(new QueueSearchList_Model
                    {
                        cn = i.cn,
                        papin = i.papin,
                        PatientName = i.PatientName,
                        gender = i.gender

                    });


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if ((Application.OpenForms["frm_search_MLC"] as frm_search_MLC) != null)
                { (Application.OpenForms["frm_search_MLC"] as frm_search_MLC).FillDataGridView(); }

                if (!backgroundWorker2.IsBusy)
                { backgroundWorker2.RunWorkerAsync(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }






            //(Application.OpenForms["frm_search_MLC"] as frm_search_MLC).lbl_notification.Visible = false;

        }

        private void frm_Seafarer_MLC_Enter(object sender, EventArgs e)
        {
            Seafarer_SearchList_model.Clear();
            SeafarerAdd_model.Clear();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        //private void r1_N_Click(object sender, EventArgs e)
        //{
        //    if (r1_N.Checked == true)
        //    { r1_N.Checked = false; }
        //    else if (r1_N.Checked == false)
        //    { r1_N.Checked = true; }

        //}

        //private void r2_Y_Click_1(object sender, EventArgs e)
        //{
        //    if (r2_Y.Checked == true)
        //    { r2_Y.Checked = false; }
        //    else
        //    { r2_Y.Checked = true;}
        //}

        //private void r2_N_Click(object sender, EventArgs e)
        //{
        //    if (r2_N.Checked == true)
        //    { r2_N.Checked = false; }
        //    else
        //    { r2_N.Checked = true; }
        //}

        //private void r3_Y_Click(object sender, EventArgs e)
        //{
        //    if (r3_Y.Checked == true)
        //    { r3_Y.Checked = false; }
        //    else
        //    { r3_Y.Checked = true; }
        //}

        //private void r3_N_Click(object sender, EventArgs e)
        //{
        //    if (r3_N.Checked == true)
        //    { r3_N.Checked = false; }
        //    else
        //    { r3_N.Checked = true; }
        //}

        //private void r4_Y_Click(object sender, EventArgs e)
        //{
        //    if (r4_Y.Checked == true)
        //    { r4_Y.Checked = false; }
        //    else
        //    { r4_Y.Checked = true; }
        //}

        //private void r4_N_Click(object sender, EventArgs e)
        //{
        //    if (r4_N.Checked == true)
        //    { r4_N.Checked = false; }
        //    else
        //    { r4_N.Checked = true; }
        //}

        //private void r5_Y_Click(object sender, EventArgs e)
        //{
        //    if (r5_Y.Checked == true)
        //    { r5_Y.Checked = false; }
        //    else
        //    { r5_Y.Checked = true; }

        //}

        //private void r5_N_Click(object sender, EventArgs e)
        //{
        //    if (r5_N.Checked == true)
        //    { r5_N.Checked = false; }
        //    else
        //    { r5_N.Checked = true; }

        //}

        //private void r6_Y_Click(object sender, EventArgs e)
        //{

        //    if (r6_Y.Checked == true)
        //    { r6_Y.Checked = false; }
        //    else
        //    { r6_Y.Checked = true; }
        //}

        //private void r6_N_Click(object sender, EventArgs e)
        //{
        //    if (r6_N.Checked == true)
        //    { r6_N.Checked = false; }
        //    else
        //    { r6_N.Checked = true; }
        //}

        //private void r7_Y_Click(object sender, EventArgs e)
        //{
        //    if (r7_Y.Checked == true)
        //    { r7_Y.Checked = false; }
        //    else
        //    { r7_Y.Checked = true; }
        //}

        //private void r7_N_Click(object sender, EventArgs e)
        //{
        //    if (r7_N.Checked == true)
        //    { r7_N.Checked = false; }
        //    else
        //    { r7_N.Checked = true; }
        //}

        //private void r8_Y_Click(object sender, EventArgs e)
        //{
        //    if (r8_Y.Checked == true)
        //    { r8_Y.Checked = false; }
        //    else
        //    { r8_Y.Checked = true; }
        //}

        //private void r8_N_Click(object sender, EventArgs e)
        //{
        //    if (r8_N.Checked == true)
        //    { r8_N.Checked = false; }
        //    else
        //    { r8_N.Checked = true; }
        //}
    }
}
