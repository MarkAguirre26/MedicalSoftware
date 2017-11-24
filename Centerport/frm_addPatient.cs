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

namespace Centerport
{
    public partial class frm_addPatient : Form
    {
        //private int Papin = 0; 
        private bool bl;
        public static PictureBox img;
        public frm_addPatient()
        {
            InitializeComponent();
            img = pic_; img.AllowDrop = true;
        }

        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        bool isclose = false;
        private void cmd_save_cancel_Click(object sender, EventArgs e)
        {
            if (txt_papin.Text == "" || txt_lastname.Text == "" || txt_fname.Text == "" || txt_mname.Text == "" || dtbday.Text == "00/00/0000")
            {
                MessageBox.Show("Please fill required information. \nLast name \nFirst name \nMiddle name \nBirth date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
                isclose = true;  

            }

            
           
        }
        public  string ReplaceString(string str)
        {
            return str.Replace("'", "`").Replace(@"\", "\\");
        }


       



        void SaveImage()
        {


            if (img.Image != null)
            {
                

                MySqlCommand cmd;               
                Image myBitmap = pic_.Image;
                var imageStream = new MemoryStream();
                using (imageStream)
                {                 
                    myBitmap.Save(imageStream, ImageFormat.Png);
                    imageStream.Position = 0;                 
                    byte[] imageBytes = imageStream.ToArray();
                   
                    using (MySqlConnection con = new MySqlConnection(ClassSql.ConnString))
                    {

                        con.Open();
                        cmd = new MySqlCommand("Update m_patient SET picture = @picture where papin ='" + txt_papin.Text + "'", con);
                        cmd.Parameters.Add("@picture", MySqlDbType.LongBlob, 100);
                        cmd.Parameters["@picture"].Value = imageBytes;
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }

                  
                   

                    
                }

            }
           
            
                          

        }

        


        void RegisterPatient()
        {
            try
            {
                               
                if (cmd_save.Text == "&Save")
                {
                   if (txt_papin.Text == "" || txt_lastname.Text == "" || txt_fname.Text == "" || txt_mname.Text == "" || dtbday.Text == "00/00/0000")
                    {
                        MessageBox.Show("Please fill required information. \nLast name \nFirst name \nMiddle name \nBirth date","Message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }

                    else
                    {

                     
                        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);                    
                        db.ExecuteCommand("INSERT INTO m_patient (papin, lastname, firstname, middlename, address_1, address_2, city, district, contact_1, contact_2, position, marital_status, gender, birthdate, place_of_birth, type_of_job, employer, passport_no, seamansbook_no, picture,registration_date, remarks, nationality, religion, test_data, father_name, father_occupation, mother_name, no_of_brothers, no_of_sisters, birth_order, spouse_name, spouse_occupation, no_of_children, elementary, highschool, college, course, highest_level_attended, mother_occupation, prev_work_start, prev_work_end, prev_company, prev_position, prev_leave_reason, prev_years, date_last_updated, sirb, designation,country_destination) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49})", txt_papin.Text, txt_lastname.Text, txt_fname.Text, txt_mname.Text, txt_address1.Text, "", txt_city.Text, '-', txt_contactNo.Text, '-', cbo_position.Text, cbo_marital.Text, cbo_gender.Text, dtbday.Text, txt_placeofBirth.Text, cbo_position.Text, cbo_employer.Text, txt_passport.Text, txt_seamanNo.Text, Tool.ImageToByte(pic_.Image), dt_regDate.Text, txt_remark.Text, txt_nationality.Text, cbo_religeon.Text, '0', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', "00/00/0000", "00/00/0000", '-', '-', '-', '-', DateTime.Now, txt_SIRB.Text, '-', txt_destination.Text);
                        db.ExecuteCommand("INSERT INTO t_registration (trkid, papin, pxtype, trans_date, diagnosis,purpose) values ({0},{1},{2},{3},{4},{5})", txt_trackingNo.Text, txt_papin.Text, cbo_patient_Type.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), "", txt_purpose.Text);
                        (Application.OpenForms["frm_visit"] as frm_visit).backgroundWorker1.RunWorkerAsync();                            

                        Tool.MessageBoxSave();
                        Tool.ClearFields(panel2); Tool.ClearFields(panel3); Tool.ClearFields(panel4); Tool.ClearFields(panel5); Tool.ClearFields(panel6); Tool.ClearFields(panel7);
                        dtbday.CustomFormat = "00/00/0000";
                       img.Image = null;
                    }

                }
               
                //Update code here/////////////

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
          

        
        
        }


        private void cmd_save_Click(object sender, EventArgs e)
        {
          
        
            backgroundWorker1.RunWorkerAsync();
            isclose = false;
        }

        private void frm_addPatient_Load(object sender, EventArgs e)
        {
            //ClassSql.DbConnect();
            txt_papin.Text = ClassSql.CreateID();         
          
            load();
            load_Employer();
            Cursor.Current = Cursors.Default;
        }

       void load_Employer()
        {
            string[] lineOfContents = File.ReadAllLines(ClassSql.EmployerPath);
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                this.cbo_employer.Items.Add(tokens[0]);
                cbo_employer.AutoCompleteCustomSource.Add(tokens[0]);
            }
        }

        void load()
        {
            cbo_patient_Type.Text = "BNI";
            txt_transdateAndTime.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            txt_purpose.Select();
            //txt_trackingNo.Text = ClassSql.CreateTrackingId();


        }

 
        private void txt_lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txt_fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txt_mname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
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
            e.Effect = DragDropEffects.Move;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          

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
            int Age = CurrentDate.Year - dtbday.Value.Year;
            //this.txt_age.Text = Age.ToString();
            if (CurrentDate.Month < dtbday.Value.Month)
            {
                Age--;
            }
            else if ((CurrentDate.Month == dtbday.Value.Month) && (CurrentDate.Day < dtbday.Value.Day))
            {

                Age--;
            }
            this.txt_age.Text = Age.ToString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                pic_.Image.Dispose();
                pic_.Image = null;
            }
            catch
            {

            }
        }

        //private void cmd_add_Employer_Click(object sender, EventArgs e)
        //{
        //    ClassSql a = new ClassSql();
        //    if (a.CountColumn("Select * from tbl_employer where Employer = '" + Tool.ReplaceString(cbo_employer.Text) + "'") >= 1)
        //    {
        //        MessageBox.Show("Employer name already exist", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }
        //    else
        //    {
        //        a.ExecuteQuery("Insert into tbl_employer (Employer) values('" + Tool.ReplaceString(cbo_employer.Text) + "')");
        //        MessageBox.Show("Employer name added", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //}

        private void frm_addPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassSql.DbClose();
        }

        private void dtbday_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void dtbday_ValueChanged(object sender, EventArgs e)
        {
          
            dtbday.Format = DateTimePickerFormat.Custom;
            dtbday.CustomFormat = "MM/dd/yyyy";
            DateTime CurrentDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            int Age = CurrentDate.Year - dtbday.Value.Year;
            //this.txt_age.Text = Age.ToString();
            if (CurrentDate.Month < dtbday.Value.Month)
            {
                Age--;
            }
            else if ((CurrentDate.Month == dtbday.Value.Month) && (CurrentDate.Day < dtbday.Value.Day))
            {

                Age--;
            }
            this.txt_age.Text = Age.ToString();
            SendKeys.Send("{RIGHT}");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { RegisterPatient(); }));
            this.Invoke(new MethodInvoker(delegate() { txt_papin.Text = ClassSql.CreateID(); }));

            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            (Application.OpenForms["frm_visit"] as frm_visit).Visit_Add_model.Clear();
            (Application.OpenForms["frm_visit"] as frm_visit).backgroundWorker1.RunWorkerAsync();            
            if (isclose)   {    this.Close();      }
           
        }

       
    }
}
