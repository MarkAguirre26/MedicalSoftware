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
using MySql.Data.MySqlClient;
using Centerport.Report;

namespace Centerport
{
    public partial class frm_Tumor_Immunological : Form,MyInter
    {
        public static bool newTumor;
        public static TextBox LabID;
        public static TextBox pin;
        private DataTable dt;
        Main fmain;
        public frm_Tumor_Immunological(Main maiin)
        {
            InitializeComponent();
            LabID = txt_resultID;
            pin = txt_Papin;
            fmain = maiin;
        }
        public void New()
      {
        IniFile ini = new IniFile(ClassSql.MMS_Path);       
        this.txt_Medtech.Text = ini.IniReadValue("MEDICAL", "MedTech");
        this.txt_license_medTech.Text = ini.IniReadValue("MEDICAL", "MedTech_license");
        this.txt_patho.Text = ini.IniReadValue("MEDICAL", "Pathologist");
        this.txt_pathologist_license.Text = ini.IniReadValue("MEDICAL", "Pathologist_license");     
        
        }
        public void Save()
        {
            if (newTumor)
            { 
                Insert(); 
            
            }
            else
            {
                UpdateTable();
            }
        
        
        }

        void Insert()
        {
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();

             
                  MySqlCommand cmd = new MySqlCommand("insert_Tumor", conn);                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@resultid", LabID.Text);
                    cmd.Parameters.AddWithValue("@psa", txt_psa.Text);
                    cmd.Parameters.AddWithValue("@afp", txt_afp.Text);
                    cmd.Parameters.AddWithValue("@hbs", txt_HBS.Text);
                    cmd.Parameters.AddWithValue("@hbc", txt_hbc.Text);
                    cmd.Parameters.AddWithValue("@hcv", txt_hcv.Text);
                    cmd.Parameters.AddWithValue("@hbsag", txt_HBsag.Text);
                    cmd.Parameters.AddWithValue("@blank", txt_blank_Immuno.Text);
                    cmd.Parameters.AddWithValue("@other_immuno", txt_other_Immuno.Text);
                    cmd.Parameters.AddWithValue("@other_tumor", txt_tumorOther.Text);

                    cmd.Parameters.AddWithValue("@resultidd", LabID.Text);
                    cmd.Parameters.AddWithValue("@resulttype", "TUMOR");
                    cmd.Parameters.AddWithValue("@papin", pin.Text);
                    cmd.Parameters.AddWithValue("@result_date", dt_result_Date.Text);
                    cmd.Parameters.AddWithValue("@pathologist", txt_patho.Text);
                    cmd.Parameters.AddWithValue("@sstatus", "Pending");
                    cmd.Parameters.AddWithValue("@specimen_no", txt_speciment.Text);
                    cmd.Parameters.AddWithValue("@medtech", txt_Medtech.Text);
                    cmd.Parameters.AddWithValue("@medtech_license", txt_license_medTech.Text);
                    cmd.Parameters.AddWithValue("@pathologist_license", txt_pathologist_license.Text);
                    cmd.Parameters.AddWithValue("@reference_no", LabID.Text);
                    cmd.ExecuteNonQuery();
                    Tool.MessageBoxSave();
                 //   newTumor = false;
                    txt_Papin.Select();
                    Availability(false);
                    fmain.ts_add_tumor.Enabled = true; fmain.ts_edit_tumor.Enabled = true; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = false; fmain.ts_search_tumor.Enabled = true; fmain.ts_print_tumor.Enabled = true;
 

                conn.Close();
            }
            
            

        }


