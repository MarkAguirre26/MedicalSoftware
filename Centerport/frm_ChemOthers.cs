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
    public partial class frm_ChemOthers : Form
    {
        public frm_ChemOthers()
        {
            InitializeComponent();
        }

        private void cmd_ok_Click(object sender, EventArgs e)
        {
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).hdl =            txt_hdl.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).ldl =            txt_ldl.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).acidPhos =       txt_acidPhos.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalbilirubin = txt_totalbil.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b1 =             txt_b1.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b2 =             txt_b2.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalpro =       txt_totalprotein.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).albumin =        txt_albumin.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).globulin =       txt_globulin.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).agration =       txt_agRatio.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).other =          txt_other.Text;

                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).hdl_con = txt_hdl_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).ldl_con = txt_ldl_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).acidPhos_con = txt_acidPhos_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalbilirubin_con = txt_totalbil_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b1_con = txt_b1_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b2_con = txt_b2_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalpro_con = txt_totalprotein_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).albumin_con = txt_albumin_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).globulin_con = txt_globulin_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).agration_con = txt_agRatio_con.Text;
                (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).other_con = txt_other_con.Text;

                if (cb_FBS.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).hdl_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).hdl_H = "0"; }
                if (cb_Bun.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).ldl_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).ldl_H = "0"; }
                if (cb_Creatinine.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).acidPhos_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).acidPhos_H = "0"; }
                if (cb_Cholesterol.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalbilirubin_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalbilirubin_H = "0"; }
                if (cb_trigly.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b1_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b1_H = "0"; }
                if (cb_uric.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b2_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).b2_H = "0"; }
                if (cb_sgot.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalpro_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).totalpro_H = "0"; }
                if (cb_sgpt.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).albumin_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).albumin_H = "0"; }
                if (cb_alk.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).globulin_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).globulin_H = "0"; }
                if (checkBox3.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).agration_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).agration_H = "0"; }
                if (checkBox2.Checked == true) { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).other_H = "1"; } else { (Application.OpenForms["frm_repeat_Chemistry"] as frm_repeat_Chemistry).other_H = "0"; }
              


                this.Close();
              
        }
    }
}
