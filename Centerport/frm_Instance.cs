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
    public partial class frm_Instance : Form
    {
        public frm_Instance()
        {
            InitializeComponent();
        }

        private void cmd_ok_Click(object sender, EventArgs e)
        {
            this.Close();
            Properties.Settings.Default.InstanceName = txt_Instance.Text;
            Properties.Settings.Default.Save();
            
            ClassSql.ConnectSqlInstance(Properties.Settings.Default.InstanceName);
           
        }

        private void frm_Instance_Load(object sender, EventArgs e)
        {
            txt_Instance.Text = Properties.Settings.Default.InstanceName;
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
