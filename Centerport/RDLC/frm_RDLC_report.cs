using Centerport.Dataset;
using Ini;
using Microsoft.Reporting.WinForms;
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

namespace Centerport.RDLC
{
    public partial class frm_RDLC_report : Form
    {
        private string AppPath = (Path.GetDirectoryName(Application.StartupPath));
        public string date1;
        public bool isVisit = false;
        public bool isHIV = false;
        public bool isXRAY = false;
        public bool isUltrasound = false;
        public bool isSeaMLC = false;
        public bool isFecalysis = false;
        public bool isUrinalysis = false;
        public bool isChemistry = false;
        public bool isHEMA = false;
        public bool isLAB08 = false;
        public bool isLAB06 = false;
        public bool isPsycho = false;
        public bool isLandMLC = false;

        public string Employer;
        public string rpr_;
        public string BsAG;
        public string WIDALTEST;
        public string MALARIAL;

        public string age;
        public string imgpath;
        public string PatientName;
        public string ExaminigPhysycian;
        public string ExaminigPhysycian_lic;
        public string resultDate;
        public string Address;
        public string Sex;
        public string CivilStatus;
        public string Medtech;
        public string MedTech_lic;
        public string ExpiryDate;
        public string Pathologist;
        public string Pathologist_Lic;
        public string rapid;
        public string Particle;
        public string EIA;
        public string other;
        public string Nonrecative;
        public string Reactive;
        public string result;




        //HEMA
        public string Position;
        public string ReferredBy;
        public string Hemoglobin_;
        public string Hematocrit_;
        public string RBCcount_;
        public string WBC_;
        public string Platelet_;
        public string BloodType_;
        public string Lymphocyte_;
        public string Segmenters_;
        public string easinophils_;
        public string Monoytes_;
        public string myelocytes_;
        public string Juveniles_;
        public string stabCells_;
        public string Basophils_;
        public string Others_;
        public string SpecimenNo;
        public string esr_;

        //CHEM
        public string FBS_;
        public string BUN_;
        public string CREATINE_;
        public string CHOLESTEROL_;
        public string TRIGLYCERIDES_;
        public string URICACID_;
        public string SGOT_;
        public string SGPT_;
        public string ALKPHOS_;
        //public string Medtech;
        //public string Medtech_Lic;
        //public string Pathologist;
        //public string Pathologist_Lic;
        //public string SpecimenNo;
        public string FBS_H;
        public string BUN_H;
        public string CREATINE_H;
        public string CHOLESTEROL_H;
        public string TRIGLYCERIDES_H;
        public string URICACID_H;
        public string SGOT_H;
        public string SGPT_H;
        public string ALKPHOS_H;
        public string FBS_CON_;
        public string BUN_CON_;
        public string CREATINE_CON_;
        public string CHOLESTEROL_CON_;
        public string TRIGLYCERIDES_CON_;
        public string URICACID_CON_;
        public string SGOT_CON_;
        public string SGPT_CON_;
        public string ALKPHOS_CON_;

        public string Remark_Chem;
        //FECALYSIS

        public string ResultDate_Fecal;
        public string Color;
        public string WHITeBLOODCELLS;
        public string Mucus;
        public string OVAORPARASITE;
        public string AMOEBA;
        public string OCCULTBLOODTEST;
        public string Others_fecal;
        public string CONSISTENCY;
        public string RedBlood;
        public string Color_other;


        //URINALYSIS

        public string resultdate_Urinalysis;
        public string RequestedBy;
        public string COLOR_Urnialysis;
        public string Transparency;
        public string Leucocytes;
        public string Nitrite;
        public string Urobilinogen;
        public string Protein;
        public string pH;
        public string Blood;
        public string SpecificGravity;
        public string Ketone;
        public string Bilirubin;
        public string Glucose;
        public string other_chem;
        public string RedBloodCells_Urinalysis;
        public string WhiteBloodCells_Urinalysis;
        public string Amorphous_Urates;
        public string Phosphate;
        public string EpithelialCells;
        public string MucusThread;
        public string others_Microscopic;
        public string UricAcid_Urinalysis;
        public string CalciumOxalate;
        public string Others_Crystal;
        public string FineGranularCast;
        public string CoarseGranularCast;
        public string Others_Cast;
        public string Color_remark;
        public string ResultDate_UTZ;
        public string ResultDate_XRAY;
        public string Findings;
        public string Impression;
        public string Radiologist;
        public string Radiologist_Lic;



        public string hdl;
        public string ldl;
        public string acidPhos;
        public string totalbilirubin;
        public string b1;
        public string b2;
        public string totalpro;
        public string albumin;
        public string globulin;
        public string agration;
        public string other_more_chem;
        public string hdl_con;
        public string ldl_con;
        public string acidPhos_con;
        public string totalbilirubin_con;
        public string b1_con;
        public string b2_Con;
        public string b2_con;
        public string totalpro_con;
        public string albumin_con;
        public string globulin_con;
        public string agration_con;
        public string other_con;
        public string hdl_H;
        public string ldl_H;
        public string acidPhos_H;
        public string totalbilirubin_H;
        public string b1_H;
        public string b2_H;
        public string totalpro_H;
        public string albumin_H;
        public string globulin_H;
        public string agration_H;
        public string other_H;


        public string IQ_TEST;
        public string Personal_TEST;
        public string Other_test;
        public string Interlectual_level;
        public string Perseverance;
        public string Obedienc;
        public string Discipline;
        public string Enthusiasm;
        public string boredom;
        public string Tolerance;
        public string Reality;
        public string Confidence;
        public string Conclusion;
        public string Relaxed;
        public string mindedness;
        public string Adaptability;
        public string Practicality;
        public string Assertiveness;
        public string Independence;
        public string Resourcefulness;
        public string Relationship;
        public string Superiors;
        public string esteem;
        public string Aggressive;
        public string Direct;
        public string med_1;
        public string Lic_1;
        public string Validity_1;
        public string ptr_1;
        public string Med_2;
        public string Validity_2;
        public string ptr_2;
        public string Lic_2;
        public string Initiative;
        public string Conclusion_text1;
        public string Conclusion_text2;
        public string ShowImage;
        DataClasses1DataContext db = new DataClasses1DataContext();


        IniFile ini = new IniFile(ClassSql.MMS_Path);
        public frm_RDLC_report()
        {
            InitializeComponent();
        }

        private void frm_Visit_report_Load(object sender, EventArgs e)
        {
            LoadReports();
        }

        void LoadReports()
        {
            if (isVisit)
            { Load_Visit_Report(); }
            else if (isHIV)
            { Load_HIV_Report(); }
            else if (isXRAY)
            { Load_XRAY_Report(); }
            else if (isUltrasound)
            { Load_Utrasound_Report(); }
            else if (isSeaMLC)
            { Load_SEABASE_MLC_Report(); }
            else if (isFecalysis)
            { Load_Fecalysis_Report(); }
            else if (isUrinalysis)
            { Load_Urinalysis(); }
            else if (isChemistry)
            { Load_Chemistry(); }
            else if (isHEMA)
            { Load_HEMA(); }
            else if (isLAB08)
            { Load_LAB08(); }
            else if (isLAB06)
            { Load_LAB06(); }
            else if (isPsycho)
            { Load_Psycho_Report(); }
            else if (isLandMLC)
            { Load_Land_Report(); }
        }

