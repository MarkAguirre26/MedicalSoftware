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
    public partial class frm_Ultrasound : Form, MyInter
    {
        Main fmain; public static bool NewULtrasound; public static TextBox pin; public static TextBox LabID;
        public static string cnUTZforSearch;
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public List<QueueSearchList_Model> UltrasoundAdd_model = new List<QueueSearchList_Model>();
        public List<Ultrasound_SearchList_Model> Ultrasound_SearchList_model = new List<Ultrasound_SearchList_Model>();
        public frm_Ultrasound(Main mainn)
        {
            InitializeComponent();
            fmain = mainn; pin = txt_Papin; LabID = txt_resultID;




        }

        private void frm_Ultrasound_Load(object sender, EventArgs e)
        {

            //ClassSql.DbConnect();
            Cursor.Current = Cursors.Default;
            Availability(false);


            //  Load_Medical();
        }
        public void setDefaultFiledsValue()
        {
            txt_ultrasoundNo.Text = "1012";
            txt_radiologist_findings.Text = "UTZ NORMAL WHOLE ABDOMEN:\nThe liver is normal.\nThe gallbladder,pancreas normal.\nright and left kidney normal..\nurinary bladder and prostate gland normal.\n";
            txt_impression.Text = "NORMAL  WHOLE ABDOMEN.";

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            txt_RadioLogist.Text = ini.IniReadValue("MEDICAL", "Xray_Radiologist");
            txt_RadioLogist_Lic.Text = ini.IniReadValue("MEDICAL", "Xray Radiologist_license");
            txt_medTect.Text = ini.IniReadValue("MEDICAL", "XRAY_TECH");
            txt_license_medTech.Text = ini.IniReadValue("MEDICAL", "XRAYTECH_LICENSE");


        }


        public void New()
        {
            //ClassSql a = new ClassSql();
            //a.PutDataTOTextBox("SELECT * FROM  tbl_medical WHERE tbl_medical.Type LIKE  '%Xray Radiologist%'", txt_medTect, "Name");
            //a.PutDataTOTextBox("SELECT * FROM  tbl_medical WHERE tbl_medical.Type LIKE  '%Pathologist%'", txt_pathologist, "Name");

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            this.txt_medTect.Text = ini.IniReadValue("MEDICAL", "XRAY_TECH");
            this.txt_license_medTech.Text = ini.IniReadValue("MEDICAL", "XRAYTECH_LICENSE");

            this.txt_RadioLogist.Text = ini.IniReadValue("MEDICAL", "Xray_Radiologist");
            this.txt_RadioLogist_Lic.Text = ini.IniReadValue("MEDICAL", "Xray Radiologist_license");



        }
        public void Save()
        {
            if (NewULtrasound)
            {

                Insert();
            }
            else
            {

                Update_UltraSound();



            }

        }

        public void Edit()
        {
            if (fmain.UserLevel == 1 || fmain.UserLevel == 2 || fmain.UserLevel == 6 || fmain.UserLevel == 7 )
            {
                NewULtrasound = false;
                Availability(true);
                fmain.ts_add_ultrasound.Enabled = false; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = true; fmain.ts_cancel_ultrasound.Enabled = true; fmain.ts_search_ultrasound.Enabled = false; fmain.ts_print_ultrasound.Enabled = false; fmain.ts_PrintPreview_Ultra.Enabled = false;

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

            Delete_Record();
        }


        void Update_UltraSound()
        {
            try
            {



                //ClassSql a = new ClassSql();
                //a.executequeryStoreproc("ProcUpdateUltrasound", "reference_no,findings,radiologist,rad_license,examination,impression,cn", new object[] { txt_ultrasoundNo.Text, txt_radiologist_findings.Text, txt_RadioLogist.Text, txt_RadioLogist_Lic.Text, txt_examination.Text, txt_impression.Text, lbl_Ultrasound_Result_Cn.Tag.ToString() });
                //a.executequeryStoreproc("ProcUpdateUltrasoundResult", "result_date,medtech,medtech_license,pathologist_license,pathologist,specimen_no,cn",  new object[] { dt_result_Date.Text, txt_medTect.Text, txt_license_medTech.Text, txt_RadioLogist_Lic.Text, txt_RadioLogist.Text, this.txt_speciment.Text, lbl_medical_cn.Tag.ToString() });

                db.ExecuteCommand("UPDATE t_radiology SET reference_no={0} , findings={1} , radiologist={2} , rad_license= {3}, examination={4} , impression= {5} WHERE  t_radiology.cn= {6}", txt_ultrasoundNo.Text, txt_radiologist_findings.Text, txt_RadioLogist.Text, txt_RadioLogist_Lic.Text, txt_examination.Text, txt_impression.Text, lbl_Ultrasound_Result_Cn.Tag.ToString());
                db.ExecuteCommand("UPDATE t_result_main SET result_date={0}, medtech={1} ,medtech_license={2} ,pathologist_license={3} ,pathologist={4},specimen_no= {5} WHERE t_result_main.cn= {6}", dt_result_Date.Text, txt_medTect.Text, txt_license_medTech.Text, txt_RadioLogist_Lic.Text, txt_RadioLogist.Text, this.txt_speciment.Text, lbl_medical_cn.Tag.ToString());
                //search_Radiology(); search_Medical();
                NewULtrasound = true;

                //Tool.MessageBoxUpdate();
                txt_Papin.Select();
                fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = true; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = false; fmain.ts_search_ultrasound.Enabled = true; fmain.ts_print_ultrasound.Enabled = true; fmain.ts_PrintPreview_Ultra.Enabled = true;
                Availability(false);




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
        //void Update_Medical()
        //{
        //    try
        //    {



        //        ClassSql a = new ClassSql();
        //           search_Medical();




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
        void Insert()
        {
            try
            {



                //  //ClassSql a = new ClassSql();
                //  //resultid`,     `resulttype`,    `papin`,              `result_date`,                         `pathologist`,                        `status`,   `fitness_date`, `valid_until`,   `remarks`,       `recommendation`, `repeat_test_requestby`,                `specimen_no`,                                                  `medtech`,                                  `medtech_license`,                                                `pathologist_license`,            `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`)
                //string a =  "INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + LabID.Text + "', 'UTZ', '" + pin.Text + "', '" + this.dt_result_Date.Text + "', '" + Tool.ReplaceString(txt_RadioLogist.Text) + "', 'PENDING',   '',              '',            '',                  '',               '',                 '" + Tool.ReplaceString(txt_speciment.Text) + "',               '" + Tool.ReplaceString(txt_medTect.Text) + "', '" + Tool.ReplaceString(txt_license_medTech.Text) + "', '" + Tool.ReplaceString(txt_RadioLogist_Lic.Text) + "', '',              '',             '',                  '',            '',             '',                 '',                 '',                     '')";
                //              //`resultid`,              `result_date`,      `papin`,               `reference_no`,                                                                                      `findings`, `    radiologist`,                                           `rad_license`,                         `examination`, `impression`
                // string b = "INSERT INTO `t_radiology` (`resultid`, `result_date`, `papin`, `reference_no`, `findings`, `radiologist`, `rad_license`, `examination`, `impression`) VALUES ('" + LabID.Text + "', '" + dt_result_Date.Text + "', '" + pin.Text + "', '" + Tool.ReplaceString(txt_ultrasoundNo.Text) + "',  '" + Tool.ReplaceString(txt_radiologist_findings.Text) + "', '" + Tool.ReplaceString(txt_RadioLogist.Text) + "', '" + Tool.ReplaceString(txt_RadioLogist_Lic.Text) + "', '"+Tool.ReplaceString(txt_examination.Text)+"',               '" + Tool.ReplaceString(txt_impression.Text) + "')";
                //  //search_Medical(); search_Radiology();  Search_Patient();


                //  var arr = new[] {a,b };
                //  File.WriteAllLines(ClassSql.tmp_path, arr);

                //resultid(254)result_date(254)papin(254)eference_no(254)findings(254)radiologist(254)rad_license(254)examination(254)impression

                //resultid,resulttype,papin,        result_date,            pathologist,            status, fitness_date,valid_until,remarks,recommendation,repeat_test_requestby,specimen_no,           medtech,                           medtech_license,    pathologist_license      ,reference_no,     restriction,        basic_doh_exam,     add_lab_tests,          flag_medlab_req,                deck_srvc_flag,         engine_srvc_flag,catering_srvc_flag,other_srvc_flag
                //  new ClassSql().executequeryStoreproc("ProcInsertUltrasound", "resultid,resulttype,papin,result_date,pathologist,status,fitness_date,valid_until,remarks,recommendation,repeat_test_requestby,specimen_no,medtech,medtech_license,pathologist_license,reference_no,restriction,basic_doh_exam,add_lab_tests,flag_medlab_req,deck_srvc_flag,engine_srvc_flag,catering_srvc_flag,other_srvc_flag", new object[] { LabID.Text, "UTZ",      pin.Text, this.dt_result_Date.Text, txt_RadioLogist.Text, "PENDING",    "",             "",    "",            "",         "",             txt_speciment.Text, txt_medTect.Text,              txt_license_medTech.Text, txt_RadioLogist_Lic.Text,        "",                 "",             "",                 "",                     "",                             "",                     "", "",""});
                //new ClassSql().executequeryStoreproc("ProcinsertUltrasoundResult", "resultid,result_date,papin,reference_no,findings,radiologist,rad_license,examination,impression", new object[] { LabID.Text, dt_result_Date.Text, pin.Text, txt_ultrasoundNo.Text, txt_radiologist_findings.Text, txt_RadioLogist.Text, txt_RadioLogist_Lic.Text, "", txt_impression.Text });
                db.ExecuteCommand("INSERT INTO t_result_main(resultid,resulttype,papin,result_date,pathologist,status,fitness_date,valid_until,remarks,recommendation,repeat_test_requestby,specimen_no,medtech,medtech_license,pathologist_license,reference_no,restriction,basic_doh_exam,add_lab_tests,flag_medlab_req,deck_srvc_flag,engine_srvc_flag,catering_srvc_flag,other_srvc_flag) values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", LabID.Text, "UTZ", pin.Text, this.dt_result_Date.Text, txt_RadioLogist.Text, "PENDING", "", "", "", "", "", txt_speciment.Text, txt_medTect.Text, txt_license_medTech.Text, txt_RadioLogist_Lic.Text, "", "", "", "", "", "", "", "", "");
                db.ExecuteCommand("INSERT INTO t_radiology(resultid,result_date,papin,reference_no,findings,radiologist,rad_license,examination,impression) values({0},{1},{2},{3},{4},{5},{6},{7},{8})", LabID.Text, dt_result_Date.Text, pin.Text, txt_ultrasoundNo.Text, txt_radiologist_findings.Text, txt_RadioLogist.Text, txt_RadioLogist_Lic.Text, "", txt_impression.Text);
                Ultrasound_SearchList_model.Clear();
                UltrasoundAdd_model.Clear();
                if (!backgroundWorker1.IsBusy)
                { backgroundWorker1.RunWorkerAsync(); }

                //Tool.MessageBoxSave();
                txt_Papin.Select();
                Availability(false);
                fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = true; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = false; fmain.ts_search_ultrasound.Enabled = true; fmain.ts_print_ultrasound.Enabled = true; fmain.ts_PrintPreview_Ultra.Enabled = true;



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





        public void Cancel()
        {
            if (NewULtrasound)
            {
                Tool.ClearFields(groupBox1);
                txt_Papin.Clear();
                ClearAll();
                Availability(false);

                fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_search_ultrasound.Enabled = true; fmain.ts_print_ultrasound.Enabled = false; fmain.ts_PrintPreview_Ultra.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = false;

            }
            else
            {
                Availability(false);
                ClearAll();
                Search_Patient(); search_Medical(); search_Radiology();
                fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = true; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_search_ultrasound.Enabled = true; fmain.ts_print_ultrasound.Enabled = true; fmain.ts_PrintPreview_Ultra.Enabled = true; fmain.ts_cancel_ultrasound.Enabled = false;
            }



        }
        public void Print()
        {
            //Report.Report_PrintOuts frm_ultraSound = new Report.Report_PrintOuts();
            //frm_ultraSound.Tag = LabID.Text;
            //frm_ultraSound.Ultrasound = true;
            //frm_ultraSound.ShowDialog();
            try
            {
                using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
                {
                    f.Tag = txt_resultID.Text;
                    f.isUltrasound = true;
                    f.age = txt_age.Text;
                    f.PatientName = txt_name.Text;
                    f.ResultDate_UTZ = dt_result_Date.Text;
                    f.Sex = txt_gender.Text;
                    f.Position = txt_position.Text;
                    f.SpecimenNo = txt_ultrasoundNo.Text;
                    f.Findings = txt_radiologist_findings.Text;
                    f.Impression = txt_impression.Text;
                    f.Radiologist = txt_RadioLogist.Text;
                    f.Radiologist_Lic = txt_RadioLogist_Lic.Text;
                    f.ShowDialog();
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }


        }
        public void Search()
        {



        }

        private void frm_Ultrasound_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.Ultrasount = true;
            fmain.ts_PrintPreview_Ultra.Enabled = false; fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = false; fmain.ts_search_ultrasound.Enabled = true; fmain.ts_print_ultrasound.Enabled = false;
            ClassSql.DbClose();
            //   fmain.Strip_sub.Visible = false;

        }

        private void frm_Ultrasound_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (fmain.ts_cancel_ultrasound.Enabled == true)
                { Cancel(); }
                else
                { this.Close(); }

            }
            else if (e.KeyCode == Keys.Add && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_add_ultrasound.Enabled == true)
                {

                    fmain.add_ultrasound();
                }
            }

            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_save_ultrasound.Enabled == true)
                {
                    Save();

                }

            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_print_ultrasound.Enabled == true)
                {
                    Print();
                }
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {

                if (fmain.ts_search_ultrasound.Enabled == true)
                {
                    fmain.Search_Ultrasound();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (fmain.ts_edit_ultrasound.Enabled == true)
                {
                    Edit();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (fmain.ts_delete_ultrasound.Enabled == true)
                {

                    Delete();
                }

            }
        }
        public void Availability(bool bl)
        {
            //Tool.SetEnable(panel3,bl);
            //Tool.SetEnable(groupBox2,bl);
            //Tool.SetEnable(groupBox3,bl);
            //Tool.SetEnable(groupBox4, bl);


            if (bl == true)
            { overlayShadow1.Visible = false; overlayShadow1.SendToBack(); }
            else
            { overlayShadow1.Visible = true; overlayShadow1.BringToFront(); }

        }

        public void ClearAll()
        {
            Tool.ClearFields(panel3);
            Tool.ClearFields(groupBox2);
            Tool.ClearFields(groupBox3);
            Tool.ClearFields(groupBox4);


        }



        void Delete_Record()
        {

            try
            {


                ClassSql a = new ClassSql();
                a.ExecuteQuery("Delete from t_radiology where resultid = '" + LabID.Text + "' and resulttype= 'UTZ'");
                Tool.MessageBoxDelete();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            finally
            {
                //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
                if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            }

        }

        //void Load_Medical()
        //{

        //    try
        //    {



        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Table("SELECT tbl_medical.cn,  tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            txt_medTect.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            txt_pathologist.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            txt_radiologist.AutoCompleteCustomSource.Add(dr["Name"].ToString());


        //        }



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

        public void Search_Patient()
        {
            try
            {



                //ClassSql a = new ClassSql(); DataTable dt;

                ////dt = a.Table("SELECT m_patient.cn, m_patient.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.birthdate, m_patient.gender, m_patient.employer, m_patient.position FROM m_patient WHERE m_patient.papin =  '" + Tool.ReplaceString(pin.Text) + "'");
                //dt = a.Mytable_Proc("Utz_patient", "@SearchID", pin.Text);
                var i = db.sp_Ultrasound_Patient(pin.Text).FirstOrDefault();
                //foreach (DataRow dr in dt.Rows)
                //{

                txt_name.Text = i.PatientName;
                // txt_bday.Text = dr["birthdate"].ToString();

                DateTime temp1;
                if (DateTime.TryParse(i.birthdate.ToString(), out temp1))
                {
                    dt_bday.Format = DateTimePickerFormat.Custom;
                    dt_bday.CustomFormat = "MM/dd/yyyy";

                    dt_bday.Value = Convert.ToDateTime(i.birthdate.ToString()).Date;
                }
                else
                {

                    dt_bday.Format = DateTimePickerFormat.Custom;
                    dt_bday.CustomFormat = "00/00/0000";

                }




                txt_gender.Text = i.gender.ToString();
                txt_employer.Text = i.employer.ToString();
                txt_position.Text = i.position.ToString();


                //}



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



        }

        public void search_Medical()
        {

            try
            {


                //  ClassSql a = new ClassSql(); DataTable dt;

                ////  dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.medtech, t_result_main.pathologist, t_result_main.specimen_no, t_result_main.medtech_license, t_result_main.pathologist_license, t_result_main.result_date FROM t_result_main  WHERE t_result_main.resulttype =  'UTZ' AND t_result_main.resultid = '" + LabID.Text + "'");
                //  dt = a.Mytable_Proc("Utz_medical", "@SearchID", LabID.Text);
                var i = db.sp_Ultrasound_Medical(LabID.Text).FirstOrDefault();

                lbl_medical_cn.Tag = i.cn.ToString();
                DateTime date1 = DateTime.Parse(i.result_date.ToString()).Date;
                dt_result_Date.Text = date1.ToShortDateString();
                // dt_result_Date.Text = dr["result_date"].ToString();                  
                txt_medTect.Text = i.medtech.ToString();
                txt_RadioLogist.Text = i.pathologist.ToString();
                this.txt_speciment.Text = i.specimen_no.ToString();
                txt_license_medTech.Text = i.medtech_license.ToString();
                txt_RadioLogist_Lic.Text = i.pathologist_license.ToString();
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
        //void search_Medical_sub()
        //{

        //    try
        //    {


        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.medtech, t_result_main.pathologist, t_result_main.specimen_no, t_result_main.medtech_license, t_result_main.pathologist_license, t_result_main.result_date FROM t_result_main  WHERE t_result_main.resulttype =  'UTZ' AND t_result_main.papin =  '" + Tool.ReplaceString(txt_Papin.Text) + "'");
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            lbl_medical_cn.Tag = dr["cn"].ToString();
        //            LabID.Text = dr["resultid"].ToString();

        //            DateTime date1 = DateTime.Parse(dr["result_date"].ToString()).Date;
        //            dt_result_Date.Text = date1.ToShortDateString();

        //            //dt_result_Date.Text = dr["result_date"].ToString();

        //            txt_medTect.Text = dr["medtech"].ToString();
        //            txt_pathologist.Text = dr["pathologist"].ToString();
        //            this.txt_speciment.Text = dr["specimen_no"].ToString();
        //            txt_license_medTech.Text = dr["medtech_license"].ToString();
        //            txt_license_pathologist.Text = dr["pathologist_license"].ToString();
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


        public void search_Radiology()
        {

            try
            {

                // ClassSql a = new ClassSql(); DataTable dt;
                //// dt = a.Table("SELECT * FROM  t_radiology WHERE t_radiology.resultid =  '" + Tool.ReplaceString(LabID.Text) + "'");
                // dt = a.Mytable_Proc("Utz_radiology", "@SearchId", LabID.Text);
                var i = db.sp_Ultrasound_Radio(LabID.Text).FirstOrDefault();


                lbl_Ultrasound_Result_Cn.Tag = i.cn.ToString();
                txt_examination.Text = i.examination.ToString();
                txt_ultrasoundNo.Text = i.reference_no.ToString();
                txt_radiologist_findings.Text = i.findings.ToString();
                txt_impression.Text = i.impression.ToString();
                txt_RadioLogist.Text = i.radiologist.ToString();
                txt_RadioLogist_Lic.Text = i.rad_license.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format(" An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}

        }


        /*  public void search_RadiologyFromSearch()
          {

              try
              {

                  ClassSql a = new ClassSql(); DataTable dt;
                  // dt = a.Table("SELECT * FROM  t_radiology WHERE t_radiology.resultid =  '" + Tool.ReplaceString(LabID.Text) + "'");
                  dt = a.Mytable_Proc("Utz_radiologyfromSearch", "@SearchId", this.Tag.ToString());
                  foreach (DataRow dr in dt.Rows)
                  {

                      lbl_Ultrasound_Result_Cn.Tag = dr["cn"].ToString();
                      txt_examination.Text = dr["examination"].ToString();
                      txt_ultrasoundNo.Text = dr["reference_no"].ToString();
                      txt_radiologist_findings.Text = dr["findings"].ToString();
                      txt_impression.Text = dr["impression"].ToString();
                      txt_RadioLogist.Text = dr["radiologist"].ToString();
                      txt_RadioLogist_Lic.Text = dr["rad_license"].ToString();


                  }



              }
              catch (Exception ex)
              {
                  MessageBox.Show(this, string.Format(" An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

              }
              finally
              {
                  //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
                  if (ClassSql.dr != null) { ClassSql.dr.Close(); }
              }

          }


            */


        private void txt_Papin_TextChanged(object sender, EventArgs e)
        {

            //if (NewULtrasound)
            //{
            //    ClassSql a = new ClassSql(); long cnt;
            //    cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + Tool.ReplaceString(txt_Papin.Text) + "' and resulttype = 'UTZ'");

            //    if (cnt >= 1)
            //    {

            //        if (MessageBox.Show("Patient had previous laboratory examination! Would you like to update Hir/Her record?", Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {

            //            NewULtrasound = false;
            //            search_Medical_sub();
            //            Search_Patient();                       
            //            search_Radiology();
            //            Availability(true);

            //        }
            //        else
            //        {
            //            NewULtrasound = true;
            //            Search_Patient();
            //            Availability(true);
            //            ClearAll();


            //        }

            //    }
            //    else
            //    {

            //        NewULtrasound = true;
            //        Search_Patient();
            //        Availability(true);
            //        ClearAll();

            //    }


            //}
            //else
            //{
            //    Search_Patient();

            //}

            //txt_Papin.Select();
            //Load_Medical();
        }

        private void txt_resultID_TextChanged(object sender, EventArgs e)
        {

            //Load_Medical();

            //if (NewULtrasound)
            //{
            //    fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = true; fmain.ts_print_ultrasound.Enabled = false; fmain.ts_search_ultrasound.Enabled = false;

            //}
            //else
            //{
            //    search_Medical();
            //    search_Radiology();
            //    fmain.ts_add_ultrasound.Enabled = true; fmain.ts_edit_ultrasound.Enabled = true; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = false; fmain.ts_print_ultrasound.Enabled = true; fmain.ts_search_ultrasound.Enabled = true;

            //}

        }

        private void txt_bday_TextChanged(object sender, EventArgs e)
        {







        }

        private void txt_medTect_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_pathologist_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_radiologist_TextChanged(object sender, EventArgs e)
        {

            //ClassSql a = new ClassSql();
            //a.PutDataTOTextBox("SELECT 
            //    .cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Name LIKE  '%" + txt_radiologist.Text + "%'", txt_rad_license, "License");

        }

        private void dt_bday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_bday.Format = DateTimePickerFormat.Custom;
                dt_bday.CustomFormat = "00/00/0000";
            }
        }

        private void dt_bday_MouseDown(object sender, MouseEventArgs e)
        {
            dt_bday.Format = DateTimePickerFormat.Custom;
            dt_bday.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_bday_ValueChanged(object sender, EventArgs e)
        {
            //if (dt_bday.Text != "" || dt_bday.Text != "0000-00-00 00:00:00" || dt_bday.Text != "00/00/0000")
            //{

            //    int age = DateTime.Now.Year - Convert.ToDateTime(dt_bday.Text).Year;
            //    txt_age.Text = age.ToString();

            //}
            //else
            //{ txt_age.Clear(); }

            if (dt_bday.Text != "" || dt_bday.Text != "0000-00-00 00:00:00" || dt_bday.Text != "00/00/0000")
            {
                int age_ = DateTime.Now.Year - dt_bday.Value.Year;
                txt_age.Text = age_.ToString();

                DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
                int Age = CurrentDate.Year - dt_bday.Value.Year;

                if (CurrentDate.Month < dt_bday.Value.Month)
                {
                    Age--;
                }
                else if ((CurrentDate.Month == dt_bday.Value.Month) && (CurrentDate.Day < dt_bday.Value.Day))
                {

                    Age--;
                }
                this.txt_age.Text = Age.ToString();




            }
            else
            {
                txt_age.Clear();
            }


        }

        private void dt_result_Date_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void cmd_load1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_medTect;
                f.txt_license = txt_license_medTech;
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_RadioLogist;
                f.txt_license = txt_RadioLogist_Lic;
                f.ShowDialog();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                //using (StreamWriter s = File.CreateText(TableListPath.UTZSearchList))
                //{ s.Close(); }

                //TextWriter sw = new StreamWriter(TableListPath.UTZSearchList);
                //ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Mytable_Proc("Utz_search", "@SearchID","%");
                var list = db.sp_Ultrasound_SearchList("%").ToList();
                Cursor.Current = Cursors.WaitCursor;
                //  int rowcount = dt.Rows.Count;
                // sw.WriteLine("a \t b \t c \t d \t e");
                foreach (var i in list)
                {

                    //sw.WriteLine(dr[0].ToString() + "\t" + dr[1].ToString() + "\t" + dr[2].ToString() + "\t" + dr[3].ToString() + "\t" + dr[4].ToString());
                    Ultrasound_SearchList_model.Add(new Ultrasound_SearchList_Model
                    {
                        cn = i.cn,
                        papin = i.papin,
                        resultID = i.resultid,
                        patientName = i.PatientName,
                        resultDate = i.result_date

                    });
                }
                // sw.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

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

                //    using (StreamWriter s = File.CreateText(TableListPath.QueueSearchList))
                //    { s.Close(); }

                //    TextWriter sw = new StreamWriter(TableListPath.QueueSearchList);
                //    ClassSql a = new ClassSql(); DataTable dt;
                //    dt = a.Mytable_Proc("Search_patient_Add_a", "@ID", "%");
                //    Cursor.Current = Cursors.WaitCursor;
                //    int rowcount = dt.Rows.Count;
                //    sw.WriteLine("a \t b \t c \t d ");
                //    foreach (DataRow dr in dt.Rows)
                //    {

                //        string Name = dr["lastname"].ToString() + ", " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
                //        sw.WriteLine(dr["cn"].ToString() + "\t" + dr["papin"].ToString() + "\t" + Name.ToString() + "\t" + dr["gender"].ToString());

                //    }
                //    sw.Close();

                var list = db.sp_SeafarerAdd("%").ToList();
                Cursor.Current = Cursors.WaitCursor;
                foreach (var i in list)
                {
                    UltrasoundAdd_model.Add(new QueueSearchList_Model
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
            //finally
            //{

            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }

            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!backgroundWorker2.IsBusy)
                { backgroundWorker2.RunWorkerAsync(); }
                if ((Application.OpenForms["frm_search_ultrasound"] as frm_search_ultrasound) != null)
                { (Application.OpenForms["frm_search_ultrasound"] as frm_search_ultrasound).FillDataGridView(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }




            //(Application.OpenForms["frm_search_ultrasound"] as frm_search_ultrasound).lbl_notification.Visible = false;

        }

        private void frm_Ultrasound_Enter(object sender, EventArgs e)
        {
            Ultrasound_SearchList_model.Clear();
            UltrasoundAdd_model.Clear();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }


    }
}
