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
using Centerport.Report;
using System.IO;
using Ini;
using Centerport.Class;

namespace Centerport
{
    public partial class frm_lab : Form, MyInter
    {
        Main fmain; public static bool newlab; public static TextBox Patient_pin; public static TextBox LabId;
        private string FBS_; private string Bun_; private string Creatinine_; private string Cholesterol_; private string trigly_; private string uric_; private string sgot_; private string sgpt_; private string alk_;

        // public static ToolStripButton tb_add_lab; public static ToolStripButton tb_edit_lab; public static ToolStripButton tb_del_lab; public static ToolStripButton tb_Save_lab; public static ToolStripButton tb_Cancel_lab; public static ToolStripButton tb_Search_lab; public static ToolStripButton tb_Print_lab; 
        public List<laboratory_search> labsearch = new List<laboratory_search>();
        public List<QueueSearchList_Model> QueueSearchList_Model = new List<QueueSearchList_Model>();
        public frm_lab(Main mainn)
        {
            InitializeComponent();
            // tb_add_lab = ts_add_lab; tb_edit_lab = ts_edit_lab; tb_del_lab = ts_delete_lab; tb_Save_lab = ts_save_lab; tb_Cancel_lab = ts_cancel_lab; tb_Search_lab = ts_search_lab; tb_Print_lab = ts_print_lab; 
            Patient_pin = txt_papin; LabId = txt_resultId;
            fmain = mainn;
            //  this.Height = fmain.Height;
        }



