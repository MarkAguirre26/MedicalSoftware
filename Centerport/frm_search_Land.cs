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
    
    public partial class frm_search_Land : Form
    {
        private string FilterBy;

        Main fmain;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        private DataTable dt_LandBase;
        public List<landbaseSearckList_Model> landbaseSearckList_model = new List<landbaseSearckList_Model>();
        public bool isOpen = false;
        public frm_search_Land(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void frm_search_Land_Load(object sender, EventArgs e)
        {
            isOpen = true;
            cbo_filter.Text = "Patient Name";
            FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
            txt_search.Select();
            if (!backgroundWorker1.IsBusy)
            { backgroundWorker1.RunWorkerAsync(); }
       
        }

      

        private void cbo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filter.Text == "Result ID")
            { FilterBy = "resultid"; }
            else if (cbo_filter.Text == "Patient Name")
            { FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)"; }
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectItem();
        }


        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                this.Close();
                Cursor.Current = Cursors.WaitCursor;
                frm_Landbase.Text_papin.Text = this.dg_result.SelectedRows[0].Cells[1].Value.ToString();
                frm_Landbase.LabID.Text = this.dg_result.SelectedRows[0].Cells[2].Value.ToString();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).ClearAll();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_Patient();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_MedicalHistory();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_medicalHistory2();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_PhyExam();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).Search_others();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).search_Ancillary();
                (Application.OpenForms["frm_Landbase"] as frm_Landbase).search_Recomendation();
               // fmain.ts_add_land.Enabled = true; fmain.ts_edit_land.Enabled = true; fmain.ts_delete_land.Enabled = false; fmain.ts_save_land.Enabled = false; fmain.ts_search_land.Enabled = true; fmain.ts_print_land.Enabled = true; fmain.ts_cancel_land.Enabled = false;
                fmain.ts_add_land.Enabled = true; fmain.ts_edit_land.Enabled = true; fmain.ts_delete_land.Enabled = false; fmain.ts_save_land.Enabled = false; fmain.ts_search_land.Enabled = true; fmain.ts_print_land.Enabled = true; fmain.ts_cancel_land.Enabled = false;


                Cursor.Current = Cursors.Default;
               // frm_land.ts_add_land.Enabled = true; frm_land.ts_edit_land.Enabled = true; frm_land.ts_delete_land.Enabled = false; frm_land.ts_save_land.Enabled = false; frm_land.ts_cancel_land.Enabled = false; frm_land.ts_search_land.Enabled = true; frm_land.ts_print_land.Enabled = true;
               // this.Close();

            }
           

        }

       public void FillDataGridView()
        {

            try
            {
                landbaseSearckList_model = (Application.OpenForms["frm_Landbase"] as frm_Landbase).landbaseSearckList_model;
                var list = (from m in landbaseSearckList_model select m).ToList();
                
                    if (cbo_filter.Text == "Result ID")
                    {
                      //  dt_LandBase.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_LandBase.Columns[2], txt_search.Text);
                        list = (from m in landbaseSearckList_model where m.resultID.StartsWith(txt_search.Text) select m).ToList();
                    }
                    else if (cbo_filter.Text == "Patient Name")
                    {
                       // dt_LandBase.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_LandBase.Columns[3], txt_search.Text);
                        list = (from m in landbaseSearckList_model where m.patientName.StartsWith(txt_search.Text) select m).ToList();
                    }
                    dg_result.DataSource = list;
                    dg_result.Columns[0].Visible = false;
                    dg_result.Columns[1].Visible = false;
                    dg_result.Columns[2].Width = 110;
                    dg_result.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dg_result.Columns[4].Width = 100;
                    dg_result.Columns[5].Width = 140;
                   
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }   



        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            ////Search();
            //if (txt_search.Text != "")
            //{ Search(txt_search.Text); }
            //else
            //{ dg_result.Rows.Clear(); }
            FillDataGridView();

        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            { cmd_search.Enabled = true; }
            else
            { cmd_search.Enabled = false; }

        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ Search(txt_search.Text); }
        }

        private void frm_search_Land_KeyDown(object sender, KeyEventArgs e)
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

        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                frm_patient_Info info = new frm_patient_Info();
                info.Tag = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                info.ShowDialog();


            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { FillDataGridView(); }));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void frm_search_Land_FormClosing(object sender, FormClosingEventArgs e)
        {
            isOpen = false;
        }
    }
}
