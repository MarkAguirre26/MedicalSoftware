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
    public partial class lab_printOut_Form : Form
    {
        public lab_printOut_Form()
        {
            InitializeComponent();
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
        void load_Lab06()
    {
            lab06_sub1.Load(@"C:\Report\lab06_sub.rpt");
            crystalReportViewer1.ReportSource = lab06_sub1;
            

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            //lab06_sub1.Refresh();
            crystalReportViewer1.RefreshReport();
            RemoveTab(crystalReportViewer1);
            wizard1.SelectedTab = tabPage1;}
        private void R_lab06_CheckedChanged(object sender, EventArgs e)
        {
            load_Lab06();
        }

        private void R_lab08_CheckedChanged(object sender, EventArgs e)
        {
            lab08_sub1.Load(@"C:\Report\lab08_sub.rpt");
            crystalReportViewer2.ReportSource = lab08_sub1;
            

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;

            //lab08_sub1.Refresh();
            crystalReportViewer2.RefreshReport();
            RemoveTab(crystalReportViewer2);
            wizard1.SelectedTab = tabPage2;
        }

        private void R_Hema_CheckedChanged(object sender, EventArgs e)
        {
            Hema_Sub1.Load(@"C:\Report\Hema_Sub.rpt");
            crystalReportViewer3.ReportSource = Hema_Sub1;
            
            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '3'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["txt_formNo"];
            //TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            //RevNo.Text = txt_RevNo.Text;  

            //Hema_Sub1.Refresh();
            crystalReportViewer3.RefreshReport();
            RemoveTab(crystalReportViewer3);
            wizard1.SelectedTab = tabPage3;
        }

        private void R_Chem_CheckedChanged(object sender, EventArgs e)
        {
            Chem_sub1.Load(@"C:\Report\Chem_sub.rpt");
            crystalReportViewer4.ReportSource = Chem_sub1;

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;


            //Chem_sub1.Refresh();
            crystalReportViewer4.RefreshReport();
            RemoveTab(crystalReportViewer4);
            wizard1.SelectedTab = tabPage4;
        }

        private void R_Urine_CheckedChanged(object sender, EventArgs e)
        {
            Urine_sub1.Load(@"C:\Report\Urine_sub.rpt");
            crystalReportViewer5.ReportSource = Urine_sub1;

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_ForNo, "Form");
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)Urine_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)Urine_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            RevNo.Text = txt_RevNo.Text;


            //Urine_sub1.Refresh();
            crystalReportViewer5.RefreshReport();
            RemoveTab(crystalReportViewer5);
            wizard1.SelectedTab = tabPage5;
        }

        private void R_Fecal_CheckedChanged(object sender, EventArgs e)
        {
            Fecal_sub1.Load(@"C:\Report\Fecal_sub.rpt");
            crystalReportViewer6.ReportSource = Fecal_sub1;

            ClassSql a = new ClassSql();
            TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '6'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)Fecal_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            //TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = txt_ForNo.Text;
            //RevNo.Text = txt_RevNo.Text;  


            //Fecal_sub1.Refresh();
            crystalReportViewer6.RefreshReport();
            RemoveTab(crystalReportViewer6);
            wizard1.SelectedTab = tabPage6;
        }

        private void lab_printOut_Form_Load(object sender, EventArgs e)
        {
            load_Lab06();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
