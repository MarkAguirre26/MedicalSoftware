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
    public partial class frm_repeat_Fecalysis : Form
    {
        frm_lab flab; private string FecalysisID; private int RowsCount;

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        public string Age;

        public string PatientName;
        public string Address;
        public string Sex;
        public string CivilStatus;
        public string Position;

        private DataTable dt_Fecal;
        private DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public frm_repeat_Fecalysis(frm_lab fflab)
        {
            InitializeComponent();
            flab = fflab;
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public void search_Medical()
        {

            try
            {


                //ClassSql a = new ClassSql(); DataTable dt;

                // dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.medtech, t_result_main.pathologist, t_result_main.specimen_no, t_result_main.medtech_license, t_result_main.pathologist_license, t_result_main.result_date, t_result_main.repeat_test_requestby, t_result_main.remarks FROM t_result_main WHERE t_result_main.cn =  '" + dg_Previous.SelectedRows[0].Cells[0].Value.ToString() + "'");
                var i = db.sp_FecalysisMedical(dg_Previous.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
                //foreach (var i in list)
                //{

                if (i != null)
                {

                    //dt_resultdate.Text = dr["result_date"].ToString();

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




        //public void Search_Fecalysis()
        //{
        //    try
        //    {


        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table("SELECT t_result_main.cn,t_result_main.resultid,t_result_main.result_date FROM t_result_main WHERE t_result_main.papin = '" + this.Tag.ToString() + "' AND t_result_main.resulttype = 'STOOL(repeat)'");

        //     dg_Previous.Rows.Clear();

        //        foreach(DataRow dr in dt.Rows)
        //        {

        //            string[] row = new string[] { dr["cn"].ToString(), dr["resultid"].ToString(), dr["result_date"].ToString() };
        //            dg_Previous.Rows.Add(row);

        //        }

        //        if (dg_Previous.Rows.Count >= 1)
        //        { cmd_new.Enabled = false; }
        //        else
        //        { cmd_new.Enabled = true; }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //       // if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }

        //}
        public void Update_Fecalysis()
        {
            try
            {

                //ClassSql a = new ClassSql();
                //a.ExecuteQuery("UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `medtech`='" + Tool.ReplaceString(MedTech.Text) + "', `medtech_license`='" + Tool.ReplaceString(med_licenseNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "',`pathologist`='" + Tool.ReplaceString(Pathologist.Text) + "',`specimen_no`='" + Tool.ReplaceString(labNo.Text) + "' , `repeat_test_requestby`='" + Tool.ReplaceString(requestBy.Text) + "', `remarks` = '" + Tool.ReplaceString(txt_remark.Text) + "'WHERE (`resultid`='" + FecalysisID.ToString() + "') LIMIT 1");

                //a.ExecuteQuery("UPDATE `t_fecalysis` SET  `color`='" + Tool.ReplaceString(cbo_color_fecal.Text) + "', `ova_parasite`='" + Tool.ReplaceString(tx_ova.Text) + "', `consistency`='" + Tool.ReplaceString(this.cbo_consistency.Text) + "', `red_blood_cells`='" + Tool.ReplaceString(this.tx_red_fecal.Text) + "', `white_blood_cells`='" + Tool.ReplaceString(this.tx_whitBlood_fecal.Text) + "', `amoeba`='" + Tool.ReplaceString(this.tx_amoeba.Text) + "', `others`='" + Tool.ReplaceString(this.txt_other_Fecalysis.Text) + "', `occult_blood`='" + Tool.ReplaceString(this.tx_occultBloodTest.Text) + "', `repeat_test_id`='" + Tool.ReplaceString(this.Tag.ToString()) + "', `result_date`='" + Tool.ReplaceString(this.dt_resultdate.Text) + "', `color_others`='" + Tool.ReplaceString(this.txt_color_other.Text) + "' WHERE (`resultid`='" + FecalysisID.ToString() + "') LIMIT 1");

                //   var arr = new[] { "UPDATE `t_result_main` SET `result_date`={0}, `medtech`={1}, `medtech_license`={2},`pathologist_license`={3},`pathologist`={4},`specimen_no`={5} , `repeat_test_requestby`={6}, `remarks` = {7} WHERE (`resultid`={8})", "UPDATE `t_fecalysis` SET  `color`={0}, `ova_parasite`={1}, `consistency`={2}, `red_blood_cells`={3}', `white_blood_cells`={4}, `amoeba`={5}, `others`={6}, `occult_blood`={7}, `repeat_test_id`={8}, `result_date`={9}, `color_others`={10} WHERE (`resultid`={11}) " };
                //   File.WriteAllLines(ClassSql.tmp_path, arr);
                db.ExecuteCommand("UPDATE t_result_main SET result_date={0}, medtech={1}, medtech_license={2},pathologist_license={3},pathologist={4},specimen_no={5} , repeat_test_requestby={6}, remarks = {7} WHERE (resultid={8})", dt_resultdate.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, Pathologist.Text, labNo.Text, requestBy.Text, txt_remark.Text, FecalysisID.ToString());
                db.ExecuteCommand("UPDATE t_fecalysis SET  color={0}, ova_parasite={1}, consistency={2}, red_blood_cells={3}, white_blood_cells={4}, amoeba={5}, others={6}, occult_blood={7}, repeat_test_id={8}, result_date={9}, color_others={10} WHERE (resultid={11})", cbo_color_fecal.Text, tx_ova.Text, cbo_consistency.Text, tx_red_fecal.Text, tx_whitBlood_fecal.Text, tx_amoeba.Text, txt_other_Fecalysis.Text, tx_occultBloodTest.Text, this.Tag.ToString(), dt_resultdate.Text, this.txt_color_other.Text, FecalysisID.ToString());
                Tool.MessageBoxUpdate();
                load_FecalPreviousList();
                groupBox1.Enabled = false;
                groupBox10.Enabled = false;
                cmd_save.Enabled = true;
                cmd_print.Enabled = true;
                groupBox2.Enabled = true;
                cmd_save.Text = "Edit";

                //Search_Fecalysis();
                // flab.Search_Fecalysis();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            //finally
            //{
            //   // if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}


        }

        //void Load_Medical()
        //{

        //    try
        //    {



        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Table("SELECT 
        //.cn,  tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            this.MedTech.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            this.Pathologist.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //            this.requestBy.AutoCompleteCustomSource.Add(dr["Name"].ToString());


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

        void Save()
        {

            try
            {



                //ClassSql a = new ClassSql();
                //a.ExecuteQuery("INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + FecalysisID.ToString() + "', 'STOOL(repeat)', '" + this.Tag.ToString() + "', '" + dt_resultdate.Text + "', '" + Tool.ReplaceString(Pathologist.Text) + "', 'PENDING',   '',              '',            '" + Tool.ReplaceString(txt_remark.Text) + "',                  '',               '" + Tool.ReplaceString(requestBy.Text) + "',                 '" + Tool.ReplaceString(labNo.Text) + "',               '" + Tool.ReplaceString(MedTech.Text) + "', '" + Tool.ReplaceString(med_licenseNo.Text) + "', '" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "', '" + frm_lab.LabId.Text + "',              '',             '',                  '',            '',             '',                 '',                 '',                     '')");

                //a.ExecuteQuery("INSERT INTO `t_fecalysis` (`resultid`, `color`, `ova_parasite`, `consistency`, `red_blood_cells`, `white_blood_cells`, `amoeba`, `others`, `occult_blood`, `repeat_test_id`, `pus_cells`, `mucus`, `result_date`, `color_others`) VALUES ('" + FecalysisID.ToString() + "', '" + Tool.ReplaceString(cbo_color_fecal.Text) + "', '" + Tool.ReplaceString(tx_ova.Text) + "', '" + Tool.ReplaceString(cbo_consistency.Text) + "', '" + Tool.ReplaceString(tx_red_fecal.Text) + "', '" + Tool.ReplaceString(tx_whitBlood_fecal.Text) + "', '" + Tool.ReplaceString(tx_amoeba.Text) + "', '" + Tool.ReplaceString(txt_other_Fecalysis.Text) + "', '" + Tool.ReplaceString(tx_occultBloodTest.Text) + "', '"+FecalysisID.ToString()+"',                      '',        '',     '" + Tool.ReplaceString(dt_resultdate.Text) + "', '" + Tool.ReplaceString(txt_color_other.Text) + "')");

                // var arr = new[] { "INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + FecalysisID.ToString() + "', 'STOOL(repeat)', '" + this.Tag.ToString() + "', '" + dt_resultdate.Text + "', '" + Tool.ReplaceString(Pathologist.Text) + "', 'PENDING',   '',              '',            '" + Tool.ReplaceString(txt_remark.Text) + "',                  '',               '" + Tool.ReplaceString(requestBy.Text) + "',                 '" + Tool.ReplaceString(labNo.Text) + "',               '" + Tool.ReplaceString(MedTech.Text) + "', '" + Tool.ReplaceString(med_licenseNo.Text) + "', '" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "', '" + frm_lab.LabId.Text + "',              '',             '',                  '',            '',             '',                 '',                 '',                     '')", "INSERT INTO `t_fecalysis` (`resultid`, `color`, `ova_parasite`, `consistency`, `red_blood_cells`, `white_blood_cells`, `amoeba`, `others`, `occult_blood`, `repeat_test_id`, `pus_cells`, `mucus`, `result_date`, `color_others`) VALUES ('" + FecalysisID.ToString() + "', '" + Tool.ReplaceString(cbo_color_fecal.Text) + "', '" + Tool.ReplaceString(tx_ova.Text) + "', '" + Tool.ReplaceString(cbo_consistency.Text) + "', '" + Tool.ReplaceString(tx_red_fecal.Text) + "', '" + Tool.ReplaceString(tx_whitBlood_fecal.Text) + "', '" + Tool.ReplaceString(tx_amoeba.Text) + "', '" + Tool.ReplaceString(txt_other_Fecalysis.Text) + "', '" + Tool.ReplaceString(tx_occultBloodTest.Text) + "', '" + FecalysisID.ToString() + "',                      '',        '',     '" + Tool.ReplaceString(dt_resultdate.Text) + "', '" + Tool.ReplaceString(txt_color_other.Text) + "')" };

                //  File.WriteAllLines(ClassSql.tmp_path, arr);

                db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1}, {2}, {3},{4}, {5},   {6},   {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15},  {16}, {17},  {18}, {19},{20}, {21},{22},{23})", FecalysisID.ToString(), "STOOL(repeat)", this.Tag.ToString(), dt_resultdate.Text, Pathologist.Text, "PENDING", "", "", txt_remark.Text, "", requestBy.Text, labNo.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, frm_lab.LabId.Text, "", "", "", "", "", "", "", "");
                db.ExecuteCommand("INSERT INTO t_fecalysis (resultid, color, ova_parasite, consistency, red_blood_cells, white_blood_cells, amoeba, others, occult_blood, repeat_test_id, pus_cells, mucus, result_date, color_others) VALUES ({0},{1}, {2}, {3},{4}, {5},   {6},   {7}, {8}, {9}, {10}, {11}, {12}, {13})", FecalysisID.ToString(), cbo_color_fecal.Text, tx_ova.Text, cbo_consistency.Text, tx_red_fecal.Text, tx_whitBlood_fecal.Text, tx_amoeba.Text, txt_other_Fecalysis.Text, tx_occultBloodTest.Text, FecalysisID.ToString(), "", "", dt_resultdate.Text, txt_color_other.Text);
                Tool.MessageBoxSave();
                load_FecalPreviousList();
                groupBox1.Enabled = false;
                groupBox10.Enabled = false;
                cmd_save.Text = "Edit";
                cmd_new.Enabled = false;
                cmd_print.Enabled = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

        }





        private void frm_repeat_Fecalysis_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //if (ClassSql.cnn.State == ConnectionState.Closed) { ClassSql.DbConnect(); }
            //  Search_Fecalysis();

            if (!backgroundWorker1.IsBusy)
            {
                //Fecal f = new Fecal();
                //f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync();
            }




            Cursor.Current = Cursors.Default;
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {

            if (cmd_save.Text == "&Save")
            {
                Save();
            }
            else if (cmd_save.Text == "Edit")
            {
                cmd_save.Text = "Update";
                groupBox1.Enabled = true;
                groupBox10.Enabled = true;
                cmd_print.Enabled = false;
                groupBox2.Enabled = false;
            }
            else
            {

                Update_Fecalysis();
            }




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

        private void MedTech_TextChanged(object sender, EventArgs e)
        {

            //if (MedTech.Text == "")
            //{ med_licenseNo.Clear(); }
            //else
            //{

            //    ClassSql a = new ClassSql();
            //    a.PutDataTOTextBox("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Name LIKE  '%" + MedTech.Text + "%'", this.med_licenseNo, "License");

            //}



        }

        private void cmd_print_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Report.Report_Lab Print = new Report.Report_Lab();
            //Print.Tag = FecalysisID.ToString();
            //Print.R_Fecal.Select();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = true;
            //Print.load_Fecal();
            //Print.ShowDialog();
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isFecalysis = true;
                f.Tag = FecalysisID.ToString();
                f.age = Age;
                f.PatientName = PatientName;
                f.Sex = Sex;
                f.ResultDate_Fecal = dt_resultdate.Text;
                f.Address = Address;
                f.Position = Position;
                f.ReferredBy = requestBy.Text;
                f.Color = cbo_color_fecal.Text;
                f.WHITeBLOODCELLS = tx_whitBlood_fecal.Text;
                f.Mucus = "";
                f.OVAORPARASITE = tx_ova.Text;
                f.AMOEBA = tx_amoeba.Text;
                f.OCCULTBLOODTEST = tx_occultBloodTest.Text;
                f.Others_fecal = txt_other_Fecalysis.Text;
                f.Medtech = MedTech.Text;
                f.MedTech_lic = med_licenseNo.Text;
                f.Pathologist = Pathologist.Text;
                f.Pathologist_Lic = Pathologist_licenseNo.Text;
                f.SpecimenNo = labNo.Text;
                f.RedBlood = tx_red_fecal.Text;
                f.Color_other = txt_color_other.Text;
                f.CONSISTENCY = cbo_consistency.Text;
                f.ShowDialog();
            }


        }

        private void frm_repeat_Fecalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ClassSql.DbConnect();
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
            Print.Tag = FecalysisID.ToString();
            //Print.R_Fecal.Select();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = true;
            //Print.load_Fecal();
            Print.isFecal = true;
            Print.ShowDialog();
        }

        private void cmd_new_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(groupBox10);
            Tool.ClearFields(groupBox1);
            groupBox1.Enabled = true;
            groupBox10.Enabled = true;
            cmd_save.Enabled = true;
            cmd_print.Enabled = false;
            cmd_save.Text = "&Save";
        }

        public class Fecal
        {
            public string cn, resultid, resultdate, papin;
        }

        void FillDataGridView()
        {
            try
            {
                dt_Fecal = Tool.GetDataSourceFromFile(TableListPath.Repeat_Fecal_List);
                if (dt_Fecal.Rows.Count >= 1)
                {

                    dt_Fecal.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_Fecal.Columns[1], "%");

                    dg_Previous.DataSource = dt_Fecal;
                    dg_Previous.Columns[0].Visible = false;
                    dg_Previous.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dg_Previous.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dt_Fecal.Rows.Count >= 1)
                { cmd_new.Enabled = false; }
                else
                { cmd_new.Enabled = true; }

            }
            catch //(Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

        }


        void load_FecalPreviousList()
        {
            try
            {



                //using (StreamWriter s = File.CreateText(TableListPath.Repeat_Fecal_List))
                //{ s.Close(); }

                // TextWriter sw = new StreamWriter(TableListPath.Repeat_Fecal_List);
                //  ClassSql a = new ClassSql(); DataTable dt;
                // dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.result_date  FROM t_result_main WHERE t_result_main.papin = '"+this.Tag.ToString() +"' AND t_result_main.resulttype = 'STOOL(repeat)'");
                var list = db.sp_RepeatFecalysisList(this.Tag.ToString()).ToList();
                var RowCount = list.Count();
                Cursor.Current = Cursors.WaitCursor;

                //  sw.WriteLine("cn \t resultid \t result_date");
                dg_Previous.Rows.Clear();
                foreach (var i in list)
                {

                    //sw.WriteLine(dr["cn"].ToString() + "\t" + dr["resultid"].ToString() + "\t" + dr["result_date"].ToString());
                    //  sw.WriteLine(dr["cn"].ToString() + "\t" + dr["resultid"].ToString() + "\t" + dr["result_date"].ToString());
                    dg_Previous.Rows.Add(i.cn, i.resultid, i.result_date);
                }
                //  sw.Close();

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
            this.Invoke(new MethodInvoker(delegate() { load_FecalPreviousList(); }));

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (!backgroundWorker1.CancellationPending)
            //{
            //    Fecal f = (Fecal)e.UserState;
            //    this.dg_Previous.Rows.Add(f.cn.ToString(), f.resultid.ToString(), f.resultdate.ToString());

            //}
        }

        void loadPreviousExam()
        {
            //ClassSql a = new ClassSql(); DataTable dt = new DataTable();

            cmd_save.Text = "Edit"; cmd_save.Enabled = true; cmd_print.Enabled = true; cmd_new.Enabled = false;
            // dt = a.Mytable_Proc("Load_Repeat_Fecalysis", "@ID", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
            var i = db.sp_FecalysisData(dg_Previous.SelectedRows[0].Cells[1].Value.ToString()).FirstOrDefault();
            //foreach (var i in list)
            //{
            if (i != null)
            {

                string input = i.result_date.ToString();
                DateTime dtime;
                if (DateTime.TryParse(input, out dtime))
                {
                    dt_resultdate.Text = input;
                }


                FecalysisID = i.resultid.ToString();
                cbo_color_fecal.Text = i.color.ToString();
                cbo_consistency.Text = i.consistency.ToString();
                txt_color_other.Text = i.color_others.ToString();
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

            search_Medical();

            //cmd_print.Enabled = true;


        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (this.dg_Previous.Rows.Count >= 1)
            //{ cmd_new.Enabled = false; }
            //else
            //{ cmd_new.Enabled = true; }
            FillDataGridView();

        }



        private void cmd_refresh_Click(object sender, EventArgs e)
        {
            //Search_Fecalysis();
            //if (this.dg_Previous.Rows.Count >= 1)
            //{ cmd_new.Enabled = false; }
            //else
            //{ cmd_new.Enabled = true; }

            if (!backgroundWorker1.IsBusy)
            {
                //Fecal f = new Fecal();
                //f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
            // FillDataGridView();



        }
        void CreateNew()
        {
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            Tool.ClearFields(groupBox10);
            Tool.ClearFields(groupBox1);
            groupBox1.Enabled = true;
            groupBox10.Enabled = true;
            cmd_save.Enabled = true;
            cmd_print.Enabled = false;
            cmd_save.Text = "&Save";
        }
        private void cmd_new_Click_1(object sender, EventArgs e)
        {
            CreateNew();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //int i = 1;

            //FecalysisID = ClassSql.Generate_ResultID("SELECT t_fecalysis.resultid FROM t_fecalysis WHERE t_fecalysis.resultid LIKE '%STOOL%' ORDER BY t_fecalysis.cn DESC LIMIT 1", "resultid", "STOOL");

            //backgroundWorker2.ReportProgress(i, FecalysisID);
            //i++;

            var list = db.sp_GenerateRepeatFecalysisID();
            foreach (var i in list)
            {
                FecalysisID = i.generated_id;
            }

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker2.CancelAsync();

            }
        }

        private void dg_Previous_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex != 0)
            {
                if (dg_Previous.Rows.Count >= 1)
                {
                    loadPreviousExam();
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void cbo_color_fecal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_color_fecal.Text == "[other]") { txt_color_other.Visible = true; } else { txt_color_other.Visible = false; txt_color_other.Clear(); }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_Previous.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteCommand("Delete from t_result_main where cn= {0}", dg_Previous.SelectedRows[0].Cells[0].Value.ToString());
                    db.ExecuteCommand("Delete from t_fecalysis where resultid = {0}", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
                    load_FecalPreviousList(); CreateNew();
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