        void Load_Visit_Report()
        {


            DataClasses1DataContext db = new DataClasses1DataContext(Properties.Settings.Default.MyConString);
            var list = db.sp_visitReport(date1).ToList();
            DataTable dt = new ds_report1.sp_visitReportDataTable();
            foreach (var i in list)
            {
              
                dt.Rows.Add(i.papin, i.PatientName, i.gender, i.pxtype, i.trans_date, i.diagnosis);
            }

            //  DataTable dt = ClassSql.GetData_Data("SELECT m_patient1.papin, m_patient1.lastname, m_patient1.firstname, m_patient1.middlename, m_patient1.gender, t_registration1.pxtype, t_registration1.trans_date, t_registration1.diagnosis FROM   cmsi.t_registration t_registration1 INNER JOIN cmsi.m_patient m_patient1 ON t_registration1.papin=m_patient1.papin WHERE t_registration1.trans_date like '%" + date1 + "%'");
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Visit.rdlc";
            ReportParameter[] parms = new ReportParameter[2];
            parms[0] = new ReportParameter("DateRange_From", date1, false);
            parms[1] = new ReportParameter("DateRange_To", date1, false);
            this.reportViewer1.LocalReport.SetParameters(parms);
            ReportviewerSetting();
        }

        void Load_Psycho_Report()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_Report_HIV", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            //reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Psycho.rdlc";
            ////ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Psycho_Evaluation"));
            ////ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Psycho_Evaluation"));
            ////ReportParameter p3 = new ReportParameter("Age", age);
            ////reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
            //ReportviewerSetting();   

            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Psycho.rdlc";
            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Psycho_Evaluation"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Psycho_Evaluation"));
            ReportParameter a = new ReportParameter("PatientName", PatientName);
            ReportParameter b = new ReportParameter("ReferedBy", ReferredBy);
            ReportParameter c = new ReportParameter("Date", resultDate);
            ReportParameter d = new ReportParameter("Position", Position);
            ReportParameter e = new ReportParameter("IQ_TEST", IQ_TEST);
            ReportParameter f = new ReportParameter("Personal_TEST", Personal_TEST);
            ReportParameter g = new ReportParameter("Other_test", Other_test);
            ReportParameter h = new ReportParameter("Interlectual_level", Interlectual_level);
            ReportParameter i = new ReportParameter("Perseverance", Perseverance);
            ReportParameter j = new ReportParameter("Obedienc", Obedienc);
            ReportParameter k = new ReportParameter("Discipline", Discipline);
            ReportParameter l = new ReportParameter("Enthusiasm", Enthusiasm);
            ReportParameter m = new ReportParameter("boredom", boredom);
            ReportParameter n = new ReportParameter("Tolerance", Tolerance);
            ReportParameter o = new ReportParameter("Reality", Reality);
            ReportParameter p = new ReportParameter("Confidence", Confidence);
            ReportParameter q = new ReportParameter("Conclusion", Conclusion);
            ReportParameter r = new ReportParameter("Relaxed", Relaxed);
            ReportParameter s = new ReportParameter("mindedness", mindedness);
            ReportParameter t = new ReportParameter("Adaptability", Adaptability);
            ReportParameter u = new ReportParameter("Practicality", Practicality);
            ReportParameter v = new ReportParameter("Assertiveness", Assertiveness);
            ReportParameter w = new ReportParameter("Independence", Independence);
            ReportParameter x = new ReportParameter("Resourcefulness", Resourcefulness);
            ReportParameter y = new ReportParameter("Relationship", Relationship);
            ReportParameter z = new ReportParameter("Superiors", Superiors);
            ReportParameter aa = new ReportParameter("esteem", esteem);
            ReportParameter bb = new ReportParameter("Aggressive", Aggressive);
            ReportParameter cc = new ReportParameter("Direct", Direct);
            ReportParameter dd = new ReportParameter("med_1", med_1);
            ReportParameter ee = new ReportParameter("Lic_1", Lic_1);
            ReportParameter ff = new ReportParameter("Validity_1", Validity_1);
            ReportParameter gg = new ReportParameter("ptr_1", ptr_1);
            ReportParameter hh = new ReportParameter("Med_2", Med_2);
            ReportParameter ii = new ReportParameter("Validity_2", Validity_2);
            ReportParameter jj = new ReportParameter("ptr_2", ptr_2);
            ReportParameter kk = new ReportParameter("Lic_2", Lic_2);
            ReportParameter ll = new ReportParameter("Initiative", Initiative);
            ReportParameter mm = new ReportParameter("Conclusion_text1", Conclusion_text1);
            ReportParameter nn = new ReportParameter("Conclusion_text2", Conclusion_text2);


            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk, ll, mm, nn });
            ReportviewerSetting();





        }


        void ReportviewerSetting()
        {
            this.reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

        }

        void Load_HIV_Report()
        {


            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_HIV.rdlc";
            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "HIV"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "HIV"));
            ReportParameter a = new ReportParameter("Age", age);
            ReportParameter b = new ReportParameter("ImagePath", imgpath);
            ReportParameter c = new ReportParameter("PatientName", PatientName);
            ReportParameter d = new ReportParameter("ExaminingPhysician", ExaminigPhysycian);
            ReportParameter e = new ReportParameter("ExaminingPhysician_Lic", ExaminigPhysycian_lic);
            ReportParameter f = new ReportParameter("ResultDate", resultDate);
            ReportParameter g = new ReportParameter("Address", Address);
            ReportParameter h = new ReportParameter("Sex", Sex);
            ReportParameter i = new ReportParameter("CivilStatus", CivilStatus);
            ReportParameter j = new ReportParameter("Medtech", Medtech);
            ReportParameter k = new ReportParameter("Medtech_lic", MedTech_lic);
            ReportParameter l = new ReportParameter("ExpiryDate", ExpiryDate);
            ReportParameter m = new ReportParameter("Pathologist", Pathologist);
            ReportParameter n = new ReportParameter("rapid", rapid);
            ReportParameter o = new ReportParameter("Particle", Particle);
            ReportParameter p = new ReportParameter("EIA", EIA);
            ReportParameter q = new ReportParameter("other", other);
            ReportParameter r = new ReportParameter("Nonrecative", Nonrecative);
            ReportParameter s = new ReportParameter("Reactive", Reactive);
            ReportParameter t = new ReportParameter("Result", result);
            ReportParameter u = new ReportParameter("ShowImage", ShowImage);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t,u });
            ReportviewerSetting();
        }

        void Load_XRAY_Report()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_XRAY", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_XRAY.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "XRAY"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "XRAY"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);

            ReportParameter a = new ReportParameter("PatientName", PatientName);
            ReportParameter b = new ReportParameter("ResultDate", ResultDate_XRAY);
            ReportParameter c = new ReportParameter("Sex", Sex);
            ReportParameter d = new ReportParameter("Position", Position);
            ReportParameter e = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter f = new ReportParameter("Findings", Findings);
            ReportParameter g = new ReportParameter("Impression", Impression);
            ReportParameter h = new ReportParameter("Radiologist", Radiologist);
            ReportParameter i = new ReportParameter("Radiologist_Lic", Radiologist_Lic);


            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i });

            ReportviewerSetting();
        }


        void Load_Utrasound_Report()
        {


            

            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_XRAY", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Ultrasound.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "XRAY"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "XRAY"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);
            ReportParameter a = new ReportParameter("PatientName", PatientName);
            ReportParameter b = new ReportParameter("ResultDate", ResultDate_UTZ);
            ReportParameter c = new ReportParameter("Sex", Sex);
            ReportParameter d = new ReportParameter("Position", Position);
            ReportParameter e = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter f = new ReportParameter("Findings", Findings);
            ReportParameter g = new ReportParameter("Impression", Impression);
            ReportParameter h = new ReportParameter("Radiologist", Radiologist);
            ReportParameter i = new ReportParameter("Radiologist_Lic", Radiologist_Lic);
         
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i });
           
            ReportviewerSetting();
        }

        void Load_SEABASE_MLC_Report()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_Seabase_MLC", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            //reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Seabase_MLC.rdlc";
            //ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Seafarer_MLC"));
            //ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Seafarer_MLC"));
            //ReportParameter p3 = new ReportParameter("Age", age);
            //ReportParameter p4 = new ReportParameter("ISO", ini.IniReadValue("ISO", "Seafarer_MLC"));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1,p2,p3,p4 });
            //ReportviewerSetting();
            Cursor.Current = Cursors.WaitCursor;
            Report_SeaBase_Print f = new Report_SeaBase_Print();
            Report_SeaBase_Print.MLC1 = true;
            f.MedCertNumber = "";
            f.Tag = "00";
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        void Load_Land_Report()
        {
            //MessageBox.Show("HERE");
            DataTable dt = ClassSql.GetData_Data_proc("RDLC_Land_MLC", this.Tag.ToString());
            ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Land_MLC.rdlc";
            //reportViewer1.LocalReport.ReportPath = @"C:\Users\Mark\Documents\Dev_Projects\Centerport_RDLC_version\Centerport\Centerport\RDLC\Report_Land_MLC.rdlc";
            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Landbase_MLC"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Landbase_MLC"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);
            ReportParameter p4 = new ReportParameter("ISO", ini.IniReadValue("ISO", "Landbase_MLC"));

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            ReportviewerSetting();

        }


        void Load_Fecalysis_Report()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_Fecalysis", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Fecalysis.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Lab_Fecalysis"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Lab_Fecalysis"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);

            ReportParameter a = new ReportParameter("PatientName", PatientName);
            ReportParameter b = new ReportParameter("Sex", Sex);
            ReportParameter c = new ReportParameter("ResultDate", ResultDate_Fecal);
            ReportParameter d = new ReportParameter("Address", Address);
            ReportParameter e = new ReportParameter("Position", Position);
            ReportParameter f = new ReportParameter("ReferredBy", ReferredBy);

            ReportParameter g = new ReportParameter("Color", Color);
            ReportParameter h = new ReportParameter("WHITeBLOODCELLS", WHITeBLOODCELLS);
            ReportParameter i = new ReportParameter("Mucus", Mucus);
            ReportParameter j = new ReportParameter("OVAORPARASITE", OVAORPARASITE);
            ReportParameter k = new ReportParameter("AMOEBA", AMOEBA);
            ReportParameter l = new ReportParameter("OCCULTBLOODTEST", OCCULTBLOODTEST);
            ReportParameter m = new ReportParameter("Others", Others_fecal);
            ReportParameter n = new ReportParameter("Medtech", Medtech);
            ReportParameter o = new ReportParameter("Medtech_Lic", MedTech_lic);
            ReportParameter p = new ReportParameter("Pathologist", Pathologist);
            ReportParameter q = new ReportParameter("Pathologist_Lic", Pathologist_Lic);
            ReportParameter r = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter s = new ReportParameter("RedBlood", RedBlood);
            ReportParameter t = new ReportParameter("Color_other", Color_other);
            ReportParameter u = new ReportParameter("CONSISTENCY", CONSISTENCY);
            ReportParameter v = new ReportParameter("ShowImage", ShowImage);          

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u,v });

            ReportviewerSetting();
        }

        void Load_Urinalysis()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_Urinalysis", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Urinalysis.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Lab_Urinalysis"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Lab_Urinalysis"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);
            ReportParameter a = new ReportParameter("PatientName", PatientName);
            ReportParameter b = new ReportParameter("Sex", Sex);
            ReportParameter c = new ReportParameter("resultdate_Urinalysis", resultdate_Urinalysis);
            ReportParameter d = new ReportParameter("Address", Address);
            ReportParameter e = new ReportParameter("RequestedBy", ReferredBy);

            ReportParameter f = new ReportParameter("COLOR", COLOR_Urnialysis);
            ReportParameter g = new ReportParameter("Transparency", Transparency);
            ReportParameter h = new ReportParameter("Leucocytes", Leucocytes);
            ReportParameter i = new ReportParameter("Nitrite", Nitrite);
            ReportParameter j = new ReportParameter("Urobilinogen", Urobilinogen);
            ReportParameter k = new ReportParameter("Protein", Protein);
            ReportParameter l = new ReportParameter("pH", pH);
            ReportParameter m = new ReportParameter("Blood", Blood);
            ReportParameter n = new ReportParameter("SpecificGravity", SpecificGravity);
            ReportParameter o = new ReportParameter("Ketone", Ketone);
            ReportParameter p = new ReportParameter("Bilirubin", Bilirubin);
            ReportParameter q = new ReportParameter("Glucose", Glucose);
            ReportParameter r = new ReportParameter("RedBloodCells_Urinalysis", RedBloodCells_Urinalysis);
            ReportParameter s = new ReportParameter("WhiteBloodCells_Urinalysis", WhiteBloodCells_Urinalysis);
            ReportParameter t = new ReportParameter("Amorphous_Urates", Amorphous_Urates);
            ReportParameter u = new ReportParameter("Phosphate", Phosphate);
            ReportParameter v = new ReportParameter("EpithelialCells", EpithelialCells);
            ReportParameter w = new ReportParameter("MucusThread", MucusThread);
            ReportParameter x = new ReportParameter("others_Microscopic", others_Microscopic);
            ReportParameter y = new ReportParameter("UricAcid_Urinalysis", UricAcid_Urinalysis);
            ReportParameter z = new ReportParameter("CalciumOxalate", CalciumOxalate);
            ReportParameter aa = new ReportParameter("Others_Crystal", Others_Crystal);
            ReportParameter bb = new ReportParameter("FineGranularCast", FineGranularCast);
            ReportParameter cc = new ReportParameter("CoarseGranularCast", CoarseGranularCast);
            ReportParameter dd = new ReportParameter("Others_Cast", Others_Cast);
            ReportParameter ee = new ReportParameter("Medtech", Medtech);
            ReportParameter ff = new ReportParameter("Medtech_Lic", MedTech_lic);
            ReportParameter gg = new ReportParameter("Patho", Pathologist);
            ReportParameter hh = new ReportParameter("Patho_Lic", Pathologist_Lic);
            ReportParameter ii = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter jj = new ReportParameter("Color_remark", Color_remark);
            ReportParameter kk = new ReportParameter("Position", Position);
            ReportParameter ll = new ReportParameter("other_chem", other_chem);
            ReportParameter nn = new ReportParameter("ShowImage", ShowImage);



            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk,ll,nn });

            ReportviewerSetting();
        }


        void Load_Chemistry()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_Chemistry", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Chemistry.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Lab_Chemistry"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Lab_Chemistry"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);
            ReportParameter a = new ReportParameter("fbs", ini.IniReadValue("NormalValue", "fbs") + " mmol/L");
            ReportParameter b = new ReportParameter("bun", ini.IniReadValue("NormalValue", "bun") + " mmol/L");
            ReportParameter c = new ReportParameter("creatine", ini.IniReadValue("NormalValue", "creatine") + " mmol/L");
            ReportParameter d = new ReportParameter("choles", ini.IniReadValue("NormalValue", "choles") + " mmol/L");
            ReportParameter e = new ReportParameter("trigly", ini.IniReadValue("NormalValue", "trigly") + " mmol/L");
            ReportParameter f = new ReportParameter("uric", ini.IniReadValue("NormalValue", "uric") + " mmol/L");
            ReportParameter g = new ReportParameter("sgot", ini.IniReadValue("NormalValue", "sgot") + " IU/L");
            ReportParameter h = new ReportParameter("sgpt", ini.IniReadValue("NormalValue", "sgpt") + " IU/L");
            ReportParameter i = new ReportParameter("alk", ini.IniReadValue("NormalValue", "alk") + " IU/L");
            ReportParameter j = new ReportParameter("fbs_con", ini.IniReadValue("NormalValue", "fbs_con") + " mg/dL");
            ReportParameter k = new ReportParameter("bun_con", ini.IniReadValue("NormalValue", "bun_con") + " mg/dL");
            ReportParameter l = new ReportParameter("creatine_Con", ini.IniReadValue("NormalValue", "creatine_Con") + " mg/dL");
            ReportParameter m = new ReportParameter("Cholesterol_Con", ini.IniReadValue("NormalValue", "Cholesterol_Con") + " mg/dL");
            ReportParameter n = new ReportParameter("Trig_Con", ini.IniReadValue("NormalValue", "Trig_Con") + " mg/dL");
            ReportParameter o = new ReportParameter("Uric_Con", ini.IniReadValue("NormalValue", "Uric_Con") + " mg/dL");
            ReportParameter p = new ReportParameter("sgpt_con", ini.IniReadValue("NormalValue", "sgpt_con"));
            ReportParameter q = new ReportParameter("sgot_con", ini.IniReadValue("NormalValue", "sgot_con"));
            ReportParameter r = new ReportParameter("alk_con", ini.IniReadValue("NormalValue", "alk_con"));

            ReportParameter aa = new ReportParameter("PatientName", PatientName);
            ReportParameter bb = new ReportParameter("Patient_Age", age);
            ReportParameter cc = new ReportParameter("Sex", Sex);
            ReportParameter dd = new ReportParameter("ResultDate", resultDate);
            ReportParameter ee = new ReportParameter("Address", Address);
            ReportParameter ff = new ReportParameter("RefferedBy", ReferredBy);
            ReportParameter gg = new ReportParameter("Position", Position);

            ReportParameter hh = new ReportParameter("FBS_", FBS_);
            ReportParameter ii = new ReportParameter("BUN_", BUN_);
            ReportParameter jj = new ReportParameter("CREATINE_", CREATINE_);
            ReportParameter kk = new ReportParameter("CHOLESTEROL_", CHOLESTEROL_);
            ReportParameter ll = new ReportParameter("TRIGLYCERIDES_", TRIGLYCERIDES_);
            ReportParameter mm = new ReportParameter("URICACID_", URICACID_);
            ReportParameter nn = new ReportParameter("SGOT_", SGOT_);
            ReportParameter oo = new ReportParameter("SGPT_", SGPT_);
            ReportParameter pp = new ReportParameter("ALKPHOS_", ALKPHOS_);
            ReportParameter qq = new ReportParameter("Medtech", Medtech);
            ReportParameter rr = new ReportParameter("Medtech_Lic", MedTech_lic);
            ReportParameter ss = new ReportParameter("Pathologist", Pathologist);
            ReportParameter tt = new ReportParameter("Pathologist_Lic", Pathologist_Lic);
            ReportParameter uu = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter vv = new ReportParameter("FBS_H", FBS_H);
            ReportParameter ww = new ReportParameter("BUN_H", BUN_H);
            ReportParameter xx = new ReportParameter("CREATINE_H", CREATINE_H);
            ReportParameter yy = new ReportParameter("CHOLESTEROL_H", CHOLESTEROL_H);
            ReportParameter zz = new ReportParameter("TRIGLYCERIDES_H", TRIGLYCERIDES_H);
            ReportParameter aaa = new ReportParameter("URICACID_H", URICACID_H);
            ReportParameter bbb = new ReportParameter("SGOT_H", SGOT_H);
            ReportParameter ccc = new ReportParameter("SGPT_H", SGPT_H);
            ReportParameter ddd = new ReportParameter("ALKPHOS_H", ALKPHOS_H);
            ReportParameter eee = new ReportParameter("FBS_CON_", FBS_CON_);
            ReportParameter fff = new ReportParameter("BUN_CON_", BUN_CON_);
            ReportParameter ggg = new ReportParameter("CREATINE_CON_", CREATINE_CON_);
            ReportParameter hhh = new ReportParameter("CHOLESTEROL_CON_", CHOLESTEROL_CON_);
            ReportParameter iii = new ReportParameter("TRIGLYCERIDES_CON_", TRIGLYCERIDES_CON_);
            ReportParameter jjj = new ReportParameter("URICACID_CON_", URICACID_CON_);
            ReportParameter kkk = new ReportParameter("SGOT_CON_", SGOT_CON_);
            ReportParameter lll = new ReportParameter("SGPT_CON_", SGPT_CON_);
            ReportParameter mmm = new ReportParameter("ALKPHOS_CON_", ALKPHOS_CON_);
            ReportParameter mmmm = new ReportParameter("Remark_Chem", Remark_Chem);

            ReportParameter aaaaaa = new ReportParameter("HDL", hdl);
            ReportParameter bbbbbb = new ReportParameter("LDL", ldl);
            ReportParameter cccccc = new ReportParameter("ACIDPHOS", acidPhos);
            ReportParameter dddddd = new ReportParameter("BILIRUBN", totalbilirubin);
            ReportParameter eeeeee = new ReportParameter("b1", b1);
            ReportParameter ffffff = new ReportParameter("b2", b2);
            ReportParameter gggggg = new ReportParameter("Protein", totalpro);
            ReportParameter hhhhhh = new ReportParameter("Albumin", albumin);
            ReportParameter iiiiii = new ReportParameter("Globulin", globulin);
            ReportParameter jjjjjj = new ReportParameter("Ratio", agration);
            ReportParameter kkkkkk = new ReportParameter("Others_bottom", other_more_chem);
            ReportParameter llllll = new ReportParameter("HDL_Con", hdl_con);
            ReportParameter mmmmmm = new ReportParameter("LDL_Con", ldl_con);
            ReportParameter nnnnnn = new ReportParameter("ACIDPHOS_Con", acidPhos_con);
            ReportParameter oooooo = new ReportParameter("BILIRUBN_Con", totalbilirubin_con);
            ReportParameter pppppp = new ReportParameter("b1_Con", b1_con);
            ReportParameter qqqqqq = new ReportParameter("b2_Con", b2_con);
            ReportParameter rrrrrr = new ReportParameter("Protein_Con", totalpro_con);
            ReportParameter ssssss = new ReportParameter("Albumin_Con", albumin_con);
            ReportParameter tttttt = new ReportParameter("Globulin_Con", globulin_con);
            ReportParameter uuuuuu = new ReportParameter("Ratio_Con", agration_con);
            ReportParameter vvvvvv = new ReportParameter("Others_bottom_Con", other_con);
            ReportParameter wwwwww = new ReportParameter("hdl_H", hdl_H);
            ReportParameter xxxxxx = new ReportParameter("ldl_H", ldl_H);
            ReportParameter yyyyyy = new ReportParameter("acidPhos_H", acidPhos_H);
            ReportParameter zzzzzz = new ReportParameter("totalbilirubin_H", totalbilirubin_H);
            ReportParameter aaaaaaa = new ReportParameter("b1_H", b1_H);
            ReportParameter bbbbbbb = new ReportParameter("b2_H", b2_H);
            ReportParameter ccccccc = new ReportParameter("totalpro_H", totalpro_H);
            ReportParameter ddddddd = new ReportParameter("albumin_H", albumin_H);
            ReportParameter eeeeeee = new ReportParameter("globulin_H", globulin_H);
            ReportParameter fffffff = new ReportParameter("agration_H", agration_H);
            ReportParameter ggggggg = new ReportParameter("other_H", other_H);
            ReportParameter hhhhhhh = new ReportParameter("ShowImage", ShowImage);


            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk, ll, mm, nn, oo, pp, qq, rr, ss, tt, uu, vv, ww, xx, yy, zz, aaa, bbb, ccc, ddd, eee, fff, ggg, hhh, iii, jjj, kkk, lll, mmm, mmmm, aaaaaa, bbbbbb, cccccc, dddddd, eeeeee, ffffff, gggggg, hhhhhh, iiiiii, jjjjjj, kkkkkk, llllll, mmmmmm, nnnnnn, oooooo, pppppp, qqqqqq, rrrrrr, ssssss, tttttt, uuuuuu, vvvvvv, wwwwww, xxxxxx, yyyyyy, zzzzzz, aaaaaaa, bbbbbbb, ccccccc, ddddddd, eeeeeee, fffffff, ggggggg, hhhhhhh });

            ReportviewerSetting();
        }

        void Load_HEMA()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_HEMA", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);
            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Hema.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Lab_Hema"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Lab_Hema"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);
            ReportParameter a = new ReportParameter("hemoglobin", ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl");
            ReportParameter b = new ReportParameter("hematocrit", ini.IniReadValue("NormalValue", "hematocrit") + "vol%");
            ReportParameter c = new ReportParameter("rbc", ini.IniReadValue("NormalValue", "RBC") + " m/cumm");
            ReportParameter d = new ReportParameter("wbc", ini.IniReadValue("NormalValue", "WBC") + " /cumm");
            ReportParameter e = new ReportParameter("platelet", ini.IniReadValue("NormalValue", "Platelet") + "/cumm");
            ReportParameter f = new ReportParameter("bloodtype", ini.IniReadValue("NormalValue", "BloodType"));
            ReportParameter g = new ReportParameter("lympho", ini.IniReadValue("NormalValue", "Lympho") + "%");
            ReportParameter h = new ReportParameter("segmenters", ini.IniReadValue("NormalValue", "Segmenters") + "%");
            ReportParameter i = new ReportParameter("easinophils", ini.IniReadValue("NormalValue", "Easinophils") + "%");
            ReportParameter j = new ReportParameter("monocytes", ini.IniReadValue("NormalValue", "MonoCytes") + "%");
            ReportParameter k = new ReportParameter("myelocytes", ini.IniReadValue("NormalValue", "Myelocytes"));
            ReportParameter l = new ReportParameter("juviniles", ini.IniReadValue("NormalValue", "Juveniles"));
            ReportParameter m = new ReportParameter("stabcells", ini.IniReadValue("NormalValue", "StabCells") + "%");
            ReportParameter n = new ReportParameter("basophiles", ini.IniReadValue("NormalValue", "BasoPhils") + "%");
            ReportParameter o = new ReportParameter("hema_others", ini.IniReadValue("NormalValue", "Hema_Other"));
            ReportParameter p = new ReportParameter("esr", ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(FEMALE)");


            ReportParameter aa = new ReportParameter("PatientName", PatientName);
            ReportParameter bb = new ReportParameter("Address", Address);
            ReportParameter cc = new ReportParameter("Age", age);
            ReportParameter dd = new ReportParameter("Sex", Sex);
            ReportParameter ee = new ReportParameter("ResultDate", resultDate);
            ReportParameter ff = new ReportParameter("Position", Position);
            ReportParameter gg = new ReportParameter("ReferredBy", ReferredBy);
            ReportParameter hh = new ReportParameter("Hemoglobin_", Hemoglobin_);
            ReportParameter ii = new ReportParameter("Hematocrit_", Hematocrit_);
            ReportParameter jj = new ReportParameter("RBCcount_", RBCcount_);
            ReportParameter kk = new ReportParameter("Platelet_", Platelet_);
            ReportParameter ll = new ReportParameter("BloodType_", BloodType_);
            ReportParameter mm = new ReportParameter("Lymphocyte_", Lymphocyte_);
            ReportParameter nn = new ReportParameter("Segmenters_", Segmenters_);
            ReportParameter oo = new ReportParameter("easinophils_", easinophils_);
            ReportParameter pp = new ReportParameter("Monoytes_", Monoytes_);
            ReportParameter qq = new ReportParameter("myelocytes_", myelocytes_);
            ReportParameter rr = new ReportParameter("Juveniles_", Juveniles_);
            ReportParameter ss = new ReportParameter("stabCells_", stabCells_);
            ReportParameter tt = new ReportParameter("Basophils_", Basophils_);
            ReportParameter uu = new ReportParameter("Others_", Others_);
            ReportParameter vv = new ReportParameter("Medtech", Medtech);
            ReportParameter ww = new ReportParameter("Medtech_Lic", MedTech_lic);
            ReportParameter xx = new ReportParameter("Pathologist", Pathologist);
            ReportParameter yy = new ReportParameter("Pathologist_Lic", Pathologist_Lic);
            ReportParameter zz = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter zzz = new ReportParameter("WBC_para", WBC_);
            ReportParameter aaaa = new ReportParameter("ShowImage", ShowImage);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, zzz, kk, ll, mm, nn, oo, pp, qq, rr, ss, tt, uu, vv, ww, xx, yy, zz,aaaa });

            ReportviewerSetting();
        }


        void Load_LAB08()
        {
            //DataTable dt = ClassSql.GetData_Data_proc("RDLC_LAB_08", this.Tag.ToString());
            //ReportDataSource ds = new ReportDataSource("DataSet1", dt);

            //reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Lab_08.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Lab_08"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Lab_08"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            ReportParameter a = new ReportParameter("fbs", ini.IniReadValue("NormalValue", "fbs") + " mmol/L");
            ReportParameter b = new ReportParameter("bun", ini.IniReadValue("NormalValue", "bun") + " mmol/L");
            ReportParameter c = new ReportParameter("creatine", ini.IniReadValue("NormalValue", "creatine") + " mmol/L");
            ReportParameter d = new ReportParameter("choles", ini.IniReadValue("NormalValue", "choles") + " mmol/L");
            ReportParameter e = new ReportParameter("trigly", ini.IniReadValue("NormalValue", "trigly") + " mmol/L");
            ReportParameter f = new ReportParameter("uric", ini.IniReadValue("NormalValue", "uric") + " mmol/L");
            ReportParameter g = new ReportParameter("sgot", ini.IniReadValue("NormalValue", "sgot") + " IU/L");
            ReportParameter h = new ReportParameter("sgpt", ini.IniReadValue("NormalValue", "sgpt") + " IU/L");
            ReportParameter i = new ReportParameter("alk", ini.IniReadValue("NormalValue", "alk") + " IU/L");
            ReportParameter j = new ReportParameter("fbs_con", ini.IniReadValue("NormalValue", "fbs_con") + " mg/dL");
            ReportParameter k = new ReportParameter("bun_con", ini.IniReadValue("NormalValue", "bun_con") + " mg/dL");
            ReportParameter l = new ReportParameter("creatine_Con", ini.IniReadValue("NormalValue", "creatine_Con") + " mg/dL");
            ReportParameter m = new ReportParameter("Cholesterol_Con", ini.IniReadValue("NormalValue", "Cholesterol_Con") + " mg/dL");
            ReportParameter n = new ReportParameter("Trig_Con", ini.IniReadValue("NormalValue", "Trig_Con") + " mg/dL");
            ReportParameter o = new ReportParameter("Uric_Con", ini.IniReadValue("NormalValue", "Uric_Con") + " mg/dL");
            ReportParameter p = new ReportParameter("sgpt_con", ini.IniReadValue("NormalValue", "sgpt_con"));
            ReportParameter q = new ReportParameter("sgot_con", ini.IniReadValue("NormalValue", "sgot_con"));
            ReportParameter r = new ReportParameter("alk_con", ini.IniReadValue("NormalValue", "alk_con"));


            ReportParameter aa = new ReportParameter("hemoglobin", ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl");
            ReportParameter bb = new ReportParameter("hematocrit", ini.IniReadValue("NormalValue", "hematocrit") + "vol%");
            ReportParameter cc = new ReportParameter("rbc", ini.IniReadValue("NormalValue", "RBC") + " m/cumm");
            ReportParameter dd = new ReportParameter("wbc", ini.IniReadValue("NormalValue", "WBC") + " /cumm");
            ReportParameter ee = new ReportParameter("platelet", ini.IniReadValue("NormalValue", "Platelet") + "/cumm");
            ReportParameter ff = new ReportParameter("bloodtype", ini.IniReadValue("NormalValue", "BloodType"));
            ReportParameter gg = new ReportParameter("lympho", ini.IniReadValue("NormalValue", "Lympho") + "%");
            ReportParameter hh = new ReportParameter("segmenters", ini.IniReadValue("NormalValue", "Segmenters") + "%");
            ReportParameter ii = new ReportParameter("easinophils", ini.IniReadValue("NormalValue", "Easinophils") + "%");
            ReportParameter jj = new ReportParameter("monocytes", ini.IniReadValue("NormalValue", "MonoCytes") + "%");
            ReportParameter kk = new ReportParameter("myelocytes", ini.IniReadValue("NormalValue", "Myelocytes"));
            ReportParameter ll = new ReportParameter("juviniles", ini.IniReadValue("NormalValue", "Juveniles"));
            ReportParameter mm = new ReportParameter("stabcells", ini.IniReadValue("NormalValue", "StabCells") + "%");
            ReportParameter nn = new ReportParameter("basophiles", ini.IniReadValue("NormalValue", "BasoPhils") + "%");
            ReportParameter oo = new ReportParameter("hema_others", ini.IniReadValue("NormalValue", "Hema_Other"));
            ReportParameter pp = new ReportParameter("esr", ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(FEMALE)");




            ReportParameter aaaaaa = new ReportParameter("PatientName", PatientName);
            ReportParameter bbbbbb = new ReportParameter("Address", Address);
            ReportParameter cccccc = new ReportParameter("Patient_Age", age);
            ReportParameter dddddd = new ReportParameter("Sex", Sex);
            ReportParameter eeeeee = new ReportParameter("ResultDate", resultDate);
            ReportParameter ffffff = new ReportParameter("Position", Position);
            ReportParameter gggggg = new ReportParameter("Hemoglobin_", Hemoglobin_);
            ReportParameter hhhhhh = new ReportParameter("Hematocrit_", Hematocrit_);
            ReportParameter iiiiii = new ReportParameter("RBCcount_", RBCcount_);
            ReportParameter jjjjjj = new ReportParameter("Platelet_", Platelet_);
            ReportParameter kkkkkk = new ReportParameter("BloodType_", BloodType_);
            ReportParameter llllll = new ReportParameter("Lymphocyte_", Lymphocyte_);
            ReportParameter mmmmmm = new ReportParameter("Segmenters_", Segmenters_);
            ReportParameter nnnnnn = new ReportParameter("easinophils_", easinophils_);
            ReportParameter oooooo = new ReportParameter("Monoytes_", Monoytes_);
            ReportParameter pppppp = new ReportParameter("myelocytes_", myelocytes_);
            ReportParameter qqqqqq = new ReportParameter("Juveniles_", Juveniles_);
            ReportParameter rrrrrr = new ReportParameter("stabCells_", stabCells_);
            ReportParameter s = new ReportParameter("Basophils_", Basophils_);
            ReportParameter t = new ReportParameter("Others_", Others_);
            ReportParameter u = new ReportParameter("Medtech", Medtech);
            ReportParameter v = new ReportParameter("Medtech_Lic", MedTech_lic);
            ReportParameter w = new ReportParameter("Pathologist", Pathologist);
            ReportParameter x = new ReportParameter("Pathologist_Lic", Pathologist_Lic);
            ReportParameter y = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter z = new ReportParameter("WBC_para", WBC_);
            ReportParameter aaa = new ReportParameter("COLOR", COLOR_Urnialysis);
            ReportParameter bbb = new ReportParameter("Transparency", Transparency);
            ReportParameter ccc = new ReportParameter("Leucocytes", Leucocytes);
            ReportParameter ddd = new ReportParameter("Nitrite", Nitrite);
            ReportParameter eee = new ReportParameter("Urobilinogen", Urobilinogen);
            ReportParameter fff = new ReportParameter("Protein", Protein);
            ReportParameter ggg = new ReportParameter("pH", pH);
            ReportParameter hhh = new ReportParameter("Blood", Blood);
            ReportParameter iii = new ReportParameter("SpecificGravity", SpecificGravity);
            ReportParameter jjj = new ReportParameter("Ketone", Ketone);
            ReportParameter kkk = new ReportParameter("Bilirubin", Bilirubin);
            ReportParameter lll = new ReportParameter("Glucose", Glucose);
            ReportParameter mmm = new ReportParameter("RedBloodCells_Urinalysis", RedBloodCells_Urinalysis);
            ReportParameter nnn = new ReportParameter("WhiteBloodCells_Urinalysis", WhiteBloodCells_Urinalysis);
            ReportParameter ooo = new ReportParameter("Amorphous_Urates", Amorphous_Urates);
            ReportParameter ppp = new ReportParameter("Phosphate", Phosphate);
            ReportParameter qqq = new ReportParameter("pithelialCells", EpithelialCells);
            ReportParameter rrr = new ReportParameter("MucusThread", MucusThread);
            ReportParameter sss = new ReportParameter("Others_Microscopic", others_Microscopic);
            ReportParameter ttt = new ReportParameter("UricAcid_Urinalysis", UricAcid_Urinalysis);
            ReportParameter uuu = new ReportParameter("CalciumOxalate", CalciumOxalate);
            ReportParameter vvv = new ReportParameter("Others_Crystal", Others_Crystal);
            ReportParameter www = new ReportParameter("FineGranularCast", FineGranularCast);
            ReportParameter xxx = new ReportParameter("CoarseGranularCast", CoarseGranularCast);
            ReportParameter yyy = new ReportParameter("Others_Cast", Others_Cast);
            ReportParameter zzz = new ReportParameter("Color_remark", Color_remark);


            ReportParameter aaaa = new ReportParameter("FBS_", FBS_);
            ReportParameter bbbb = new ReportParameter("BUN_", BUN_);
            ReportParameter cccc = new ReportParameter("CREATINE_", CREATINE_);
            ReportParameter dddd = new ReportParameter("CHOLESTEROL_", CHOLESTEROL_);
            ReportParameter eeee = new ReportParameter("TRIGLYCERIDES_", TRIGLYCERIDES_);
            ReportParameter ffff = new ReportParameter("URICACID_", URICACID_);
            ReportParameter gggg = new ReportParameter("SGOT_", SGOT_);
            ReportParameter hhhh = new ReportParameter("SGPT_", SGPT_);
            ReportParameter iiii = new ReportParameter("ALKPHOS_", ALKPHOS_);
            ReportParameter jjjj = new ReportParameter("FBS_H", FBS_H);
            ReportParameter kkkk = new ReportParameter("BUN_H", BUN_H);
            ReportParameter llll = new ReportParameter("CREATINE_H", CREATINE_H);
            ReportParameter mmmm = new ReportParameter("CHOLESTEROL_H", CHOLESTEROL_H);
            ReportParameter nnnn = new ReportParameter("TRIGLYCERIDES_H", TRIGLYCERIDES_H);
            ReportParameter oooo = new ReportParameter("URICACID_H", URICACID_H);
            ReportParameter pppp = new ReportParameter("SGOT_H", SGOT_H);
            ReportParameter qqqq = new ReportParameter("SGPT_H", SGPT_H);
            ReportParameter rrrr = new ReportParameter("ALKPHOS_H", ALKPHOS_H);
            ReportParameter ssss = new ReportParameter("FBS_CON_", FBS_CON_);
            ReportParameter tttt = new ReportParameter("BUN_CON_", BUN_CON_);
            ReportParameter uuuu = new ReportParameter("CREATINE_CON_", CREATINE_CON_);
            ReportParameter vvvv = new ReportParameter("CHOLESTEROL_CON_", CHOLESTEROL_CON_);
            ReportParameter wwww = new ReportParameter("TRIGLYCERIDES_CON_", TRIGLYCERIDES_CON_);
            ReportParameter xxxx = new ReportParameter("URICACID_CON_", URICACID_CON_);
            ReportParameter yyyy = new ReportParameter("SGOT_CON_", SGOT_CON_);
            ReportParameter zzzz = new ReportParameter("SGPT_CON_", SGPT_CON_);
            ReportParameter aaaaa = new ReportParameter("ALKPHOS_CON_", ALKPHOS_CON_);
            ReportParameter bbbbb = new ReportParameter("Remark_Chem", Remark_Chem);

            //ReportParameter ccccc    = new ReportParameter("Color",);
            //ReportParameter ddddd    = new ReportParameter("WHITeBLOODCELLS",);
            //ReportParameter eeeee    = new ReportParameter("Mucus",);
            //ReportParameter fffff    = new ReportParameter("OVAORPARASITE",);
            //ReportParameter ggggg    = new ReportParameter("AMOEBA",);
            //ReportParameter hhhhh    = new ReportParameter("OCCULTBLOODTEST",);
            //ReportParameter iiiii    = new ReportParameter("Others",);
            //ReportParameter jjjjj    = new ReportParameter("RedBlood",);
            //ReportParameter kkkkk    = new ReportParameter("Color_other",);
            ReportParameter lllll = new ReportParameter("HBsAG", BsAG);

            ReportParameter mmmmm = new ReportParameter("Employer", Employer);
            ReportParameter nnnnn = new ReportParameter("esr_", esr_);
            ReportParameter ooooo = new ReportParameter("RPR", rpr_);
            ReportParameter ppppp = new ReportParameter("Color_Fecal", Color);
            ReportParameter qqqqq = new ReportParameter("WHITeBLOODCELLS", WHITeBLOODCELLS);
            ReportParameter rrrrr = new ReportParameter("Mucus_fecal", Mucus);
            ReportParameter sssss = new ReportParameter("OVAORPARASITE", OVAORPARASITE);
            ReportParameter ttttt = new ReportParameter("AMOEBA", AMOEBA);
            ReportParameter uuuuu = new ReportParameter("OCCULTBLOODTEST", OCCULTBLOODTEST);
            ReportParameter vvvvv = new ReportParameter("Others_fecal", Others_fecal);
            ReportParameter wwwww = new ReportParameter("RedBlood", RedBlood);
            ReportParameter xxxxx = new ReportParameter("Color_other_Fecal", Color_other);
            ReportParameter yyyyy = new ReportParameter("CONSISTENCY", CONSISTENCY);
            ReportParameter zzzzz = new ReportParameter("other_chem", other_chem);
            ReportParameter aaaaaaa = new ReportParameter("ShowImage", ShowImage);




            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk, ll, mm, nn, oo, pp, aaaaaa, bbbbbb, cccccc, dddddd, eeeeee, ffffff, gggggg, hhhhhh, iiiiii, jjjjjj, kkkkkk, llllll, mmmmmm, nnnnnn, oooooo, pppppp, qqqqqq, rrrrrr, s, t, u, v, w, x, y, z, aaa, bbb, ccc, ddd, eee, fff, ggg, hhh, iii, jjj, kkk, lll, mmm, nnn, ooo, ppp, qqq, rrr, sss, ttt, uuu, vvv, www, xxx, yyy, zzz, aaaa, bbbb, cccc, dddd, eeee, ffff, gggg, hhhh, iiii, jjjj, kkkk, llll, mmmm, nnnn, oooo, pppp, qqqq, rrrr, ssss, tttt, uuuu, vvvv, wwww, xxxx, yyyy, zzzz, aaaaa, bbbbb, lllll, mmmmm, nnnnn, ooooo, ppppp, qqqqq, rrrrr, sssss, ttttt, uuuuu, vvvvv, wwwww, xxxxx, yyyyy, zzzzz,aaaaaaa });



            ReportviewerSetting();
        }

        void Load_LAB06()
        {
            //    DataTable dt = ClassSql.GetData_Data_proc("RDLC_LAB_06", this.Tag.ToString());
            //    ReportDataSource ds = new ReportDataSource("DataSet1", dt);

            //    reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.ReportPath = AppPath.Replace("bin", "") + @"RDLC\Report_Lab06.rdlc";


            ReportParameter p1 = new ReportParameter("FormNo", ini.IniReadValue("FORM", "Lab_068"));
            ReportParameter p2 = new ReportParameter("Rev_No", ini.IniReadValue("REVISION", "Lab_06"));
            ReportParameter p3 = new ReportParameter("Patient_Age", age);



            ReportParameter aa = new ReportParameter("hemoglobin", ini.IniReadValue("NormalValue", "hemoglobin") + "gm/dl");
            ReportParameter bb = new ReportParameter("hematocrit", ini.IniReadValue("NormalValue", "hematocrit") + "vol%");
            ReportParameter cc = new ReportParameter("rbc", ini.IniReadValue("NormalValue", "RBC") + " m/cumm");
            ReportParameter dd = new ReportParameter("wbc", ini.IniReadValue("NormalValue", "WBC") + " /cumm");
            ReportParameter ee = new ReportParameter("platelet", ini.IniReadValue("NormalValue", "Platelet") + "/cumm");
            ReportParameter ff = new ReportParameter("bloodtype", ini.IniReadValue("NormalValue", "BloodType"));
            ReportParameter gg = new ReportParameter("lympho", ini.IniReadValue("NormalValue", "Lympho") + "%");
            ReportParameter hh = new ReportParameter("segmenters", ini.IniReadValue("NormalValue", "Segmenters") + "%");
            ReportParameter ii = new ReportParameter("easinophils", ini.IniReadValue("NormalValue", "Easinophils") + "%");
            ReportParameter jj = new ReportParameter("monocytes", ini.IniReadValue("NormalValue", "MonoCytes") + "%");
            ReportParameter kk = new ReportParameter("myelocytes", ini.IniReadValue("NormalValue", "Myelocytes"));
            ReportParameter ll = new ReportParameter("juviniles", ini.IniReadValue("NormalValue", "Juveniles"));
            ReportParameter mm = new ReportParameter("stabcells", ini.IniReadValue("NormalValue", "StabCells") + "%");
            ReportParameter nn = new ReportParameter("basophiles", ini.IniReadValue("NormalValue", "BasoPhils") + "%");
            ReportParameter oo = new ReportParameter("hema_others", ini.IniReadValue("NormalValue", "Hema_Other"));
            ReportParameter pp = new ReportParameter("esr", ini.IniReadValue("NormalValue", "ESR") + "mm/hr(MALE)/" + ini.IniReadValue("NormalValue", "textBox1") + "mm/hr(FEMALE)");







            ReportParameter a = new ReportParameter("PatientName", PatientName);
            ReportParameter b = new ReportParameter("Address", Address);
            ReportParameter c = new ReportParameter("Age", age);
            ReportParameter d = new ReportParameter("Sex", Sex);
            ReportParameter e = new ReportParameter("ResultDate", resultDate);
            ReportParameter f = new ReportParameter("Position", Position);
            ReportParameter g = new ReportParameter("ReferredBy", ReferredBy);
            ReportParameter h = new ReportParameter("Hemoglobin_", Hemoglobin_);
            ReportParameter i = new ReportParameter("Hematocrit_", Hematocrit_);
            ReportParameter j = new ReportParameter("RBCcount_", RBCcount_);
            ReportParameter k = new ReportParameter("Platelet_", Platelet_);
            ReportParameter l = new ReportParameter("BloodType_", BloodType_);
            ReportParameter m = new ReportParameter("Lymphocyte_", Lymphocyte_);
            ReportParameter n = new ReportParameter("Segmenters_", Segmenters_);
            ReportParameter o = new ReportParameter("easinophils_", easinophils_);
            ReportParameter p = new ReportParameter("Monoytes_", Monoytes_);
            ReportParameter q = new ReportParameter("myelocytes_", myelocytes_);
            ReportParameter r = new ReportParameter("Juveniles_", Juveniles_);
            ReportParameter s = new ReportParameter("stabCells_", stabCells_);
            ReportParameter t = new ReportParameter("Basophils_", Basophils_);
            ReportParameter u = new ReportParameter("Others_", Others_);
            ReportParameter v = new ReportParameter("Medtech", Medtech);
            ReportParameter w = new ReportParameter("Medtech_Lic", MedTech_lic);
            ReportParameter x = new ReportParameter("Pathologist", Pathologist);
            ReportParameter y = new ReportParameter("Pathologist_Lic", Pathologist_Lic);
            ReportParameter aaa = new ReportParameter("SpecimenNo", SpecimenNo);
            ReportParameter bbb = new ReportParameter("WBC_para", WBC_);
            ReportParameter ccc = new ReportParameter("esr_", esr_);
            ReportParameter ddd = new ReportParameter("Employer", Employer);
            ReportParameter eee = new ReportParameter("rpr_", rpr_);
            ReportParameter fff = new ReportParameter("BsAG", BsAG);
            ReportParameter ggg = new ReportParameter("WIDALTEST", WIDALTEST);
            ReportParameter hhh = new ReportParameter("MALARIAL", MALARIAL);
            ReportParameter iii = new ReportParameter("COLOR", COLOR_Urnialysis);
            ReportParameter jjj = new ReportParameter("Transparency", Transparency);
            ReportParameter kkk = new ReportParameter("Leucocytes", Leucocytes);
            ReportParameter lll = new ReportParameter("Nitrite", Nitrite);
            ReportParameter mmm = new ReportParameter("Urobilinogen", Urobilinogen);
            ReportParameter nnn = new ReportParameter("Protein", Protein);
            ReportParameter ooo = new ReportParameter("pH", pH);
            ReportParameter ppp = new ReportParameter("Blood", Blood);
            ReportParameter qqq = new ReportParameter("SpecificGravity", SpecificGravity);
            ReportParameter rrr = new ReportParameter("Ketone", Ketone);
            ReportParameter sss = new ReportParameter("Bilirubin", Bilirubin);
            ReportParameter ttt = new ReportParameter("Glucose", Glucose);
            ReportParameter uuu = new ReportParameter("RedBloodCells_Urinalysis", RedBloodCells_Urinalysis);
            ReportParameter vvv = new ReportParameter("WhiteBloodCells_Urinalysis", WhiteBloodCells_Urinalysis);
            ReportParameter www = new ReportParameter("Amorphous_Urates", Amorphous_Urates);
            ReportParameter xxx = new ReportParameter("Phosphate", Phosphate);
            ReportParameter yyy = new ReportParameter("EpithelialCells", EpithelialCells);
            ReportParameter zzz = new ReportParameter("MucusThread", MucusThread);
            ReportParameter aaaa = new ReportParameter("others_Microscopic", others_Microscopic);
            ReportParameter bbbb = new ReportParameter("UricAcid_Urinalysis", UricAcid_Urinalysis);
            ReportParameter cccc = new ReportParameter("CalciumOxalate", CalciumOxalate);
            ReportParameter dddd = new ReportParameter("Others_Crystal", Others_Crystal);
            ReportParameter eeee = new ReportParameter("FineGranularCast", FineGranularCast);
            ReportParameter ffff = new ReportParameter("CoarseGranularCast", CoarseGranularCast);
            ReportParameter gggg = new ReportParameter("Others_Cast", Others_Cast);
            ReportParameter hhhh = new ReportParameter("Color_remark", Color_remark);
            ReportParameter iiii = new ReportParameter("Color_Fecal", Color);
            ReportParameter jjjj = new ReportParameter("WHITeBLOODCELLS_Fecal", WHITeBLOODCELLS);
            ReportParameter kkkk = new ReportParameter("Mucus", Mucus);
            ReportParameter llll = new ReportParameter("OVAORPARASITE", OVAORPARASITE);
            ReportParameter mmmm = new ReportParameter("AMOEBA", AMOEBA);
            ReportParameter nnnn = new ReportParameter("OCCULTBLOODTEST", OCCULTBLOODTEST);
            ReportParameter ooooo = new ReportParameter("Others_Fecal", Others_fecal);
            ReportParameter pppp = new ReportParameter("RedBlood_Fecal", RedBlood);
            ReportParameter qqqq = new ReportParameter("Color_other_Fecal", Color_other);
            ReportParameter rrrr = new ReportParameter("CONSISTENCY", CONSISTENCY);
            ReportParameter ssss = new ReportParameter("other_chem", other_chem);
            ReportParameter tttt = new ReportParameter("ShowImage", ShowImage);


            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, aa, bb, cc, dd, ee, ff, gg, hh, ii, jj, kk, ll, mm, nn, oo, pp, a, b, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, aaa, bbb, ccc, ddd, eee, fff, ggg, hhh, iii, jjj, kkk, lll, mmm, nnn, ooo, ppp, qqq, rrr, sss, ttt, uuu, vvv, www, xxx, yyy, zzz, aaaa, bbbb, cccc, dddd, eeee, ffff, gggg, hhhh, iiii, jjjj, kkkk, llll, mmmm, nnnn, ooooo, pppp, qqqq, rrrr, ssss,tttt });

            ReportviewerSetting();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_printers printers = new frm_printers();
            printers.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }

        private void frm_RDLC_report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                reportViewer1.PrintDialog();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cmd_refresh_Click(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