        public void New()
        {

            //ClassSql a = new ClassSql();
            //a.PutDataTOTextBox("Select * from tbl_medical where type LIKE '%MedTech%'", MedTech, "Name");
            //a.PutDataTOTextBox("Select * from tbl_medical where type LIKE '%Pathologist%'", Pathologist, "Name");


            IniFile ini = new IniFile(ClassSql.MMS_Path);
            MedTech.Text = ini.IniReadValue("MEDICAL", "MedTech");
            med_licenseNo.Text = ini.IniReadValue("MEDICAL", "MedTech_license");
            Pathologist.Text = ini.IniReadValue("MEDICAL", "Pathologist");
            Pathologist_licenseNo.Text = ini.IniReadValue("MEDICAL", "Pathologist_license");



        }
        public void Save()
        {

            if (newlab)
            {
                insert();

            }
            else
            {

                Update_Medical();




            }



        }
        public void Edit()
        {

            if (fmain.UserLevel == 1 || fmain.UserLevel == 2 || fmain.UserLevel == 3)
            {
                newlab = false;
                Availability(true);
                fmain.ts_add_lab.Enabled = false; fmain.ts_edit_lab.Enabled = false; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = true; fmain.ts_cancel_lab.Enabled = true; fmain.ts_search_lab.Enabled = false; fmain.ts_print_lab.Enabled = false;
                cmd_chemistry.Enabled = false; cmd_Repeat_fecalysis.Enabled = false; cmd_repeatUrinal.Enabled = false; cmd_repeatHema.Enabled = false;

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

            //try
            //{
            //    if (id_ != null)
            //    {

            //        if (MessageBox.Show("Are you sure you want to delete Patient with Papin no.:" + txt_papin.Text, Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            ClassSql a = new ClassSql();
            //            a.ExecuteQuery("Delete from m_patient where cn = '" + id_.Text + "'");
            //            id_.Clear();
            //            Tool.MessageBoxDelete();

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            //}
            //finally
            //{
            //    if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}



        }
        public void Cancel()
        {


            if (newlab)
            {
                txt_papin.Select();
                txt_papin.Clear();

                //dt_resultdate.Enabled = false;
                //labNo.Enabled = false;
                //MedTech.Enabled = false;
                //Pathologist.Enabled = false;
                //med_licenseNo.Enabled = false;
                //Pathologist_licenseNo.Enabled = false;
                txt_papin.Clear();
                ClearAll();
                Availability(false);

                cmd_chemistry.Enabled = false; cmd_Repeat_fecalysis.Enabled = false; cmd_repeatUrinal.Enabled = false; cmd_repeatHema.Enabled = false;
                fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = false; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = false;
            }
            else
            {
                txt_papin.Select();
                //dt_resultdate.Enabled = false;
                //labNo.Enabled = false;
                //MedTech.Enabled = false;
                //Pathologist.Enabled = false;
                //med_licenseNo.Enabled = false;
                //Pathologist_licenseNo.Enabled = false;        

                Availability(false);
                ClearAll();

                Search_Patient(); Search_lab(); Search_Hema(); Search_Chemistry(); Search_Urinalysis(); Search_Fecalysis();

                cmd_chemistry.Enabled = true; cmd_Repeat_fecalysis.Enabled = true; cmd_repeatUrinal.Enabled = true; cmd_repeatHema.Enabled = true;
                fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = true; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = true; fmain.ts_cancel_lab.Enabled = false;
            }

        }
        public void Print()
        {

            //Report_Lab frm_lab_Report = new Report_Lab();
            //frm_lab_Report.Tag = LabId.Text;
            //frm_lab_Report.R_lab08.Select();
            //frm_lab_Report.Load_Lab08();
            //frm_lab_Report.ShowDialog();
            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.isFecalysis = true;
            //    f.age = txt_age.Text;
            //    f.Tag = LabId.Text;
            //    f.ShowDialog();
            //}

            using (frm_LabPrintChoices f = new frm_LabPrintChoices())
            {
                f.ShowImage = "0";
                f.Age = txt_age.Text;
                f.resultid = LabId.Text;
                f.PatientName = name.Text;
                f.Sex = gender.Text;
                f.Address = address.Text;
                f.CivilStatus = civil_stat.Text;
                f.Age = txt_age.Text;
                f.Position = position.Text;
                f.resultdateHema = Hema_RelustDate.Text;
                f.ReferredBy = "";
                f.Hemoglobin_ = hemoglobin.Text;
                f.Hematocrit_ = hematocrit.Text;
                f.RBCcount_ = RBC.Text;
                f.WBC_ = WBC.Text;
                f.SpecimenNo = labNo.Text;
                f.Platelet_ = Platelet.Text;
                f.BloodType_ = BloodType.Text;
                f.Lymphocyte_ = Lympho.Text;
                f.Segmenters_ = Segmenters.Text;
                f.easinophils_ = Easinophils.Text;
                f.Monoytes_ = MonoCytes.Text;
                f.myelocytes_ = Myelocytes.Text;
                f.Juveniles_ = Juveniles.Text;
                f.stabCells_ = StabCells.Text;
                f.Basophils_ = BasoPhils.Text;
                f.Others_HEma = Hema_Other.Text;
                //f.Medtech = MedTech.Text;
                //f.MedTech_lic = med_licenseNo.Text;
                f.Pathologist = Pathologist.Text;
                f.Pathologist_Lic = Pathologist_licenseNo.Text;

                f.Employer = agency.Text;
                f.esr = ESR.Text;
                f.rpr_ = cbo_rpr.Text;
                f.BsAG = cbo_hb.Text;
                f.WIDALTEST = cbo_widal.Text;
                f.MALARIAL = cbo_malaroial.Text;

                f.ResultDate_lab06 = dt_resultdate.Text;


                //   f.isFecalysis = true;
                // f.Tag = FecalysisID.ToString();
                // f.Age = txt_age.Text;
                //f.PatientName = name.Text;
                //f.Sex = gender.Text;
                f.ResultDate_Fecal = dt_resultDate_Fecalysis.Text;
                //f.Address = address.Text;
                //f.Position = position.Text;
                //f.ReferredBy = "";
                f.Color_fecal = cbo_color_fecal.Text;
                f.WHITeBLOODCELLS = tx_whitBlood_fecal.Text;
                f.Mucus = "";
                f.OVAORPARASITE = tx_ova.Text;
                f.AMOEBA = tx_amoeba.Text;
                f.OCCULTBLOODTEST = tx_occultBloodTest.Text;
                f.other_fecal = txt_other_Fecalysis.Text;
                f.Medtech = MedTech.Text;
                f.MedTech_lic = med_licenseNo.Text;
                f.Pathologist = Pathologist.Text;
                f.Pathologist_Lic = Pathologist_licenseNo.Text;
                f.SpecimenNo = labNo.Text;
                f.RedBlood = tx_red_fecal.Text;
                f.color_Others_fecal = txt_color_other_fecal.Text;
                f.CONSISTENCY = cbo_consistency.Text;



                f.resultdate_Urinalysis = dt_Result_urinal.Text;
                f.COLOR_Urnialysis = cbo_color.Text.Replace("[n/a]", "").Replace("N/A", "");
                f.Transparency = cbo_transparency.Text;
                f.Leucocytes = cbo_leu.Text;
                f.Nitrite = cbo_nitrite.Text;
                f.Urobilinogen = cbo_uro.Text;
                f.Protein = cbo_protein.Text;
                f.pH = cbo_ph.Text;
                f.Blood = cbo_blood.Text;
                f.SpecificGravity = cbo_spec.Text;
                f.Ketone = cbo_keton.Text;
                f.Bilirubin = cbo_bili.Text;
                f.Glucose = cbo_glucose.Text;
                f.other_chem = txt_other_chem.Text;
                f.RedBloodCells_Urinalysis = txt_redBlood.Text;
                f.WhiteBloodCells_Urinalysis = tx_whiteBlood.Text;
                f.Amorphous_Urates = tx_urates.Text;
                f.Phosphate = tx_phosphate.Text;
                f.EpithelialCells = tx_cells.Text;
                f.MucusThread = tx_musus.Text;
                f.others_Microscopic = tx_other_micro.Text;
                f.UricAcid_Urinalysis = tx_uric_crystal.Text;
                f.CalciumOxalate = tx_caium.Text;
                f.Others_Crystal = tx_other_Crystals.Text;
                f.FineGranularCast = tx_Granular.Text;
                f.CoarseGranularCast = tx_coarse.Text;
                f.Others_Cast = tx_other_cast.Text;
                f.Color_remark = tx_color_other.Text;






                f.resultdate_Chem = dt_Chemistry.Text;

                f.FBS_ = tx_FBS.Text;
                f.BUN_ = txt_Bun.Text;
                f.CREATINE_ = tx_Creatinine.Text;
                f.CHOLESTEROL_ = tx_Cholesterol.Text;
                f.TRIGLYCERIDES_ = tx_trigly.Text;
                f.URICACID_ = tx_uric.Text;
                f.SGOT_ = tx_sgot.Text;
                f.SGPT_ = tx_sgpt.Text;
                f.ALKPHOS_ = tx_alk.Text;
                //f.Medtech = MedTech.Text;
                //f.MedTech_lic = med_licenseNo.Text;
                //f.Pathologist = Pathologist.Text;
                //f.Pathologist_Lic = Pathologist_licenseNo.Text;
                //f.SpecimenNo = labNo.Text;
                if (cb_FBS.Checked) { f.FBS_H = "1"; } else { f.FBS_H = "0"; }
                if (cb_Bun.Checked) { f.BUN_H = "1"; } else { f.BUN_H = "0"; }
                if (cb_Creatinine.Checked) { f.CREATINE_H = "1"; } else { f.CREATINE_H = "0"; }
                if (cb_Cholesterol.Checked) { f.CHOLESTEROL_H = "1"; } else { f.CHOLESTEROL_H = "0"; }
                if (cb_trigly.Checked) { f.TRIGLYCERIDES_H = "1"; } else { f.TRIGLYCERIDES_H = "0"; }
                if (cb_uric.Checked) { f.URICACID_H = "1"; } else { f.URICACID_H = "0"; }
                if (cb_sgot.Checked) { f.SGOT_H = "1"; } else { f.SGOT_H = "0"; }
                if (cb_sgpt.Checked) { f.SGPT_H = "1"; } else { f.SGPT_H = "0"; }
                if (cb_alk.Checked) { f.ALKPHOS_H = "1"; } else { f.ALKPHOS_H = "0"; }
                f.FBS_CON_ = tx_fbs_Conventional.Text;
                f.BUN_CON_ = tx_bun_convetional.Text;
                f.CREATINE_CON_ = tx_creatinine_convetional.Text;
                f.CHOLESTEROL_CON_ = tx_choles_conventional.Text;
                f.TRIGLYCERIDES_CON_ = tx_trygly_convetion.Text;
                f.URICACID_CON_ = tx_uric_Conventional.Text;
                f.SGOT_CON_ = tx_sgot_conventional.Text;
                f.SGPT_CON_ = tx_sgpt_conventional.Text;
                f.ALKPHOS_CON_ = tx_alk_conventional.Text;
                f.remark_chem = "";
                f.ShowDialog();
            }

        }
        public void Search()
        {



        }



        public void Add_Record()
        {
            //   newlab = true;
            //LoadMedtech();
            //LoadPathologist();

            Availability(true);
            //labNo.Enabled = true;
            //MedTech.Enabled = true;
            //Pathologist.Enabled = true;
            //med_licenseNo.Enabled = true;
            //Pathologist_licenseNo.Enabled = true;
            //ClearAll();

        }



        //void LoadMedtech()
        //{

        //    try
        //    {
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Type =  'MedTech'");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            MedTech.Text = dr["Name"].ToString();
        //            med_licenseNo.Text = dr["License"].ToString();

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


        //void LoadPathologist()
        //{

        //    try
        //    {
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Type =  'Pathologist'");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            this.Pathologist.Text = dr["Name"].ToString();
        //            this.Pathologist_licenseNo.Text = dr["License"].ToString();

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




        private void frm_lab_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                if (fmain.ts_cancel_lab.Enabled == true)
                { Cancel(); }
                else
                { this.Close(); }

            }
            else if (e.KeyCode == Keys.Add && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_add_lab.Enabled == true)
                {

                    fmain.Add_lab();
                }
            }

            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_save_lab.Enabled == true)
                {
                    Save();

                }

            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_print_lab.Enabled == true)
                {
                    Print();
                }
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {

                if (fmain.ts_search_lab.Enabled == true)
                {
                    fmain.Search_Lab();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (fmain.ts_edit_lab.Enabled == true)
                {
                    Edit();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (fmain.ts_delete_lab.Enabled == true)
                {

                    Delete();
                }

            }


        }

        private void frm_lab_FormClosing(object sender, FormClosingEventArgs e)
        {
            //  fmain.Strip_sub.Visible = false;
            ClassSql.DbClose();
            fmain.laboratory = true;
            fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = false; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = false;

        }

        private void frm_lab_Load(object sender, EventArgs e)
        {


            //ClassSql.DbConnect();
            load_Hema_NormalValues();
            load_NormalCHEM();


            Availability(false);
            Cursor.Current = Cursors.Default;
            txt_papin.Select();

            //if (!backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.RunWorkerAsync();
            //}



        }




        public void Availability(bool bl)
        {

            if (bl == true)
            {
                overlayShadow1.Visible = false;
                overlayShadow1.SendToBack();
            }
            else
            {
                overlayShadow1.Visible = true;
                overlayShadow1.BringToFront();
                cmd_chemistry.BringToFront();
                cmd_Repeat_fecalysis.BringToFront();
                cmd_repeatUrinal.BringToFront();
                cmd_repeatHema.BringToFront();

            }
        }

        public void ClearAll()
        {

            Tool.ClearFields(groupBox1);
            Tool.ClearFields(groupBox2);
            Tool.ClearFields(groupBox3);
            Tool.ClearFields(groupBox4);
            Tool.ClearFields(groupBox5);
            Tool.ClearFields(groupBox6);
            Tool.ClearFields(groupBox7);
            Tool.ClearFields(groupBox8);
            Tool.ClearFields(groupBox9);
            Tool.ClearFields(groupBox10);
            Tool.ClearFields(panel4);
        }
        //void Load_Medical()
        //{

        //    try
        //    {



        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Table("SELECT tbl_medical.cn,  tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            this.MedTech.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            this.Pathologist.AutoCompleteCustomSource.Add(dr["Name"].ToString());


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


        void Medical_personnel()
        {

            //

        }


        void ClearAll_()
        {

            Tool.ClearFields(groupBox2);
            Tool.ClearFields(groupBox3);
            Tool.ClearFields(groupBox4);
            Tool.ClearFields(groupBox5);
            Tool.ClearFields(groupBox6);
            Tool.ClearFields(groupBox7);
            Tool.ClearFields(groupBox8);
            Tool.ClearFields(groupBox9);
            Tool.ClearFields(groupBox10);


        }
        private void txt_papin_TextChanged(object sender, EventArgs e)
        {
            //if (newlab)
            //{
            //    ClassSql a = new ClassSql(); int cnt;
            //    cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + Tool.ReplaceString(txt_papin.Text) + "' and resulttype = 'LAB'");
            //      if (cnt >= 1)
            //      {

            //          if (MessageBox.Show("Patient had previous laboratory examination! Would you like to update Hir/Her record?", Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //          {
            //              newlab = false;
            //              Search_Patient();                        
            //              Availability(true);
            //              dt_resultdate.Enabled = true;
            //              labNo.Enabled = true;
            //              MedTech.Enabled = true;
            //              Pathologist.Enabled = true;
            //              med_licenseNo.Enabled = true;
            //              Pathologist_licenseNo.Enabled = true;
            //          }
            //          else
            //          {
            //              newlab = true;
            //              Search_Patient();
            //              //Search_lab();
            //              Add_Record();
            //              ClearAll_();
            //          }

            //      }
            //      else
            //      {
            //          newlab = true;
            //          Search_Patient();
            //          //Search_lab();
            //          Add_Record();
            //          dt_resultdate.Enabled = true;
            //          labNo.Enabled = true;
            //          MedTech.Enabled = true;
            //          Pathologist.Enabled = true;
            //          med_licenseNo.Enabled = true;
            //          Pathologist_licenseNo.Enabled = true;

            //          ClearAll_();



            //      }


            //}
            //else
            //{
            //    Search_Patient();

            //}
            //txt_papin.Select();
            //Medical_personnel();

        }

        //public void Lab_Details()
        //{
        //    try
        //    {

        //        ClassSql a = new ClassSql(); DataTable dt;
        //        //dt = a.Table("SELECT *  FROM t_result_main WHERE t_result_main.resultid =  '" + Tool.ReplaceString(LabId.Text) + "'");
        //        dt = a.Mytable_Proc("Lab_details", "ID", LabId.Text);
        //        foreach (DataRow dr in dt.Rows)
        //        {



        //            DateTime temp_Bday;
        //            if (DateTime.TryParse(dr["result_date"].ToString(), out temp_Bday))
        //            {
        //                dt_resultdate.Format = DateTimePickerFormat.Custom;
        //                dt_resultdate.CustomFormat = "MM/dd/yyyy";
        //                this.dt_resultdate.Value = Convert.ToDateTime(dr["result_date"].ToString()).Date;
        //            }
        //            else
        //            {
        //                dt_resultdate.Format = DateTimePickerFormat.Custom;
        //                dt_resultdate.CustomFormat = "00/00/0000";
        //            }





        //            MedTech.Text = dr["medtech"].ToString();
        //            med_licenseNo.Text = dr["medtech_license"].ToString();
        //            labNo.Text = dr["specimen_no"].ToString();
        //            Pathologist.Text = dr["pathologist"].ToString();
        //            Pathologist_licenseNo.Text = dr["pathologist_license"].ToString();

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
        public void Search_lab()
        {
            try
            {

                // ClassSql a = new ClassSql(); DataTable dt;              
                //  dt = a.Mytable_Proc("Lab_detail_view", "@ID", LabId.Text);
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = (from m in db.Lab_detail_views where m.resultid == LabId.Text select m).FirstOrDefault();
                //foreach (var i in lists)
                //{



                DateTime temp_Bday;
                if (DateTime.TryParse(i.result_date.ToString(), out temp_Bday))
                {
                    dt_resultdate.Format = DateTimePickerFormat.Custom;
                    dt_resultdate.CustomFormat = "MM/dd/yyyy";
                    this.dt_resultdate.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {
                    dt_resultdate.Format = DateTimePickerFormat.Custom;
                    dt_resultdate.CustomFormat = "00/00/0000";
                }

                MedTech.Text = i.medtech.ToString();
                med_licenseNo.Text = i.medtech_license.ToString();
                labNo.Text = i.specimen_no.ToString();
                Pathologist.Text = i.pathologist.ToString();
                Pathologist_licenseNo.Text = i.pathologist_license.ToString();

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }
        public void Search_Patient()
        {
            try
            {

                //ClassSql a = new ClassSql(); DataTable dt;

                //dt = a.Table("SELECT  m_patient.cn, m_patient.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.`position`, m_patient.gender, m_patient.birthdate, m_patient.employer, m_patient.type_of_job FROM m_patient  WHERE m_patient.papin=  '" +Tool.ReplaceString(Patient_pin.Text)+ "'");
                //  dt = a.Mytable_Proc("lab_Patient", "@ID", Patient_pin.Text);
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = db.lab_patient(Patient_pin.Text).FirstOrDefault();
                //foreach (var i in lists)
                //{

                name.Text = i.latname.ToString() + ", " + i.firstname.ToString() + " " + i.middlename.ToString();
                agency.Text = i.employer.ToString();
                position.Text = i.position.ToString();

                address.Text = i.address_1.ToString();
                civil_stat.Text = i.marital_status.ToString();
                DateTime temp;
                if (DateTime.TryParse(i.birthdate.ToString(), out temp))
                {
                    dt_bady.Format = DateTimePickerFormat.Custom;
                    dt_bady.CustomFormat = "MM/dd/yyyy";

                    dt_bady.Value = Convert.ToDateTime(i.birthdate.ToString()).Date;
                }
                else
                {

                    dt_bady.Format = DateTimePickerFormat.Custom;
                    dt_bady.CustomFormat = "00/00/0000";


                }


                gender.Text = i.gender.ToString();

                //}





            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



        }

        void load_Hema_NormalValues()
        {


            IniFile ini = new IniFile(ClassSql.MMS_Path);
            hema_normal.Text = ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl";
            hematocrit_normal.Text = ini.IniReadValue("NormalValue", "hematocrit") + "vol%";
            rbc_normal.Text = ini.IniReadValue("NormalValue", "RBC") + " m/cumm";
            wbc_normal.Text = ini.IniReadValue("NormalValue", "WBC") + " /cumm";
            platelet_normal.Text = ini.IniReadValue("NormalValue", "Platelet") + "/cumm";
            label32.Text = ini.IniReadValue("NormalValue", "BloodType");
            esr_normal.Text = ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(FEMALE)";
            lymp_normal.Text = ini.IniReadValue("NormalValue", "Lympho") + "%";
            segmenter_normal.Text = ini.IniReadValue("NormalValue", "Segmenters") + "%";
            eos_normal.Text = ini.IniReadValue("NormalValue", "Easinophils") + "%";
            mono_normal.Text = ini.IniReadValue("NormalValue", "MonoCytes") + "%";
            label15.Text = ini.IniReadValue("NormalValue", "Myelocytes");
            label2.Text = ini.IniReadValue("NormalValue", "Juveniles");
            stabCells_normal.Text = ini.IniReadValue("NormalValue", "StabCells") + "%";
            baso_normal.Text = ini.IniReadValue("NormalValue", "BasoPhils") + "%";
            label30.Text = ini.IniReadValue("NormalValue", "Hema_Other");


        }

        void load_NormalCHEM()
        {


            IniFile ini = new IniFile(ClassSql.MMS_Path);
            l_fbs.Text = ini.IniReadValue("NormalValue", "fbs") + " mmol/L";
            l_bun.Text = ini.IniReadValue("NormalValue", "bun") + " mmol/L";
            L_creatinine.Text = ini.IniReadValue("NormalValue", "creatine") + " mmol/L";
            L_cholesterol.Text = ini.IniReadValue("NormalValue", "choles") + " mmol/L";
            l_trigly.Text = ini.IniReadValue("NormalValue", "trigly") + " mmol/L";
            l_UricAcid.Text = ini.IniReadValue("NormalValue", "uric") + " mmol/L";
            L_Sgot.Text = ini.IniReadValue("NormalValue", "sgot") + " IU/L";
            L_Sgpt.Text = ini.IniReadValue("NormalValue", "sgpt") + " IU/L";
            L_alk.Text = ini.IniReadValue("NormalValue", "alk") + " IU/L";
            L_fbs_con.Text = ini.IniReadValue("NormalValue", "fbs_con") + " mg/dL";
            l_bun_con.Text = ini.IniReadValue("NormalValue", "bun_con") + " mg/dL";
            L_creatine_Con.Text = ini.IniReadValue("NormalValue", "creatine_Con") + " mg/dL";
            L_Cholesterol_Con.Text = ini.IniReadValue("NormalValue", "Cholesterol_Con") + " mg/dL";
            L_Trig_Con.Text = ini.IniReadValue("NormalValue", "Trig_Con") + " mg/dL";
            l_Uric_Con.Text = ini.IniReadValue("NormalValue", "Uric_Con") + " mg/dL";
            label35.Text = ini.IniReadValue("NormalValue", "sgot_con");
            label34.Text = ini.IniReadValue("NormalValue", "sgpt_con");
            label33.Text = ini.IniReadValue("NormalValue", "alk_con");
            HbA1c_SI_Normal.Text = ini.IniReadValue("NormalValue", "HBA1C_SI") + " %";
            HbA1c_Con_Normal.Text = ini.IniReadValue("NormalValue", "HBA1C_CON") + " %";

        }


        public void Search_Hema()
        {
            try
            {

                // ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Table("SELECT  t_hematology.cn,  t_hematology.resultid, t_hematology.hemoglobin,  t_hematology.hematocrit, t_hematology.rbc_count, t_hematology.wbc_count, t_hematology.lymphocytes, t_hematology.segmenters, t_hematology.eosinophils, t_hematology.stab_cells, t_hematology.basophils, t_hematology.monocytes, t_hematology.blood_type, t_hematology.esr, t_hematology.others, t_hematology.repeat_test_id, t_hematology.myelocytes, t_hematology.juveniles, t_hematology.platelet, t_hematology.result_date FROM t_hematology  WHERE t_hematology.resultid =  '" + Tool.ReplaceString(LabId.Text) + "'");
                // dt = a.Mytable_Proc("lab_hema", "@ID", LabId.Text);
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = db.lab_hema(LabId.Text).FirstOrDefault();

                //foreach (var i in lists)
                //{

                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    Hema_RelustDate.Format = DateTimePickerFormat.Custom;
                    Hema_RelustDate.CustomFormat = "MM/dd/yyyy";
                    this.Hema_RelustDate.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {
                    Hema_RelustDate.Format = DateTimePickerFormat.Custom;
                    Hema_RelustDate.CustomFormat = "00/00/0000";
                }




                hemoglobin.Text = i.hemoglobin.ToString();
                hematocrit.Text = i.hematocrit.ToString();
                RBC.Text = i.rbc_count.ToString();
                WBC.Text = i.wbc_count.ToString();
                Platelet.Text = i.platelet.ToString();
                BloodType.Text = i.blood_type.ToString();
                ESR.Text = i.esr.ToString();
                Lympho.Text = i.lymphocytes.ToString();
                Segmenters.Text = i.segmenters.ToString();
                Easinophils.Text = i.eosinophils.ToString();
                MonoCytes.Text = i.monocytes.ToString();
                Myelocytes.Text = i.myelocytes.ToString();
                Juveniles.Text = i.juveniles.ToString();
                StabCells.Text = i.stab_cells.ToString();
                BasoPhils.Text = i.basophils.ToString();
                Hema_Other.Text = i.others.ToString();

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
        public void Search_Chemistry()
        {
            try
            {

                //  ClassSql a = new ClassSql(); DataTable dt;
                // dt = a.Table("Select * from t_clinical_chemistry Where resultid =  '" + Tool.ReplaceString(LabId.Text) + "' ");
                // dt = a.Mytable_Proc("lab_chem", "@ID", LabId.Text);

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = db.lab_chem(LabId.Text).FirstOrDefault();
                //foreach (var i in lists)
                //{

                tx_FBS.Text = i.fbs.ToString();
                txt_Bun.Text = i.bun.ToString();
                tx_Creatinine.Text = i.creatinine.ToString();
                tx_Cholesterol.Text = i.cholesterol_susp.ToString();
                tx_trigly.Text = i.cholesterol_elev.ToString();
                tx_uric.Text = i.uric_acid.ToString();
                tx_sgot.Text = i.sgot.ToString();
                tx_sgpt.Text = i.sgpt.ToString();
                tx_alk.Text = i.alk_phos.ToString();
                tx_fbs_Conventional.Text = i.fbs_con.ToString();
                tx_bun_convetional.Text = i.bun_con.ToString();
                tx_creatinine_convetional.Text = i.creatinine_con.ToString();
                tx_choles_conventional.Text = i.cholesterol_susp_con.ToString();
                tx_trygly_convetion.Text = i.cholesterol_elev_con.ToString();
                tx_uric_Conventional.Text = i.uric_acid_con.ToString();
                tx_sgot_conventional.Text = i.sgot_con.ToString();
                tx_sgpt_conventional.Text = i.sgpt_con.ToString();
                tx_alk_conventional.Text = i.alk_phos_con.ToString();
                cbo_rpr.Text = i.vdrl.ToString();
                cbo_hb.Text = i.hbsag.ToString();
                cbo_widal.Text = i.widal_test.ToString();
                cbo_malaroial.Text = i.malarial_smear.ToString();
                txt_hba1c_SI.Text = i.ahbe.ToString();
                txt_hba1c_Con.Text = i.hbeag.ToString();


                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    dt_Chemistry.Format = DateTimePickerFormat.Custom;
                    dt_Chemistry.CustomFormat = "MM/dd/yyyy";
                    this.dt_Chemistry.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {
                    dt_Chemistry.Format = DateTimePickerFormat.Custom;
                    dt_Chemistry.CustomFormat = "00/00/0000";
                }



                string FBS_ = i.fbs_high.ToString();
                string Bun_ = i.bun_high.ToString();
                string Creatinine_ = i.creatinine_high.ToString();
                string Cholesterol_ = i.cholesterol_high.ToString();
                string trigly_ = i.triglycerides_high.ToString();
                string uric_ = i.uric_acid_high.ToString();
                string sgot_ = i.sgot_high.ToString();
                string sgpt_ = i.sgpt_high.ToString();
                string alk_ = i.alk_high.ToString();

                if (FBS_ == "1") { cb_FBS.Checked = true; } else { cb_FBS.Checked = false; }
                if (Bun_ == "1") { cb_Bun.Checked = true; } else { cb_Bun.Checked = false; }
                if (Creatinine_ == "1") { cb_Creatinine.Checked = true; } else { cb_Creatinine.Checked = false; }
                if (Cholesterol_ == "1") { cb_Cholesterol.Checked = true; } else { cb_Cholesterol.Checked = false; }
                if (trigly_ == "1") { cb_trigly.Checked = true; } else { cb_trigly.Checked = false; }
                if (uric_ == "1") { cb_uric.Checked = true; } else { cb_uric.Checked = false; }
                if (sgot_ == "1") { cb_sgot.Checked = true; } else { cb_sgot.Checked = false; }
                if (sgpt_ == "1") { cb_sgpt.Checked = true; } else { cb_sgpt.Checked = false; }
                if (alk_ == "1") { cb_alk.Checked = true; } else { cb_alk.Checked = false; }

                if (cbo_rpr.Text == "") { cbo_rpr.Text = "N/A"; }
                if (cbo_hb.Text == "") { cbo_hb.Text = "N/A"; }
                if (cbo_widal.Text == "") { cbo_widal.Text = "N/A"; }
                if (cbo_malaroial.Text == "") { cbo_malaroial.Text = "N/A"; }




                //}
                // load_Hema_NormalCHEM();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("HERE An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

        }
        public void Search_Urinalysis()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = (from m in db.view_urinalysis where m.resultid.Equals(LabId.Text) select m).FirstOrDefault();

                cbo_color.Text = i.color.ToString();
                cbo_transparency.Text = i.transparency.ToString();
                tx_color_other.Text = i.color_remarks.ToString();
                cbo_leu.Text = i.leukocytes.ToString();
                cbo_nitrite.Text = i.nitrite.ToString();
                cbo_uro.Text = i.urobilinogen.ToString();
                cbo_protein.Text = i.protein.ToString();
                cbo_ph.Text = i.ph.ToString();
                cbo_blood.Text = i.blood.ToString();
                cbo_spec.Text = i.specific_gravity.ToString();
                cbo_keton.Text = i.ketone.ToString();
                cbo_bili.Text = i.bilirubin.ToString();
                cbo_glucose.Text = i.sugar.ToString();
                txt_other_chem.Text = i.others_chem.ToString();
                txt_redBlood.Text = i.red_blood_cells.ToString();
                tx_whiteBlood.Text = i.white_blood_cells.ToString();
                tx_urates.Text = i.amorphous_urates.ToString();
                tx_phosphate.Text = i.amorphous_phosphates.ToString();
                tx_cells.Text = i.epithelial_cells.ToString();
                tx_musus.Text = i.mucus_threads.ToString();
                tx_other_micro.Text = i.microscopic_others.ToString();
                tx_uric_crystal.Text = i.uric_acid.ToString();
                tx_caium.Text = i.calcium_oxalate.ToString();
                tx_other_Crystals.Text = i.others_crystals.ToString();
                tx_Granular.Text = i.fine_granular.ToString();
                tx_coarse.Text = i.coarse_granular.ToString();
                tx_other_cast.Text = i.cast_others.ToString();



                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    dt_Result_urinal.Format = DateTimePickerFormat.Custom;
                    dt_Result_urinal.CustomFormat = "MM/dd/yyyy";
                    dt_Result_urinal.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {
                    dt_Result_urinal.Format = DateTimePickerFormat.Custom;
                    dt_Result_urinal.CustomFormat = "00/00/0000";
                }

                // dt_Result_urinal.Text = dr["result_date"].ToString();

                //  }

                if (cbo_bili.Text == "") { cbo_bili.Text = "[n/a]"; }
                if (this.cbo_blood.Text == "") { cbo_blood.Text = "[n/a]"; }
                if (this.cbo_color.Text == "") { cbo_color.Text = "[n/a]"; }
                if (this.cbo_glucose.Text == "") { cbo_glucose.Text = "[n/a]"; }
                if (this.cbo_keton.Text == "") { cbo_keton.Text = "[n/a]"; }
                if (this.cbo_leu.Text == "") { cbo_leu.Text = "[n/a]"; }
                if (this.cbo_nitrite.Text == "") { cbo_nitrite.Text = "[n/a]"; }
                if (this.cbo_ph.Text == "") { cbo_ph.Text = "[n/a]"; }
                if (this.cbo_protein.Text == "") { cbo_protein.Text = "[n/a]"; }
                if (this.cbo_spec.Text == "") { cbo_spec.Text = "[n/a]"; }
                if (this.cbo_transparency.Text == "") { cbo_transparency.Text = "[n/a]"; }
                if (this.cbo_uro.Text == "")
                {
                    cbo_uro.Text = "[n/a]";
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }
        public void Search_Fecalysis()
        {
            try
            {

                //  ClassSql a = new ClassSql(); DataTable dt;

                //  dt = a.Table("Select * from t_fecalysis where  resultid = '" + Tool.ReplaceString(LabId.Text) + "' ");
                // dt = a.Mytable_Proc("lab_Fecalysis", "@ID", LabId.Text);
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var i = db.lab_fecalysis(LabId.Text).FirstOrDefault();
                //foreach (var i in lists)
                //{


                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    dt_resultDate_Fecalysis.Format = DateTimePickerFormat.Custom;
                    dt_resultDate_Fecalysis.CustomFormat = "MM/dd/yyyy";
                    dt_resultDate_Fecalysis.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {
                    dt_resultDate_Fecalysis.Format = DateTimePickerFormat.Custom;
                    dt_resultDate_Fecalysis.CustomFormat = "00/00/0000";
                }


                // dt_resultDate_Fecalysis.Text = dr["result_date"].ToString();

                cbo_color_fecal.Text = i.color.ToString();
                cbo_consistency.Text = i.consistency.ToString();
                txt_color_other_fecal.Text = i.color_others.ToString();
                tx_red_fecal.Text = i.red_blood_cells.ToString();
                tx_whitBlood_fecal.Text = i.white_blood_cells.ToString();
                txt_other_Fecalysis.Text = i.others.ToString();
                tx_ova.Text = i.ova_parasite.ToString();
                tx_amoeba.Text = i.amoeba.ToString();
                tx_occultBloodTest.Text = i.occult_blood.ToString();

                if (cbo_color_fecal.Text == "") { cbo_color_fecal.Text = "N/A"; }
                if (cbo_consistency.Text == "") { cbo_consistency.Text = "N/A"; }

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }
        private void dt_bady_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
            if (dt_bady.Text != "" || dt_bady.Text != "0000-00-00 00:00:00" || dt_bady.Text != "00/00/0000")
            {
                int age_ = DateTime.Now.Year - dt_bady.Value.Year;
                txt_age.Text = age_.ToString();

                DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
                int Age = CurrentDate.Year - dt_bady.Value.Year;

                if (CurrentDate.Month < dt_bady.Value.Month)
                {
                    Age--;
                }
                else if ((CurrentDate.Month == dt_bady.Value.Month) && (CurrentDate.Day < dt_bady.Value.Day))
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







        private void cbo_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_color.Text == "[other]") { tx_color_other.Visible = true; } else { tx_color_other.Visible = false; tx_color_other.Clear(); }
        }

        private void cbo_color_fecal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_color_fecal.Text == "[other]") { txt_color_other_fecal.Visible = true; } else { txt_color_other_fecal.Visible = false; txt_color_other_fecal.Clear(); }
        }

        private void cmd_repeatHema_Click(object sender, EventArgs e)
        {
            using (frm_repeat_Hema f = new frm_repeat_Hema(this))
            {
                f.Tag = Patient_pin.Text;
                f.PatientName = name.Text;
                f.Sex = gender.Text;
                f.Address = address.Text;
                f.CivilStatus = civil_stat.Text;
                f.Age = txt_age.Text;
                f.Position = position.Text;
                f.ShowDialog();
            }



        }

        private void cmd_chemistry_Click(object sender, EventArgs e)
        {
            frm_repeat_Chemistry f = new frm_repeat_Chemistry(this);
            f.Tag = Patient_pin.Text;
            //   f_chem.Text = Patient_pin.Text;

            f.Age = txt_age.Text;
            f.PatientName = name.Text;
            f.Sex = gender.Text;
            f.Address = address.Text;
            f.CivilStatus = civil_stat.Text;
            f.Age = txt_age.Text;
            f.Position = position.Text;
            f.ShowDialog();
        }

        //void Delete_Record()
        //{

        //    try
        //    {


        //        ClassSql a = new ClassSql();
        //        a.ExecuteQuery("Delete from t_med_history where resultid = '" + LabId.Text + "' and resulttype= 'LAB'");
        //        a.ExecuteQuery("Delete from t_med_history2 where resultid = '" + LabId.Text + "' and resulttype= 'LAB'");
        //        a.ExecuteQuery("Delete from t_phy_exam where resultid = '" + LabId.Text + "' and resulttype= 'LAB'");
        //        a.ExecuteQuery("Delete from t_others where resultid = '" + LabId.Text + "' and resulttype= 'LAB'");
        //        a.ExecuteQuery("Delete from t_ancillary where resultid = '" + LabId.Text + "' and resulttype= 'LAB'");
        //        a.ExecuteQuery("Delete from t_result_main where resultid = '" + LabId.Text + "' and resulttype= 'LAB'");

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


        private void labID_TextChanged(object sender, EventArgs e)
        {
            //Search_lab();          
            //Search_Hema();
            //Search_Chemistry();
            //Search_Urinalysis();
            //Search_Fecalysis();


            //if (LabId.Text == "")
            //{

            //    fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = false; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = false;
            //}
            //else
            //{
            //    fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = true; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = false;
            //}





        }

        private void cmd_repeatUrinal_Click(object sender, EventArgs e)
        {
            ClassSql.DbClose();
            frm_repeat_Urninalysis f = new frm_repeat_Urninalysis(this);
            f.Tag = Patient_pin.Text;
            f.Age = txt_age.Text;
            f.PatientName = name.Text;
            f.Sex = gender.Text;
            f.Address = address.Text;
            f.CivilStatus = civil_stat.Text;
            f.Position = position.Text;
            f.ShowDialog();
        }

        private void cmd_Repeat_fecalysis_Click(object sender, EventArgs e)
        {
            frm_repeat_Fecalysis f = new frm_repeat_Fecalysis(this);
            f.Tag = Patient_pin.Text;
            f.Age = txt_age.Text;
            f.PatientName = name.Text;
            f.Sex = gender.Text;
            f.Address = address.Text;
            f.CivilStatus = civil_stat.Text;
            f.Age = txt_age.Text;
            f.Position = position.Text;
            f.ShowDialog();
        }

        private void frm_lab_Leave(object sender, EventArgs e)
        {
            Main.Strip_Lab_.Visible = false;
        }

        private void ts_add_lab_Click(object sender, EventArgs e)
        {




        }

        private void ts_search_lab_Click(object sender, EventArgs e)
        {

        }

        private void ts_edit_lab_Click(object sender, EventArgs e)
        {


        }



        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void ts_save_lab_Click(object sender, EventArgs e)
        {

        }

        private void New_update_Lab()
        {



        }

        //public void Update_Chem()
        //{
        //    try
        //    {





        //        ClassSql a = new ClassSql();

        //        if (cb_FBS.Checked == true) { FBS_ = "1"; } else { FBS_ = "0"; }
        //           Search_Chemistry();


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
        //public void Update_Fecalysis()
        //{
        //    try
        //    {

        //        ClassSql a = new ClassSql();
        //          Tool.MessageBoxUpdate();
        //      //  Search_Fecalysis();


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

        void insert()
        {
            try
            {
                if (cb_FBS.Checked == true) { FBS_ = "1"; } else { FBS_ = "0"; }
                if (cb_Bun.Checked == true) { Bun_ = "1"; } else { Bun_ = "0"; }
                if (cb_Creatinine.Checked == true) { Creatinine_ = "1"; } else { Creatinine_ = "0"; }
                if (cb_Cholesterol.Checked == true) { Cholesterol_ = "1"; } else { Cholesterol_ = "0"; }
                if (cb_trigly.Checked == true) { trigly_ = "1"; } else { trigly_ = "0"; }
                if (cb_uric.Checked == true) { uric_ = "1"; } else { uric_ = "0"; }
                if (cb_sgot.Checked == true) { sgot_ = "1"; } else { sgot_ = "0"; }
                if (cb_sgpt.Checked == true) { sgpt_ = "1"; } else { sgpt_ = ""; }
                if (cb_alk.Checked == false) { alk_ = "1"; } else { alk_ = "0"; }

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);

                db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", LabId.Text, "LAB", Patient_pin.Text, dt_resultdate.Text, Pathologist.Text, "PENDING", "", "", "", "", "", labNo.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, LabId.Text, "", "", "", "", "", "", "", "");
                db.ExecuteCommand("INSERT INTO t_hematology (resultid, hemoglobin, hematocrit, rbc_count, wbc_count, lymphocytes, segmenters, eosinophils, stab_cells, basophils, monocytes, blood_type, esr, others, repeat_test_id, myelocytes, juveniles, platelet, result_date) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})", LabId.Text, hemoglobin.Text, hematocrit.Text, RBC.Text, WBC.Text, Lympho.Text, Segmenters.Text, Easinophils.Text, StabCells.Text, BasoPhils.Text, MonoCytes.Text, BloodType.Text, ESR.Text, Hema_Other.Text, "", Myelocytes.Text, Juveniles.Text, Platelet.Text, Hema_RelustDate.Text);
                db.ExecuteCommand("INSERT INTO t_clinical_chemistry (resultid, fbs, fbs_con, bun, bun_con, creatinine, creatinine_con, cholesterol_susp, cholesterol_susp_con, cholesterol_elev, cholesterol_elev_con, uric_acid, uric_acid_con, sgot, sgot_con, sgpt, sgpt_con, alk_phos, alk_phos_con, vdrl, hbsag, ahbe, hbeag, widal_test, malarial_smear, hiv, hbsag_titer, ahbe_titer, hbeag_titer, plasmodium, repeat_test_id, fbs_high, bun_high, creatinine_high, cholesterol_high, triglycerides_high, uric_acid_high, sgot_high, sgpt_high, alk_high, result_date) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40})", LabId.Text, tx_FBS.Text, tx_fbs_Conventional.Text, txt_Bun.Text, tx_bun_convetional.Text, tx_Creatinine.Text, tx_creatinine_convetional.Text, tx_Cholesterol.Text, tx_choles_conventional.Text, tx_trigly.Text, tx_trygly_convetion.Text, tx_uric.Text, tx_uric_Conventional.Text, tx_sgot.Text, tx_sgot_conventional.Text, tx_sgpt.Text, tx_sgpt_conventional.Text, tx_alk.Text, tx_alk_conventional.Text, cbo_rpr.Text, cbo_hb.Text, txt_hba1c_SI.Text, txt_hba1c_Con.Text, cbo_widal.Text, cbo_malaroial.Text, "", "", "", "", "", "", FBS_.ToString(), Bun_.ToString(), Creatinine_.ToString(), Cholesterol_.ToString(), trigly_.ToString(), uric_.ToString(), sgot_.ToString(), sgpt_.ToString(), alk_.ToString(), dt_Chemistry.Text);
                db.ExecuteCommand("INSERT INTO t_urinalysis (resultid, color, transparency, reaction, specific_gravity, sugar, albumin, blood, fine_granular, coarse_granular, hyaline, waxy, rbc, pus, mixed, red_blood_cells, white_blood_cells, calcium_oxalate, uric_acid, triple_phosphate, others_crystals, amorphous_urates, amorphous_phosphates, epithelial_cells, renal_cells, bacteria, mucus_threads, color_remarks, others_specified, repeat_test_id, urine_bile, others_chem, leukocytes, yeast_cells, squamous, result_date, nitrite, urobilinogen, protein, ph, ketone, bilirubin, microscopic_others, cast_others) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43})", LabId.Text, cbo_color.Text, cbo_transparency.Text, "", cbo_spec.Text, cbo_glucose.Text, txt_other_chem.Text, cbo_blood.Text, tx_Granular.Text, tx_coarse.Text, "", "", "", "", "", txt_redBlood.Text, tx_whiteBlood.Text, tx_caium.Text, tx_uric_crystal.Text, "", tx_other_Crystals.Text, tx_urates.Text, tx_phosphate.Text, this.tx_cells.Text, "", "", tx_musus.Text, tx_color_other.Text, "", "", "", "", cbo_leu.Text, "", "", dt_resultdate.Text, cbo_nitrite.Text, cbo_uro.Text, cbo_protein.Text, cbo_ph.Text, cbo_keton.Text, cbo_bili.Text, tx_other_micro.Text, tx_other_cast.Text);
                db.ExecuteCommand("INSERT INTO t_fecalysis (resultid, color, ova_parasite, consistency, red_blood_cells, white_blood_cells, amoeba, others, occult_blood, repeat_test_id, pus_cells, mucus, result_date, color_others) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})", LabId.Text, cbo_color_fecal.Text, tx_ova.Text, cbo_consistency.Text, tx_red_fecal.Text, tx_whitBlood_fecal.Text, tx_amoeba.Text, txt_other_Fecalysis.Text, tx_occultBloodTest.Text, "", "", "", dt_resultDate_Fecalysis.Text, txt_color_other_fecal.Text);

                labsearch.Clear(); QueueSearchList_Model.Clear();
                if (!backgroundWorker1.IsBusy)
                { backgroundWorker1.RunWorkerAsync(); }


                //Search_Hema();                Search_Chemistry();                Search_Urinalysis();                Search_Urinalysis();              
                txt_papin.Select();
                Availability(false);
                fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = true; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = true;
                cmd_chemistry.Enabled = true; cmd_Repeat_fecalysis.Enabled = true; cmd_repeatUrinal.Enabled = true; cmd_repeatHema.Enabled = true;

                //Tool.MessageBoxUpdate();
                //Tool.MessageBoxSave();
                //  Search_Fecalysis();


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
        public void Update_Medical()
        {
            try
            {
                if (cb_FBS.Checked == true) { FBS_ = "1"; } else { FBS_ = "0"; }
                if (cb_Bun.Checked == true) { Bun_ = "1"; } else { Bun_ = "0"; }
                if (cb_Creatinine.Checked == true) { Creatinine_ = "1"; } else { Creatinine_ = "0"; }
                if (cb_Cholesterol.Checked == true) { Cholesterol_ = "1"; } else { Cholesterol_ = "0"; }
                if (cb_trigly.Checked == true) { trigly_ = "1"; } else { trigly_ = "0"; }
                if (cb_uric.Checked == true) { uric_ = "1"; } else { uric_ = "0"; }
                if (cb_sgot.Checked == true) { sgot_ = "1"; } else { sgot_ = "0"; }
                if (cb_sgpt.Checked == true) { sgpt_ = "1"; } else { sgpt_ = "0"; }
                if (cb_alk.Checked == true) { alk_ = "1"; } else { alk_ = "0"; }


                // ClassSql a = new ClassSql();
                //string a = "UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `pathologist`='" + Tool.ReplaceString(Pathologist.Text) + "', `specimen_no`='" + Tool.ReplaceString(labNo.Text) + "', `medtech`='" + Tool.ReplaceString(MedTech.Text) + "', `medtech_license`='" + Tool.ReplaceString(med_licenseNo.Text) + "', `pathologist_license`='" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "' WHERE (`resultid`='" + Tool.ReplaceString(txt_resultId.Text) + "') LIMIT 1";
                //string b = "UPDATE `t_hematology` SET `hemoglobin`='" + Tool.ReplaceString(hemoglobin.Text) + "', `hematocrit`='" + Tool.ReplaceString(this.hematocrit.Text) + "', `rbc_count`='" + Tool.ReplaceString(this.RBC.Text) + "', `wbc_count`='" + Tool.ReplaceString(this.WBC.Text) + "', `lymphocytes`='" + Tool.ReplaceString(this.Lympho.Text) + "', `segmenters`='" + Tool.ReplaceString(this.Segmenters.Text) + "', `eosinophils`='" + Tool.ReplaceString(this.Easinophils.Text) + "', `stab_cells`='" + Tool.ReplaceString(this.StabCells.Text) + "', `basophils`='" + Tool.ReplaceString(this.BasoPhils.Text) + "', `monocytes`='" + Tool.ReplaceString(this.MonoCytes.Text) + "', `blood_type`='" + Tool.ReplaceString(this.BloodType.Text) + "', `esr`='" + Tool.ReplaceString(this.ESR.Text) + "', `others`='" + Tool.ReplaceString(this.Hema_Other.Text) + "', `repeat_test_id`='" + Tool.ReplaceString(txt_resultId.Text) + "', `myelocytes`='" + Tool.ReplaceString(this.Myelocytes.Text) + "', `juveniles`='" + Tool.ReplaceString(this.Juveniles.Text) + "', `platelet`='" + Tool.ReplaceString(this.Platelet.Text) + "', `result_date`='" + Tool.ReplaceString(this.Hema_RelustDate.Text) + "' WHERE (`resultid`='" + txt_resultId.Text + "') LIMIT 1";
                //string c = "UPDATE `t_clinical_chemistry` SET  `fbs`='" + Tool.ReplaceString(tx_FBS.Text) + "', `fbs_con`='" + Tool.ReplaceString(this.tx_fbs_Conventional.Text) + "', `bun`='" + Tool.ReplaceString(this.txt_Bun.Text) + "', `bun_con`='" + Tool.ReplaceString(this.tx_bun_convetional.Text) + "', `creatinine`='" + Tool.ReplaceString(this.tx_Creatinine.Text) + "', `creatinine_con`='" + Tool.ReplaceString(this.tx_creatinine_convetional.Text) + "', `cholesterol_susp`='" + Tool.ReplaceString(this.tx_Cholesterol.Text) + "', `cholesterol_susp_con`='" + Tool.ReplaceString(this.tx_choles_conventional.Text) + "', `cholesterol_elev`='" + Tool.ReplaceString(this.tx_trigly.Text) + "', `cholesterol_elev_con`='" + Tool.ReplaceString(this.tx_trygly_convetion.Text) + "', `uric_acid`='" + Tool.ReplaceString(this.tx_uric.Text) + "', `uric_acid_con`='" + Tool.ReplaceString(this.tx_uric_Conventional.Text) + "', `sgot`='" + Tool.ReplaceString(this.tx_sgot.Text) + "', `sgot_con`='" + Tool.ReplaceString(this.tx_sgot_conventional.Text) + "', `sgpt`='" + Tool.ReplaceString(this.tx_sgpt.Text) + "', `sgpt_con`='" + Tool.ReplaceString(this.tx_sgpt_conventional.Text) + "', `alk_phos`='" + Tool.ReplaceString(this.tx_alk.Text) + "', `alk_phos_con`='" + Tool.ReplaceString(this.tx_alk_conventional.Text) + "', `vdrl`='" + Tool.ReplaceString(this.cbo_rpr.Text) + "', `hbsag`='" + Tool.ReplaceString(this.cbo_hb.Text) + "', `ahbe`='" + Tool.ReplaceString(txt_hba1c_SI.Text) + "', `hbeag`='" + Tool.ReplaceString(txt_hba1c_Con.Text) + "', `widal_test`='" + Tool.ReplaceString(this.cbo_widal.Text) + "', `malarial_smear`='" + Tool.ReplaceString(this.cbo_malaroial.Text) + "', `hiv`='', `hbsag_titer`='', `ahbe_titer`='', `hbeag_titer`='', `plasmodium`='', `repeat_test_id`='" + Tool.ReplaceString(txt_resultId.Text) + "', `fbs_high`='" + FBS_.ToString() + "', `bun_high`='" + Bun_.ToString() + "', `creatinine_high`='" + Creatinine_.ToString() + "', `cholesterol_high`='" + Cholesterol_.ToString() + "', `triglycerides_high`='" + trigly_.ToString() + "', `uric_acid_high`='" + uric_.ToString() + "', `sgot_high`='" + sgot_.ToString() + "', `sgpt_high`='" + sgpt_.ToString() + "', `alk_high`='" + alk_.ToString() + "', `result_date`='" + Tool.ReplaceString(dt_Chemistry.Text) + "' WHERE (`resultid`='" + LabId.Text + "') LIMIT 1";
                //string d = "UPDATE `t_urinalysis` SET  `color`='" + Tool.ReplaceString(cbo_color.Text) + "', `transparency`='" + Tool.ReplaceString(cbo_transparency.Text) + "', `specific_gravity`='" + Tool.ReplaceString(this.cbo_spec.Text) + "', `sugar`='" + Tool.ReplaceString(cbo_glucose.Text) + "', `blood`='" + Tool.ReplaceString(cbo_blood.Text) + "', `fine_granular`='" + Tool.ReplaceString(tx_Granular.Text) + "', `coarse_granular`='" + Tool.ReplaceString(tx_coarse.Text) + "',`red_blood_cells`='" + Tool.ReplaceString(txt_redBlood.Text) + "', `white_blood_cells`='" + Tool.ReplaceString(tx_whiteBlood.Text) + "', `calcium_oxalate`='" + Tool.ReplaceString(tx_caium.Text) + "', `uric_acid`='" + Tool.ReplaceString(tx_uric_crystal.Text) + "',  `others_crystals`='" + Tool.ReplaceString(tx_other_Crystals.Text) + "', `amorphous_urates`='" + Tool.ReplaceString(this.tx_urates.Text) + "', `amorphous_phosphates`='" + Tool.ReplaceString(this.tx_phosphate.Text) + "', `epithelial_cells`='" + Tool.ReplaceString(tx_cells.Text) + "', `mucus_threads`='" + Tool.ReplaceString(tx_musus.Text) + "', `color_remarks`='" + Tool.ReplaceString(tx_color_other.Text) + "', `others_specified`='', `repeat_test_id`='" + Tool.ReplaceString(txt_resultId.Text) + "',  `leukocytes`='" + Tool.ReplaceString(cbo_leu.Text) + "',`result_date`='" + Tool.ReplaceString(dt_Result_urinal.Text) + "', `nitrite`='" + Tool.ReplaceString(cbo_nitrite.Text) + "', `urobilinogen`='" + Tool.ReplaceString(cbo_uro.Text) + "', `protein`='" + Tool.ReplaceString(cbo_protein.Text) + "', `ph`='" + Tool.ReplaceString(cbo_ph.Text) + "', `ketone`='" + Tool.ReplaceString(cbo_keton.Text) + "', `bilirubin`='" + Tool.ReplaceString(cbo_bili.Text) + "', `microscopic_others`='" + Tool.ReplaceString(tx_other_micro.Text) + "', `cast_others`='" + Tool.ReplaceString(tx_other_cast.Text) + "' WHERE (`resultid`='" + txt_resultId.Text + "') LIMIT 1";
                //string e  =  "UPDATE `t_fecalysis` SET  `color`='" + Tool.ReplaceString(cbo_color_fecal.Text) + "', `ova_parasite`='" + Tool.ReplaceString(tx_ova.Text) + "', `consistency`='" + Tool.ReplaceString(this.cbo_consistency.Text) + "', `red_blood_cells`='" + Tool.ReplaceString(this.tx_red_fecal.Text) + "', `white_blood_cells`='" + Tool.ReplaceString(this.tx_whitBlood_fecal.Text) + "', `amoeba`='" + Tool.ReplaceString(this.tx_amoeba.Text) + "', `others`='" + Tool.ReplaceString(this.txt_other_Fecalysis.Text) + "', `occult_blood`='" + Tool.ReplaceString(this.tx_occultBloodTest.Text) + "', `repeat_test_id`='" + Tool.ReplaceString(txt_resultId.Text) + "', `result_date`='" + Tool.ReplaceString(this.dt_resultDate_Fecalysis.Text) + "', `color_others`='" + Tool.ReplaceString(this.txt_color_other_fecal.Text) + "' WHERE (`resultid`='" + txt_resultId.Text + "') LIMIT 1";
                //var arr = new[] { a, b, c, d, e };
                //File.WriteAllLines(ClassSql.tmp_path, arr);

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                db.ExecuteCommand("UPDATE t_result_main SET result_date={0}, pathologist={1}, specimen_no={2}, medtech={3}, medtech_license={4}, pathologist_license={5} WHERE resultid={6}", dt_resultdate.Text, Pathologist.Text, labNo.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, txt_resultId.Text);
                db.ExecuteCommand("UPDATE t_hematology SET hemoglobin={0}, hematocrit={1}, rbc_count={2}, wbc_count={3}, lymphocytes={4}, segmenters={5}, eosinophils={6}, stab_cells={7}, basophils={8}, monocytes={9}, blood_type={10}, esr={11}, others={12}, repeat_test_id={13}, myelocytes={14}, juveniles={15}, platelet={16}, result_date={17} WHERE (resultid={18})", hemoglobin.Text, hematocrit.Text, RBC.Text, WBC.Text, Lympho.Text, Segmenters.Text, Easinophils.Text, StabCells.Text, BasoPhils.Text, MonoCytes.Text, BloodType.Text, ESR.Text, Hema_Other.Text, txt_resultId.Text, Myelocytes.Text, Juveniles.Text, Platelet.Text, Hema_RelustDate.Text, txt_resultId.Text);
                db.ExecuteCommand("UPDATE t_clinical_chemistry SET  fbs={0}, fbs_con={1}, bun={2}, bun_con={3}, creatinine={4}, creatinine_con={5}, cholesterol_susp={6}, cholesterol_susp_con={7}, cholesterol_elev={8}, cholesterol_elev_con={9}, uric_acid={10}, uric_acid_con={11}, sgot={12}, sgot_con={13}, sgpt={14}, sgpt_con={15}, alk_phos={16}, alk_phos_con={17}, vdrl={18}, hbsag={19}, ahbe={20}, hbeag={21}, widal_test={22}, malarial_smear={23}, hiv={24}, hbsag_titer={25}, ahbe_titer={26}, hbeag_titer={27}, plasmodium={28}, repeat_test_id={29}, fbs_high={30}, bun_high={31}, creatinine_high={32}, cholesterol_high={33}, triglycerides_high={34}, uric_acid_high={35}, sgot_high={36}, sgpt_high={37}, alk_high={38}, result_date={39} WHERE resultid={40}", tx_FBS.Text, this.tx_fbs_Conventional.Text, this.txt_Bun.Text, this.tx_bun_convetional.Text, this.tx_Creatinine.Text, this.tx_creatinine_convetional.Text, this.tx_Cholesterol.Text, this.tx_choles_conventional.Text, this.tx_trigly.Text, this.tx_trygly_convetion.Text, this.tx_uric.Text, this.tx_uric_Conventional.Text, this.tx_sgot.Text, this.tx_sgot_conventional.Text, this.tx_sgpt.Text, this.tx_sgpt_conventional.Text, this.tx_alk.Text, this.tx_alk_conventional.Text, this.cbo_rpr.Text, this.cbo_hb.Text, txt_hba1c_SI.Text, txt_hba1c_Con.Text, this.cbo_widal.Text, this.cbo_malaroial.Text, "", "", "", "", "", txt_resultId.Text, FBS_.ToString(), Bun_.ToString(), Creatinine_.ToString(), Cholesterol_.ToString(), trigly_.ToString(), uric_.ToString(), sgot_.ToString(), sgpt_.ToString(), alk_.ToString(), dt_Chemistry.Text, LabId.Text);
                db.ExecuteCommand("UPDATE t_urinalysis SET  color={0}, transparency={1}, specific_gravity={2}, sugar={3}, blood={4}, fine_granular={5}, coarse_granular={6},red_blood_cells={7}, white_blood_cells={8}, calcium_oxalate={9}, uric_acid={10},  others_crystals={11}, amorphous_urates={12}, amorphous_phosphates={13}, epithelial_cells={14}, mucus_threads={15}, color_remarks={16}, others_specified={17}, repeat_test_id={18},  leukocytes={19},result_date={20}, nitrite={21}, urobilinogen={22}, protein={23}, ph={24}, ketone={25}, bilirubin={26}, microscopic_others={27}, cast_others={28}, others_chem={29} WHERE (resultid={30})", cbo_color.Text, cbo_transparency.Text, this.cbo_spec.Text, cbo_glucose.Text, cbo_blood.Text, tx_Granular.Text, tx_coarse.Text, txt_redBlood.Text, tx_whiteBlood.Text, tx_caium.Text, tx_uric_crystal.Text, tx_other_Crystals.Text, this.tx_urates.Text, this.tx_phosphate.Text, this.tx_phosphate.Text, tx_musus.Text, tx_color_other.Text, "", txt_resultId.Text, cbo_leu.Text, dt_Result_urinal.Text, cbo_nitrite.Text, cbo_uro.Text, cbo_protein.Text, cbo_ph.Text, cbo_keton.Text, cbo_bili.Text, tx_other_micro.Text, tx_other_cast.Text, txt_other_chem.Text, txt_resultId.Text);
                db.ExecuteCommand("UPDATE t_fecalysis SET  color={0}, ova_parasite={1}, consistency={2}, red_blood_cells={3}, white_blood_cells={4}, amoeba={5}, others={6}, occult_blood={7}, repeat_test_id={8}, result_date={9}, color_others={10} WHERE resultid={11}", cbo_color_fecal.Text, tx_ova.Text, cbo_consistency.Text, tx_red_fecal.Text, tx_whitBlood_fecal.Text, tx_amoeba.Text, txt_other_Fecalysis.Text, tx_occultBloodTest.Text, txt_resultId.Text, dt_resultDate_Fecalysis.Text, txt_color_other_fecal.Text, txt_resultId.Text);

                //Tool.MessageBoxUpdate();
                txt_papin.Select();
                newlab = true;
                fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = true; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = true;
                cmd_chemistry.Enabled = true; cmd_Repeat_fecalysis.Enabled = true; cmd_repeatUrinal.Enabled = true; cmd_repeatHema.Enabled = true;
                Availability(false);


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //    if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}


        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    LoadNormalValue();
        //}


        private void dt_resultdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                dt_resultdate.Format = DateTimePickerFormat.Custom;
                dt_resultdate.CustomFormat = "00/00/0000";

            }
        }

        private void dt_resultdate_MouseDown(object sender, MouseEventArgs e)
        {
            dt_resultdate.Format = DateTimePickerFormat.Custom;
            dt_resultdate.CustomFormat = "MM/dd/yyyy";
        }

        private void Hema_RelustDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                Hema_RelustDate.Format = DateTimePickerFormat.Custom;
                Hema_RelustDate.CustomFormat = "00/00/0000";

            }

        }

        private void Hema_RelustDate_MouseDown(object sender, MouseEventArgs e)
        {
            Hema_RelustDate.Format = DateTimePickerFormat.Custom;
            Hema_RelustDate.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_Chemistry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                dt_Chemistry.Format = DateTimePickerFormat.Custom;
                dt_Chemistry.CustomFormat = "00/00/0000";

            }
        }

        private void dt_Chemistry_MouseDown(object sender, MouseEventArgs e)
        {
            dt_Chemistry.Format = DateTimePickerFormat.Custom;
            dt_Chemistry.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_Result_urinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                dt_Result_urinal.Format = DateTimePickerFormat.Custom;
                dt_Result_urinal.CustomFormat = "00/00/0000";

            }
        }

        private void dt_Result_urinal_MouseDown(object sender, MouseEventArgs e)
        {
            dt_Result_urinal.Format = DateTimePickerFormat.Custom;
            dt_Result_urinal.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_resultDate_Fecalysis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {

                dt_resultDate_Fecalysis.Format = DateTimePickerFormat.Custom;
                dt_resultDate_Fecalysis.CustomFormat = "00/00/0000";

            }
        }

        private void dt_resultDate_Fecalysis_MouseDown(object sender, MouseEventArgs e)
        {
            dt_resultDate_Fecalysis.Format = DateTimePickerFormat.Custom;
            dt_resultDate_Fecalysis.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_resultdate_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void Hema_RelustDate_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_Chemistry_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_Result_urinal_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_resultDate_Fecalysis_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void tx_fbs_Conventional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_fbs_Conventional.Text) * Convert.ToDouble(0.0555);
                tx_FBS.Text = result.ToString("0.0");
            }
            catch
            { tx_FBS.Clear(); }





        }

        private void tx_fbs_Conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_fbs_Conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_bun_convetional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_bun_convetional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_creatinine_convetional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_creatinine_convetional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_choles_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && tx_choles_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_trygly_convetion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_trygly_convetion.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_uric_Conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
             && !char.IsDigit(e.KeyChar)
             && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_uric_Conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_sgot_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_sgot_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_sgpt_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_sgpt_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_alk_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
           && !char.IsDigit(e.KeyChar)
           && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_alk_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_FBS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                      && !char.IsDigit(e.KeyChar)
                      && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_FBS.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_Bun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                      && !char.IsDigit(e.KeyChar)
                      && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && txt_Bun.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_Creatinine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                      && !char.IsDigit(e.KeyChar)
                      && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.'
                && tx_Creatinine.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_Cholesterol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_Cholesterol.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_trigly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_trigly.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_uric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_uric.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_sgot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_sgot.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_sgpt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_sgpt.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_alk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_alk.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_bun_convetional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_bun_convetional.Text) * Convert.ToDouble(0.357);
                txt_Bun.Text = result.ToString("0.0");
            }
            catch
            { txt_Bun.Clear(); }


        }

        private void tx_creatinine_convetional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_creatinine_convetional.Text) * Convert.ToDouble(88.4);
                this.tx_Creatinine.Text = result.ToString("0.0");
            }
            catch
            { tx_Creatinine.Clear(); }


        }

        private void tx_choles_conventional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_choles_conventional.Text) * Convert.ToDouble(0.0259);
                this.tx_Cholesterol.Text = result.ToString("0.0");
            }
            catch
            { tx_Cholesterol.Clear(); }


        }

        private void tx_trygly_convetion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_trygly_convetion.Text) / Convert.ToDouble(88.5);
                this.tx_trigly.Text = result.ToString("0.00");
            }
            catch
            { tx_trigly.Clear(); }


        }

        private void tx_uric_Conventional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_uric_Conventional.Text) * Convert.ToDouble(0.059);
                this.tx_uric.Text = result.ToString("0.00");
            }
            catch
            { tx_uric.Clear(); }


        }

        private void cmd_load1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = MedTech;
                f.txt_license = med_licenseNo;
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = Pathologist;
                f.txt_license = Pathologist_licenseNo;
                f.ShowDialog();
            }
        }

        private void tx_sgot_conventional_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_sgot_TextChanged(object sender, EventArgs e)
        {

        }



        //this is in frm_lab

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                foreach (var item in db.lab_search("%"))
                {
                    labsearch.Add(new laboratory_search
                    {
                        cn = item.cn,
                        papin = item.papin,
                        PatientName = item.PatientName,
                        resultid = item.resultid,
                        resultdate = item.result_date
                    });


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }




        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                foreach (var i in db.Search_patient_add_a("%"))
                {
                    QueueSearchList_Model.Add(new QueueSearchList_Model
                    {
                        cn = i.cn,
                        papin = i.papin,
                        PatientName = i.lastname + ", " + i.firstname + " " + i.middlename,
                        gender = i.gender,

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
                if (!backgroundWorker2.IsBusy)
                { backgroundWorker2.RunWorkerAsync(); }


                if ((Application.OpenForms["frm_search_Lab"] as frm_search_Lab) != null)
                {

                    (Application.OpenForms["frm_search_Lab"] as frm_search_Lab).FillDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }




        }

        private void frm_lab_Enter(object sender, EventArgs e)
        {
            labsearch.Clear();
            QueueSearchList_Model.Clear();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }


    }
}
