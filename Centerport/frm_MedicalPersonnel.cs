using Ini;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_MedicalPersonnel : Form
    {
        public TextBox txt_medic; public TextBox txt_license;
        public frm_MedicalPersonnel()
        {
            InitializeComponent();
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_MedicalPersonnel_Load(object sender, EventArgs e)
        {
            loadMedics();
        }


        void loadMedics()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);

            string a = ini.IniReadValue("MEDICAL", "PEME_Physician");
            string b = ini.IniReadValue("MEDICAL", "PEME MedicalDirector");
            string c = ini.IniReadValue("MEDICAL", "MedTech");
            string d = ini.IniReadValue("MEDICAL", "Pathologist");
            string e = ini.IniReadValue("MEDICAL", "Xray_Radiologist");
            string f = ini.IniReadValue("MEDICAL", "Medical_Director");
            string g = ini.IniReadValue("MEDICAL", "HIV_Exam_physician");
            string h = ini.IniReadValue("MEDICAL", "Psychometrician");
            string i = ini.IniReadValue("MEDICAL", "Psychologist");
            string j = ini.IniReadValue("MEDICAL", "XRAY_TECH");
            string k = ini.IniReadValue("MEDICAL", "medtech1_Name");
            string l = ini.IniReadValue("MEDICAL", "medtech2_Name");

            string aa = ini.IniReadValue("MEDICAL", "PEME_Physician_license");
            string bb = ini.IniReadValue("MEDICAL", "PEME MedicalDirector_license");
            string cc = ini.IniReadValue("MEDICAL", "MedTech_license");
            string dd = ini.IniReadValue("MEDICAL", "Pathologist_license");
            string ee = ini.IniReadValue("MEDICAL", "Xray Radiologist_license");
            string ff = ini.IniReadValue("MEDICAL", "Medical Director_license");
            string gg = ini.IniReadValue("MEDICAL", "HIV_Exam_physician_license");
            string hh = ini.IniReadValue("MEDICAL", "Psychometrician_license");
            string ii = ini.IniReadValue("MEDICAL", "Psychologist_license");
            string jj = ini.IniReadValue("MEDICAL", "XRAYTECH_LICENSE");
            string kk = ini.IniReadValue("MEDICAL", "medtech1_Lic");
            string ll = ini.IniReadValue("MEDICAL", "medtech2_Lic");


            StringCollection Names = new StringCollection();
            StringCollection License = new StringCollection();

            string[] row = new string[] {a,b,c,d,e,f,g,h,i,j,k,l };
            string[] lics = new string[] {aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll };
          
            Names.AddRange(row); 
            License.AddRange(lics);

            foreach (string name in Names)
            {
                dg_medics.Rows.Add(name);               
            }
            dg_medics.Rows[0].Cells[1].Value = aa;
            dg_medics.Rows[1].Cells[1].Value = bb;
            dg_medics.Rows[2].Cells[1].Value = cc;
            dg_medics.Rows[3].Cells[1].Value = dd;
            dg_medics.Rows[4].Cells[1].Value = ee;
            dg_medics.Rows[5].Cells[1].Value = ff;
            dg_medics.Rows[6].Cells[1].Value = gg;
            dg_medics.Rows[7].Cells[1].Value = hh;
            dg_medics.Rows[8].Cells[1].Value = ii;
            dg_medics.Rows[9].Cells[1].Value = jj;
            dg_medics.Rows[10].Cells[1].Value = kk;
            dg_medics.Rows[11].Cells[1].Value = ll;
         
        
        }


        void SelectItem()
        {
            try
            {
                txt_medic.Text = dg_medics.SelectedRows[0].Cells[0].Value.ToString();
                txt_license.Text = dg_medics.SelectedRows[0].Cells[1].Value.ToString();
                if ((Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation) != null)
                {
                    IniFile ini = new IniFile(ClassSql.MMS_Path);
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Lic_validity_Medtech.Text = ini.IniReadValue("MEDICAL", "Psychometrician_Validity");
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).PTR_medtech.Text = ini.IniReadValue("MEDICAL", "Psychometrician_ptr");
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Lic_Validity_Patho.Text = ini.IniReadValue("MEDICAL", "Psychologist_Validity");
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).PTR_Patho.Text = ini.IniReadValue("MEDICAL", "Psychologist_Ptr");
                }
                    this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }
        private void cmd_Select_Click(object sender, EventArgs e)
        {

            SelectItem();
            
        }


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                dg_medics.Rows[dg_medics.SelectedRows[0].Index].Selected = false;
                foreach (DataGridViewRow row in this.dg_medics.Rows)
                {
                    if (row.Cells[0].Value.ToString().Contains(txt_search.Text))
                    {
                        dg_medics.Rows[row.Index].Selected = true;

                        break;
                    }
                }
            }
            catch
            {

               // dg_medics.Rows[dg_medics.SelectedRows[0].Index].Selected = false;
                dg_medics.Rows[0].Cells[0].Selected = true;
            }


            
           
           
            
            
            
        }

        private void dg_medics_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SelectItem();
            }
            catch
            { }
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
           //string searchString = this.dtToday.Text;
            dg_medics.Rows[dg_medics.SelectedRows[0].Index].Selected = false;  
           foreach (DataGridViewRow row in this.dg_medics.Rows)
           {
               if (row.Cells[0].Value.ToString().Contains(txt_search.Text))
               {
                   dg_medics.Rows[row.Index].Selected = true;

                   break;
               }
           }
        }
    }
}
