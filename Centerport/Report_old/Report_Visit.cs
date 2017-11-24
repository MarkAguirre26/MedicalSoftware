using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Centerport.Report
{
    public partial class Report_Visit : Form
    {
        public static string count;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;


        public Report_Visit()
        {
            InitializeComponent();
        }

        private void Report_Visit_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
              
            
            R_Visit1.Load(@"C:\Report\R_Visit.rpt");
            crystalReportViewer1.ReportSource = R_Visit1;
            crystalReportViewer1.SelectionFormula = "{t_registration1.trans_date} LIKE '*" + this.Tag.ToString() + "*'";

            TextObject MonthCover = (TextObject)R_Visit1.ReportDefinition.ReportObjects["txt_printRange"]; TextObject Total = (TextObject)R_Visit1.ReportDefinition.ReportObjects["txt_Total"];
            MonthCover.Text = "Date Range From  " + Convert.ToDateTime(this.Tag).Date.ToShortDateString() + "  To  " + Convert.ToDateTime(this.Tag).Date.ToShortDateString();
            Total.Text = "Total Patient Count:"+count;
//txt_Total
            R_Visit1.Refresh();
            crystalReportViewer1.RefreshReport();

            foreach (Control control in crystalReportViewer1.Controls)
            {
                if (control is PageView)
                {
                    TabControl tab = (TabControl)((PageView)control).Controls[0];
                    tab.ItemSize = new Size(0, 1);
                    tab.SizeMode = TabSizeMode.Fixed;
                    tab.Appearance = TabAppearance.Buttons;
                }
            }
                  
            
        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            //Check the state of the Left Mouse Button
            if ((long)m.Msg == BUTTON_DOWN_CODE)
                left_button_down = true;
            else if ((long)m.Msg == BUTTON_UP_CODE)
                left_button_down = false;

            if (left_button_down)
            {
                if ((long)m.Msg == WM_MOVING)
                {
                    //Set the forms opacity to 50% if user is moving
                    if (this.Opacity != 0.5)
                        this.Opacity = 0.5;
                }
            }

            else if (!left_button_down)
                if (this.Opacity != 1.0)
                    this.Opacity = 1.0;

            base.DefWndProc(ref m);
        }

        private void Report_Visit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            R_Visit1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Visit1.PrintToPrinter(1, false, 0, 0);

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
