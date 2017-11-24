using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Centerport.Dataset;
using Centerport.Report;
namespace Centerport.Dataset
{
    public partial class frm_report : Form
    {
        public frm_report()
        {
            InitializeComponent();
        }

        private async void frm_report_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            DataTable dt = new ds_report1.sp_visitReportDataTable();
            Visit_Report rpt = new Visit_Report();

            await Task.Run(() =>
            {
                var list = db.sp_visitReport(this.Tag.ToString()).ToList();
                foreach (var i in list)
                {
                   
                    dt.Rows.Add( i.papin, i.PatientName, i.gender, i.pxtype,i.trans_date, i.diagnosis);

                }
                this.Invoke(new Action(() => { rpt.SetDataSource(dt); }));

            });
            this.crystalReportViewer1.ReportSource = rpt;

        }
    }
}
