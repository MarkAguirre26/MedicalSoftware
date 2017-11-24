using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ini;

namespace Centerport
{
  
    public partial class frm_NormalValues : Form
    {
       
        public frm_NormalValues()
        {
            InitializeComponent();
        }

        private void frm_NormalValues_Load(object sender, EventArgs e)
        {
            //if (File.Exists(ClassSql.HemaPath))
            //{
            LoadHema();
            //}
            //if (File.Exists(ClassSql.ChemistryPath))
            //{
            LoadChemistry();
            //}
            //if (File.Exists(ClassSql.HivPath))
            //{
            LoadHIV();
            load_Medical();
            Load_FornNo();
            loadNormaValueTumor();
            //}
            }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (File.Exists(ClassSql.MMS_Path))
            //{
            //    File.Delete(ClassSql.MMS_Path);
            //}
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            ini.IniWriteValue("NormalValue", "hemoglobin", hemoglobin.Text);
            ini.IniWriteValue("NormalValue", "hematocrit", hematocrit.Text);
            ini.IniWriteValue("NormalValue", "RBC", RBC.Text);
            ini.IniWriteValue("NormalValue", "WBC", WBC.Text);
            ini.IniWriteValue("NormalValue", "Platelet", Platelet.Text);
            ini.IniWriteValue("NormalValue", "BloodType", BloodType.Text);
            ini.IniWriteValue("NormalValue", "ESR", ESR.Text);
            ini.IniWriteValue("NormalValue", "Lympho", Lympho.Text);
            ini.IniWriteValue("NormalValue", "Segmenters", Segmenters.Text);
            ini.IniWriteValue("NormalValue", "Easinophils", Easinophils.Text);
            ini.IniWriteValue("NormalValue", "MonoCytes", MonoCytes.Text);
            ini.IniWriteValue("NormalValue", "Myelocytes", Myelocytes.Text);
            ini.IniWriteValue("NormalValue", "Juveniles", Juveniles.Text);
            ini.IniWriteValue("NormalValue", "StabCells", StabCells.Text);
            ini.IniWriteValue("NormalValue", "BasoPhils", BasoPhils.Text);
            ini.IniWriteValue("NormalValue", "Hema_Other", Hema_Other.Text);
            ini.IniWriteValue("NormalValue", "textBox1", textBox1.Text);

            //FileInfo CreateFile = new FileInfo(ClassSql.HemaPath);
            //FileStream Create = CreateFile.Create();
            //Create.Close();
            //File.AppendAllLines(ClassSql.HemaPath, new[] { hemoglobin.Text, hematocrit.Text, RBC.Text, WBC.Text, Platelet.Text, BloodType.Text, ESR.Text, Lympho.Text, Segmenters.Text, Easinophils.Text, MonoCytes.Text, Myelocytes.Text, Juveniles.Text, StabCells.Text, BasoPhils.Text, Hema_Other.Text, textBox1.Text });

            Tool.MessageBoxSave();
            LoadHema();

           

        }
        void LoadHema()
        {
            //if (File.Exists(ClassSql.MMS_Path))
            //{
            //    string[] lines = System.IO.File.ReadAllLines(ClassSql.MMS_Path);
                IniFile ini = new IniFile(ClassSql.MMS_Path);
                hemoglobin.Text = ini.IniReadValue("NormalValue", "hemoglobin");
                hematocrit.Text = ini.IniReadValue("NormalValue", "hematocrit");
                RBC.Text = ini.IniReadValue("NormalValue", "RBC");
                WBC.Text = ini.IniReadValue("NormalValue", "WBC");
                Platelet.Text = ini.IniReadValue("NormalValue", "Platelet");
                BloodType.Text = ini.IniReadValue("NormalValue", "BloodType");
                ESR.Text = ini.IniReadValue("NormalValue", "ESR");
                Lympho.Text = ini.IniReadValue("NormalValue", "Lympho");
                Segmenters.Text = ini.IniReadValue("NormalValue", "Segmenters");
                Easinophils.Text = ini.IniReadValue("NormalValue", "Easinophils");
                MonoCytes.Text = ini.IniReadValue("NormalValue", "MonoCytes");
                Myelocytes.Text = ini.IniReadValue("NormalValue", "Myelocytes");
                Juveniles.Text = ini.IniReadValue("NormalValue", "Juveniles");
                StabCells.Text = ini.IniReadValue("NormalValue", "StabCells");
                BasoPhils.Text = ini.IniReadValue("NormalValue", "BasoPhils");
                Hema_Other.Text = ini.IniReadValue("NormalValue", "Hema_Other");
                textBox1.Text = ini.IniReadValue("NormalValue", "textBox1");
            
           // }
            
          
        }

