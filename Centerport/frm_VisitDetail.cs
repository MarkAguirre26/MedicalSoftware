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
using System.IO;

namespace Centerport
{
    public partial class frm_VisitDetail : Form
    {
        frm_search_Patient_Queuing Search_q;
        public frm_VisitDetail(frm_search_Patient_Queuing q)
        {
            InitializeComponent();
            Search_q = q;
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_VisitDetail_Load(object sender, EventArgs e)
        {
            
            load();
        }

        void load()
        {
            
            cbo_type.Text = "BNI";
            txt_transdate.Text = DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            txt_purpose.Select();
        //    txt_tracking.Text = ClassSql.CreateTrackingId();
           
        
        }

        private void cmd_ok_Click(object sender, EventArgs e)
        {
           
            InsertVisit();
        }



        void InsertVisit()
        {
             try
            {
                DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
                db.ExecuteCommand("INSERT INTO t_registration (trkid, papin, pxtype, trans_date, diagnosis,purpose) VALUES({0},{1},{2},{3},{4},{5})", txt_tracking.Text, this.Tag.ToString(), cbo_type.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")," ",Tool.ReplaceString(txt_purpose.Text));
                (Application.OpenForms["frm_visit"] as frm_visit).loadlist();

                // ClassSql a = new ClassSql();               
                // a.ExecuteQuery("INSERT INTO `t_registration` (`trkid`, `papin`, `pxtype`, `trans_date`, `diagnosis`,`purpose`) VALUES ('" + Tool.ReplaceString(txt_tracking.Text) + "', '" + Tool.ReplaceString(this.Tag.ToString()) + "', '" + Tool.ReplaceString(cbo_type.Text) + "', '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "', '','" + Tool.ReplaceString(txt_purpose.Text) + "')");
                               
                
                Search_q.Close();
                this.Close();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An error occured {0}", ex.Message), Properties.Settings.Default.SystemName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;

            }
                       




        }

        private void frm_VisitDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            //if (!(Application.OpenForms["frm_visit"] as frm_visit).backgroundWorker1.IsBusy)
            //{
            //    Centerport.frm_visit.TableFields f = new Centerport.frm_visit.TableFields();
            //    f.Date = (Application.OpenForms["frm_visit"] as frm_visit).dt_from.Text;
            //    (Application.OpenForms["frm_visit"] as frm_visit).dg_listQueue.Rows.Clear();
            //    (Application.OpenForms["frm_visit"] as frm_visit).backgroundWorker1.RunWorkerAsync(f);
            //}
        }

       


    }
}
