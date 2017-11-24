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
    public partial class frm_krpan : Form
    {
        frm_seafarer_MEC f_mec;
        public bool isEdit;
        public frm_krpan(frm_seafarer_MEC f)
        {
            InitializeComponent();
            f_mec = f;
        }

        private void frm_krpan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_krpan_Load(object sender, EventArgs e)
        {

            try
            {

                if (isEdit)
                {
                    DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);
                    var i = db.sp_krpan(this.Tag.ToString()).FirstOrDefault();
                    cbo_mendal.Text = i.MentalDisorder;
                    cbo_cardio.Text = i.Cardiovascular;
                    cbo_circum.Text = i.CircumferenceChest;
                    cbo_incfection.Text = i.Infection;
                    cbo_nervous.Text = i.NervousSystem;
                    cbo_digestive.Text = i.Digestive;
                    cbo_liver.Text = i.Liver;
                    cbo_anemia.Text = i.Anemia;
                }
               
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                
              //  throw;
            }
           
          
            

        }



        private void cmd_save_Click(object sender, EventArgs e)
        {
            //f_mec.MentalDisorder = cbo_mendal.Text;
            //f_mec.Cardiovascular = cbo_cardio.Text;
            //f_mec.CircumferenceChest = cbo_circum.Text;
            //f_mec.Infection = cbo_incfection.Text;
            //f_mec.NervousSystem = cbo_nervous.Text;
            //f_mec.Digestive = cbo_digestive.Text;
            //f_mec.Liver = cbo_liver.Text;
            //f_mec.Anemia = cbo_anemia.Text;
            //f_mec.UrineSyphilisis = cbo_urine.Text;
            //this.Close();

           
            DataClasses2DataContext db = new DataClasses2DataContext(Properties.Settings.Default.MyConString);

            var count = db.sp_countKrPan(this.Tag.ToString()).FirstOrDefault();
            if (count.Column1.Value >= 1)
            {
                db.sp_update_krpan(cbo_mendal.Text, cbo_cardio.Text, cbo_circum.Text, cbo_incfection.Text, cbo_nervous.Text, cbo_digestive.Text, cbo_liver.Text, cbo_anemia.Text, cbo_urine.Text, this.Tag.ToString());
                //db.ExecuteCommand("UPDATE [Centerport_Medical].[dbo].[tbl_krpan] SET [BloodDisorder]={0}, [MentalDisorder]={1}, [Cardiovascular]={2}, [CircumferenceChest]={3}, [Infection]={4}, [NervousSystem]={5}, [Digestive]={6}, [Liver]={7}, [Anemia]={8}, [UrineSyphilisis]={9} WHERE ([cn]='10')", "", cbo_mendal.Text, cbo_cardio.Text, cbo_circum.Text, cbo_incfection.Text, cbo_nervous.Text,         cbo_digestive.Text, cbo_liver.Text, cbo_anemia.Text, cbo_urine.Text, this.Tag.ToString());
                                                                                                                                                                                                                                                                                                                            //, [Cardiovascular]={2}, [CircumferenceChest]={3}, [Infection]={4},    [NervousSystem]={5}, [Digestive]={6}, [Liver]={7},   [Anemia]={8},  [UrineSyphilisis]={9}
            }
            else
            {
                db.ExecuteCommand("INSERT INTO [Centerport_Medical].[dbo].[tbl_krpan] ([Resultid], [BloodDisorder], [MentalDisorder], [Cardiovascular], [CircumferenceChest], [Infection], [NervousSystem], [Digestive], [Liver], [Anemia], [UrineSyphilisis]) VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})", this.Tag.ToString(), "",          cbo_mendal.Text, cbo_cardio.Text, cbo_circum.Text, cbo_incfection.Text,  cbo_nervous.Text,cbo_digestive.Text, cbo_liver.Text, cbo_anemia.Text, cbo_urine.Text);
            }                                                                                                                                                                                                                                                                                                           //[Resultid], [BloodDisorder], [MentalDisorder], [Cardiovascular], [CircumferenceChest], [Infection],   [NervousSystem],  [Digestive],       [Liver],        [Anemia],      [UrineSyphilisis]
            this.Close();

        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