        void UpdateTable()
        {
            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("update_labExtra", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@j", LabID.Text);
                cmd.Parameters.AddWithValue("@a", txt_psa.Text);
                cmd.Parameters.AddWithValue("@b", txt_afp.Text);
                cmd.Parameters.AddWithValue("@c", txt_HBS.Text);
                cmd.Parameters.AddWithValue("@d", txt_hbc.Text);
                cmd.Parameters.AddWithValue("@e", txt_hcv.Text);
                cmd.Parameters.AddWithValue("@f", txt_HBsag.Text);
                cmd.Parameters.AddWithValue("@g", txt_blank_Immuno.Text);
                cmd.Parameters.AddWithValue("@h", txt_other_Immuno.Text);
                cmd.Parameters.AddWithValue("@i", txt_tumorOther.Text);
                cmd.ExecuteNonQuery();
                Tool.MessageBoxUpdate();
                newTumor = true;
                txt_Papin.Select();
                fmain.ts_add_tumor.Enabled = true; fmain.ts_edit_tumor.Enabled = true; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = false; fmain.ts_search_tumor.Enabled = true; fmain.ts_print_tumor.Enabled = true;
                Availability(false);
                conn.Close();
            }
        
        }
        public void Availability(bool bl)
        {


            if (bl == true)
            { overlayShadow1.Visible = false; overlayShadow1.SendToBack(); }
            else
            { overlayShadow1.Visible = true; overlayShadow1.BringToFront(); }

        }

        public void Edit()
        {
            newTumor = false;
            Availability(true);       

            fmain.ts_add_tumor.Enabled = false; fmain.ts_edit_tumor.Enabled = false; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = true; fmain.ts_cancel_tumor.Enabled = true; fmain.ts_search_tumor.Enabled = false; fmain.ts_print_tumor.Enabled = false;
  
        
        }
        public void Print()
        {
         using(frm_lab_33_Report f = new frm_lab_33_Report())
         {
             f.Tag = LabID.Text;
             f.ShowDialog(); 
         }
        
        }
        public void Search()
        {


        }

