namespace Centerport
{
    partial class frm_xray
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_Xray_Result_Cn = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_impression = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_radiologist_findings = new System.Windows.Forms.RichTextBox();
            this.txt_specimentNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cmd_load1 = new System.Windows.Forms.Button();
            this.lbl_medical_cn = new System.Windows.Forms.Label();
            this.txt_speciment = new System.Windows.Forms.TextBox();
            this.txt_RadioLogist_Lic = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_RadioLogist = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_XRAYtech_lic = new System.Windows.Forms.TextBox();
            this.dt_result_Date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_XRAYtech = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Papin = new System.Windows.Forms.TextBox();
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
            this.overlayShadow1 = new Centerport.Class.OverlayShadow();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_resultID
            // 
            this.txt_resultID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_resultID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_resultID.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_resultID.Location = new System.Drawing.Point(363, 4);
            this.txt_resultID.Name = "txt_resultID";
            this.txt_resultID.ReadOnly = true;
            this.txt_resultID.Size = new System.Drawing.Size(226, 19);
            this.txt_resultID.TabIndex = 292;
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
            this.label28.Size = new System.Drawing.Size(139, 24);
            this.label28.TabIndex = 16;
            this.label28.Text = "X-Ray Result";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_resultID);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txt_Papin);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.overlayShadow1);
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 474);
            this.panel2.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_Xray_Result_Cn);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txt_specimentNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox2.Location = new System.Drawing.Point(10, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(887, 292);
            this.groupBox2.TabIndex = 296;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X-RAY RESULT";
            // 
            // lbl_Xray_Result_Cn
            // 
            this.lbl_Xray_Result_Cn.AutoSize = true;
            this.lbl_Xray_Result_Cn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Xray_Result_Cn.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Xray_Result_Cn.Location = new System.Drawing.Point(377, 17);
            this.lbl_Xray_Result_Cn.Name = "lbl_Xray_Result_Cn";
            this.lbl_Xray_Result_Cn.Size = new System.Drawing.Size(202, 25);
            this.lbl_Xray_Result_Cn.TabIndex = 294;
            this.lbl_Xray_Result_Cn.Text = "lbl_Xray_Result_Cn";
            this.lbl_Xray_Result_Cn.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_impression);
            this.groupBox4.Location = new System.Drawing.Point(5, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(876, 112);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "*Impression";
            // 
            // txt_impression
            // 
            this.txt_impression.Font = new System.Drawing.Font("Arial", 9F);
            this.txt_impression.Location = new System.Drawing.Point(9, 20);
            this.txt_impression.Name = "txt_impression";
            this.txt_impression.Size = new System.Drawing.Size(856, 86);
            this.txt_impression.TabIndex = 7;
            this.txt_impression.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_radiologist_findings);
            this.groupBox3.Location = new System.Drawing.Point(5, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(876, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "*Radiology Findings";
            // 
            // txt_radiologist_findings
            // 
            this.txt_radiologist_findings.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_radiologist_findings.Location = new System.Drawing.Point(9, 20);
            this.txt_radiologist_findings.Name = "txt_radiologist_findings";
            this.txt_radiologist_findings.Size = new System.Drawing.Size(856, 86);
            this.txt_radiologist_findings.TabIndex = 6;
            this.txt_radiologist_findings.Text = "";
            // 
            // txt_specimentNo
            // 
            this.txt_specimentNo.BackColor = System.Drawing.Color.White;
            this.txt_specimentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_specimentNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_specimentNo.Location = new System.Drawing.Point(750, 25);
            this.txt_specimentNo.Name = "txt_specimentNo";
            this.txt_specimentNo.Size = new System.Drawing.Size(120, 21);
            this.txt_specimentNo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(683, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 256;
            this.label6.Text = "X-Ray No.:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.cmd_load1);
            this.panel3.Controls.Add(this.lbl_medical_cn);
            this.panel3.Controls.Add(this.txt_speciment);
            this.panel3.Controls.Add(this.txt_RadioLogist_Lic);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txt_RadioLogist);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txt_XRAYtech_lic);
            this.panel3.Controls.Add(this.dt_result_Date);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txt_XRAYtech);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(10, 109);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(885, 60);
            this.panel3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(856, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 297;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmd_load1
            // 
            this.cmd_load1.Location = new System.Drawing.Point(856, 3);
            this.cmd_load1.Name = "cmd_load1";
            this.cmd_load1.Size = new System.Drawing.Size(23, 23);
            this.cmd_load1.TabIndex = 296;
            this.cmd_load1.Text = "...";
            this.cmd_load1.UseVisualStyleBackColor = true;
            this.cmd_load1.Click += new System.EventHandler(this.cmd_load1_Click);
            // 
            // lbl_medical_cn
            // 
            this.lbl_medical_cn.AutoSize = true;
            this.lbl_medical_cn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_medical_cn.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_medical_cn.Location = new System.Drawing.Point(373, 28);
            this.lbl_medical_cn.Name = "lbl_medical_cn";
            this.lbl_medical_cn.Size = new System.Drawing.Size(155, 25);
            this.lbl_medical_cn.TabIndex = 295;
            this.lbl_medical_cn.Text = "lbl_medical_cn";
            this.lbl_medical_cn.Visible = false;
            // 
            // txt_speciment
            // 
            this.txt_speciment.BackColor = System.Drawing.Color.White;
            this.txt_speciment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_speciment.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_speciment.Location = new System.Drawing.Point(111, 31);
            this.txt_speciment.Name = "txt_speciment";
            this.txt_speciment.Size = new System.Drawing.Size(112, 21);
            this.txt_speciment.TabIndex = 4;
            this.txt_speciment.Visible = false;
            // 
            // txt_RadioLogist_Lic
            // 
            this.txt_RadioLogist_Lic.BackColor = System.Drawing.Color.White;
            this.txt_RadioLogist_Lic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RadioLogist_Lic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RadioLogist_Lic.Location = new System.Drawing.Point(708, 31);
            this.txt_RadioLogist_Lic.Name = "txt_RadioLogist_Lic";
            this.txt_RadioLogist_Lic.Size = new System.Drawing.Size(131, 21);
            this.txt_RadioLogist_Lic.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Arial", 9F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(45, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 15);
            this.label13.TabIndex = 262;
            this.label13.Text = "LAB. NO.:";
            this.label13.Visible = false;
            // 
            // txt_RadioLogist
            // 
            this.txt_RadioLogist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_RadioLogist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_RadioLogist.BackColor = System.Drawing.Color.White;
            this.txt_RadioLogist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RadioLogist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_RadioLogist.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RadioLogist.Location = new System.Drawing.Point(319, 31);
            this.txt_RadioLogist.Name = "txt_RadioLogist";
            this.txt_RadioLogist.Size = new System.Drawing.Size(293, 21);
            this.txt_RadioLogist.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(618, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 15);
            this.label14.TabIndex = 263;
            this.label14.Text = "LICENSE NO.:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Arial", 9F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(226, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 15);
            this.label15.TabIndex = 264;
            this.label15.Text = "RADIOLOGIST:";
            // 
            // txt_XRAYtech_lic
            // 
            this.txt_XRAYtech_lic.BackColor = System.Drawing.Color.White;
            this.txt_XRAYtech_lic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_XRAYtech_lic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_XRAYtech_lic.Location = new System.Drawing.Point(708, 4);
            this.txt_XRAYtech_lic.Name = "txt_XRAYtech_lic";
            this.txt_XRAYtech_lic.Size = new System.Drawing.Size(131, 21);
            this.txt_XRAYtech_lic.TabIndex = 3;
            // 
            // dt_result_Date
            // 
            this.dt_result_Date.CustomFormat = "MM/dd/yyyy";
            this.dt_result_Date.Font = new System.Drawing.Font("Arial", 9F);
            this.dt_result_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_result_Date.Location = new System.Drawing.Point(111, 5);
            this.dt_result_Date.Name = "dt_result_Date";
            this.dt_result_Date.ShowUpDown = true;
            this.dt_result_Date.Size = new System.Drawing.Size(112, 21);
            this.dt_result_Date.TabIndex = 1;
            this.dt_result_Date.ValueChanged += new System.EventHandler(this.dt_result_Date_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(14, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 255;
            this.label9.Text = "RESULT DATE:";
            // 
            // txt_XRAYtech
            // 
            this.txt_XRAYtech.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_XRAYtech.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_XRAYtech.BackColor = System.Drawing.Color.White;
            this.txt_XRAYtech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_XRAYtech.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_XRAYtech.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_XRAYtech.Location = new System.Drawing.Point(319, 4);
            this.txt_XRAYtech.Name = "txt_XRAYtech";
            this.txt_XRAYtech.Size = new System.Drawing.Size(293, 21);
            this.txt_XRAYtech.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(618, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 15);
            this.label8.TabIndex = 256;
            this.label8.Text = "LICENSE NO.:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(237, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 15);
            this.label10.TabIndex = 258;
            this.label10.Text = "XRAY TECH.:";
            // 
            // txt_Papin
            // 
            this.txt_Papin.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Papin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Papin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Papin.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Papin.Location = new System.Drawing.Point(667, 4);
            this.txt_Papin.Name = "txt_Papin";
            this.txt_Papin.ReadOnly = true;
            this.txt_Papin.Size = new System.Drawing.Size(226, 19);
            this.txt_Papin.TabIndex = 293;
            this.txt_Papin.TabStop = false;
            this.txt_Papin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Papin.TextChanged += new System.EventHandler(this.txt_Papin_TextChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PATIENT INFORMATION";
            // 
            // dt_bday
            // 
            this.dt_bday.CustomFormat = "00/00/0000";
            this.dt_bday.Enabled = false;
            this.dt_bday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_bday.Location = new System.Drawing.Point(531, 20);
            this.dt_bday.Name = "dt_bday";
            this.dt_bday.ShowUpDown = true;
            this.dt_bday.Size = new System.Drawing.Size(114, 21);
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
            // overlayShadow1
            // 
            this.overlayShadow1.Location = new System.Drawing.Point(0, 30);
            this.overlayShadow1.Name = "overlayShadow1";
            this.overlayShadow1.Size = new System.Drawing.Size(905, 444);
            this.overlayShadow1.TabIndex = 297;
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
            // frm_xray
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(939, 490);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(938, 524);
            this.MinimumSize = new System.Drawing.Size(938, 524);
            this.Name = "frm_xray";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "X-Ray Result Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_xray_FormClosing);
            this.Load += new System.EventHandler(this.frm_xray_Load);
            this.Enter += new System.EventHandler(this.frm_xray_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_xray_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_medical_cn;
        private System.Windows.Forms.TextBox txt_speciment;
        private System.Windows.Forms.TextBox txt_RadioLogist_Lic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_RadioLogist;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_XRAYtech_lic;
        private System.Windows.Forms.DateTimePicker dt_result_Date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_XRAYtech;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Papin;
        private Class.OverlayShadow overlayShadow1;
        private System.Windows.Forms.DateTimePicker dt_bday;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_Xray_Result_Cn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txt_impression;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txt_radiologist_findings;
        private System.Windows.Forms.TextBox txt_specimentNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmd_load1;
        public System.Windows.Forms.TextBox txt_age;
        public System.Windows.Forms.TextBox txt_resultID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}