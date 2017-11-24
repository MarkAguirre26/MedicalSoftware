using Centerport.Class;
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
    public partial class frm_search_MLC : Form
    {
        private string FilterBy;
        Main fmain;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        private DataTable dt_SEAMLC;

        public bool isOpen;
        public frm_search_MLC(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
           
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
        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectItem();
        }

        //void Search(string ID)
        //{
        //    try
        //    {
        //        txt_search.Select();
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        //dt = a.Table("SELECT t_result_main.cn,  t_result_main.resultid, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.papin, t_result_main.status, t_result_main.resulttype, t_result_main.repeat_test_tag FROM m_patient Inner Join t_result_main ON t_result_main.papin = m_patient.papin WHERE  " + FilterBy + " = '" + Tool.ReplaceString(txt_search.Text) + "'  AND t_result_main.resulttype =  'LAND' AND t_result_main.repeat_test_tag <>  'Y' AND t_result_main.papin <>  '00000000' ORDER BY t_result_main.result_date ASC");
        //      //  dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.status,t_result_main.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, t_result_main.result_date, t_result_main.remarks FROM t_result_main Inner Join m_patient ON t_result_main.papin = m_patient.papin WHERE t_result_main.resulttype =  'SEAMLC' AND " + FilterBy.ToString() + "     LIKE   '" + Tool.ReplaceString(txt_search.Text) + "%'  ORDER BY " + FilterBy.ToString() + " ASC LIMIT 50");
        //        dt = a.Mytable_Proc("SeaMLC_search", "@SearchID", ID);
        //        this.dg_result.Rows.Clear();
        //        Cursor.Current = Cursors.WaitCursor;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            //DateTime Date = Convert.ToDateTime(dr["result_date"].ToString());
        //            string name =  dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
        //            string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(), dr["resultid"].ToString(), name.ToString(), dr["result_date"].ToString(), dr["recommendation"].ToString() };
        //            dg_result.Rows.Add(rows);


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //         MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {
        //        //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }
        //        Cursor.Current = Cursors.Default;
        //    }


        //}


        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                this.Close();
                Cursor.Current = Cursors.WaitCursor;
                frm_Seafarer_MLC.pin.Clear();
                frm_Seafarer_MLC.pin.Text = this.dg_result.SelectedRows[0].Cells[1].Value.ToString();
                frm_Seafarer_MLC.LabID.Clear();
                frm_Seafarer_MLC.LabID.Text = this.dg_result.SelectedRows[0].Cells[2].Value.ToString();
                frm_Seafarer_MLC.cn_MLCFromResultMain = this.dg_result.SelectedRows[0].Cells[0].Value.ToString();

                // frm_land.ts_add_land.Enabled = true; frm_land.ts_edit_land.Enabled = true; frm_land.ts_delete_land.Enabled = false; frm_land.ts_save_land.Enabled = false; frm_land.ts_cancel_land.Enabled = false; frm_land.ts_search_land.Enabled = true; frm_land.ts_print_land.Enabled = true;
                (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).ClearAll();
                (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Search_Patient();
                (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Search_PhyExam();
                (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).search_RecomendationFromSearch();
                (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).GetSpecimenNumber();
                //fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = true; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = true; fmain.ts_cancel_mlc.Enabled = false;
                fmain.ts_add_mlc.Enabled = true; fmain.ts_edit_mlc.Enabled = true; fmain.ts_delete_mlc.Enabled = false; fmain.ts_save_mlc.Enabled = false; fmain.ts_search_mlc.Enabled = true; fmain.ts_print_mlc.Enabled = true; fmain.ts_cancel_mlc.Enabled = false;
             
                
                
                Cursor.Current = Cursors.Default;
                
                //this.Close();

            }


        }

        private void cbo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filter.Text == "Result ID")
            { FilterBy = "resultid"; }
            else if (cbo_filter.Text == "Patient Name")
            { FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)"; }
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            { cmd_search.Enabled = true; }
            else
            { cmd_search.Enabled = false; }

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView();
            
            ////Search();
            //if (txt_search.Text != "")
            //{ Search(txt_search.Text); }
            //else
            //{ dg_result.Rows.Clear(); }
        }


        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void frm_search_MLC_Load(object sender, EventArgs e)
        {
            isOpen = true;
            cbo_filter.Text = "Patient Name";
            FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
            txt_search.Select();
            
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
           // Search("%");}
           // Search("%");
            //try
            //{
            //    txt_search.Select();
            //    ClassSql a = new ClassSql(); DataTable dt;
            //    //dt = a.Table("SELECT t_result_main.cn,  t_result_main.resultid, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.papin, t_result_main.status, t_result_main.resulttype, t_result_main.repeat_test_tag FROM m_patient Inner Join t_result_main ON t_result_main.papin = m_patient.papin WHERE  " + FilterBy + " = '" + Tool.ReplaceString(txt_search.Text) + "'  AND t_result_main.resulttype =  'LAND' AND t_result_main.repeat_test_tag <>  'Y' AND t_result_main.papin <>  '00000000' ORDER BY t_result_main.result_date ASC");
            //    dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.status,t_result_main.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, t_result_main.result_date, t_result_main.remarks FROM t_result_main Inner Join m_patient ON t_result_main.papin = m_patient.papin WHERE t_result_main.resulttype =  'SEAMLC' ORDER BY m_patient.lastname  ASC LIMIT 10");
            //    this.dg_result.Rows.Clear();
            //    Cursor.Current = Cursors.WaitCursor;
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        //DateTime Date = Convert.ToDateTime(dr["result_date"].ToString());
            //        string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
            //        string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(), dr["resultid"].ToString(), name.ToString(), dr["result_date"].ToString(), dr["status"].ToString() };
            //        dg_result.Rows.Add(rows);


            //    }


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            //}
            //finally
            //{
            //    //if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //    Cursor.Current = Cursors.Default;
            //}

        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ Search(txt_search.Text); }
        }

        private void frm_search_MLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SelectItem(); }
        }

        private void dg_result_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SelectItem(); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search();
            txt_search.Clear();
            txt_search.Select();
            //dg_result.Rows.Clear();
        }

        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                frm_patient_Info info = new frm_patient_Info();
                info.Tag = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                info.ShowDialog();


            }
        }

        public List<Seafarer_SearchList_MLC> Seafarer_SearchList_model = new List<Seafarer_SearchList_MLC>();
    public    void FillDataGridView()
        {



            try
            {
                Seafarer_SearchList_model = (Application.OpenForms["frm_Seafarer_MLC"] as frm_Seafarer_MLC).Seafarer_SearchList_model;
                var list = (from m in Seafarer_SearchList_model select m).ToList();


                if (cbo_filter.Text == "Result ID")
                {

                    list = (from m in Seafarer_SearchList_model where m.resultID.StartsWith(txt_search.Text) select m).ToList();
                }
                else if (cbo_filter.Text == "Patient Name")
                {

                    list = (from m in Seafarer_SearchList_model where m.patientName.StartsWith(txt_search.Text) select m).ToList();
                }
                dg_result.DataSource = list;
                dg_result.Columns[0].Visible = false;
                dg_result.Columns[1].Visible = false;
                dg_result.Columns[2].Width = 110;
                dg_result.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg_result.Columns[4].Width = 90;
                dg_result.Columns[5].Width = 140;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { FillDataGridView(); }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDataGridView();
        }

        private void frm_search_MLC_FormClosing(object sender, FormClosingEventArgs e)
        {
            isOpen = false;
        }
    }
}
