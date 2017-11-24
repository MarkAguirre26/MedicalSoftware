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
using System.Drawing.Imaging;
using System.Data.SqlClient;
using Centerport.Report;
using Ini;
using Centerport.Class;


namespace Centerport
{
    public partial class frm_patientInfo : Form, MyInter
    {
        Main fmain; public static PictureBox img; //public bool newPatient;
        public static string OrderBy;
        private string ResultType; private string ResultID;
        //private static GroupBox group1; private static GroupBox group2; private static GroupBox group3; private static GroupBox group4; private static GroupBox group7; private static GroupBox group5; private static GroupBox group6; private static GroupBox group8;
        private static TextBox txt_update; private static TextBox txt_reg;
        public static TextBox pin; public static TextBox id_;
        // public static ToolStripButton tb_add_profil; public static ToolStripButton tb_edit_profile; public static ToolStripButton tb_del_profile; public static ToolStripButton tb_Save_profile; public static ToolStripButton tb_Cancel_profile; public static ToolStripButton tb_Search_profile; public static ToolStripButton tb_Print_profile; public static ToolStripButton tb_Close_profile; public static ToolStripButton tb_Exit_profile;
        public static bool NewPatient;
        public int pagecount = 0;
        //public int page = 1;
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);

        public frm_patientInfo(Main mainn)
        {
            InitializeComponent();
            img = pic_;
            img.AllowDrop = true;

            // group1 = groupBox1; group2 = groupBox2; group3 = groupBox3; group4 = groupBox4; group5 = groupBox5; group6 = groupBox6; group8 = groupBox8; group7 = groupBox7;
            txt_update = txt_dateUpdate; pin = txt_papin; id_ = txt_id;
            txt_reg = txt_datereg;
            fmain = mainn;
            //   tb_add_profil = ts_add_Profile; tb_edit_profile = ts_edit_Profile; tb_del_profile = ts_delete_Profile; tb_Save_profile = ts_save_Profile; tb_Cancel_profile = ts_cancel_Profile; tb_Search_profile = ts_search_Profile;

        }


