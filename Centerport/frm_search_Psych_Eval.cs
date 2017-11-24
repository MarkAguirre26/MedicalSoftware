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
    public partial class frm_search_Psych_Eval : Form
    {
        private string FilterBy;
        private bool iscanceled = false;
        private DataTable dt_Psycho;
        public bool isOpen;
        DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
        public List<Psychology_Model> Psychology_model = new List<Psychology_Model>();
        Main fmain;
        public frm_search_Psych_Eval(Main maiin)
        {
            InitializeComponent();
            fmain = maiin;
        }

        private void frm_search_Psych_Eval_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Search_Phyc_DataTable' table. You can move, or remove it, as needed.
           // this.search_Phyc_DataTableTableAdapter.Fill(this.dataSet.Search_Phyc_DataTable);
            isOpen = true;
            cbo_filter.Text = "Patient Name";
            FilterBy = "CONCAT(m_patient.lastname,',',m_patient.firstname,' ',m_patient.middlename)";
            txt_search.Select();
            if (!backgroundWorker2.IsBusy)
            {
                backgroundWorker2.RunWorkerAsync();
            }

           

           // Search("%");
            //try
            //{
            //    txt_search.Select();
            //    ClassSql a = new ClassSql(); DataTable dt;
            //    //dt = a.Table("SELECT t_result_main.cn,  t_result_main.resultid, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.papin, t_result_main.status, t_result_main.resulttype, t_result_main.repeat_test_tag FROM m_patient Inner Join t_result_main ON t_result_main.papin = m_patient.papin WHERE  " + FilterBy + " = '" + Tool.ReplaceString(txt_search.Text) + "'  AND t_result_main.resulttype =  'LAND' AND t_result_main.repeat_test_tag <>  'Y' AND t_result_main.papin <>  '00000000' ORDER BY t_result_main.result_date ASC");
            //    dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.status,t_result_main.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, t_result_main.result_date, t_result_main.remarks FROM t_result_main Inner Join m_patient ON t_result_main.papin = m_patient.papin WHERE t_result_main.resulttype =  'PSYCHO' ORDER BY m_patient.lastname  ASC LIMIT 10");
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

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            { cmd_select.Enabled = true; }
            else
            { cmd_select.Enabled = false; }
        }

        //void Search(string ID)
        //{
        //    try
        //    {
        //        txt_search.Select();
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        //dt = a.Table("SELECT t_result_main.cn,  t_result_main.resultid, m_patient.lastname, m_patient.firstname, m_patient.middlename, m_patient.papin, t_result_main.status, t_result_main.resulttype, t_result_main.repeat_test_tag FROM m_patient Inner Join t_result_main ON t_result_main.papin = m_patient.papin WHERE  " + FilterBy + " = '" + Tool.ReplaceString(txt_search.Text) + "'  AND t_result_main.resulttype =  'LAND' AND t_result_main.repeat_test_tag <>  'Y' AND t_result_main.papin <>  '00000000' ORDER BY t_result_main.result_date ASC");
        //       // dt = a.Table("SELECT t_result_main.cn, t_result_main.resultid, t_result_main.resulttype, t_result_main.status,t_result_main.papin, m_patient.lastname, m_patient.firstname, m_patient.middlename, t_result_main.result_date, t_result_main.remarks FROM t_result_main Inner Join m_patient ON t_result_main.papin = m_patient.papin WHERE t_result_main.resulttype =  'PSYCHO' AND " + FilterBy.ToString() + "     LIKE   '" + Tool.ReplaceString(txt_search.Text) + "%'  ORDER BY " + FilterBy.ToString() + " ASC LIMIT 50");
        //        dt = a.Mytable_Proc("Patient_search", "@ID", ID);
        //        this.dg_result.Rows.Clear();
        //        Cursor.Current = Cursors.WaitCursor;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            //DateTime Date = Convert.ToDateTime(dr["result_date"].ToString());
        //            //string name =  dr["lastname"].ToString() + " , " + dr["firstname"].ToString() + " " + dr["middlename"].ToString();
        //            string[] rows = new string[] { dr["cn"].ToString(), dr["papin"].ToString(), dr["Name"].ToString() };
        //            dg_result.Rows.Add(rows);


        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
          


        //}


        void SelectItem()
        {
            if (dg_result.SelectedRows.Count >= 1)
            {
                this.Close();
                Cursor.Current = Cursors.WaitCursor;
                
                
                string pin = dg_result.SelectedRows[0].Cells[1].Value.ToString();
                //ClassSql a = new ClassSql(); DataTable dt = new DataTable();
                var p = (from m in db.t_psychologies where m.papin.Contains(pin) select m).ToList();


               if (p.Count() >= 1)
                {                                      
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).ClearAll();
                    frm_Psych_Evaluation.NewPsych_Eval = false;
                    frm_Psych_Evaluation.pin.Clear();
                    frm_Psych_Evaluation.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();                  
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Search_Patient();             
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).search_Psych();
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Availability(false);
                   fmain.ts_add_Eval.Enabled = true; fmain.ts_edit_Eval.Enabled = true; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = false; fmain.ts_search_Eval.Enabled = true; fmain.ts_print_Eval.Enabled = true; fmain.ts_cancel_Eval.Enabled = false;

                    this.Close();

                }
                else
                {
                  
                    frm_Psych_Evaluation.NewPsych_Eval = true;
                    frm_Psych_Evaluation.pin.Clear();
                    frm_Psych_Evaluation.pin.Text = dg_result.SelectedRows[0].Cells[1].Value.ToString();                 
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Availability(true);
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).ClearAll();
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Search_Patient();
                    (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).New();
                    fmain.ts_add_Eval.Enabled = false; fmain.ts_edit_Eval.Enabled = false; fmain.ts_delete_Eval.Enabled = false; fmain.ts_save_Eval.Enabled = true; fmain.ts_search_Eval.Enabled = false; fmain.ts_print_Eval.Enabled = false; fmain.ts_cancel_Eval.Enabled = true;

                    this.Close();

                }                
                               
                Cursor.Current = Cursors.Default;

            }


        }

      
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            FillDataGridView();
                  
                       
        }

        private void cmd_search_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectItem();
        }

        private void frm_search_Psych_Eval_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{ dg_result.Select(); }
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    this.Close();
            //    SelectItem(); }

            if (e.KeyCode == Keys.Enter)
            { SelectItem(); }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            { dg_result.Focus(); }
            //else if (e.KeyCode == Keys.Enter)
            //{ SearchNow(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search();
            txt_search.Clear();
            txt_search.Select();
            //dg_result.Rows.Clear();
            //cmd_select.Enabled = false;
            //if (backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.CancelAsync();
            //    iscanceled = true;
            //    lbl_notif.Text = "Process Canceled";
            //    lbl_notif.Visible = true;

            //}

        }

        private void dg_result_DoubleClick(object sender, EventArgs e)
        {
            SelectItem();
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

     

        //void SearchNow()
        //{
        //    if (txt_search.Text != "")
        //    {

        //        if (backgroundWorker1.IsBusy)
        //        {
        //            backgroundWorker1.CancelAsync();
                
        //        }
        //        else if (!backgroundWorker1.IsBusy)
        //        {

        //            lbl_notif.Text = "Searching...";
        //            lbl_notif.Visible = true;
        //            Foo f = new Foo();
        //            f.Name = txt_search.Text;
        //            this.dg_result.Rows.Clear();
        //            backgroundWorker1.RunWorkerAsync(f);
        //        }
        //    }
        //    else
        //    {
        //        lbl_notif.Visible = false;

        //    }
        //}

        //private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        Foo f = (Foo)e.Argument;
        //        int i = 1;
        //        ClassSql a = new ClassSql(); DataTable dt;
        //        dt = a.Mytable_Proc("Patient_search", "@ID", f.Name);
        //        Cursor.Current = Cursors.WaitCursor;

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            f.cn = dr["cn"].ToString();
        //            f.papin = dr["papin"].ToString();
        //            f.patientName = dr["Name"].ToString();                  
        //            backgroundWorker1.ReportProgress(i, f);
        //            i++;
        //            Thread.Sleep(10);

        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

        //    }
        //    finally
        //    {

        //        if (ClassSql.dr != null) { ClassSql.dr.Close(); }

        //    }

        //}

        //private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    if (!backgroundWorker1.CancellationPending)
        //    {
        //        Foo f = (Foo)e.UserState;
        //        this.dg_result.Rows.Add(f.cn.ToString(), f.papin.ToString(),  f.patientName.ToString());


        //    }
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //    if (iscanceled)
        //    {

        //        iscanceled = false;
        //    }


        //    else if (!iscanceled)
        //    {


        //        if (dg_result.Rows.Count == 0)
        //        {
        //            lbl_notif.Text = "No record found";
        //            lbl_notif.Visible = true;
        //            cmd_select.Enabled = false;
        //        }
        //        else
        //        {
        //            lbl_notif.Text = "";
        //            lbl_notif.Visible = false;
        //            cmd_select.Enabled = true;


        //        }

        //    }
        //}

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //int i = 0;
            this.Invoke(new MethodInvoker(delegate() { FillDataGridView(); }));
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

               
          
          

        }

      public  void FillDataGridView()
        {

            try
            {
                //dt_Psycho = Tool.GetDataSourceFromFile(TableListPath.Psycho);
                //if (dt_Psycho.Rows.Count >= 1)
                //{
                //    if (cbo_filter.Text == "Patient Pin")
                //    {
                //        dt_Psycho.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_Psycho.Columns[1], txt_search.Text);
                //    }
                //    else if (cbo_filter.Text == "Patient Name")
                //    {
                //        dt_Psycho.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", dt_Psycho.Columns[2], txt_search.Text);
                //    }

                //    dg_result.DataSource = dt_Psycho;
                //    dg_result.Columns[0].Visible = false;
                //    dg_result.Columns[1].Width = 100;
                //    dg_result.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //    lbl_notification.Visible = false;
                //}
                //else
                //{
                //    lbl_notification.Visible = true;
                //    lbl_notification.Text = "No record";
                //}
                //dg_result.Rows.Clear();
                Psychology_model = (Application.OpenForms["frm_Psych_Evaluation"] as frm_Psych_Evaluation).Psychology_model;
                var list = (from m in Psychology_model select m).ToList();
                if (cbo_filter.Text == "Patient Pin")
                {
                    list = (from m in Psychology_model where m.papin.StartsWith(txt_search.Text) select m).ToList();
                }
                else if (cbo_filter.Text == "Patient Name")
                {
                    list = (from m in Psychology_model where m.PatientName.StartsWith(txt_search.Text) select m).ToList();
                }
                dg_result.DataSource = list;
                dg_result.Columns[0].Visible = false;
                dg_result.Columns[1].Width = 100;
                dg_result.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }

          
        }

      private void frm_search_Psych_Eval_FormClosing(object sender, FormClosingEventArgs e)
      {
          isOpen = false;
      }


      



     
      

    }
}
