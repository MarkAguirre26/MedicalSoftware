using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport.Report
{
    public partial class frm_landbase_Print_Choice : Form
    {
        public string resultid;
        public string age;
        public frm_landbase_Print_Choice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.Summary = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.Detailed = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            Cursor.Current = Cursors.WaitCursor;
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.MLC = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
  

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.MER = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
        }

        private void frm_landbase_Print_Choice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

        private void frm_landbase_Print_Choice_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report_Landbase print = new Report_Landbase();
            Report_Landbase.MLC = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
