namespace Centerport
{
    partial class frm_HIV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_resultID = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dt_bday = new System.Windows.Forms.DateTimePicker();
            this.txt_gender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_position = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_agency = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_Papin = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pic_ = new System.Windows.Forms.PictureBox();
            this.lbl_medical_cn = new System.Windows.Forms.Label();
            this.lbl_HIV_Result_Cn = new System.Windows.Forms.Label();
            this.panelChoice = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.rb_result_NonReactive = new System.Windows.Forms.RadioButton();
            this.rb_result_Reactive = new System.Windows.Forms.RadioButton();
            this.txt_other_specify = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cb_eie = new System.Windows.Forms.CheckBox();
            this.cb_particle = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_rabid = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_CivitStatus = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmd_load1 = new System.Windows.Forms.Button();
            this.dt_expire_date = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dt_result_date = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_pysicianNo = new System.Windows.Forms.TextBox();
            this.txt_pathologist_license = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_certNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_examining_phy = new System.Windows.Forms.TextBox();
            this.txt_patho = new System.Windows.Forms.TextBox();
            this.txt_Medtech = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.overlayShadow1 = new Centerport.Class.OverlayShadow();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_)).BeginInit();
            this.panelChoice.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_resultID
            // 
            this.txt_resultID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_resultID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_resultID.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_resultID.Location = new System.Drawing.Point(411, 1);
            this.txt_resultID.Name = "txt_resultID";
            this.txt_resultID.ReadOnly = true;
            this.txt_resultID.Size = new System.Drawing.Size(226, 19);
            this.txt_resultID.TabIndex = 294;
            this.txt_resultID.TabStop = false;
            this.txt_resultID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_resultID.Visible = false;
            this.txt_resultID.TextChanged += new System.EventHandler(this.txt_resultID_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label28.Location = new System.Drawing.Point(11, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(380, 24);
            this.label28.TabIndex = 16;
            this.label28.Text = "Human Immunodeficiency Virus (HIV)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_resultID);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txt_Papin);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.overlayShadow1);
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 421);
            this.panel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dt_bday);
            this.groupBox1.Controls.Add(this.txt_gender);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_age);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_position);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_agency);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 81);
            this.groupBox1.TabIndex = 296;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PATIENT INFORMATION";
            // 
            // dt_bday
            // 
            this.dt_bday.CustomFormat = "00/00/0000";
            this.dt_bday.Enabled = false;
            this.dt_bday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_bday.Location = new System.Drawing.Point(531, 18);
            this.dt_bday.Name = "dt_bday";
            this.dt_bday.ShowUpDown = true;
            this.dt_bday.Size = new System.Drawing.Size(98, 21);
            this.dt_bday.TabIndex = 259;
            this.dt_bday.ValueChanged += new System.EventHandler(this.dt_bday_ValueChanged);
            this.dt_bday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bday_KeyDown);
            this.dt_bday.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_bday_MouseDown);
            // 
            // txt_gender
            // 
            this.txt_gender.BackColor = System.Drawing.SystemColors.Control;
            this.txt_gender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gender.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_gender.Location = new System.Drawing.Point(774, 20);
            this.txt_gender.Name = "txt_gender";
            this.txt_gender.ReadOnly = true;
            this.txt_gender.Size = new System.Drawing.Size(96, 22);
            this.txt_gender.TabIndex = 258;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(720, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 257;
            this.label5.Text = "Gender:";
            // 
            // txt_age
            // 
            this.txt_age.BackColor = System.Drawing.SystemColors.Control;
            this.txt_age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_age.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_age.Location = new System.Drawing.Point(682, 20);
            this.txt_age.Name = "txt_age";
            this.txt_age.ReadOnly = true;
            this.txt_age.Size = new System.Drawing.Size(34, 22);
            this.txt_age.TabIndex = 256;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(649, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 255;
            this.label4.Text = "Age:";
            // 
            // txt_position
            // 
            this.txt_position.BackColor = System.Drawing.SystemColors.Control;
            this.txt_position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_position.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_position.Location = new System.Drawing.Point(531, 46);
            this.txt_position.Name = "txt_position";
            this.txt_position.ReadOnly = true;
            this.txt_position.Size = new System.Drawing.Size(339, 22);
            this.txt_position.TabIndex = 254;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(475, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 252;
            this.label2.Text = "Position:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(467, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 251;
            this.label3.Text = "Birth date:";
            // 
            // txt_agency
            // 
            this.txt_agency.BackColor = System.Drawing.SystemColors.Control;
            this.txt_agency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_agency.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_agency.Location = new System.Drawing.Point(74, 46);
            this.txt_agency.Name = "txt_agency";
            this.txt_agency.ReadOnly = true;
            this.txt_agency.Size = new System.Drawing.Size(385, 22);
            this.txt_agency.TabIndex = 250;
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.SystemColors.Control;
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_name.Location = new System.Drawing.Point(74, 20);
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(385, 22);
            this.txt_name.TabIndex = 249;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 246;
            this.label1.Text = "Agency:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.Font = new System.Drawing.Font("Arial", 9F);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(24, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 15);
            this.label24.TabIndex = 245;
            this.label24.Text = "Name:";
            // 
            // txt_Papin
            // 
            this.txt_Papin.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Papin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Papin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Papin.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Papin.Location = new System.Drawing.Point(667, 5);
            this.txt_Papin.Name = "txt_Papin";
            this.txt_Papin.ReadOnly = true;
            this.txt_Papin.Size = new System.Drawing.Size(226, 19);
            this.txt_Papin.TabIndex = 295;
            this.txt_Papin.TabStop = false;
            this.txt_Papin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Papin.TextChanged += new System.EventHandler(this.txt_Papin_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pic_);
            this.groupBox3.Controls.Add(this.lbl_medical_cn);
            this.groupBox3.Controls.Add(this.lbl_HIV_Result_Cn);
            this.groupBox3.Controls.Add(this.panelChoice);
            this.groupBox3.Controls.Add(this.txt_other_specify);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cb_eie);
            this.groupBox3.Controls.Add(this.cb_particle);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cb_rabid);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox3.Location = new System.Drawing.Point(9, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(887, 180);
            this.groupBox3.TabIndex = 260;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HUMAN IMMUNODEFICIENCY VIRUS (HIV) SCREEN TEST";
            // 
            // pic_
            // 
            this.pic_.Location = new System.Drawing.Point(787, 84);
            this.pic_.Name = "pic_";
            this.pic_.Size = new System.Drawing.Size(49, 50);
            this.pic_.TabIndex = 298;
            this.pic_.TabStop = false;
            this.pic_.Visible = false;
            // 
            // lbl_medical_cn
            // 
            this.lbl_medical_cn.AutoSize = true;
            this.lbl_medical_cn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_medical_cn.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_medical_cn.Location = new System.Drawing.Point(489, 29);
            this.lbl_medical_cn.Name = "lbl_medical_cn";
            this.lbl_medical_cn.Size = new System.Drawing.Size(155, 25);
            this.lbl_medical_cn.TabIndex = 297;
            this.lbl_medical_cn.Text = "lbl_medical_cn";
            this.lbl_medical_cn.Visible = false;
            // 
            // lbl_HIV_Result_Cn
            // 
            this.lbl_HIV_Result_Cn.AutoSize = true;
            this.lbl_HIV_Result_Cn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HIV_Result_Cn.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_HIV_Result_Cn.Location = new System.Drawing.Point(653, 29);
            this.lbl_HIV_Result_Cn.Name = "lbl_HIV_Result_Cn";
            this.lbl_HIV_Result_Cn.Size = new System.Drawing.Size(202, 25);
            this.lbl_HIV_Result_Cn.TabIndex = 296;
            this.lbl_HIV_Result_Cn.Text = "lbl_Xray_Result_Cn";
            this.lbl_HIV_Result_Cn.Visible = false;
            // 
            // panelChoice
            // 
            this.panelChoice.Controls.Add(this.label18);
            this.panelChoice.Controls.Add(this.rb_result_NonReactive);
            this.panelChoice.Controls.Add(this.rb_result_Reactive);
            this.panelChoice.Location = new System.Drawing.Point(349, 84);
            this.panelChoice.Name = "panelChoice";
            this.panelChoice.Size = new System.Drawing.Size(366, 37);
            this.panelChoice.TabIndex = 267;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(26, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 16);
            this.label18.TabIndex = 263;
            this.label18.Text = "RESULT:";
            // 
            // rb_result_NonReactive
            // 
            this.rb_result_NonReactive.AutoSize = true;
            this.rb_result_NonReactive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_result_NonReactive.ForeColor = System.Drawing.Color.Black;
            this.rb_result_NonReactive.Location = new System.Drawing.Point(115, 8);
            this.rb_result_NonReactive.Name = "rb_result_NonReactive";
            this.rb_result_NonReactive.Size = new System.Drawing.Size(118, 20);
            this.rb_result_NonReactive.TabIndex = 232;
            this.rb_result_NonReactive.TabStop = true;
            this.rb_result_NonReactive.Text = "NONREACTIVE";
            this.rb_result_NonReactive.UseVisualStyleBackColor = true;
            // 
            // rb_result_Reactive
            // 
            this.rb_result_Reactive.AutoSize = true;
            this.rb_result_Reactive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_result_Reactive.ForeColor = System.Drawing.Color.Black;
            this.rb_result_Reactive.Location = new System.Drawing.Point(239, 8);
            this.rb_result_Reactive.Name = "rb_result_Reactive";
            this.rb_result_Reactive.Size = new System.Drawing.Size(90, 20);
            this.rb_result_Reactive.TabIndex = 233;
            this.rb_result_Reactive.TabStop = true;
            this.rb_result_Reactive.Text = "REACTIVE";
            this.rb_result_Reactive.UseVisualStyleBackColor = true;
            // 
            // txt_other_specify
            // 
            this.txt_other_specify.BackColor = System.Drawing.Color.White;
            this.txt_other_specify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_other_specify.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_other_specify.Location = new System.Drawing.Point(150, 149);
            this.txt_other_specify.Name = "txt_other_specify";
            this.txt_other_specify.Size = new System.Drawing.Size(718, 22);
            this.txt_other_specify.TabIndex = 266;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("Arial", 9F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(49, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 15);
            this.label17.TabIndex = 263;
            this.label17.Text = "Others (Specify)";
            // 
            // cb_eie
            // 
            this.cb_eie.AutoSize = true;
            this.cb_eie.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_eie.ForeColor = System.Drawing.Color.Black;
            this.cb_eie.Location = new System.Drawing.Point(52, 128);
            this.cb_eie.Name = "cb_eie";
            this.cb_eie.Size = new System.Drawing.Size(96, 18);
            this.cb_eie.TabIndex = 252;
            this.cb_eie.Text = "EIA/CMA/ELFA";
            this.cb_eie.UseVisualStyleBackColor = true;
            // 
            // cb_particle
            // 
            this.cb_particle.AutoSize = true;
            this.cb_particle.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_particle.ForeColor = System.Drawing.Color.Black;
            this.cb_particle.Location = new System.Drawing.Point(52, 103);
            this.cb_particle.Name = "cb_particle";
            this.cb_particle.Size = new System.Drawing.Size(125, 18);
            this.cb_particle.TabIndex = 251;
            this.cb_particle.Text = "Particle Agglutination";
            this.cb_particle.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("Arial", 9F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(24, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(221, 15);
            this.label16.TabIndex = 250;
            this.label16.Text = "Screening TEst Used:   (Please Check)";
            // 
            // cb_rabid
            // 
            this.cb_rabid.AutoSize = true;
            this.cb_rabid.Font = new System.Drawing.Font("Arial", 8F);
            this.cb_rabid.ForeColor = System.Drawing.Color.Black;
            this.cb_rabid.Location = new System.Drawing.Point(52, 78);
            this.cb_rabid.Name = "cb_rabid";
            this.cb_rabid.Size = new System.Drawing.Size(56, 18);
            this.cb_rabid.TabIndex = 249;
            this.cb_rabid.Text = "RAPID";
            this.cb_rabid.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(24, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(442, 15);
            this.label9.TabIndex = 248;
            this.label9.Text = "Human Immunodeficiency Virus Type (HIV-1) as a screening test for HIV/AIDS:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_CivitStatus);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.cmd_load1);
            this.groupBox2.Controls.Add(this.dt_expire_date);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dt_result_date);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_pysicianNo);
            this.groupBox2.Controls.Add(this.txt_pathologist_license);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txt_certNo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txt_examining_phy);
            this.groupBox2.Controls.Add(this.txt_patho);
            this.groupBox2.Controls.Add(this.txt_Medtech);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(9, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(887, 136);
            this.groupBox2.TabIndex = 259;
            this.groupBox2.TabStop = false;
            // 
            // txt_CivitStatus
            // 
            this.txt_CivitStatus.Location = new System.Drawing.Point(18, 33);
            this.txt_CivitStatus.Name = "txt_CivitStatus";
            this.txt_CivitStatus.Size = new System.Drawing.Size(16, 21);
            this.txt_CivitStatus.TabIndex = 273;
            this.txt_CivitStatus.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(609, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 272;
            this.textBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(543, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 271;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(543, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 270;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmd_load1
            // 
            this.cmd_load1.Location = new System.Drawing.Point(543, 13);
            this.cmd_load1.Name = "cmd_load1";
            this.cmd_load1.Size = new System.Drawing.Size(23, 23);
            this.cmd_load1.TabIndex = 269;
            this.cmd_load1.Text = "...";
            this.cmd_load1.UseVisualStyleBackColor = true;
            this.cmd_load1.Click += new System.EventHandler(this.cmd_load1_Click);
            // 
            // dt_expire_date
            // 
            this.dt_expire_date.CustomFormat = "MM/dd/yyyy";
            this.dt_expire_date.Font = new System.Drawing.Font("Arial", 9F);
            this.dt_expire_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_expire_date.Location = new System.Drawing.Point(388, 100);
            this.dt_expire_date.Name = "dt_expire_date";
            this.dt_expire_date.ShowUpDown = true;
            this.dt_expire_date.Size = new System.Drawing.Size(104, 21);
            this.dt_expire_date.TabIndex = 265;
            this.dt_expire_date.ValueChanged += new System.EventHandler(this.dt_expire_date_ValueChanged);
            this.dt_expire_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_expire_date_KeyDown);
            this.dt_expire_date.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dt_expire_date_MouseDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Arial", 9F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(303, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 15);
            this.label15.TabIndex = 264;
            this.label15.Text = "Expire Date:";
            // 
            // dt_result_date
            // 
            this.dt_result_date.CustomFormat = "MM/dd/yyyy";
            this.dt_result_date.Font = new System.Drawing.Font("Arial", 9F);
            this.dt_result_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_result_date.Location = new System.Drawing.Point(155, 100);
            this.dt_result_date.Name = "dt_result_date";
            this.dt_result_date.ShowUpDown = true;
            this.dt_result_date.Size = new System.Drawing.Size(104, 21);
            this.dt_result_date.TabIndex = 263;
            this.dt_result_date.ValueChanged += new System.EventHandler(this.dt_result_date_ValueChanged);
            this.dt_result_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_result_date_KeyDown);
            this.dt_result_date.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dt_result_date_MouseDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Arial", 9F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(63, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 15);
            this.label11.TabIndex = 262;
            this.label11.Text = "Rersult Date:";
            // 
            // txt_pysicianNo
            // 
            this.txt_pysicianNo.BackColor = System.Drawing.Color.White;
            this.txt_pysicianNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pysicianNo.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_pysicianNo.Location = new System.Drawing.Point(729, 61);
            this.txt_pysicianNo.Name = "txt_pysicianNo";
            this.txt_pysicianNo.Size = new System.Drawing.Size(139, 22);
            this.txt_pysicianNo.TabIndex = 261;
            // 
            // txt_pathologist_license
            // 
            this.txt_pathologist_license.BackColor = System.Drawing.Color.White;
            this.txt_pathologist_license.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pathologist_license.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_pathologist_license.Location = new System.Drawing.Point(729, 37);
            this.txt_pathologist_license.Name = "txt_pathologist_license";
            this.txt_pathologist_license.Size = new System.Drawing.Size(139, 22);
            this.txt_pathologist_license.TabIndex = 260;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(591, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 15);
            this.label12.TabIndex = 257;
            this.label12.Text = "Physician License No.:";
            // 
            // txt_certNo
            // 
            this.txt_certNo.BackColor = System.Drawing.Color.White;
            this.txt_certNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_certNo.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_certNo.Location = new System.Drawing.Point(729, 14);
            this.txt_certNo.Name = "txt_certNo";
            this.txt_certNo.Size = new System.Drawing.Size(140, 22);
            this.txt_certNo.TabIndex = 259;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Arial", 9F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(582, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 15);
            this.label13.TabIndex = 256;
            this.label13.Text = "Pathologist License No.:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(578, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 15);
            this.label14.TabIndex = 255;
            this.label14.Text = "HIV Proficiency Cert. No. :";
            // 
            // txt_examining_phy
            // 
            this.txt_examining_phy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_examining_phy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_examining_phy.BackColor = System.Drawing.Color.White;
            this.txt_examining_phy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_examining_phy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_examining_phy.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_examining_phy.Location = new System.Drawing.Point(169, 61);
            this.txt_examining_phy.Name = "txt_examining_phy";
            this.txt_examining_phy.Size = new System.Drawing.Size(368, 22);
            this.txt_examining_phy.TabIndex = 253;
            // 
            // txt_patho
            // 
            this.txt_patho.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_patho.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_patho.BackColor = System.Drawing.Color.White;
            this.txt_patho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_patho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_patho.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_patho.Location = new System.Drawing.Point(169, 37);
            this.txt_patho.Name = "txt_patho";
            this.txt_patho.Size = new System.Drawing.Size(368, 22);
            this.txt_patho.TabIndex = 252;
            // 
            // txt_Medtech
            // 
            this.txt_Medtech.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_Medtech.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_Medtech.BackColor = System.Drawing.Color.White;
            this.txt_Medtech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Medtech.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Medtech.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txt_Medtech.Location = new System.Drawing.Point(169, 14);
            this.txt_Medtech.Name = "txt_Medtech";
            this.txt_Medtech.Size = new System.Drawing.Size(368, 22);
            this.txt_Medtech.TabIndex = 251;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(39, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 15);
            this.label8.TabIndex = 249;
            this.label8.Text = "Examining Physician:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(91, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 248;
            this.label7.Text = "Pathologist:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(38, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 247;
            this.label6.Text = "Medical Technologist:";
            // 
            // overlayShadow1
            // 
            this.overlayShadow1.Location = new System.Drawing.Point(0, 34);
            this.overlayShadow1.Name = "overlayShadow1";
            this.overlayShadow1.Size = new System.Drawing.Size(905, 393);
            this.overlayShadow1.TabIndex = 297;
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(524, 11);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(100, 20);
            this.txt_address.TabIndex = 17;
            this.txt_address.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // frm_HIV
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(905, 459);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frm_HIV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Human Immunodeficiency Virus (HIV) Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_HIV_FormClosing);
            this.Load += new System.EventHandler(this.frm_HIV_Load);
            this.Enter += new System.EventHandler(this.frm_HIV_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_HIV_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_)).EndInit();
            this.panelChoice.ResumeLayout(false);
            this.panelChoice.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_pysicianNo;
        private System.Windows.Forms.TextBox txt_pathologist_license;
        private System.Windows.Forms.TextBox txt_certNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_examining_phy;
        private System.Windows.Forms.TextBox txt_patho;
        private System.Windows.Forms.TextBox txt_Medtech;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dt_expire_date;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dt_result_date;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cb_rabid;
        private System.Windows.Forms.CheckBox cb_eie;
        private System.Windows.Forms.CheckBox cb_particle;
        private System.Windows.Forms.TextBox txt_other_specify;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panelChoice;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rb_result_NonReactive;
        private System.Windows.Forms.RadioButton rb_result_Reactive;
        private System.Windows.Forms.TextBox txt_Papin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_gender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_agency;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbl_medical_cn;
        private System.Windows.Forms.Label lbl_HIV_Result_Cn;
        private Class.OverlayShadow overlayShadow1;
        private System.Windows.Forms.DateTimePicker dt_bday;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmd_load1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txt_resultID;
        public System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.TextBox txt_CivitStatus;
        private System.Windows.Forms.PictureBox pic_;
        private System.Windows.Forms.TextBox txt_address;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}