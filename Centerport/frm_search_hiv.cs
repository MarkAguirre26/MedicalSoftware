using Centerport.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_search_hiv : Form
    {
        private string FilterBy;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        private DataTable dt_HIV;
        public bool isOpen;
        public List<HIV_Model> Hiv_model = new List<HIV_Model>();
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        Main fmain;
        public frm_search_hiv(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //void Search(string ID)
        //{
        //    try
        //    {
        //        txt_search.Select();
        //        ClassSql a = new ClassSql(); DataTable dt;

        //        dt = a.Mytable_Proc("Hiv_search", "@SearchID", ID);
        //        this.dg_result.Rows.Clear();
        //        Cursor.Current = Cursors.WaitCursor;
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            string name = dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
        //            string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(), dr["resultid"].ToString(), name.ToString(), dr["result_date"].ToString() };
        //            dg_result.Rows.Add(rows);


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

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
                //Thread.Sleep(0);
                //Thread.Sto
                Cursor.Current = Cursors.WaitCursor;
                frm_HIV.pin.Clear();
                string PatientId = this.dg_result.SelectedRows[0].Cells[1].Value.ToString();
                frm_HIV.pin.Text = PatientId;
                frm_HIV.LabID.Clear();
                string ResultId = this.dg_result.SelectedRows[0].Cells[2].Value.ToString();
                frm_HIV.LabID.Text = ResultId;
                (Application.OpenForms["frm_HIV"] as frm_HIV).ClearAll();
                (Application.OpenForms["frm_HIV"] as frm_HIV).Search_Patient(PatientId);
                (Application.OpenForms["frm_HIV"] as frm_HIV).search_HIV(ResultId);
                (Application.OpenForms["frm_HIV"] as frm_HIV).search_Medical_ByProc(ResultId);
                (Application.OpenForms["frm_HIV"] as frm_HIV).search_med = true;
                // fmain.ts_add_hiv.Enabled = false; fmain.ts_edit_hiv.Enabled = false; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = true; fmain.ts_search_hiv.Enabled = false; fmain.ts_print_hiv.Enabled = false; fmain.ts_cancel_hiv.Enabled = true;
                fmain.ts_PrintPreview.Enabled = true; fmain.ts_add_hiv.Enabled = true; fmain.ts_edit_hiv.Enabled = true; fmain.ts_delete_hiv.Enabled = false; fmain.ts_save_hiv.Enabled = false; fmain.ts_search_hiv.Enabled = true; fmain.ts_print_hiv.Enabled = true; fmain.ts_cancel_hiv.Enabled = false;


                Cursor.Current = Cursors.Default;

                // frm_land.ts_add_land.Enabled = true; frm_land.ts_edit_land.Enabled = true; frm_land.ts_delete_land.Enabled = false; frm_land.ts_save_land.Enabled = false; frm_land.ts_cancel_land.Enabled = false; frm_land.ts_search_land.Enabled = true; frm_land.ts_print_land.Enabled = true;


            }



        }






        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            { cmd_select.Enabled = true; }
            else
            { cmd_select.Enabled = false; }

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
        private void frm_search_hiv_Load(object sender, EventArgs e)
        {
            isOpen = true;
            //ClassSql.DbConnect();
            cbo_filter.Text = "Patient Name";
            FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
            txt_search.Select();
            backgroundWorker1.RunWorkerAsync();
            // Search("%");
            //try
            //{
            //    txt_search.Select();
            //    ClassSql a = new ClassSql(); DataTable dt;

            //    dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.status,t_result_main.resulttype, t_result_main.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, t_result_main.result_date, t_result_main.remarks FROM t_result_main Inner Join m_patient ON t_result_main.papin = m_patient.papin WHERE t_result_main.resulttype =  'HIV'   ORDER BY m_patient.lastname LIMIT 10");
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
            //    if (ClassSql.cnn != null) { ClassSql.DbClose(); }
            //    if (ClassSql.dr != null) { ClassSql.dr.Close(); }
            //    Cursor.Current = Cursors.Default;
            //}
        }

        public void FillDataGridView()
        {



            try
            {
                Hiv_model = (Application.OpenForms["frm_HIV"] as frm_HIV).Hiv_model;
                var list = (from m in Hiv_model select m).ToList();
                //if (dt_HIV.Rows.Count >= 1)
                //{
                //    lbl_notif.Visible = false;
                if (cbo_filter.Text == "Result ID")
                {
                    //dt_HIV.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_HIV.Columns[2], txt_search.Text);
                    list = (from m in Hiv_model where m.resultID.StartsWith(txt_search.Text) select m).ToList();
                }
                else if (cbo_filter.Text == "Patient Name")
                {
                    list = (from m in Hiv_model where m.patientName.StartsWith(txt_search.Text) select m).ToList();
                }
                dg_result.DataSource = list;
                dg_result.Columns[0].Visible = false;
                dg_result.Columns[1].Visible = false;
                dg_result.Columns[2].Width = 100;
                dg_result.Columns[3].Width = 340;// DataGridViewAutoSizeColumnMode.Fill;
                dg_result.Columns[4].Width = 100;
                //dg_result.Columns[5].Width = 100;

                //}
                //else
                //{
                //    lbl_notif.Visible = true;
                //    lbl_notif.Text = "No record";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }


        }


        private void cbo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filter.Text == "Result ID")
            { FilterBy = "resultid"; }
            else
            { FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)"; }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            // this.Close();
            SelectItem();
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectItem();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //if (txt_search.Text != "")
            //{ Search(txt_search.Text); }
            //else
            //{ dg_result.Rows.Clear(); }

            FillDataGridView();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ Search(txt_search.Text); }
        }

        private void frm_search_hiv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SelectItem(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search();
            txt_search.Clear();
            txt_search.Select();

        }

        private void frm_search_hiv_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SelectItem();
            isOpen = false;
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDataGridView();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate () { FillDataGridView(); }));

        }
    }
}
