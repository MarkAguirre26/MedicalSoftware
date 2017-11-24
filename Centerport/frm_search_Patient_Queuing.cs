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
using System.IO;
using System.Threading;
using Centerport.Class;


namespace Centerport
{
    public partial class frm_search_Patient_Queuing : Form
    {
        public int Papin; public bool Sea_mlc; public bool tumor; public bool ultraS; public bool queue; public bool Landbase; public bool lab; public bool seafarer; public bool mlc; public bool Psych_Evaluation; public bool xray; public bool hiv;
        Main fmain; private string Patient_cn;
        private string NameForSearch = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        public List<QueueSearchList_Model> queueSearchList_Model = new List<QueueSearchList_Model>();

        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);

        public bool isfromVisit = false;

        private DataTable dt_Queue;
        public frm_search_Patient_Queuing(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }

        private void cmd_cnacel_Click(object sender, EventArgs e)
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
        private void cmd_addnew_Click(object sender, EventArgs e)
        {

            frm_addPatient f_addPatient = new frm_addPatient();
            f_addPatient.ShowDialog();


        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    using (MemoryStream mStream = new MemoryStream(byteArrayIn))
        //    {
        //        return Image.FromStream(mStream);
        //    }
        //}




        void loadImage()
        {


            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);

                //  ClassSql a = new ClassSql(); DataTable dt;
                // dt = a.Table("Select picture  from m_patient where cn = '" + dg_result.SelectedRows[0].Cells[0].Value.ToString() + "'");

                var list = db.Select_Patient_pic(dg_result.SelectedRows[0].Cells[0].Value.ToString()).ToList();
                if (list.Count() >= 1)
                {
                    foreach (var i in list)
                    {

                        //byte[] pic_array = (byte[])i.picture.ToArray();
                        //MemoryStream stream = new MemoryStream(pic_array);
                        //stream.Seek(0, SeekOrigin.Begin);
                        //MemoryStream mstream = new MemoryStream();
                        //mstream.Write(pic_array, 0, Convert.ToInt32(pic_array.Length));
                        //Bitmap bm = new Bitmap(mstream, false);
                        //mstream.Dispose();
                        pic_.Image = Tool.bytetoimage(i.picture.ToArray());
                    }
                }
                else
                {
                    //pic_.Image = null;
                    pic_.Image = Properties.Resources.AnonymousPic;
                    pic_.BackgroundImage = Properties.Resources.AnonymousPic;

                }

            }
            catch //(Exception ex)
            {
                // MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                pic_.Image = Properties.Resources.AnonymousPic;
                pic_.BackgroundImage = Properties.Resources.AnonymousPic;
            }



        }


        private void cmd_clear_criteria_Click(object sender, EventArgs e)
        {
            txt_Search.Clear(); txt_Search.Select();
            pic_.Image = Properties.Resources.AnonymousPic;
            pic_.BackgroundImage = Properties.Resources.AnonymousPic;
        }


        private void frm_search_Patient_Queuing_Load(object sender, EventArgs e)
        {

            txt_Search.Select();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }


        }


        //void Searach()
        //{

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(ClassSql.ConnString))
        //        {
        //            conn.Open();
        //            ClassSql a = new ClassSql(); DataTable dt;
        //            dt = a.Mytable_Proc("Search_patient_Add_a", "@ID", Tool.ReplaceString(txt_Search.Text));
        //            dg_result.Rows.Clear();
        //            Cursor.Current = Cursors.WaitCursor;
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                string Name = dr["lastname"].ToString() + ", " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
        //                string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(), Name.ToString(), dr["gender"].ToString() };
        //                dg_result.Rows.Add(rows);
        //                //  txtcount.Text = "Item(s): "+ dg_searresult.Rows.Count.ToString();

        //            }

        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //        Cursor.Current = Cursors.Default;
        //    }




        //}





        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (queue)
                {

                    using (frm_VisitDetail f_detail = new frm_VisitDetail(this))
                    {
                        f_detail.Tag = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        f_detail.ShowDialog();

                    }



                }

                else if (lab)
                {


                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    var cnt = db.sp_CountPatient(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_lab.newlab = false;
                            frm_lab.LabId.Clear();
                            // a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'LAB'", frm_lab.LabId, "resultid");
                            var i = db.sp_Que_Lab(pin.ToString()).FirstOrDefault();
                            frm_lab.LabId.Text = i.resultid;
                            frm_lab.Patient_pin.Clear();
                            frm_lab.Patient_pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                            (Application.OpenForms["frm_lab"] as frm_lab).Search_Patient();
                            (Application.OpenForms["frm_lab"] as frm_lab).Search_lab();
                            (Application.OpenForms["frm_lab"] as frm_lab).Search_Hema();
                            (Application.OpenForms["frm_lab"] as frm_lab).Search_Chemistry();
                            (Application.OpenForms["frm_lab"] as frm_lab).Search_Urinalysis();
                            (Application.OpenForms["frm_lab"] as frm_lab).Search_Fecalysis();
                            (Application.OpenForms["frm_lab"] as frm_lab).Availability(true);
                            fmain.ts_add_lab.Enabled = false; fmain.ts_edit_lab.Enabled = false; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = true; fmain.ts_search_lab.Enabled = false; fmain.ts_print_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = true;

                            this.Close();
                        }
                        else
                        {
                            lab = true;


                        }

                    }
                    else
                    {
                        frm_lab.LabId.Clear();
                        var i = db.sp_QueeLab_GenerateID().FirstOrDefault();
                        //frm_lab.LabId.Text = ClassSql.Generate_ResultID("SELECT t_result_main.resultid FROM t_result_main WHERE t_result_main.resulttype =  'LAB'  ORDER BY t_result_main.cn DESC LIMIT 1", "resultid", "LAB00");
                        frm_lab.LabId.Text = i.generated_id;
                        frm_lab.Patient_pin.Clear();
                        frm_lab.Patient_pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();

                        (Application.OpenForms["frm_lab"] as frm_lab).Availability(true);
                        (Application.OpenForms["frm_lab"] as frm_lab).ClearAll();
                        (Application.OpenForms["frm_lab"] as frm_lab).Search_Patient();
                        (Application.OpenForms["frm_lab"] as frm_lab).New();
                        fmain.ts_add_lab.Enabled = false; fmain.ts_edit_lab.Enabled = false; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = true; fmain.ts_search_lab.Enabled = false; fmain.ts_print_lab.Enabled = false; fmain.ts_cancel_lab.Enabled = true;

                        this.Close();

                    }



                }
                else if (Landbase)
                {
                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //ClassSql a = new ClassSql();
                    //long cnt;
                    //cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'LAND'");
                    var cnt = db.sp_Quee_Landabase(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_Landbase.newLandbase = false;
                            frm_Landbase.LabID.Clear();
                            //  a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'LAND'", frm_Landbase.LabID, "resultid");
                            var i = db.sp_QueeLand_putText(pin.ToString()).FirstOrDefault();
                            frm_Landbase.LabID.Text = i.resultid;
                            frm_Landbase.Text_papin.Clear();
                            frm_Landbase.Text_papin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_Patient();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_MedicalHistory();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_medicalHistory2();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_PhyExam();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_others();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).search_Ancillary();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).search_Recomendation();
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).Availability(true);
                            (Application.OpenForms["frm_Landbase"] as frm_Landbase).dt_valid_until.Text = DateTime.Now.AddYears(1).ToShortDateString();
                            //(Application.OpenForms["frm_Landbase"] as frm_Landbase).ClearAll();
                            //fmain.ts_add_land.Enabled = true; fmain.ts_edit_land.Enabled = true; fmain.ts_delete_land.Enabled = false; fmain.ts_save_land.Enabled = false; fmain.ts_search_land.Enabled = true; fmain.ts_print_land.Enabled = true; fmain.ts_cancel_land.Enabled = false;
                            fmain.ts_add_land.Enabled = false; fmain.ts_edit_land.Enabled = false; fmain.ts_delete_land.Enabled = false; fmain.ts_save_land.Enabled = true; fmain.ts_search_land.Enabled = false; fmain.ts_print_land.Enabled = false; fmain.ts_cancel_land.Enabled = true;



                            this.Close();

                        }
                        else
                        {
                            Landbase = true;


                        }

                    }
                    else
                    {
                        frm_Landbase.LabID.Clear();
                        //   frm_Landbase.LabID.Text = ClassSql.Generate_ResultID("SELECT t_med_history.resultid FROM t_med_history WHERE t_med_history.resultid LIKE  '%LAND%' ORDER BY t_med_history.cn DESC LIMIT 1", "resultid", "LAND00");
                        var i = db.sp_QueeLandbase_GenerateID().FirstOrDefault();
                        frm_Landbase.LabID.Text = i.generated_id;
                        frm_Landbase.Text_papin.Clear();
                        frm_Landbase.Text_papin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        frm_Landbase.Count = false;
                        (Application.OpenForms["frm_Landbase"] as frm_Landbase).Availability(true);
                        (Application.OpenForms["frm_Landbase"] as frm_Landbase).ClearAll();
                        (Application.OpenForms["frm_Landbase"] as frm_Landbase).New();
                        (Application.OpenForms["frm_Landbase"] as frm_Landbase).CheckedallNo();
                        (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_Patient();
                        (Application.OpenForms["frm_Landbase"] as frm_Landbase).dt_valid_until.Text = DateTime.Now.AddYears(1).ToShortDateString();
                        fmain.ts_add_land.Enabled = false; fmain.ts_edit_land.Enabled = false; fmain.ts_delete_land.Enabled = false; fmain.ts_save_land.Enabled = true; fmain.ts_search_land.Enabled = false; fmain.ts_print_land.Enabled = false; fmain.ts_cancel_land.Enabled = true;


                        this.Close();


                    }



                }
                else if (seafarer)
                {

                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //ClassSql a = new ClassSql(); 
                    //long cnt;
                    //cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'SEA'");
                    var cnt = db.sp_Seafarer_CountColumn(pin.ToString()).FirstOrDefault();
                    if (cnt.patientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_seafarer_MEC.NewSeabase = false;
                            frm_seafarer_MEC.LabID.Clear();
                            // a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'SEA' order by t_result_main.cn DESC limit 1", frm_seafarer_MEC.LabID, "resultid");
                            var i = db.sp_Seafarer_PutText(pin.ToString()).FirstOrDefault();
                            frm_seafarer_MEC.LabID.Text = i.resultid;
                            frm_seafarer_MEC.pin.Clear();
                            frm_seafarer_MEC.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();


                            //if (System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] != null)
                            //                 {
                            //(System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();

                            //                 }

                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_MedicalHistory();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_medicalHistory2();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_PhyExam();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_others();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).search_Ancillary();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).search_Recomendation();
                            //(Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).search_RecomendationFromSearch();
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Availability(true);
                            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).dt_validUntil.Text = DateTime.Now.AddYears(2).ToShortDateString();
                            //(Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).ClearAll();
                            // fmain.ts_add_sea.Enabled = true; fmain.ts_edit_sea.Enabled = true; fmain.ts_delete_sea.Enabled = false; fmain.ts_save_sea.Enabled = false; fmain.ts_search_sea.Enabled = true; fmain.ts_print_sea.Enabled = true; fmain.ts_cancel_sea.Enabled = false;
                            fmain.ts_add_sea.Enabled = false; fmain.ts_edit_sea.Enabled = false; fmain.ts_delete_sea.Enabled = false; fmain.ts_save_sea.Enabled = true; fmain.ts_search_sea.Enabled = false; fmain.ts_print_sea.Enabled = false; fmain.ts_cancel_sea.Enabled = true;

                            this.Close();
                        }
                        else
                        {
                            seafarer = true;


                        }

                    }
                    else
                    {
                        frm_seafarer_MEC.LabID.Clear();
                        //   frm_seafarer_MEC.LabID.Text = ClassSql.Generate_ResultID("SELECT t_med_history.resultid FROM t_med_history WHERE t_med_history.resultid LIKE  '%SEA%' ORDER BY t_med_history.cn DESC LIMIT 1", "resultid", "SEA00");
                        var i = db.sp_QueeSeabase_GenerateID().FirstOrDefault();
                        frm_seafarer_MEC.LabID.Text = i.generated_id;
                        frm_seafarer_MEC.pin.Clear();
                        frm_seafarer_MEC.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Availability(true);
                        (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).ClearAll();
                        (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();
                        (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).checkedNo();
                        (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).New();
                        (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).dt_validUntil.Text = DateTime.Now.AddYears(2).ToShortDateString();
                        fmain.ts_add_sea.Enabled = false; fmain.ts_edit_sea.Enabled = false; fmain.ts_delete_sea.Enabled = false; fmain.ts_save_sea.Enabled = true; fmain.ts_search_sea.Enabled = false; fmain.ts_print_sea.Enabled = false; fmain.ts_cancel_sea.Enabled = true;

                        this.Close();

                    }


                }
                else if (Sea_mlc)
                {

                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //ClassSql a = new ClassSql();
                    //long cnt;
                    // cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'SEAMLC'");
                    var cnt = db.sp_SeaMLC_CountColumn(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_Seafarer_MLC.NewSeafarer = false;
                            frm_Seafarer_MLC.LabID.Clear();
                            //  a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'SEAMLC' order by t_result_main.cn DESC", frm_Seafarer_MLC.LabID, "resultid");
                            var i = db.sp_SeaMLC_putText(pin.ToString()).FirstOrDefault();
                            frm_Seafarer_MLC.LabID.Text = i.resultid;
                            frm_Seafarer_MLC.pin.Clear();
                            frm_Seafarer_MLC.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();


                            //if (System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] != null)
                            //                 {
                            //(System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();

                            //                 }

                            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Search_Patient();
                            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Search_PhyExam();
                            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).search_Recomendation();
                            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).GetSpecimenNumber();
                            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Availability(true);
                            (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).dt_ValidUntil.Text = DateTime.Now.AddYears(2).ToShortDateString();
                            fmain.ts_add_mlc.Enabled = false; fmain.ts_edit_mlc.Enabled = false; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = true; fmain.ts_search_mlc.Enabled = false; fmain.ts_print_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = true;

                            this.Close();
                        }
                        else
                        {
                            Sea_mlc = true;


                        }

                    }
                    else
                    {
                        frm_Seafarer_MLC.LabID.Clear();
                        // frm_Seafarer_MLC.LabID.Text = ClassSql.Generate_ResultID("SELECT t_phy_exam.resultid FROM t_phy_exam WHERE t_phy_exam.resultid LIKE  '%SEAMLC%' ORDER BY t_phy_exam.cn DESC LIMIT 1 ", "resultid", "SEAMLC00");
                        var i = db.sp_QueeMLC_GenerateID().FirstOrDefault();
                        frm_Seafarer_MLC.LabID.Text = i.generated_id;
                        frm_Seafarer_MLC.pin.Clear();
                        frm_Seafarer_MLC.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Availability(true);
                        (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).ClearGroupBox();
                        (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Search_Patient();
                        (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).GetSpecimenNumber();
                        (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).New();
                        (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).dt_ValidUntil.Text = DateTime.Now.AddYears(2).ToShortDateString();
                        fmain.ts_add_mlc.Enabled = false; fmain.ts_edit_mlc.Enabled = false; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = true; fmain.ts_search_mlc.Enabled = false; fmain.ts_print_mlc.Enabled = false; fmain.ts_cancel_mlc.Enabled = true;

                        this.Close();

                    }







                }
                else if (ultraS)
                {

                    //.pin.Clear();
                    //frm_Ultrasound.LabID.Clear();
                    //frm_Ultrasound.LabID.Text = ClassSql.Generate_ResultID("SELECT t_radiology.resultid  FROM t_radiology ORDER BY t_radiology.resultid DESC LIMIT 1", "resultid", "UTZO0000000");
                    //frm_Ultrasound.pin.Clear();
                    //frm_Ultrasound.pin.Text = dg_searresult.SelectedRows[0].Cells["col_papin"].Value.ToString();
                    //fmain.ts_add_ultrasound.Enabled = false; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = true; fmain.ts_cancel_ultrasound.Enabled = true; fmain.ts_search_ultrasound.Enabled = false; fmain.ts_print_ultrasound.Enabled = false;
                    //this.Close();
                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //  ClassSql a = new ClassSql(); 
                    //long cnt;
                    //   cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'UTZ'");
                    var cnt = db.sp_Ultra_CountColumn(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_Ultrasound.NewULtrasound = false;
                            frm_Ultrasound.LabID.Clear();
                            // a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'UTZ' ORDER BY t_result_main.cn DESC LIMIT 1", frm_Ultrasound.LabID, "resultid");
                            var i = db.spUltr_PutText(pin.ToString()).FirstOrDefault();
                            frm_Ultrasound.LabID.Text = i.resultid;
                            frm_Ultrasound.pin.Clear();
                            frm_Ultrasound.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();


                            //if (System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] != null)
                            //                 {
                            //(System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();

                            //                 }

                            (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).Search_Patient();
                            (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).search_Medical();
                            (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).search_Radiology();
                            (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).Availability(true);
                            fmain.ts_add_ultrasound.Enabled = false; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = true; fmain.ts_search_ultrasound.Enabled = false; fmain.ts_print_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = true;

                            this.Close();
                        }
                        else
                        {
                            ultraS = true;


                        }

                    }
                    else
                    {
                        frm_Ultrasound.LabID.Clear();
                        //frm_Ultrasound.LabID.Text = ClassSql.Generate_ResultID("SELECT t_radiology.resultid  FROM t_radiology ORDER BY t_radiology.cn DESC LIMIT 1", "resultid", "UTZ00");
                        var i = db.sp_Quee_Ultr_GenerateID().FirstOrDefault();
                        frm_Ultrasound.LabID.Text = i.generated_id;
                        frm_Ultrasound.pin.Clear();
                        frm_Ultrasound.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();

                        (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).Availability(true);
                        (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).ClearAll();
                        (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).setDefaultFiledsValue();
                        (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).Search_Patient();
                        (Application.OpenForms["frm_Ultrasound"] as frm_Ultrasound).New();
                        fmain.ts_add_ultrasound.Enabled = false; fmain.ts_edit_ultrasound.Enabled = false; fmain.ts_delete_ultrasound.Enabled = false; fmain.ts_save_ultrasound.Enabled = true; fmain.ts_search_ultrasound.Enabled = false; fmain.ts_print_ultrasound.Enabled = false; fmain.ts_cancel_ultrasound.Enabled = true;

                        this.Close();

                    }






                }

                else if (xray)
                {

                    //frm_xray.LabID.Clear();
                    //frm_xray.LabID.Text = ClassSql.Generate_ResultID("SELECT t_radiology.resultid  FROM t_radiology ORDER BY t_radiology.resultid DESC LIMIT 1", "resultid", "XRAYO0000000");
                    //frm_xray.pin.Clear();
                    //frm_xray.pin.Text = dg_searresult.SelectedRows[0].Cells["col_papin"].Value.ToString();
                    //fmain.ts_add_xray.Enabled = false; fmain.ts_edit_xray.Enabled = false; fmain.ts_delete_xray.Enabled = false; fmain.ts_save_xray.Enabled = true; fmain.ts_cancel_xray.Enabled = true; fmain.ts_search_xray.Enabled = false; fmain.ts_print_xray.Enabled = false;
                    //this.Close();


                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //ClassSql a = new ClassSql(); long cnt;
                    //  cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'XRAY'");
                    var cnt = db.sp_Xray_Count_Column(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_xray.NewXray = false;
                            frm_xray.LabID.Clear();
                            //  a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'XRAY' ORDER BY t_result_main.cn DESC limit 1", frm_xray.LabID, "resultid");
                            var i = db.sp_Xray_PutText(pin.ToString()).FirstOrDefault();
                            frm_xray.LabID.Text = i.resultid;
                            frm_xray.pin.Clear();
                            frm_xray.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();


                            //if (System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] != null)
                            //                 {
                            //(System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();

                            //                 }

                            (Application.OpenForms["frm_xray"] as frm_xray).Search_Patient();
                            (Application.OpenForms["frm_xray"] as frm_xray).search_Medical();
                            (Application.OpenForms["frm_xray"] as frm_xray).search_Xray();
                            (Application.OpenForms["frm_xray"] as frm_xray).Availability(true);
                            fmain.ts_add_xray.Enabled = false; fmain.ts_edit_xray.Enabled = false; fmain.ts_delete_xray.Enabled = false; fmain.ts_save_xray.Enabled = true; fmain.ts_search_xray.Enabled = false; fmain.ts_print_xray.Enabled = false; fmain.ts_cancel_xray.Enabled = true;

                            this.Close();
                        }
                        else
                        {
                            xray = true;


                        }

                    }
                    else
                    {
                        frm_xray.LabID.Clear();
                        // frm_xray.LabID.Text = ClassSql.Generate_ResultID("SELECT t_radiology.resultid  FROM t_radiology ORDER BY t_radiology.cn DESC LIMIT 1", "resultid", "XRAY00");
                        var i = db.sp_Xray_GenerateID().FirstOrDefault();
                        frm_xray.LabID.Text = i.generated_id;
                        frm_xray.pin.Clear();
                        frm_xray.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        (Application.OpenForms["frm_xray"] as frm_xray).Availability(true);
                        (Application.OpenForms["frm_xray"] as frm_xray).ClearAll();
                        (Application.OpenForms["frm_xray"] as frm_xray).setDefaultFiledsValue();
                        (Application.OpenForms["frm_xray"] as frm_xray).Search_Patient();
                        (Application.OpenForms["frm_xray"] as frm_xray).New();
                        fmain.ts_add_xray.Enabled = false; fmain.ts_edit_xray.Enabled = false; fmain.ts_delete_xray.Enabled = false; fmain.ts_save_xray.Enabled = true; fmain.ts_search_xray.Enabled = false; fmain.ts_print_xray.Enabled = false; fmain.ts_cancel_xray.Enabled = true;

                        this.Close();

                    }



                }
                else if (hiv)
                {
                    //    frm_HIV.LabID.Clear();
                    //    frm_HIV.LabID.Text = ClassSql.Generate_ResultID("SELECT t_hiv.resultid FROM t_hiv ORDER BY t_hiv.resultid DESC LIMIT 1", "resultid", "HIVO0000000");
                    //    frm_HIV.pin.Clear();
                    //    frm_HIV.pin.Text = dg_searresult.SelectedRows[0].Cells["col_papin"].Value.ToString();
                    //    fmain.ts_add_hiv.Enabled = false; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = true; fmain.ts_cancel_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = false;
                    //    this.Close();

                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //ClassSql a = new ClassSql(); 
                    //var cnt;
                    //  cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'HIV'");
                    var cnt = db.sp_HIV_CountCoulumn(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_HIV.NewHiv = false;
                            frm_HIV.LabID.Clear();
                            // a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'HIV'", frm_HIV.LabID, "resultid");
                            var i = db.sp_HIV_PutText(pin.ToString()).FirstOrDefault();
                            frm_HIV.LabID.Text = i.resultid;
                            frm_HIV.pin.Clear();
                            string PatientPin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                            frm_HIV.pin.Text = PatientPin;


                            //if (System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] != null)
                            //                 {
                            //(System.Windows.Forms.Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();

                            //                 }

                            (Application.OpenForms["frm_HIV"] as frm_HIV).Search_Patient(PatientPin);
                            (Application.OpenForms["frm_HIV"] as frm_HIV).search_HIV(frm_HIV.LabID.Text);
                            (Application.OpenForms["frm_HIV"] as frm_HIV).search_Medical_ByProc(frm_HIV.LabID.Text);
                            (Application.OpenForms["frm_HIV"] as frm_HIV).search_med = true;
                            (Application.OpenForms["frm_HIV"] as frm_HIV).Edit();

                            //(Application.OpenForms["frm_HIV"] as frm_HIV).Availability(true);
                            //fmain.ts_add_hiv.Enabled = false; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = true;
                            // fmain.ts_add_hiv.Enabled = false; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = true; fmain.ts_cancel_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = false;
                            this.Close();
                        }
                        else
                        {
                            hiv = true;


                        }

                    }
                    else
                    {
                        frm_HIV.LabID.Clear();
                        var i = db.sp_Hiv_GenerateID().FirstOrDefault();
                        frm_HIV.LabID.Text = i.generated_id;
                        // frm_HIV.LabID.Text = ClassSql.Generate_ResultID("SELECT t_hiv.resultid FROM t_hiv ORDER BY t_hiv.cn DESC LIMIT 1", "resultid", "HIV00");
                        frm_HIV.pin.Clear();
                        string PatientPin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        frm_HIV.pin.Text = PatientPin;
                        (Application.OpenForms["frm_HIV"] as frm_HIV).Availability(true);
                        (Application.OpenForms["frm_HIV"] as frm_HIV).ClearAll();
                        (Application.OpenForms["frm_HIV"] as frm_HIV).Search_Patient(PatientPin);
                        (Application.OpenForms["frm_HIV"] as frm_HIV).New();
                        fmain.ts_add_hiv.Enabled = false; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = true;

                        this.Close();

                    }





                }
                else if (Psych_Evaluation)
                {



                    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                    //ClassSql a = new ClassSql(); long cnt;
                    //  cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'PSYCHO'");
                    var cnt = db.sp_Psycho_CountColumn(pin.ToString()).FirstOrDefault();
                    if (cnt.PatientCount >= 1)
                    {

                        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frm_Psych_Evaluation.NewPsych_Eval = false;
                            frm_Psych_Evaluation.LabID.Clear();
                            //a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'PSYCHO'", frm_Psych_Evaluation.LabID, "resultid");
                            var i = db.sp_Psycho_PutText(pin.ToString()).FirstOrDefault();
                            frm_Psych_Evaluation.LabID.Text = i.resultid;
                            frm_Psych_Evaluation.pin.Clear();
                            frm_Psych_Evaluation.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();



                            (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Search_Patient();
                            (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).search_Psych();
                            (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Availability(true);
                            fmain.ts_add_Eval.Enabled = false; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = true; fmain.ts_search_Eval.Enabled = false; fmain.ts_print_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = true;

                            this.Close();
                        }
                        else
                        {
                            Psych_Evaluation = true;


                        }

                    }
                    else
                    {
                        frm_Psych_Evaluation.LabID.Clear();
                        //frm_Psych_Evaluation.LabID.Text = ClassSql.Generate_ResultID("SELECT t_psychology.resultid FROM t_psychology ORDER BY t_psychology.cn DESC LIMIT 1", "resultid", "PSYCHO00");
                        var i = db.sp_Psycho_GenerateID().FirstOrDefault();
                        frm_Psych_Evaluation.LabID.Text = i.generated_id;
                        frm_Psych_Evaluation.pin.Clear();
                        frm_Psych_Evaluation.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                        (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Availability(true);
                        (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).ClearAll();
                        (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Search_Patient();
                        (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).New();
                        fmain.ts_add_Eval.Enabled = false; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = true; fmain.ts_search_Eval.Enabled = false; fmain.ts_print_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = true;

                        this.Close();

                    }





                    //}

                    //   lab = false; Landbase = false; queue = false; seafarer = false; Sea_mlc = false; ultraS = false; hiv = false; xray = false; Psych_Evaluation = false;

                }
                //else if (tumor)
                //{
                //    string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                //
                //long cnt;
                //  //  cnt = a.CountColumn("SELECT Count(t_result_main.papin) AS `count` FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' and resulttype = 'TUMOR'");
                //    cnt = db.sp_Tumor_CountColumn(pin.ToString()).Count();
                //    if (cnt >= 1)
                //    {

                //        if (MessageBox.Show("Previous laboratory examination Detected! Click YES to modify or No to cancel.", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //        {
                //            frm_Tumor_Immunological.newTumor = false;
                //            frm_Tumor_Immunological.LabID.Clear();
                //           // a.PutDataTOTextBox("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.papin, t_result_main.resulttype FROM t_result_main WHERE t_result_main.papin =  '" + pin.ToString() + "' AND t_result_main.resulttype =  'TUMOR'", frm_Psych_Evaluation.LabID, "resultid");
                //            var i = db.sp_Tumor_PutText(pin.ToString()).FirstOrDefault();
                //            frm_Psych_Evaluation.LabID.Text = i.resultid;
                //            frm_Tumor_Immunological.pin.Clear();
                //            frm_Tumor_Immunological.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();



                //            (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Search_Patient();
                //            (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Availability(true);
                //            fmain.ts_add_tumor.Enabled = false; fmain.ts_edit_tumor.Enabled = false; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = true; fmain.ts_search_tumor.Enabled = false; fmain.ts_print_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = true;

                //            this.Close();
                //        }
                //        else
                //        {
                //            tumor = true;


                //        }

                //    }
                //    else
                //    {
                //        frm_Tumor_Immunological.LabID.Clear();
                //        frm_Tumor_Immunological.LabID.Text = ClassSql.Generate_ResultID("SELECT tbl_LabExtra.resultid FROM tbl_LabExtra ORDER BY tbl_LabExtra.cn DESC LIMIT 1", "resultid", "TUMO00");
                //        frm_Tumor_Immunological.pin.Clear();
                //        frm_Tumor_Immunological.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                //        (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Availability(true);
                //        (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).ClearAll();
                //        (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Search_Patient();
                //        (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).New();
                //        fmain.ts_add_tumor.Enabled = false; fmain.ts_edit_tumor.Enabled = false; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = true; fmain.ts_search_tumor.Enabled = false; fmain.ts_print_tumor.Enabled = false; fmain.ts_cancel_tumor.Enabled = true;

                //        this.Close();

                //    }


                //}


            }
            else
            {
                MessageBox.Show("Actione Denied! No active or Selected item", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (ClassSql.cnn.State == ConnectionState.Open)
            //{ ClassSql.DbClose(); }
            Cursor.Current = Cursors.Default;

        }

        private void frm_search_Patient_Queuing_FormClosed(object sender, FormClosedEventArgs e)
        {
            lab = false; Landbase = false; queue = false;

        }

        private void txtlastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtmiddlename_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dg_searresult_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void dg_searresult_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 0 || e.RowIndex != 0)
            {
                if (dg_result.SelectedRows.Count >= 1)
                {
                    Patient_cn = dg_result.SelectedRows[0].Cells[0].Value.ToString();

                    //  loadImage();
                }

            }


        }


        private void dg_searresult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SelectItem();
            }
        }

        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Select(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ Searach(); }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            // FillDataGridView(txt_Search.Text);
            FillDataGridView();
        }

        private void dg_searresult_DoubleClick_1(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void dg_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex != 0)
            {
                if (dg_result.SelectedRows.Count >= 1)
                {
                    Patient_cn = dg_result.SelectedRows[0].Cells[0].Value.ToString();

                    loadImage();
                }

            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            // FillDataGridView("%");
            this.Invoke(new MethodInvoker(delegate() { FillDataGridView(); }));

        }

        void FillDataGridView()
        {

            try
            {


                var list = (from m in queueSearchList_Model select m).ToList();

                list = (from m in queueSearchList_Model where m.PatientName.StartsWith(txt_Search.Text) select m).ToList();
                dg_result.DataSource = list;
                dg_result.Columns[0].Visible = false;
                dg_result.Columns[1].Width = 100;
                dg_result.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg_result.Columns[3].Width = 80;

                lbl_items.Text = "Items: " + list.Count();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured" + ex.Message, Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }

        void FillDataGridView(string searchID)
        {

            try
            {
                dt_Queue = Tool.GetDataSourceFromFile(TableListPath.QueueSearchList);

                if (dt_Queue.Rows.Count >= 1)
                {
                    //  lbl_notif.Visible = false;
                    dt_Queue.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_Queue.Columns[2], searchID);
                    dg_result.DataSource = dt_Queue;
                    dg_result.Columns[0].Visible = false;
                    dg_result.Columns[1].Width = 100;
                    dg_result.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dg_result.Columns[3].Width = 80;
                }
                //else
                //{
                //    lbl_notif.Visible = true;
                //    lbl_notif.Text = "No record";
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured" + ex.Message, Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }

        private void frm_search_Patient_Queuing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectItem();

            }

        }






    }
}
