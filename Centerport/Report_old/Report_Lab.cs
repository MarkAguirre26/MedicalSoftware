using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
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
    public partial class Report_Lab : Form
    {

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;


        public Report_Lab()
        {
            InitializeComponent();
            this.Load += new EventHandler(Report_Lab_Load);

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
        private void Report_Lab_Load(object sender, EventArgs e)
        {

           // load_lab06();
            Cursor.Current = Cursors.Default;
            
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
   public    void load_lab06()
        {
          
          
            R_lab_061.Load(@"C:\Report\R_lab_06.rpt");
            crystalReportViewer1.ReportSource = R_lab_061;          
            crystalReportViewer1.SelectionFormula = "{t_result_main1.resultid} = '"+this.Tag.ToString() +"'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;      
    
           //R_lab_061.Refresh();
            crystalReportViewer1.RefreshReport();
            RemoveTab(crystalReportViewer1); 
            wizard1.SelectedTab = tabPage1;
       
       }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            load_lab06();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            Load_Lab08();
        }

        public void Load_Lab08()
        {
            R_lab_081.Load(@"C:\Report\R_lab_08.rpt");
            crystalReportViewer2.ReportSource = R_lab_081;
            crystalReportViewer2.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_lab_081.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lab_081.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            //R_lab_081.Refresh();
            crystalReportViewer2.RefreshReport();
            RemoveTab(crystalReportViewer2);
            wizard1.SelectedTab = tabPage2;
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            LoadHema();
           
        }
        public void LoadHema()
        {
            R_HemaLab011.Load(@"C:\Report\R_HemaLab01.rpt");
            crystalReportViewer3.ReportSource = R_HemaLab011;
            crystalReportViewer3.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '3'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["txt_formNo"];
            //TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            //RevNo.Text = txt_RevNo.Text;  

            //R_HemaLab011.Refresh();
            crystalReportViewer3.RefreshReport();
            RemoveTab(crystalReportViewer3);
            wizard1.SelectedTab = tabPage3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            Load_Chem();

           
        }
        public void Load_Chem()
        {
            R_Chemistry1.Load(@"C:\Report\R_Chemistry.rpt");
            crystalReportViewer4.ReportSource = R_Chemistry1;
            crystalReportViewer4.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;


            //R_HemaLab011.Refresh();
            crystalReportViewer4.RefreshReport();
            RemoveTab(crystalReportViewer4);
            wizard1.SelectedTab = tabPage4;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {


            Load_Urine();
        }

        public void Load_Urine()
        {
            R_Urinalysis1.Load(@"C:\Report\R_Urinalysis.rpt");
            crystalReportViewer5.ReportSource = R_Urinalysis1;
            crystalReportViewer5.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Urinalysis1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Urinalysis1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;


            //R_Urinalysis1.Refresh();
            crystalReportViewer5.RefreshReport();
            RemoveTab(crystalReportViewer5);
            wizard1.SelectedTab = tabPage5;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            load_Fecal();
           
        }
        public void load_Fecal()
        {
            R_Fecalysis1.Load(@"C:\Report\R_Fecalysis.rpt");
            crystalReportViewer6.ReportSource = R_Fecalysis1;
            crystalReportViewer6.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '6'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_Fecalysis1.ReportDefinition.ReportObjects["txt_formNo"];
            //TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            //RevNo.Text = txt_RevNo.Text;  


            //R_Urinalysis1.Refresh();
            crystalReportViewer6.RefreshReport();
            RemoveTab(crystalReportViewer6);
            wizard1.SelectedTab = tabPage6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            R_lab_061.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_lab_061.PrintToPrinter(1, false, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            R_lab_081.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_lab_081.PrintToPrinter(1, false, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            R_HemaLab011.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_HemaLab011.PrintToPrinter(1, false, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            R_Chemistry1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Chemistry1.PrintToPrinter(1, false, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            R_Urinalysis1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Urinalysis1.PrintToPrinter(1, false, 0, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            R_Fecalysis1.PrintOptions.PrinterName = Tool.PrinterPath(); 
            R_Fecalysis1.PrintToPrinter(1, false, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_Lab_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {this.Close();}
        }

    }
}
