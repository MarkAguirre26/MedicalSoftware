using Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_repeat_Chemistry : Form
    {
        frm_lab flab;

        private string FBS_; private string Bun_; private string Creatinine_; private string Cholesterol_; private string trigly_; private string uric_; private string sgot_; private string sgpt_; private string alk_;

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;


        public string PatientName;
        public string Age;
        public string Sex;
        public string ResultDate;
        public string Address;
        public string RefferedBy;
        public string Position;
        public string CivilStatus;


        public string hdl = "";
        public string ldl = "";
        public string acidPhos = "";
        public string totalbilirubin = "";
        public string b1 = "";
        public string b2 = "";
        public string totalpro = "";
        public string albumin = "";
        public string globulin = "";
        public string agration = "";
        public string other = "";
        public string hdl_con = "";
        public string ldl_con = "";
        public string acidPhos_con = "";
        public string totalbilirubin_con = "";
        public string b1_con = "";
        public string b2_Con = "";
        public string b2_con = "";
        public string totalpro_con = "";
        public string albumin_con = "";
        public string globulin_con = "";
        public string agration_con = "";
        public string other_con = "";
        public string hdl_H = "";
        public string ldl_H = "";
        public string acidPhos_H = "";
        public string totalbilirubin_H = "";
        public string b1_H = "";
        public string b2_H = "";
        public string totalpro_H = "";
        public string albumin_H = "";
        public string globulin_H = "";
        public string agration_H = "";
        public string other_H = "";


        private DataTable dt_Chem;

        public string CHEMID; public int RowsCount;
        private DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public frm_repeat_Chemistry(frm_lab fflab)
        {
            InitializeComponent();
            flab = fflab;
        }



        private void frm_repeat_Chemistry_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Search_Chemistry();
            load_NormalCHEM();
            //Load_Medical();
            if (!backgroundWorker1.IsBusy)
            {
                //Chem f = new Chem();
                //f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync();
            }



            Cursor.Current = Cursors.Default;




        }

        void load_NormalCHEM()
        {


            IniFile ini = new IniFile(ClassSql.MMS_Path);
            label81.Text = ini.IniReadValue("NormalValue", "fbs") + " mmol/L";
            label82.Text = ini.IniReadValue("NormalValue", "bun") + " mmol/L";
            label83.Text = ini.IniReadValue("NormalValue", "creatine") + " mmol/L";
            label84.Text = ini.IniReadValue("NormalValue", "choles") + " mmol/L";
            label85.Text = ini.IniReadValue("NormalValue", "trigly") + " mmol/L";
            label86.Text = ini.IniReadValue("NormalValue", "uric") + " mmol/L";
            label87.Text = ini.IniReadValue("NormalValue", "sgot") + " IU/L";
            label88.Text = ini.IniReadValue("NormalValue", "sgpt") + " IU/L";
            label89.Text = ini.IniReadValue("NormalValue", "alk") + " IU/L";
            label98.Text = ini.IniReadValue("NormalValue", "fbs_con") + " mg/dL";
            label97.Text = ini.IniReadValue("NormalValue", "bun_con") + " mg/dL";
            label96.Text = ini.IniReadValue("NormalValue", "creatine_Con") + " mg/dL";
            label95.Text = ini.IniReadValue("NormalValue", "Cholesterol_Con") + " mg/dL";
            label94.Text = ini.IniReadValue("NormalValue", "Trig_Con") + " mg/dL";
            label93.Text = ini.IniReadValue("NormalValue", "Uric_Con") + " mg/dL";
            label4.Text = ini.IniReadValue("NormalValue", "sgpt_con");
            label3.Text = ini.IniReadValue("NormalValue", "sgot_con");
            label5.Text = ini.IniReadValue("NormalValue", "alk_con");


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
        //           this.Pathologist.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //           this.requestBy.AutoCompleteCustomSource.Add(dr["Name"].ToString());


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

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void search_Medical()
        {

            try
            {


                // ClassSql a = new ClassSql(); DataTable dt;
                //  dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.medtech, t_result_main.pathologist, t_result_main.specimen_no, t_result_main.medtech_license, t_result_main.pathologist_license, t_result_main.result_date, t_result_main.repeat_test_requestby, t_result_main.remarks FROM t_result_main WHERE t_result_main.cn =  '" + dg_Previous.SelectedRows[0].Cells[0].Value.ToString() + "'");
                var i = db.sp_ChemistryMedical(dg_Previous.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
                //dg_Previous.Rows.Clear();
                if (i != null)
                {
                    string input = i.result_date.ToString();
                    DateTime dtime;
                    if (DateTime.TryParse(input, out dtime))
                    {
                        dt_resultdate.Text = input;
                    }


                    MedTech.Text = i.medtech.ToString();
                    this.Pathologist.Text = i.pathologist.ToString();
                    labNo.Text = i.specimen_no.ToString();
                    med_licenseNo.Text = i.medtech_license.ToString();
                    Pathologist_licenseNo.Text = i.pathologist_license.ToString();
                    requestBy.Text = i.repeat_test_requestby.ToString();
                    txt_remark.Text = i.remarks.ToString();
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }

        void Save()
        {

            try
            {
            if (cb_FBS.Checked == true) { FBS_ = "1"; } else { FBS_ = "0"; }
            if (cb_Bun.Checked == true) { Bun_ = "1"; } else { Bun_ = "0"; }
            if (cb_Creatinine.Checked == true) { Creatinine_ = "1"; } else { Creatinine_ = "0"; }
            if (cb_Cholesterol.Checked == true) { Cholesterol_ = "1"; } else { Cholesterol_ = "0"; }
            if (cb_trigly.Checked == true) { trigly_ = "1"; } else { trigly_ = "0"; }
            if (cb_uric.Checked == true) { uric_ = "1"; } else { uric_ = "0"; }
            if (cb_sgot.Checked == true) { sgot_ = "1"; } else { sgot_ = "0"; } //cb_Creatinine
            if (cb_sgpt.Checked == true) { sgpt_ = "1"; } else { sgpt_ = "0"; }
            if (cb_alk.Checked == true) { alk_ = "1"; } else { alk_ = "0"; }

            if (hdl == null) { hdl = "-"; }
            if (ldl == null) { ldl = "-"; }
            if (acidPhos == null) { acidPhos = "-"; }
            if (totalbilirubin == null) { totalbilirubin = "-"; }
            if (b1 == null) { b1 = "-"; }
            if (b2 == null) { b2 = "-"; }
            if (totalpro == null) { totalpro = "-"; }
            if (albumin == null) { albumin = "-"; }
            if (globulin == null) { globulin = "-"; }
            if (agration == null) { agration = "-"; }
            if (other == null) { other = "-"; }




            if (hdl_H == null) { hdl_H = "-"; }
            if (ldl_H == null) { ldl_H = "-"; }
            if (acidPhos_H == null) { acidPhos_H = "-"; }
            if (totalbilirubin_H == null) { totalbilirubin_H = "-"; }
            if (b1_H == null) { b1_H = "-"; }
            if (b2_H == null) { b2_H = "-"; }
            if (totalpro_H == null) { totalpro_H = "-"; }
            if (albumin_H == null) { albumin_H = "-"; }
            if (globulin_H == null) { globulin_H = "-"; }
            if (agration_H == null) { agration_H = "-"; }
            if (other_H == null) { other_H = "-"; }









            db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", CHEMID.ToString(), "CHEM(repeat)", this.Tag.ToString(), dt_resultdate.Text, Pathologist.Text, "PENDING", "", "", txt_remark.Text, "", requestBy.Text, labNo.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, frm_lab.LabId.Text, "", "", "", "", "", "", "", "");
            db.ExecuteCommand("INSERT INTO t_clinical_chemistry (resultid,        fbs,           fbs_con,                     bun,            bun_con,           creatinine,            creatinine_con,                  cholesterol_susp,          cholesterol_susp_con, cholesterol_elev,            cholesterol_elev_con,   uric_acid,                uric_acid_con,                   sgot,            sgot_con,                sgpt,            sgpt_con,               alk_phos,      alk_phos_con,               vdrl,       hbsag,               ahbe,   hbeag,      widal_test,     malarial_smear, hiv,  hbsag_titer,   ahbe_titer,   hbeag_titer,       plasmodium,     repeat_test_id,   fbs_high,        bun_high,                  creatinine_high,         cholesterol_high,         triglycerides_high,  uric_acid_high,     sgot_high,          sgpt_high,       alk_high,        result_date,        hdl ,ldl,  acidPhos, totalbilirubin,  b1, b2, totalpro, albumin, globulin, agration, other, hdl_con,   ldl_con,acidPhos_con, totalbilirubin_con, b1_con,b2_con, totalpro_con, albumin_con,  globulin_con, agration_con,other_con, hdl_H, ldl_H, acidPhos_H,totalbilirubin_H,  b1_H,  b2_H,  totalpro_H, albumin_H ,globulin_H,   agration_H,other_H) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},{61},{62},{63},{64},{65},{66},{67},{68},{69},{70},{71},{72},{73})", CHEMID.ToString(), tx_FBS.Text, tx_fbs_Conventional.Text, tx_Bun.Text, tx_bun_convetional.Text, tx_Creatinine.Text, tx_creatinine_convetional.Text, tx_Cholesterol.Text, tx_choles_conventional.Text, tx_trigly.Text, tx_trygly_convetion.Text, tx_uric.Text, tx_uric_Conventional.Text, tx_sgot.Text, tx_sgot_conventional.Text, tx_sgpt.Text, tx_sgpt_conventional.Text, tx_alk.Text, tx_alk_conventional.Text, cbo_rpr.Text, cbo_hb.Text, "", "", cbo_widal.Text, cbo_malaroial.Text, "", "", "", "", "", "", FBS_.ToString(), Bun_.ToString(), Creatinine_.ToString(), Cholesterol_.ToString(), trigly_.ToString(), uric_.ToString(), sgot_.ToString(), sgpt_.ToString(), alk_.ToString(), dt_resultdate.Text, hdl.ToString(), ldl.ToString(), acidPhos.ToString(), totalbilirubin.ToString(), b1.ToString(), b2.ToString(), totalpro.ToString(), albumin.ToString(), globulin.ToString(), agration.ToString(), other.ToString(), hdl_con.ToString(), ldl_con.ToString(), acidPhos_con.ToString(), totalbilirubin_con.ToString(), b1_con.ToString(), b2_con.ToString(), totalpro_con.ToString(), albumin_con.ToString(), globulin_con.ToString(), agration_con.ToString(), other_con.ToString(), hdl_H.ToString(), ldl_H.ToString(), acidPhos_H.ToString(), totalbilirubin_H.ToString(), b1_H.ToString(), b2_H.ToString(), totalpro_H.ToString(), albumin_H.ToString(), globulin_H.ToString(), agration_H.ToString(), other_H.ToString());
            // CHEMID.ToString(), tx_FBS.Text, tx_fbs_Conventional.Text, tx_Bun.Text, tx_bun_convetional.Text, tx_Creatinine.Text,  tx_creatinine_convetional.Text, tx_Cholesterol.Text,     tx_choles_conventional.Text, tx_trigly.Text,           tx_trygly_convetion.Text, tx_uric.Text,             tx_uric_Conventional.Text,   tx_sgot.Text,    tx_sgot_conventional.Text, tx_sgpt.Text,  tx_sgpt_conventional.Text,  tx_alk.Text,    tx_alk_conventional.Text, cbo_rpr.Text, cbo_hb.Text,        "",     "",     cbo_widal.Text, cbo_malaroial.Text, "",     "",              "",            "",                "",          "",           FBS_.ToString() ,  Bun_.ToString() ,          Creatinine_.ToString() , Cholesterol_.ToString() , trigly_.ToString() ,  uric_.ToString() , sgot_.ToString(),  sgpt_.ToString(), alk_.ToString(), dt_resultdate.Text , hdl, ldl ,acidPhos ,totalbilirubin , b1 ,b2 ,totalpro, albumin , globulin,agration, other , hdl_con , ldl_con,acidPhos_con , totalbilirubin_con,b1_con,b2_con , totalpro_con, albumin_con, globulin_con, agration_con,other_con, hdl_H, ldl_H ,acidPhos_H,totalbilirubin_H , b1_H , b2_H ,totalpro_H , albumin_H , globulin_H , agration_H, other_H

            Tool.MessageBoxSave();
            load_previousData();
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            cmd_save.Text = "Edit";
            cmd_new.Enabled = false;
            cmd_print.Enabled = true;




            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

        }


        void loadPreviousExam()
        {
           
            cmd_save.Text = "Edit"; cmd_save.Enabled = true; cmd_print.Enabled = true; cmd_new.Enabled = false;          
            var i = db.sp_loadRepeatChemistryData(dg_Previous.SelectedRows[0].Cells[1].Value.ToString()).FirstOrDefault();
            if (i != null)
            {
                CHEMID = i.resultid;
                tx_FBS.Text = i.fbs.ToString();
                tx_Bun.Text = i.bun.ToString();
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

                hdl = i.hdl.ToString();
                ldl = i.ldl.ToString();
                acidPhos = i.acidPhos.ToString();
                totalbilirubin = i.totalbilirubin.ToString();
                b1 = i.b1.ToString();
                b2 = i.b2.ToString();
                totalpro = i.totalpro.ToString();
                albumin = i.albumin.ToString();
                globulin = i.globulin.ToString();
                agration = i.agration.ToString();
                other = i.other.ToString();

                hdl_con = i.hdl_con.ToString();
                ldl_con = i.ldl_con.ToString();
                acidPhos_con = i.acidPhos_con.ToString();
                totalbilirubin_con = i.totalpro_con.ToString();
                b1_con = i.b1_con.ToString();
                b2_con = i.b2_con.ToString();
                totalpro_con = i.totalpro_con.ToString();
                albumin_con = i.albumin_con.ToString();
                globulin_con = i.globulin_con.ToString();
                agration_con = i.agration_con.ToString();
                other_con = i.other_con.ToString();

                hdl_H = i.hdl_H.ToString();
                ldl_H = i.ldl_H.ToString();
                acidPhos_H = i.acidPhos_H.ToString();
                totalbilirubin_H = i.totalbilirubin_H.ToString();
                b1_H = i.b1_H.ToString();
                b2_H = i.b2_H.ToString();
                totalpro_H = i.totalpro_H.ToString();
                albumin_H = i.albumin_H.ToString();
                globulin_H = i.globulin_H.ToString();
                agration_H = i.agration_H.ToString();
                other_H = i.other_H.ToString();



                string input = i.result_date.ToString();
                DateTime dtime;
                if (DateTime.TryParse(input, out dtime))
                {
                    dt_resultdate.Text = input;
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
            
            
            }
         
                
           
            search_Medical();

        }

        public class Chem
        {
            public string cn, resultid, resultdate, papin;
        }


        //void Search_Chemistry()
        //{
        //    try
        //    {


        //         ClassSql a = new ClassSql(); DataTable dt;             
        //         dt = a.Table("SELECT t_result_main.cn,t_result_main.resultid, t_result_main.result_date FROM t_result_main WHERE t_result_main.papin = '" + this.Tag.ToString() + "' AND t_result_main.resulttype = 'CHEM(repeat)'");

        //         dg_Previous.Rows.Clear();
        //         foreach (DataRow dr in dt.Rows)
        //         {
        //             string[] row = new string[] { dr["cn"].ToString(), dr["resultid"].ToString(), dr["result_date"].ToString() };
        //             dg_Previous.Rows.Add(row);

        //         }


        //         if (dt.Rows.Count >=1)
        //         {
        //             cmd_new.Enabled = false;

        //         }
        //         else
        //         {
        //             cmd_new.Enabled = true;
        //         }


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


        public void Update_Chem()
        {
            try
            {



                if (cb_FBS.Checked == true) { FBS_ = "1"; } else { FBS_ = "0"; }
                if (cb_Bun.Checked == true) { Bun_ = "1"; } else { Bun_ = "0"; }
                if (cb_Creatinine.Checked == true) { Creatinine_ = "1"; } else { Creatinine_ = "0"; }
                if (cb_Cholesterol.Checked == true) { Cholesterol_ = "1"; } else { Cholesterol_ = "0"; }
                if (cb_trigly.Checked == true) { trigly_ = "1"; } else { trigly_ = "0"; }
                if (cb_uric.Checked == true) { uric_ = "1"; } else { uric_ = "0"; }
                if (cb_sgot.Checked == true) { sgot_ = "1"; } else { sgot_ = "0"; } //cb_Creatinine
                if (cb_sgpt.Checked == true) { sgpt_ = "1"; } else { sgpt_ = "0"; }
                if (cb_alk.Checked == true) { alk_ = "1"; } else { alk_ = "0"; }

                if (hdl == null) { hdl = "-"; }
                if (ldl == null) { ldl = "-"; }
                if (acidPhos == null) { acidPhos = "-"; }
                if (totalbilirubin == null) { totalbilirubin = "-"; }
                if (b1 == null) { b1 = "-"; }
                if (b2 == null) { b2 = "-"; }
                if (totalpro == null) { totalpro = "-"; }
                if (albumin == null) { albumin = "-"; }
                if (globulin == null) { globulin = "-"; }
                if (agration == null) { agration = "-"; }
                if (other == null) { other = "-"; }

                if (hdl_H == null) { hdl_H = "-"; }
                if (ldl_H == null) { ldl_H = "-"; }
                if (acidPhos_H == null) { acidPhos_H = "-"; }
                if (totalbilirubin_H == null) { totalbilirubin_H = "-"; }
                if (b1_H == null) { b1_H = "-"; }
                if (b2_H == null) { b2_H = "-"; }
                if (totalpro_H == null) { totalpro_H = "-"; }
                if (albumin_H == null) { albumin_H = "-"; }
                if (globulin_H == null) { globulin_H = "-"; }
                if (agration_H == null) { agration_H = "-"; }
                if (other_H == null) { other_H = "-"; }
                //ClassSql a = new ClassSql();
                //a.ExecuteQuery("UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `medtech`='" + Tool.ReplaceString(MedTech.Text) + "', `medtech_license`='" + Tool.ReplaceString(med_licenseNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "',`pathologist`='" + Tool.ReplaceString(Pathologist.Text) + "',`specimen_no`='" + Tool.ReplaceString(labNo.Text) + "' , `repeat_test_requestby`='" + Tool.ReplaceString(requestBy.Text) + "', `remarks` = '" + Tool.ReplaceString(txt_remark.Text) + "'WHERE (`resultid`='" + CHEMID.ToString() + "') LIMIT 1");
                //a.ExecuteQuery("UPDATE `t_clinical_chemistry` SET  `fbs`='" + Tool.ReplaceString(tx_FBS.Text) + "', `fbs_con`='" + Tool.ReplaceString(this.tx_fbs_Conventional.Text) + "', `bun`='" + Tool.ReplaceString(this.tx_Bun.Text) + "', `bun_con`='" + Tool.ReplaceString(this.tx_bun_convetional.Text) + "', `creatinine`='" + Tool.ReplaceString(this.tx_Creatinine.Text) + "', `creatinine_con`='" + Tool.ReplaceString(this.tx_creatinine_convetional.Text) + "', `cholesterol_susp`='" + Tool.ReplaceString(this.tx_Cholesterol.Text) + "', `cholesterol_susp_con`='" + Tool.ReplaceString(this.tx_choles_conventional.Text) + "', `cholesterol_elev`='" + Tool.ReplaceString(this.tx_trigly.Text) + "', `cholesterol_elev_con`='" + Tool.ReplaceString(this.tx_trygly_convetion.Text) + "', `uric_acid`='" + Tool.ReplaceString(this.tx_uric.Text) + "', `uric_acid_con`='" + Tool.ReplaceString(this.tx_uric_Conventional.Text) + "', `sgot`='" + Tool.ReplaceString(this.tx_sgot.Text) + "', `sgot_con`='" + Tool.ReplaceString(this.tx_sgot_conventional.Text) + "', `sgpt`='" + Tool.ReplaceString(this.tx_sgpt.Text) + "', `sgpt_con`='" + Tool.ReplaceString(this.tx_sgpt_conventional.Text) + "', `alk_phos`='" + Tool.ReplaceString(this.tx_alk.Text) + "', `alk_phos_con`='" + Tool.ReplaceString(this.tx_alk_conventional.Text) + "', `vdrl`='" + Tool.ReplaceString(this.cbo_rpr.Text) + "', `hbsag`='" + Tool.ReplaceString(this.cbo_hb.Text) + "', `ahbe`='', `hbeag`='', `widal_test`='" + Tool.ReplaceString(this.cbo_widal.Text) + "', `malarial_smear`='" + Tool.ReplaceString(this.cbo_malaroial.Text) + "', `hiv`='', `hbsag_titer`='', `ahbe_titer`='', `hbeag_titer`='', `plasmodium`='', `repeat_test_id`='" + Tool.ReplaceString(this.Tag.ToString()) + "', `fbs_high`='" + FBS_.ToString() + "', `bun_high`='" + Bun_.ToString() + "', `creatinine_high`='" + Creatinine_.ToString() + "', `cholesterol_high`='" + Cholesterol_.ToString() + "', `triglycerides_high`='" + trigly_.ToString() + "', `uric_acid_high`='" + uric_.ToString() + "', `sgot_high`='" + sgot_.ToString() + "', `sgpt_high`='" + sgpt_.ToString() + "', `alk_high`='" + alk_.ToString() + "', `result_date`='"+Tool.ReplaceString(dt_resultdate.Text) +"' WHERE (`resultid`='" + CHEMID.ToString() +"') LIMIT 1");
                //var arr = new[] { "UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `medtech`='" + Tool.ReplaceString(MedTech.Text) + "', `medtech_license`='" + Tool.ReplaceString(med_licenseNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "',`pathologist`='" + Tool.ReplaceString(Pathologist.Text) + "',`specimen_no`='" + Tool.ReplaceString(labNo.Text) + "' , `repeat_test_requestby`='" + Tool.ReplaceString(requestBy.Text) + "', `remarks` = '" + Tool.ReplaceString(txt_remark.Text) + "'WHERE (`resultid`='" + CHEMID.ToString() + "') LIMIT 1", "UPDATE `t_clinical_chemistry` SET  `fbs`='" + Tool.ReplaceString(tx_FBS.Text) + "', `fbs_con`='" + Tool.ReplaceString(this.tx_fbs_Conventional.Text) + "', `bun`='" + Tool.ReplaceString(this.tx_Bun.Text) + "', `bun_con`='" + Tool.ReplaceString(this.tx_bun_convetional.Text) + "', `creatinine`='" + Tool.ReplaceString(this.tx_Creatinine.Text) + "', `creatinine_con`='" + Tool.ReplaceString(this.tx_creatinine_convetional.Text) + "', `cholesterol_susp`='" + Tool.ReplaceString(this.tx_Cholesterol.Text) + "', `cholesterol_susp_con`='" + Tool.ReplaceString(this.tx_choles_conventional.Text) + "', `cholesterol_elev`='" + Tool.ReplaceString(this.tx_trigly.Text) + "', `cholesterol_elev_con`='" + Tool.ReplaceString(this.tx_trygly_convetion.Text) + "', `uric_acid`='" + Tool.ReplaceString(this.tx_uric.Text) + "', `uric_acid_con`='" + Tool.ReplaceString(this.tx_uric_Conventional.Text) + "', `sgot`='" + Tool.ReplaceString(this.tx_sgot.Text) + "', `sgot_con`='" + Tool.ReplaceString(this.tx_sgot_conventional.Text) + "', `sgpt`='" + Tool.ReplaceString(this.tx_sgpt.Text) + "', `sgpt_con`='" + Tool.ReplaceString(this.tx_sgpt_conventional.Text) + "', `alk_phos`='" + Tool.ReplaceString(this.tx_alk.Text) + "', `alk_phos_con`='" + Tool.ReplaceString(this.tx_alk_conventional.Text) + "', `vdrl`='" + Tool.ReplaceString(this.cbo_rpr.Text) + "', `hbsag`='" + Tool.ReplaceString(this.cbo_hb.Text) + "', `ahbe`='', `hbeag`='', `widal_test`='" + Tool.ReplaceString(this.cbo_widal.Text) + "', `malarial_smear`='" + Tool.ReplaceString(this.cbo_malaroial.Text) + "', `hiv`='', `hbsag_titer`='', `ahbe_titer`='', `hbeag_titer`='', `plasmodium`='', `repeat_test_id`='" + Tool.ReplaceString(this.Tag.ToString()) + "', `fbs_high`='" + FBS_.ToString() + "', `bun_high`='" + Bun_.ToString() + "', `creatinine_high`='" + Creatinine_.ToString() + "', `cholesterol_high`='" + Cholesterol_.ToString() + "', `triglycerides_high`='" + trigly_.ToString() + "', `uric_acid_high`='" + uric_.ToString() + "', `sgot_high`='" + sgot_.ToString() + "', `sgpt_high`='" + sgpt_.ToString() + "', `alk_high`='" + alk_.ToString() + "', `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "',hdl = '" + hdl + "' ,ldl='" + ldl + "',acidPhos='" + acidPhos + "',totalbilirubin='" + totalbilirubin + "',b1='" + b1 + "',b2='" + b2 + "',totalpro='" + totalpro + "',albumin='" + albumin + "',globulin='" + globulin + "',agration='" + agration + "',other='" + other + "', hdl_con ='" + hdl_con + "',ldl_con='" + ldl_con + "',acidPhos_con='" + acidPhos_con + "',totalbilirubin_con='" + totalbilirubin_con + "',b1_con='" + b1_con + "',b2_con='" + b2_con + "',totalpro_con='" + totalpro_con + "',albumin_con='" + albumin_con + "',globulin_con='" + globulin_con + "',agration_con='" + agration_con + "',other_con='" + other_con + "',hdl_H='" + hdl_H + "',ldl_H='" + ldl_H + "',acidPhos_H='" + acidPhos_H + "',totalbilirubin_H='" + totalbilirubin_H + "',b1_H='" + b1_H + "',b2_H='" + b2_H + "',totalpro_H='" + totalpro_H + "',albumin_H='" + albumin_H + "',globulin_H='" + globulin_H + "',agration_H='" + agration_H + "',other_H='" + other_H + "'   WHERE (`resultid`='" + CHEMID.ToString() + "') LIMIT 1" };

                db.ExecuteCommand("UPDATE t_result_main SET result_date={0}, medtech={1}, medtech_license={2},pathologist_license={3},pathologist={4},specimen_no={5} , repeat_test_requestby={6}, remarks = {7} WHERE (resultid={8})", dt_resultdate.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, Pathologist.Text, labNo.Text, requestBy.Text, txt_remark.Text, CHEMID.ToString());
                db.ExecuteCommand("UPDATE t_clinical_chemistry SET   fbs={0}, fbs_con={1},bun= {2}, bun_con= {3},creatinine= {4}, creatinine_con={5}, cholesterol_susp=  {6} , cholesterol_susp_con={7} ,cholesterol_elev= {8}, cholesterol_elev_con={9},  uric_acid= {10} , uric_acid_con={11},sgot= {12} ,  sgot_con={13},sgpt= {14} ,sgpt_con={15} ,alk_phos= {16} , alk_phos_con={17} , vdrl= {18} ,            hbsag=   {19}, ahbe=  {20}, hbeag= {21} ,widal_test= {22} ,malarial_smear= {23},hiv=    {24}, hbsag_titer={25}, ahbe_titer={26} , hbeag_titer={27},plasmodium={28}, repeat_test_id= {29} ,  fbs_high=  {30}, bun_high= {31}  , creatinine_high= {32} ,  cholesterol_high= {33},triglycerides_high={34} , uric_acid_high= {35}  ,            sgot_high=  {36}           ,            sgpt_high={37}            ,            alk_high=  {38}           ,             result_date= {39}            ,            hdl = {40}                   ,            ldl=  {41}              ,            acidPhos= {42}              ,            totalbilirubin= {43}                ,            b1= {44}                   ,            b2=  {45}                     ,            totalpro={46}                 ,            albumin=  {47}                 ,            globulin= {48}             ,            agration= {49}          ,            other=    {50}             ,             hdl_con = {51}             ,            ldl_con=   {52}                ,            acidPhos_con={53}              ,            totalbilirubin_con={54}            ,            b1_con= {55}               ,            b2_con=  {56}                  ,            totalpro_con= {57}              ,            albumin_con=  {58}         ,            globulin_con= {59}         ,            agration_con=  {60}        ,            other_con=  {61}          ,            hdl_H=      {62}           ,            ldl_H=      {63}          ,            acidPhos_H=  {64}          ,            totalbilirubin_H=  {65}    ,            b1_H=  {66}                ,            b2_H=   {67}            ,            totalpro_H={68}           ,            albumin_H= {69}            ,            globulin_H= {70}           ,            agration_H= {71}           ,            other_H=    {72}                   WHERE resultid= {73}  ", tx_FBS.Text, this.tx_fbs_Conventional.Text, this.tx_Bun.Text, this.tx_bun_convetional.Text, this.tx_Creatinine.Text, this.tx_creatinine_convetional.Text, this.tx_Cholesterol.Text, this.tx_choles_conventional.Text, this.tx_trigly.Text, this.tx_trygly_convetion.Text, this.tx_uric.Text, this.tx_uric_Conventional.Text, this.tx_sgot.Text, this.tx_sgot_conventional.Text, this.tx_sgpt.Text, this.tx_sgpt_conventional.Text, this.tx_alk.Text, this.tx_alk_conventional.Text, this.cbo_rpr.Text, this.cbo_hb.Text, "", "", this.cbo_widal.Text, this.cbo_malaroial.Text, "", "", "", "", "", this.Tag.ToString(), FBS_.ToString(), Bun_.ToString(), Creatinine_.ToString(), Cholesterol_.ToString(), trigly_.ToString(), uric_.ToString(), sgot_.ToString(), sgpt_.ToString(), alk_.ToString(), "dt_resultdate.Text", hdl, ldl, acidPhos, totalbilirubin, b1, b2, totalpro, albumin, globulin, agration, other, hdl_con, ldl_con, acidPhos_con, totalbilirubin_con, b1_con, b2_con, totalpro_con, albumin_con, globulin_con, agration_con, other_con, hdl_H, ldl_H, acidPhos_H, totalbilirubin_H, b1_H, b2_H, totalpro_H, albumin_H, globulin_H, agration_H, other_H, CHEMID.ToString());
                Tool.MessageBoxUpdate();
                load_previousData();
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                cmd_save.Enabled = true;
                cmd_print.Enabled = true;
                groupBox2.Enabled = true;
                cmd_save.Text = "Edit";

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }

        private void cmd_save_Click(object sender, EventArgs e)
        {
            if (cmd_save.Text == "&Save")
            { Save(); }
            else if (cmd_save.Text == "Edit")
            {
                cmd_save.Text = "Update";
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                cmd_print.Enabled = false;
                groupBox2.Enabled = false;
            }
            else
            {
                Update_Chem();
            }


        }

        private void MedTech_TextChanged(object sender, EventArgs e)
        {
            //if (MedTech.Text == "")
            //{ med_licenseNo.Clear(); }
            //else
            //{
            //    ClassSql a = new ClassSql();
            //    a.PutDataTOTextBox("SELECT 
            //.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Name LIKE  '%" + MedTech.Text + "%'", this.med_licenseNo, "License");


            //}


        }

        private void Pathologist_TextChanged(object sender, EventArgs e)
        {
            //if (Pathologist.Text == "")
            //{ Pathologist_licenseNo.Clear(); }
            //else
            //{
            //    ClassSql a = new ClassSql();
            //    a.PutDataTOTextBox("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Name like  '%" + Pathologist.Text + "%'", this.Pathologist_licenseNo, "License");


            //}


        }

        private void requestBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmd_print_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            //Report.Report_Lab Print = new Report.Report_Lab();
            //Print.Tag = CHEMID.ToString();
            //Print.R_Chem.Select();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = true; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = false;
            //Print.Load_Chem();
            //Print.ShowDialog();

            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isChemistry = true;
                f.Tag = CHEMID.ToString();
                f.age = Age;
                f.PatientName = PatientName;
                f.Sex = Sex;
                f.resultDate = dt_resultdate.Text;
                f.Address = Address;
                f.ReferredBy = requestBy.Text;
                f.Position = Position;
                f.FBS_ = tx_FBS.Text;
                f.BUN_ = tx_Bun.Text;
                f.CREATINE_ = tx_Creatinine.Text;
                f.CHOLESTEROL_ = tx_Cholesterol.Text;
                f.TRIGLYCERIDES_ = tx_trigly.Text;
                f.URICACID_ = tx_uric.Text;
                f.SGOT_ = tx_sgot.Text;
                f.SGPT_ = tx_sgpt.Text;
                f.ALKPHOS_ = tx_alk.Text;
                f.Medtech = MedTech.Text;
                f.MedTech_lic = med_licenseNo.Text;
                f.Pathologist = Pathologist.Text;
                f.Pathologist_Lic = Pathologist_licenseNo.Text;
                f.SpecimenNo = labNo.Text;
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
                f.Remark_Chem = txt_remark.Text;



                f.hdl = hdl;
                f.ldl = ldl;
                f.acidPhos = acidPhos;
                f.totalbilirubin = totalbilirubin;
                f.b1 = b1;
                f.b2 = b2;
                f.totalpro = totalpro;
                f.albumin = albumin;
                f.globulin = globulin;
                f.agration = agration;
                f.other_more_chem = other;
                f.hdl_con = hdl_con;
                f.ldl_con = ldl_con;
                f.acidPhos_con = acidPhos_con;
                f.totalbilirubin_con = totalbilirubin_con;
                f.b1_con = b1_con;
                f.b2_Con = b2_Con;
                f.b2_con = b2_con;
                f.totalpro_con = totalpro_con;
                f.albumin_con = albumin_con;
                f.globulin_con = globulin_con;
                f.agration_con = agration_con;
                f.other_con = other_con;
                f.hdl_H = hdl_H;
                f.ldl_H = ldl_H;
                f.acidPhos_H = acidPhos_H;
                f.totalbilirubin_H = totalbilirubin_H;
                f.b1_H = b1_H;
                f.b2_H = b2_H;
                f.totalpro_H = totalpro_H;
                f.albumin_H = albumin_H;
                f.globulin_H = globulin_H;
                f.agration_H = agration_H;
                f.other_H = other_H;

                f.ShowDialog();
            }
        }

        private void frm_repeat_Chemistry_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ClassSql.DbConnect();
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_bun_convetional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_creatinine_convetional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_creatinine_convetional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_choles_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_choles_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_trygly_convetion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_trygly_convetion.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_uric_Conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_uric_Conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_sgot_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_sgot_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_sgpt_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_sgpt_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_alk_conventional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
            if (e.KeyChar == '.' && tx_alk_conventional.Text.IndexOf('.') > -1)
                e.Handled = true;
        }

        private void tx_fbs_Conventional_TextChanged(object sender, EventArgs e)
        {
            try
            {


                double result = Convert.ToDouble(tx_fbs_Conventional.Text) * Convert.ToDouble(0.0555);
                tx_FBS.Text = result.ToString("0.0");
            }
            catch
            {
                tx_FBS.Clear();

            }
        }

        private void tx_bun_convetional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_bun_convetional.Text) * Convert.ToDouble(0.357);
                tx_Bun.Text = result.ToString("0.0");
            }
            catch
            { tx_Bun.Clear(); }
        }

        private void tx_creatinine_convetional_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_creatinine_convetional.Text) * Convert.ToDouble(88.4);
                tx_Creatinine.Text = result.ToString("0.0");
            }
            catch
            { tx_Creatinine.Clear(); }


        }

        private void tx_choles_conventional_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double result = Convert.ToDouble(tx_choles_conventional.Text) * Convert.ToDouble(0.0259);
                tx_Cholesterol.Text = result.ToString("0.0");
            }
            catch
            { tx_Cholesterol.Clear(); }


        }

        private void tx_trygly_convetion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(tx_trygly_convetion.Text) / Convert.ToDouble(88.5);
                tx_trigly.Text = result.ToString("0.00");
            }
            catch
            { tx_trigly.Clear(); }


        }

        private void tx_uric_Conventional_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double result = Convert.ToDouble(tx_uric_Conventional.Text) * Convert.ToDouble(0.059);
                tx_uric.Text = result.ToString("0.00");
            }
            catch
            { tx_uric.Clear(); }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tx_sgot_conventional_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = MedTech;
                f.txt_license = med_licenseNo;
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = Pathologist;
                f.txt_license = Pathologist_licenseNo;
                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = requestBy;
                f.txt_license = textBox1;
                f.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report.Report_Lab Print = new Report.Report_Lab();
            Print.Tag = CHEMID.ToString();
            //Print.R_Chem.Select();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = true; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = false;
            //Print.Load_Chem();
            Print.isChem = true;
            Print.ShowDialog();
        }

        private void tx_sgpt_conventional_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_alk_conventional_TextChanged(object sender, EventArgs e)
        {

        }

        private void dg_orevieousExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex != 0)
            {
                if (dg_Previous.Rows.Count >= 1)
                {
                    loadPreviousExam();
                }

            }

        }

        private void cmd_new_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        void CreateNew()
        {


            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            Tool.ClearFields(groupBox3);
            Tool.ClearFields(groupBox1);
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            cmd_save.Enabled = true;
            cmd_print.Enabled = false;
            cmd_save.Text = "&Save";
        
        }

        private void cmd_refresh_Click(object sender, EventArgs e)
        {

        }

        private void cmd_refresh_Click_1(object sender, EventArgs e)
        {
            // Search_Chemistry();
            //if (dg_orevieousExams.Rows.Count >= 1)
            //{ cmd_new.Enabled = false; }
            //else
            //{ cmd_new.Enabled = true; }


            if (!backgroundWorker1.IsBusy)
            {
                Chem f = new Chem();
                f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync(f);
            }



        }


        void load_previousData()
        {

            try
            {

                //    using (StreamWriter s = File.CreateText(TableListPath.Repeat_Chem_List))
                //{ s.Close(); }

                //    TextWriter sw = new StreamWriter(TableListPath.Repeat_Chem_List);
                //ClassSql a = new ClassSql(); DataTable dt;
                // dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.result_date  FROM t_result_main WHERE t_result_main.papin = '"+this.Tag.ToString() +"' AND t_result_main.resulttype = 'CHEM(repeat)'");

                var lists = db.sp_RepeatChemistryList(this.Tag.ToString()).ToList();
                var RowCount = lists.Count();
                Cursor.Current = Cursors.WaitCursor;
                //  int rowcount = dt.Rows.Count;
                //  sw.WriteLine("cn \t resultid \t result_date");
                dg_Previous.Rows.Clear();
                foreach (var i in lists)
                {
                    dg_Previous.Rows.Add(i.cn.ToString(), i.resultid, i.result_date);
                    // sw.WriteLine(dr["cn"].ToString() + "\t" + dr["resultid"].ToString() + "\t" + dr["result_date"].ToString());

                }
                // sw.Close();
                if (RowCount >= 1)
                { cmd_new.Enabled = false; }
                else
                { cmd_new.Enabled = true; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            this.Invoke(new MethodInvoker(delegate() { load_previousData(); }));


        }

        void FillDataGridView()
        {
            try
            {


                dt_Chem = Tool.GetDataSourceFromFile(TableListPath.Repeat_Chem_List);

                if (dt_Chem.Rows.Count >= 1)
                {
                    dt_Chem.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_Chem.Columns[1], "%");
                    dg_Previous.DataSource = dt_Chem;
                    dg_Previous.Columns[0].Visible = false;
                    dg_Previous.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dg_Previous.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                }

                if (dt_Chem.Rows.Count >= 1)
                { cmd_new.Enabled = false; }
                else
                { cmd_new.Enabled = true; }
            }

            catch
            { }

        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //int i = 1;

            //CHEMID = ClassSql.Generate_ResultID("SELECT t_clinical_chemistry.resultid FROM t_clinical_chemistry WHERE t_clinical_chemistry.resultid LIKE '%CHEM%' ORDER BY t_clinical_chemistry.cn DESC LIMIT 1", "resultid", "CHEM");

            //backgroundWorker2.ReportProgress(i, CHEMID);
            //i++;
            var list = db.sp_GenerateRepeatChemistryID();
            foreach (var i in list)
            {
                CHEMID = i.generated_id;
            }

        }


        private void dg_Previous_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex != 0)
            {
                if (this.dg_Previous.Rows.Count >= 1)
                {
                    loadPreviousExam();
                }

            }
        }

        private void cmd_more_Click(object sender, EventArgs e)
        {
            using (frm_ChemOthers f = new frm_ChemOthers())
            {
                f.txt_hdl.Text = hdl;
                f.txt_ldl.Text = ldl;
                f.txt_acidPhos.Text = acidPhos;
                f.txt_totalbil.Text = totalbilirubin;
                f.txt_b1.Text = b1;
                f.txt_b2.Text = b2;
                f.txt_totalprotein.Text = totalpro;
                f.txt_albumin.Text = albumin;
                f.txt_globulin.Text = globulin;
                f.txt_agRatio.Text = agration;
                f.txt_other.Text = other;


                f.txt_hdl_con.Text = hdl_con;
                f.txt_ldl_con.Text = ldl_con;
                f.txt_acidPhos_con.Text = acidPhos_con;
                f.txt_totalbil_con.Text = totalbilirubin_con;
                f.txt_b1_con.Text = b1_con;
                f.txt_b2_con.Text = b2_con;
                f.txt_totalprotein_con.Text = totalpro_con;
                f.txt_albumin_con.Text = albumin_con;
                f.txt_globulin_con.Text = globulin_con;
                f.txt_agRatio_con.Text = agration_con;
                f.txt_other_con.Text = other_con;

                



                if (hdl_H == "1") { f.cb_FBS.Checked = true; } else { f.cb_FBS.Checked = false; }
                if (ldl_H == "1") { f.cb_Bun.Checked = true; } else { f.cb_Bun.Checked = false; }
                if (acidPhos_H == "1") { f.cb_Creatinine.Checked = true; } else { f.cb_Creatinine.Checked = false; }
                if (totalbilirubin_H == "1") { f.cb_Cholesterol.Checked = true; } else { f.cb_Cholesterol.Checked = false; }
                if (b1_H == "1") { f.cb_trigly.Checked = true; } else { f.cb_trigly.Checked = false; }
                if (b2_H == "1") { f.cb_uric.Checked = true; } else { f.cb_uric.Checked = false; }
                if (totalpro_H == "1") { f.cb_sgot.Checked = true; } else { f.cb_sgot.Checked = false; }
                if (albumin_H == "1") { f.cb_sgpt.Checked = true; } else { f.cb_sgpt.Checked = false; }
                if (globulin_H == "1") { f.cb_alk.Checked = true; } else { f.cb_alk.Checked = false; }
                if (agration_H == "1") { f.checkBox3.Checked = true; } else { f.checkBox3.Checked = false; }
                if (other_H == "1") { f.checkBox2.Checked = true; } else { f.checkBox2.Checked = false; }



                f.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_Previous.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    db.ExecuteCommand("Delete from t_result_main where cn= {0}", dg_Previous.SelectedRows[0].Cells[0].Value.ToString());
                    db.ExecuteCommand("Delete from t_clinical_chemistry where resultid = {0}", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
                    load_previousData(); CreateNew();
                }
            }
            else
            {
                MessageBox.Show("No active/selected record", Properties.Settings.Default.SystemName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        
            
        }
    }
}
