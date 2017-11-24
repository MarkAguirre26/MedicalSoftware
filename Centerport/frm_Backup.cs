using MySql.Data.MySqlClient;
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
    public partial class frm_Backup : Form
    {
        Main fmain;
        public frm_Backup(Main mmain)
        {
            InitializeComponent();
            fmain = mmain;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ClassSql a = new ClassSql(); 
            //if (this.rb_backup.Checked == true || this.rb_restore.Checked == true)
            //{
            //    if (rb_backup.Checked)
            //    {

            //        //progressBar1.Value = 30;

            //            a.MySqlBackup(ClassSql.ConnString);
            //          //  progressBar1.Value = 100;
                   
            //        }
            //    else if (rb_restore.Checked)
            //    {
            //        MessageBox.Show("Operation not allowed please contact your system administrator.", "Action denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        //a.MysqlRestore(ClassSql.ConnString);

            //    }
                               




            //}
            //else
            //{
            //    MessageBox.Show("Action Denied! No Selected item", Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            //}
             
        }

        private void frm_Backup_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            { 
                this.Close();
            }
        }

      

      
    
        
    }
}
