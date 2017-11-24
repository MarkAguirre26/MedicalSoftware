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
    public partial class frm_repeat_Urninalysis : Form
    {
        frm_lab flab; public int RowsCount; private string UrineID;

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
        private DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        private DataTable dt_Urine;
        public frm_repeat_Urninalysis(frm_lab fflab)
        {
            InitializeComponent();
            flab = fflab;
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

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Urine
        {
            public string cn, resultid, resultdate, papin;
        }

        private void frm_repeat_Urninalysis_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            //if (ClassSql.cnn == null) { ClassSql.DbConnect(); }
            //if (ClassSql.cnn.State == ConnectionState.Closed) { ClassSql.DbConnect(); }

            //  Search_Urinalysis();
            //   Load_Medical();
            if (!backgroundWorker1.IsBusy)
            {
                //Urine f = new Urine();
                //f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync();
            }






            Cursor.Current = Cursors.Default;
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



                //   MessageBox.Show(UrineID.ToString());
                //     ClassSql a = new ClassSql();                                                                                                                                                                                                                                                                                                                                                                                                                                  // resultid`,              `resulttype`,       `papin`,                   `result_date`,                           `pathologist`,                 `status`, `fitness_date`, `valid_until`,                 `remarks`,                                 `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`
                //a.ExecuteQuery("INSERT INTO `t_result_main` (`resultid`, `resulttype`, `papin`, `result_date`, `pathologist`, `status`, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + UrineID.ToString() + "', 'URINE(repeat)', '" + this.Tag.ToString() + "', '" + dt_resultdate.Text + "', '" + Tool.ReplaceString(Pathologist.Text) + "', 'PENDING',   '',              '',            '"+Tool.ReplaceString(txt_remark.Text)+"',                  '',               '"+Tool.ReplaceString(requestBy.Text)+"',                 '" + Tool.ReplaceString(labNo.Text) + "',               '" + Tool.ReplaceString(MedTech.Text) + "', '" + Tool.ReplaceString(med_licenseNo.Text) + "', '" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "', '" + frm_lab.LabId.Text + "',              '',             '',                  '',            '',             '',                 '',                 '',                     '')");
                //resultid`,                                            `color`,                                   `transparency`,             `reaction`,                  `specific_gravity`,                                `sugar`,                        `albumin`,              `blood`,                        `fine_granular`,                                `coarse_granular`,           `hyaline`,  `waxy`, `rbc`, `pus`, `mixed`,                     `red_blood_cells`,                               `white_blood_cells`,                           `calcium_oxalate`,                           `uric_acid`,                    `triple_phosphate`, `others_crystals`,                                          `amorphous_urates`,                             `amorphous_phosphates`,                        `epithelial_cells`,                  `renal_cells`, `bacteria`,              `mucus_threads`,                               `color_remarks`,                            `others_specified`,     `repeat_test_id`,                           `urine_bile`, `others_chem`,   `leukocytes`,        `yeast_cells`,                           `squamous`,             `result_date`,                          `nitrite`,                 `urobilinogen`,             `protein`,                   `ph`,                  `ketone`,                       `bilirubin`,              `microscopic_others`, `cast_others`
                //a.ExecuteQuery("INSERT INTO `t_urinalysis` (`resultid`, `color`, `transparency`, `reaction`, `specific_gravity`, `sugar`, `albumin`, `blood`, `fine_granular`, `coarse_granular`, `hyaline`, `waxy`, `rbc`, `pus`, `mixed`, `red_blood_cells`, `white_blood_cells`, `calcium_oxalate`, `uric_acid`, `triple_phosphate`, `others_crystals`, `amorphous_urates`, `amorphous_phosphates`, `epithelial_cells`, `renal_cells`, `bacteria`, `mucus_threads`, `color_remarks`, `others_specified`, `repeat_test_id`, `urine_bile`, `others_chem`, `leukocytes`, `yeast_cells`, `squamous`, `result_date`, `nitrite`, `urobilinogen`, `protein`, `ph`, `ketone`, `bilirubin`, `microscopic_others`, `cast_others`) VALUES ('" + UrineID.ToString() + "', '" + Tool.ReplaceString(cbo_color.Text) + "', '" + Tool.ReplaceString(cbo_transparency.Text) + "',   '',               '" + Tool.ReplaceString(cbo_spec.Text) + "', '" + Tool.ReplaceString(cbo_glucose.Text) + "',    '',         '" + cbo_blood.Text + "', '" + Tool.ReplaceString(tx_Granular.Text) + "', '" + Tool.ReplaceString(tx_coarse.Text) + "', '',        '',   '',     '',   '',         '" + Tool.ReplaceString(txt_redBlood.Text) + "', '" + Tool.ReplaceString(tx_whiteBlood.Text) + "', '" + Tool.ReplaceString(tx_caium.Text) + "', '" + Tool.ReplaceString(tx_uric_crystal.Text) + "', '',      '" + Tool.ReplaceString(tx_other_Crystals.Text) + "', '" + Tool.ReplaceString(tx_urates.Text) + "', '" + Tool.ReplaceString(tx_phosphate.Text) + "', '" + Tool.ReplaceString(this.tx_cells.Text) + "', '',               '',         '" + Tool.ReplaceString(tx_musus.Text) + "', '" + Tool.ReplaceString(tx_color_other.Text) + "',        '',             '" + UrineID.ToString() + "',                      '',          '',         '" + cbo_leu.Text + "',    '',                                        '',  '" + Tool.ReplaceString(dt_resultdate.Text) + "',  '" + cbo_nitrite.Text + "', '" + cbo_uro.Text + "', '" + cbo_protein.Text + "', '" + cbo_ph.Text + "',      '" + cbo_keton .Text+ "','" + cbo_bili.Text + "', '" + Tool.ReplaceString(tx_other_micro.Text) + "', '" + Tool.ReplaceString(tx_other_cast.Text) + "')");

                //  var arr = new[] { "INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, `fitness_date`, `valid_until`, `remarks`, `recommendation`, `repeat_test_requestby`, `specimen_no`, `medtech`, `medtech_license`, `pathologist_license`, `reference_no`, `restriction`, `basic_doh_exam`, `add_lab_tests`, `flag_medlab_req`, `deck_srvc_flag`, `engine_srvc_flag`, `catering_srvc_flag`, `other_srvc_flag`) VALUES ('" + UrineID.ToString() + "', 'URINE(repeat)', '" + this.Tag.ToString() + "', '" + dt_resultdate.Text + "', '" + Tool.ReplaceString(Pathologist.Text) + "', 'PENDING',   '',              '',            '" + Tool.ReplaceString(txt_remark.Text) + "',                  '',               '" + Tool.ReplaceString(requestBy.Text) + "',                 '" + Tool.ReplaceString(labNo.Text) + "',               '" + Tool.ReplaceString(MedTech.Text) + "', '" + Tool.ReplaceString(med_licenseNo.Text) + "', '" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "', '" + frm_lab.LabId.Text + "',              '',             '',                  '',            '',             '',                 '',                 '',                     '')", "" };

                db.ExecuteCommand("INSERT INTO t_result_main (resultid, resulttype, papin, result_date, pathologist, status, fitness_date, valid_until, remarks, recommendation, repeat_test_requestby, specimen_no, medtech, medtech_license, pathologist_license, reference_no, restriction, basic_doh_exam, add_lab_tests, flag_medlab_req, deck_srvc_flag, engine_srvc_flag, catering_srvc_flag, other_srvc_flag) VALUES ({0},{1}, {2}, {3},{4}, {5},   {6},   {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15},  {16}, {17},  {18}, {19},{20}, {21},{22},{23})", UrineID.ToString(), "URINE(repeat)", this.Tag.ToString(), dt_resultdate.Text, Pathologist.Text, "PENDING", "", "", txt_remark.Text, "", requestBy.Text, labNo.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, frm_lab.LabId.Text, "", "", "", "", "", "", "", "HERE");
                db.ExecuteCommand("INSERT INTO t_urinalysis (resultid, color, transparency, reaction, specific_gravity, sugar, albumin, blood, fine_granular, coarse_granular, hyaline, waxy, rbc, pus, mixed, red_blood_cells, white_blood_cells, calcium_oxalate, uric_acid, triple_phosphate, others_crystals, amorphous_urates, amorphous_phosphates, epithelial_cells, renal_cells, bacteria, mucus_threads, color_remarks, others_specified, repeat_test_id, urine_bile, others_chem, leukocytes, yeast_cells, squamous, result_date, nitrite, urobilinogen, protein, ph, ketone, bilirubin, microscopic_others, cast_others) VALUES ({0},                   {1},            {2},                 {3},          {4},        {5},            {6},    {7},           {8},                {9},          {10},     {11},   {12},  {13}, {14},          {15},                 {16},                 {17},           {18},      {19},         {20},                       {21},              {22},        {23},         {24},            {25},             {26},            {27},               {28},                 {29},            {30},            {31},           {32},        {33},        {34},       {35},           {36},             {37},            {38},            {39},             {40}              ,{41},               {42},              {43})", UrineID.ToString(), cbo_color.Text, cbo_transparency.Text, "", cbo_spec.Text, cbo_glucose.Text, "", cbo_blood.Text, tx_Granular.Text, tx_coarse.Text, "", "", "", "", "", txt_redBlood.Text, tx_whiteBlood.Text, tx_caium.Text, tx_uric_crystal.Text, "", tx_other_Crystals.Text, tx_urates.Text, tx_phosphate.Text, this.tx_cells.Text, "", "", tx_musus.Text, tx_color_other.Text, "", UrineID.ToString(), "", "", cbo_leu.Text, "", "", dt_resultdate.Text, cbo_nitrite.Text, cbo_uro.Text, cbo_protein.Text, cbo_ph.Text, cbo_keton.Text, cbo_bili.Text, tx_other_micro.Text, tx_other_cast.Text);
                // File.WriteAllLines(ClassSql.tmp_path, arr);

                Tool.MessageBoxSave();
                LoadPreviousList();
                groupBox1.Enabled = false;
                groupBox4.Enabled = false;
                cmd_save.Text = "Edit";
                cmd_new.Enabled = false;
                cmd_print.Enabled = true;




                //Search_Urinalysis();


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


                //ClassSql a = new ClassSql(); DataTable dt;

                //  dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.medtech, t_result_main.pathologist, t_result_main.specimen_no, t_result_main.medtech_license, t_result_main.pathologist_license, t_result_main.result_date, t_result_main.repeat_test_requestby, t_result_main.remarks FROM t_result_main WHERE  t_result_main.cn =  '" + dg_Previous.SelectedRows[0].Cells[0].Value.ToString() + "'");
                var i = db.sp_UrinalysisMedical(dg_Previous.SelectedRows[0].Cells[0].Value.ToString()).FirstOrDefault();
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
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //}

        }



        //public void Search_Urinalysis()
        //{
        //    try
        //    {

        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table("SELECT t_result_main.cn,t_result_main.resultid, t_result_main.result_date FROM t_result_main WHERE t_result_main.papin = '" + this.Tag.ToString() + "' AND t_result_main.resulttype = 'URINE(repeat)'");

        //       this.dg_Previous.Rows.Clear();
        //        foreach (DataRow dr in dt.Rows)
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
        //        //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }

        //}

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
                groupBox4.Enabled = true;
                cmd_print.Enabled = false;
                gb_Previous.Enabled = false;
            }
            else
            { Update_Urin(); }




        }
        public void Update_Urin()
        {
            try
            {

                //ClassSql a = new ClassSql();
                //a.ExecuteQuery("UPDATE `t_result_main` SET `result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `medtech`='" + Tool.ReplaceString(MedTech.Text) + "', `medtech_license`='" + Tool.ReplaceString(med_licenseNo.Text) + "',`pathologist_license`='" + Tool.ReplaceString(Pathologist_licenseNo.Text) + "',`pathologist`='" + Tool.ReplaceString(Pathologist.Text) + "',`specimen_no`='" + Tool.ReplaceString(labNo.Text) + "' , `repeat_test_requestby`='" + Tool.ReplaceString(requestBy.Text) + "', `remarks` = '" + Tool.ReplaceString(txt_remark.Text) + "' WHERE (`resultid`='" + UrineID.ToString() + "') LIMIT 1");
                //a.ExecuteQuery("UPDATE `t_urinalysis` SET  `color`='" + Tool.ReplaceString(cbo_color.Text) + "', `transparency`='" + Tool.ReplaceString(cbo_transparency.Text) + "', `specific_gravity`='" + Tool.ReplaceString(this.cbo_spec.Text) + "', `sugar`='" + Tool.ReplaceString(cbo_glucose.Text) + "', `blood`='" + Tool.ReplaceString(cbo_blood.Text) + "', `fine_granular`='" + Tool.ReplaceString(tx_Granular.Text) + "', `coarse_granular`='" + Tool.ReplaceString(tx_coarse.Text) + "',`red_blood_cells`='" + Tool.ReplaceString(txt_redBlood.Text) + "', `white_blood_cells`='" + Tool.ReplaceString(tx_whiteBlood.Text) + "', `calcium_oxalate`='" + Tool.ReplaceString(tx_caium.Text) + "', `uric_acid`='" + Tool.ReplaceString(tx_uric_crystal.Text) + "',  `others_crystals`='" + Tool.ReplaceString(tx_other_Crystals.Text) + "', `amorphous_urates`='" + Tool.ReplaceString(this.tx_urates.Text) + "', `amorphous_phosphates`='" + Tool.ReplaceString(this.tx_phosphate.Text) + "', `epithelial_cells`='" + Tool.ReplaceString(tx_cells.Text) + "', `mucus_threads`='" + Tool.ReplaceString(tx_musus.Text) + "', `color_remarks`='" + Tool.ReplaceString(tx_color_other.Text) + "', `others_specified`="", `repeat_test_id`='" + Tool.ReplaceString(this.Tag.ToString()) + "',  `leukocytes`='" + Tool.ReplaceString(cbo_leu.Text) + "',`result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `nitrite`='" + Tool.ReplaceString(cbo_nitrite.Text) + "', `urobilinogen`='" + Tool.ReplaceString(cbo_uro.Text) + "', `protein`='" + Tool.ReplaceString(cbo_protein.Text) + "', `ph`='" + Tool.ReplaceString(cbo_ph.Text) + "', `ketone`='" + Tool.ReplaceString(cbo_keton.Text) + "', `bilirubin`='" + Tool.ReplaceString(cbo_bili.Text) + "', `microscopic_others`='" + Tool.ReplaceString(tx_other_micro.Text) + "', `cast_others`='"+Tool.ReplaceString(tx_other_cast.Text )+"' WHERE (`resultid`='" + UrineID.ToString() + "') LIMIT 1");

                // var arr = new[] { "UPDATE `t_result_main` SET `result_date`={0}, `medtech`={1}, `medtech_license`={2},`pathologist_license`={3},`pathologist`={4},`specimen_no`={5} , `repeat_test_requestby`={6}, `remarks` = {7} WHERE (`resultid`={8}", "UPDATE `t_urinalysis` SET  `color`='" + Tool.ReplaceString(cbo_color.Text) + "', `transparency`='" + Tool.ReplaceString(cbo_transparency.Text) + "', `specific_gravity`='" + Tool.ReplaceString(this.cbo_spec.Text) + "', `sugar`='" + Tool.ReplaceString(cbo_glucose.Text) + "', `blood`='" + Tool.ReplaceString(cbo_blood.Text) + "', `fine_granular`='" + Tool.ReplaceString(tx_Granular.Text) + "', `coarse_granular`='" + Tool.ReplaceString(tx_coarse.Text) + "',`red_blood_cells`='" + Tool.ReplaceString(txt_redBlood.Text) + "', `white_blood_cells`='" + Tool.ReplaceString(tx_whiteBlood.Text) + "', `calcium_oxalate`='" + Tool.ReplaceString(tx_caium.Text) + "', `uric_acid`='" + Tool.ReplaceString(tx_uric_crystal.Text) + "',  `others_crystals`='" + Tool.ReplaceString(tx_other_Crystals.Text) + "', `amorphous_urates`='" + Tool.ReplaceString(this.tx_urates.Text) + "', `amorphous_phosphates`='" + Tool.ReplaceString(this.tx_phosphate.Text) + "', `epithelial_cells`='" + Tool.ReplaceString(tx_cells.Text) + "', `mucus_threads`='" + Tool.ReplaceString(tx_musus.Text) + "', `color_remarks`='" + Tool.ReplaceString(tx_color_other.Text) + "', `others_specified`='', `repeat_test_id`='" + Tool.ReplaceString(this.Tag.ToString()) + "',  `leukocytes`='" + Tool.ReplaceString(cbo_leu.Text) + "',`result_date`='" + Tool.ReplaceString(dt_resultdate.Text) + "', `nitrite`='" + Tool.ReplaceString(cbo_nitrite.Text) + "', `urobilinogen`='" + Tool.ReplaceString(cbo_uro.Text) + "', `protein`='" + Tool.ReplaceString(cbo_protein.Text) + "', `ph`='" + Tool.ReplaceString(cbo_ph.Text) + "', `ketone`='" + Tool.ReplaceString(cbo_keton.Text) + "', `bilirubin`='" + Tool.ReplaceString(cbo_bili.Text) + "', `microscopic_others`='" + Tool.ReplaceString(tx_other_micro.Text) + "', `cast_others`='" + Tool.ReplaceString(tx_other_cast.Text) + "' WHERE (`resultid`='" + UrineID.ToString() + "') LIMIT 1" };
                // File.WriteAllLines(ClassSql.tmp_path, arr);      
                db.ExecuteCommand("UPDATE t_result_main SET result_date={0}, medtech={1}, medtech_license={2},pathologist_license={3},pathologist={4},specimen_no={5} , repeat_test_requestby={6}, remarks = {7} WHERE (resultid={8})", dt_resultdate.Text, MedTech.Text, med_licenseNo.Text, Pathologist_licenseNo.Text, Pathologist.Text, labNo.Text, requestBy.Text, txt_remark.Text, UrineID.ToString());

                db.ExecuteCommand("UPDATE t_urinalysis SET  color={0}, transparency={1}, specific_gravity={2}, sugar={3}, blood={4}, fine_granular={5}, coarse_granular={6},red_blood_cells={7}, white_blood_cells={8}, calcium_oxalate={9}, uric_acid={10},  others_crystals={11}, amorphous_urates={12}, amorphous_phosphates={13}, epithelial_cells={14}, mucus_threads={15}, color_remarks={16}, others_specified={17}, repeat_test_id={18},  leukocytes={19},result_date={20}, nitrite={21}, urobilinogen={22}, protein={23}, ph={24}, ketone={25}, bilirubin={26}, microscopic_others={27}, cast_others={28} WHERE (resultid={29})", cbo_color.Text, cbo_transparency.Text, cbo_spec.Text, cbo_glucose.Text, cbo_blood.Text, tx_Granular.Text, tx_coarse.Text, txt_redBlood.Text, tx_whiteBlood.Text, tx_caium.Text, tx_uric_crystal.Text, tx_other_Crystals.Text, this.tx_urates.Text, this.tx_phosphate.Text, tx_cells.Text, tx_musus.Text, tx_color_other.Text, "", this.Tag.ToString(), cbo_leu.Text, dt_resultdate.Text, cbo_nitrite.Text, cbo_uro.Text, cbo_protein.Text, cbo_ph.Text, cbo_keton.Text, cbo_bili.Text, tx_other_micro.Text, tx_other_cast.Text, UrineID.ToString());
                // MessageBox.Show(string.Format("UPDATE t_urinalysis SET  color={0}, transparency={1}, specific_gravity={2}, sugar={3}, blood={4}, fine_granular={5}, coarse_granular={6},red_blood_cells={7}, white_blood_cells={8}, calcium_oxalate={9}, uric_acid={10},  others_crystals={11}, amorphous_urates={12}, amorphous_phosphates={13}, epithelial_cells={14}, mucus_threads={15}, color_remarks={16}, others_specified={17}, repeat_test_id={18},  leukocytes={19},result_date={20}, nitrite={21}, urobilinogen={22}, protein={23}, ph={24}, ketone={25}, bilirubin={26}, microscopic_others={27}, cast_others={28} WHERE (resultid={29})", cbo_color.Text, cbo_transparency.Text, cbo_spec.Text, cbo_glucose.Text, cbo_blood.Text, tx_Granular.Text, tx_coarse.Text, txt_redBlood.Text, tx_whiteBlood.Text, tx_caium.Text, tx_uric_crystal.Text, tx_other_Crystals.Text, this.tx_urates.Text, this.tx_phosphate.Text, tx_cells.Text, tx_musus.Text, tx_color_other.Text, "", this.Tag.ToString(), cbo_leu.Text, dt_resultdate.Text, cbo_nitrite.Text, cbo_uro.Text, cbo_protein.Text, cbo_ph.Text, cbo_keton.Text, cbo_bili.Text, tx_other_micro.Text, tx_other_cast.Text, UrineID.ToString()));  
                Tool.MessageBoxUpdate();
                LoadPreviousList();
                groupBox1.Enabled = false;
                groupBox4.Enabled = false;
                cmd_save.Enabled = true;
                cmd_print.Enabled = true;
                gb_Previous.Enabled = true;
                cmd_save.Text = "Edit";

                //ClassSql.DbConnect();
                //Search_Urinalysis();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



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

        private void cmd_print_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Report.Report_Lab Print = new Report.Report_Lab();
            //Print.Tag = UrineID.ToString();
            //Print.R_Urine.ToString();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = true; Print.R_Fecal.Enabled = false;
            //Print.Load_Urine();
            //Print.ShowDialog();

            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isUrinalysis = true;
                f.Tag = UrineID.ToString();
                f.age = Age;
                f.PatientName = PatientName;
                f.Sex = Sex;
                f.resultdate_Urinalysis = dt_resultdate.Text;
                f.Address = Address;
                f.Position = Position;
                f.ReferredBy = requestBy.Text;
                f.COLOR_Urnialysis = cbo_color.Text;
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
                f.Medtech = MedTech.Text;
                f.MedTech_lic = med_licenseNo.Text;
                f.Pathologist = Pathologist.Text;
                f.Pathologist_Lic = Pathologist_licenseNo.Text;
                f.SpecimenNo = labNo.Text;
                f.Color_remark = tx_color_other.Text;


                f.ShowDialog();


            }

        }

        private void frm_repeat_Urninalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ClassSql.DbClose();
        }

        private void frm_repeat_Urninalysis_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ClassSql.DbConnect();
        }

        private void cbo_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_color.Text == "[other]") { tx_color_other.Enabled = true; } else { tx_color_other.Enabled = false; tx_color_other.Clear(); }
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
            Print.Tag = UrineID.ToString();
            //Print.R_Urine.ToString();
            //Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = true; Print.R_Fecal.Enabled = false;
            //Print.Load_Urine();
            Print.isUrine = true;
            Print.ShowDialog();
        }
        void CreateNew()
        {
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

            Tool.ClearFields(groupBox4);
            Tool.ClearFields(groupBox1);
            groupBox1.Enabled = true;
            groupBox4.Enabled = true;
            cmd_save.Enabled = true;
            cmd_print.Enabled = false;
            cmd_save.Text = "&Save";
        }
        private void cmd_new_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        void LoadPreviousList()
        {


            try
            {

                //using (StreamWriter s = File.CreateText(TableListPath.Repeat_Urine_List))
                //{ s.Close(); }

                //  TextWriter sw = new StreamWriter(TableListPath.Repeat_Urine_List);
                //  ClassSql a = new ClassSql(); DataTable dt;
                // dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.result_date  FROM t_result_main WHERE t_result_main.papin = '" + this.Tag.ToString() + "' AND t_result_main.resulttype = 'URINE(repeat)'");
                var list = db.sp_LoadRepeatUrinalysisList(this.Tag.ToString()).ToList();
                Cursor.Current = Cursors.WaitCursor;
                int rowcount = list.Count();
                //  sw.WriteLine("cn \t resultid \t result_date");
                dg_Previous.Rows.Clear();
                foreach (var i in list)
                {

                    //sw.WriteLine(dr["cn"].ToString() + "\t" + dr["resultid"].ToString() + "\t" + dr["result_date"].ToString());
                    // sw.WriteLine(i.cn.ToString() + "\t" + dr["resultid"].ToString() + "\t" + dr["result_date"].ToString());
                    dg_Previous.Rows.Add(i.cn, i.resultid, i.result_date);
                }
                // sw.Close();
                if (rowcount >= 1)
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

            this.Invoke(new MethodInvoker(delegate() { LoadPreviousList(); }));



        }


        void FillDataGridView()
        {
            try
            {
                dt_Urine = Tool.GetDataSourceFromFile(TableListPath.Repeat_Urine_List);
                if (dt_Urine.Rows.Count >= 1)
                {

                    dt_Urine.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_Urine.Columns[1], "%");

                    dg_Previous.DataSource = dt_Urine;
                    dg_Previous.Columns[0].Visible = false;
                    dg_Previous.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dg_Previous.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dt_Urine.Rows.Count >= 1)
                { cmd_new.Enabled = false; }
                else
                { cmd_new.Enabled = true; }
            }
            catch
            { }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if (!backgroundWorker1.CancellationPending)
            //{
            //    Urine f = (Urine)e.UserState;
            //    dg_Previous.Rows.Add(f.cn.ToString(), f.resultid.ToString(), f.resultdate.ToString());

            //}
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //if (dg_Previous.Rows.Count >= 1)
            //{ cmd_new.Enabled = false; }
            //else
            //{ cmd_new.Enabled = true; }

            FillDataGridView();

        }

        private void dg_Previous_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex != 0)
            {
                if (dg_Previous.Rows.Count >= 1)
                {
                    loadPreviousExam();
                }

            }
        }

        void loadPreviousExam()
        {
            //ClassSql a = new ClassSql(); DataTable dt = new DataTable();

            cmd_save.Text = "Edit"; cmd_save.Enabled = true; cmd_print.Enabled = true; cmd_new.Enabled = false;


            //  dt = a.Mytable_Proc("Load_repeat_Urinalysis", "@ID", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
            var i = db.sp_LoadUrinalysisPreviousData(dg_Previous.SelectedRows[0].Cells[1].Value.ToString()).FirstOrDefault();

            //foreach (var i in list)
            //{
            if (i != null)
            {
                UrineID = i.resultid.ToString();
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
                string input = i.result_date.ToString();




                DateTime dtime;
                if (DateTime.TryParse(input, out dtime))
                {
                    dt_resultdate.Text = input;

                }

            }

            //}
            search_Medical();

        }

        private void cmd_refresh_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                //
                //Urine f = new Urine();
                //f.papin = this.Tag.ToString();
                //dg_Previous.Rows.Clear();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            // int i = 1;
            // UrineID = ClassSql.Generate_ResultID("SELECT t_urinalysis.resultid FROM t_urinalysis WHERE t_urinalysis.resultid LIKE '%URINE%' ORDER BY t_urinalysis.cn DESC LIMIT 1", "resultid", "URINE");
            //backgroundWorker2.ReportProgress(i, UrineID);
            //i++;
            var list = db.sp_GenerateRepeatUrinalysis();
            foreach (var i in list)
            {
                UrineID = i.generated_id;
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker2.CancelAsync();

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_Previous.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show(this, "Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteCommand("Delete from t_result_main where cn= {0}", dg_Previous.SelectedRows[0].Cells[0].Value.ToString());

                    db.ExecuteCommand("Delete from t_urinalysis where resultid = {0}", dg_Previous.SelectedRows[0].Cells[1].Value.ToString());
                    LoadPreviousList(); CreateNew();
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
