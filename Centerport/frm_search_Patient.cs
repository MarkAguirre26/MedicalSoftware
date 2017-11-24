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
    public partial class frm_search_Patient : Form
    {


        private string FilterBy;
        Main fmain;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        private string pin;

        public List<PatientSearchList_Model> patientSearchList_Model;
        public bool isOpen;
        private DataTable dt_patient;

        public DataTable _dt_patient
        {
            get { return dt_patient; }
            set { dt_patient = value; }
        }
        public frm_search_Patient(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
           
           
        }


    public    void FillDataGridView()
        {

            try
            {
                patientSearchList_Model = (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).patientSearchList_Model;                
                var list = (from m in patientSearchList_Model select m).ToList();
                if (cbo_filter.Text == "Patient Pin")
                {
                    list = (from m in patientSearchList_Model where m.papin.StartsWith(txt_search.Text) select m).ToList();
                }
                else if (cbo_filter.Text == "Patient Name")
                {
                    list = (from m in patientSearchList_Model where m.PatientName.StartsWith(txt_search.Text) select m).ToList();
                }
                dg_result.DataSource = list;
                dg_result.AutoGenerateColumns = true;
                dg_result.Columns[0].Visible = false;
                dg_result.Columns[1].Width = 100;
                dg_result.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }      


        }


        private void frm_patientList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Search_Phyc_DataTable' table. You can move, or remove it, as needed.
            isOpen = true;
            cbo_filter.Text = "Patient Name";
            //FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
           
            txt_search.Select();
            if (!backgroundWorker1.IsBusy)
            { backgroundWorker1.RunWorkerAsync(); }
          
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

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
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
        //        ClassSql a = new ClassSql(); DataTable dt;               
        //        dt = a.Mytable_Proc("Patient_search", "@ID", ID);
        //        this.dg_result.Rows.Clear();

        //        Cursor.Current = Cursors.WaitCursor;
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            //string name = dr["lastname"].ToString()+", "+ dr["firstname"].ToString()+" "+ dr["middlename"].ToString();
        //            string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(),dr["Name"].ToString()  };
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

        private void dg_searresult_DoubleClick(object sender, EventArgs e)
        {

            SelectItem();
                       
        }




        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                this.Close();
                Cursor.Current = Cursors.WaitCursor;
                frm_patientInfo.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).Tag = dg_result.SelectedRows[0].Cells[0].Value.ToString();               
                (Application.OpenForms["frm_patientInfo"] as frm_patientInfo).Search_();    
                fmain.ts_add_profile.Enabled = true; fmain.ts_edit_profile.Enabled = true; fmain.ts_del_profile.Enabled = true; fmain.ts_save_profile.Enabled = false; fmain.ts_search_profile.Enabled = true; fmain.ts_print_profile.Enabled = false; fmain.ts_cancel_profile.Enabled = false;
                fmain.ts_First_Record.Enabled = true;
                fmain.ts_prev_record.Enabled = true;
                fmain.ts_next_Record.Enabled = true;
                fmain.ts_last_Record.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
                    
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            ////Search();
            //if (txt_search.Text != "")
            //{ Search(txt_search.Text); }
            //else
            //{ dg_result.Rows.Clear(); }
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dg_result.DataSource;
            //bs.Filter = "Patient Name like '" + txt_search.Text + "%'";
            //dg_result.DataSource = bs;
            FillDataGridView();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            { cmd_search.Enabled = true; }
            else
            { cmd_search.Enabled = false; }
        }

        private void cbo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filter.Text == "Patient Pin")
            { FilterBy = "papin"; }
            else if (cbo_filter.Text == "Patient Name")
            { FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)"; }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ Search(txt_search.Text); }
        }

        private void frm_search_Patient_KeyDown(object sender, KeyEventArgs e)
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

        private void dg_result_CellClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dg_result_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dg_result_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { FillDataGridView(); }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void frm_search_Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            isOpen = false;
        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }



    }
}
