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
using System.Globalization;
using System.IO;
using Ini;
using Centerport.Class;


namespace Centerport
{
    public partial class frm_HIV : Form, MyInter
    {
        Main fmain; public static bool NewHiv; public static TextBox pin; public static TextBox LabID;

        public bool search_med;
        private string rapid = "0";
        private string particle_agglutination = "0";
        private string eia_cmia_elfa = "0";
        private string results = "NONREACTIVE";
        public List<HIV_Model> Hiv_model = new List<HIV_Model>();
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public List<QueueSearchList_Model> hivAdd_model = new List<QueueSearchList_Model>();
        public frm_HIV(Main mainn)
        {
            InitializeComponent();
            fmain = mainn; pin = txt_Papin; LabID = txt_resultID;
        }

        private void frm_HIV_Load(object sender, EventArgs e)
        {
            //ClassSql.DbConnect();
            Cursor.Current = Cursors.Default;
            //Load_Medical();
            Availability(false);


            dt_expire_date.Format = DateTimePickerFormat.Custom;
            dt_expire_date.CustomFormat = "00/00/0000";


            dt_result_date.Format = DateTimePickerFormat.Custom;
            dt_result_date.CustomFormat = "00/00/0000";

            if (!Directory.Exists(ClassSql.HIV_TempImage))
            {
                DirectoryInfo di = Directory.CreateDirectory(ClassSql.HIV_TempImage);
            }





        }

        //public void search_Medical(string ResultId)
        // {

        //     try
        //     {
        //         //if (bl)
        //         //{

        //         
        //DataTable dt;

        //             //resulttype =  'HIV' AND 
        //             dt = a.Table("SELECT t_hiv.resultid, t_result_main.cn, t_result_main.medtech, t_result_main.medtech_license, t_result_main.pathologist_license, t_result_main.pathologist, t_result_main.repeat_test_requestby, t_result_main.result_date, t_result_main.valid_until, t_result_main.fitness_date, t_result_main.remarks, t_hiv.cn, t_hiv.rapid, t_hiv.particle_agglutination, t_hiv.eia_cmia_elfa, t_hiv.others_specify, t_hiv.results FROM t_result_main INNER JOIN t_hiv ON t_result_main.resultid = t_hiv.resultid   WHERE t_hiv.resultid =  '" + ResultId + "'");

        //             foreach (DataRow dr in dt.Rows)
        //             {

        //                 lbl_medical_cn.Tag = dr["cn"].ToString();
        //                 txt_Medtech.Text = dr["medtech"].ToString();
        //                 txt_patho.Text = dr["pathologist"].ToString();
        //                 txt_medtect_license.Text = dr["medtech_license"].ToString();
        //                 txt_pathologist_license.Text = dr["pathologist_license"].ToString();
        //                 txt_examining_phy.Text = dr["repeat_test_requestby"].ToString();
        //                 DateTime temp;
        //                 if (DateTime.TryParse(dr["result_date"].ToString(), out temp))
        //                 {
        //                     dt_result_date.Format = DateTimePickerFormat.Custom;
        //                     dt_result_date.CustomFormat = "MM/dd/yyyy";

        //                     dt_result_date.Value = Convert.ToDateTime(dr["result_date"].ToString()).Date;
        //                 }
        //                 else
        //                 {

        //                     dt_result_date.Format = DateTimePickerFormat.Custom;
        //                     dt_result_date.CustomFormat = "00/00/0000";


        //                 }



        //                 DateTime temp2;
        //                 if (DateTime.TryParse(dr["valid_until"].ToString(), out temp2))
        //                 {

        //                     dt_expire_date.Format = DateTimePickerFormat.Custom;
        //                     dt_expire_date.CustomFormat = "MM/dd/yyyy";

        //                     dt_expire_date.Value = Convert.ToDateTime(dr["valid_until"].ToString()).Date;
        //                 }
        //                 else
        //                 {

        //                     dt_expire_date.Format = DateTimePickerFormat.Custom;
        //                     dt_expire_date.CustomFormat = "00/00/0000";


        //                 }




        //                 txt_Remark.Text = dr["remarks"].ToString();

        //             }


        //         //}



        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //     }
        //     finally
        //     {
        //         //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //         if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //     }

        // }

