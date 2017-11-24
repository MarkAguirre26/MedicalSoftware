using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Ini;
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
        public bool isLabo6 = false;
        public bool isLabo8 = false;
        public bool isHema = false;
        public bool isChem = false;
        public bool isUrine = false;
        public bool isFecal = false;
    
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
    public  void load_Lab06()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);

            lab06_sub1.Load(@"C:\Report\lab06_sub.rpt");
            crystalReportViewer1.ReportSource = lab06_sub1;
            

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_RevNo, "Revision");

            TextObject FormNo = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_06");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_06");


            
            TextObject aa = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text134"];
            TextObject b = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text133"];
            TextObject c = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text125"];
            TextObject d = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text98"];
            TextObject e = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text97"];
            TextObject f = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text96"];
            TextObject g = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text95"];
            TextObject h = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text144"];
            TextObject i = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text143"];
            TextObject j = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text142"];
            TextObject k = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text141"];
            TextObject l = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text140"];
            TextObject m = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text139"];
            TextObject n = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text145"];
            TextObject o = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text146"];
            TextObject p = (TextObject)lab06_sub1.ReportDefinition.ReportObjects["Text147"];

            aa.Text = ini.IniReadValue("NormalValue", "hemoglobin") +"gm/dl";
            b.Text = ini.IniReadValue("NormalValue", "hematocrit") +"vol%";
            c.Text = ini.IniReadValue("NormalValue", "RBC") +" m/cumm";
            d.Text = ini.IniReadValue("NormalValue", "WBC") +" /cumm";
            e.Text = ini.IniReadValue("NormalValue", "Platelet") +"/cumm";
            f.Text = ini.IniReadValue("NormalValue", "BloodType");
            g.Text = ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1")+"mm/hr(FEMALE)";
            h.Text = ini.IniReadValue("NormalValue", "Lympho") +"%";
            i.Text = ini.IniReadValue("NormalValue", "Segmenters")+"%";
            j.Text = ini.IniReadValue("NormalValue", "Easinophils") +"%";
            k.Text = ini.IniReadValue("NormalValue", "MonoCytes") +"%";
            l.Text = ini.IniReadValue("NormalValue", "Myelocytes");
            m.Text = ini.IniReadValue("NormalValue", "Juveniles");
            n.Text = ini.IniReadValue("NormalValue", "StabCells") +"%";
            o.Text = ini.IniReadValue("NormalValue", "BasoPhils") +"%";
            p.Text = ini.IniReadValue("NormalValue", "Hema_Other");
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
            Load_lab08();
        }

        public void Load_lab08()
        {
            lab08_sub1.Load(@"C:\Report\lab08_sub.rpt");
            crystalReportViewer2.ReportSource = lab08_sub1;


            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_08");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_08");


            TextObject aa = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["a"];
            TextObject b = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["b"];
            TextObject c = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["c"];
            TextObject d = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["d"];
            TextObject ee = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["e"];
            TextObject f = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["f"];
            TextObject g = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["g"];
            TextObject h = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["h"];
            TextObject i = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["i"];
            TextObject j = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["j"];
            TextObject k = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["k"];
            TextObject l = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["l"];
            TextObject m = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["m"];
            TextObject n = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["n"];
            TextObject o = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["o"];
            TextObject p = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["p"];

            aa.Text = ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl";
            b.Text = ini.IniReadValue("NormalValue", "hematocrit") + "vol%";
            c.Text = ini.IniReadValue("NormalValue", "RBC") + " m/cumm";
            d.Text = ini.IniReadValue("NormalValue", "WBC") + " /cumm";
            ee.Text = ini.IniReadValue("NormalValue", "Platelet") + "/cumm";
            f.Text = ini.IniReadValue("NormalValue", "BloodType");
            g.Text = ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(FEMALE)";
            h.Text = ini.IniReadValue("NormalValue", "Lympho") + "%";
            i.Text = ini.IniReadValue("NormalValue", "Segmenters") + "%";
            j.Text = ini.IniReadValue("NormalValue", "Easinophils") + "%";
            k.Text = ini.IniReadValue("NormalValue", "MonoCytes") + "%";
            l.Text = ini.IniReadValue("NormalValue", "Myelocytes");
            m.Text = ini.IniReadValue("NormalValue", "Juveniles");
            n.Text = ini.IniReadValue("NormalValue", "StabCells") + "%";
            o.Text = ini.IniReadValue("NormalValue", "BasoPhils") + "%";
            p.Text = ini.IniReadValue("NormalValue", "Hema_Other");
            //Text176
            TextObject aaa = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text156"];
            TextObject bb = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text157"];
            TextObject cc = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text174"];
            TextObject dd = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text175"];
            TextObject eee = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text176"];
            TextObject ff = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text177"];
            TextObject gg = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text178"];
            TextObject hh = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text187"];
            TextObject ii = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text188"];
            TextObject jj = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text197"];
            TextObject kk = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text196"];
            TextObject ll = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text195"];
            TextObject mm = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text194"];
            TextObject nn = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text193"];
            TextObject oo = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text192"];
            TextObject pp = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text191"];
            TextObject qq = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text190"];
            TextObject rr = (TextObject)lab08_sub1.ReportDefinition.ReportObjects["Text189"];

            aaa.Text = ini.IniReadValue("NormalValue", "fbs") + " mmol/L";
            bb.Text = ini.IniReadValue("NormalValue", "bun") + " mmol/L";
            cc.Text = ini.IniReadValue("NormalValue", "creatine") + " mmol/L";
            dd.Text = ini.IniReadValue("NormalValue", "choles") + " mmol/L";
            eee.Text = ini.IniReadValue("NormalValue", "trigly") + " mmol/L";
            ff.Text = ini.IniReadValue("NormalValue", "uric") + " mmol/L";
            gg.Text = ini.IniReadValue("NormalValue", "sgot") + " IU/L";
            hh.Text = ini.IniReadValue("NormalValue", "sgpt") + " IU/L";
            ii.Text = ini.IniReadValue("NormalValue", "alk") + " IU/L";
            jj.Text = ini.IniReadValue("NormalValue", "fbs_con") + " mg/dL";
            kk.Text = ini.IniReadValue("NormalValue", "bun_con") + " mg/dL";
            ll.Text = ini.IniReadValue("NormalValue", "creatine_Con") + " mg/dL";
            mm.Text = ini.IniReadValue("NormalValue", "Cholesterol_Con") + " mg/dL";
            nn.Text = ini.IniReadValue("NormalValue", "Trig_Con") + " mg/dL";
            oo.Text = ini.IniReadValue("NormalValue", "Uric_Con") + " mg/dL";
            pp.Text = ini.IniReadValue("NormalValue", "sgpt_con");
            qq.Text = ini.IniReadValue("NormalValue", "sgot_con");
            rr.Text = ini.IniReadValue("NormalValue", "alk_con");

            //lab08_sub1.Refresh();
            crystalReportViewer2.RefreshReport();
            RemoveTab(crystalReportViewer2);
            wizard1.SelectedTab = tabPage2;
        
        }

        private void R_Hema_CheckedChanged(object sender, EventArgs e)
        {

            Load_Hema();


        }

        public void Load_Hema()
        {
            Hema_Sub1.Load(@"C:\Report\Hema_Sub.rpt");
            crystalReportViewer3.ReportSource = Hema_Sub1;

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '3'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["txt_rev"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Hema");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Hema");

            TextObject aa = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["a"];
            TextObject b = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["b"];
            TextObject c = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["c"];
            TextObject d = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["d"];
            TextObject ee = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["e"];
            TextObject f = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["f"];
            TextObject g = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["g"];
            TextObject h = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["h"];
            TextObject i = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["i"];
            TextObject j = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["j"];
            TextObject k = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["k"];
            TextObject l = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["l"];
            TextObject m = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["m"];
            TextObject n = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["n"];
            TextObject o = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["o"];
            //TextObject p = (TextObject)Hema_Sub1.ReportDefinition.ReportObjects["p"];

            aa.Text = ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl";
            b.Text = ini.IniReadValue("NormalValue", "hematocrit") + "vol%";
            c.Text = ini.IniReadValue("NormalValue", "RBC") + " m/cumm";
            d.Text = ini.IniReadValue("NormalValue", "WBC") + " /cumm";
            ee.Text = ini.IniReadValue("NormalValue", "Platelet") + "/cumm";
            f.Text = ini.IniReadValue("NormalValue", "BloodType");
            //g.Text = ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(FEMALE)";
            g.Text = ini.IniReadValue("NormalValue", "Lympho") + "%";
            h.Text = ini.IniReadValue("NormalValue", "Segmenters") + "%";
            i.Text = ini.IniReadValue("NormalValue", "Easinophils") + "%";
            j.Text = ini.IniReadValue("NormalValue", "MonoCytes") + "%";
            k.Text = ini.IniReadValue("NormalValue", "Myelocytes");
            l.Text = ini.IniReadValue("NormalValue", "Juveniles");
            m.Text = ini.IniReadValue("NormalValue", "StabCells") + "%";
            n.Text = ini.IniReadValue("NormalValue", "BasoPhils") + "%";
            o.Text = ini.IniReadValue("NormalValue", "Hema_Other");

            //Hema_Sub1.Refresh();
            crystalReportViewer3.RefreshReport();
            RemoveTab(crystalReportViewer3);
            wizard1.SelectedTab = tabPage3;
        }
        private void R_Chem_CheckedChanged(object sender, EventArgs e)
        {
            load_Chem();
        }

        public void load_Chem()
        {
            Chem_sub1.Load(@"C:\Report\Chem_sub.rpt");
            crystalReportViewer4.ReportSource = Chem_sub1;

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_RevNo, "Revision");
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Chemistry");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Chemistry");

            TextObject a = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text9"];
            TextObject b = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text44"];
            TextObject c = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text45"];
            TextObject d = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text51"];
            TextObject ee = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text61"];
            TextObject f = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text62"];
            TextObject g = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text63"];
            TextObject h = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text64"];
            TextObject i = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text65"];
            TextObject j = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text75"];
            TextObject k = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text76"];
            TextObject l = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text77"];
            TextObject m = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text78"];
            TextObject n = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text79"];
            TextObject o = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text80"];
            TextObject p = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text81"];
            TextObject q = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text82"];
            TextObject r = (TextObject)Chem_sub1.ReportDefinition.ReportObjects["Text83"];


            a.Text = ini.IniReadValue("NormalValue", "fbs") + " mmol/L";
            b.Text = ini.IniReadValue("NormalValue", "bun") + " mmol/L";
            c.Text = ini.IniReadValue("NormalValue", "creatine") + " mmol/L";
            d.Text = ini.IniReadValue("NormalValue", "choles") + " mmol/L";
            ee.Text = ini.IniReadValue("NormalValue", "trigly") + " mmol/L";
            f.Text = ini.IniReadValue("NormalValue", "uric") + " mmol/L";
            g.Text = ini.IniReadValue("NormalValue", "sgot") + " IU/L";
            h.Text = ini.IniReadValue("NormalValue", "sgpt") + " IU/L";
            i.Text = ini.IniReadValue("NormalValue", "alk") + " IU/L";
            j.Text = ini.IniReadValue("NormalValue", "fbs_con") + " mg/dL";
            k.Text = ini.IniReadValue("NormalValue", "bun_con") + " mg/dL";
            l.Text = ini.IniReadValue("NormalValue", "creatine_Con") + " mg/dL";
            m.Text = ini.IniReadValue("NormalValue", "Cholesterol_Con") + " mg/dL";
            n.Text = ini.IniReadValue("NormalValue", "Trig_Con") + " mg/dL";
            o.Text = ini.IniReadValue("NormalValue", "Uric_Con") + " mg/dL";
            p.Text = ini.IniReadValue("NormalValue", "sgpt_con");
            q.Text = ini.IniReadValue("NormalValue", "sgot_con");
            r.Text = ini.IniReadValue("NormalValue", "alk_con");



            //Chem_sub1.Refresh();
            crystalReportViewer4.RefreshReport();
            RemoveTab(crystalReportViewer4);
            wizard1.SelectedTab = tabPage4;
        }
        private void R_Urine_CheckedChanged(object sender, EventArgs e)
        {
            load_Urin();
        }
        public void load_Urin()
        {
            Urine_sub1.Load(@"C:\Report\Urine_sub.rpt");
            crystalReportViewer5.ReportSource = Urine_sub1;

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_RevNo, "Revision");
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)Urine_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)Urine_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Urinalysis");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Urinalysis");


            //Urine_sub1.Refresh();
            crystalReportViewer5.RefreshReport();
            RemoveTab(crystalReportViewer5);
            wizard1.SelectedTab = tabPage5;
        }
        private void R_Fecal_CheckedChanged(object sender, EventArgs e)
        {
            load_Fecal();
        }

        public void load_Fecal()
        {
            Fecal_sub1.Load(@"C:\Report\Fecal_sub.rpt");
            crystalReportViewer6.ReportSource = Fecal_sub1;

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '6'", txt_ForNo, "Form");
            ////a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)Fecal_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)Fecal_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Fecalysis");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Fecalysis");


            //Fecal_sub1.Refresh();
            crystalReportViewer6.RefreshReport();
            RemoveTab(crystalReportViewer6);
            wizard1.SelectedTab = tabPage6;
        }
        private void lab_printOut_Form_Load(object sender, EventArgs e)
        {
            load_Lab06();
            //if (isLabo6)
            //{ load_Lab06(); }
            //else if (isLabo8)
            //{ Load_lab08(); }
            //else if (isHema)
            //{ Load_Hema(); }
            //else if (isChem)
            //{ load_Chem(); }
            //else if (isUrine)
            //{ load_Urin(); }
            //else if (isFecal)
            //{ load_Fecal(); }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (isLabo6)
                {
                    crystalReportViewer1.PrintReport();
                }
                else if (isLabo8)
                {
                    crystalReportViewer2.PrintReport();

                }
                else if (isHema)
                {
                    crystalReportViewer3.PrintReport();

                }
                else if (isChem)
                {
                    crystalReportViewer4.PrintReport();

                }
                else if (isUrine)
                {
                    crystalReportViewer5.PrintReport();
                }
                else if (isFecal)
                {
                    crystalReportViewer6.PrintReport();

                }
                //else if (r_lab34.Checked)
                //{ viewer34.PrintReport(); }
            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("{0}" + ex.Message + "@\n Please use the deafualt print button to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)); }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            LoadLab34();
        }
        void LoadLab34()
        {

            this.Text = "Medical Examination Certificate Print-Out";
            lab34_sub1.Load(@"C:\Report\lab34_sub.rpt");
            viewer34.ReportSource = lab34_sub1;
           // viewer34.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";


            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)lab34_sub1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)lab34_sub1.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Normal = (TextObject)lab34_sub1.ReportDefinition.ReportObjects["txt_normalValue"];
            TextObject ISO = (TextObject)lab34_sub1.ReportDefinition.ReportObjects["txt_iso"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_34");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_34");
            ISO.Text = ini.IniReadValue("ISO", "Lab_34");
            string HBSA1C_con = ini.IniReadValue("NormalValue", "HBA1C_CON");
            if (HBSA1C_con == "")
            {
                Normal.Text = ini.IniReadValue("NormalValue", "HBA1C_SI");

            }
            else
            {
                Normal.Text = ini.IniReadValue("NormalValue", "HBA1C_SI") + " - " + HBSA1C_con;
            }
            
            viewer34.RefreshReport();
            RemoveTab(viewer34);
            wizard1.SelectedTab = tabPage7;

        }

    }
}
