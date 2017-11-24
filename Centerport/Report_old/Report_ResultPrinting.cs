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
    public partial class Report_ResultPrinting : Form
    {

     private string  ResultType;
     private string ResultID; //bool canMove = false;

    


        public Report_ResultPrinting()
        {
            InitializeComponent();
           
        }
        void Search_byName()
        {
            try
            {
                string Pname = "CONCAT(m_patient.lastname,', ',m_patient.firstname,' ',m_patient.middlename)";
                ClassSql a = new ClassSql(); DataTable dt;
                dt = a.Table(" SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.papin, t_result_main.result_date,  t_result_main.`status`, m_patient.lastname, m_patient.firstname, m_patient.middlename FROM   t_result_main INNER JOIN m_patient ON t_result_main.papin = m_patient.papin WHERE " + Pname.ToString() + " LIKE '%" + Tool.ReplaceString(txt_search.Text) + "%' ORDER BY " + Pname.ToString() + " ASC limit 20");
                this.dg_result.Rows.Clear();


                foreach (DataRow dr in dt.Rows)
                {
                    string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
                    string Type = dr["resulttype"].ToString();


                    string[] rows = new string[] { dr["cn"].ToString(), dr["resultid"].ToString(), dr["result_date"].ToString(), Type.ToString(), name.ToString(), dr["status"].ToString() };
                    dg_result.Rows.Add(rows);


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            finally
            {
                if (ClassSql.cnn != null) { ClassSql.DbClose(); }
                if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            }


        }

     

        void Search_byDate()
        {
            try
            {

                ClassSql a = new ClassSql(); DataTable dt;
                dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.papin, t_result_main.result_date,  t_result_main.`status`, m_patient.lastname, m_patient.firstname, m_patient.middlename FROM   t_result_main INNER JOIN m_patient ON t_result_main.papin = m_patient.papin WHERE result_date = '" + dt_retrieve.Text + "' ORDER BY cn ASC ");
                this.dg_result.Rows.Clear();


                foreach (DataRow dr in dt.Rows)
                {
                    string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
                    string[] rows = new string[] { dr["cn"].ToString(), dr["resultid"].ToString(), dr["result_date"].ToString(), dr["resulttype"].ToString(), name.ToString(), dr["status"].ToString() };
                    dg_result.Rows.Add(rows);


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
            finally
            {
                if (ClassSql.cnn != null) { ClassSql.DbClose(); }
                if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            }


        }

        private void dg_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.ColumnIndex == -1 || e.RowIndex == -1)
            //{ }
            //else 
            //{

            //   string status = this.dg_result.SelectedRows[0].Cells["Status"].Value.ToString();

            //   if (status == "PENDING")
            //   { cmd_print.Enabled = false; }
            //   else
            //   { cmd_print.Enabled = true; }

           // }

            if (e.ColumnIndex == 1 || e.RowIndex == -1)
            {


            }
            else
            {
                ResultType = this.dg_result.SelectedRows[0].Cells["Result_Type"].Value.ToString();
                ResultID   = this.dg_result.SelectedRows[0].Cells["result_id"].Value.ToString();
                string status = this.dg_result.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status == "PENDING")  { cmd_print.Enabled = false; }      else   { cmd_print.Enabled = true; }

            }

          
        }

        private void cmd_retrieve_Click(object sender, EventArgs e)
        {
            Search_byDate();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            Search_byName();
        }

        private void Report_ResultPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.Releasing = true;
        }

        private void Report_ResultPrinting_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            //canMove = true;
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_print_Click(object sender, EventArgs e)
        {
            if (ResultType == "SEA")
            {

                Cursor.Current = Cursors.WaitCursor;
                Report_SeaBase_Print print = new Report_SeaBase_Print();
                print.Tag = ResultID.ToString();
                print.Load_mlc();
                print.rb_mlc.Select();
                print.wizard1.SelectedTab = print.tabPage2;
                print.ShowDialog();


            }

            else if (ResultType == "HIV")
            {
                Cursor.Current = Cursors.WaitCursor;
                Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
                frm_print.Tag = ResultID.ToString();
                frm_print.HIV = true;
                frm_print.ShowDialog();


            }
            else if (ResultType == "LAB")
            {
                Cursor.Current = Cursors.WaitCursor;
                Report_Lab frm_lab_Report = new Report_Lab();
                frm_lab_Report.Tag = ResultID.ToString();
                frm_lab_Report.Load_Lab08();
                frm_lab_Report.R_lab08.Select();
                frm_lab_Report.wizard1.SelectedTab = frm_lab_Report.tabPage2;
                frm_lab_Report.ShowDialog();


            }
            else if (ResultType == "LAND")
            {
                Cursor.Current = Cursors.Default;
                Report_Landbase Print = new Report_Landbase();
                Print.Load_Summary();
                Print.ShowDialog();


            }
            else if (ResultType == "PSYCHO")
            {

                Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
                frm_print.Tag = ResultID.ToString();
                frm_print.PsychEval = true;
                frm_print.ShowDialog();



            }
            else if (ResultType == "UTZ")
            {
                Cursor.Current = Cursors.WaitCursor;
                Report.Report_PrintOuts frm_ultraSound = new Report.Report_PrintOuts();
                frm_ultraSound.Tag = ResultID.ToString();
                frm_ultraSound.Ultrasound = true;
                frm_ultraSound.ShowDialog();



            }
            else if (ResultType == "XRAY")
            {
                Report.Report_PrintOuts frm_print = new Report.Report_PrintOuts();
                frm_print.Tag = ResultID.ToString();
                frm_print.XRAY = true;
                frm_print.ShowDialog();

            }
            else if (ResultType == "SEAMLC")
            {
                Report.Report_PrintOuts frm_mlc = new Report.Report_PrintOuts();
                frm_mlc.Tag = ResultID.ToString();
                frm_mlc.MLC = true;
                frm_mlc.ShowDialog();
            }
            else if (ResultType == "HEMA(repeat)")
            {

                Cursor.Current = Cursors.WaitCursor;
                Report.Report_Lab Print = new Report.Report_Lab();
                Print.Tag = ResultID.ToString();
                Print.R_Hema.Select();
                Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = true; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = false;
                Print.LoadHema();
                Print.ShowDialog();

            }
            else if (ResultType == "CHEM(repeat)")
            {

                Cursor.Current = Cursors.WaitCursor;
                Report.Report_Lab Print = new Report.Report_Lab();
                Print.Tag = ResultID.ToString();
                Print.R_Chem.Select();
                Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = true; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = false;
                Print.Load_Chem();
                Print.ShowDialog();

            }
            else if (ResultType == "URINE(repeat)")
            {
                Cursor.Current = Cursors.WaitCursor;
                Report.Report_Lab Print = new Report.Report_Lab();
                Print.Tag = ResultID.ToString();
                Print.R_Urine.ToString();
                Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = true; Print.R_Fecal.Enabled = false;
                Print.Load_Urine();
                Print.ShowDialog();


            }
            else if (ResultType == "STOOL(repeat)")
            {
                Cursor.Current = Cursors.WaitCursor;
                Report.Report_Lab Print = new Report.Report_Lab();
                Print.Tag = ResultID.ToString();
                Print.R_Fecal.Select();
                Print.R_lab06.Enabled = false; Print.R_lab08.Enabled = false; Print.R_Hema.Enabled = false; Print.R_Chem.Enabled = false; Print.R_Urine.Enabled = false; Print.R_Fecal.Enabled = true;
                Print.load_Fecal();
                Print.ShowDialog();

            }

        }

        private void Report_ResultPrinting_Move(object sender, EventArgs e)
        {
            //if (canMove)
            //{
            //    this.Opacity = 0.1;
            //}
        }

        private void Report_ResultPrinting_ResizeEnd(object sender, EventArgs e)
        {
            //this.Opacity = 1;
            //canMove = false;
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Select(); }
        }
    }
}
