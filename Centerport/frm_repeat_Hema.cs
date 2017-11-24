using Centerport.Class;
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
    public partial class frm_repeat_Hema : Form
    {
        frm_lab flab;

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        public string Age;

        public string HemaID; public int RowsCount;

        public string PatientName;
        public string Address;
        public string Sex;
        public string CivilStatus;
        public string Position;
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        private DataTable dt_Hema;

        public frm_repeat_Hema(frm_lab f_labb)
        {
            InitializeComponent();
            flab = f_labb;
        }

        //public void Search_Hema()
        //     {
        //         try
        //         {

        //             ClassSql a = new ClassSql(); DataTable dt;
        //             dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.result_date  FROM t_result_main WHERE t_result_main.papin = '" + this.Tag.ToString() + "' AND t_result_main.resulttype = 'HEMA(repeat)'");

        //             dg_Previous.Rows.Clear();

        //             foreach (DataRow dr in dt.Rows)
        //             {

        //                 string[] row = new string[] { dr["cn"].ToString(), dr["resultid"].ToString(), dr["result_date"].ToString() };
        //                 dg_Previous.Rows.Add(row);

        //             }



        //         }
        //         catch (Exception ex)
        //         {
        //             MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //         }
        //         finally
        //         {
        //            // if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //             if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //         }


        //     }

        //public void Load_Medical()
        // {

        //     try
        //     {



        //         ClassSql a = new ClassSql(); DataTable dt;

        //         dt = a.Table("SELECT tbl_medical.cn,  tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical");
        //         foreach (DataRow dr in dt.Rows)
        //         {
        //             this.MedTech.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //             this.Pathologist.AutoCompleteCustomSource.Add(dr["Name"].ToString());
        //             this.requestBy.AutoCompleteCustomSource.Add(dr["Name"].ToString());


        //         }



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

        public class Hema
        {
            public string cn, resultid, resultdate, papin;
        }
        private void frm_repeat_Hema_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;



            backgroundWorker1.RunWorkerAsync();
            load_Hema_NormalValues();
            Cursor.Current = Cursors.Default;
        }

        void load_Hema_NormalValues()
        {



            IniFile ini = new IniFile(ClassSql.MMS_Path);
            a.Text = ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl";
            b.Text = ini.IniReadValue("NormalValue", "hematocrit") + "vol%";
            c.Text = ini.IniReadValue("NormalValue", "RBC") + " m/cumm";
            d.Text = ini.IniReadValue("NormalValue", "WBC") + " /cumm";
            e.Text = ini.IniReadValue("NormalValue", "Platelet") + "/cumm";
            label6.Text = ini.IniReadValue("NormalValue", "BloodType");
            ff.Text = ini.IniReadValue("NormalValue", "ESR") + "mm/hr(Male)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(Female)";
            f.Text = ini.IniReadValue("NormalValue", "Lympho") + "%";
            g.Text = ini.IniReadValue("NormalValue", "Segmenters") + "%";
            h.Text = ini.IniReadValue("NormalValue", "Easinophils") + "%";
            ii.Text = ini.IniReadValue("NormalValue", "MonoCytes") + "%";
            label3.Text = ini.IniReadValue("NormalValue", "Myelocytes");
            label4.Text = ini.IniReadValue("NormalValue", "Juveniles");
            j.Text = ini.IniReadValue("NormalValue", "StabCells") + "%";
            k.Text = ini.IniReadValue("NormalValue", "BasoPhils") + "%";
            label5.Text = ini.IniReadValue("NormalValue", "Hema_Other");


        }


        void Save()
        {

            try
            {



                //  var arr = new[] { "INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + HemaID.ToString() + "', 'HEMA(repeat)', '" + this.Tag.ToString() + "', '" + dt_resultdate.Text + "', '" + Tool.ReplaceString(Pathologist.Text) + "', 'PENDING',   "",              '',            '" + Tool.ReplaceString(txt_remark.Text) + "',                  '',               '" + Tool.ReplaceString(requestBy.Text) + "',                 '" + Tool.ReplaceString(labNo.Text) + "',               '" + Tool.ReplaceString(MedTech.Text) + "', '" + Tool.ReplaceString(med_licenseNo.Text) + "', '" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "', '" + frm_lab.LabId.Text + "',              '',             '',                  '',            '',             '',                 '',                 '',                     '')", "INSERT INTO `t_hematology` (`resultid`, `hemoglobin`, `hematocrit`, `rbc_count`, `wbc_count`, `lymphocytes`, `segmenters`, `eosinophils`, `stab_cells`, `basophils`, `monocytes`, `blood_type`, `esr`, `others`, `repeat_test_id`, `myelocytes`, `juveniles`, `platelet`, `result_date`) VALUES ('" + HemaID.ToString() + "', '" + Tool.ReplaceString(hemoglobin.Text) + "', '" + Tool.ReplaceString(hematocrit.Text) + "', '" + Tool.ReplaceString(RBC.Text) + "', '" + Tool.ReplaceString(WBC.Text) + "', '" + Tool.ReplaceString(Lympho.Text) + "', '" + Tool.ReplaceString(Segmenters.Text) + "', '" + Tool.ReplaceString(Easinophils.Text) + "', '" + Tool.ReplaceString(StabCells.Text) + "', '" + Tool.ReplaceString(BasoPhils.Text) + "', '" + Tool.ReplaceString(MonoCytes.Text) + "', '" + Tool.ReplaceString(BloodType.Text) + "', '" + Tool.ReplaceString(ESR.Text) + "', '" + Tool.ReplaceString(Hema_Other.Text) + "', '" + HemaID.ToString() + "',           '" + Tool.ReplaceString(Myelocytes.Text) + "', '" + Tool.ReplaceString(Juveniles.Text) + "', '" + Tool.ReplaceString(Platelet.Text) + "', '" + Tool.ReplaceString(dt_resultdate.Text) + "')" };
                //  File.WriteAllLines(ClassSql.tmp_path, arr);
                db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", HemaID.ToString(), "HEMA(repeat)", this.Tag.ToString(), dt_resultdate.Text, Tool.ReplaceString(Pathologist.Text), "PENDING", "", "", Tool.ReplaceString(txt_remark.Text), "", Tool.ReplaceString(requestBy.Text), Tool.ReplaceString(labNo.Text), Tool.ReplaceString(MedTech.Text), Tool.ReplaceString(med_licenseNo.Text), Tool.ReplaceString(Pathologist_licenseNo.Text), frm_lab.LabId.Text, "", "", "", "", "", "", "", "");
                db.ExecuteCommand("INSERT INTO t_hematology (resultid, hemoglobin, hematocrit, rbc_count, wbc_count, lymphocytes, segmenters, eosinophils, stab_cells, basophils, monocytes, blood_type, esr, others, repeat_test_id, myelocytes, juveniles, platelet, result_date) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18})", HemaID.ToString(), hemoglobin.Text, hematocrit.Text, RBC.Text, WBC.Text, Lympho.Text, Segmenters.Text, Easinophils.Text, StabCells.Text, BasoPhils.Text, MonoCytes.Text, BloodType.Text, ESR.Text, Hema_Other.Text, HemaID.ToString(), Myelocytes.Text, Juveniles.Text, Platelet.Text, dt_resultdate.Text);
                // "INSERT INTO `t_hematology` (`resultid`, `hemoglobin`, `hematocrit`, `rbc_count`, `wbc_count`, `lymphocytes`, `segmenters`, `eosinophils`, `stab_cells`, `basophils`, `monocytes`, `blood_type`, `esr`, `others`, `repeat_test_id`, `myelocytes`, `juveniles`, `platelet`, `result_date`) VALUES ('" + HemaID.ToString() + "', '" + Tool.ReplaceString(hemoglobin.Text) + "', '" + Tool.ReplaceString(hematocrit.Text) + "', '" + Tool.ReplaceString(RBC.Text) + "', '" + Tool.ReplaceString(WBC.Text) + "', '" + Tool.ReplaceString(Lympho.Text) + "', '" + Tool.ReplaceString(Segmenters.Text) + "', '" + Tool.ReplaceString(Easinophils.Text) + "', '" + Tool.ReplaceString(StabCells.Text) + "', '" + Tool.ReplaceString(BasoPhils.Text) + "', '" + Tool.ReplaceString(MonoCytes.Text) + "', '" + Tool.ReplaceString(BloodType.Text) + "', '" + Tool.ReplaceString(ESR.Text) + "', '" + Tool.ReplaceString(Hema_Other.Text) + "', '" + HemaID.ToString() + "',           '" + Tool.ReplaceString(Myelocytes.Text) + "', '" + Tool.ReplaceString(Juveniles.Text) + "', '" + Tool.ReplaceString(Platelet.Text) + "', '" + Tool.ReplaceString(dt_resultdate.Text) + "')");

                Tool.MessageBoxSave();
                loadData();

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                cmd_save.Text = "Edit";
                cmdNew.Enabled = false;
                cmd_print.Enabled = true;

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


                var i = db.sp_hema_resultMain(dg_Previous.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
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

                    MedTech.Text = i.medtech.ToString();
                    Pathologist.Text = i.pathologist.ToString();
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


        public void Update_hema()
        {
            try
            {

                // var qry = new[] { "UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `medtech`='" + Tool.ReplaceString(MedTech.Text) + "', `medtech_license`='" + Tool.ReplaceString(med_licenseNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "',`pathologist`='" + Tool.ReplaceString(Pathologist.Text) + "',`specimen_no`='" + Tool.ReplaceString(labNo.Text) + "' , `repeat_test_requestby`='" + Tool.ReplaceString(requestBy.Text) + "', `remarks` = '" + Tool.ReplaceString(txt_remark.Text) + "'WHERE (`resultid`='" + HemaID.ToString() + "') LIMIT 1", "UPDATE `t_hematology` SET `hemoglobin`='" + Tool.ReplaceString(hemoglobin.Text) + "', `hematocrit`='" + Tool.ReplaceString(this.hematocrit.Text) + "', `rbc_count`='" + Tool.ReplaceString(this.RBC.Text) + "', `wbc_count`='" + Tool.ReplaceString(this.WBC.Text) + "', `lymphocytes`='" + Tool.ReplaceString(this.Lympho.Text) + "', `segmenters`='" + Tool.ReplaceString(this.Segmenters.Text) + "', `eosinophils`='" + Tool.ReplaceString(this.Easinophils.Text) + "', `stab_cells`='" + Tool.ReplaceString(this.StabCells.Text) + "', `basophils`='" + Tool.ReplaceString(this.BasoPhils.Text) + "', `monocytes`='" + Tool.ReplaceString(this.MonoCytes.Text) + "', `blood_type`='" + Tool.ReplaceString(this.BloodType.Text) + "', `esr`='" + Tool.ReplaceString(this.ESR.Text) + "', `others`='" + Tool.ReplaceString(this.Hema_Other.Text) + "', `myelocytes`='" + Tool.ReplaceString(this.Myelocytes.Text) + "', `juveniles`='" + Tool.ReplaceString(this.Juveniles.Text) + "', `platelet`='" + Tool.ReplaceString(this.Platelet.Text) + "', `result_date`='" + Tool.ReplaceString(this.dt_resultdate.Text) + "' WHERE (`resultid`='" + HemaID.ToString() + "') LIMIT 1" };
                db.ExecuteCommand("UPDATE t_result_main SET result_date= {0}, medtech={1}, medtech_license={2},pathologist_license={3},pathologist={4},specimen_no={5} , repeat_test_requestby={6}, remarks = {7} WHERE (resultid={8})", dt_resultdate.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, Pathologist.Text, labNo.Text, requestBy.Text, txt_remark.Text, HemaID.ToString());
                db.ExecuteCommand("UPDATE t_hematology SET hemoglobin={0}, hematocrit={1},      rbc_count={2}, wbc_count={3}, lymphocytes={4}, segmenters={5},    eosinophils={6},    stab_cells={7},     basophils={8},     monocytes={9},    blood_type={10},   esr={11},    others={12},      myelocytes={13}, juveniles={14},    platelet={15},     result_date={16}  WHERE (resultid={17})", hemoglobin.Text, this.hematocrit.Text, RBC.Text, this.WBC.Text, this.Lympho.Text, this.Segmenters.Text, this.Easinophils.Text, this.StabCells.Text, this.BasoPhils.Text, this.MonoCytes.Text, this.BloodType.Text, this.ESR.Text, this.Hema_Other.Text, this.Myelocytes.Text, this.Juveniles.Text, this.Platelet.Text, this.dt_resultdate.Text, HemaID.ToString());
                // File.WriteAllLines(ClassSql.tmp_path,qry);           
                // MessageBox.Show(string.Format("UPDATE t_result_main SET result_date= {0}, medtech={1}, medtech_license={2},pathologist_license={3},pathologist={4},specimen_no={5} , repeat_test_requestby={6}, remarks = {7} WHERE (resultid={8})", dt_resultdate.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, Pathologist.Text, labNo.Text, requestBy.Text, txt_remark.Text, HemaID.ToString()));
                //MessageBox.Show(string.Format("UPDATE t_hematology SET hemoglobin={0}, hematocrit={1},      rbc_count={2}, wbc_count={3}, lymphocytes={4}, segmenters={5},    eosinophils={6},    stab_cells={7},     basophils={8},     monocytes={9},    blood_type={10},   esr={11},    others={12},      myelocytes={13}, juveniles={14},    platelet={15},     result_date={16}  WHERE (resultid={17})", hemoglobin.Text, this.hematocrit.Text, RBC.Text, this.WBC.Text, this.Lympho.Text, this.Segmenters.Text, this.Easinophils.Text, this.StabCells.Text, this.BasoPhils.Text, this.MonoCytes.Text, this.BloodType.Text, this.ESR.Text, this.Hema_Other.Text, this.Myelocytes.Text, this.Juveniles.Text, this.Platelet.Text, this.dt_resultdate.Text, HemaID.ToString()));
                Tool.MessageBoxUpdate();
                loadData();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                cmd_save.Enabled = true;
                cmd_print.Enabled = true;
                this.groupBox3.Enabled = true;
                cmd_save.Text = "Edit";



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                this.groupBox2.Enabled = true;
                cmd_print.Enabled = false;
                this.groupBox3.Enabled = false;
            }
            else
            {
                Update_hema();
            }



        }




        private void MedTech_TextChanged(object sender, EventArgs e)
        {
            //if (MedTech.Text == "")
            //{ med_licenseNo.Clear(); }
            //else
            //{

            //    ClassSql a = new ClassSql();
            //    a.PutDataTOTextBox("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Name LIKE  '" + MedTech.Text + "%'", this.med_licenseNo, "License");


            //}


        }

        private void Pathologist_TextChanged(object sender, EventArgs e)
        {
            //if (Pathologist.Text == "")
            //{ Pathologist_licenseNo.Clear(); }
            //else
            //{

            //    ClassSql a = new ClassSql();
            //    a.PutDataTOTextBox("SELECT tbl_medical.cn, tbl_medical.Name, tbl_medical.License, tbl_medical.Type FROM tbl_medical WHERE tbl_medical.Name like  '" + Pathologist.Text + "%'", this.Pathologist_licenseNo, "License");

            //}

        }

        private void dt_resultdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ClassSql a = new ClassSql(); DataTable dt;
            //int RowsCount = a.CountColumn("SELECT t_result_main.resultid, t_result_main.resulttype, t_result_main.papin  FROM t_result_main WHERE t_result_main.papin = '" + this.Tag.ToString() + "' AND t_result_main.resulttype = 'HEMA'");
            //this.Text = RowsCount.ToString();
            //Search_Hema();
        }

        private void cmd_print_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isHEMA = true;
                f.Tag = HemaID.ToString();
                f.age = Age;
                f.PatientName = PatientName;
                f.Address = Address;
                f.resultDate = dt_resultdate.Text;
                f.Sex = Sex;
                f.Position = Position;
                f.ReferredBy = requestBy.Text;
                f.CivilStatus = CivilStatus;
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
                f.Others_ = Hema_Other.Text;
                f.Medtech = MedTech.Text;
                f.MedTech_lic = med_licenseNo.Text;
                f.Pathologist = Pathologist.Text;
                f.Pathologist_Lic = Pathologist_licenseNo.Text;
                f.ShowDialog();
            }

        }

        private void frm_repeat_Hema_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ClassSql.DbConnect();
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
            Print.Tag = HemaID.ToString();
            //Print.R_Hema.Select();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = true; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = false;
            //Print.LoadHema();
            Print.isHema = true;
            Print.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public List<Repeat_hema_Model> Repeat_hema_model = new List<Repeat_hema_Model>();
        void loadData()
        {
            try
            {

                var lists = db.Repeat_hema(this.Tag.ToString()).ToList();
                Cursor.Current = Cursors.WaitCursor;
                dg_Previous.Rows.Clear();
                foreach (var i in lists)
                {
                    //Repeat_hema_model.Add(new Repeat_hema_Model
                    //{
                    //    cn = i.cn,
                    //    resultID = i.resultid.ToString(),
                    //    resultDate = i.result_date.ToString()
                    //});

                    dg_Previous.Rows.Add(i.cn, i.resultid, i.result_date);

                }
                if (lists.Count() >= 1)
                { cmdNew.Enabled = false; }
                else
                { cmdNew.Enabled = true; }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {



            this.Invoke(new MethodInvoker(delegate() { loadData(); }));




        }

        void FillDataGridView()
        {
            try
            {

                var lists = Repeat_hema_model;
                var RowCount = lists.Count();

                dg_Previous.DataSource = lists;
                dg_Previous.Columns[0].Visible = false;
                dg_Previous.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg_Previous.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (RowCount >= 1)
                { cmdNew.Enabled = false; }
                else
                { cmdNew.Enabled = true; }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (!backgroundWorker1.CancellationPending)
            //{
            //    Hema f = (Hema)e.UserState;
            //    this.dg_Previous.Rows.Add(f.cn.ToString(), f.resultid.ToString(), f.resultdate.ToString());

            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // FillDataGridView();
        }

        void loadPreviousExam()
        {
            //ClassSql a = new ClassSql(); DataTable dt = new DataTable();

            cmd_save.Text = "Edit"; cmd_save.Enabled = true; cmd_print.Enabled = true; cmdNew.Enabled = false;
            // dt = a.Mytable_Proc("Load_Repeat_Hema", "@ID", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
            var i = db.sp_repeat_hema(dg_Previous.SelectedRows[0].Cells[1].Value.ToString()).FirstOrDefault();
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

                //dt_resultdate.Text = dr["result_date"].ToString();
                HemaID = i.resultid.ToString();
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
            }
            //}
            search_Medical();

            //cmd_print.Enabled = true;


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

        private void cmd_refresh_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                Hema f = new Hema();
                f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync(f);
            }

        }

        private void cmd_new_Click(object sender, EventArgs e)
        {
            Tool.ClearFields(groupBox1);
            Tool.ClearFields(groupBox2);
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            cmd_save.Enabled = true;
            cmd_print.Enabled = false;
            cmd_save.Text = "&Save";
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = db.sp_hema();
            foreach (var i in list)
            {
                HemaID = i.generated_id;
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker2.CancelAsync();

            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            CreateNew();

        }

        void CreateNew()
        {
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            Tool.ClearFields(groupBox2);
            Tool.ClearFields(groupBox1);
            groupBox2.Enabled = true;
            groupBox1.Enabled = true;
            cmd_save.Enabled = true;
            cmd_print.Enabled = false;
            cmd_save.Text = "&Save";

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_Previous.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteCommand("Delete from t_result_main where cn= {0}", dg_Previous.SelectedRows[0].Cells[0].Value.ToString());
                    db.ExecuteCommand("Delete from t_hematology where resultid= {0}", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
                    loadData();
                    CreateNew();
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
