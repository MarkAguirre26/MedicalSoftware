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

    public partial class frm_LabPrintChoices : Form
    {
        public string resultid;
        public string ShowImage;
        public string Age;
        public string PatientName;
        public string Address;
        public string Sex;
        public string CivilStatus;
        public string Position;
        public string resultdateHema;

        public string ResultDate_lab06;
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
        public string Others_HEma;
        public string SpecimenNo;
        public string Medtech;
        public string MedTech_lic;
        public string Pathologist;
        public string Pathologist_Lic;



        public string ResultDate_Fecal;
        public string Color_fecal;
        public string WHITeBLOODCELLS;
        public string Mucus;
        public string OVAORPARASITE;
        public string AMOEBA;
        public string OCCULTBLOODTEST;
        public string color_Others_fecal;
        public string CONSISTENCY;
        public string RedBlood;
        public string other_fecal;

        public string resultdate_Urinalysis;
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

        public string resultdate_Chem;
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
        public string remark_chem;


        public string Employer;
        public string esr;
        public string rpr_;
        public string BsAG;
        public string WIDALTEST;
        public string MALARIAL;



        public frm_LabPrintChoices()
        {
            InitializeComponent();
        }

        private void frm_LabPrintChoices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.ShowImage = ShowImage;
                f.isFecalysis = true;
                f.Tag = resultid;
                f.age = Age;
                f.PatientName = PatientName;
                f.Sex = Sex;
                f.ResultDate_Fecal = ResultDate_Fecal;
                f.Address = Address;
                f.Position = Position;
                f.ReferredBy = ReferredBy;
                f.ShowImage = ShowImage;
                f.Color = Color_fecal;
                f.WHITeBLOODCELLS = WHITeBLOODCELLS;
                f.Mucus = "";
                f.OVAORPARASITE = OVAORPARASITE;
                f.AMOEBA = AMOEBA;
                f.OCCULTBLOODTEST = OCCULTBLOODTEST;
                f.Others_fecal = other_fecal;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.SpecimenNo = SpecimenNo;
                f.RedBlood = RedBlood;
                f.Color_other = color_Others_fecal;
                f.CONSISTENCY = CONSISTENCY;
                f.ShowDialog();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isUrinalysis = true;
                f.Tag = resultid;
                f.age = Age;
                f.PatientName = PatientName;
                f.Sex = Sex;
                f.ShowImage = ShowImage;
                f.resultdate_Urinalysis = resultdate_Urinalysis;
                f.Address = Address;
                f.RequestedBy = ReferredBy;
                f.Position = Position;

                f.COLOR_Urnialysis = COLOR_Urnialysis;
                f.Transparency = Transparency;
                f.Leucocytes = Leucocytes;
                f.Nitrite = Nitrite;
                f.Urobilinogen = Urobilinogen;
                f.Protein = Protein;
                f.pH = pH;
                f.Blood = Blood;
                f.SpecificGravity = SpecificGravity;
                f.Ketone = Ketone;
                f.Bilirubin = Bilirubin;
                f.Glucose = Glucose;
                f.other_chem = other_chem;
                f.RedBloodCells_Urinalysis = RedBloodCells_Urinalysis;
                f.WhiteBloodCells_Urinalysis = WhiteBloodCells_Urinalysis;
                f.Amorphous_Urates = Amorphous_Urates;
                f.Phosphate = Phosphate;
                f.EpithelialCells = EpithelialCells;
                f.MucusThread = MucusThread;
                f.others_Microscopic = others_Microscopic;
                f.UricAcid_Urinalysis = UricAcid_Urinalysis;
                f.CalciumOxalate = CalciumOxalate;
                f.Others_Crystal = Others_Crystal;
                f.FineGranularCast = FineGranularCast;
                f.CoarseGranularCast = CoarseGranularCast;
                f.Others_Cast = Others_Cast;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.SpecimenNo = SpecimenNo;
                f.Color_remark = Color_remark;
                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.isChemistry = true;
                f.Tag = resultid;
                f.age = Age;
                f.ShowImage = ShowImage;
                f.PatientName = PatientName;
                f.Sex = Sex;

                f.resultDate = resultdate_Chem;
                f.Address = Address;

                f.ReferredBy = ReferredBy;

                f.Position = Position;

                f.FBS_ = FBS_;
                f.BUN_ = BUN_;
                f.CREATINE_ = CREATINE_;
                f.CHOLESTEROL_ = CHOLESTEROL_;
                f.TRIGLYCERIDES_ = TRIGLYCERIDES_;
                f.URICACID_ = URICACID_;
                f.SGOT_ = SGOT_;
                f.SGPT_ = SGPT_;
                f.ALKPHOS_ = ALKPHOS_;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.SpecimenNo = SpecimenNo;
                if (FBS_H == "1") { f.FBS_H = "1"; } else { f.FBS_H = "0"; }
                if (BUN_H == "1") { f.BUN_H = "1"; } else { f.BUN_H = "0"; }
                if (CREATINE_H == "1") { f.CREATINE_H = "1"; } else { f.CREATINE_H = "0"; }
                if (CHOLESTEROL_H == "1") { f.CHOLESTEROL_H = "1"; } else { f.CHOLESTEROL_H = "0"; }
                if (TRIGLYCERIDES_H == "1") { f.TRIGLYCERIDES_H = "1"; } else { f.TRIGLYCERIDES_H = "0"; }
                if (URICACID_H == "1") { f.URICACID_H = "1"; } else { f.URICACID_H = "0"; }
                if (SGOT_H == "1") { f.SGOT_H = "1"; } else { f.SGOT_H = "0"; }
                if (SGPT_H == "1") { f.SGPT_H = "1"; } else { f.SGPT_H = "0"; }
                if (ALKPHOS_H == "1") { f.ALKPHOS_H = "1"; } else { f.ALKPHOS_H = "0"; }
                f.FBS_CON_ = FBS_CON_;
                f.BUN_CON_ = BUN_CON_;
                f.CREATINE_CON_ = CREATINE_CON_;
                f.CHOLESTEROL_CON_ = CHOLESTEROL_CON_;
                f.TRIGLYCERIDES_CON_ = TRIGLYCERIDES_CON_;
                f.URICACID_CON_ = URICACID_CON_;
                f.SGOT_CON_ = SGOT_CON_;
                f.SGPT_CON_ = SGPT_CON_;
                f.ALKPHOS_CON_ = ALKPHOS_CON_;
                f.Remark_Chem = remark_chem;
                f.ShowDialog();




            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                //f.isHEMA = true;
                //f.Tag = resultid;
                //f.age = Age;
                //f.PatientName = PatientName;
                //f.Sex = Sex;
                //f.Address = Address;
                //f.CivilStatus = CivilStatus;
                //f.age = Age;
                //f.Position = Position;
                //f.ShowDialog();
                f.ShowImage = ShowImage;
                f.isHEMA = true;
                f.Tag = resultid;
                f.age = Age;
                f.PatientName = PatientName;
                f.Address = Address;
                f.resultDate = resultdateHema;
                f.Sex = Sex;
                f.Position = Position;
                f.ReferredBy = ReferredBy;
                f.CivilStatus = CivilStatus;
                f.Hemoglobin_ = Hemoglobin_;
                f.Hematocrit_ = Hematocrit_;
                f.RBCcount_ = RBCcount_;
                f.WBC_ = WBC_;
                f.SpecimenNo = SpecimenNo;
                f.Platelet_ = Platelet_;
                f.BloodType_ = BloodType_;
                f.Lymphocyte_ = Lymphocyte_;
                f.Segmenters_ = Segmenters_;
                f.easinophils_ = easinophils_;
                f.Monoytes_ = Monoytes_;
                f.myelocytes_ = myelocytes_;
                f.Juveniles_ = Juveniles_;
                f.stabCells_ = stabCells_;
                f.Basophils_ = Basophils_;
                f.Others_ = Others_HEma;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.ShowImage = ShowImage;
                f.isLAB08 = true;
                f.Tag = resultid;
                f.age = Age;
                f.PatientName = PatientName;
                f.Address = Address;
                f.resultDate = ResultDate_lab06;
                f.Sex = Sex;
                f.Position = Position;
                f.ReferredBy = ReferredBy;
                f.CivilStatus = CivilStatus;
                f.Hemoglobin_ = Hemoglobin_;
                f.Hematocrit_ = Hematocrit_;
                f.RBCcount_ = RBCcount_;
                f.WBC_ = WBC_;
                f.esr_ = esr;
                f.SpecimenNo = SpecimenNo;
                f.Platelet_ = Platelet_;
                f.BloodType_ = BloodType_;
                f.Lymphocyte_ = Lymphocyte_;
                f.Segmenters_ = Segmenters_;
                f.easinophils_ = easinophils_;
                f.Monoytes_ = Monoytes_;
                f.myelocytes_ = myelocytes_;
                f.Juveniles_ = Juveniles_;
                f.stabCells_ = stabCells_;
                f.Basophils_ = Basophils_;
                f.Others_ = Others_HEma;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.Employer = Employer;

                f.rpr_ = rpr_;
                f.BsAG = BsAG;
                f.WIDALTEST = WIDALTEST;
                f.MALARIAL = MALARIAL;

                f.FBS_ = FBS_;
                f.BUN_ = BUN_;
                f.CREATINE_ = CREATINE_;
                f.CHOLESTEROL_ = CHOLESTEROL_;
                f.TRIGLYCERIDES_ = TRIGLYCERIDES_;
                f.URICACID_ = URICACID_;
                f.SGOT_ = SGOT_;
                f.SGPT_ = SGPT_;
                f.ALKPHOS_ = ALKPHOS_;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.SpecimenNo = SpecimenNo;
                if (FBS_H == "1") { f.FBS_H = "1"; } else { f.FBS_H = "0"; }
                if (BUN_H == "1") { f.BUN_H = "1"; } else { f.BUN_H = "0"; }
                if (CREATINE_H == "1") { f.CREATINE_H = "1"; } else { f.CREATINE_H = "0"; }
                if (CHOLESTEROL_H == "1") { f.CHOLESTEROL_H = "1"; } else { f.CHOLESTEROL_H = "0"; }
                if (TRIGLYCERIDES_H == "1") { f.TRIGLYCERIDES_H = "1"; } else { f.TRIGLYCERIDES_H = "0"; }
                if (URICACID_H == "1") { f.URICACID_H = "1"; } else { f.URICACID_H = "0"; }
                if (SGOT_H == "1") { f.SGOT_H = "1"; } else { f.SGOT_H = "0"; }
                if (SGPT_H == "1") { f.SGPT_H = "1"; } else { f.SGPT_H = "0"; }
                if (ALKPHOS_H == "1") { f.ALKPHOS_H = "1"; } else { f.ALKPHOS_H = "0"; }
                f.FBS_CON_ = FBS_CON_;
                f.BUN_CON_ = BUN_CON_;
                f.CREATINE_CON_ = CREATINE_CON_;
                f.CHOLESTEROL_CON_ = CHOLESTEROL_CON_;
                f.TRIGLYCERIDES_CON_ = TRIGLYCERIDES_CON_;
                f.URICACID_CON_ = URICACID_CON_;
                f.SGOT_CON_ = SGOT_CON_;
                f.SGPT_CON_ = SGPT_CON_;
                f.ALKPHOS_CON_ = ALKPHOS_CON_;
                f.Remark_Chem = remark_chem;

                f.COLOR_Urnialysis = COLOR_Urnialysis;
                f.Transparency = Transparency;
                f.Leucocytes = Leucocytes;
                f.Nitrite = Nitrite;
                f.Urobilinogen = Urobilinogen;
                f.Protein = Protein;
                f.pH = pH;
                f.Blood = Blood;
                f.SpecificGravity = SpecificGravity;
                f.Ketone = Ketone;
                f.Bilirubin = Bilirubin;
                f.Glucose = Glucose;
                f.RedBloodCells_Urinalysis = RedBloodCells_Urinalysis;
                f.WhiteBloodCells_Urinalysis = WhiteBloodCells_Urinalysis;
                f.Amorphous_Urates = Amorphous_Urates;
                f.Phosphate = Phosphate;
                f.EpithelialCells = EpithelialCells;
                f.MucusThread = MucusThread;
                f.others_Microscopic = others_Microscopic;
                f.UricAcid_Urinalysis = UricAcid_Urinalysis;
                f.CalciumOxalate = CalciumOxalate;
                f.Others_Crystal = Others_Crystal;
                f.FineGranularCast = FineGranularCast;
                f.CoarseGranularCast = CoarseGranularCast;
                f.Others_Cast = Others_Cast;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.SpecimenNo = SpecimenNo;
                f.Color_remark = Color_remark;
                f.Color = Color_fecal;
                f.WHITeBLOODCELLS = WHITeBLOODCELLS;
                f.Mucus = "";
                f.OVAORPARASITE = OVAORPARASITE;
                f.AMOEBA = AMOEBA;
                f.OCCULTBLOODTEST = OCCULTBLOODTEST;
                f.Others_fecal = other_fecal;
                f.RedBlood = RedBlood;
                f.Color_other = color_Others_fecal;
                f.CONSISTENCY = CONSISTENCY;
                f.other_chem = other_chem;


                f.ShowDialog();
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (RDLC.frm_RDLC_report f = new RDLC.frm_RDLC_report())
            {
                f.ShowImage = ShowImage;
                f.isLAB06 = true;
                f.Tag = resultid;
                f.age = Age;
                f.PatientName = PatientName;
                f.Address = Address;
                f.resultDate = ResultDate_lab06;
                f.Sex = Sex;
                f.Position = Position;
                f.ReferredBy = ReferredBy;
                f.CivilStatus = CivilStatus;
                f.Hemoglobin_ = Hemoglobin_;
                f.Hematocrit_ = Hematocrit_;
                f.RBCcount_ = RBCcount_;
                f.WBC_ = WBC_;
                f.SpecimenNo = SpecimenNo;
                f.Platelet_ = Platelet_;
                f.BloodType_ = BloodType_;
                f.Lymphocyte_ = Lymphocyte_;
                f.Segmenters_ = Segmenters_;
                f.easinophils_ = easinophils_;
                f.Monoytes_ = Monoytes_;
                f.myelocytes_ = myelocytes_;
                f.Juveniles_ = Juveniles_;
                f.stabCells_ = stabCells_;
                f.Basophils_ = Basophils_;
                f.Others_ = Others_HEma;
                f.Medtech = Medtech;
                f.MedTech_lic = MedTech_lic;
                f.Pathologist = Pathologist;
                f.Pathologist_Lic = Pathologist_Lic;
                f.Employer = Employer;

                f.esr_ = esr;
                f.rpr_ = rpr_;
                f.BsAG = BsAG;
                f.WIDALTEST = WIDALTEST;
                f.MALARIAL = MALARIAL;

                f.COLOR_Urnialysis = COLOR_Urnialysis;
                f.Transparency = Transparency;
                f.Leucocytes = Leucocytes;
                f.Nitrite = Nitrite;
                f.Urobilinogen = Urobilinogen;
                f.Protein = Protein;
                f.pH = pH;
                f.Blood = Blood;
                f.SpecificGravity = SpecificGravity;
                f.Ketone = Ketone;
                f.Bilirubin = Bilirubin;
                f.Glucose = Glucose;
                f.RedBloodCells_Urinalysis = RedBloodCells_Urinalysis;
                f.WhiteBloodCells_Urinalysis = WhiteBloodCells_Urinalysis;
                f.Amorphous_Urates = Amorphous_Urates;
                f.Phosphate = Phosphate;
                f.EpithelialCells = EpithelialCells;
                f.MucusThread = MucusThread;
                f.others_Microscopic = others_Microscopic;
                f.UricAcid_Urinalysis = UricAcid_Urinalysis;
                f.CalciumOxalate = CalciumOxalate;
                f.Others_Crystal = Others_Crystal;
                f.FineGranularCast = FineGranularCast;
                f.CoarseGranularCast = CoarseGranularCast;
                f.Others_Cast = Others_Cast;
                f.Color_remark = Color_remark;

                f.Color = Color_fecal;
                f.WHITeBLOODCELLS = WHITeBLOODCELLS;
                f.Mucus = "";
                f.OVAORPARASITE = OVAORPARASITE;
                f.AMOEBA = AMOEBA;
                f.OCCULTBLOODTEST = OCCULTBLOODTEST;
                f.Others_fecal = other_fecal;
                f.RedBlood = RedBlood;
                f.Color_other = color_Others_fecal;
                f.CONSISTENCY = CONSISTENCY;
                f.other_chem = other_chem;
                f.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Report.Report_Lab f = new Report.Report_Lab())
            {
                f.Tag = resultid;
                f.isLabo6 = true;
                f.ShowDialog();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Report.Report_Lab f = new Report.Report_Lab())
            {
                f.Tag = resultid;
                f.isHema = true;
                f.ShowDialog();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Report.Report_Lab f = new Report.Report_Lab())
            {
                f.Tag = resultid;
                f.isChem = true;
                f.ShowDialog();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Report.Report_Lab f = new Report.Report_Lab())
            {
                f.Tag = resultid;
                f.isUrine = true;
                f.ShowDialog();
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Report.Report_Lab f = new Report.Report_Lab())
            {
                f.Tag = resultid;
                f.isFecal = true;
                f.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_LabPrintChoices_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Report.Report_Lab f = new Report.Report_Lab())
            {
                f.Tag = resultid;
                f.isLabo8 = true;
                f.ShowDialog();
            }
        }
    }
}
