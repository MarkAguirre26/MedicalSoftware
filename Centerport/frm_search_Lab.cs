using Centerport.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centerport
{
    public partial class frm_search_Lab : Form
    {
        private string FilterBy;
        Main fmain;
        private const long BUTTON_DOWN_CODE = 0xa1;
        private const long BUTTON_UP_CODE = 0xa0;
        private const long WM_MOVING = 0x216;
        static bool left_button_down = false;
        private bool iscanceled = false;
        public bool isopen;
        private DataTable dt_lab;
        public List<laboratory_search> labsearch;
        public frm_search_Lab(Main maiin)
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
        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class Foo
        {
        public string cn,papin,Name,resultid,patientName,resultDate;
        }


      
        private void cbo_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_filter.Text == "Result ID")
            { FilterBy = "resultid"; }
            else if (cbo_filter.Text == "Patient Name")
            { FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)"; }
                       
        }

        private void frm_search_Patient_Lab_Load(object sender, EventArgs e)
        {
            isopen = true;
            cbo_filter.Text = "Patient Name";
           // FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
            
            txt_search.Select();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        

        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
        }


        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
               // ResultID
                this.Close();
                Cursor.Current = Cursors.WaitCursor;
                frm_lab.Patient_pin.Tag = this.dg_result.SelectedRows[0].Cells[0].Value.ToString();
                frm_lab.Patient_pin.Clear();
                frm_lab.Patient_pin.Text = this.dg_result.SelectedRows[0].Cells[2].Value.ToString();
                frm_lab.LabId.Clear();
                frm_lab.LabId.Text = this.dg_result.SelectedRows[0].Cells[1].Value.ToString();

                (Application.OpenForms["frm_lab"] as frm_lab).ClearAll();
                (Application.OpenForms["frm_lab"] as frm_lab).Search_Patient();
                (Application.OpenForms["frm_lab"] as frm_lab).Search_lab();
                (Application.OpenForms["frm_lab"] as frm_lab).Search_Hema();
                (Application.OpenForms["frm_lab"] as frm_lab).Search_Chemistry();
                (Application.OpenForms["frm_lab"] as frm_lab).Search_Urinalysis();
                (Application.OpenForms["frm_lab"] as frm_lab).Search_Fecalysis();
                (Application.OpenForms["frm_lab"] as frm_lab).cmd_chemistry.Enabled = true;
                (Application.OpenForms["frm_lab"] as frm_lab).cmd_Repeat_fecalysis.Enabled = true;
                (Application.OpenForms["frm_lab"] as frm_lab).cmd_repeatUrinal.Enabled = true;
                (Application.OpenForms["frm_lab"] as frm_lab).cmd_repeatHema.Enabled = true;
                fmain.ts_add_lab.Enabled = true; fmain.ts_edit_lab.Enabled = true; fmain.ts_delete_lab.Enabled = false; fmain.ts_save_lab.Enabled = false; fmain.ts_search_lab.Enabled = true; fmain.ts_print_lab.Enabled = true; fmain.ts_cancel_lab.Enabled = false;
                Cursor.Current = Cursors.Default;
                // this.Close();
            }


        
        
        }

        private void frm_search_Patient_Lab_Shown(object sender, EventArgs e)
        {         
           
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //if (txt_search.Text != "")
            //{ Search(txt_search.Text); }
            //else
            //{ dg_result.Rows.Clear(); }
            FillDataGridView();
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectItem();
        }

        private void dg_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ SearchNow(); }
        }

        private void frm_search_Lab_KeyDown(object sender, KeyEventArgs e)
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
            //cmd_select.Enabled = false;
          
        }

        private void patientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                frm_patient_Info info = new frm_patient_Info();
                info.Tag = dg_result.SelectedRows[0].Cells[2].Value.ToString();
                info.ShowDialog();


            }
        }

      
       


     public   void FillDataGridView()
        {
            try
            {
                labsearch = (Application.OpenForms["frm_lab"] as frm_lab).labsearch;

                var list = (from m in labsearch select m).ToList();        
                             
                    if (cbo_filter.Text == "Result ID")
                    {
                        list = (from m in labsearch where m.resultid.StartsWith(txt_search.Text) select m).ToList();
                    }
                    else if (cbo_filter.Text == "Patient Name")
                    {
                        list = (from m in labsearch where m.PatientName.StartsWith(txt_search.Text) select m).ToList();
                    }
                    dg_result.DataSource = list;
                    dg_result.AutoGenerateColumns = true;
                    dg_result.Columns[0].Visible = false;
                    dg_result.Columns[1].Width = 100;
                    dg_result.Columns[2].Visible = false;
                    dg_result.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dg_result.Columns[4].Width = 130;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }            
        }
        

        private void frm_search_Lab_FormClosing(object sender, FormClosingEventArgs e)
        {
            isopen = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate() { FillDataGridView(); }));
        }

     
      
    }
}
