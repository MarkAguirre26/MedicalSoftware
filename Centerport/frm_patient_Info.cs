using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_patient_Info : Form
    {
        public frm_patient_Info()
        {
            InitializeComponent();
        }

        //private void cmd_ok_Click(object sender, EventArgs e)
        //{
        //    if (cmd_ok.Text == "&OK")
        //    {
        //        this.Close();
        //    }
        //    else
        //    {
               
        //        if (txt_firstname.Text == "" || txt_lastname.Text == "" || txt_middlename.Text == "")
        //        {
        //            MessageBox.Show("Please Fill all required information!","Action Denied",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        //            return;
        //        }
        //        else {

        //            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
        //            db.sp_updateName(txt_lastname.Text, txt_firstname.Text, txt_middlename.Text, dtbday.Text, txtgender.Text, txtaddress.Text, txtcontact.Text, txtemployer.Text, txtposition.Text, txtpassport.Text, txtSemanBook.Text, txt_SIRB.Text, this.Tag.ToString());
        //            (Application.OpenForms["frm_seafarer_MEC"] as frm_seafarer_MEC).Search_Patient();
        //            this.Close();
        //        }
                
                

        //    }

        //}

        private void frm_patient_Info_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            { Search(this.Tag.ToString()); }
            else
            { MessageBox.Show("Please select patient.", "Select patient", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            
        }

     

        void Search(string ID)
        {

            try
            {
                foreach (Control c in panel1.Controls)
                {
                    if (c is TextBox)
                    {
                        (c as TextBox).ReadOnly = false;
                        (c as TextBox).CharacterCasing = CharacterCasing.Normal;

                    }

                }
                
                
                
                
                // ClassSql a = new ClassSql(); DataTable dt;
               // dt = a.Table("Select * from m_patient where papin = '"+ID+"' ");           
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                var lists = (from m in db.view_patients where m.papin.Contains(ID) select m).ToList();
                Tool.ClearForm(this);
                Cursor.Current = Cursors.WaitCursor;
                foreach (var i in lists)
                {

                    txt_firstname.Text = i.firstname.ToString();
                    txt_middlename.Text = i.middlename.ToString();
                    txt_lastname.Text = i.lastname.ToString();
                    try
                    { dtbday.Text = i.birthdate.ToString(); }
                    catch
                    { }
                    txtgender.Text = i.gender.ToString();
                    txtaddress.Text = i.address_1.ToString() + "/" + i.city.ToString();
                    txtcontact.Text = i.contact_1.ToString() + "," + i.contact_2.ToString();
                    txtemployer.Text = i.employer.ToString();
                    txtdesignation.Text = i.designation.ToString();
                    txtposition.Text = i.position.ToString();
                    txt_SIRB.Text = i.sirb.ToString();
                    txtpassport.Text = i.passport_no.ToString();
                    txtSemanBook.Text = i.seamansbook_no.ToString();
                    txt_marital.Text = i.marital_status.ToString();
                    pic_.Image = Tool.bytetoimage(i.picture);
                                      

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
           

        }

        private void frm_patient_Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Tag = null;
        }

        private void frm_patient_Info_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

        private void cmd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
