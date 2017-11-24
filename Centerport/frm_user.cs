using Centerport.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_user : Form
    {
        DataClasses2DataContext db;// = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        Main fmain;
        public frm_user(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }
        List<user_model> user_model_ = new List<user_model>();
        private void frm_user_Load(object sender, EventArgs e)
        {

               db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);      
               LoadUserLevel();
               loaduser();

            //

        }
        void LoadUserLevel()
        {
            var level_list = db.sp_userLevel();
            foreach (var i in level_list)
            {
                this.cbo_level.Items.Add(new ComboBoxItem(i.Description, i.cn));
            }
        }
        void loaduser()
        {
            if (fmain.UserLevel == 1 || fmain.UserLevel == 2)
            {
                var list = db.sp_User().ToList();
                dataGridView1.Rows.Clear();
                foreach (var i in list)
                {

                    dataGridView1.Rows.Add(i.cn, i.Fullname, i.Username, i.Password, i.Description);
                }
             
            }
            else
            {
                var list = db.sp_loginifNotHead(this.Tag.ToString()).ToList();
                dataGridView1.Rows.Clear();
                foreach (var i in list)
                {

                    dataGridView1.Rows.Add(i.cn, i.Fullname, i.Username, i.Password, i.Description);
                }
                cmd_new.Visible = false;
            }




        }




        void Availability(bool mode, string action)
        {
            txt_name.Enabled = mode;
            txt_username.Enabled = mode;
            txt_password.Enabled = mode;
            txt_confirmPassword.Enabled = mode;
            cbo_level.Enabled = mode;
            cmd_save.Text = action;

        }
  
     

    

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_username.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_password.Text = EncodeString.Decrypt(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            cbo_level.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();      
            cmd_save.Enabled = false;
            cmd_edit.Enabled = true;
            cmd_edit.Enabled = true;
            txt_name.Enabled = false;
            txt_username.Enabled = false;
            txt_password.Enabled = false;
            txt_confirmPassword.Enabled = false;
            cbo_level.Enabled = false;
        }

        private void cmd_edit_Click(object sender, EventArgs e)
        {
            Availability(true, "Modify");
            cmd_save.Enabled = true;
            cmd_new.Enabled = true;

            cmd_edit.Enabled = false;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                MessageBox.Show(EncodeString.Decrypt(dataGridView1.SelectedRows[0].Cells[3].Value.ToString()));

            }
        }

        private void cmd_new_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_username.Clear();
            txt_password.Clear();
            txt_confirmPassword.Clear();
            cbo_level.SelectedIndex = -1;
            cmd_edit.Enabled = false;
            cmd_save.Enabled = true;
            cmd_new.Text = "Clear";
            Availability(true, "Save");
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {
            string Levelcn = ((this.cbo_level.SelectedItem as ComboBoxItem).Value.ToString());

            if (txt_name.Text == "" || txt_username.Text == "" || txt_password.Text == "" || txt_password.Text != txt_confirmPassword.Text || cbo_level.Text == "")
            {
                MessageBox.Show("Please check/Verify required informaion", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (cmd_save.Text == "Save")
                {
                    db.ExecuteCommand("INSERT INTO [Centerport_Medical].[dbo].[tbl_user] ([Fullname], [Username], [Password], [UserLevel], [Remark]) VALUES ({0},{1}, {2}, {3}, {4})", txt_name.Text, txt_username.Text, EncodeString.Encrypt(txt_password.Text), Levelcn, "1");
                    Availability(false, "Save");
                    cmd_edit.Enabled = false;
                    cmd_new.Enabled = true;
                    cmd_save.Enabled = false;
                    txt_name.Clear();
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_confirmPassword.Clear();
                    cbo_level.SelectedIndex = -1;
                    cmd_new.Text = "New";

                }
                else
                {
                    db.ExecuteCommand("UPDATE [Centerport_Medical].[dbo].[tbl_user] SET [Fullname]={0}, [Username]={1}, [Password]={2}, [UserLevel]={3} WHERE ([cn]={4})", txt_name.Text, txt_username.Text, EncodeString.Encrypt(txt_password.Text), Levelcn, dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    Availability(false, "Modify");
                    cmd_edit.Enabled = false;
                    cmd_new.Enabled = true;
                    cmd_save.Enabled = false;
                    txt_confirmPassword.Clear();
                    cmd_new.Text = "New";
                }
            }

            loaduser();
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
