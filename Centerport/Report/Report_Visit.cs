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
using MySql.Data.MySqlClient;
using CrystalDecisions.Shared;
using Ini;
using Centerport.Class;

namespace Centerport.Report
{
    public partial class Report_Visit : Form
    {
        public static string count;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;

        string printerName;
        public Report_Visit()
        {
            InitializeComponent();
        }

        private void Report_Visit_Load(object sender, EventArgs e)
        {


            Cursor.Current = Cursors.Default;
            //ClassSql a = new ClassSql(); DataSet ds;
            //ds = a.Mytable_Report("_Visit_Report", "ID", this.Tag.ToString());
            IniFile ini = new IniFile(ClassSql.MMS_Path); 
       
            Visit_Report1.Load(@"C:\Report\Visit_Report.rpt"); 
            CrystalReportLogon.Connect(Visit_Report1, ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"), ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"));
            crystalReportViewer1.ReportSource = Visit_Report1;
            crystalReportViewer1.SelectionFormula = "{t_registration1.trans_date} LIKE '*" + this.Tag.ToString() + "*'";

            TextObject MonthCover = (TextObject)Visit_Report1.ReportDefinition.ReportObjects["txt_printRange"]; TextObject Total = (TextObject)Visit_Report1.ReportDefinition.ReportObjects["txt_Total"];
            MonthCover.Text = "Date Range From  " + Convert.ToDateTime(this.Tag).Date.ToShortDateString() + "  To  " + Convert.ToDateTime(this.Tag).Date.ToShortDateString();
            Total.Text = "Total Patient Count:" + count;
           // Visit_Report1.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:\Users\Mark\Downloads\samplepdf.pdf");


            //txt_Total
            //R_Visit1.Refresh();
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


///////////////////////////////////////////////////////////

            //ReportDocument myReport = new ReportDocument();

            //if (ClassSql.cnn.State == ConnectionState.Closed)
            //{
            //    ClassSql.DbConnect();
            //    MessageBox.Show("Closed");

            //}
            //else
            //{
            //    ClassSql.DbClose();
            //    MessageBox.Show("Open");
            //}

            //try
            //{
            //    // ReportDocument myReport = new ReportDocument();
            //    DataSet myData = new DataSet();

            //    MySqlCommand cmd = new MySqlCommand();
            //    MySqlDataAdapter myAdapter = new MySqlDataAdapter();


            //    cmd.CommandText = "SELECT t_registration.pxtype, t_registration.trans_date, t_registration.diagnosis, t_registration.purpose FROM t_registration WHERE t_registration.trans_date LIKE '%" + this.Tag.ToString() + "%'";
            //    cmd.Connection = ClassSql.cnn;

            //    myAdapter.SelectCommand = cmd;
            //    myAdapter.Fill(myData);

            //    Visit_Report1.Load(@"C:\Report\Visit_Report.rpt");
            //    Visit_Report1.SetDataSource(myData);
            //    crystalReportViewer1.ReportSource = Visit_Report1;

            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message, "Report could not be created",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
         

         
           
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


            Visit_Report1.PrintOptions.PrinterName = Tool.PrinterPath();
            Visit_Report1.PrintToPrinter(1, false, 0, 0);

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Text = printDocument1.PrinterSettings.PrinterName.ToString();
            //Visit_Report1.PrintOptions.PrinterName = this.Text;
            //MessageBox.Show(Visit_Report1.PrintOptions.PrinterName.ToString());
           // Visit_Report1.PrintToPrinter(1, false, 0, 0);
            crystalReportViewer1.PrintReport();
           
        }
    }
}
