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
using Ini;

namespace Centerport.Report
{
    public partial class Report_Lab : Form
    {

        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;

        public bool isLabo6 = false;
        public bool isLabo8 = false;
        public bool isHema = false;
        public bool isChem = false;
        public bool isUrine = false;
        public bool isFecal = false;

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
            //Load_Lab08();
            if (isLabo6)
            { load_lab06(); }
            else if (isLabo8)
            { Load_Lab08(); }
            else if (isHema)
            { LoadHema(); }
            else if (isChem)
            { Load_Chem(); }
            else if (isUrine)
            { Load_Urine(); }
            else if (isFecal)
            { load_Fecal(); }


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
            IniFile ini = new IniFile(ClassSql.MMS_Path);


  
       

         


            R_lab_061.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_lab_061.Load(@"C:\Report\R_lab_06.rpt");
            Viewer_01.ReportSource = R_lab_061;          
            Viewer_01.SelectionFormula = "{t_result_main1.resultid} = '"+this.Tag.ToString() +"'";
          
            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '1'", txt_RevNo, "Revision");
            TextObject FormNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_06");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_06");


            TextObject aa = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text134"];
            TextObject b = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text133"];
            TextObject c = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text125"];
            TextObject d = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text98"];
            TextObject e = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text97"];
            TextObject f = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text96"];
            TextObject g = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text95"];
            TextObject h = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text144"];
            TextObject i = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text143"];
            TextObject j = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text142"];
            TextObject k = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text141"];
            TextObject l = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text140"];
            TextObject m = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text139"];
            TextObject n = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text145"];
            TextObject o = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text146"];
            TextObject p = (TextObject) R_lab_061.ReportDefinition.ReportObjects["Text147"];

            aa.Text = ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl";
            b.Text = ini.IniReadValue("NormalValue", "hematocrit") + "vol%";
            c.Text = ini.IniReadValue("NormalValue", "RBC") + " m/cumm";
            d.Text = ini.IniReadValue("NormalValue", "WBC") + " /cumm";
            e.Text = ini.IniReadValue("NormalValue", "Platelet") + "/cumm";
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

         
           //R_lab_061.Refresh();
            Viewer_01.RefreshReport();
            RemoveTab(Viewer_01); 
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
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_lab_081.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_lab_081.Load(@"C:\Report\R_lab_08.rpt");
            Viewer_02.ReportSource = R_lab_081;
            Viewer_02.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
         
