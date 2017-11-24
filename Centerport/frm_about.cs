using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_about : Form
    {
        public frm_about()
        {
            InitializeComponent();
        }

        private void frm_about_Load(object sender, EventArgs e)
        {
            label5.Text = Properties.Settings.Default.SystemName.ToString() + Tool.version;
            label1.Text = "Version: " + Tool.version;
            //
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://hsgsoftware.com/");
        }

        private void cmd_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