        void LoadHIV()
        {
            //if (File.Exists(ClassSql.MMS_Path))
            //{
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            dt_expire.Text = ini.IniReadValue("HIVExpireDate", "Date");
            
            //}
        }

        void LoadChemistry()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);    

            tx_fbs.Text = ini.IniReadValue("NormalValue", "fbs");
            txt_bun.Text = ini.IniReadValue("NormalValue", "bun");
            txt_creatine.Text = ini.IniReadValue("NormalValue", "creatine");
            txt_choles.Text = ini.IniReadValue("NormalValue", "choles");
            txt_trigly.Text = ini.IniReadValue("NormalValue", "trigly");
            txt_uric.Text = ini.IniReadValue("NormalValue", "uric");
            txt_sgot.Text = ini.IniReadValue("NormalValue", "sgot");
            txt_sgpt.Text = ini.IniReadValue("NormalValue", "sgpt");
            txt_alk.Text = ini.IniReadValue("NormalValue", "alk");
            L_fbs_con.Text = ini.IniReadValue("NormalValue", "fbs_con");
            l_bun_con.Text = ini.IniReadValue("NormalValue", "bun_con");
            L_creatine_Con.Text = ini.IniReadValue("NormalValue", "creatine_Con");
            L_Cholesterol_Con.Text = ini.IniReadValue("NormalValue", "Cholesterol_Con");
            L_Trig_Con.Text = ini.IniReadValue("NormalValue", "Trig_Con");
            l_Uric_Con.Text = ini.IniReadValue("NormalValue", "Uric_Con");
            sgpt_con.Text = ini.IniReadValue("NormalValue", "sgpt_con");
            sgot_con.Text = ini.IniReadValue("NormalValue", "sgot_con");
            alk_con.Text = ini.IniReadValue("NormalValue", "alk_con");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {         
            // tx_fbs.Text        
            // txt_bun.Text      
            //  txt_creatine.Text
            // txt_choles.Text   
            // txt_trigly.Text   
            // txt_uric.Text     
            // txt_sgot.Text     
            // txt_sgpt.Text     
            // txt_alk.Text      
            // L_fbs_con.Text    
            // l_bun_con.Text    
            // L_creatine_Con.Tex
            // L_Cholesterol_Con.
            // L_Trig_Con.Text   
            // l_Uric_Con.Text   
            // sgpt_con.Text     
            // sgot_con.Text     
            // alk_con.Text      
            
            
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            ini.IniWriteValue("NormalValue", "fbs"              , tx_fbs.Text);
            ini.IniWriteValue("NormalValue", "bun"              , txt_bun.Text);
            ini.IniWriteValue("NormalValue", "creatine"         , txt_creatine.Text);
            ini.IniWriteValue("NormalValue", "choles"           , txt_choles.Text);
            ini.IniWriteValue("NormalValue", "trigly"           , txt_trigly.Text);
            ini.IniWriteValue("NormalValue", "uric"             , txt_uric.Text);
            ini.IniWriteValue("NormalValue", "sgot"             , txt_sgot.Text);
            ini.IniWriteValue("NormalValue", "sgpt"             ,    txt_sgpt.Text);

            ini.IniWriteValue("NormalValue", "alk"              , txt_alk.Text);
            ini.IniWriteValue("NormalValue", "fbs_con"          , L_fbs_con.Text);
            ini.IniWriteValue("NormalValue", "bun_con"          , l_bun_con.Text);
            ini.IniWriteValue("NormalValue", "creatine_Con"     , L_creatine_Con.Text);
            ini.IniWriteValue("NormalValue", "Cholesterol_Con"  , L_Cholesterol_Con.Text);
            ini.IniWriteValue("NormalValue", "Trig_Con"         , L_Trig_Con.Text);
            ini.IniWriteValue("NormalValue", "Uric_Con"         , l_Uric_Con.Text);
            ini.IniWriteValue("NormalValue", "sgpt_con"         , sgpt_con.Text);
            ini.IniWriteValue("NormalValue", "sgot_con"         , sgot_con.Text);
            ini.IniWriteValue("NormalValue", "alk_con"          , alk_con.Text);


            Tool.MessageBoxSave();
            LoadChemistry();
        }

   

        private void button7_Click(object sender, EventArgs e)
        {

            IniFile ini = new IniFile(ClassSql.MMS_Path);
            ini.IniWriteValue("HIVExpireDate", "Date", dt_expire.Text);
            Tool.MessageBoxSave();
            LoadHIV();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            ini.IniWriteValue("MEDICAL", "PEME_Physician", a.Text); ini.IniWriteValue("MEDICAL", "PEME_Physician_license", aa.Text);
            ini.IniWriteValue("MEDICAL", "PEME MedicalDirector", b.Text); ini.IniWriteValue("MEDICAL", "PEME MedicalDirector_license", bb.Text);
            ini.IniWriteValue("MEDICAL", "MedTech", c.Text); ini.IniWriteValue("MEDICAL", "MedTech_license", cc.Text);
            ini.IniWriteValue("MEDICAL", "medtech1_Name", txt_medtech1_Name.Text); ini.IniWriteValue("MEDICAL", "medtech1_Lic", txt_medtech1_Lic.Text);
            ini.IniWriteValue("MEDICAL", "medtech2_Name", txt_medtech2_Name.Text); ini.IniWriteValue("MEDICAL", "medtech2_Lic", txt_medtech2_Lic.Text);
            ini.IniWriteValue("MEDICAL", "Pathologist", d.Text); ini.IniWriteValue("MEDICAL", "Pathologist_license", dd.Text);
            ini.IniWriteValue("MEDICAL", "Xray_Radiologist", ea.Text); ini.IniWriteValue("MEDICAL", "Xray Radiologist_license", ee.Text);
            ini.IniWriteValue("MEDICAL", "XRAY_TECH", txt_xray_tech_Name.Text); ini.IniWriteValue("MEDICAL", "XRAYTECH_LICENSE", txt_xray_tech_License.Text);
            ini.IniWriteValue("MEDICAL", "Medical_Director", f.Text); ini.IniWriteValue("MEDICAL", "Medical Director_license", ff.Text);
            ini.IniWriteValue("MEDICAL", "HIV_Exam_physician", g.Text); ini.IniWriteValue("MEDICAL", "HIV_Exam_physician_license", gg.Text);
            ini.IniWriteValue("MEDICAL", "Psychometrician", h.Text); ini.IniWriteValue("MEDICAL", "Psychometrician_license", hh.Text);
            ini.IniWriteValue("MEDICAL", "Psychologist", i.Text); ini.IniWriteValue("MEDICAL", "Psychologist_license", ii.Text);
            ini.IniWriteValue("MEDICAL", "hiv_cert_no", j.Text);
            ini.IniWriteValue("MEDICAL", "Psychometrician_Validity", Metrician_validity.Text);
            ini.IniWriteValue("MEDICAL", "Psychometrician_ptr", Metrician_ptr.Text);
            ini.IniWriteValue("MEDICAL", "Psychologist_Validity", Chologist_validity.Text);
            ini.IniWriteValue("MEDICAL", "Psychologist_Ptr", Chologist_ptr.Text);
            Tool.MessageBoxSave();
            load_Medical();

        }


        void load_Medical()
        {

     


            IniFile ini = new IniFile(ClassSql.MMS_Path);
      a.Text   =    ini.IniReadValue("MEDICAL", "PEME_Physician");
          aa.Text   =   ini.IniReadValue("MEDICAL", "PEME_Physician_license");
     b.Text   =   ini.IniReadValue("MEDICAL", "PEME MedicalDirector");
        bb.Text   =   ini.IniReadValue("MEDICAL", "PEME MedicalDirector_license");
       c.Text    =   ini.IniReadValue("MEDICAL", "MedTech");
       txt_medtech1_Name.Text = ini.IniReadValue("MEDICAL", "medtech1_Name");
       txt_medtech1_Lic.Text = ini.IniReadValue("MEDICAL", "medtech1_Lic");

       txt_medtech2_Name.Text = ini.IniReadValue("MEDICAL", "medtech2_Name");
       txt_medtech2_Lic.Text = ini.IniReadValue("MEDICAL", "medtech2_Lic");
        cc.Text    =   ini.IniReadValue("MEDICAL", "MedTech_license");
       d.Text   =   ini.IniReadValue("MEDICAL", "Pathologist");
    dd.Text    =   ini.IniReadValue("MEDICAL", "Pathologist_license");
       ea.Text    =   ini.IniReadValue("MEDICAL", "Xray_Radiologist");
       ee.Text   =   ini.IniReadValue("MEDICAL", "Xray Radiologist_license");
          f.Text   =   ini.IniReadValue("MEDICAL", "Medical_Director");
         ff.Text =   ini.IniReadValue("MEDICAL", "Medical Director_license");
             g.Text  =   ini.IniReadValue("MEDICAL", "HIV_Exam_physician");
      gg.Text    =   ini.IniReadValue("MEDICAL", "HIV_Exam_physician_license");

         h.Text   =   ini.IniReadValue("MEDICAL", "Psychometrician");
         hh.Text  =   ini.IniReadValue("MEDICAL", "Psychometrician_license");
         i.Text  =   ini.IniReadValue("MEDICAL", "Psychologist");
        ii.Text  =   ini.IniReadValue("MEDICAL", "Psychologist_license");

      j.Text = ini.IniReadValue("MEDICAL", "hiv_cert_no");

      Metrician_validity.Text = ini.IniReadValue("MEDICAL", "Psychometrician_Validity");
      Metrician_ptr.Text = ini.IniReadValue("MEDICAL", "Psychometrician_ptr");

      Chologist_validity.Text = ini.IniReadValue("MEDICAL", "Psychologist_Validity");
      Chologist_ptr.Text = ini.IniReadValue("MEDICAL", "Psychologist_Ptr");


      txt_xray_tech_Name.Text = ini.IniReadValue("MEDICAL", "XRAY_TECH");
      txt_xray_tech_License.Text = ini.IniReadValue("MEDICAL", "XRAYTECH_LICENSE");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
           

            ini.IniWriteValue("FORM", "Lab_06",                         Form1.Text);
            ini.IniWriteValue("FORM", "Lab_08",                         Form2.Text);
            ini.IniWriteValue("FORM", "Lab_Hema",                       Form3.Text);
            ini.IniWriteValue("FORM", "Lab_Chemistry",                  Form4.Text);
            ini.IniWriteValue("FORM", "Lab_Urinalysis",                 Form5.Text);
            ini.IniWriteValue("FORM", "Lab_Fecalysis",                  Form6.Text);
            ini.IniWriteValue("FORM", "HIV",                            Form7.Text);
            ini.IniWriteValue("FORM", "XRAY",                           Form8.Text);
            ini.IniWriteValue("FORM", "Ultrasound",                     Form9.Text);
            ini.IniWriteValue("FORM", "Psycho_Evaluation",              Form10.Text);
            ini.IniWriteValue("FORM", "Seafarer_Summary",               Form11.Text);
            ini.IniWriteValue("FORM", "Seafarer_Detailed",              Form12.Text);
            ini.IniWriteValue("FORM", "Seafarer_MER",                   Form13.Text);
            ini.IniWriteValue("FORM", "Seafarer_MLC",                   Form14.Text);
            ini.IniWriteValue("FORM", "Landbase_Summary",               Form15.Text);
            ini.IniWriteValue("FORM", "Landbase_Detailed",              Form16.Text);
            ini.IniWriteValue("FORM", "Landbase_MER",                   Form17.Text);
            ini.IniWriteValue("FORM", "Landbase_MLC",                   Form18.Text);

            //ini.IniWriteValue("REVISION", "Lab_33", Form33_Rev.Text);
            //ini.IniWriteValue("REVISION", "Lab_34", Form34_Rev.Text);

            ini.IniWriteValue("REVISION", "Lab_06",                     Rev1.Text);
            ini.IniWriteValue("REVISION", "Lab_08",                     Rev2.Text);
            ini.IniWriteValue("REVISION", "Lab_Hema",                   Rev3.Text);
            ini.IniWriteValue("REVISION", "Lab_Chemistry",              Rev4.Text);
            ini.IniWriteValue("REVISION", "Lab_Urinalysis",             Rev5.Text);
            ini.IniWriteValue("REVISION", "Lab_Fecalysis",              Rev6.Text);
            ini.IniWriteValue("REVISION", "HIV",                        Rev7.Text);
            ini.IniWriteValue("REVISION", "XRAY",                       Rev8.Text);
            ini.IniWriteValue("REVISION", "Ultrasound",                 Rev9.Text);
            ini.IniWriteValue("REVISION", "Psycho_Evaluation",          Rev10.Text);
            ini.IniWriteValue("REVISION", "Seafarer_Summary",           Rev11.Text);
            ini.IniWriteValue("REVISION", "Seafarer_Detailed",          Rev12.Text);
            ini.IniWriteValue("REVISION", "Seafarer_MER",               Rev13.Text);
            ini.IniWriteValue("REVISION", "Seafarer_MLC",               Rev14.Text);
            ini.IniWriteValue("REVISION", "Landbase_Summary",           Rev15.Text);
            ini.IniWriteValue("REVISION", "Landbase_Detailed",          Rev16.Text);
            ini.IniWriteValue("REVISION", "Landbase_MER",               Rev17.Text);
            ini.IniWriteValue("REVISION", "Landbase_MLC",               Rev18.Text);

            //ini.IniWriteValue("ISO", "Lab_33",Form33_ISO.Text);
            //ini.IniWriteValue("ISO", "Lab_34", Form34_ISO.Text);

            ini.IniWriteValue("ISO", "Lab_06",                          Iso1.Text);
            ini.IniWriteValue("ISO", "Lab_08",                          Iso2.Text);
            ini.IniWriteValue("ISO", "Lab_Hema",                        Iso3.Text);
            ini.IniWriteValue("ISO", "Lab_Chemistry",                   Iso4.Text);
            ini.IniWriteValue("ISO", "Lab_Urinalysis",                  Iso5.Text);
            ini.IniWriteValue("ISO", "Lab_Fecalysis",                   Iso6.Text);
            ini.IniWriteValue("ISO", "HIV",                             Iso7.Text);
            ini.IniWriteValue("ISO", "XRAY",                            Iso8.Text);
            ini.IniWriteValue("ISO", "Ultrasound",                      Iso9.Text);
            ini.IniWriteValue("ISO", "Psycho_Evaluation",               Iso10.Text);
            ini.IniWriteValue("ISO", "Seafarer_Summary",                Iso11.Text);
            ini.IniWriteValue("ISO", "Seafarer_Detailed",               Iso12.Text);
            ini.IniWriteValue("ISO", "Seafarer_MER",                    Iso13.Text);
            ini.IniWriteValue("ISO", "Seafarer_MLC",                    Iso14.Text);
            ini.IniWriteValue("ISO", "Landbase_Summary",                Iso15.Text);
            ini.IniWriteValue("ISO", "Landbase_Detailed",               Iso16.Text);
            ini.IniWriteValue("ISO", "Landbase_MER",                    Iso17.Text);
            ini.IniWriteValue("ISO", "Landbase_MLC",                    Iso18.Text);
            Tool.MessageBoxSave();


        }
        void Load_FornNo()
        {

            IniFile ini = new IniFile(ClassSql.MMS_Path);

            Form33.Text = ini.IniReadValue("FORM", "Lab_33");
            form34.Text = ini.IniReadValue("FORM", "Lab_34");
             Form1.Text   = ini.IniReadValue( "FORM", "Lab_06");            
             Form2.Text   = ini.IniReadValue( "FORM", "Lab_08");            
             Form3.Text   = ini.IniReadValue( "FORM", "Lab_Hema");          
             Form4.Text   = ini.IniReadValue( "FORM", "Lab_Chemistry");     
             Form5.Text   = ini.IniReadValue( "FORM", "Lab_Urinalysis");    
             Form6.Text   = ini.IniReadValue( "FORM", "Lab_Fecalysis");   
             Form7.Text   = ini.IniReadValue( "FORM", "HIV");               
             Form8.Text   = ini.IniReadValue( "FORM", "XRAY");              
             Form9.Text   = ini.IniReadValue( "FORM", "Ultrasound");        
             Form10.Text  = ini.IniReadValue( "FORM", "Psycho_Evaluation"); 

             Form11.Text  = ini.IniReadValue( "FORM", "Seafarer_Summary");
             Form12.Text  = ini.IniReadValue( "FORM", "Seafarer_Detailed"); 
             Form13.Text  = ini.IniReadValue( "FORM", "Seafarer_MER");      
             Form14.Text  = ini.IniReadValue( "FORM", "Seafarer_MLC");  
   
             Form15.Text  = ini.IniReadValue( "FORM", "Landbase_Summary");  
             Form16.Text  = ini.IniReadValue( "FORM", "Landbase_Detailed"); 
             Form17.Text  = ini.IniReadValue( "FORM", "Landbase_MER");
             Form18.Text = ini.IniReadValue("FORM", "Landbase_MLC");

             this.Form33_Rev.Text = ini.IniReadValue("REVISION", "Lab_33");
             Form34_Rev.Text = ini.IniReadValue("REVISION", "Lab_34");

             Rev1.Text   = ini.IniReadValue("REVISION", "Lab_06");           
             Rev2.Text   = ini.IniReadValue("REVISION", "Lab_08");            
             Rev3.Text   = ini.IniReadValue("REVISION", "Lab_Hema");          
             Rev4.Text   = ini.IniReadValue("REVISION", "Lab_Chemistry");     
             Rev5.Text   = ini.IniReadValue("REVISION", "Lab_Urinalysis");    
             Rev6.Text   = ini.IniReadValue("REVISION", "Lab_Fecalysis");    
             Rev7.Text   = ini.IniReadValue("REVISION", "HIV");               
             Rev8.Text   = ini.IniReadValue("REVISION", "XRAY");              
             Rev9.Text   = ini.IniReadValue("REVISION", "Ultrasound");        
             Rev10.Text  = ini.IniReadValue("REVISION", "Psycho_Evaluation");
 
             Rev11.Text  = ini.IniReadValue("REVISION", "Seafarer_Summary");
             Rev12.Text  = ini.IniReadValue("REVISION", "Seafarer_Detailed"); 
             Rev13.Text  = ini.IniReadValue("REVISION", "Seafarer_MER");
             Rev14.Text  = ini.IniReadValue("REVISION", "Seafarer_MLC");  
    
             Rev15.Text  = ini.IniReadValue("REVISION", "Landbase_Summary");  
             Rev16.Text  = ini.IniReadValue("REVISION", "Landbase_Detailed"); 
             Rev17.Text  = ini.IniReadValue("REVISION", "Landbase_MER");
             Rev18.Text = ini.IniReadValue("REVISION", "Landbase_MLC");

             Form33_ISO.Text = ini.IniReadValue("ISO", "Lab_33");
             Form34_ISO.Text = ini.IniReadValue("ISO", "Lab_34");    

             Iso1.Text  = ini.IniReadValue("ISO", "Lab_06");           
             Iso2.Text  = ini.IniReadValue("ISO", "Lab_08");          
             Iso3.Text  = ini.IniReadValue("ISO", "Lab_Hema");         
             Iso4.Text  = ini.IniReadValue("ISO", "Lab_Chemistry");    
             Iso5.Text  = ini.IniReadValue("ISO", "Lab_Urinalysis");   
             Iso6.Text  = ini.IniReadValue("ISO", "Lab_Fecalysis");  
             Iso7.Text  = ini.IniReadValue("ISO", "HIV");             
             Iso8.Text  = ini.IniReadValue("ISO", "XRAY");             
             Iso9.Text  = ini.IniReadValue("ISO", "Ultrasound");       
             Iso10.Text = ini.IniReadValue("ISO", "Psycho_Evaluation");

             Iso11.Text = ini.IniReadValue("ISO", "Seafarer_Summary");
             Iso12.Text = ini.IniReadValue("ISO", "Seafarer_Detailed");
             Iso13.Text = ini.IniReadValue("ISO", "Seafarer_MER");
             Iso14.Text = ini.IniReadValue("ISO", "Seafarer_MLC");  
  
             Iso15.Text = ini.IniReadValue("ISO", "Landbase_Summary"); 
             Iso16.Text = ini.IniReadValue("ISO", "Landbase_Detailed");
             Iso17.Text = ini.IniReadValue("ISO", "Landbase_MER");
             Iso18.Text = ini.IniReadValue("ISO", "Landbase_MLC");

             txt_medicalNumber.Text = ini.IniReadValue("MedicalCertificationNumber", "Number");
                    
        
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            ini.IniWriteValue("FORM", "Lab_33", Form33.Text);
            ini.IniWriteValue("FORM", "Lab_34", form34.Text);
            ini.IniWriteValue("REVISION", "Lab_33", Form33_Rev.Text);
            ini.IniWriteValue("REVISION", "Lab_34", Form34_Rev.Text);
            ini.IniWriteValue("ISO", "Lab_33", Form33_ISO.Text);
            ini.IniWriteValue("ISO", "Lab_34", Form34_ISO.Text);
            ini.IniWriteValue("MedicalCertificationNumber", "Number", txt_medicalNumber.Text);
            Load_FornNo();
            Tool.MessageBoxSave();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            ini.IniWriteValue("NormalValue", "PSA",                 txtpsa.Text);
            ini.IniWriteValue("NormalValue", "AFP",                 txtafp.Text);
            ini.IniWriteValue("NormalValue", "TumorOther",          txt_tumorOther.Text);
            ini.IniWriteValue("NormalValue", "HBS",                 txt_hbs.Text);
            ini.IniWriteValue("NormalValue", "HBC",                 txt_hbc.Text);
            ini.IniWriteValue("NormalValue", "HCV",                 txt_hcv.Text);
            ini.IniWriteValue("NormalValue", "HBSAG",               txt_hbsag.Text);
            ini.IniWriteValue("NormalValue", "Blank",               txt_blankImmu.Text);
            ini.IniWriteValue("NormalValue", "ImmuOther",   txt_otherImmu.Text);
            loadNormaValueTumor();
            Tool.MessageBoxSave();

        }
        void loadNormaValueTumor()
        {
            IniFile ini = new IniFile(ClassSql.MMS_Path);
            txtpsa.Text = ini.IniReadValue("NormalValue", "PSA");
            txtafp.Text= ini.IniReadValue("NormalValue", "AFP");
            txt_tumorOther.Text= ini.IniReadValue("NormalValue", "TumorOther");
            txt_hbs.Text= ini.IniReadValue("NormalValue", "HBS");
            txt_hbc.Text= ini.IniReadValue("NormalValue", "HBC");
            txt_hcv.Text= ini.IniReadValue("NormalValue", "HCV");
            txt_hbsag.Text= ini.IniReadValue("NormalValue", "HBSAG");
            txt_blankImmu.Text= ini.IniReadValue("NormalValue", "Blank");
            txt_otherImmu.Text = ini.IniReadValue("NormalValue", "ImmuOther");
        
        }
    }
   
}