            TextObject FormNo = (TextObject)R_lab_081.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lab_081.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_08");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_08");

            TextObject aa = (TextObject)R_lab_081.ReportDefinition.ReportObjects["a"];
            TextObject b = (TextObject)R_lab_081.ReportDefinition.ReportObjects["b"];
            TextObject c = (TextObject)R_lab_081.ReportDefinition.ReportObjects["c"];
            TextObject d = (TextObject)R_lab_081.ReportDefinition.ReportObjects["d"];
            TextObject ee = (TextObject)R_lab_081.ReportDefinition.ReportObjects["e"];
            TextObject f = (TextObject)R_lab_081.ReportDefinition.ReportObjects["f"];
            TextObject g = (TextObject)R_lab_081.ReportDefinition.ReportObjects["g"];
            TextObject h = (TextObject)R_lab_081.ReportDefinition.ReportObjects["h"];
            TextObject i = (TextObject)R_lab_081.ReportDefinition.ReportObjects["i"];
            TextObject j = (TextObject)R_lab_081.ReportDefinition.ReportObjects["j"];
            TextObject k = (TextObject)R_lab_081.ReportDefinition.ReportObjects["k"];
            TextObject l = (TextObject)R_lab_081.ReportDefinition.ReportObjects["l"];
            TextObject m = (TextObject)R_lab_081.ReportDefinition.ReportObjects["m"];
            TextObject n = (TextObject)R_lab_081.ReportDefinition.ReportObjects["n"];
            TextObject o = (TextObject)R_lab_081.ReportDefinition.ReportObjects["o"];
            TextObject p = (TextObject)R_lab_081.ReportDefinition.ReportObjects["p"];

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

            TextObject aaa = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text156"];
            TextObject bb = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text157"];
            TextObject cc = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text174"];
            TextObject dd = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text175"];
            TextObject eee = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text176"];
            TextObject ff = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text177"];
            TextObject gg = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text178"];
            TextObject hh = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text187"];
            TextObject ii = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text188"];
            TextObject jj = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text197"];
            TextObject kk = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text196"];
            TextObject ll = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text195"];
            TextObject mm = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text194"];
            TextObject nn = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text193"];
            TextObject oo = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text192"];
            TextObject pp = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text191"];
            TextObject qq = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text190"];
            TextObject rr = (TextObject)R_lab_081.ReportDefinition.ReportObjects["Text189"];

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














            //R_lab_081.Refresh();
            Viewer_02.RefreshReport();
            RemoveTab(Viewer_02);
            wizard1.SelectedTab = tabPage2;
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            LoadHema();
           
        }
        public void LoadHema()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_HemaLab011.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_HemaLab011.Load(@"C:\Report\R_HemaLab01.rpt");
            Viewer_03.ReportSource = R_HemaLab011;
            Viewer_03.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '3'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
          
            TextObject FormNo = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["txt_rev"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Hema");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Hema");

            TextObject aa = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["a"];
            TextObject b = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["b"];
            TextObject c = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["c"];
            TextObject d = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["d"];
            TextObject e = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["e"];
            TextObject f = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["f"];
            TextObject g = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["g"];
            TextObject h = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["h"];
            TextObject i = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["i"];
            TextObject j = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["j"];
            TextObject k = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["k"];
            TextObject l = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["l"];
            TextObject m = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["m"];
            TextObject n = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["n"];
            TextObject o = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["o"];
            //TextObject p = (TextObject)R_HemaLab011.ReportDefinition.ReportObjects["p"];

            aa.Text = ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl";
            b.Text = ini.IniReadValue("NormalValue", "hematocrit") + "vol%";
            c.Text = ini.IniReadValue("NormalValue", "RBC") + " m/cumm";
            d.Text = ini.IniReadValue("NormalValue", "WBC") + " /cumm";
            e.Text = ini.IniReadValue("NormalValue", "Platelet") + "/cumm";
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

            //R_HemaLab011.Refresh();
            Viewer_03.RefreshReport();
            RemoveTab(Viewer_03);
            wizard1.SelectedTab = tabPage3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            Load_Chem();

           
        }
        public void Load_Chem()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Chemistry1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_Chemistry1.Load(@"C:\Report\R_Chemistry.rpt");
            Viewer_04.ReportSource = R_Chemistry1;
            Viewer_04.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '4'", txt_RevNo, "Revision");
           
            TextObject FormNo = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Chemistry");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Chemistry");


            TextObject a = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text9"];
            TextObject b = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text44"];
            TextObject c = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text45"];
            TextObject d = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text51"];
            TextObject e = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text61"];
            TextObject f = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text62"];
            TextObject g = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text63"];
            TextObject h = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text64"];
            TextObject i = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text65"];
            TextObject j = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text75"];
            TextObject k = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text76"];
            TextObject l = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text77"];
            TextObject m = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text78"];
            TextObject n = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text79"];
            TextObject o = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text80"];
            TextObject p = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text81"];
            TextObject q = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text82"];
            TextObject r = (TextObject)R_Chemistry1.ReportDefinition.ReportObjects["Text83"];

           
            a.Text = ini.IniReadValue("NormalValue", "fbs") + " mmol/L";
            b.Text = ini.IniReadValue("NormalValue", "bun") + " mmol/L";
            c.Text = ini.IniReadValue("NormalValue", "creatine") + " mmol/L";
            d.Text = ini.IniReadValue("NormalValue", "choles") + " mmol/L";
            e.Text = ini.IniReadValue("NormalValue", "trigly") + " mmol/L";
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





            //R_HemaLab011.Refresh();
            Viewer_04.RefreshReport();
            RemoveTab(Viewer_04);
            wizard1.SelectedTab = tabPage4;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {


            Load_Urine();
        }

        public void Load_Urine()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Urinalysis1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_Urinalysis1.Load(@"C:\Report\R_Urinalysis.rpt");
            Viewer_05.ReportSource = R_Urinalysis1;
            Viewer_05.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '5'", txt_RevNo, "Revision");
           
            TextObject FormNo = (TextObject)R_Urinalysis1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_Urinalysis1.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Urinalysis");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Urinalysis"); 


            //R_Urinalysis1.Refresh();
            Viewer_05.RefreshReport();
            RemoveTab(Viewer_05);
            wizard1.SelectedTab = tabPage5;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            load_Fecal();
           
        }
        public void load_Fecal()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            R_Fecalysis1.SetDatabaseLogon(ini.IniReadValue("CONNECTIONSTRING", "Uid"), ini.IniReadValue("CONNECTIONSTRING", "Pwd"), ini.IniReadValue("CONNECTIONSTRING", "Server"), ini.IniReadValue("CONNECTIONSTRING", "Database"));

            R_Fecalysis1.Load(@"C:\Report\R_Fecalysis.rpt");
            Viewer_06.ReportSource = R_Fecalysis1;
            Viewer_06.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            //ClassSql a = new ClassSql();
            //TextBox txt_ForNo = new TextBox(); TextBox txt_RevNo = new TextBox();
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '6'", txt_ForNo, "Form");
            //a.PutDataTOTextBox("SELECT * FROM tbl_formno WHERE cn = '2'", txt_RevNo, "Revision");
           
            TextObject FormNo = (TextObject)R_Fecalysis1.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_lab_061.ReportDefinition.ReportObjects["txt_RevNo"];
            FormNo.Text = ini.IniReadValue("FORM", "Lab_Fecalysis");
            RevNo.Text = ini.IniReadValue("REVISION", "Lab_Fecalysis"); 


            //R_Urinalysis1.Refresh();
            Viewer_06.RefreshReport();
            RemoveTab(Viewer_06);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
           
            try
            {
                if (isLabo6)
                {

                    //R_lab_061.PrintOptions.PrinterName = Tool.PrinterPath();
                 
                    //R_lab_061.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    //R_lab_061.PrintToPrinter(1, false, 0, 0);
                    Viewer_01.PrintReport();
                }
                else if (isLabo8)
                {
                    //R_lab_081.PrintOptions.PrinterName = Tool.PrinterPath();
                    //R_lab_081.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    //R_lab_081.PrintToPrinter(1, false, 0, 0);
                    Viewer_02.PrintReport();

                }
                else if (isHema)
                {
                    //R_HemaLab011.PrintOptions.PrinterName = Tool.PrinterPath();
                    //R_HemaLab011.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    //R_HemaLab011.PrintToPrinter(1, false, 0, 0);

                    Viewer_03.PrintReport();
                }
                else if (isChem)
                {
                //    R_Chemistry1.PrintOptions.PrinterName = Tool.PrinterPath();
                //    R_Chemistry1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //    R_Chemistry1.PrintToPrinter(1, false, 0, 0);
                    Viewer_04.PrintReport();

                }
                else if (isUrine)
                {
                    //R_Urinalysis1.PrintOptions.PrinterName = Tool.PrinterPath();
                    //R_Urinalysis1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    //R_Urinalysis1.PrintToPrinter(1, false, 0, 0);
                    Viewer_05.PrintReport();
                }
                else if (isFecal)
                {
                    Viewer_06.PrintReport();

                }
                //else if (r_lab34.Checked)
                //{
                //    crystalReport_lab34.PrintReport();
                //}

            }
            catch (Exception ex)
            { MessageBox.Show(string.Format("{0}" + ex.Message + "@\n Please use the deafualt print button to print.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)); }

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            LoadLab34();
        }
        void LoadLab34()
        {
            
            this.Text = "Medical Examination Certificate Print-Out";
            R_chemistry_Form341.Load(@"C:\Report\R_chemistry_Form34.rpt");
            crystalReport_lab34.ReportSource = R_chemistry_Form341;
            crystalReport_lab34.SelectionFormula = "{t_result_main1.resultid} = '" + this.Tag.ToString() + "'";

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            TextObject FormNo = (TextObject)R_chemistry_Form341.ReportDefinition.ReportObjects["txt_formNo"];
            TextObject RevNo = (TextObject)R_chemistry_Form341.ReportDefinition.ReportObjects["txt_RevNo"];
            TextObject Normal = (TextObject)R_chemistry_Form341.ReportDefinition.ReportObjects["txt_normalValue"];
            TextObject ISO = (TextObject)R_chemistry_Form341.ReportDefinition.ReportObjects["txt_iso"];
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

           
            crystalReport_lab34.RefreshReport();

            RemoveTab(crystalReport_lab34);
            wizard1.SelectedTab = tab_lab34;

        }
    }
}