        public void loadPatient_ByPage(int pageindex)
        {
            var lists = (from m in db.view_patients orderby m.cn ascending select m).Skip((pageindex - 1) * 1).Take(1);

            Clear();
            pin.Clear();
            img.Image = null;
            foreach (var i in lists)
            {

                this.Tag = i.cn.ToString();

                this.txt_papin.Text = i.papin.ToString();
                txt_datereg.Text = i.registration_date.ToString();
                txt_dateUpdate.Text = i.date_last_updated.ToString();
                txt_lastname.Text = i.lastname.ToString();
                txt_firstName.Text = i.firstname.ToString();
                txt_mname.Text = i.middlename.ToString();
                txtaddress1.Text = i.address_1.ToString();
                txtcity.Text = i.city.ToString();
                txt_Contact.Text = i.contact_1.ToString();
                DateTime temp_Bday;
                if (DateTime.TryParse(i.birthdate, out temp_Bday))
                {
                    dtbday.Format = DateTimePickerFormat.Custom;
                    dtbday.CustomFormat = "MM/dd/yyyy";
                    this.dtbday.Value = Convert.ToDateTime(i.birthdate.ToString()).Date;
                }
                else
                {
                    dtbday.Format = DateTimePickerFormat.Custom;
                    dtbday.CustomFormat = "00/00/0000";
                }

                cbo_gender.Text = i.gender.ToString();
                cbo_status.Text = i.marital_status.ToString();
                txt_placeofBirth.Text = i.place_of_birth.ToString();
                cbo_religeon.Text = i.religion.ToString();
                txtNationality.Text = i.nationality.ToString();
                cbo_employer.Text = i.employer.ToString();
                cbo_designation.Text = i.designation.ToString();
                txt_passportNo.Text = i.passport_no.ToString();
                txtsemanNo.Text = i.seamansbook_no.ToString();
                txtPosition.Text = i.position.ToString();
                txtSIRB.Text = i.sirb.ToString();
                txtfarthername.Text = i.father_name.ToString();
                txtfatherOccu.Text = i.father_occupation.ToString();
                txtmothername.Text = i.mother_name.ToString();
                txtmotherocc.Text = i.mother_occupation.ToString();
                txtnoofbrother.Text = i.no_of_brothers.ToString();
                txtnoofsister.Text = i.no_of_sisters.ToString();
                txtbirthorder.Text = i.birth_order.ToString();
                txtspouse.Text = i.spouse_name.ToString();
                txtspouseoccu.Text = i.spouse_occupation.ToString();
                txtnoofchildren.Text = i.no_of_children.ToString();
                txtelem.Text = i.elementary.ToString();
                txthigh.Text = i.highschool.ToString();
                txtcollege.Text = i.college.ToString();
                txtcourse.Text = i.course.ToString();
                txtHighLevel.Text = i.highest_level_attended.ToString();
                txtDestination.Text = i.country_destination.ToString();

                DateTime temp;
                if (DateTime.TryParse(i.prev_work_end.ToString(), out temp))
                {
                    dt_end.Format = DateTimePickerFormat.Custom;
                    dt_end.CustomFormat = "MM/dd/yyyy";
                    dt_end.Value = Convert.ToDateTime(i.prev_work_end.ToString()).Date;
                }
                else
                {
                    dt_end.Format = DateTimePickerFormat.Custom;
                    dt_end.CustomFormat = "00/00/0000";
                }


                DateTime temp2;
                if (DateTime.TryParse(i.prev_work_start.ToString(), out temp2))
                {
                    dt_start.Format = DateTimePickerFormat.Custom;
                    dt_start.CustomFormat = "MM/dd/yyyy";

                    dt_start.Value = Convert.ToDateTime(i.prev_work_start.ToString()).Date;
                }
                else
                {
                    dt_start.Format = DateTimePickerFormat.Custom;
                    dt_start.CustomFormat = "00/00/0000";


                }
                
                txt_prevCompany.Text = i.prev_company.ToString();
                txtprev_position.Text = i.prev_position.ToString();
                txt_prevreason.Text = i.prev_leave_reason.ToString();
                txt_remark.Text = i.remarks.ToString();
                if (pic_.Image != null)
                {
                    pic_.Image.Dispose();
                    pic_.Image = null;
                }
                pic_.Image = Tool.bytetoimage(i.picture);
                txt_id.Focus();
                break;
            }










        }
        public void Save()
        {
            if (NewPatient)
            {
                this.Invoke(new MethodInvoker(delegate() { Add_profile(); }));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate() { Update_Profile(); }));
            }


        }



        public void EnableDisAble(bool bl)
        {


            if (bl == true)
            { overlayShadow1.Visible = false; overlayShadow1.SendToBack(); }
            else
            { overlayShadow1.Visible = true; overlayShadow1.BringToFront(); }

        }

        private void frm_patientInfo_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.Default;
            EnableDisAble(false);
            txt_papin.Select();

            string[] lineOfContents = File.ReadAllLines(ClassSql.EmployerPath);
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                this.cbo_employer.Items.Add(tokens[0]);
                cbo_employer.AutoCompleteCustomSource.Add(tokens[0]);
            }


            backgroundWorker2.RunWorkerAsync();
            backgroundWorker1.RunWorkerAsync();

        }



        public void New()
        {
            EnableDisAble(true);
            NewPatient = true;
            Clear();
            pin.Text = ClassSql.CreateID();
            txt_update.Text = DateTime.Today.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
            txt_reg.Text = DateTime.Today.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
            fmain.ts_add_profile.Enabled = false; fmain.ts_edit_profile.Enabled = false; fmain.ts_del_profile.Enabled = false; fmain.ts_save_profile.Enabled = true; fmain.ts_search_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = true; fmain.ts_print_profile.Enabled = false;
            fmain.ts_First_Record.Enabled = false;
            fmain.ts_prev_record.Enabled = false;
            fmain.ts_next_Record.Enabled = false;
            fmain.ts_last_Record.Enabled = false;

            dt_end.Format = DateTimePickerFormat.Custom;
            dt_end.CustomFormat = "00/00/0000";

            this.dt_start.Format = DateTimePickerFormat.Custom;
            dt_start.CustomFormat = "00/00/0000";

            this.dtbday.Format = DateTimePickerFormat.Custom;
            dtbday.CustomFormat = "00/00/0000";

            // load_Employer();

        }
        public void Edit()
        {

            if (fmain.UserLevel == 1 || fmain.UserLevel == 2 || fmain.UserLevel == 4)
            {

                EnableDisAble(true);
                NewPatient = false;
                fmain.ts_add_profile.Enabled = false; fmain.ts_edit_profile.Enabled = false; fmain.ts_del_profile.Enabled = false; fmain.ts_save_profile.Enabled = true; fmain.ts_search_profile.Enabled = false; fmain.ts_print_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = true;
                fmain.ts_First_Record.Enabled = false;
                fmain.ts_prev_record.Enabled = false;
                fmain.ts_next_Record.Enabled = false;
                fmain.ts_last_Record.Enabled = false;
                //   load_Employer();

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

            if (fmain.UserLevel == 1 || fmain.UserLevel == 2)
            {

                try
                {
                    if (this.Tag.ToString() != null)
                    {

                        if (MessageBox.Show("Are you sure you want to delete Patient with Papin no.:" + txt_papin.Text, Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                            db.ExecuteCommand("Delete from m_patient where cn = {0}", this.Tag);
                            Tool.MessageBoxDelete();
                            fmain.PatientPageCount -= 1;
                            fmain.PatientTotalCount -= 1;
                            loadPatient_ByPage(fmain.PatientPageCount);
                            fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_print_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = false;


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

                }



            }
            else
            {
                if (MessageBox.Show("You do not have enough access privileges for this operation, Please use RELEASING account. \n Would you like to continue?", "Action Denied!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    new frm_login(fmain).ShowDialog();
                }

            }




        }
        public void Cancel()
        {

            txt_papin.Select();
            EnableDisAble(false);
            if (NewPatient)
            {
                txt_papin.Clear();
                fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_print_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = false;

            }
            else
            {
                fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_print_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = false;

            }

            fmain.ts_First_Record.Enabled = true;
            fmain.ts_prev_record.Enabled = true;
            fmain.ts_next_Record.Enabled = true;
            fmain.ts_last_Record.Enabled = true;



        }
        public void Print()
        {
            //  MessageBox.Show("Wala pa"); 
        }
        public void Search()
        {

        }












        public void Add_profile()
        {

            try
            {

                //isEmptyColor();
                if (txt_papin.Text == "" || txt_lastname.Text == "" || this.txt_firstName.Text == "" || txt_mname.Text == "" || txtaddress1.Text == "" || cbo_status.Text == "" || cbo_employer.Text == "" || txtPosition.Text == "" || dtbday.Text == "00/00/0000")
                {
                    MessageBox.Show("Please fill required information. \nLast name \nFirst name \nMiddle name \nAddress \nBirth date \nMarital status \nEmployer \nDesignation \nPosition", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (pic_.Image == null)
                    {
                        pic_.Image = Properties.Resources.AnonymousPic;
                    }
                    DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                    db.ExecuteCommand("INSERT INTO m_patient (papin, lastname, firstname, middlename, address_1, address_2, city,district, contact_1, contact_2, position, marital_status, gender, birthdate, place_of_birth, type_of_job, employer, passport_no, seamansbook_no, picture,registration_date, remarks, nationality, religion, test_data, father_name, father_occupation, mother_name, no_of_brothers, no_of_sisters, birth_order, spouse_name, spouse_occupation, no_of_children, elementary, highschool, college, course, highest_level_attended, mother_occupation, prev_work_start, prev_work_end, prev_company, prev_position, prev_leave_reason, prev_years, date_last_updated, sirb, designation,country_destination) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49})", txt_papin.Text, txt_lastname.Text, txt_firstName.Text, txt_mname.Text, this.txtaddress1.Text, " ", this.txtcity.Text, " ", txt_Contact.Text, " ", txtPosition.Text, cbo_status.Text, cbo_gender.Text, dtbday.Text, txt_placeofBirth.Text, this.cbo_designation.Text, this.cbo_employer.Text, this.txt_passportNo.Text, this.txtsemanNo.Text, Tool.ImageToByte(pic_.Image), txt_datereg.Text, txt_remark.Text, this.txtNationality.Text, cbo_religeon.Text, "0", txtfarthername.Text, this.txtfatherOccu.Text, this.txtmothername.Text, this.txtnoofbrother.Text, this.txtnoofsister.Text, this.txtbirthorder.Text, txtspouse.Text, this.txtspouseoccu.Text, this.txtnoofchildren.Text, this.txtelem.Text, this.txthigh.Text, this.txtcollege.Text, this.txtcourse.Text, this.txtHighLevel.Text, this.txtmotherocc.Text, dt_start.Text, dt_end.Text, this.txt_prevCompany.Text, this.txtprev_position.Text, this.txt_prevreason.Text, this.txt_lenght.Text, DateTime.Now, txtsemanNo.Text, cbo_designation.Text, txtDestination.Text);
                    //Tool.MessageBoxSave();

                    //patientSearchList_Model.Clear();
                    //if (!backgroundWorker2.IsBusy)
                    //{
                    //    backgroundWorker2.RunWorkerAsync();
                    //}
                    //// OrderBy = "DESC";
                    //// Search_JumpRecord();
                    ////patientSearchList_Model.Clear();

                    pin.Select();
                    EnableDisAble(false);
                    fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_cancel_profile.Enabled = false; fmain.ts_print_profile.Enabled = false;
                    fmain.ts_First_Record.Enabled = true; fmain.ts_prev_record.Enabled = true; fmain.ts_next_Record.Enabled = true; fmain.ts_last_Record.Enabled = true;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }




        }

        public void Update_Profile()
        {

            try
            {


                //isEmptyColor();
                if (txt_papin.Text == "" || txt_lastname.Text == "" || this.txt_firstName.Text == "" || txt_mname.Text == "" || txtaddress1.Text == "" || cbo_status.Text == "" || cbo_employer.Text == "" || txtPosition.Text == "" || dtbday.Text == "00/00/0000")
                {
                    MessageBox.Show("Please fill required information. \nLast name \nFirst name \nMiddle name \nAddress \nBirth date \nMarital status \nEmployer \nDesignation \nPosition", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {

                    //    ClassSql a = new ClassSql();
                    // a.executequeryStoreproc("ProcUpdatePatientInfo", "lastname,firstname,middlename,address_1,city,contact_1,position,marital_status,gender,birthdate,place_of_birth,employer,passport_no,seamansbook_no,registration_date,remarks,nationality,religion,father_name,father_occupation,mother_name,no_of_brothers,no_of_sisters,birth_order,spouse_name,spouse_occupation,no_of_children,elementary,highschool,college,course,highest_level_attended,mother_occupation,prev_work_start,prev_work_end,prev_company,prev_position,prev_leave_reason,prev_years,date_last_updated,sirb,designation,country_destination,papin,picture", new object[] { txt_lastname.Text, txt_firstName.Text, txt_mname.Text, this.txtaddress1.Text, this.txtcity.Text, this.txt_Contact.Text, txtPosition.Text, cbo_status.Text, cbo_gender.Text, dtbday.Text, txt_placeofBirth.Text, cbo_employer.Text, this.txt_passportNo.Text, this.txtsemanNo.Text, txt_datereg.Text, txt_remark.Text, this.txtNationality.Text, cbo_religeon.Text, txtfarthername.Text, this.txtfatherOccu.Text, this.txtmothername.Text, this.txtnoofbrother.Text, this.txtnoofsister.Text, this.txtbirthorder.Text, this.txtspouse.Text, this.txtspouseoccu.Text, this.txtnoofchildren.Text, this.txtelem.Text, this.txthigh.Text, this.txtcollege.Text, this.txtcourse.Text, this.txtHighLevel.Text, this.txtmotherocc.Text, dt_start.Text, dt_end.Text, this.txt_prevCompany.Text, this.txtprev_position.Text, this.txt_prevreason.Text, this.txt_lenght.Text, DateTime.Now, this.txtSIRB.Text, this.cbo_designation.Text, txtDestination.Text, txt_papin.Text, Tool.ImageToByte(pic_.Image) });
                    //SaveImage();
                    DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                    // MessageBox.Show(string.Format("UPDATE m_patient SET  m_patient.lastname={0}, m_patient.firstname={1}, m_patient.middlename ={2}, m_patient.address_1={3}, m_patient.city={4}, m_patient.contact_1={5},m_patient.position={6}, m_patient.marital_status={7},m_patient.gender={8}, m_patient.birthdate={9}, m_patient.place_of_birth={10}, m_patient.employer ={11}, m_patient.passport_no={12}, m_patient.seamansbook_no={13},m_patient.registration_date={14}, m_patient.remarks={15}, m_patient.nationality={16}, m_patient.religion={17}, m_patient.father_name={18}, m_patient.father_occupation={19}, m_patient.mother_name={20}, m_patient.no_of_brothers={21}, m_patient.no_of_sisters={22},m_patient.birth_order={23}, m_patient.spouse_name={24}, m_patient.spouse_occupation={25}, m_patient.no_of_children={26}, m_patient.elementary={27}, m_patient.highschool={28}, m_patient.college= {29}, m_patient.course={30}, m_patient.highest_level_attended={31}, m_patient.mother_occupation={32}, m_patient.prev_work_start={33}, m_patient.prev_work_end={34},m_patient.prev_company={35}, m_patient.prev_position={36}, m_patient.prev_leave_reason={37}, m_patient.prev_years={38}, m_patient.date_last_updated={39}, m_patient.sirb={40},  m_patient.designation={41},   m_patient.country_destination={42},   m_patient.picture={44}    WHERE m_patient.papin={43}", txt_lastname.Text, txt_firstName.Text, txt_mname.Text, this.txtaddress1.Text, this.txtcity.Text, this.txt_Contact.Text, txtPosition.Text, cbo_status.Text, cbo_gender.Text, dtbday.Text, txt_placeofBirth.Text, cbo_employer.Text, this.txt_passportNo.Text, this.txtsemanNo.Text, txt_datereg.Text, txt_remark.Text, this.txtNationality.Text, cbo_religeon.Text, txtfarthername.Text, this.txtfatherOccu.Text, this.txtmothername.Text, this.txtnoofbrother.Text, this.txtnoofsister.Text, this.txtbirthorder.Text, this.txtspouse.Text, this.txtspouseoccu.Text, this.txtnoofchildren.Text, this.txtelem.Text, this.txthigh.Text, this.txtcollege.Text, this.txtcourse.Text, this.txtHighLevel.Text, this.txtmotherocc.Text, dt_start.Text, dt_end.Text, this.txt_prevCompany.Text, this.txtprev_position.Text, this.txt_prevreason.Text, this.txt_lenght.Text, DateTime.Now, this.txtSIRB.Text, this.cbo_designation.Text, txtDestination.Text, txt_papin.Text, Tool.ImageToByte(pic_.Image),txt_papin.Text));
                    db.ExecuteCommand("UPDATE m_patient SET  m_patient.lastname={0}, m_patient.firstname={1}, m_patient.middlename ={2}, m_patient.address_1={3}, m_patient.city={4}, m_patient.contact_1={5},m_patient.position={6}, m_patient.marital_status={7},m_patient.gender={8}, m_patient.birthdate={9}, m_patient.place_of_birth={10}, m_patient.employer ={11}, m_patient.passport_no={12}, m_patient.seamansbook_no={13},m_patient.registration_date={14}, m_patient.remarks={15}, m_patient.nationality={16}, m_patient.religion={17}, m_patient.father_name={18}, m_patient.father_occupation={19}, m_patient.mother_name={20}, m_patient.no_of_brothers={21}, m_patient.no_of_sisters={22},m_patient.birth_order={23}, m_patient.spouse_name={24}, m_patient.spouse_occupation={25}, m_patient.no_of_children={26}, m_patient.elementary={27}, m_patient.highschool={28}, m_patient.college= {29}, m_patient.course={30}, m_patient.highest_level_attended={31}, m_patient.mother_occupation={32}, m_patient.prev_work_start={33}, m_patient.prev_work_end={34},m_patient.prev_company={35}, m_patient.prev_position={36}, m_patient.prev_leave_reason={37}, m_patient.prev_years={38}, m_patient.date_last_updated={39}, m_patient.sirb={40},  m_patient.designation={41},   m_patient.country_destination={42},   m_patient.picture={44}    WHERE m_patient.papin={43}", txt_lastname.Text, txt_firstName.Text, txt_mname.Text, this.txtaddress1.Text, this.txtcity.Text, this.txt_Contact.Text, txtPosition.Text, cbo_status.Text, cbo_gender.Text, dtbday.Text, txt_placeofBirth.Text, cbo_employer.Text, this.txt_passportNo.Text, this.txtsemanNo.Text, txt_datereg.Text, txt_remark.Text, this.txtNationality.Text, cbo_religeon.Text, txtfarthername.Text, this.txtfatherOccu.Text, this.txtmothername.Text, this.txtnoofbrother.Text, this.txtnoofsister.Text, this.txtbirthorder.Text, this.txtspouse.Text, this.txtspouseoccu.Text, this.txtnoofchildren.Text, this.txtelem.Text, this.txthigh.Text, this.txtcollege.Text, this.txtcourse.Text, this.txtHighLevel.Text, this.txtmotherocc.Text, dt_start.Text, dt_end.Text, this.txt_prevCompany.Text, this.txtprev_position.Text, this.txt_prevreason.Text, this.txt_lenght.Text, DateTime.Now, txtsemanNo.Text, this.cbo_designation.Text, txtDestination.Text, txt_papin.Text, Tool.ImageToByte(pic_.Image), txt_papin.Text);
                    //txt_lastname.Text,   txt_firstName.Text,           txt_mname.Text,     this.txtaddress1.Text, this.txtcity.Text, this.txt_Contact.Text,    txtPosition.Text,       cbo_status.Text,                     cbo_gender.Text, dtbday.Text,           txt_placeofBirth.Text,        cbo_employer.Text,            this.txt_passportNo.Text, this.txtsemanNo.Text,        txt_datereg.Text,               txt_remark.Text,         this.txtNationality.Text,   cbo_religeon.Text,      txtfarthername.Text,        this.txtfatherOccu.Text,          this.txtmothername.Text,    this.txtnoofbrother.Text,         this.txtnoofsister.Text,  this.txtbirthorder.Text,     this.txtspouse.Text,          this.txtspouseoccu.Text,           this.txtnoofchildren.Text, this.txtelem.Text,           this.txthigh.Text,          this.txtcollege.Text,  this.txtcourse.Text,  this.txtHighLevel.Text,                  this.txtmotherocc.Text,           dt_start.Text,                  dt_end.Text,                 this.txt_prevCompany.Text, this.txtprev_position.Text,   this.txt_prevreason.Text,         this.txt_lenght.Text,        DateTime.Now,                  this.txtSIRB.Text,         this.cbo_designation.Text, txtDestination.Text,                Tool.ImageToByte(pic_.Image),              txt_papin.Text
                    //Tool.MessageBoxUpdate();
                    fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_cancel_profile.Enabled = false; fmain.ts_print_profile.Enabled = false;
                    fmain.ts_First_Record.Enabled = true; fmain.ts_prev_record.Enabled = true; fmain.ts_next_Record.Enabled = true; fmain.ts_last_Record.Enabled = true;
                    EnableDisAble(false);
                    pin.Select();
                    //  Search_();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }




        }



        private void frm_patientInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (fmain.ts_cancel_profile.Enabled == true)
                { Cancel(); }
                else
                { this.Close(); }

            }
            else if (e.KeyCode == Keys.Add && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_add_profile.Enabled == true)
                {

                    New();
                }
            }

            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_save_profile.Enabled == true)
                {
                    Save();

                }

            }
            else if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                if (fmain.ts_print_profile.Enabled == true)
                {
                    Print();
                }
            }
            else if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {

                if (fmain.ts_search_profile.Enabled == true)
                {
                    fmain.Search_Profile();
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (fmain.ts_edit_profile.Enabled == true)
                {
                    Edit();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (fmain.ts_del_profile.Enabled == true)
                {

                    Delete();
                }

            }







        }


        void Clear()
        {
            //  Tool.ClearFields(groupBox3);

            Tool.ClearFields(groupBox3);
            Tool.ClearFields(groupBox1);
            Tool.ClearFields(groupBox2);
            Tool.ClearFields(groupBox4);
            Tool.ClearFields(groupBox5);
            Tool.ClearFields(groupBox6);
            Tool.ClearFields(panel3);
            Tool.ClearFields(groupBox8);
            txtage.Text = "";
            try
            { img.Image = null; }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;


            }



            //txtaddress1.Clear();
            //txtaddress2.Clear();
            //txtcity.Clear();
            //txt_Contact.Clear();

        }

        public void Search_()
        {

            try
            {
                // ClassSql a = new ClassSql(); DataTable dt;
                // dt = a.Table("SELECT * FROM m_patient  WHERE cn = '" + this.Tag.ToString() + "'");
                // dt = a.Mytable_Proc("patient_search_", "@ID", this.Tag.ToString());

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var lists = (from m in db.view_patients where m.cn == Convert.ToInt32(this.Tag.ToString()) select m);
                Clear();
                pin.Clear();
                //  img.Image = null;
                foreach (var i in lists)
                {
                    this.Tag = i.cn.ToString();

                    this.txt_papin.Text = i.papin.ToString();
                    txt_datereg.Text = i.registration_date.ToString();
                    txt_dateUpdate.Text = i.date_last_updated.ToString();
                    txt_lastname.Text = i.lastname.ToString();
                    txt_firstName.Text = i.firstname.ToString();
                    txt_mname.Text = i.middlename.ToString();
                    txtaddress1.Text = i.address_1.ToString();
                    txtcity.Text = i.city.ToString();
                    txt_Contact.Text = i.contact_1.ToString();
                    DateTime temp_Bday;
                    if (DateTime.TryParse(i.birthdate, out temp_Bday))
                    {
                        dtbday.Format = DateTimePickerFormat.Custom;
                        dtbday.CustomFormat = "MM/dd/yyyy";
                        this.dtbday.Value = Convert.ToDateTime(i.birthdate.ToString()).Date;
                    }
                    else
                    {
                        dtbday.Format = DateTimePickerFormat.Custom;
                        dtbday.CustomFormat = "00/00/0000";
                    }

                    cbo_gender.Text = i.gender.ToString();
                    cbo_status.Text = i.marital_status.ToString();
                    txt_placeofBirth.Text = i.place_of_birth.ToString();
                    cbo_religeon.Text = i.religion.ToString();
                    txtNationality.Text = i.nationality.ToString();
                    cbo_employer.Text = i.employer.ToString();
                    cbo_designation.Text = i.designation.ToString();
                    txt_passportNo.Text = i.passport_no.ToString();
                    txtsemanNo.Text = i.seamansbook_no.ToString();
                    txtPosition.Text = i.position.ToString();
                    txtSIRB.Text = i.sirb.ToString();
                    txtfarthername.Text = i.father_name.ToString();
                    txtfatherOccu.Text = i.father_occupation.ToString();
                    txtmothername.Text = i.mother_name.ToString();
                    txtmotherocc.Text = i.mother_occupation.ToString();
                    txtnoofbrother.Text = i.no_of_brothers.ToString();
                    txtnoofsister.Text = i.no_of_sisters.ToString();
                    txtbirthorder.Text = i.birth_order.ToString();
                    txtspouse.Text = i.spouse_name.ToString();
                    txtspouseoccu.Text = i.spouse_occupation.ToString();
                    txtnoofchildren.Text = i.no_of_children.ToString();
                    txtelem.Text = i.elementary.ToString();
                    txthigh.Text = i.highschool.ToString();
                    txtcollege.Text = i.college.ToString();
                    txtcourse.Text = i.course.ToString();
                    txtHighLevel.Text = i.highest_level_attended.ToString();
                    txtDestination.Text = i.country_destination.ToString();

                    DateTime temp;
                    if (DateTime.TryParse(i.prev_work_end.ToString(), out temp))
                    {
                        dt_end.Format = DateTimePickerFormat.Custom;
                        dt_end.CustomFormat = "MM/dd/yyyy";
                        dt_end.Value = Convert.ToDateTime(i.prev_work_end.ToString()).Date;
                    }
                    else
                    {
                        dt_end.Format = DateTimePickerFormat.Custom;
                        dt_end.CustomFormat = "00/00/0000";
                    }


                    DateTime temp2;
                    if (DateTime.TryParse(i.prev_work_start.ToString(), out temp2))
                    {
                        dt_start.Format = DateTimePickerFormat.Custom;
                        dt_start.CustomFormat = "MM/dd/yyyy";

                        dt_start.Value = Convert.ToDateTime(i.prev_work_start.ToString()).Date;
                    }
                    else
                    {
                        dt_start.Format = DateTimePickerFormat.Custom;
                        dt_start.CustomFormat = "00/00/0000";


                    }

                    txt_prevCompany.Text = i.prev_company.ToString();
                    txtprev_position.Text = i.prev_position.ToString();
                    txt_prevreason.Text = i.prev_leave_reason.ToString();
                    txt_remark.Text = i.remarks.ToString();
                    if (pic_.Image != null)
                    {
                        pic_.Image.Dispose();
                        pic_.Image = null;
                    }
                    pic_.Image = Tool.bytetoimage(i.picture);
                    txt_id.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }



        private void frm_patientInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassSql.DbClose();
            fmain.f_PatientInfo = true;
            fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_print_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = false;

            fmain.ts_First_Record.Enabled = true;
            fmain.ts_prev_record.Enabled = true;
            fmain.ts_next_Record.Enabled = true;
            fmain.ts_last_Record.Enabled = true;


        }



        private void txtpapin_TextChanged(object sender, EventArgs e)
        {

        }










        private void txt_lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
         //   e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txt_firstName_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txt_mname_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void frm_patientInfo_Leave_1(object sender, EventArgs e)
        {

        }

        private void frm_patientInfo_Enter(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            Search_();
            //   Search_labHistory();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {




        }




        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            frm_camera cam = new frm_camera();
            cam.ShowDialog();
        }


        private void pic__DragDrop(object sender, DragEventArgs e)
        {
            //this.Text= (string)e.Data.GetData(typeof(string)); 

            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files) //Console.WriteLine(file);
                {
                    // this.Text = file.ToString();
                    img.Image = Image.FromFile(file.ToString());
                }
            }
            catch
            { }



        }

        private void pic__DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(string))) e.Effect = DragDropEffects.Copy;
            e.Effect = DragDropEffects.Move;
        }



        private void txt_lastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_lastname_Validating(object sender, CancelEventArgs e)
        {


        }




        private void dt_start_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");

            this.dt_start.Format = DateTimePickerFormat.Custom;
            dt_start.CustomFormat = "MM/dd/yyyy";

            int Lenght = Convert.ToDateTime(dt_end.Text).Year - Convert.ToDateTime(dt_start.Text).Year;
            this.txt_lenght.Text = Lenght.ToString();
        }

        private void dt_end_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
            dt_end.Format = DateTimePickerFormat.Custom;
            dt_end.CustomFormat = "MM/dd/yyyy";

            int Lenght = Convert.ToDateTime(dt_end.Text).Year - Convert.ToDateTime(dt_start.Text).Year;
            this.txt_lenght.Text = Lenght.ToString();
        }

        private void dtbday_ValueChanged(object sender, EventArgs e)
        {
            dtbday.Format = DateTimePickerFormat.Custom;
            dtbday.CustomFormat = "MM/dd/yyyy";

            DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            int Age = CurrentDate.Year - dtbday.Value.Year;// Convert.ToDateTime(dtbday.Text).Year;
            //this.txt_age.Text = Age.ToString();
            if (CurrentDate.Month < dtbday.Value.Month)
            {
                Age--;
            }
            else if ((CurrentDate.Month == dtbday.Value.Month) && (CurrentDate.Day < dtbday.Value.Day))
            {

                Age--;
            }
            this.txtage.Text = Age.ToString();
            SendKeys.Send("{RIGHT}");


        }


        private void dt_end_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_end.Format = DateTimePickerFormat.Custom;
                dt_end.CustomFormat = "00/00/0000";
            }
        }

        private void dt_start_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dt_start.Format = DateTimePickerFormat.Custom;
                dt_start.CustomFormat = "00/00/0000";
            }
        }

        private void dtbday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                dtbday.Format = DateTimePickerFormat.Custom;
                dtbday.CustomFormat = "00/00/0000";
            }
        }

        private void dtbday_MouseDown(object sender, MouseEventArgs e)
        {
            dtbday.Format = DateTimePickerFormat.Custom;
            dtbday.CustomFormat = "MM/dd/yyyy";

            DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            int Age = CurrentDate.Year - dtbday.Value.Year;// Convert.ToDateTime(dtbday.Text).Year;
            //this.txt_age.Text = Age.ToString();
            if (CurrentDate.Month < dtbday.Value.Month)
            {
                Age--;
            }
            else if ((CurrentDate.Month == dtbday.Value.Month) && (CurrentDate.Day < dtbday.Value.Day))
            {

                Age--;
            }
            this.txtage.Text = Age.ToString();
        }

        private void dt_start_MouseDown(object sender, MouseEventArgs e)
        {
            dt_start.Format = DateTimePickerFormat.Custom;
            dt_start.CustomFormat = "MM/dd/yyyy";
        }

        private void dt_end_MouseDown(object sender, MouseEventArgs e)
        {
            dt_end.Format = DateTimePickerFormat.Custom;
            dt_end.CustomFormat = "MM/dd/yyyy";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                img.Image.Dispose();
                img.Image = null;
                // SaveImage();

            }
            catch
            {

            }
        }

        private void cmd_addEmployer_Click(object sender, EventArgs e)
        {
            //ClassSql a = new ClassSql();
            //if (a.CountColumn("Select * from tbl_employer where Employer = '"+Tool.ReplaceString(txtemployer.Text)+"'") >= 1)
            //{
            //    MessageBox.Show("Employer name already exist", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //else
            //{ 
            //    a.ExecuteQuery("Insert into tbl_employer (Employer) values('" + Tool.ReplaceString(txtemployer.Text) + "')");
            //    MessageBox.Show("Employer name added", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}



        }

        private void frm_patientInfo_Shown(object sender, EventArgs e)
        {

        }

        private void cbo_designation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_designation.SelectedIndex == 0)
            {

                txtPosition.Items.Clear(); txtPosition.Text = "";
                string[] row = new string[] { "Master", "Chief Mate", "2nd Mate", "3rd mate", "A/B", "O/S", "A/M" };

                foreach (string item in row)
                {
                    txtPosition.Items.Add(item);
                }


            }
            else if (cbo_designation.SelectedIndex == 1)
            {
                txtPosition.Items.Clear(); txtPosition.Text = "";
                string[] row = new string[] { "Superintendent", "Chief Engr.", "Welder", "1st Engr.", "2nd Engr.", "3rd Engr.", "4th Engr.", "Oiler", "Wiper", "E/C" };
                foreach (string item in row)
                {
                    txtPosition.Items.Add(item);
                }
            }
            else if (cbo_designation.SelectedIndex == 2)
            {
                txtPosition.Items.Clear(); txtPosition.Text = "";
                string[] row = new string[] { "Messman", "Chief Cook" };
                foreach (string item in row)
                {
                    txtPosition.Items.Add(item);
                }

            }
            else
            {
                txtPosition.Items.Clear(); txtPosition.Text = "";
                string[] row = new string[] { "Student", "Driver", "Conductor", "Office Staff" };
                foreach (string item in row)
                {
                    txtPosition.Items.Add(item);
                }
            }


        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            cbo_designation.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPosition.Text = "";
        }

        public List<PatientSearchList_Model> patientSearchList_Model = new List<PatientSearchList_Model>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                foreach (var i in db.Patient_search("%"))
                {
                    patientSearchList_Model.Add(new PatientSearchList_Model
                    {
                        cn = Convert.ToInt32(i.cn),
                        papin = i.papin,
                        PatientName = i.Name

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
                if ((Application.OpenForms["frm_search_Patient"] as frm_search_Patient) != null)
                { (Application.OpenForms["frm_search_Patient"] as frm_search_Patient).FillDataGridView(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }



            //(Application.OpenForms["frm_search_Patient"] as frm_search_Patient).lbl_notification.Visible = false;

        }

        private void txt_papin_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {


            this.Invoke(new MethodInvoker(delegate() { loadPatient_ByPage(2); }));


        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Opacity = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {



        }
        //void load_Employer()
        //{ ClassSql a = new ClassSql(); DataTable dt;
        //dt = a.Table("Select * from tbl_employer");
        //foreach (DataRow dr in dt.Rows)
        //{
        //    cbo_employer.AutoCompleteCustomSource.Add(dr["Employer"].ToString());

        //}
        //}
    }
}