        public void search_Medical_ByProc(string ResultId)
        {

            try
            {
                //if (bl)
                //{


                //ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Mytable_Proc("HIV_medical","@ID", ResultId);
                var i = db.sp_Hiv_Medical(ResultId).FirstOrDefault();
                //if (dt.Rows.Count > 0) 
                //{

                lbl_medical_cn.Tag = i.cn.ToString();
                txt_Medtech.Text = i.medtech.ToString();
                txt_patho.Text = i.pathologist.ToString();
                txt_certNo.Text = i.medtech_license.ToString();
                txt_pathologist_license.Text = i.pathologist_license.ToString();
                txt_examining_phy.Text = i.repeat_test_requestby.ToString();

                DateTime temp;
                if (DateTime.TryParse(i.result_date.ToString(), out temp))
                {
                    dt_result_date.Format = DateTimePickerFormat.Custom;
                    dt_result_date.CustomFormat = "MM/dd/yyyy";

                    dt_result_date.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                }
                else
                {

                    dt_result_date.Format = DateTimePickerFormat.Custom;
                    dt_result_date.CustomFormat = "00/00/0000";


                }



                DateTime temp2;
                if (DateTime.TryParse(i.valid_until.ToString(), out temp2))
                {

                    dt_expire_date.Format = DateTimePickerFormat.Custom;
                    dt_expire_date.CustomFormat = "MM/dd/yyyy";

                    dt_expire_date.Value = Convert.ToDateTime(i.valid_until.ToString()).Date;
                }
                else
                {

                    dt_expire_date.Format = DateTimePickerFormat.Custom;
                    dt_expire_date.CustomFormat = "00/00/0000";


                }



                txt_pysicianNo.Text = i.remarks.ToString();

                //}
                //dr.Close();





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


        //public  void search_Medical_Sub()
        //  {

        //      try
        //      {


        //          ClassSql a = new ClassSql(); DataTable dt;

        //          dt = a.Table("SELECT * From t_result_main  WHERE resulttype =  'HIV' AND papin =  '" + pin.Text + "'");
        //          foreach (DataRow dr in dt.Rows)
        //          {

        //              lbl_medical_cn.Tag = dr["cn"].ToString();
        //              LabID.Text = dr["resultid"].ToString();
        //              txt_Medtech.Text = dr["medtech"].ToString();
        //              txt_patho.Text = dr["pathologist"].ToString();
        //              txt_medtect_license.Text = dr["medtech_license"].ToString();
        //              txt_pathologist_license.Text = dr["pathologist_license"].ToString();
        //              txt_examining_phy.Text = dr["repeat_test_requestby"].ToString();

        //              //DateTime date1 = DateTime.Parse(dr["result_date"].ToString()).Date;
        //              //dt_result_date.Text = date1.ToShortDateString();


        //              DateTime temp;
        //              if (DateTime.TryParse(dr["result_date"].ToString(), out temp))
        //              {
        //                  //dt_result_date.Format = DateTimePickerFormat.Custom;
        //                  //dt_result_date.CustomFormat = "MM/dd/yyyy";

        //                  dt_result_date.Value = Convert.ToDateTime(dr["result_date"].ToString()).Date;
        //              }
        //              else
        //              {

        //                  dt_result_date.Format = DateTimePickerFormat.Custom;
        //                  dt_result_date.CustomFormat = "00/00/0000";


        //              }

        //             //DateTime date2 = DateTime.Parse(dr["valid_until"].ToString()).Date;
        //             // dt_expire_date.Text = date2.ToShortDateString();



        //              DateTime temp2;
        //              if (DateTime.TryParse(dr["valid_until"].ToString(), out temp2))
        //              {

        //                  //dt_expire_date.Format = DateTimePickerFormat.Custom;
        //                  //dt_expire_date.CustomFormat = "MM/dd/yyyy";

        //                  dt_expire_date.Value = Convert.ToDateTime(dr["valid_until"].ToString()).Date;
        //              }
        //              else
        //              {

        //                  dt_expire_date.Format = DateTimePickerFormat.Custom;
        //                  dt_expire_date.CustomFormat = "00/00/0000";


        //              }










        //              txt_Remark.Text = dr["remarks"].ToString();

        //          }


        //      }
        //      catch (Exception ex)
        //      {
        //          MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //      }
        //      finally
        //      {
        //          //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //          if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //      }

        //  }      

        public void search_HIV(string LabID)
        {

            try
            {


                //ClassSql a = new ClassSql(); DataTable dt;

                //dt = a.Mytable_Proc("HIV_Search_Detail", "@SearchID", LabID);
                var i = db.sp_HIV_detail(LabID).FirstOrDefault();
                //foreach (DataRow dr in dt.Rows)
                //{

                lbl_HIV_Result_Cn.Tag = i.cn.ToString();
                string rapid = i.rapid.ToString();
                if (rapid == "1") { cb_rabid.Checked = true; } else { cb_rabid.Checked = false; }
                string particle_agglutination = i.particle_agglutination.ToString();
                if (particle_agglutination == "1") { this.cb_particle.Checked = true; } else { cb_particle.Checked = false; }
                string eia_cmia_elfa = i.eia_cmia_elfa.ToString();
                if (eia_cmia_elfa == "1") { this.cb_eie.Checked = true; } else { cb_eie.Checked = false; }
                txt_other_specify.Text = i.others_specify.ToString();
                string results = i.results.ToString();
                if (results == "NONREACTIVE") { rb_result_NonReactive.Checked = true; } else { rb_result_Reactive.Checked = true; }

                //}



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

        void Insert()
        {
            try
            {
                if (cb_rabid.Checked == true) { rapid = "1"; } else { rapid = "0"; }
                if (this.cb_particle.Checked == true) { particle_agglutination = "1"; } else { particle_agglutination = "0"; }
                if (this.cb_eie.Checked == true) { eia_cmia_elfa = "1"; } else { eia_cmia_elfa = "0"; }
                if (rb_result_Reactive.Checked == true) { results = "REACTIVE"; } else if (this.rb_result_NonReactive.Checked == true) { results = "NONREACTIVE"; } else { results = ""; }



                //using (MySqlConnection con = new MySqlConnection(ClassSql.ConnString))
                //{
                //    con.Open();
                //    MySqlCommand cmd = new MySqlCommand("Insert_HIV", con);
                //    cmd.CommandType = CommandType.StoredProcedure;                  
                //   //cmd.Parameters.AddWithValue("@resultid",LabID.Text);
                //   //cmd.Parameters.AddWithValue("@resulttype","HIV");
                //   //cmd.Parameters.AddWithValue("@papin",pin.Text);
                //   //cmd.Parameters.AddWithValue("@result_date",dt_result_date.Text);
                //   //cmd.Parameters.AddWithValue("@pathologist",txt_patho.Text);
                //   //cmd.Parameters.AddWithValue("@status","PENDING");
                //   //cmd.Parameters.AddWithValue("@fitness_date",dt_expire_date.Text);
                //   //cmd.Parameters.AddWithValue("@valid_until",dt_expire_date.Text);
                //   //cmd.Parameters.AddWithValue("@remarks", txt_pysicianNo.Text);
                //   //cmd.Parameters.AddWithValue("@recommendation","");
                //   //cmd.Parameters.AddWithValue("@repeat_test_requestby",txt_examining_phy.Text);
                //   //cmd.Parameters.AddWithValue("@specimen_no", txt_pysicianNo.Text);
                //   //cmd.Parameters.AddWithValue("@medtech",txt_Medtech.Text);
                //   //cmd.Parameters.AddWithValue("@medtech_license","");
                //   //cmd.Parameters.AddWithValue("@pathologist_license",txt_pathologist_license.Text);
                //   //cmd.Parameters.AddWithValue("@reference_no",txt_resultID.Text);
                //   //cmd.Parameters.AddWithValue("@restriction","");
                //   //cmd.Parameters.AddWithValue("@basic_doh_exam","");
                //   //cmd.Parameters.AddWithValue("@add_lab_tests","");
                //   //cmd.Parameters.AddWithValue("@flag_medlab_req","");
                //   //cmd.Parameters.AddWithValue("@deck_srvc_flag","");
                //   //cmd.Parameters.AddWithValue("@engine_srvc_flag","");                                          
                //   //cmd.Parameters.AddWithValue("@catering_srvc_flag","");
                //   //cmd.Parameters.AddWithValue("@other_srvc_flag","");                  

                //    cmd.Parameters.AddWithValue("@LabID_", txt_resultID.Text);
                //    cmd.Parameters.AddWithValue("@rapid", rapid.ToString());
                //    cmd.Parameters.AddWithValue("@particle_agglutination", particle_agglutination.ToString());
                //    cmd.Parameters.AddWithValue("@eia_cmia_elfa", eia_cmia_elfa.ToString());
                //    cmd.Parameters.AddWithValue("@txt_other_specify", Tool.ReplaceString(txt_other_specify.Text));
                //    cmd.Parameters.AddWithValue("@results", results.ToString());

                //    cmd.ExecuteNonQuery();
                //    con.Close();
                //}

                // ClassSql a = new ClassSql();   
                //resultid`,       `resulttype`, `papin`,          `result_date`,       `pathologist`,                                     `status`, `fitness_date`, `valid_until`,                             `remarks`,              `recommendation`,                       `repeat_test_requestby`,         `specimen_no`,                                         `medtech`,               `medtech_license`,                                                     `pathologist_license`,                         `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`
                //string b = "INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + LabID.Text + "', 'HIV', '" + pin.Text + "', '" + dt_result_date.Text + "', '" + Tool.ReplaceString(txt_patho.Text) + "', 'PENDING',   '',              '" + dt_expire_date.Text + "', '" + Tool.ReplaceString(txt_pysicianNo.Text) + "', '',               '" + Tool.ReplaceString(txt_examining_phy.Text) + "', '',               '" + Tool.ReplaceString(txt_Medtech.Text) + "', '" + Tool.ReplaceString(txt_certNo.Text) + "', '" + Tool.ReplaceString(this.txt_pathologist_license.Text) + "', '', '', '', '', '', '', '', '', '')";
                //string a = "INSERT INTO `t_hiv` (`resultid`, `rapid`, `particle_agglutination`, `eia_cmia_elfa`, `others_specify`, `results`) VALUES ('" + LabID.Text + "', '" + rapid.ToString() + "', '" + particle_agglutination.ToString() + "', '" + eia_cmia_elfa.ToString() + "', '" + Tool.ReplaceString(txt_other_specify.Text) + "', '" + results.ToString() + "')";

                // var arr = new[] { a, b };
                // File.WriteAllLines(ClassSql.tmp_path, arr);
                db.ExecuteCommand("INSERT INTO t_hiv (resultid, rapid, particle_agglutination, eia_cmia_elfa, others_specify, results) VALUES ({0},{1},{2},{3},{4},{5})", LabID.Text, rapid.ToString(), particle_agglutination.ToString(), eia_cmia_elfa.ToString(), txt_other_specify.Text, results.ToString());
                db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", LabID.Text, "HIV", pin.Text, dt_result_date.Text, txt_patho.Text, "PENDING", "", dt_expire_date.Text, txt_pysicianNo.Text, "", txt_examining_phy.Text, "", txt_Medtech.Text, txt_certNo.Text, txt_pathologist_license.Text, "", "", "", "", "", "", "", "", "");
                Hiv_model.Clear();
                hivAdd_model.Clear();
                if (!backgroundWorker1.IsBusy)
                { backgroundWorker1.RunWorkerAsync(); }

                //Tool.MessageBoxSave();
                txt_Papin.Select();
                Availability(false);
                fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = true; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = true; fmain.ts_PrintPreview.Enabled = true;




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
        //        a.ExecuteQuery("UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_result_date.Text) + "', `repeat_test_requestby`= '"+Tool.ReplaceString(txt_examining_phy.Text) +"', `valid_until`='" + Tool.ReplaceString(dt_expire_date.Text) + "',`medtech`='" + Tool.ReplaceString(txt_Medtech.Text) + "', `medtech_license`='" + Tool.ReplaceString(txt_medtect_license.Text) + "',`pathologist_license`='" + Tool.ReplaceString(txt_pathologist_license.Text) + "',`pathologist`='" + Tool.ReplaceString(txt_patho.Text) + "',`remarks`='" + Tool.ReplaceString(txt_Remark.Text) + "' WHERE (`cn`='" + lbl_medical_cn.Tag.ToString() + "') LIMIT 1");

        //        search_Medical();




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

        void Update_HIV()
        {
            try
            {


                if (cb_rabid.Checked == true) { rapid = "1"; } else { rapid = "0"; }
                if (this.cb_particle.Checked == true) { particle_agglutination = "1"; } else { particle_agglutination = "0"; }
                if (this.cb_eie.Checked == true) { eia_cmia_elfa = "1"; } else { eia_cmia_elfa = "0"; }
                if (rb_result_Reactive.Checked == true) { results = "REACTIVE"; } else { results = "NONREACTIVE"; }

                //ClassSql a = new ClassSql();
                //string a =   "UPDATE `t_hiv` SET  `rapid`='" + rapid.ToString() + "', `particle_agglutination`='" + particle_agglutination.ToString() + "', `eia_cmia_elfa`='" + eia_cmia_elfa.ToString() + "', `others_specify`='" + Tool.ReplaceString(txt_other_specify.Text) + "', `results`='" + results.ToString() + "' WHERE (`cn`='" + lbl_HIV_Result_Cn.Tag.ToString() + "') LIMIT 1";
                //string b =   "UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_result_date.Text) + "', `repeat_test_requestby`= '" + Tool.ReplaceString(txt_examining_phy.Text) + "', `valid_until`='" + Tool.ReplaceString(dt_expire_date.Text) + "',`medtech`='" + Tool.ReplaceString(txt_Medtech.Text) + "', `medtech_license`='" + Tool.ReplaceString(txt_certNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(txt_pathologist_license.Text) + "',`pathologist`='" + Tool.ReplaceString(txt_patho.Text) + "',`remarks`='" + Tool.ReplaceString(txt_pysicianNo.Text) + "' WHERE (`cn`='" + lbl_medical_cn.Tag.ToString() + "') LIMIT 1";

                //var arr = new[] {a,b  };
                //File.WriteAllLines(ClassSql.tmp_path, arr);

                db.ExecuteCommand("UPDATE t_hiv SET  rapid={0}, particle_agglutination={1}, eia_cmia_elfa={2}, others_specify={3}, results={4} WHERE (cn={5})", rapid.ToString(), particle_agglutination.ToString(), eia_cmia_elfa.ToString(), Tool.ReplaceString(txt_other_specify.Text), results.ToString(), lbl_HIV_Result_Cn.Tag.ToString());
                db.ExecuteCommand("UPDATE t_result_main SET result_date={0}, repeat_test_requestby= {1}, valid_until={2},medtech={3}, medtech_license={4},pathologist_license={5},pathologist={6},remarks={7} WHERE (cn={8})", dt_result_date.Text, txt_examining_phy.Text, dt_expire_date.Text, txt_Medtech.Text, txt_certNo.Text, txt_pathologist_license.Text, txt_patho.Text, txt_pysicianNo.Text, lbl_medical_cn.Tag.ToString());

                //      using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
                //      { 
                //      conn.Open();
                //      MySqlCommand cmd = new MySqlCommand("Update_HIV", conn);
                //      cmd.CommandType = CommandType.StoredProcedure;
                //          cmd.Parameters.AddWithValue("@rapid",rapid.ToString());
                //           cmd.Parameters.AddWithValue("@particle_agglutination",particle_agglutination.ToString());
                //           cmd.Parameters.AddWithValue("@eia_cmia_elfa",eia_cmia_elfa.ToString());
                //           cmd.Parameters.AddWithValue("@others_specify",Tool.ReplaceString(txt_other_specify.Text));
                //           cmd.Parameters.AddWithValue("@results", results.ToString());
                //           cmd.Parameters.AddWithValue("@ID", lbl_HIV_Result_Cn.Tag.ToString());    

                //          //cmd.Parameters.AddWithValue("@result_date", Tool.ReplaceString(dt_result_date.Text) );
                //          //cmd.Parameters.AddWithValue("@repeat_test_requestby",Tool.ReplaceString(txt_examining_phy.Text));
                //          //cmd.Parameters.AddWithValue("@valid_until", Tool.ReplaceString(dt_expire_date.Text));
                //          //cmd.Parameters.AddWithValue("@medtech",Tool.ReplaceString(txt_Medtech.Text));
                //          //cmd.Parameters.AddWithValue("@medtech_license", Tool.ReplaceString(txt_certNo.Text));
                //          //cmd.Parameters.AddWithValue("@pathologist_license", Tool.ReplaceString(txt_pathologist_license.Text));
                //          //cmd.Parameters.AddWithValue("@pathologist",Tool.ReplaceString(txt_patho.Text));
                //          //cmd.Parameters.AddWithValue("@remarks",Tool.ReplaceString(txt_pysicianNo.Text));
                //          //cmd.Parameters.AddWithValue("@CN", LabID.Text);
                //          cmd.ExecuteNonQuery();
                //      conn.Close();

                //      //ClassSql a = new ClassSql();
                //      //a.ExecuteQuery("UPDATE `t_hiv` SET  `rapid`='"+rapid.ToString() +"', `particle_agglutination`='"+particle_agglutination.ToString() +"', `eia_cmia_elfa`='"+eia_cmia_elfa.ToString() +"', `others_specify`='"+Tool.ReplaceString(txt_other_specify.Text)+"', `results`='"+results.ToString() +"' WHERE (`cn`='"+lbl_HIV_Result_Cn.Tag.ToString() +"') LIMIT 1");
                //      a.ExecuteQuery("UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_result_date.Text) + "', `repeat_test_requestby`= '" + Tool.ReplaceString(txt_examining_phy.Text) + "', `valid_until`='" + Tool.ReplaceString(dt_expire_date.Text) + "',`medtech`='" + Tool.ReplaceString(txt_Medtech.Text) + "', `medtech_license`='" + Tool.ReplaceString(txt_certNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(txt_pathologist_license.Text) + "',`pathologist`='" + Tool.ReplaceString(txt_patho.Text) + "',`remarks`='" + Tool.ReplaceString(txt_pysicianNo.Text) + "' WHERE (`cn`='" + lbl_medical_cn.Tag.ToString() + "') LIMIT 1");



                //  //search_HIV(LabID.Text); search_Medical(LabID.Text);
                ////  Update_Medical();


                //      }

                NewHiv = true;
                //Tool.MessageBoxSave();
                txt_Papin.Select();
                fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = true; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = true; fmain.ts_PrintPreview.Enabled = true;
                Availability(false);


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


        public void Availability(bool bl)
        {


            if (bl == true)
            { overlayShadow1.Visible = false; overlayShadow1.SendToBack(); }
            else
            { overlayShadow1.Visible = true; overlayShadow1.BringToFront(); }

        }

        public void ClearAll()
        {
            Tool.ClearFields(panelChoice);
            Tool.ClearFields(groupBox2);
            Tool.ClearFields(groupBox3);


        }


        public void New()
        {



            IniFile ini = new IniFile(ClassSql.MMS_Path);
            dt_expire_date.Text = ini.IniReadValue("HIVExpireDate", "Date");
            this.txt_Medtech.Text = ini.IniReadValue("MEDICAL", "MedTech");
            this.txt_certNo.Text = ini.IniReadValue("MEDICAL", "MedTech_license");

            this.txt_patho.Text = ini.IniReadValue("MEDICAL", "Pathologist");
            this.txt_pathologist_license.Text = ini.IniReadValue("MEDICAL", "Pathologist_license");

            //this.txt_certNo.Text = ini.IniReadValue("MEDICAL", "hiv_cert_no");

            this.txt_examining_phy.Text = ini.IniReadValue("MEDICAL", "HIV_Exam_physician");
            this.txt_pysicianNo.Text = ini.IniReadValue("MEDICAL", "HIV_Exam_physician_license");
            dt_expire_date.Text = ini.IniReadValue("HIVExpireDate", "Date");

        }



        public void Save()
        {

            if (NewHiv)
            {

                Insert();
            }
            else
            {

                Update_HIV();


            }






        }


        public void Edit()
        {

            if (fmain.UserLevel == 1 || fmain.UserLevel == 2 || fmain.UserLevel == 3)
            {
                NewHiv = false;
                Availability(true);

                dt_expire_date.Format = DateTimePickerFormat.Custom;
                dt_expire_date.CustomFormat = "MM/dd/yyyy";

                IniFile ini = new IniFile(ClassSql.MMS_Path);
                dt_expire_date.Text = ini.IniReadValue("HIVExpireDate", "Date");
                fmain.ts_add_hiv.Enabled = false; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = true; fmain.ts_cancel_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = false; fmain.ts_PrintPreview.Enabled = false;

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
        public void Cancel()
        {
            if (NewHiv)
            {
                Tool.ClearFields(groupBox1);
                txt_Papin.Clear();
                ClearAll();
                Availability(false);

                fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = false; fmain.ts_PrintPreview.Enabled = false; fmain.ts_cancel_hiv.Enabled = false;

            }
            else
            {
                Availability(false);
                ClearAll();
                Search_Patient(pin.Text); search_HIV(LabID.Text); search_Medical_ByProc(LabID.Text);
                fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = true; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = true; fmain.ts_PrintPreview.Enabled = true; fmain.ts_cancel_hiv.Enabled = false;
            }



        }
        public void Print()
        {

            //Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
            //frm_print.Tag = LabID.Text;
            //frm_print.HIV = true;
            //frm_print.ShowDialog();
            try
            {

                pic_.Image.Save(ClassSql.HIV_TempImage + "\\tmp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
                {
                    f.Tag = LabID.Text;
                    f.isHIV = true;
                    f.ShowImage = "0";
                    f.age = txt_age.Text;
                    f.imgpath = @"file:///" + ClassSql.HIV_TempImage + "\\tmp.jpg";
///
                    f.PatientName = txt_name.Text;
                    f.ExaminigPhysycian = txt_examining_phy.Text;
                    f.ExaminigPhysycian_lic = txt_pysicianNo.Text;
                    DateTime dt = Convert.ToDateTime(dt_result_date.Text);
                    f.resultDate = dt.ToString("dd MMMM  yyyy");
                    f.Address = txt_address.Text;
                    f.Sex = txt_gender.Text;
                    f.CivilStatus = txt_CivitStatus.Text;
                    f.Medtech = txt_Medtech.Text;
                    f.MedTech_lic = txt_certNo.Text;
                    DateTime dt_expiry = Convert.ToDateTime(dt_expire_date.Text);
                    f.ExpiryDate = dt_expiry.ToString("dd MMMM yyyy");
                    f.Pathologist = txt_patho.Text;
                    if (cb_rabid.Checked) { f.rapid = "1"; } else { f.rapid = "0"; }
                    if (cb_particle.Checked) { f.Particle = "1"; } else { f.Particle = "0"; }
                    if (cb_eie.Checked) { f.EIA = "1"; } else { f.EIA = "0"; }

                    f.other = txt_other_specify.Text;
                    if (rb_result_NonReactive.Checked) { f.Nonrecative = "1"; f.result = "NONREACTIVE"; } else { f.Nonrecative = "0"; f.result = "REACTIVE"; }
                    if (rb_result_Reactive.Checked) { f.Reactive = "1"; } else { f.Reactive = "0"; }


                    f.ShowDialog();
                }


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }



        }


        public void Search()
        {



        }



        void Delete_Record()
        {

            //try
            //{


            //    ClassSql a = new ClassSql();
            //    a.ExecuteQuery("Delete from t_radiology where resultid = '" + LabID.Text + "' and resulttype= 'HIV'");
            //    Tool.MessageBoxDelete();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            //}
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}

        }




        private void frm_HIV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (fmain.ts_cancel_hiv.Enabled == true)
                { Cancel(); }
                else
                { this.Close(); }

            }
            else if (e.KeyCode == Keys.Add && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_add_hiv.Enabled == true)
                {

                    fmain.add_hiv();
                }
            }

            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_save_hiv.Enabled == true)
                {
                    Save();

                }

            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_print_hiv.Enabled == true)
                {
                    Print();
                }
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {

                if (fmain.ts_search_hiv.Enabled == true)
                {
                    fmain.search_hiv();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (fmain.ts_edit_hiv.Enabled == true)
                {
                    Edit();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (fmain.ts_delete_hiv.Enabled == true)
                {

                    Delete();
                }

            }
        }

        private void frm_HIV_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.HIV = true;
            fmain.ts_PrintPreview.Enabled = false; fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = false;

            // fmain.Strip_sub.Visible = false;
        }

        private void txt_resultID_TextChanged(object sender, EventArgs e)
        {
            //if (search_med)
            //{


            //}

            //ClearAll();

            //if (NewHiv)
            //{
            //    //search_HIV();
            //    //search_Medical();
            //    fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = false;

            //}
            //else
            //{

            //    search_HIV();
            //    search_Medical();
            //    fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = true; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = true;

            //}

        }

        private void txt_bday_TextChanged(object sender, EventArgs e)
        {

        }

        //void Load_Medical()
        //{

        //    try
        //    {



        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Table("SELECT 
        //            .cn,  tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical");
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            txt_Medtech.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            txt_patho.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            txt_examining_phy.AutoCompleteCustomSource.Add(dr["Name"].ToString());

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

        //void loadImage(string papin)
        //{


        //    try
        //    {


        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table("Select picture  from m_patient where papin = '" + papin + "'");
        //        clearFolder(ClassSql.HIV_TempImage);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            if (dt.Rows.Count >= 1)
        //            {
        //                byte[] pic_array = (byte[])dr["picture"];
        //                MemoryStream stream = new MemoryStream(pic_array);
        //                stream.Seek(0, SeekOrigin.Begin);
        //                MemoryStream mstream = new MemoryStream();
        //                mstream.Write(pic_array, 0, Convert.ToInt32(pic_array.Length));
        //                Bitmap bm = new Bitmap(mstream, false);
        //                mstream.Dispose();
        //                pic_.Image = bm;

        //            }
        //            else
        //            {
        //                pic_.Image = Properties.Resources.AnonymousPic;
        //                //pic_.BackgroundImage = Properties.Resources.AnonymousPic;

        //            }
        //        }


        //    }
        //    catch 
        //    {
        //        // MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.Systemname.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
        //        pic_.Image = Properties.Resources.AnonymousPic;
        //    }



        //}

        public void Search_Patient(string PatientId)
        {
            try
            {



                //ClassSql a = new ClassSql(); DataTable dt;             
                //dt = a.Mytable_Proc("HIV_Search_Patient", "@SearchID", PatientId);               
                var i = db.sp_HIV_Patient(PatientId).FirstOrDefault();

                //foreach (DataRow dr in dt.Rows)
                //{

                this.txt_name.Text = i.PatientName;
                txt_address.Text = i.address_1.ToString();
                txt_CivitStatus.Text = i.marital_status.ToString();
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

                this.txt_gender.Text = i.gender.ToString();
                this.txt_agency.Text = i.employer.ToString();
                txt_position.Text = i.position.ToString();
                // loadImage(txt_Papin.Text);
                //}

                pic_.Image = Tool.bytetoimage(i.picture.ToArray());


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

        private void txt_Papin_TextChanged(object sender, EventArgs e)
        {

            //if (NewHiv)
            //{
            //    ClassSql a = new ClassSql(); long cnt;
            //    cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + Tool.ReplaceString(txt_Papin.Text) + "' and resulttype = 'HIV'");

            //    if (cnt >= 1)
            //    {

            //        if (MessageBox.Show("Previous laboratory examination Detected! Would you like to update Hir/Her record?", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            NewHiv = false;
            //            search_Medical_Sub();
            //            Search_Patient();
            //            search_HIV();
            //          //  search_Medical();

            //            Availability(true);

            //        }
            //        else
            //        {
            //            NewHiv = true;
            //            Search_Patient();
            //            Availability(true);
            //            ClearAll();


            //        }

            //    }
            //    else
            //    {

            //        NewHiv = true;
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



        private void txt_examining_phy_TextChanged(object sender, EventArgs e)
        {

        }

        private void dt_result_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_result_date.Format = DateTimePickerFormat.Custom;
                dt_result_date.CustomFormat = "00/00/00";
            }
        }

        private void dt_result_date_MouseDown(object sender, MouseEventArgs e)
        {
            dt_result_date.Format = DateTimePickerFormat.Custom;
            dt_result_date.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_expire_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_expire_date.Format = DateTimePickerFormat.Custom;
                dt_expire_date.CustomFormat = "00/00/00";
            }
        }

        private void dt_expire_date_MouseDown(object sender, MouseEventArgs e)
        {
            dt_expire_date.Format = DateTimePickerFormat.Custom;
            dt_expire_date.CustomFormat = "MM/dd/yyyy";
        }

        private void txt_bday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_bday.Format = DateTimePickerFormat.Custom;
                dt_bday.CustomFormat = "00/00/0000";
            }
        }

        private void txt_bday_MouseDown(object sender, MouseEventArgs e)
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

            //  SendKeys.Send("{RIGHT}");
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

        private void dt_result_date_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_expire_date_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void cmd_load1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_Medtech;
                f.txt_license = textBox1;
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_examining_phy;
                f.txt_license = txt_pysicianNo;
                f.ShowDialog();
            }
        }

        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {






        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {



                //using (StreamWriter s = File.CreateText(TableListPath.HIVSearchList))
                //{ s.Close(); }

                //TextWriter sw = new StreamWriter(TableListPath.HIVSearchList);
                //ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Mytable_Proc("Hiv_search", "@SearchID", "%");
                var list = db.sp_HIV_SearchList("%").ToList();
                Cursor.Current = Cursors.WaitCursor;
                //int rowcount = dt.Rows.Count;
                // sw.WriteLine("a \t b \t c \t d \t e");
                foreach (var i in list)
                {

                    // sw.WriteLine(dr[0].ToString() + "\t" + dr[1].ToString() + "\t" + dr[2].ToString());
                    //string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
                    //sw.WriteLine(dr["cn"].ToString() + "\t" + dr["papin"].ToString() + "\t" + dr["resultid"].ToString() + "\t" + dr["PatientName"].ToString() + "\t" + dr["result_date"].ToString());

                    Hiv_model.Add(new HIV_Model
                    {
                        cn = i.cn,
                        papin = i.papin,
                        resultID = i.resultid,
                        patientName = i.PatientName,
                        resultDate = i.result_date
                    });
                }
                //  sw.Close();



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

                //using (StreamWriter s = File.CreateText(TableListPath.QueueSearchList))
                //{ s.Close(); }

                //TextWriter sw = new StreamWriter(TableListPath.QueueSearchList);
                //ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Mytable_Proc("Search_patient_Add_a", "@ID", "%");
                var list = db.sp_HivAdd("%").ToList();
                Cursor.Current = Cursors.WaitCursor;
                //  int rowcount = dt.Rows.Count;
                //sw.WriteLine("a \t b \t c \t d ");
                foreach (var i in list)
                {
                    hivAdd_model.Add(new QueueSearchList_Model
                    {
                        cn = i.cn,
                        papin = i.papin,
                        PatientName = i.PatientName,
                        gender = i.gender
                    });
                    //string Name = dr["lastname"].ToString() + ", " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
                    //sw.WriteLine(dr["cn"].ToString() + "\t" + dr["papin"].ToString() + "\t" + Name.ToString() + "\t" + dr["gender"].ToString());

                }
                //sw.Close();



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
                if ((Application.OpenForms["frm_search_hiv"] as frm_search_hiv) != null)
                { (Application.OpenForms["frm_search_hiv"] as frm_search_hiv).FillDataGridView(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



            //(Application.OpenForms["frm_search_hiv"] as frm_search_hiv).lbl_notification.Visible = false;

        }

        private void frm_HIV_Enter(object sender, EventArgs e)
        {
            Hiv_model.Clear();
            hivAdd_model.Clear();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
