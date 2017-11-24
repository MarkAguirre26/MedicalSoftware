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
     
    public partial class frm_MLC_Print : Form
    {
        public string resultid;
        public string Age;
        public frm_MLC_Print()
        {
            InitializeComponent();
        }

        private void frm_MLC_Print_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isSeaMLC = true;
                f.Tag = resultid;
                f.age = Age;
                f.ShowDialog();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print print = new Report_SeaBase_Print();
            Report_SeaBase_Print.MLC1 = true;
            print.Tag = resultid;
            print.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
