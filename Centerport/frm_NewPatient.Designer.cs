namespace Centerport
{
    partial class frm_NewPatient
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
            this.txt_Mname = new System.Windows.Forms.TextBox();
            this.txt_fname = new System.Windows.Forms.TextBox();
            this.cbo_employer = new System.Windows.Forms.ComboBox();
            this.cbo_Position = new System.Windows.Forms.ComboBox();
            this.label58 = new System.Windows.Forms.Label();
            this.cbo_gender = new System.Windows.Forms.ComboBox();
            this.dt_bdayNew = new System.Windows.Forms.DateTimePicker();
            this.cbo_designation = new System.Windows.Forms.ComboBox();
            this.txt_lname = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_age = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_marital = new System.Windows.Forms.ComboBox();
            this.cbo_religeon = new System.Windows.Forms.ComboBox();
            this.txt_nationality = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmd_save = new System.Windows.Forms.Button();
            this.txt_papin = new System.Windows.Forms.TextBox();
            this.dt_regDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbo_patient_Type = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_transdateAndTime = new System.Windows.Forms.TextBox();
            this.txt_trackingNo = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pic_ = new System.Windows.Forms.PictureBox();
            this.cmd_new = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmd_close = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Mname
            // 
            this.txt_Mname.BackColor = System.Drawing.Color.White;
            this.txt_Mname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Mname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mname.Location = new System.Drawing.Point(102, 96);
            this.txt_Mname.Name = "txt_Mname";
            this.txt_Mname.Size = new System.Drawing.Size(320, 21);
            this.txt_Mname.TabIndex = 3;
            // 
            // txt_fname
            // 
            this.txt_fname.BackColor = System.Drawing.Color.White;
            this.txt_fname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fname.Location = new System.Drawing.Point(102, 66);
            this.txt_fname.Name = "txt_fname";
            this.txt_fname.Size = new System.Drawing.Size(320, 21);
            this.txt_fname.TabIndex = 2;
            // 
            // cbo_employer
            // 
            this.cbo_employer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_employer.BackColor = System.Drawing.Color.White;
            this.cbo_employer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_employer.FormattingEnabled = true;
            this.cbo_employer.Location = new System.Drawing.Point(102, 304);
            this.cbo_employer.Name = "cbo_employer";
            this.cbo_employer.Size = new System.Drawing.Size(320, 23);
            this.cbo_employer.TabIndex = 10;
            this.cbo_employer.SelectedIndexChanged += new System.EventHandler(this.cbo_employer_SelectedIndexChanged);
            // 
            // cbo_Position
            // 
            this.cbo_Position.AutoCompleteCustomSource.AddRange(new string[] {
            "DECK",
            "ENGINE",
            "STEWARD",
            "OTHER"});
            this.cbo_Position.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_Position.BackColor = System.Drawing.Color.White;
            this.cbo_Position.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Position.FormattingEnabled = true;
            this.cbo_Position.Location = new System.Drawing.Point(102, 366);
            this.cbo_Position.Name = "cbo_Position";
            this.cbo_Position.Size = new System.Drawing.Size(320, 23);
            this.cbo_Position.TabIndex = 12;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label58.ForeColor = System.Drawing.Color.DarkBlue;
            this.label58.Location = new System.Drawing.Point(7, 370);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(53, 15);
            this.label58.TabIndex = 45;
            this.label58.Text = "Position:";
            // 
            // cbo_gender
            // 
            this.cbo_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_gender.FormattingEnabled = true;
            this.cbo_gender.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
            this.cbo_gender.Location = new System.Drawing.Point(102, 182);
            this.cbo_gender.Name = "cbo_gender";
            this.cbo_gender.Size = new System.Drawing.Size(320, 21);
            this.cbo_gender.TabIndex = 6;
            this.cbo_gender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_gender_KeyDown);
            // 
            // dt_bdayNew
            // 
            this.dt_bdayNew.CustomFormat = "";
            this.dt_bdayNew.Font = new System.Drawing.Font("Arial", 9F);
            this.dt_bdayNew.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_bdayNew.Location = new System.Drawing.Point(102, 154);
            this.dt_bdayNew.Name = "dt_bdayNew";
            this.dt_bdayNew.ShowUpDown = true;
            this.dt_bdayNew.Size = new System.Drawing.Size(101, 21);
            this.dt_bdayNew.TabIndex = 5;
            this.dt_bdayNew.ValueChanged += new System.EventHandler(this.dt_bdayNew_ValueChanged);
            // 
            // cbo_designation
            // 
            this.cbo_designation.AutoCompleteCustomSource.AddRange(new string[] {
            "DECK",
            "ENGINE",
            "STEWARD",
            "OTHER"});
            this.cbo_designation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbo_designation.BackColor = System.Drawing.Color.White;
            this.cbo_designation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_designation.FormattingEnabled = true;
            this.cbo_designation.Items.AddRange(new object[] {
            "DECK",
            "ENGINE",
            "STEWARD",
            "OTHER"});
            this.cbo_designation.Location = new System.Drawing.Point(102, 335);
            this.cbo_designation.Name = "cbo_designation";
            this.cbo_designation.Size = new System.Drawing.Size(320, 23);
            this.cbo_designation.TabIndex = 11;
            this.cbo_designation.SelectedIndexChanged += new System.EventHandler(this.cbo_designation_SelectedIndexChanged);
            // 
            // txt_lname
            // 
            this.txt_lname.BackColor = System.Drawing.Color.White;
            this.txt_lname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_lname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lname.Location = new System.Drawing.Point(102, 127);
            this.txt_lname.Name = "txt_lname";
            this.txt_lname.Size = new System.Drawing.Size(320, 21);
            this.txt_lname.TabIndex = 4;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label59.ForeColor = System.Drawing.Color.DarkBlue;
            this.label59.Location = new System.Drawing.Point(7, 339);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(78, 15);
            this.label59.TabIndex = 63;
            this.label59.Text = "*Designation:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.SystemColors.Control;
            this.label60.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(7, 185);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(48, 15);
            this.label60.TabIndex = 257;
            this.label60.Text = "Gender:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.SystemColors.Control;
            this.label62.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label62.ForeColor = System.Drawing.Color.DarkBlue;
            this.label62.Location = new System.Drawing.Point(7, 157);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(58, 15);
            this.label62.TabIndex = 251;
            this.label62.Text = "Birthdate:";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.SystemColors.Control;
            this.label63.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label63.ForeColor = System.Drawing.Color.DarkBlue;
            this.label63.Location = new System.Drawing.Point(7, 308);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(60, 15);
            this.label63.TabIndex = 246;
            this.label63.Text = "Employer:";
            this.label63.Click += new System.EventHandler(this.label63_Click);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.BackColor = System.Drawing.SystemColors.Control;
            this.label64.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label64.ForeColor = System.Drawing.Color.DarkBlue;
            this.label64.Location = new System.Drawing.Point(7, 69);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(67, 15);
            this.label64.TabIndex = 245;
            this.label64.Text = "First Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 309;
            this.label1.Text = "PATIENT INFORMATION ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(7, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 310;
            this.label2.Text = "Middle Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(7, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 311;
            this.label3.Text = "Last Name:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(223, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 15);
            this.label16.TabIndex = 313;
            this.label16.Text = "Age:";
            // 
            // txt_age
            // 
            this.txt_age.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_age.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_age.Location = new System.Drawing.Point(256, 154);
            this.txt_age.Mask = "##";
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(32, 21);
            this.txt_age.TabIndex = 312;
            this.txt_age.TabStop = false;
            this.txt_age.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(7, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 15);
            this.label12.TabIndex = 315;
            this.label12.Text = "Marital Status:";
            // 
            // cbo_marital
            // 
            this.cbo_marital.AutoCompleteCustomSource.AddRange(new string[] {
            "Single",
            "Married",
            "Separated",
            "Devorce",
            "Widowed",
            "Widower"});
            this.cbo_marital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_marital.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_marital.FormattingEnabled = true;
            this.cbo_marital.Items.AddRange(new object[] {
            "Single",
            "Married",
            "Separated",
            "Devorce",
            "Widowed",
            "Widower"});
            this.cbo_marital.Location = new System.Drawing.Point(102, 211);
            this.cbo_marital.Name = "cbo_marital";
            this.cbo_marital.Size = new System.Drawing.Size(320, 23);
            this.cbo_marital.TabIndex = 7;
            this.cbo_marital.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_marital_KeyDown);
            // 
            // cbo_religeon
            // 
            this.cbo_religeon.AutoCompleteCustomSource.AddRange(new string[] {
            "Aglipayans",
            "Agnostics",
            "Animist",
            "Atheist",
            "Baptist",
            "Buddhists",
            "Christian",
            "Hindus",
            "Iglesia ni Cristo",
            "Jehovah Witnesses",
            "Methodist",
            "Mormons",
            "Muslims",
            "Protestants",
            "Roman Catholic",
            "Sevent Day Adventist"});
            this.cbo_religeon.BackColor = System.Drawing.Color.White;
            this.cbo_religeon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_religeon.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_religeon.FormattingEnabled = true;
            this.cbo_religeon.Items.AddRange(new object[] {
            "Aglipayans",
            "Agnostics",
            "Animist",
            "Atheist",
            "Baptist",
            "Buddhists",
            "Christian",
            "Hindus",
            "Iglesia ni Cristo",
            "Jehovah Witnesses",
            "Methodist",
            "Mormons",
            "Muslims",
            "Protestants",
            "Roman Catholic",
            "Sevent Day Adventist"});
            this.cbo_religeon.Location = new System.Drawing.Point(102, 242);
            this.cbo_religeon.Name = "cbo_religeon";
            this.cbo_religeon.Size = new System.Drawing.Size(320, 23);
            this.cbo_religeon.TabIndex = 8;
            this.cbo_religeon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_religeon_KeyDown);
            // 
            // txt_nationality
            // 
            this.txt_nationality.AutoCompleteCustomSource.AddRange(new string[] {
            "Afghan",
            "Albanian",
            "Algerian",
            "American",
            "Andorran",
            "Angolan",
            "Argentine",
            "Armenian",
            "Aromanian",
            "Aruban",
            "Australian",
            "Austrian",
            "Azeri",
            "Bahamian",
            "Bahraini",
            "Bangladeshi",
            "Barbadian",
            "Belarusian",
            "Belgian",
            "Belizean",
            "Bermudian",
            "Boer",
            "Bosniak",
            "Brazilian",
            "Breton",
            "British",
            "British Virgin Islander",
            "Bulgarian",
            "Burmese",
            "Macedonian Bulgarian",
            "Burkinabè",
            "Burundian",
            "Cambodian",
            "Cameroonian",
            "Canadian",
            "Catalan",
            "Cape Verdean",
            "Chadian",
            "Chilean",
            "Chinese",
            "Colombian",
            "Comorian",
            "Congolese",
            "Croatian",
            "Cuban",
            "Cypriot",
            "Turkish Cypriot",
            "Czech",
            "Dane",
            "Dominicans (Republic)",
            "Dominicans (Commonwealth)",
            "Dutch",
            "East Timorese",
            "Ecuadorian",
            "Egyptian",
            "Emirati",
            "English",
            "Eritrean",
            "Estonian",
            "Ethiopian",
            "Faroese",
            "Finn",
            "Finnish Swedish",
            "Fijian",
            "Filipino",
            "French citizen",
            "Georgian",
            "German",
            "Baltic German",
            "Ghanaian",
            "Gibraltar",
            "Greek",
            "Greek Macedonian",
            "Grenadian",
            "Guatemalan",
            "Guianese (French)",
            "Guinean",
            "Guinea-Bissau national",
            "Guyanese",
            "Haitian",
            "Honduran",
            "Hong Kong",
            "Hungarian",
            "Icelander",
            "Indian",
            "Indonesian",
            "Iranians (Persians)",
            "Iraqi",
            "Irish",
            "Israeli",
            "Italian",
            "Ivoirian",
            "Jamaican",
            "Japanese",
            "Jordanian",
            "Kazakh",
            "Kenyan",
            "Korean",
            "Kosovo Albanian",
            "Kurd",
            "Kuwaiti",
            "Lao",
            "Latvian",
            "Lebanese",
            "Liberian",
            "Libyan",
            "Liechtensteiner",
            "Lithuanian",
            "Luxembourger",
            "Macedonian",
            "Malagasy",
            "Malaysian",
            "Malawian",
            "Maldivian",
            "Malian",
            "Maltese",
            "Manx",
            "Mauritian",
            "Mexican",
            "Moldovan",
            "Moroccan",
            "Mongolian",
            "Montenegrin",
            "Namibian",
            "Nepalese",
            "New Zealander",
            "Nicaraguan",
            "Nigerien",
            "Nigerian",
            "Norwegian",
            "Pakistani",
            "Palauan",
            "Palestinian",
            "Panamanian",
            "Papua New Guinean",
            "Paraguayan",
            "Peruvian",
            "Pole",
            "Portuguese",
            "Puerto Rican",
            "Quebecer",
            "Réunionnai",
            "Romanian",
            "Russian",
            "Baltic Russian",
            "Rwandan",
            "Salvadoran",
            "São Tomé and Príncipe",
            "Saudi",
            "Scot",
            "Senegalese",
            "Serb",
            "Sierra Leonean",
            "Singaporean",
            "Sindhian",
            "Slovak",
            "Slovene",
            "Somali",
            "South African",
            "Spaniard",
            "Sri Lankan",
            "St Lucian",
            "Sudanese",
            "Surinamese",
            "Swede",
            "Swiss",
            "Syrian",
            "Taiwanese",
            "Tanzanian",
            "Tha",
            "Tibetan",
            "Tobagonians",
            "Trinidadia",
            "Tunisian",
            "Turk",
            "Tuvaluan",
            "Ugandan",
            "Ukrainian",
            "Uruguayan",
            "Uzbek",
            "Vanuatuan",
            "Venezuelan",
            "Vietnamese",
            "Welsh",
            "Yemenis",
            "Zambian",
            "Zimbabwean"});
            this.txt_nationality.BackColor = System.Drawing.Color.White;
            this.txt_nationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_nationality.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nationality.FormattingEnabled = true;
            this.txt_nationality.Items.AddRange(new object[] {
            "Afghan",
            "Albanian",
            "Algerian",
            "American",
            "Andorran",
            "Angolan",
            "Argentine",
            "Armenian",
            "Aromanian",
            "Aruban",
            "Australian",
            "Austrian",
            "Azeri",
            "Bahamian",
            "Bahraini",
            "Bangladeshi",
            "Barbadian",
            "Belarusian",
            "Belgian",
            "Belizean",
            "Bermudian",
            "Boer",
            "Bosniak",
            "Brazilian",
            "Breton",
            "British",
            "British Virgin Islander",
            "Bulgarian",
            "Burmese",
            "Macedonian Bulgarian",
            "Burkinabè",
            "Burundian",
            "Cambodian",
            "Cameroonian",
            "Canadian",
            "Catalan",
            "Cape Verdean",
            "Chadian",
            "Chilean",
            "Chinese",
            "Colombian",
            "Comorian",
            "Congolese",
            "Croatian",
            "Cuban",
            "Cypriot",
            "Turkish Cypriot",
            "Czech",
            "Dane",
            "Dominicans (Republic)",
            "Dominicans (Commonwealth)",
            "Dutch",
            "East Timorese",
            "Ecuadorian",
            "Egyptian",
            "Emirati",
            "English",
            "Eritrean",
            "Estonian",
            "Ethiopian",
            "Faroese",
            "Finn",
            "Finnish Swedish",
            "Fijian",
            "Filipino",
            "French citizen",
            "Georgian",
            "German",
            "Baltic German",
            "Ghanaian",
            "Gibraltar",
            "Greek",
            "Greek Macedonian",
            "Grenadian",
            "Guatemalan",
            "Guianese (French)",
            "Guinean",
            "Guinea-Bissau national",
            "Guyanese",
            "Haitian",
            "Honduran",
            "Hong Kong",
            "Hungarian",
            "Icelander",
            "Indian",
            "Indonesian",
            "Iranians (Persians)",
            "Iraqi",
            "Irish",
            "Israeli",
            "Italian",
            "Ivoirian",
            "Jamaican",
            "Japanese",
            "Jordanian",
            "Kazakh",
            "Kenyan",
            "Korean",
            "Kosovo Albanian",
            "Kurd",
            "Kuwaiti",
            "Lao",
            "Latvian",
            "Lebanese",
            "Liberian",
            "Libyan",
            "Liechtensteiner",
            "Lithuanian",
            "Luxembourger",
            "Macedonian",
            "Malagasy",
            "Malaysian",
            "Malawian",
            "Maldivian",
            "Malian",
            "Maltese",
            "Manx",
            "Mauritian",
            "Mexican",
            "Moldovan",
            "Moroccan",
            "Mongolian",
            "Montenegrin",
            "Namibian",
            "Nepalese",
            "New Zealander",
            "Nicaraguan",
            "Nigerien",
            "Nigerian",
            "Norwegian",
            "Pakistani",
            "Palauan",
            "Palestinian",
            "Panamanian",
            "Papua New Guinean",
            "Paraguayan",
            "Peruvian",
            "Pole",
            "Portuguese",
            "Puerto Rican",
            "Quebecer",
            "Réunionnai",
            "Romanian",
            "Russian",
            "Baltic Russian",
            "Rwandan",
            "Salvadoran",
            "São Tomé and Príncipe",
            "Saudi",
            "Scot",
            "Senegalese",
            "Serb",
            "Sierra Leonean",
            "Singaporean",
            "Sindhian",
            "Slovak",
            "Slovene",
            "Somali",
            "South African",
            "Spaniard",
            "Sri Lankan",
            "St Lucian",
            "Sudanese",
            "Surinamese",
            "Swede",
            "Swiss",
            "Syrian",
            "Taiwanese",
            "Tanzanian",
            "Tha",
            "Tibetan",
            "Tobagonians",
            "Trinidadia",
            "Tunisian",
            "Turk",
            "Tuvaluan",
            "Ugandan",
            "Ukrainian",
            "Uruguayan",
            "Uzbek",
            "Vanuatuan",
            "Venezuelan",
            "Vietnamese",
            "Welsh",
            "Yemenis",
            "Zambian",
            "Zimbabwean"});
            this.txt_nationality.Location = new System.Drawing.Point(102, 273);
            this.txt_nationality.Name = "txt_nationality";
            this.txt_nationality.Size = new System.Drawing.Size(320, 23);
            this.txt_nationality.TabIndex = 9;
            this.txt_nationality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nationality_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.Location = new System.Drawing.Point(7, 246);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 15);
            this.label14.TabIndex = 318;
            this.label14.Text = "Religion:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.Location = new System.Drawing.Point(7, 277);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 15);
            this.label15.TabIndex = 319;
            this.label15.Text = "Nationality:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(-5, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(539, 15);
            this.label4.TabIndex = 320;
            this.label4.Text = "____________________________________________________________________________";
            // 
            // cmd_save
            // 
            this.cmd_save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmd_save.Location = new System.Drawing.Point(169, 466);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(100, 23);
            this.cmd_save.TabIndex = 12;
            this.cmd_save.Text = "&Save";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // txt_papin
            // 
            this.txt_papin.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_papin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_papin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_papin.Location = new System.Drawing.Point(102, 39);
            this.txt_papin.Name = "txt_papin";
            this.txt_papin.ReadOnly = true;
            this.txt_papin.Size = new System.Drawing.Size(177, 21);
            this.txt_papin.TabIndex = 322;
            this.txt_papin.TabStop = false;
            // 
            // dt_regDate
            // 
            this.dt_regDate.CustomFormat = "MM/dd/yyy hh:mm tt";
            this.dt_regDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_regDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_regDate.Location = new System.Drawing.Point(302, 38);
            this.dt_regDate.Name = "dt_regDate";
            this.dt_regDate.ShowUpDown = true;
            this.dt_regDate.Size = new System.Drawing.Size(122, 22);
            this.dt_regDate.TabIndex = 323;
            this.dt_regDate.TabStop = false;
            this.dt_regDate.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(7, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 321;
            this.label6.Text = "Papin:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbo_patient_Type);
            this.panel6.Controls.Add(this.label24);
            this.panel6.Location = new System.Drawing.Point(567, 137);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(244, 27);
            this.panel6.TabIndex = 328;
            // 
            // cbo_patient_Type
            // 
            this.cbo_patient_Type.BackColor = System.Drawing.Color.White;
            this.cbo_patient_Type.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_patient_Type.FormattingEnabled = true;
            this.cbo_patient_Type.Items.AddRange(new object[] {
            "BNI",
            "BMA",
            "OPD"});
            this.cbo_patient_Type.Location = new System.Drawing.Point(93, 3);
            this.cbo_patient_Type.Name = "cbo_patient_Type";
            this.cbo_patient_Type.Size = new System.Drawing.Size(150, 23);
            this.cbo_patient_Type.TabIndex = 26;
            this.cbo_patient_Type.Text = "BNI";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(8, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(76, 15);
            this.label24.TabIndex = 46;
            this.label24.Text = "Patient Type:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(490, 176);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 15);
            this.label25.TabIndex = 326;
            this.label25.Text = "Trans Date:";
            // 
            // txt_transdateAndTime
            // 
            this.txt_transdateAndTime.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_transdateAndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_transdateAndTime.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_transdateAndTime.Location = new System.Drawing.Point(567, 170);
            this.txt_transdateAndTime.Name = "txt_transdateAndTime";
            this.txt_transdateAndTime.ReadOnly = true;
            this.txt_transdateAndTime.Size = new System.Drawing.Size(191, 21);
            this.txt_transdateAndTime.TabIndex = 324;
            // 
            // txt_trackingNo
            // 
            this.txt_trackingNo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_trackingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_trackingNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_trackingNo.Location = new System.Drawing.Point(567, 201);
            this.txt_trackingNo.Name = "txt_trackingNo";
            this.txt_trackingNo.ReadOnly = true;
            this.txt_trackingNo.Size = new System.Drawing.Size(178, 21);
            this.txt_trackingNo.TabIndex = 325;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(490, 203);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 15);
            this.label26.TabIndex = 327;
            this.label26.Text = "Tracking No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(424, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 329;
            this.label5.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(424, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 330;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(424, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 331;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(206, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 332;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(426, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 15);
            this.label10.TabIndex = 333;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(426, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 15);
            this.label11.TabIndex = 334;
            this.label11.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(426, 369);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 15);
            this.label13.TabIndex = 335;
            this.label13.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 434);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(208, 13);
            this.label17.TabIndex = 336;
            this.label17.Text = "NOTE: Please fill all fields with red (*) mark";
            // 
            // pic_
            // 
            this.pic_.BackColor = System.Drawing.Color.Silver;
            this.pic_.BackgroundImage = global::Centerport.Properties.Resources.AnonymousPic;
            this.pic_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_.Image = global::Centerport.Properties.Resources.AnonymousPic;
            this.pic_.Location = new System.Drawing.Point(567, 12);
            this.pic_.Name = "pic_";
            this.pic_.Size = new System.Drawing.Size(133, 101);
            this.pic_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_.TabIndex = 337;
            this.pic_.TabStop = false;
            // 
            // cmd_new
            // 
            this.cmd_new.Location = new System.Drawing.Point(88, 466);
            this.cmd_new.Name = "cmd_new";
            this.cmd_new.Size = new System.Drawing.Size(75, 23);
            this.cmd_new.TabIndex = 338;
            this.cmd_new.Text = "New";
            this.cmd_new.UseVisualStyleBackColor = true;
            this.cmd_new.Click += new System.EventHandler(this.cmd_new_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_papin);
            this.panel1.Controls.Add(this.cbo_designation);
            this.panel1.Controls.Add(this.pic_);
            this.panel1.Controls.Add(this.dt_bdayNew);
            this.panel1.Controls.Add(this.txt_lname);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label59);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label58);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label60);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbo_Position);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label62);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label63);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbo_employer);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label64);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txt_fname);
            this.panel1.Controls.Add(this.txt_transdateAndTime);
            this.panel1.Controls.Add(this.cbo_gender);
            this.panel1.Controls.Add(this.txt_trackingNo);
            this.panel1.Controls.Add(this.txt_Mname);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dt_regDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_age);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cbo_marital);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cbo_religeon);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txt_nationality);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(0, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 406);
            this.panel1.TabIndex = 339;
            // 
            // cmd_close
            // 
            this.cmd_close.Location = new System.Drawing.Point(275, 467);
            this.cmd_close.Name = "cmd_close";
            this.cmd_close.Size = new System.Drawing.Size(75, 23);
            this.cmd_close.TabIndex = 340;
            this.cmd_close.Text = "Close";
            this.cmd_close.UseVisualStyleBackColor = true;
            this.cmd_close.Click += new System.EventHandler(this.cmd_close_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frm_NewPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 502);
            this.Controls.Add(this.cmd_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmd_new);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_NewPatient";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Patient";
            this.Load += new System.EventHandler(this.frm_NewPatient_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Mname;
        private System.Windows.Forms.TextBox txt_fname;
        private System.Windows.Forms.ComboBox cbo_employer;
        private System.Windows.Forms.ComboBox cbo_Position;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ComboBox cbo_gender;
        private System.Windows.Forms.DateTimePicker dt_bdayNew;
        private System.Windows.Forms.ComboBox cbo_designation;
        private System.Windows.Forms.TextBox txt_lname;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox txt_age;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_marital;
        private System.Windows.Forms.ComboBox cbo_religeon;
        private System.Windows.Forms.ComboBox txt_nationality;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmd_save;
        public System.Windows.Forms.TextBox txt_papin;
        private System.Windows.Forms.DateTimePicker dt_regDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbo_patient_Type;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_transdateAndTime;
        private System.Windows.Forms.TextBox txt_trackingNo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pic_;
        private System.Windows.Forms.Button cmd_new;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmd_close;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}