        public void Delete()
        {

            using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Delete_tumor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(@"resultid", txt_resultID.Text);
                cmd.ExecuteNonQuery();
                Tool.MessageBoxDelete();

                conn.Close();
            }
        
        
        }

        //public void Search_Patient()
        //{
        //    try
        //    {



        //        ClassSql a = new ClassSql(); DataTable dt;


        //        dt = a.Mytable_Proc("HIV_Search_Patient", "@SearchID", pin.Text);
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            this.txt_name.Text = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();

        //            DateTime temp1;
        //            if (DateTime.TryParse(dr["birthdate"].ToString(), out temp1))
        //            {
        //                dt_bday.Format = DateTimePickerFormat.Custom;
        //                dt_bday.CustomFormat = "MM/dd/yyyy";
        //                dt_bday.Value = Convert.ToDateTime(dr["birthdate"].ToString()).Date;
        //            }
        //            else
        //            {

        //                dt_bday.Format = DateTimePickerFormat.Custom;
        //                dt_bday.CustomFormat = "00/00/0000";

        //            }

        //            this.txt_gender.Text = dr["gender"].ToString();
        //            this.txt_agency.Text = dr["employer"].ToString();
        //            txt_position.Text = dr["position"].ToString();

        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {

        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }


        //}

        //public void Search_tumor()
        //{

        //    try
        //    {


        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Mytable_Proc("search_tumor", "@SearchID", LabID.Text);
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            txt_psa.Text = dr["psa"].ToString();
        //            txt_afp.Text = dr["afp"].ToString();
        //            txt_tumorOther.Text = dr["onther_tumor"].ToString();
        //            txt_HBS.Text = dr["anti_hbs"].ToString();
        //            txt_hbc.Text = dr["anti_hbc"].ToString();
        //            txt_hcv.Text = dr["anti_hcv"].ToString();
        //            txt_HBsag.Text = dr["hbsag"].ToString();
        //            txt_blank_Immuno.Text = dr["blank"].ToString();
        //            txt_other_Immuno.Text = dr["other_immuno"].ToString();
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format(" An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
              
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }

        //}

        //public void search_Medical_ByProc()
        //{

        //    try
        //    {
        //        //if (bl)
        //        //{

        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Mytable_Proc("Search_MedicalTumor", "@ID", LabID.Text);

        //        if (dt.Rows.Count > 0)
        //        {

                 
        //            txt_Medtech.Text = dt.Rows[0]["medtech"].ToString();
        //           txt_license_medTech.Text = dt.Rows[0]["medtech_license"].ToString();
        //           txt_speciment.Text = dt.Rows[0]["specimen_no"].ToString();
        //            txt_patho.Text = dt.Rows[0]["pathologist"].ToString();                   
        //            txt_pathologist_license.Text = dt.Rows[0]["pathologist_license"].ToString();
                  

        //            DateTime temp;
        //            if (DateTime.TryParse(dt.Rows[0]["result_date"].ToString(), out temp))
        //            {
        //                this.dt_result_Date.Format = DateTimePickerFormat.Custom;
        //                dt_result_Date.CustomFormat = "MM/dd/yyyy";

        //                dt_result_Date.Value = Convert.ToDateTime(dt.Rows[0]["result_date"].ToString()).Date;
        //            }
        //            else
        //            {

        //                dt_result_Date.Format = DateTimePickerFormat.Custom;
        //                dt_result_Date.CustomFormat = "00/00/0000";


        //            }


                    

                

        //        }
        //        //dr.Close();





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

            if (newTumor)
            {
                Tool.ClearFields(groupBox1);
                txt_Papin.Clear();
                ClearAll();
                Availability(false);
              
                fmain.ts_add_tumor.Enabled = true; fmain.ts_edit_tumor.Enabled = false; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = true; fmain.ts_search_tumor.Enabled = false; fmain.ts_print_tumor.Enabled = false;
  
            }
            else
            {
                Availability(false);
                ClearAll();
                //Search_Patient();
                //Search_tumor();
                //search_Medical_ByProc();
                //fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = true; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = true; fmain.ts_cancel_hiv.Enabled = false;
                fmain.ts_add_tumor.Enabled = true; fmain.ts_edit_tumor.Enabled = true; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = false; fmain.ts_search_tumor.Enabled = true; fmain.ts_print_tumor.Enabled = true;
            }
            txt_Papin.Select();
        
        }
        public void ClearAll()
        {
            Tool.ClearFields(panel4);
           


        }

        private DataTable GetLogData(int ID)
        {
            MySqlDataAdapter DA = new MySqlDataAdapter("tumor_report", ClassSql.cnn);
            DataTable dt = new DataTable();
            DA.SelectCommand.Parameters.AddWithValue("@id", ID);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;
            DA.Fill(dt);

            //using (MySqlConnection conn = new MySqlConnection(ClassSql.MMS_Path))
            //{
            //    conn.Open();
            //    MySqlDataAdapter DA = new MySqlDataAdapter("tumor_report",conn);
            //    DataTable dt = new DataTable();
            //    DA.SelectCommand.Parameters.AddWithValue("@id", ID);
            //    DA.SelectCommand.CommandType = CommandType.StoredProcedure;               
            //    DA.Fill(dt);
            //    conn.Close();
            return dt;
            //}

        }

        private void frm_Tumor_Immunological_Load(object sender, EventArgs e)
        {

            //ClassSql.DbConnect();
            Cursor.Current = Cursors.Default;
            //Load_Medical();
            Availability(false);
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            a.Text = ini.IniReadValue("NormalValue", "PSA");
            b.Text = ini.IniReadValue("NormalValue", "AFP");
            c.Text = ini.IniReadValue("NormalValue", "TumorOther");
            d.Text = ini.IniReadValue("NormalValue", "HBS");
            ee.Text = ini.IniReadValue("NormalValue", "HBC");
            f.Text = ini.IniReadValue("NormalValue", "HCV");
            g.Text = ini.IniReadValue("NormalValue", "HBSAG");
            h.Text = ini.IniReadValue("NormalValue", "Blank");
            i.Text = ini.IniReadValue("NormalValue", "ImmuOther");
          
            
        }

        private void frm_Tumor_Immunological_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.Tumor = true;
            fmain.ts_add_tumor.Enabled = true; fmain.ts_edit_tumor.Enabled = false; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = false; fmain.ts_search_tumor.Enabled = true; fmain.ts_print_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = false;
            ClassSql.DbClose();
        }

        private void frm_Tumor_Immunological_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dt_result_Date_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_bday_ValueChanged(object sender, EventArgs e)
        {
            if (dt_bday.Text != "" || dt_bday.Text != "0000-00-00 00:00:00" || dt_bday.Text != "00/00/0000")
            {

                int age = DateTime.Now.Year - Convert.ToDateTime(dt_bday.Text).Year;
                txt_age.Text = age.ToString();

            }
            else
            { txt_age.Clear(); }
        }

        private void cmd_load1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_Medtech;
                f.txt_license = txt_license_medTech;
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_patho;
                f.txt_license = txt_pathologist_license;
                f.ShowDialog();
            }
        }


    }
}
