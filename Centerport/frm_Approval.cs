using Centerport.Dataset;
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
    public partial class frm_Approval : Form
    {
        Main fmain; private string dgcn;
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public frm_Approval(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }

        private void frm_Approval_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.Approval = true;
            ClassSql.DbClose();
        }

        private void frm_Approval_Load(object sender, EventArgs e)
        {
            //ClassSql.DbConnect();
            Cursor.Current = Cursors.Default;
           

        }

        //void Search_byName()
        //{
        //    try
        //    {
        //        string Pname = "CONCAT(m_patient.lastname,', ',m_patient.firstname,' ',m_patient.middlename)";
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Table(" SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.papin, t_result_main.result_date,  t_result_main.`status`, m_patient.lastname, m_patient.firstname, m_patient.middlename FROM   t_result_main INNER JOIN m_patient ON t_result_main.papin = m_patient.papin WHERE " + Pname.ToString() + " LIKE '%" + Tool.ReplaceString(txt_search.Text) + "%' ORDER BY " + Pname.ToString() + " DESC limit 20");
        //        this.dg_result.Rows.Clear();


        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
        //            string Type = dr["resulttype"].ToString();


        //            string[] rows = new string[] { dr["cn"].ToString(), dr["resultid"].ToString(), dr["result_date"].ToString(), Type.ToString(), name.ToString(), dr["status"].ToString() };
        //            dg_result.Rows.Add(rows);


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //    }


        //}

        private void cmd_refresh_Click(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
          //  Search_byName();
            Search_byDate();
        }
        void Search_byDate()
        {
            try
            {

               
                var list = db.sp_ForApproval(dt_retrieve.Text, "%").ToList();
                dg_result.Rows.Clear();
                foreach (var i in list)
                {

                    dg_result.Rows.Add(i.cn, i.resultid, i.result_date, i.resulttype, i.PatientName, i.status);


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
           


        }

        private void cmd_retrieve_Click(object sender, EventArgs e)
        {
            Search_byDate();
        }




        private void dg_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == 5)
            {
                dg_result.ReadOnly = false;
                dgcn = this.dg_result.SelectedRows[0].Cells["cn"].Value.ToString();

                // string status = Convert.ToString((dg_result.Rows[0].Cells["Status"] as DataGridViewComboBoxCell).FormattedValue.ToString());

                try
                {


                    // ClassSql a = new ClassSql();
                    //  a.ExecuteQuery("Update t_result_main SET status = '" + status.ToString() + "' where cn ='"+cn.ToString()+"' ");
                    // MessageBox.Show(status.ToString());

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
            else
            {
                dg_result.ReadOnly = true;
            }
        }

        private void dg_result_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            { }
            catch
            { }
        }

        private void dg_result_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewComboBoxCell cell = dg_result[0,5] as DataGridViewComboBoxCell;
            // string valueSelected = dg_result.SelectedRows[0].Cells["Status"].Value.ToString();
            // MessageBox.Show(valueSelected);

        }

        private void dg_result_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dg_result.CurrentCell.ColumnIndex == 5)
            {
                // Check box column
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            }
        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedIndex = ((ComboBox)sender).SelectedItem.ToString();
            ////MessageBox.Show("Selected Index = " + selectedIndex);
            //ClassSql a = new ClassSql();
            //a.ExecuteQuery("Update t_result_main SET status = '" + selectedIndex.ToString() + "' where cn ='" + dgcn.ToString() + "' ");
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Approval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

            }
        }

    }
}
