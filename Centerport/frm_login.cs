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
    public partial class frm_login : Form
    {
        Main fmain;
        public frm_login(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }

        private void cmd_login_Click(object sender, EventArgs e)
        {
            try
            {

                DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
                string pwd = EncodeString.Encrypt(txt_password.Text);
                var list = db.sp_login(txt_username.Text, pwd).ToList();

                if (list.Count() >= 1)
                {
                    foreach (var i in list)
                    {

                        fmain.UserLevel = Convert.ToInt32(i.UserLevel);
                        fmain.UserCn = i.cn;
                    }
                    txt_username.Clear();
                    txt_password.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User does not exist", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }

            }
            catch
            {
                new frm_server().ShowDialog();
            }

        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            fmain.isfromLogin = true;
            Application.Exit();
        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            if (System.Environment.MachineName == "CMSISERVER")
            {
                ClassSql.ConnectSqlInstance(Properties.Settings.Default.InstanceName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (FormPrint)
            //{
                Cursor.Current = Cursors.WaitCursor;
                //FormPrint = false;
                frm_FormPrinting frm_print = new frm_FormPrinting();
                //frm_print.MdiParent = this;
                frm_print.Show();

            //}
        }
    }
}
