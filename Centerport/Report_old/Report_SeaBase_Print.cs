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

namespace Centerport
{
    public partial class Report_SeaBase_Print : Form
    {

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;

        private bool Summary, Detail, MER, MLC1, MLC2;
        
        public Report_SeaBase_Print()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Load_Summary();
        }
        void RemoveTab(CrystalReportViewer rpt)
        {

            foreach (Control control in rpt.Controls)
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
        void Load_Summary()
        {


            //Summary = true; Detail = false; MER = false; MLC1 = false; MLC2 = false;
            R_Seabase_Summary1.Load(@"C:\Report\R_Seabase_Summary.rpt");
            crystalReportViewer1.ReportSource = R_Seabase_Summary1;
            crystalReportViewer1.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '11'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_RevNo"];
            //TextObject CompanyName = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_CompanyName"];
            //TextObject CompanyAdd = (TextObject)R_Seabase_Summary1.ReportDefinition.ReportObjects["txt_CompanyAdd"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            //CompanyName.Text = Properties.Settings.Default.CompanyName.ToString();
            //CompanyAdd.Text = Properties.Settings.Default.CompanyAdd.ToString();
            //R_Seabase_Summary1.Refresh();
            crystalReportViewer1.RefreshReport();
            RemoveTab(crystalReportViewer1);
            wizard1.SelectedTab = tabPage1;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Load_mlc();
        }
        public void Load_mlc()
        {
            //Summary = false; Detail = false; MER = false; MLC1 = true ; MLC2 = false;
            R_Seabase_MLC1.Load(@"C:\Report\R_Seabase_MLC.rpt");
            crystalReportViewer2.ReportSource = R_Seabase_MLC1;
            crystalReportViewer2.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '14'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '14'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject CompanyName = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_CompanyName"];
            TextObject CompanyAdd = (TextObject)R_Seabase_MLC1.ReportDefinition.ReportObjects["txt_CompanyAdd"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            CompanyName.Text = Properties.Settings.Default.CompanyName.ToString();
            CompanyAdd.Text = Properties.Settings.Default.CompanyAdd.ToString();
            //R_Seabase_MLC1.Refresh();
            crystalReportViewer2.RefreshReport();
            RemoveTab(crystalReportViewer2);
            wizard1.SelectedTab = tabPage2;}

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
            R_Seabase_MER1.Load(@"C:\Report\R_Seabase_MER.rpt");
            crystalReportViewer4.ReportSource = R_Seabase_MER1;
            crystalReportViewer4.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '13'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '13'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Seabase_MER1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Seabase_MER1.ReportDefinition.ReportObjects["txt_RevNo"];          
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;         
           // /R_Seabase_MER1.Refresh();
            crystalReportViewer4.RefreshReport();
            RemoveTab(crystalReportViewer4);

            wizard1.SelectedTab = tabPage4;

            tabControl1.SelectedTab = tabPage5;

            Seabase_MER_Page21.Load(@"C:\Report\Seabase_MER_Page2.rpt");
            crystalReportViewer5.ReportSource = Seabase_MER_Page21;
            crystalReportViewer5.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo2 = new TextBox(); TextBox txt_RevNo2 = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '13'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '13'", txt_RevNo, "Revision");
            //TextObject FormNo2 = (TextObject)Seabase_MER_Page21.ReportDefinition.ReportObjects["txt_formNo"];
            //TextObject RevNo2 = (TextObject)Seabase_MER_Page21.ReportDefinition.ReportObjects["txt_RevNo"];
            //FormNo2.Text = txt_ForNo2.Text;
            //RevNo2.Text = txt_RevNo2.Text;

            // /R_Seabase_MER1.Refresh();
            crystalReportViewer5.RefreshReport();
            RemoveTab(crystalReportViewer5);
           // wizard1.SelectedTab = tabPage4;



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
        private void Report_SeaBase_Print_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            Load_Summary();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Summary = false; Detail = true; MER = false; MLC1 = true; MLC2 = false; 
            R_SeabaseDetailed1.Load(@"C:\Report\R_SeabaseDetailed.rpt");
            crystalReportViewer3.ReportSource = R_SeabaseDetailed1;
            crystalReportViewer3.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_RevNo, "Revision");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '12'", txt_ISO, "ISO");
            TextObject FormNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject ISO = (TextObject)R_SeabaseDetailed1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            ISO.Text = txt_ISO.Text;

            //R_SeabaseDetailed1.Refresh();
            crystalReportViewer3.RefreshReport();
            RemoveTab(crystalReportViewer3);
            wizard1.SelectedTab = tabPage3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //R_Seabase_Summary1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            //R_Seabase_Summary1.PrintToPrinter(1, false, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            R_Seabase_MLC1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Seabase_MLC1.PrintToPrinter(1, false, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            R_SeabaseDetailed1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_SeabaseDetailed1.PrintToPrinter(1, false, 0, 0); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            R_Seabase_MER1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Seabase_MER1.PrintToPrinter(1, false, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_SeaBase_Print_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

    }
}
