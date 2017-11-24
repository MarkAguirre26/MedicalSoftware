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

namespace Centerport.Report
{
    public partial class Report_Landbase : Form
    {
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;





        public Report_Landbase()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Load_Summary();
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
      public  void Load_Summary()
        {

            R_lanabase_Summary1.Load(@"C:\Report\R_lanabase_Summary.rpt");
            crystalReportViewer1.ReportSource = R_lanabase_Summary1;
            crystalReportViewer1.SelectionFormula = "{t_result_main1.resultid} = '"+this.Tag.ToString()+"'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '15'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lanabase_Summary1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

          //  R_lanabase_Summary1.Refresh();
            crystalReportViewer1.RefreshReport();
            RemoveTab(crystalReportViewer1);
            wizard1.SelectedTab = tabPage1;

        }

        private void Report_Landbase_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            Load_Summary();
            Load_MER();
            load_Detailed();
            Load_MLC();
            //Load_MLC();
            //load_Detailed();
            //Load_MER();
        }

        void Load_MLC()
        {

            R_landbaseMLC1.Load(@"C:\Report\R_landbaseMLC.rpt");
            crystalReportViewer2.ReportSource = R_landbaseMLC1;
            crystalReportViewer2.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '18'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_landbaseMLC1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
           // R_landbaseMLC1.Refresh();
            crystalReportViewer2.RefreshReport();
            RemoveTab(crystalReportViewer2);        
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Load_MLC();
          
            wizard1.SelectedTab = tabPage2;

        }
        void Load_MER()
        {

            R_Landbade_MER1.Load(@"C:\Report\R_Landbade_MER.rpt");
            crystalReportViewer4.ReportSource = R_Landbade_MER1;
            crystalReportViewer4.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_RevNo, "Revision");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ISO, "ISO");
            TextObject FormNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            Iso.Text = txt_ISO.Text;
           // R_Landbade_MER1.Refresh();
            crystalReportViewer4.RefreshReport();
            RemoveTab(crystalReportViewer4);


            LandBase_MER21.Load(@"C:\Report\LandBase_MER2.rpt");
            crystalReportViewer5.ReportSource = LandBase_MER21;
            crystalReportViewer5.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_RevNo, "Revision");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '17'", txt_ISO, "ISO");
            //TextObject FormNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_formNo"];
            //TextObject RevNo = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_RevNo"];
            //TextObject Iso = (TextObject)R_Landbade_MER1.ReportDefinition.ReportObjects["txt_iso"];
            //FormNo.Text = txt_ForNo.Text;
            //RevNo.Text = txt_RevNo.Text;
            //Iso.Text = txt_ISO.Text;

            // R_Landbade_MER1.Refresh();
            crystalReportViewer5.RefreshReport();
            RemoveTab(crystalReportViewer5);



        }


        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Load_MER();
            wizard1.SelectedTab = tabPage4;
            tabControl1.SelectedTab = tabPage5;

        }
        void load_Detailed()
        {
            R_Landbase_Detailed1.Load(@"C:\Report\R_Landbase_Detailed.rpt");
            crystalReportViewer3.ReportSource = R_Landbase_Detailed1;
            crystalReportViewer3.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox(); TextBox txt_ISO = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_RevNo, "Revision");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '16'", txt_ISO, "ISO");
            TextObject FormNo = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Iso = (TextObject)R_Landbase_Detailed1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;
            Iso.Text = txt_ISO.Text;

           // R_Landbase_Detailed1.Refresh();
            crystalReportViewer3.RefreshReport();
            RemoveTab(crystalReportViewer3);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            load_Detailed();
            wizard1.SelectedTab = tabPage3;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void R_lanabase_Summary1_InitReport(object sender, EventArgs e)
        {

        }

        private void R_Landbade_MER1_InitReport(object sender, EventArgs e)
        {

        }

        private void wizard1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer3_Load(object sender, EventArgs e)
        {

        }

        private void R_Landbase_Detailed1_InitReport(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            R_lanabase_Summary1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_lanabase_Summary1.PrintToPrinter(1, false, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            R_landbaseMLC1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_landbaseMLC1.PrintToPrinter(1, false, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            R_Landbase_Detailed1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Landbase_Detailed1.PrintToPrinter(1, false, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            R_Landbade_MER1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Landbade_MER1.PrintToPrinter(1, false, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_Landbase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }

    }
}
