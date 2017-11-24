using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Ini;
using MySql.Data.MySqlClient;
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
    public partial class frm_lab_33_Report : Form
    {
     public   DataTable dt;
        public frm_lab_33_Report()
        {
            InitializeComponent();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void frm_lab_33_Report_Load(object sender, EventArgs e)
        {
           
            LoadReport();
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

       




        void LoadReport()
        {


           // DataSet2 ds = new DataSet2();
           // ds.Tables[0].Merge(dt);            
            this.Text = "Medical Examination Certificate Print-Out";
            R_TumorImmunological1.Load(@"C:\Report\R_TumorImmunological.rpt");
           // R_TumorImmunological1.SetDataSource(ds);
            Viewer_01.ReportSource = R_TumorImmunological1;
            Viewer_01.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject a = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["a"];
            TextObject b = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["b"];
            TextObject c = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["c"];
            TextObject d = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["d"];
            TextObject e = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["e"];
            TextObject f = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["f"];
            TextObject g = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["g"];
            TextObject h = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["h"];
            TextObject i = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["i"];

            TextObject FormNo = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["txt_formNO"];
            TextObject RevNo = (TextObject)R_TumorImmunological1.ReportDefinition.ReportObjects["txt_RevNo"];

            a.Text = ini.IniReadValue("NormalValue", "PSA");
            b.Text = ini.IniReadValue("NormalValue", "AFP");
            c.Text = ini.IniReadValue("NormalValue", "TumorOther");
            d.Text = ini.IniReadValue("NormalValue", "HBS");
            e.Text = ini.IniReadValue("NormalValue", "HBC");
            f.Text = ini.IniReadValue("NormalValue", "HCV");
            g.Text = ini.IniReadValue("NormalValue", "HBSAG");
            h.Text = ini.IniReadValue("NormalValue", "Blank");
            i.Text = ini.IniReadValue("NormalValue", "ImmuOther");

            FormNo.Text = ini.IniReadValue("FORM", "Lab_33");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_33");


            Viewer_01.RefreshReport();
            RemoveTab(Viewer_01);
           
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Viewer_01.PrintReport();
        }
    }
}
