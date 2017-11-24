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
    public partial class frm_Seabase_Print_Choice : Form
    {
        public string Resultid;
        public string age;
        public string MedCertNumber;
        public string recomendation;
        public frm_Seabase_Print_Choice()
        {
            InitializeComponent();
        }

        private void frm_Seabase_Print_Choice_Load(object sender, EventArgs e)
        {

        }

        private void frm_Seabase_Print_Choice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.Summary = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.Detail = true;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //Report_SeaBase_Print print = new Report_SeaBase_Print();
            //Report_SeaBase_Print.MLC1 = true;
            //print.Tag = this.Tag.ToString();
            //print.ShowDialog();
            //Cursor.Current = Cursors.Default;
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.MLC1 = true;
            print.MedCertNumber = MedCertNumber;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
            Cursor.Current = Cursors.Default;

            //using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            //{
            //    f.Tag = Resultid;
            //    f.isSeaMLC = true;
            //    f.age = age;
            //    f.ShowDialog();
            //}

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.MER = true;
            print.recomendation = recomendation;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.krpan = true;
            print.recomendation = recomendation;
            print.Tag = this.Tag.ToString();
            print.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
