using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Centerport
{
    public partial class frm_searchTumor : Form
    {
        private string FilterBy;
        Main fmain;
        public frm_searchTumor(Main maiin)
        {
            fmain = maiin;
            InitializeComponent();
        }

        private void cbo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filter.Text == "Result ID")
            { FilterBy = "resultid"; }
            else if (cbo_filter.Text == "Patient Name")
            { FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)"; }

        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            else if (e.KeyCode == Keys.Enter)
            {
                //Search(txt_search.Text);
            }

        }

        //void Search(string ID)
        //{

                       
        //        try
        //        {
        //            txt_search.Select();
        //            ClassSql a = new ClassSql(); DataTable dt;

        //            dt = a.Mytable_Proc("search_tumorPatient", "@SearchID", ID);
        //            this.dg_result.Rows.Clear();
        //            Cursor.Current = Cursors.WaitCursor;
        //            foreach (DataRow dr in dt.Rows)
        //            {
                      
        //                string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
        //                string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(), dr["resultid"].ToString(), name.ToString(), dr["result_date"].ToString() };
        //                dg_result.Rows.Add(rows);


        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //        }
        //        finally
        //        {
        //            //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //            if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //            Cursor.Current = Cursors.Default;
        //        }

               


            
        //}
        private void cmd_clear_Click(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.Select();
           
        }

        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                frm_patient_Info info = new frm_patient_Info();
                info.Tag = dg_result.SelectedRows[0].Cells["Papin"].Value.ToString();
                info.ShowDialog();


            }
        }

        private void frm_searchTumor_Load(object sender, EventArgs e)
        {
            //if (ClassSql.cnn.State == ConnectionState.Closed)
            //{ ClassSql.DbConnect(); }
            cbo_filter.Text = "Patient Name";
            FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
            txt_search.Select();
        }

        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                this.Close();
                Cursor.Current = Cursors.WaitCursor;
                frm_Tumor_Immunological.pin.Text = dg_result.SelectedRows[0].Cells["Pap_pin"].Value.ToString();
                frm_Tumor_Immunological.LabID.Text = this.dg_result.SelectedRows[0].Cells["ResultId"].Value.ToString();

                (Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).ClearAll();
                //(Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Search_Patient();
                //(Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).search_Medical_ByProc();
                //(Application.OpenForms["frm_Tumor_Immunological"] as frm_Tumor_Immunological).Search_tumor();
            
                fmain.ts_add_tumor.Enabled = true; fmain.ts_edit_tumor.Enabled = true; fmain.ts_delete_tumor.Enabled = false; fmain.ts_save_tumor.Enabled = false; fmain.ts_search_tumor.Enabled = true; fmain.ts_print_tumor.Enabled = true; fmain.ts_cancel_tumor.Enabled = false;
               
                Cursor.Current = Cursors.Default;
            }

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void frm_searchTumor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            { this.Close(); }
        }



    }
}
