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
    public partial class frm_Psych_Evaluation : Form, MyInter
    {
        Main fmain; public static bool NewPsych_Eval; public static TextBox pin; public static TextBox LabID;
        string Ilevel;

        string intelectual_level = "0";
        string persevance = "0";
        string obedience = "0";
        string selfDis = "0";
        string Enthu = "0";
        string initiative = "0";
        string boredom = "0";
        string Tolerance = "0";
        string FacesReality = "0";
        string Confidence = "0";
        string Relaxed = "0";
        string Toughmindness = "0";
        string Adaptability = "0";
        string Practicality = "0";
        string Assertiveness = "0";
        string Independence = "0";
        string Resourcefulness = "0";
        string Peers = "0";
        string Superiors = "0";
        string Selfesteem = "0";
        string Aggresive = "0";
        string Direct = "0";
        private string IntelTest = "0";
        private string PersonalityTest = "0";
        private string Others = "0";
        private string Recomendation = "0";
        public string cn;
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public List<Psychology_Model> Psychology_model = new List<Psychology_Model>();
        public frm_Psych_Evaluation(Main mainn)
        {
            InitializeComponent();
            fmain = mainn; pin = txt_Papin; LabID = txt_resultID;
            Cursorhand();

        }


        public void New()
        {
            Cursor.Current = Cursors.WaitCursor;



            IniFile ini = new IniFile(ClassSql.MMS_Path);
            txt_medTech.Text = ini.IniReadValue("MEDICAL", "Psychometrician");
            txt_pathologist.Text = ini.IniReadValue("MEDICAL", "Psychologist");
            this.txt_License1.Text = ini.IniReadValue("MEDICAL", "Psychometrician_license");
            txt_License2.Text = ini.IniReadValue("MEDICAL", "Psychologist_license");
            txt_intel_result.Text = "RPMT"; txt_person_result.Text = "BPI"; txt_other_result.Text = "AUTOBIOGRAPHY & INTERVIEW";


        }




        public void Save()
        {

            if (NewPsych_Eval)
            {
                Insert();

            }
            else
            {
                Update_psych();




            }



        }
        public void Edit()
        {

            if (fmain.UserLevel == 1 || fmain.UserLevel == 2 || fmain.UserLevel == 5)
            {
                NewPsych_Eval = false;
                Availability(true);
                fmain.ts_add_Eval.Enabled = false; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = true; fmain.ts_cancel_Eval.Enabled = true; fmain.ts_search_Eval.Enabled = false; fmain.ts_print_Eval.Enabled = false;

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
            // Delete_Record();

        }
        public void Cancel()
        {
            if (NewPsych_Eval)
            {
                fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_search_Eval.Enabled = true; fmain.ts_print_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = false;

                Tool.ClearFields(groupBox1);
                txt_Papin.Clear();
                ClearAll();
                Availability(false);

            }
            else
            {
                Availability(false);
                ClearAll();
                Search_Patient(); search_Psych();
                fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = true; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_search_Eval.Enabled = true; fmain.ts_print_Eval.Enabled = true; fmain.ts_cancel_Eval.Enabled = false;


            }



        }
        public void Print()
        {
            using (Report.Report_PrintOuts f = new Report.Report_PrintOuts())
            {
                f.Tag = lbl_Psych_Cn.Tag;
                f.Name_from = txtName.Text;
                f.Employer_from = txt_employer.Text;

                DateTime dt = Convert.ToDateTime(dt_dateExam.Text);
                f.Date = dt.ToString("dd MMMM yyyy");
                f.Position_from = txt_position.Text;
                f.Psychometrician = txt_medTech.Text;
                f.Psychologist = txt_pathologist.Text;
                f.Psychometrician_license = txt_License1.Text;
                f.Psychologist_License = txt_License2.Text;
                f.PsychEval = true;
                f.comment1 = txt_eval_detail.Text;
                f.comment2 = txt_Notrec_details.Text;
                if (rb_recomendation.Checked)
                { f.remark = 1; }
                else if (rb_for.Checked)
                { f.remark = 2; }
                else if (rb_not.Checked)
                { f.remark = 3; }
                else
                { f.remark = 0; }

                f.ShowDialog();

            }


            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{

            //    if (per_1.Checked == true) { persevance = "1"; } else if (per_2.Checked == true) { persevance = "2"; } else if (per_3.Checked == true) { persevance = "3"; } else if (per_4.Checked == true) { persevance = "4"; } else if (per_5.Checked == true) { persevance = "5"; } else if (per_6.Checked == true) { persevance = "6"; } else if (per_7.Checked == true) { persevance = "7"; } else { persevance = "-"; }

            //    if (obi_1.Checked == true) { obedience = "1"; } else if (obi_2.Checked == true) { obedience = "2"; } else if (obi_3.Checked == true) { obedience = "3"; } else if (obi_4.Checked == true) { obedience = "4"; } else if (obi_5.Checked == true) { obedience = "5"; } else if (obi_6.Checked == true) { obedience = "6"; } else if (obi_7.Checked == true) { obedience = "7"; } else { obedience = "-"; }
            //    if (self_1.Checked == true) { selfDis = "1"; } else if (this.self_2.Checked == true) { selfDis = "2"; } else if (self_3.Checked == true) { selfDis = "3"; } else if (self_4.Checked == true) { selfDis = "4"; } else if (self_5.Checked == true) { selfDis = "5"; } else if (self_6.Checked == true) { selfDis = "6"; } else if (self_7.Checked == true) { selfDis = "7"; } else { selfDis = "-"; }
            //    if (ini_1.Checked == true) { initiative = "1"; } else if (this.ini_2.Checked == true) { initiative = "2"; } else if (ini_3.Checked == true) { initiative = "3"; } else if (ini_4.Checked == true) { initiative = "4"; } else if (ini_5.Checked == true) { initiative = "5"; } else if (ini_6.Checked == true) { initiative = "6"; } else if (ini_7.Checked == true) { initiative = "7"; } else { initiative = "-"; }
            //    if (can_1.Checked == true) { boredom = "1"; } else if (this.can_2.Checked == true) { boredom = "2"; } else if (can_3.Checked == true) { boredom = "3"; } else if (can_4.Checked == true) { boredom = "4"; } else if (can_5.Checked == true) { boredom = "5"; } else if (can_6.Checked == true) { boredom = "6"; } else if (can_7.Checked == true) { boredom = "7"; } else { boredom = "-"; }
            //    if (tol_1.Checked == true) { Tolerance = "1"; } else if (this.tol_2.Checked == true) { Tolerance = "2"; } else if (tol_3.Checked == true) { Tolerance = "3"; } else if (tol_4.Checked == true) { Tolerance = "4"; } else if (tol_5.Checked == true) { Tolerance = "5"; } else if (tol_6.Checked == true) { Tolerance = "6"; } else if (tol_7.Checked == true) { Tolerance = "7"; } else { Tolerance = "-"; }
            //    if (face_1.Checked == true) { FacesReality = "1"; } else if (this.face_2.Checked == true) { FacesReality = "2"; } else if (face_3.Checked == true) { FacesReality = "3"; } else if (face_4.Checked == true) { FacesReality = "4"; } else if (face_5.Checked == true) { FacesReality = "5"; } else if (face_6.Checked == true) { FacesReality = "6"; } else if (face_7.Checked == true) { FacesReality = "7"; } else { FacesReality = "-"; }
            //    if (con_1.Checked == true) { Confidence = "1"; } else if (this.con_2.Checked == true) { Confidence = "2"; } else if (con_3.Checked == true) { Confidence = "3"; } else if (con_4.Checked == true) { Confidence = "4"; } else if (con_5.Checked == true) { Confidence = "5"; } else if (con_6.Checked == true) { Confidence = "6"; } else if (con_7.Checked == true) { Confidence = "7"; } else { Confidence = "-"; }
            //    if (relax_1.Checked == true) { Relaxed = "1"; } else if (this.relax_2.Checked == true) { Relaxed = "2"; } else if (relax_3.Checked == true) { Relaxed = "3"; } else if (relax_4.Checked == true) { Relaxed = "4"; } else if (relax_5.Checked == true) { Relaxed = "5"; } else if (relax_6.Checked == true) { Relaxed = "6"; } else if (relax_7.Checked == true) { Relaxed = "7"; } else { Relaxed = "-"; }
            //    if (Toug1.Checked == true) { Toughmindness = "1"; } else if (this.Toug2.Checked == true) { Toughmindness = "2"; } else if (Toug3.Checked == true) { Toughmindness = "3"; } else if (Toug4.Checked == true) { Toughmindness = "4"; } else if (Toug5.Checked == true) { Toughmindness = "5"; } else if (Toug6.Checked == true) { Toughmindness = "6"; } else if (Toug7.Checked == true) { Toughmindness = "7"; } else { Toughmindness = "-"; }
            //    if (adap_1.Checked == true) { Adaptability = "1"; } else if (this.adap_2.Checked == true) { Adaptability = "2"; } else if (adap_3.Checked == true) { Adaptability = "3"; } else if (adap_4.Checked == true) { Adaptability = "4"; } else if (adap_5.Checked == true) { Adaptability = "5"; } else if (adap_6.Checked == true) { Adaptability = "6"; } else if (adap_7.Checked == true) { Adaptability = "7"; } else { Adaptability = "-"; }
            //    if (pract1.Checked == true) { Practicality = "1"; } else if (this.pract2.Checked == true) { Practicality = "2"; } else if (pract3.Checked == true) { Practicality = "3"; } else if (pract4.Checked == true) { Practicality = "4"; } else if (pract5.Checked == true) { Practicality = "5"; } else if (pract6.Checked == true) { Practicality = "6"; } else if (pract7.Checked == true) { Practicality = "7"; } else { Practicality = "-"; }
            //    if (aser1.Checked == true) { Assertiveness = "1"; } else if (this.aser2.Checked == true) { Assertiveness = "2"; } else if (aser3.Checked == true) { Assertiveness = "3"; } else if (aser4.Checked == true) { Assertiveness = "4"; } else if (aser5.Checked == true) { Assertiveness = "5"; } else if (aser6.Checked == true) { Assertiveness = "6"; } else if (aser7.Checked == true) { Assertiveness = "7"; } else { Assertiveness = "-"; }
            //    if (inde1.Checked == true) { Independence = "1"; } else if (this.inde2.Checked == true) { Independence = "2"; } else if (inde3.Checked == true) { Independence = "3"; } else if (inde4.Checked == true) { Independence = "4"; } else if (inde5.Checked == true) { Independence = "5"; } else if (inde6.Checked == true) { Independence = "6"; } else if (inde7.Checked == true) { Independence = "7"; } else { Independence = "-"; }
            //    if (Resource1.Checked == true) { Resourcefulness = "1"; } else if (this.Resource2.Checked == true) { Resourcefulness = "2"; } else if (Resource3.Checked == true) { Resourcefulness = "3"; } else if (Resource4.Checked == true) { Resourcefulness = "4"; } else if (Resource5.Checked == true) { Resourcefulness = "5"; } else if (Resource6.Checked == true) { Resourcefulness = "6"; } else if (Resource7.Checked == true) { Resourcefulness = "7"; } else { Resourcefulness = "-"; }
            //    if (rel_1.Checked == true) { Peers = "1"; } else if (this.rel_2.Checked == true) { Peers = "2"; } else if (rel_3.Checked == true) { Peers = "3"; } else if (rel_4.Checked == true) { Peers = "4"; } else if (rel_5.Checked == true) { Peers = "5"; } else if (rel_6.Checked == true) { Peers = "6"; } else if (rel_7.Checked == true) { Peers = "7"; } else { Peers = "-"; }
            //    if (rel_with_1.Checked == true) { Superiors = "1"; } else if (this.rel_with_2.Checked == true) { Superiors = "2"; } else if (rel_with_3.Checked == true) { Superiors = "3"; } else if (rel_with_4.Checked == true) { Superiors = "4"; } else if (rel_with_5.Checked == true) { Superiors = "5"; } else if (rel_with_6.Checked == true) { Superiors = "6"; } else if (rel_with_7.Checked == true) { Superiors = "7"; } else { Superiors = "-"; }
            //    if (esteem_1.Checked == true) { Selfesteem = "1"; } else if (this.esteem_2.Checked == true) { Selfesteem = "2"; } else if (esteem_3.Checked == true) { Selfesteem = "3"; } else if (esteem_4.Checked == true) { Selfesteem = "4"; } else if (esteem_5.Checked == true) { Selfesteem = "5"; } else if (esteem_6.Checked == true) { Selfesteem = "6"; } else if (esteem_7.Checked == true) { Selfesteem = "7"; } else { Selfesteem = "-"; }
            //    if (aggr_1.Checked == true) { Aggresive = "1"; } else if (this.aggr_2.Checked == true) { Aggresive = "2"; } else if (aggr_3.Checked == true) { Aggresive = "3"; } else if (aggr_4.Checked == true) { Aggresive = "4"; } else if (aggr_5.Checked == true) { Aggresive = "5"; } else if (aggr_6.Checked == true) { Aggresive = "6"; } else if (aggr_7.Checked == true) { Aggresive = "7"; } else { Aggresive = "-"; }
            //    if (direc_1.Checked == true) { Direct = "1"; } else if (this.direc_2.Checked == true) { Direct = "2"; } else if (direc_3.Checked == true) { Direct = "3"; } else if (direc_4.Checked == true) { Direct = "4"; } else if (direc_5.Checked == true) { Direct = "5"; } else if (direc_6.Checked == true) { Direct = "6"; } else if (direc_7.Checked == true) { Direct = "7"; } else { Direct = "-"; }
            //    if (enthu_1.Checked == true) { Enthu = "1"; } else if (this.enthu_2.Checked == true) { Enthu = "2"; } else if (enthu_3.Checked == true) { Enthu = "3"; } else if (enthu_4.Checked == true) { Enthu = "4"; } else if (enthu_5.Checked == true) { Enthu = "5"; } else if (enthu_6.Checked == true) { Enthu = "6"; } else if (enthu_7.Checked == true) { Enthu = "7"; } else { Enthu = "-"; }

            //    if (rb_recomendation.Checked == true) { Recomendation = "1"; } else if (rb_for.Checked == true) { Recomendation = "2"; } else if (rb_not.Checked == true) { Recomendation = "3"; } else { Recomendation = "-"; }



            //    f.isPsycho = true;
            //    f.age = txt_age.Text;
            //    f.Tag = LabID.Text;
            //    f.PatientName = txtName.Text;
            //    f.ReferredBy = txt_employer.Text;
            //    f.resultDate = dt_dateExam.Text;
            //    f.Position = txt_position.Text;
            //    f.IQ_TEST = txt_intel_result.Text;
            //    f.Personal_TEST = txt_person_result.Text;
            //    f.Other_test = txt_other_result.Text;
            //    if (rb_intelectual_level_Very.Checked) { Ilevel = "1"; } else if (rb_intelectual_level_Superior.Checked) { Ilevel = "2"; } else if (rb_intelectual_level_Above.Checked) { Ilevel = "3"; } else if (rb_intelectual_level_Average.Checked) { Ilevel = "4"; } else if (rb_intelectual_level_Below.Checked) { Ilevel = "5"; } else if (rb_intelectual_level_BorderLine.Checked) { Ilevel = "6"; } else if (rb_mentally.Checked) { Ilevel = "7"; } else { Ilevel = "0"; }
            //    f.Interlectual_level = Ilevel;
            //    f.Perseverance = persevance;
            //    f.Obedienc = obedience;
            //    f.Discipline = selfDis;
            //    f.Enthusiasm = Enthu;
            //    f.Initiative = initiative;
            //    f.boredom = boredom;
            //    f.Tolerance = Tolerance;
            //    f.Reality = FacesReality;
            //    f.Confidence = Confidence;
            //    f.Conclusion = Recomendation;
            //    f.Relaxed = Relaxed;
            //    f.mindedness = Toughmindness;
            //    f.Adaptability = Adaptability;
            //    f.Practicality = Practicality;
            //    f.Assertiveness = Assertiveness;
            //    f.Independence = Independence;
            //    f.Resourcefulness = Resourcefulness;
            //    f.Relationship = Peers;
            //    f.Superiors = Superiors;
            //    f.esteem = Selfesteem;
            //    f.Aggressive = Aggresive;
            //    f.Direct = Direct;
            //    f.med_1 = txt_medTech.Text;
            //    f.Lic_1 = txt_License1.Text;        
            //    f.Validity_1 = Lic_validity_Medtech.Text;
            //    f.ptr_1 = PTR_medtech.Text;
            //    f.Med_2 = txt_pathologist.Text;
            //    f.Validity_2 = Lic_Validity_Patho.Text;
            //    f.ptr_2 = PTR_Patho.Text;
            //    f.Lic_2 = txt_License2.Text;
            //    f.Conclusion_text1 = txt_eval_detail.Text;
            //    f.Conclusion_text2 = txt_Notrec_details.Text;
            //    f.ShowDialog();
            //}


        }


        //void Delete_Record()
        //{

        //    try
        //    {


        //        ClassSql a = new ClassSql();
        //        a.ExecuteQuery("Delete from t_psychology where resultid = '" + LabID.Text + "' and resulttype= 'PSYCHO'");
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




        public void Search()
        {


        }

        void Insert()
        {

            try
            {




                if (rb_intelectual_level_Very.Checked == true) { intelectual_level = "VS"; } else if (rb_intelectual_level_Superior.Checked == true) { intelectual_level = "SUP"; } else if (rb_intelectual_level_Above.Checked == true) { intelectual_level = "AAVG"; } else if (rb_intelectual_level_Average.Checked == true) { intelectual_level = "AVG"; } else if (rb_intelectual_level_Below.Checked == true) { intelectual_level = "BAVG"; } else if (rb_intelectual_level_BorderLine.Checked == true) { intelectual_level = "BL"; } else if (rb_mentally.Checked == true) { intelectual_level = "M"; } else { intelectual_level = "-"; }

                if (per_1.Checked == true) { persevance = "1"; } else if (per_2.Checked == true) { persevance = "2"; } else if (per_3.Checked == true) { persevance = "3"; } else if (per_4.Checked == true) { persevance = "4"; } else if (per_5.Checked == true) { persevance = "5"; } else if (per_6.Checked == true) { persevance = "6"; } else if (per_7.Checked == true) { persevance = "7"; } else { persevance = "-"; }
                if (obi_1.Checked == true) { obedience = "1"; } else if (obi_2.Checked == true) { obedience = "2"; } else if (obi_3.Checked == true) { obedience = "3"; } else if (obi_4.Checked == true) { obedience = "4"; } else if (obi_5.Checked == true) { obedience = "5"; } else if (obi_6.Checked == true) { obedience = "6"; } else if (obi_7.Checked == true) { obedience = "7"; } else { obedience = "-"; }
                if (self_1.Checked == true) { selfDis = "1"; } else if (this.self_2.Checked == true) { selfDis = "2"; } else if (self_3.Checked == true) { selfDis = "3"; } else if (self_4.Checked == true) { selfDis = "4"; } else if (self_5.Checked == true) { selfDis = "5"; } else if (self_6.Checked == true) { selfDis = "6"; } else if (self_7.Checked == true) { selfDis = "7"; } else { selfDis = "-"; }
                if (ini_1.Checked == true) { initiative = "1"; } else if (this.ini_2.Checked == true) { initiative = "2"; } else if (ini_3.Checked == true) { initiative = "3"; } else if (ini_4.Checked == true) { initiative = "4"; } else if (ini_5.Checked == true) { initiative = "5"; } else if (ini_6.Checked == true) { initiative = "6"; } else if (ini_7.Checked == true) { initiative = "7"; } else { initiative = "-"; }
                if (can_1.Checked == true) { boredom = "1"; } else if (this.can_2.Checked == true) { boredom = "2"; } else if (can_3.Checked == true) { boredom = "3"; } else if (can_4.Checked == true) { boredom = "4"; } else if (can_5.Checked == true) { boredom = "5"; } else if (can_6.Checked == true) { boredom = "6"; } else if (can_7.Checked == true) { boredom = "7"; } else { boredom = "-"; }
                if (tol_1.Checked == true) { Tolerance = "1"; } else if (this.tol_2.Checked == true) { Tolerance = "2"; } else if (tol_3.Checked == true) { Tolerance = "3"; } else if (tol_4.Checked == true) { Tolerance = "4"; } else if (tol_5.Checked == true) { Tolerance = "5"; } else if (tol_6.Checked == true) { Tolerance = "6"; } else if (tol_7.Checked == true) { Tolerance = "7"; } else { Tolerance = "-"; }
                if (face_1.Checked == true) { FacesReality = "1"; } else if (this.face_2.Checked == true) { FacesReality = "2"; } else if (face_3.Checked == true) { FacesReality = "3"; } else if (face_4.Checked == true) { FacesReality = "4"; } else if (face_5.Checked == true) { FacesReality = "5"; } else if (face_6.Checked == true) { FacesReality = "6"; } else if (face_7.Checked == true) { FacesReality = "7"; } else { FacesReality = "-"; }
                if (con_1.Checked == true) { Confidence = "1"; } else if (this.con_2.Checked == true) { Confidence = "2"; } else if (con_3.Checked == true) { Confidence = "3"; } else if (con_4.Checked == true) { Confidence = "4"; } else if (con_5.Checked == true) { Confidence = "5"; } else if (con_6.Checked == true) { Confidence = "6"; } else if (con_7.Checked == true) { Confidence = "7"; } else { Confidence = "-"; }
                if (relax_1.Checked == true) { Relaxed = "1"; } else if (this.relax_2.Checked == true) { Relaxed = "2"; } else if (relax_3.Checked == true) { Relaxed = "3"; } else if (relax_4.Checked == true) { Relaxed = "4"; } else if (relax_5.Checked == true) { Relaxed = "5"; } else if (relax_6.Checked == true) { Relaxed = "6"; } else if (relax_7.Checked == true) { Relaxed = "7"; } else { Relaxed = "-"; }
                if (Toug1.Checked == true) { Toughmindness = "1"; } else if (this.Toug2.Checked == true) { Toughmindness = "2"; } else if (Toug3.Checked == true) { Toughmindness = "3"; } else if (Toug4.Checked == true) { Toughmindness = "4"; } else if (Toug5.Checked == true) { Toughmindness = "5"; } else if (Toug6.Checked == true) { Toughmindness = "6"; } else if (Toug7.Checked == true) { Toughmindness = "7"; } else { Toughmindness = "-"; }
                if (adap_1.Checked == true) { Adaptability = "1"; } else if (this.adap_2.Checked == true) { Adaptability = "2"; } else if (adap_3.Checked == true) { Adaptability = "3"; } else if (adap_4.Checked == true) { Adaptability = "4"; } else if (adap_5.Checked == true) { Adaptability = "5"; } else if (adap_6.Checked == true) { Adaptability = "6"; } else if (adap_7.Checked == true) { Adaptability = "7"; } else { Adaptability = "-"; }
                if (pract1.Checked == true) { Practicality = "1"; } else if (this.pract2.Checked == true) { Practicality = "2"; } else if (pract3.Checked == true) { Practicality = "3"; } else if (pract4.Checked == true) { Practicality = "4"; } else if (pract5.Checked == true) { Practicality = "5"; } else if (pract6.Checked == true) { Practicality = "6"; } else if (pract7.Checked == true) { Practicality = "7"; } else { Practicality = "-"; }
                if (aser1.Checked == true) { Assertiveness = "1"; } else if (this.aser2.Checked == true) { Assertiveness = "2"; } else if (aser3.Checked == true) { Assertiveness = "3"; } else if (aser4.Checked == true) { Assertiveness = "4"; } else if (aser5.Checked == true) { Assertiveness = "5"; } else if (aser6.Checked == true) { Assertiveness = "6"; } else if (aser7.Checked == true) { Assertiveness = "7"; } else { Assertiveness = "-"; }
                if (inde1.Checked == true) { Independence = "1"; } else if (this.inde2.Checked == true) { Independence = "2"; } else if (inde3.Checked == true) { Independence = "3"; } else if (inde4.Checked == true) { Independence = "4"; } else if (inde5.Checked == true) { Independence = "5"; } else if (inde6.Checked == true) { Independence = "6"; } else if (inde7.Checked == true) { Independence = "7"; } else { Independence = "-"; }
                if (Resource1.Checked == true) { Resourcefulness = "1"; } else if (this.Resource2.Checked == true) { Resourcefulness = "2"; } else if (Resource3.Checked == true) { Resourcefulness = "3"; } else if (Resource4.Checked == true) { Resourcefulness = "4"; } else if (Resource5.Checked == true) { Resourcefulness = "5"; } else if (Resource6.Checked == true) { Resourcefulness = "6"; } else if (Resource7.Checked == true) { Resourcefulness = "7"; } else { Resourcefulness = "-"; }
                if (rel_1.Checked == true) { Peers = "1"; } else if (this.rel_2.Checked == true) { Peers = "2"; } else if (rel_3.Checked == true) { Peers = "3"; } else if (rel_4.Checked == true) { Peers = "4"; } else if (rel_5.Checked == true) { Peers = "5"; } else if (rel_6.Checked == true) { Peers = "6"; } else if (rel_7.Checked == true) { Peers = "7"; } else { Peers = "-"; }
                if (rel_with_1.Checked == true) { Superiors = "1"; } else if (this.rel_with_2.Checked == true) { Superiors = "2"; } else if (rel_with_3.Checked == true) { Superiors = "3"; } else if (rel_with_4.Checked == true) { Superiors = "4"; } else if (rel_with_5.Checked == true) { Superiors = "5"; } else if (rel_with_6.Checked == true) { Superiors = "6"; } else if (rel_with_7.Checked == true) { Superiors = "7"; } else { Superiors = "-"; }
                if (esteem_1.Checked == true) { Selfesteem = "1"; } else if (this.esteem_2.Checked == true) { Selfesteem = "2"; } else if (esteem_3.Checked == true) { Selfesteem = "3"; } else if (esteem_4.Checked == true) { Selfesteem = "4"; } else if (esteem_5.Checked == true) { Selfesteem = "5"; } else if (esteem_6.Checked == true) { Selfesteem = "6"; } else if (esteem_7.Checked == true) { Selfesteem = "7"; } else { Selfesteem = "-"; }
                if (aggr_1.Checked == true) { Aggresive = "1"; } else if (this.aggr_2.Checked == true) { Aggresive = "2"; } else if (aggr_3.Checked == true) { Aggresive = "3"; } else if (aggr_4.Checked == true) { Aggresive = "4"; } else if (aggr_5.Checked == true) { Aggresive = "5"; } else if (aggr_6.Checked == true) { Aggresive = "6"; } else if (aggr_7.Checked == true) { Aggresive = "7"; } else { Aggresive = "-"; }
                if (direc_1.Checked == true) { Direct = "1"; } else if (this.direc_2.Checked == true) { Direct = "2"; } else if (direc_3.Checked == true) { Direct = "3"; } else if (direc_4.Checked == true) { Direct = "4"; } else if (direc_5.Checked == true) { Direct = "5"; } else if (direc_6.Checked == true) { Direct = "6"; } else if (direc_7.Checked == true) { Direct = "7"; } else { Direct = "-"; }
                if (enthu_1.Checked == true) { Enthu = "1"; } else if (this.enthu_2.Checked == true) { Enthu = "2"; } else if (enthu_3.Checked == true) { Enthu = "3"; } else if (enthu_4.Checked == true) { Enthu = "4"; } else if (enthu_5.Checked == true) { Enthu = "5"; } else if (enthu_6.Checked == true) { Enthu = "6"; } else if (enthu_7.Checked == true) { Enthu = "1"; } else { Enthu = "-"; }
                if (cb_intel_test.Checked == true) { IntelTest = "Y"; } else { IntelTest = "N"; }
                if (this.cb_person_test.Checked == true) { PersonalityTest = "Y"; } else { PersonalityTest = "N"; }
                if (cb_other_test.Checked == true) { Others = "Y"; } else { Others = "N"; }
                if (rb_recomendation.Checked == true) { Recomendation = "1"; } else if (rb_for.Checked == true) { Recomendation = "2"; } else if (rb_not.Checked == true) { Recomendation = "3"; } else { Recomendation = "-"; }


                //`resultid`,                `type_of_test`,             `intelectual_level`,            `res_persevering`,                    `res_obedient`,            `res_selfdiscipline`,           `res_enthusiastic`,            `res_venturesome`,        `emo_isolation_boredom`,             `emo_noise_vibration_temp`,       `emo_reality`,                `emo_confident`,                `emo_stress`,      `emo_relaxed`,           `obj_realistic`,           `obj_jealousy`,      `obj_adaptable`,         `obj_practicalminded`,          `mot_assertive`,              `mot_independent`,         `mot_resourceful`,               `type_of_test_desc`, `goal_orientation`, `recommendation`, `rec_reservation_desc`, `rec_not_rec_desc`,     `iapa_rel_peer`,     `iapa_rel_superior`,          `iapa_self_esteem`,       `iapa_aggressive_tendencies`,    `intel_test`,                   `intel_result`,                       `person_test`,         `person_result`,                            `other_test`,                 `other_result`,                     `ff_eval_details`,                          `not_rec_details`)
                IniFile ini = new IniFile(ClassSql.MMS_Path);

                db.ExecuteCommand("INSERT INTO t_psychology (resultid, type_of_test, intelectual_level, res_persevering, res_obedient, res_selfdiscipline, res_enthusiastic, res_venturesome, emo_isolation_boredom, emo_noise_vibration_temp, emo_reality, emo_confident, emo_stress, emo_relaxed, obj_realistic, obj_jealousy, obj_adaptable, obj_practicalminded, mot_assertive, mot_independent, mot_resourceful, type_of_test_desc, goal_orientation, recommendation, rec_reservation_desc, rec_not_rec_desc, iapa_rel_peer, iapa_rel_superior, iapa_self_esteem, iapa_aggressive_tendencies, intel_test, intel_result, person_test, person_result, other_test, other_result, ff_eval_details, not_rec_details,papin,pathologist,pathologist_license,medtech,medtech_license,result_date,fitness_date,Lic_Validity_Medtech,PTR_medTech,Lic_Validity_Pathologist,PTR_Pathologist) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{8})", "", "", intelectual_level.ToString(), persevance.ToString(), obedience.ToString(), selfDis.ToString(), Enthu.ToString(), initiative.ToString(), boredom.ToString(), Tolerance.ToString(), FacesReality.ToString(), Confidence.ToString(), "", Relaxed.ToString(), Toughmindness.ToString(), "", Adaptability.ToString(), Practicality.ToString(), Assertiveness.ToString(), Independence.ToString(), Resourcefulness.ToString(), "", Direct.ToString(), Recomendation.ToString(), "", "", Peers.ToString(), Superiors.ToString(), Selfesteem.ToString(), Aggresive.ToString(), IntelTest.ToString(), txt_intel_result.Text, PersonalityTest.ToString(), txt_person_result.Text, Others.ToString(), txt_other_result.Text, txt_eval_detail.Text, txt_Notrec_details.Text, pin.Text, txt_pathologist.Text, txt_License2.Text, txt_medTech.Text, txt_License1.Text, dt_dateExam.Text, dt_testAdministered.Text, ini.IniReadValue("MEDICAL", "Psychometrician_Validity"), ini.IniReadValue("MEDICAL", "Psychometrician_ptr"), ini.IniReadValue("MEDICAL", "Psychologist_Validity"), ini.IniReadValue("MEDICAL", "Psychologist_Ptr"));

                this.Invoke(new Action(() => { search_Psych(); }));

                fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = true; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = false; fmain.ts_search_Eval.Enabled = true; fmain.ts_print_Eval.Enabled = true;
                txt_Papin.Select();
                //Tool.MessageBoxSave();
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

        void Update_psych()
        {


            try
            {


                // if (rb_intelectual_level_Very.Checked == true) { intelectual_level = "VS"; } else if (rb_intelectual_level_Superior.Checked == true) { intelectual_level = "SUP"; } else if (rb_intelectual_level_Above.Checked == true) { intelectual_level = "AAVG"; } else if (rb_intelectual_level_Average.Checked == true) { intelectual_level = "AVG"; } else if (rb_intelectual_level_Below.Checked == true) { intelectual_level = "BAVG"; } else if (rb_intelectual_level_BorderLine.Checked == true) { intelectual_level = "BL"; } else if (rb_mentally.Checked == true) { intelectual_level = "M"; }       
                //if (per_1.Checked == true) { persevance = "1"; } else if (per_2.Checked == true) { persevance = "2"; } else if (per_3.Checked == true) { persevance = "3"; } else if (per_4.Checked == true) { persevance = "4"; } else if (per_5.Checked == true) { persevance = "5"; } else if (per_6.Checked == true) { persevance = "6"; } else if (per_7.Checked == true) { persevance = "7"; }
                //if (obi_1.Checked == true) { obedience = "1"; } else if (obi_2.Checked == true) { obedience = "2"; } else if     (obi_3.Checked == true) { obedience = "3"; } else if (obi_4.Checked == true) { obedience = "4"; } else if (obi_5.Checked == true) { obedience = "5"; } else if (obi_6.Checked == true) { obedience = "6"; } else if (obi_7.Checked == true) { obedience = "7"; }
                //if (self_1.Checked == true) { selfDis = "1"; } else if (this.self_2.Checked == true) { selfDis = "2"; } else if (self_3.Checked == true) { selfDis = "3"; } else if (self_4.Checked == true) { selfDis = "4"; } else if (self_5.Checked == true) { selfDis = "5"; } else if (self_6.Checked == true) { selfDis = "6"; } else if (self_7.Checked == true) { selfDis = "7"; }
                //if (ini_1.Checked == true) { initiative = "1"; } else if (this.ini_2.Checked == true) { initiative = "2"; } else if (ini_3.Checked == true) { initiative = "3"; } else if (ini_4.Checked == true) { initiative = "4"; } else if (ini_5.Checked == true) { initiative = "5"; } else if (ini_6.Checked == true) { initiative = "6"; } else if (ini_7.Checked == true) { initiative = "7"; }
                //if (can_1.Checked == true) { boredom = "1"; } else if (this.can_2.Checked == true) { boredom = "2"; } else if (can_3.Checked == true) { boredom = "3"; } else if (can_4.Checked == true) { boredom = "4"; } else if (can_5.Checked == true) { boredom = "5"; } else if (can_6.Checked == true) { boredom = "6"; } else if (can_7.Checked == true) { boredom = "7"; }
                //if (tol_1.Checked == true) { Tolerance = "1"; } else if (this.tol_2.Checked == true) { Tolerance = "2"; } else if (tol_3.Checked == true) { Tolerance = "3"; } else if (tol_4.Checked == true) { Tolerance = "4"; } else if (tol_5.Checked == true) { Tolerance = "5"; } else if (tol_6.Checked == true) { Tolerance = "6"; } else if (tol_7.Checked == true) { Tolerance = "7"; }
                //if (face_1.Checked == true) { FacesReality = "1"; } else if (this.face_2.Checked == true) { FacesReality = "2"; } else if (face_3.Checked == true) { FacesReality = "3"; } else if (face_4.Checked == true) { FacesReality = "4"; } else if (face_5.Checked == true) { FacesReality = "5"; } else if (face_6.Checked == true) { FacesReality = "6"; } else if (face_7.Checked == true) { FacesReality = "7"; }
                //if (con_1.Checked == true) { Confidence = "1"; } else if (this.con_2.Checked == true) { Confidence = "2"; } else if (con_3.Checked == true) { Confidence = "3"; } else if (con_4.Checked == true) { Confidence = "4"; } else if (con_5.Checked == true) { Confidence = "5"; } else if (con_6.Checked == true) { Confidence = "6"; } else if (con_7.Checked == true) { Confidence = "7"; }
                //if (relax_1.Checked == true) { Relaxed = "1"; } else if (this.relax_2.Checked == true) { Relaxed = "2"; } else if (relax_3.Checked == true) { Relaxed = "3"; } else if (relax_4.Checked == true) { Relaxed = "4"; } else if (relax_5.Checked == true) { Relaxed = "5"; } else if (relax_6.Checked == true) { Relaxed = "6"; } else if (relax_7.Checked == true) { Relaxed = "7"; }
                //if (Toug1.Checked == true) { Toughmindness = "1"; } else if (this.Toug2.Checked == true) { Toughmindness = "2"; } else if (Toug3.Checked == true) { Toughmindness = "3"; } else if (Toug4.Checked == true) { Toughmindness = "4"; } else if (Toug5.Checked == true) { Toughmindness = "5"; } else if (Toug6.Checked == true) { Toughmindness = "6"; } else if (Toug7.Checked == true) { Toughmindness = "7"; }
                //if (adap_1.Checked == true) { Adaptability = "1"; } else if (this.adap_2.Checked == true) { Adaptability = "2"; } else if (adap_3.Checked == true) { Adaptability = "3"; } else if (adap_4.Checked == true) { Adaptability = "4"; } else if (adap_5.Checked == true) { Adaptability = "5"; } else if (adap_6.Checked == true) { Adaptability = "6"; } else if (adap_7.Checked == true) { Adaptability = "7"; }
                //if (pract1.Checked == true) { Practicality = "1"; } else if (this.pract2.Checked == true) { Practicality = "2"; } else if (pract3.Checked == true) { Practicality = "3"; } else if (pract4.Checked == true) { Practicality = "4"; } else if (pract5.Checked == true) { Practicality = "5"; } else if (pract6.Checked == true) { Practicality = "6"; } else if (pract7.Checked == true) { Practicality = "7"; }
                //if (aser1.Checked == true) { Assertiveness = "1"; } else if (this.aser2.Checked == true) { Assertiveness = "2"; } else if (aser3.Checked == true) { Assertiveness = "3"; } else if (aser4.Checked == true) { Assertiveness = "4"; } else if (aser5.Checked == true) { Assertiveness = "5"; } else if (aser6.Checked == true) { Assertiveness = "6"; } else if (aser7.Checked == true) { Assertiveness = "7"; }
                //if (inde1.Checked == true) { Independence = "1"; } else if (this.inde2.Checked == true) { Independence = "2"; } else if (inde3.Checked == true) { Independence = "3"; } else if (inde4.Checked == true) { Independence = "4"; } else if (inde5.Checked == true) { Independence = "5"; } else if (inde6.Checked == true) { Independence = "6"; } else if (inde7.Checked == true) { Independence = "7"; }
                //if (Resource1.Checked == true) { Resourcefulness = "1"; } else if (this.Resource2.Checked == true) { Resourcefulness = "2"; } else if (Resource3.Checked == true) { Resourcefulness = "3"; } else if (Resource4.Checked == true) { Resourcefulness = "4"; } else if (Resource5.Checked == true) { Resourcefulness = "5"; } else if (Resource6.Checked == true) { Resourcefulness = "6"; } else if (Resource7.Checked == true) { Resourcefulness = "7"; }
                //if (rel_1.Checked == true) { Peers = "1"; } else if (this.rel_2.Checked == true) { Peers = "2"; } else if (rel_3.Checked == true) { Peers = "3"; } else if (rel_4.Checked == true) { Peers = "4"; } else if (rel_5.Checked == true) { Peers = "5"; } else if (rel_6.Checked == true) { Peers = "6"; } else if (rel_7.Checked == true) { Peers = "7"; }
                //if (rel_with_1.Checked == true) { Superiors = "1"; } else if (this.rel_with_2.Checked == true) { Superiors = "2"; } else if (rel_with_3.Checked == true) { Superiors = "3"; } else if (rel_with_4.Checked == true) { Superiors = "4"; } else if (rel_with_5.Checked == true) { Superiors = "5"; } else if (rel_with_6.Checked == true) { Superiors = "6"; } else if (rel_with_7.Checked == true) { Superiors = "7"; }
                //if (esteem_1.Checked == true) { Selfesteem = "1"; } else if (this.esteem_2.Checked == true) { Selfesteem = "2"; } else if (esteem_3.Checked == true) { Selfesteem = "3"; } else if (esteem_4.Checked == true) { Selfesteem = "4"; } else if (esteem_5.Checked == true) { Selfesteem = "5"; } else if (esteem_6.Checked == true) { Selfesteem = "6"; } else if (esteem_7.Checked == true) { Selfesteem = "7"; }
                //if (aggr_1.Checked == true) { Aggresive = "1"; } else if (this.aggr_2.Checked == true) { Aggresive = "2"; } else if (aggr_3.Checked == true) { Aggresive = "3"; } else if (aggr_4.Checked == true) { Aggresive = "4"; } else if (aggr_5.Checked == true) { Aggresive = "5"; } else if (aggr_6.Checked == true) { Aggresive = "6"; } else if (aggr_7.Checked == true) { Aggresive = "7"; }
                //if (direc_1.Checked == true) { Direct = "1"; } else if (this.direc_2.Checked == true) { Direct = "2"; } else if (direc_3.Checked == true) { Direct = "3"; } else if (direc_4.Checked == true) { Direct = "4"; } else if (direc_5.Checked == true) { Direct = "5"; } else if (direc_6.Checked == true) { Direct = "6"; } else if (direc_7.Checked == true) { Direct = "7"; }
                //if (enthu_1.Checked == true) { Enthu = "1"; } else if (this.enthu_2.Checked == true) { Enthu = "2"; } else if (enthu_3.Checked == true) { Enthu = "3"; } else if (enthu_4.Checked == true) { Enthu = "4"; } else if (enthu_5.Checked == true) { Enthu = "5"; } else if (enthu_6.Checked == true) { Enthu = "6"; } else if (enthu_7.Checked == true) { Enthu = "7"; }              
                //if (cb_intel_test.Checked == true) { IntelTest = "Y"; } else { IntelTest = "N"; }
                //if (this.cb_person_test.Checked == true) { PersonalityTest = "Y"; } else { PersonalityTest = "N"; }
                //if (cb_other_test.Checked == true) { Others = "Y"; } else { Others = "N"; }
                //if (rb_recomendation.Checked == true) { Recomendation = "1"; } else if (rb_for.Checked == true) { Recomendation = "2"; } else if (rb_not.Checked == true) { Recomendation = "3"; }


                if (rb_intelectual_level_Very.Checked == true) { intelectual_level = "VS"; } else if (rb_intelectual_level_Superior.Checked == true) { intelectual_level = "SUP"; } else if (rb_intelectual_level_Above.Checked == true) { intelectual_level = "AAVG"; } else if (rb_intelectual_level_Average.Checked == true) { intelectual_level = "AVG"; } else if (rb_intelectual_level_Below.Checked == true) { intelectual_level = "BAVG"; } else if (rb_intelectual_level_BorderLine.Checked == true) { intelectual_level = "BL"; } else if (rb_mentally.Checked == true) { intelectual_level = "M"; } else { intelectual_level = "-"; }
                if (per_1.Checked == true) { persevance = "1"; } else if (per_2.Checked == true) { persevance = "2"; } else if (per_3.Checked == true) { persevance = "3"; } else if (per_4.Checked == true) { persevance = "4"; } else if (per_5.Checked == true) { persevance = "5"; } else if (per_6.Checked == true) { persevance = "6"; } else if (per_7.Checked == true) { persevance = "7"; } else { persevance = "-"; }
                if (obi_1.Checked == true) { obedience = "1"; } else if (obi_2.Checked == true) { obedience = "2"; } else if (obi_3.Checked == true) { obedience = "3"; } else if (obi_4.Checked == true) { obedience = "4"; } else if (obi_5.Checked == true) { obedience = "5"; } else if (obi_6.Checked == true) { obedience = "6"; } else if (obi_7.Checked == true) { obedience = "7"; } else { obedience = "-"; }
                if (self_1.Checked == true) { selfDis = "1"; } else if (this.self_2.Checked == true) { selfDis = "2"; } else if (self_3.Checked == true) { selfDis = "3"; } else if (self_4.Checked == true) { selfDis = "4"; } else if (self_5.Checked == true) { selfDis = "5"; } else if (self_6.Checked == true) { selfDis = "6"; } else if (self_7.Checked == true) { selfDis = "7"; } else { selfDis = "-"; }
                if (ini_1.Checked == true) { initiative = "1"; } else if (this.ini_2.Checked == true) { initiative = "2"; } else if (ini_3.Checked == true) { initiative = "3"; } else if (ini_4.Checked == true) { initiative = "4"; } else if (ini_5.Checked == true) { initiative = "5"; } else if (ini_6.Checked == true) { initiative = "6"; } else if (ini_7.Checked == true) { initiative = "7"; } else { initiative = "-"; }
                if (can_1.Checked == true) { boredom = "1"; } else if (this.can_2.Checked == true) { boredom = "2"; } else if (can_3.Checked == true) { boredom = "3"; } else if (can_4.Checked == true) { boredom = "4"; } else if (can_5.Checked == true) { boredom = "5"; } else if (can_6.Checked == true) { boredom = "6"; } else if (can_7.Checked == true) { boredom = "7"; } else { boredom = "-"; }
                if (tol_1.Checked == true) { Tolerance = "1"; } else if (this.tol_2.Checked == true) { Tolerance = "2"; } else if (tol_3.Checked == true) { Tolerance = "3"; } else if (tol_4.Checked == true) { Tolerance = "4"; } else if (tol_5.Checked == true) { Tolerance = "5"; } else if (tol_6.Checked == true) { Tolerance = "6"; } else if (tol_7.Checked == true) { Tolerance = "7"; } else { Tolerance = "-"; }
                if (face_1.Checked == true) { FacesReality = "1"; } else if (this.face_2.Checked == true) { FacesReality = "2"; } else if (face_3.Checked == true) { FacesReality = "3"; } else if (face_4.Checked == true) { FacesReality = "4"; } else if (face_5.Checked == true) { FacesReality = "5"; } else if (face_6.Checked == true) { FacesReality = "6"; } else if (face_7.Checked == true) { FacesReality = "7"; } else { FacesReality = "-"; }
                if (con_1.Checked == true) { Confidence = "1"; } else if (this.con_2.Checked == true) { Confidence = "2"; } else if (con_3.Checked == true) { Confidence = "3"; } else if (con_4.Checked == true) { Confidence = "4"; } else if (con_5.Checked == true) { Confidence = "5"; } else if (con_6.Checked == true) { Confidence = "6"; } else if (con_7.Checked == true) { Confidence = "7"; } else { Confidence = "-"; }
                if (relax_1.Checked == true) { Relaxed = "1"; } else if (this.relax_2.Checked == true) { Relaxed = "2"; } else if (relax_3.Checked == true) { Relaxed = "3"; } else if (relax_4.Checked == true) { Relaxed = "4"; } else if (relax_5.Checked == true) { Relaxed = "5"; } else if (relax_6.Checked == true) { Relaxed = "6"; } else if (relax_7.Checked == true) { Relaxed = "7"; } else { Relaxed = "-"; }
                if (Toug1.Checked == true) { Toughmindness = "1"; } else if (this.Toug2.Checked == true) { Toughmindness = "2"; } else if (Toug3.Checked == true) { Toughmindness = "3"; } else if (Toug4.Checked == true) { Toughmindness = "4"; } else if (Toug5.Checked == true) { Toughmindness = "5"; } else if (Toug6.Checked == true) { Toughmindness = "6"; } else if (Toug7.Checked == true) { Toughmindness = "7"; } else { Toughmindness = "-"; }
                if (adap_1.Checked == true) { Adaptability = "1"; } else if (this.adap_2.Checked == true) { Adaptability = "2"; } else if (adap_3.Checked == true) { Adaptability = "3"; } else if (adap_4.Checked == true) { Adaptability = "4"; } else if (adap_5.Checked == true) { Adaptability = "5"; } else if (adap_6.Checked == true) { Adaptability = "6"; } else if (adap_7.Checked == true) { Adaptability = "7"; } else { Adaptability = "-"; }
                if (pract1.Checked == true) { Practicality = "1"; } else if (this.pract2.Checked == true) { Practicality = "2"; } else if (pract3.Checked == true) { Practicality = "3"; } else if (pract4.Checked == true) { Practicality = "4"; } else if (pract5.Checked == true) { Practicality = "5"; } else if (pract6.Checked == true) { Practicality = "6"; } else if (pract7.Checked == true) { Practicality = "7"; } else { Practicality = "-"; }
                if (aser1.Checked == true) { Assertiveness = "1"; } else if (this.aser2.Checked == true) { Assertiveness = "2"; } else if (aser3.Checked == true) { Assertiveness = "3"; } else if (aser4.Checked == true) { Assertiveness = "4"; } else if (aser5.Checked == true) { Assertiveness = "5"; } else if (aser6.Checked == true) { Assertiveness = "6"; } else if (aser7.Checked == true) { Assertiveness = "7"; } else { Assertiveness = "-"; }
                if (inde1.Checked == true) { Independence = "1"; } else if (this.inde2.Checked == true) { Independence = "2"; } else if (inde3.Checked == true) { Independence = "3"; } else if (inde4.Checked == true) { Independence = "4"; } else if (inde5.Checked == true) { Independence = "5"; } else if (inde6.Checked == true) { Independence = "6"; } else if (inde7.Checked == true) { Independence = "7"; } else { Independence = "-"; }
                if (Resource1.Checked == true) { Resourcefulness = "1"; } else if (this.Resource2.Checked == true) { Resourcefulness = "2"; } else if (Resource3.Checked == true) { Resourcefulness = "3"; } else if (Resource4.Checked == true) { Resourcefulness = "4"; } else if (Resource5.Checked == true) { Resourcefulness = "5"; } else if (Resource6.Checked == true) { Resourcefulness = "6"; } else if (Resource7.Checked == true) { Resourcefulness = "7"; } else { Resourcefulness = "-"; }
                if (rel_1.Checked == true) { Peers = "1"; } else if (this.rel_2.Checked == true) { Peers = "2"; } else if (rel_3.Checked == true) { Peers = "3"; } else if (rel_4.Checked == true) { Peers = "4"; } else if (rel_5.Checked == true) { Peers = "5"; } else if (rel_6.Checked == true) { Peers = "6"; } else if (rel_7.Checked == true) { Peers = "7"; } else { Peers = "-"; }
                if (rel_with_1.Checked == true) { Superiors = "1"; } else if (this.rel_with_2.Checked == true) { Superiors = "2"; } else if (rel_with_3.Checked == true) { Superiors = "3"; } else if (rel_with_4.Checked == true) { Superiors = "4"; } else if (rel_with_5.Checked == true) { Superiors = "5"; } else if (rel_with_6.Checked == true) { Superiors = "6"; } else if (rel_with_7.Checked == true) { Superiors = "7"; } else { Superiors = "-"; }
                if (esteem_1.Checked == true) { Selfesteem = "1"; } else if (this.esteem_2.Checked == true) { Selfesteem = "2"; } else if (esteem_3.Checked == true) { Selfesteem = "3"; } else if (esteem_4.Checked == true) { Selfesteem = "4"; } else if (esteem_5.Checked == true) { Selfesteem = "5"; } else if (esteem_6.Checked == true) { Selfesteem = "6"; } else if (esteem_7.Checked == true) { Selfesteem = "7"; } else { Selfesteem = "-"; }
                if (aggr_1.Checked == true) { Aggresive = "1"; } else if (this.aggr_2.Checked == true) { Aggresive = "2"; } else if (aggr_3.Checked == true) { Aggresive = "3"; } else if (aggr_4.Checked == true) { Aggresive = "4"; } else if (aggr_5.Checked == true) { Aggresive = "5"; } else if (aggr_6.Checked == true) { Aggresive = "6"; } else if (aggr_7.Checked == true) { Aggresive = "7"; } else { Aggresive = "-"; }
                if (direc_1.Checked == true) { Direct = "1"; } else if (this.direc_2.Checked == true) { Direct = "2"; } else if (direc_3.Checked == true) { Direct = "3"; } else if (direc_4.Checked == true) { Direct = "4"; } else if (direc_5.Checked == true) { Direct = "5"; } else if (direc_6.Checked == true) { Direct = "6"; } else if (direc_7.Checked == true) { Direct = "7"; } else { Direct = "-"; }
                if (enthu_1.Checked == true) { Enthu = "1"; } else if (this.enthu_2.Checked == true) { Enthu = "2"; } else if (enthu_3.Checked == true) { Enthu = "3"; } else if (enthu_4.Checked == true) { Enthu = "4"; } else if (enthu_5.Checked == true) { Enthu = "5"; } else if (enthu_6.Checked == true) { Enthu = "6"; } else if (enthu_7.Checked == true) { Enthu = "1"; } else { Enthu = "-"; }
                if (cb_intel_test.Checked == true) { IntelTest = "Y"; } else { IntelTest = "N"; }
                if (this.cb_person_test.Checked == true) { PersonalityTest = "Y"; } else { PersonalityTest = "N"; }
                if (cb_other_test.Checked == true) { Others = "Y"; } else { Others = "N"; }
                if (rb_recomendation.Checked == true) { Recomendation = "1"; } else if (rb_for.Checked == true) { Recomendation = "2"; } else if (rb_not.Checked == true) { Recomendation = "3"; } else { Recomendation = "-"; }




                IniFile ini = new IniFile(ClassSql.MMS_Path);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          //`resultid`,                `type_of_test`,             `intelectual_level`,            `res_persevering`,                    `res_obedient`,            `res_selfdiscipline`,           `res_enthusiastic`,            `res_venturesome`,        `emo_isolation_boredom`,             `emo_noise_vibration_temp`,       `emo_reality`,                `emo_confident`,                `emo_stress`,      `emo_relaxed`,           `obj_realistic`,           `obj_jealousy`,      `obj_adaptable`,         `obj_practicalminded`,          `mot_assertive`,              `mot_independent`,         `mot_resourceful`,               `type_of_test_desc`, `goal_orientation`, `recommendation`, `rec_reservation_desc`, `rec_not_rec_desc`,     `iapa_rel_peer`,     `iapa_rel_superior`,          `iapa_self_esteem`,       `iapa_aggressive_tendencies`,    `intel_test`,                   `intel_result`,                       `person_test`,         `person_result`,                            `other_test`,                 `other_result`,                     `ff_eval_details`,                          `not_rec_details`)
                //string a = "UPDATE `t_psychology` SET   `intelectual_level`='" + intelectual_level.ToString() + "', `res_persevering`='" + persevance.ToString() + "', `res_obedient`='" + obedience.ToString() + "', `res_selfdiscipline`='" + selfDis.ToString() + "', `res_enthusiastic`='" + Enthu.ToString() + "', `res_venturesome`='" + initiative.ToString() + "', `emo_isolation_boredom`='" + boredom.ToString() + "', `emo_noise_vibration_temp`='" + Tolerance.ToString() + "', `emo_reality`='" + FacesReality.ToString() + "', `emo_confident`='" + Confidence.ToString() + "', `emo_relaxed`='" + Relaxed.ToString() + "', `obj_realistic`='" + Toughmindness.ToString() + "',`obj_adaptable`='" + Adaptability.ToString() + "', `obj_practicalminded`='" + Practicality.ToString() + "', `mot_assertive`='" + Assertiveness.ToString() + "', `mot_independent`='" + Independence.ToString() + "', `mot_resourceful`='" + Resourcefulness.ToString() + "',`recommendation`='" + Recomendation.ToString() + "',`iapa_rel_peer`='" + Peers.ToString() + "', `iapa_rel_superior`='" + Superiors.ToString() + "', `iapa_self_esteem`='" + Selfesteem.ToString() + "', `iapa_aggressive_tendencies`='" + Aggresive.ToString() + "', `intel_test`='" + IntelTest.ToString() + "', `intel_result`='" + Tool.ReplaceString(txt_intel_result.Text) + "', `person_test`='" + PersonalityTest.ToString() + "', `person_result`='" + Tool.ReplaceString(txt_person_result.Text) + "', `other_test`='" + Others.ToString() + "', `other_result`='" + Tool.ReplaceString(txt_other_result.Text) + "', `ff_eval_details`='" + Tool.ReplaceString(txt_eval_detail.Text) + "', `not_rec_details`='" + Tool.ReplaceString(txt_Notrec_details.Text) + "', `goal_orientation`='" + Direct.ToString() + "', `result_date`='" + dt_dateExam.Text + "', `pathologist`='" + Tool.ReplaceString(txt_pathologist.Text) + "',pathologist_license='" + Tool.ReplaceString(txt_License2.Text) + "',`fitness_date`='" + dt_testAdministered.Text + "', `medtech`='" + Tool.ReplaceString(txt_medTech.Text) + "', medtech_license= '" + Tool.ReplaceString(txt_License1.Text) + "', Lic_Validity_Medtech = '" + ini.IniReadValue("MEDICAL", "Psychometrician_Validity") + "' , PTR_medTech = '" + ini.IniReadValue("MEDICAL", "Psychometrician_ptr") + "',Lic_Validity_Pathologist='" + ini.IniReadValue("MEDICAL", "Psychologist_Validity") + "', PTR_Pathologist = '" + ini.IniReadValue("MEDICAL", "Psychologist_Ptr") + "' WHERE (`cn`='" + lbl_Psych_Cn.Tag + "') LIMIT 1";
                ////string b =   "UPDATE `t_result_main` SET  `result_date`='" + dt_dateExam.Text + "', `pathologist`='" + Tool.ReplaceString(txt_pathologist.Text) + "',pathologist_license='" + Tool.ReplaceString(txt_License2.Text) + "',`fitness_date`='" + dt_testAdministered.Text + "', `medtech`='" + Tool.ReplaceString(txt_medTech.Text) + "', medtech_license= '" + Tool.ReplaceString(txt_License1.Text) + "', `reference_no`='" + LabID.Text + "' WHERE (`resultid`='" + LabID.Text + "') LIMIT 1";
                ////search_Psych(); search_Medical();
                //var arr = new[] { a };
                //File.WriteAllLines(ClassSql.tmp_path, arr);    

                db.ExecuteCommand("UPDATE t_psychology SET   intelectual_level={0}, res_persevering={1}, res_obedient={2}, res_selfdiscipline={3}, res_enthusiastic={4}, res_venturesome={5}, emo_isolation_boredom={6}, emo_noise_vibration_temp={7}, emo_reality={8}, emo_confident={9}, emo_relaxed={10}, obj_realistic={11},obj_adaptable={12}, obj_practicalminded={13}, mot_assertive={14}, mot_independent={15}, mot_resourceful={16},recommendation={17},iapa_rel_peer={18}, iapa_rel_superior={19}, iapa_self_esteem={20}, iapa_aggressive_tendencies={21}, intel_test={22}, intel_result={23}, person_test={24}, person_result={25}, other_test={26}, other_result={27}, ff_eval_details={28}, not_rec_details={29}, goal_orientation={30}, result_date={31}, pathologist={32},pathologist_license={33},fitness_date={34}, medtech={35}, medtech_license= {36}, Lic_Validity_Medtech = {37} , PTR_medTech = {38},Lic_Validity_Pathologist={39}, PTR_Pathologist = {40} WHERE cn={41}", intelectual_level.ToString(), persevance.ToString(), obedience.ToString(), selfDis.ToString(), Enthu.ToString(), initiative.ToString(), boredom.ToString(), Tolerance.ToString(), FacesReality.ToString(), Confidence.ToString(), Relaxed.ToString(), Toughmindness.ToString(), Adaptability.ToString(), Practicality.ToString(), Assertiveness.ToString(), Independence.ToString(), Resourcefulness.ToString(), Recomendation.ToString(), Peers.ToString(), Superiors.ToString(), Selfesteem.ToString(), Aggresive.ToString(), IntelTest.ToString(), txt_intel_result.Text, PersonalityTest.ToString(), txt_person_result.Text, Others.ToString(), txt_other_result.Text, txt_eval_detail.Text, txt_Notrec_details.Text, Direct.ToString(), dt_dateExam.Text, txt_pathologist.Text, txt_License2.Text, dt_testAdministered.Text, txt_medTech.Text, txt_License1.Text, ini.IniReadValue("MEDICAL", "Psychometrician_Validity"), ini.IniReadValue("MEDICAL", "Psychometrician_ptr"), ini.IniReadValue("MEDICAL", "Psychologist_Validity"), ini.IniReadValue("MEDICAL", "Psychologist_Ptr"), this.lbl_Psych_Cn.Tag.ToString());

                if (!backgroundWorker1.IsBusy)
                {
                    Psychology_model.Clear();
                    backgroundWorker1.RunWorkerAsync();
                }
                //  MessageBox.Show(string.Format("UPDATE t_psychology SET   intelectual_level={0}, res_persevering={1}, res_obedient={2}, res_selfdiscipline={3}, res_enthusiastic={4}, res_venturesome={5}, emo_isolation_boredom={6}, emo_noise_vibration_temp={7}, emo_reality={8}, emo_confident={9}, emo_relaxed={10}, obj_realistic={11},obj_adaptable={12}, obj_practicalminded={13}, mot_assertive={14}, mot_independent={15}, mot_resourceful={16},recommendation={17},iapa_rel_peer={18}, iapa_rel_superior={19}, iapa_self_esteem={20}, iapa_aggressive_tendencies={21}, intel_test={22}, intel_result={23}, person_test={24}, person_result={25}, other_test={26}, other_result={27}, ff_eval_details={28}, not_rec_details={29}, goal_orientation={30}, result_date={31}, pathologist={32},pathologist_license={33},fitness_date={34}, medtech={35}, medtech_license= {36}, Lic_Validity_Medtech = {37} , PTR_medTech = {38},Lic_Validity_Pathologist={39}, PTR_Pathologist = {40} WHERE cn={41}",intelectual_level.ToString() ,persevance.ToString() ,obedience.ToString() ,selfDis.ToString() ,Enthu.ToString() ,initiative.ToString() ,boredom.ToString() ,Tolerance.ToString() ,FacesReality.ToString() ,Confidence.ToString() ,Relaxed.ToString() ,Toughmindness.ToString() ,Adaptability.ToString() ,Practicality.ToString() ,Assertiveness.ToString() ,Independence.ToString() ,Resourcefulness.ToString() ,Recomendation.ToString() ,Peers.ToString() ,Superiors.ToString() ,Selfesteem.ToString() ,Aggresive.ToString() ,IntelTest.ToString() ,txt_intel_result.Text ,PersonalityTest.ToString() ,txt_person_result.Text ,Others.ToString() ,txt_other_result.Text ,txt_eval_detail.Text ,txt_Notrec_details.Text ,Direct.ToString() ,dt_dateExam.Text ,txt_pathologist.Text ,txt_License2.Text ,dt_testAdministered.Text ,txt_medTech.Text ,txt_License1.Text ,ini.IniReadValue("MEDICAL", "Psychometrician_Validity") ,ini.IniReadValue("MEDICAL", "Psychometrician_ptr") ,ini.IniReadValue("MEDICAL", "Psychologist_Validity") ,ini.IniReadValue("MEDICAL", "Psychologist_Ptr") ,this.lbl_Psych_Cn.Tag.ToString()));

                NewPsych_Eval = true;
                fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = true; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = false; fmain.ts_print_Eval.Enabled = true; fmain.ts_search_Eval.Enabled = true;
                //Tool.MessageBoxUpdate();
                Availability(false);
                txt_Papin.Select();
                //search_Medical();
                //search_Psych();
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


        public void createNewPatient()
        {







        }
        private void frm_Psych_Evaluation_Load(object sender, EventArgs e)
        {
            //ClassSql.DbConnect();
            Cursor.Current = Cursors.Default;
            Availability(false);
            txt_Papin.Select();
            if (!backgroundWorker1.IsBusy)
            { backgroundWorker1.RunWorkerAsync(); }


            //Load_Medical();

        }

        private void frm_Psych_Evaluation_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                if (fmain.ts_cancel_Eval.Enabled == true)
                { Cancel(); }
                else
                { this.Close(); }

            }
            else if (e.KeyCode == Keys.Add && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_add_Eval.Enabled == true)
                {

                    fmain.add_psycho();
                }
            }

            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_save_Eval.Enabled == true)
                {
                    Save();

                }

            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_print_Eval.Enabled == true)
                {
                    Print();
                }
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {

                if (fmain.ts_search_Eval.Enabled == true)
                {
                    fmain.Search_Psycho();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (fmain.ts_edit_Eval.Enabled == true)
                {
                    Edit();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (fmain.ts_delete_Eval.Enabled == true)
                {

                    Delete();
                }

            }
        }

        private void frm_Psych_Evaluation_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.Evaulation = true;
            fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_search_Eval.Enabled = true; fmain.ts_print_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = false;
            ClassSql.DbClose();
            //fmain.Strip_sub.Visible = false;
        }

        private void txt_resultID_TextChanged(object sender, EventArgs e)
        {
            //ClearAll();
            //Load_Medical();
            ////search_mlc();


            //if (NewPsych_Eval)
            //{
            //    fmain.ts_add_Eval.Enabled = false; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = true; fmain.ts_cancel_Eval.Enabled = true; fmain.ts_print_Eval.Enabled = false; fmain.ts_search_Eval.Enabled = false;

            //}
            //else
            //{
            //    search_Psych();
            //    search_Medical();
            //    fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = true; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = false; fmain.ts_print_Eval.Enabled = true; fmain.ts_search_Eval.Enabled = true;

            //}



        }


        public void search_Psych()
        {

            try
            {




                //dt = a.Mytable_Proc("Psycho_Detail", "@SearchID", pin.Text);
                // var list = (from m in db.sp_Pshycho_Detail(pin.Text)  select m).Take(1);
                var list = db.sp_Pshycho_Detail(pin.Text);

                foreach (var i in list)
                {
                    lbl_Psych_Cn.Tag = i.cn.ToString();
                    txt_intel_result.Text = i.intel_result.ToString();
                    string type_of_test = i.type_of_test.ToString();
                    string intelectual_level = i.intelectual_level.ToString();
                    if (intelectual_level == "VS") { rb_intelectual_level_Very.Checked = true; } else if (intelectual_level == "SUP") { rb_intelectual_level_Superior.Checked = true; } else if (intelectual_level == "AAVG") { rb_intelectual_level_Above.Checked = true; } else if (intelectual_level == "AVG") { rb_intelectual_level_Average.Checked = true; } else if (intelectual_level == "BAVG") { rb_intelectual_level_Below.Checked = true; } else if (intelectual_level == "BL") { rb_intelectual_level_BorderLine.Checked = true; } else if (intelectual_level == "M") { rb_mentally.Checked = true; }
                    string res_persevering = i.res_persevering.ToString();
                    if (res_persevering == "1") { per_1.Checked = true; } else if (res_persevering == "2") { per_2.Checked = true; } else if (res_persevering == "3") { per_3.Checked = true; } else if (res_persevering == "4") { per_4.Checked = true; } else if (res_persevering == "5") { per_5.Checked = true; } else if (res_persevering == "6") { per_6.Checked = true; } else if (res_persevering == "7") { per_7.Checked = true; }
                    string res_obedient = i.res_obedient.ToString();
                    if (res_obedient == "1") { obi_1.Checked = true; } else if (res_obedient == "2") { obi_2.Checked = true; } else if (res_obedient == "3") { obi_3.Checked = true; } else if (res_obedient == "4") { obi_4.Checked = true; } else if (res_obedient == "5") { obi_5.Checked = true; } else if (res_obedient == "6") { obi_6.Checked = true; } else if (res_obedient == "7") { obi_7.Checked = true; }
                    string res_selfdiscipline = i.res_selfdiscipline.ToString();
                    if (res_selfdiscipline == "1") { self_1.Checked = true; } else if (res_selfdiscipline == "2") { self_2.Checked = true; } else if (res_selfdiscipline == "3") { self_3.Checked = true; } else if (res_selfdiscipline == "4") { self_4.Checked = true; } else if (res_selfdiscipline == "5") { self_5.Checked = true; } else if (res_selfdiscipline == "6") { self_6.Checked = true; } else if (res_selfdiscipline == "7") { self_7.Checked = true; }
                    string res_enthusiastic = i.res_enthusiastic.ToString();
                    if (res_enthusiastic == "1") { enthu_1.Checked = true; } else if (res_enthusiastic == "2") { enthu_2.Checked = true; } else if (res_enthusiastic == "3") { enthu_3.Checked = true; } else if (res_enthusiastic == "4") { enthu_4.Checked = true; } else if (res_enthusiastic == "5") { enthu_5.Checked = true; } else if (res_enthusiastic == "6") { enthu_6.Checked = true; } else if (res_enthusiastic == "7") { enthu_7.Checked = true; }
                    string res_venturesome = i.res_venturesome.ToString();
                    if (res_venturesome == "1") { ini_1.Checked = true; } else if (res_venturesome == "2") { ini_2.Checked = true; } else if (res_venturesome == "3") { ini_3.Checked = true; } else if (res_venturesome == "4") { ini_4.Checked = true; } else if (res_venturesome == "5") { ini_5.Checked = true; } else if (res_venturesome == "6") { ini_6.Checked = true; } else if (res_venturesome == "7") { ini_7.Checked = true; }
                    string emo_isolation_boredom = i.emo_isolation_boredom.ToString();
                    if (emo_isolation_boredom == "1") { can_1.Checked = true; } else if (emo_isolation_boredom == "2") { can_2.Checked = true; } else if (emo_isolation_boredom == "3") { can_3.Checked = true; } else if (emo_isolation_boredom == "4") { can_4.Checked = true; } else if (emo_isolation_boredom == "5") { can_5.Checked = true; } else if (emo_isolation_boredom == "6") { can_6.Checked = true; } else if (emo_isolation_boredom == "7") { can_7.Checked = true; }
                    string emo_noise_vibration_temp = i.emo_noise_vibration_temp.ToString();
                    if (emo_noise_vibration_temp == "1") { tol_1.Checked = true; } else if (emo_noise_vibration_temp == "2") { tol_2.Checked = true; } else if (emo_noise_vibration_temp == "3") { tol_3.Checked = true; } else if (emo_noise_vibration_temp == "4") { tol_4.Checked = true; } else if (emo_noise_vibration_temp == "5") { tol_5.Checked = true; } else if (emo_noise_vibration_temp == "6") { tol_6.Checked = true; } else if (emo_noise_vibration_temp == "7") { tol_7.Checked = true; }
                    string emo_reality = i.emo_reality.ToString();
                    if (emo_reality == "1") { face_1.Checked = true; } else if (emo_reality == "2") { face_2.Checked = true; } else if (emo_reality == "3") { face_3.Checked = true; } else if (emo_reality == "4") { face_4.Checked = true; } else if (emo_reality == "5") { face_5.Checked = true; } else if (emo_reality == "6") { face_6.Checked = true; } else if (emo_reality == "7") { face_7.Checked = true; }
                    string emo_confident = i.emo_confident.ToString();
                    if (emo_confident == "1") { con_1.Checked = true; } else if (emo_confident == "2") { con_2.Checked = true; } else if (emo_confident == "3") { con_3.Checked = true; } else if (emo_confident == "4") { con_4.Checked = true; } else if (emo_confident == "5") { con_5.Checked = true; } else if (emo_confident == "6") { con_6.Checked = true; } else if (emo_confident == "7") { con_7.Checked = true; }
                    string emo_relaxed = i.emo_relaxed.ToString();
                    if (emo_relaxed == "1") { relax_1.Checked = true; } else if (emo_relaxed == "2") { relax_2.Checked = true; } else if (emo_relaxed == "3") { relax_3.Checked = true; } else if (emo_relaxed == "4") { relax_4.Checked = true; } else if (emo_relaxed == "5") { relax_5.Checked = true; } else if (emo_relaxed == "6") { relax_6.Checked = true; } else if (emo_relaxed == "7") { relax_7.Checked = true; }
                    string obj_realistic = i.obj_realistic.ToString();
                    if (obj_realistic == "1") { Toug1.Checked = true; } else if (obj_realistic == "2") { Toug2.Checked = true; } else if (obj_realistic == "3") { Toug3.Checked = true; } else if (obj_realistic == "4") { Toug4.Checked = true; } else if (obj_realistic == "5") { Toug5.Checked = true; } else if (obj_realistic == "6") { Toug6.Checked = true; } else if (obj_realistic == "7") { Toug7.Checked = true; }
                    string obj_adaptable = i.obj_adaptable.ToString();
                    if (obj_adaptable == "1") { adap_1.Checked = true; } else if (obj_adaptable == "2") { adap_2.Checked = true; } else if (obj_adaptable == "3") { adap_3.Checked = true; } else if (obj_adaptable == "4") { adap_4.Checked = true; } else if (obj_adaptable == "5") { adap_5.Checked = true; } else if (obj_adaptable == "6") { adap_6.Checked = true; } else if (obj_adaptable == "7") { adap_7.Checked = true; }
                    string obj_practicalminded = i.obj_practicalminded.ToString();
                    if (obj_practicalminded == "1") { pract1.Checked = true; } else if (obj_practicalminded == "2") { pract2.Checked = true; } else if (obj_practicalminded == "3") { pract3.Checked = true; } else if (obj_practicalminded == "4") { pract4.Checked = true; } else if (obj_practicalminded == "5") { pract5.Checked = true; } else if (obj_practicalminded == "6") { pract6.Checked = true; } else if (obj_practicalminded == "7") { pract7.Checked = true; }
                    string mot_assertive = i.mot_assertive.ToString();
                    if (mot_assertive == "1") { aser1.Checked = true; } else if (mot_assertive == "2") { aser2.Checked = true; } else if (mot_assertive == "3") { aser3.Checked = true; } else if (mot_assertive == "4") { aser4.Checked = true; } else if (mot_assertive == "5") { aser5.Checked = true; } else if (mot_assertive == "6") { aser6.Checked = true; } else if (mot_assertive == "7") { aser7.Checked = true; }
                    string mot_independent = i.mot_independent.ToString();
                    if (mot_independent == "1") { inde1.Checked = true; } else if (mot_independent == "2") { inde2.Checked = true; } else if (mot_independent == "3") { inde3.Checked = true; } else if (mot_independent == "4") { inde4.Checked = true; } else if (mot_independent == "5") { inde5.Checked = true; } else if (mot_independent == "6") { inde6.Checked = true; } else if (mot_independent == "7") { inde7.Checked = true; }
                    string mot_resourceful = i.mot_resourceful.ToString();
                    if (mot_resourceful == "1") { Resource1.Checked = true; } else if (mot_resourceful == "2") { Resource2.Checked = true; } else if (mot_resourceful == "3") { Resource3.Checked = true; } else if (mot_resourceful == "4") { Resource4.Checked = true; } else if (mot_resourceful == "5") { Resource5.Checked = true; } else if (mot_resourceful == "6") { Resource6.Checked = true; } else if (mot_resourceful == "7") { Resource7.Checked = true; }
                    string goal_orientation = i.goal_orientation.ToString();
                    if (goal_orientation == "1") { direc_1.Checked = true; } else if (goal_orientation == "2") { direc_2.Checked = true; } else if (goal_orientation == "3") { direc_3.Checked = true; } else if (goal_orientation == "4") { direc_4.Checked = true; } else if (goal_orientation == "5") { direc_5.Checked = true; } else if (goal_orientation == "6") { direc_6.Checked = true; } else if (goal_orientation == "7") { direc_7.Checked = true; }
                    string recommendation = i.recommendation.ToString();
                    if (recommendation == "1") { rb_recomendation.Checked = true; } else if (recommendation == "2") { rb_for.Checked = true; } else if (recommendation == "3") { rb_not.Checked = true; }
                    string iapa_rel_peer = i.iapa_rel_peer.ToString();
                    if (iapa_rel_peer == "1") { rel_1.Checked = true; } else if (iapa_rel_peer == "2") { rel_2.Checked = true; } else if (iapa_rel_peer == "3") { rel_3.Checked = true; } else if (iapa_rel_peer == "4") { rel_4.Checked = true; } else if (iapa_rel_peer == "5") { rel_5.Checked = true; } else if (iapa_rel_peer == "6") { rel_6.Checked = true; } else if (iapa_rel_peer == "7") { rel_7.Checked = true; }
                    string iapa_rel_superior = i.iapa_rel_superior.ToString();
                    if (iapa_rel_superior == "1") { rel_with_1.Checked = true; } else if (iapa_rel_superior == "2") { rel_with_2.Checked = true; } else if (iapa_rel_superior == "3") { rel_with_3.Checked = true; } else if (iapa_rel_superior == "4") { rel_with_4.Checked = true; } else if (iapa_rel_superior == "5") { rel_with_5.Checked = true; } else if (iapa_rel_superior == "6") { rel_with_6.Checked = true; } else if (iapa_rel_superior == "7") { rel_with_7.Checked = true; }
                    string iapa_self_esteem = i.iapa_self_esteem.ToString();
                    if (iapa_self_esteem == "1") { esteem_1.Checked = true; } else if (iapa_self_esteem == "2") { esteem_2.Checked = true; } else if (iapa_self_esteem == "3") { esteem_3.Checked = true; } else if (iapa_self_esteem == "4") { esteem_4.Checked = true; } else if (iapa_self_esteem == "5") { esteem_5.Checked = true; } else if (iapa_self_esteem == "6") { esteem_6.Checked = true; } else if (iapa_self_esteem == "7") { esteem_7.Checked = true; }
                    string iapa_aggressive_tendencies = i.iapa_aggressive_tendencies.ToString();
                    if (iapa_aggressive_tendencies == "1") { aggr_1.Checked = true; } else if (iapa_aggressive_tendencies == "2") { aggr_2.Checked = true; } else if (iapa_aggressive_tendencies == "3") { aggr_3.Checked = true; } else if (iapa_aggressive_tendencies == "4") { aggr_4.Checked = true; } else if (iapa_aggressive_tendencies == "5") { aggr_5.Checked = true; } else if (iapa_aggressive_tendencies == "6") { aggr_6.Checked = true; } else if (iapa_aggressive_tendencies == "7") { aggr_7.Checked = true; }

                    string intel_test = i.intel_test.ToString();
                    if (intel_test == "Y") { cb_intel_test.Checked = true; } else { cb_intel_test.Checked = false; }


                    string person_test = i.person_test.ToString();
                    if (person_test == "Y") { this.cb_person_test.Checked = true; } else { cb_person_test.Checked = false; }

                    txt_person_result.Text = i.person_result.ToString();


                    string other_test = i.other_test.ToString();
                    if (other_test == "Y") { cb_other_test.Checked = true; } else { cb_other_test.Checked = false; }

                    txt_other_result.Text = i.other_result.ToString();

                    txt_eval_detail.Text = i.ff_eval_details.ToString();

                    txt_Notrec_details.Text = i.not_rec_details.ToString();

                    txt_medTech.Text = i.medtech.ToString();
                    txt_pathologist.Text = i.pathologist.ToString();
                    txt_License1.Text = i.medtech_license.ToString();
                    txt_License2.Text = i.pathologist_license.ToString();
                    DateTime temp1;
                    if (DateTime.TryParse(i.result_date.ToString(), out temp1))
                    {
                        dt_dateExam.Format = DateTimePickerFormat.Custom;
                        dt_dateExam.CustomFormat = "MM/dd/yyyy";

                        dt_dateExam.Value = Convert.ToDateTime(i.result_date.ToString()).Date;
                    }

                    DateTime temp2;
                    if (DateTime.TryParse(i.fitness_date.ToString(), out temp2))
                    {
                        dt_testAdministered.Format = DateTimePickerFormat.Custom;
                        dt_testAdministered.CustomFormat = "MM/dd/yyyy";

                        dt_testAdministered.Value = Convert.ToDateTime(i.fitness_date.ToString()).Date;
                    }
                    else
                    {

                        dt_testAdministered.Format = DateTimePickerFormat.Custom;
                        dt_testAdministered.CustomFormat = "00/00/0000";

                    }

                    Lic_validity_Medtech.Text = i.Lic_Validity_Medtech.ToString();
                    PTR_medtech.Text = i.PTR_medTech.ToString();
                    Lic_Validity_Patho.Text = i.Lic_Validity_Pathologist.ToString();
                    PTR_Patho.Text = i.PTR_Pathologist.ToString();




                }

                if (rb_for.Checked == true) { txt_eval_detail.Visible = true; } else { txt_eval_detail.Visible = false; }
                if (rb_not.Checked == true) { txt_Notrec_details.Visible = true; } else { txt_Notrec_details.Visible = false; }



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


        public void Search_Patient()
        {
            try
            {



                //ClassSql a = new ClassSql(); DataTable dt;
                //dt = a.Mytable_Proc("Psycho_patient", "@SearchID", pin.Text);
                var i = db.sp_psycho_Patient(pin.Text).FirstOrDefault();
                //foreach (DataRow dr in dt.Rows)
                //{

                txtName.Text = i.PatientName.ToString();
                //dt_bday.Text = dr["birthdate"].ToString();

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
                txt_employer.Text = i.employer.ToString();
                txt_position.Text = i.position.ToString();

                //}



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



        }




        public void Availability(bool bl)
        {

            if (bl == true)
            { overlayShadow1.Visible = false; overlayShadow1.SendToBack(); }
            else
            { overlayShadow1.Visible = true; overlayShadow1.BringToFront(); }

        }

        void Cursorhand()
        {

            Tool.SetCursor(panel29);
            //Tool.SetCursor(panel1);
            Tool.SetCursor(ntel_test);
            Tool.SetCursor(panel3);
            Tool.SetCursor(panel4);
            Tool.SetCursor(panel24);
            Tool.SetCursor(panel27);
            Tool.SetCursor(panel25);
            Tool.SetCursor(panel26);
            //Tool.SetCursor(panel20);
            //Tool.SetCursor(panel23);
            Tool.SetCursor(panel21);
            Tool.SetCursor(panel22);
            Tool.SetCursor(panel16);
            Tool.SetCursor(panel19);
            Tool.SetCursor(panel17);
            Tool.SetCursor(panel18);
            //Tool.SetCursor(panel12);
            Tool.SetCursor(panel15);
            Tool.SetCursor(panel13);
            Tool.SetCursor(panel14);
            Tool.SetCursor(panel8);
            Tool.SetCursor(panel11);
            Tool.SetCursor(panel9);
            //Tool.SetCursor(panel10);
            Tool.SetCursor(panel6);
            Tool.SetCursor(panel7);
            Tool.SetCursor(panel5);
            Tool.SetCursor(panel28);
            Tool.SetCursor(panel29);


        }





        public void ClearAll()
        {
            Tool.ClearFields(panel29);
            //Tool.ClearFields(panel1);
            Tool.ClearFields(ntel_test);
            Tool.ClearFields(panel3);
            Tool.ClearFields(panel4);
            Tool.ClearFields(panel24);
            Tool.ClearFields(panel27);
            Tool.ClearFields(panel25);
            Tool.ClearFields(panel26);
            //Tool.ClearFields(panel20);
            //Tool.ClearFields(panel23);
            Tool.ClearFields(panel21);
            Tool.ClearFields(panel22);
            Tool.ClearFields(panel16);
            Tool.ClearFields(panel19);
            Tool.ClearFields(panel17);
            Tool.ClearFields(panel18);
            //Tool.ClearFields(panel12);
            Tool.ClearFields(panel15);
            Tool.ClearFields(panel13);
            Tool.ClearFields(panel14);
            Tool.ClearFields(panel8);
            Tool.ClearFields(panel11);
            Tool.ClearFields(panel9);
            //Tool.ClearFields(panel10);
            Tool.ClearFields(panel6);
            Tool.ClearFields(panel7);
            Tool.ClearFields(panel5);
            Tool.ClearFields(panel28);
            Tool.ClearFields(panel29);

        }


        private void txt_Papin_TextChanged(object sender, EventArgs e)
        {


        }


        //public   void search_Medical()
        //   {

        //       try
        //       {


        //           ClassSql a = new ClassSql(); DataTable dt;
        //           dt = a.Mytable_Proc("Psycho_medical", "@SearchID", LabID.Text);
        //           foreach (DataRow dr in dt.Rows)
        //           {
        //               lbl_medical_cn.Tag = dr["cn"].ToString();
        //               txt_medTech.Text = dr["medtech"].ToString();
        //               txt_pathologist.Text = dr["pathologist"].ToString();
        //               txt_License1.Text = dr["medtech_license"].ToString();
        //               txt_License2.Text = dr["pathologist_license"].ToString();                  
        //               DateTime temp1;
        //               if (DateTime.TryParse(dr["result_date"].ToString(), out temp1))
        //               {
        //                   dt_dateExam.Format = DateTimePickerFormat.Custom;
        //                   dt_dateExam.CustomFormat = "MM/dd/yyyy";

        //                   dt_dateExam.Value = Convert.ToDateTime(dr["result_date"].ToString()).Date;
        //               }                  

        //               DateTime temp2;
        //               if (DateTime.TryParse(dr["fitness_date"].ToString(), out temp2))
        //               {
        //                   dt_testAdministered.Format = DateTimePickerFormat.Custom;
        //                   dt_testAdministered.CustomFormat = "MM/dd/yyyy";

        //                   dt_testAdministered.Value = Convert.ToDateTime(dr["fitness_date"].ToString()).Date;
        //               }
        //               else
        //               {

        //                   dt_testAdministered.Format = DateTimePickerFormat.Custom;
        //                   dt_testAdministered.CustomFormat = "00/00/0000";

        //               }                   

        //           }

        //       }
        //       catch (Exception ex)
        //       {
        //           MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //       }


        //   }


        private void rb_not_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_not.Checked == true) { txt_Notrec_details.Visible = true; } else { txt_Notrec_details.Visible = false; txt_Notrec_details.Clear(); }
        }

        private void rb_for_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_for.Checked == true) { txt_eval_detail.Visible = true; } else { txt_eval_detail.Visible = false; txt_eval_detail.Clear(); }
        }

        private void dt_testAdministered_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_testAdministered.Format = DateTimePickerFormat.Custom;
                dt_testAdministered.CustomFormat = "00/00/0000";
            }
        }

        private void dt_testAdministered_MouseDown(object sender, MouseEventArgs e)
        {
            dt_testAdministered.Format = DateTimePickerFormat.Custom;
            dt_testAdministered.CustomFormat = "MM/dd/yyyy";
            //dt_testAdministered.Value = DateTime.Now;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
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

        private void dt_dateExam_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void dt_testAdministered_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void cmd_load1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_medTech;
                f.txt_license = txt_License1;
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frm_MedicalPersonnel f = new frm_MedicalPersonnel())
            {
                f.txt_medic = txt_pathologist;
                f.txt_license = txt_License2;
                f.ShowDialog();
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var list = db.sp_PsychoSearchList("%").ToList();

                foreach (var i in list)
                {
                    Psychology_model.Add(new Psychology_Model
                    {
                        cn = i.cn,
                        papin = i.papin,
                        PatientName = i.PatientName
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
            //try
            //{
            //    if ((Application.OpenForms["frm_search_Psych_Eval"] as frm_search_Psych_Eval) != null)
            //    {

            //        (Application.OpenForms["frm_search_Psych_Eval"] as frm_search_Psych_Eval).FillDataGridView();
            //    }




            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            //}


        }





    }
}
