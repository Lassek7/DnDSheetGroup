namespace CharacterSheet
{
    partial class AddToInventoryForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ItemDescriptionRichBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemAmountBox = new System.Windows.Forms.TextBox();
            this.ItemTypeBox = new System.Windows.Forms.TextBox();
            this.ItemweightBox = new System.Windows.Forms.TextBox();
            this.ItemNameBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ArmorEquippedCheck = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ArmorDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ArmorACBox = new System.Windows.Forms.TextBox();
            this.ArmorTypeBox = new System.Windows.Forms.TextBox();
            this.ArmorWeightBox = new System.Windows.Forms.TextBox();
            this.ArmorNameBox = new System.Windows.Forms.TextBox();
            this.ArmorAmountBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.WeaponEquippedCheck = new System.Windows.Forms.CheckBox();
            this.WeaponProficencyCheck = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.WeaponCharismaStatRadioButton = new System.Windows.Forms.RadioButton();
            this.WeaponWisdomStatRadioButton = new System.Windows.Forms.RadioButton();
            this.WeaponIntelligenceStatRadioButton = new System.Windows.Forms.RadioButton();
            this.WeaponConstitutionStatRadioButton = new System.Windows.Forms.RadioButton();
            this.WeaponDexterityStatRadioButton = new System.Windows.Forms.RadioButton();
            this.WeaponStrengthStatRadioButton = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.WeaponDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.WeaponDamageTypeBox = new System.Windows.Forms.TextBox();
            this.WeaponDamageBox = new System.Windows.Forms.TextBox();
            this.WeaponRangeBox = new System.Windows.Forms.TextBox();
            this.WeaponNameBox = new System.Windows.Forms.TextBox();
            this.WeaponAmountBox = new System.Windows.Forms.TextBox();
            this.WeaponWeightBox = new System.Windows.Forms.TextBox();
            this.WeaponTypeBox = new System.Windows.Forms.TextBox();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ItemDescriptionRichBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ItemAmountBox);
            this.groupBox1.Controls.Add(this.ItemTypeBox);
            this.groupBox1.Controls.Add(this.ItemweightBox);
            this.groupBox1.Controls.Add(this.ItemNameBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Item";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Description";
            // 
            // ItemDescriptionRichBox
            // 
            this.ItemDescriptionRichBox.Location = new System.Drawing.Point(330, 32);
            this.ItemDescriptionRichBox.Name = "ItemDescriptionRichBox";
            this.ItemDescriptionRichBox.Size = new System.Drawing.Size(82, 43);
            this.ItemDescriptionRichBox.TabIndex = 9;
            this.ItemDescriptionRichBox.Text = "";
            this.ItemDescriptionRichBox.TextChanged += new System.EventHandler(this.ItemDescriptionRichBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ItemType";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Weight Pr. Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // ItemAmountBox
            // 
            this.ItemAmountBox.Location = new System.Drawing.Point(131, 32);
            this.ItemAmountBox.Name = "ItemAmountBox";
            this.ItemAmountBox.Size = new System.Drawing.Size(71, 20);
            this.ItemAmountBox.TabIndex = 3;
            this.ItemAmountBox.TextChanged += new System.EventHandler(this.ItemAmountBox_TextChanged);
            // 
            // ItemTypeBox
            // 
            this.ItemTypeBox.Location = new System.Drawing.Point(27, 78);
            this.ItemTypeBox.Name = "ItemTypeBox";
            this.ItemTypeBox.Size = new System.Drawing.Size(71, 20);
            this.ItemTypeBox.TabIndex = 2;
            this.ItemTypeBox.TextChanged += new System.EventHandler(this.ItemTypeBox_TextChanged);
            // 
            // ItemweightBox
            // 
            this.ItemweightBox.Location = new System.Drawing.Point(233, 32);
            this.ItemweightBox.Name = "ItemweightBox";
            this.ItemweightBox.Size = new System.Drawing.Size(71, 20);
            this.ItemweightBox.TabIndex = 1;
            this.ItemweightBox.TextChanged += new System.EventHandler(this.ItemweightBox_TextChanged);
            // 
            // ItemNameBox
            // 
            this.ItemNameBox.Location = new System.Drawing.Point(27, 32);
            this.ItemNameBox.Name = "ItemNameBox";
            this.ItemNameBox.Size = new System.Drawing.Size(71, 20);
            this.ItemNameBox.TabIndex = 0;
            this.ItemNameBox.TextChanged += new System.EventHandler(this.ItemNameBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ArmorEquippedCheck);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ArmorDescriptionBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ArmorACBox);
            this.groupBox2.Controls.Add(this.ArmorTypeBox);
            this.groupBox2.Controls.Add(this.ArmorWeightBox);
            this.groupBox2.Controls.Add(this.ArmorNameBox);
            this.groupBox2.Controls.Add(this.ArmorAmountBox);
            this.groupBox2.Location = new System.Drawing.Point(18, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Armor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "AC";
            // 
            // ArmorEquippedCheck
            // 
            this.ArmorEquippedCheck.AutoSize = true;
            this.ArmorEquippedCheck.Location = new System.Drawing.Point(234, 80);
            this.ArmorEquippedCheck.Name = "ArmorEquippedCheck";
            this.ArmorEquippedCheck.Size = new System.Drawing.Size(82, 17);
            this.ArmorEquippedCheck.TabIndex = 16;
            this.ArmorEquippedCheck.Text = "Equip Item?";
            this.ArmorEquippedCheck.UseVisualStyleBackColor = true;
            this.ArmorEquippedCheck.CheckedChanged += new System.EventHandler(this.ArmorEquippedCheck_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "ItemType";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Description";
            // 
            // ArmorDescriptionBox
            // 
            this.ArmorDescriptionBox.Location = new System.Drawing.Point(330, 35);
            this.ArmorDescriptionBox.Name = "ArmorDescriptionBox";
            this.ArmorDescriptionBox.Size = new System.Drawing.Size(82, 40);
            this.ArmorDescriptionBox.TabIndex = 12;
            this.ArmorDescriptionBox.Text = "";
            this.ArmorDescriptionBox.TextChanged += new System.EventHandler(this.ArmorDescriptionBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Weight Pr. Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // ArmorACBox
            // 
            this.ArmorACBox.Location = new System.Drawing.Point(131, 77);
            this.ArmorACBox.Name = "ArmorACBox";
            this.ArmorACBox.Size = new System.Drawing.Size(71, 20);
            this.ArmorACBox.TabIndex = 5;
            this.ArmorACBox.TextChanged += new System.EventHandler(this.ArmorACBox_TextChanged);
            // 
            // ArmorTypeBox
            // 
            this.ArmorTypeBox.Location = new System.Drawing.Point(27, 77);
            this.ArmorTypeBox.Name = "ArmorTypeBox";
            this.ArmorTypeBox.Size = new System.Drawing.Size(71, 20);
            this.ArmorTypeBox.TabIndex = 4;
            this.ArmorTypeBox.TextChanged += new System.EventHandler(this.ArmorTypeBox_TextChanged);
            // 
            // ArmorWeightBox
            // 
            this.ArmorWeightBox.Location = new System.Drawing.Point(234, 33);
            this.ArmorWeightBox.Name = "ArmorWeightBox";
            this.ArmorWeightBox.Size = new System.Drawing.Size(71, 20);
            this.ArmorWeightBox.TabIndex = 3;
            this.ArmorWeightBox.TextChanged += new System.EventHandler(this.ArmorWeightBox_TextChanged);
            // 
            // ArmorNameBox
            // 
            this.ArmorNameBox.Location = new System.Drawing.Point(27, 30);
            this.ArmorNameBox.Name = "ArmorNameBox";
            this.ArmorNameBox.Size = new System.Drawing.Size(71, 20);
            this.ArmorNameBox.TabIndex = 2;
            this.ArmorNameBox.TextChanged += new System.EventHandler(this.ArmorNameBox_TextChanged);
            // 
            // ArmorAmountBox
            // 
            this.ArmorAmountBox.Location = new System.Drawing.Point(129, 30);
            this.ArmorAmountBox.Name = "ArmorAmountBox";
            this.ArmorAmountBox.Size = new System.Drawing.Size(71, 20);
            this.ArmorAmountBox.TabIndex = 1;
            this.ArmorAmountBox.TextChanged += new System.EventHandler(this.ArmorAmountBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.WeaponEquippedCheck);
            this.groupBox3.Controls.Add(this.WeaponProficencyCheck);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.WeaponCharismaStatRadioButton);
            this.groupBox3.Controls.Add(this.WeaponWisdomStatRadioButton);
            this.groupBox3.Controls.Add(this.WeaponIntelligenceStatRadioButton);
            this.groupBox3.Controls.Add(this.WeaponConstitutionStatRadioButton);
            this.groupBox3.Controls.Add(this.WeaponDexterityStatRadioButton);
            this.groupBox3.Controls.Add(this.WeaponStrengthStatRadioButton);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.WeaponDescriptionBox);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.WeaponDamageTypeBox);
            this.groupBox3.Controls.Add(this.WeaponDamageBox);
            this.groupBox3.Controls.Add(this.WeaponRangeBox);
            this.groupBox3.Controls.Add(this.WeaponNameBox);
            this.groupBox3.Controls.Add(this.WeaponAmountBox);
            this.groupBox3.Controls.Add(this.WeaponWeightBox);
            this.groupBox3.Controls.Add(this.WeaponTypeBox);
            this.groupBox3.Location = new System.Drawing.Point(18, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 176);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add Weapon";
            // 
            // WeaponEquippedCheck
            // 
            this.WeaponEquippedCheck.AutoSize = true;
            this.WeaponEquippedCheck.Location = new System.Drawing.Point(234, 129);
            this.WeaponEquippedCheck.Name = "WeaponEquippedCheck";
            this.WeaponEquippedCheck.Size = new System.Drawing.Size(94, 17);
            this.WeaponEquippedCheck.TabIndex = 32;
            this.WeaponEquippedCheck.Text = "Item Equipped";
            this.WeaponEquippedCheck.UseVisualStyleBackColor = true;
            this.WeaponEquippedCheck.CheckedChanged += new System.EventHandler(this.WeaponEquippedCheck_CheckedChanged);
            // 
            // WeaponProficencyCheck
            // 
            this.WeaponProficencyCheck.AutoSize = true;
            this.WeaponProficencyCheck.Location = new System.Drawing.Point(234, 84);
            this.WeaponProficencyCheck.Name = "WeaponProficencyCheck";
            this.WeaponProficencyCheck.Size = new System.Drawing.Size(76, 17);
            this.WeaponProficencyCheck.TabIndex = 31;
            this.WeaponProficencyCheck.Text = "Proficency";
            this.WeaponProficencyCheck.UseVisualStyleBackColor = true;
            this.WeaponProficencyCheck.CheckedChanged += new System.EventHandler(this.WeaponProficencyCheck_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Damage type";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(142, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 28;
            this.label19.Text = "Damage";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(39, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "Range";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(473, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 26;
            this.label17.Text = "Type";
            // 
            // WeaponCharismaStatRadioButton
            // 
            this.WeaponCharismaStatRadioButton.AutoSize = true;
            this.WeaponCharismaStatRadioButton.Location = new System.Drawing.Point(440, 153);
            this.WeaponCharismaStatRadioButton.Name = "WeaponCharismaStatRadioButton";
            this.WeaponCharismaStatRadioButton.Size = new System.Drawing.Size(68, 17);
            this.WeaponCharismaStatRadioButton.TabIndex = 25;
            this.WeaponCharismaStatRadioButton.TabStop = true;
            this.WeaponCharismaStatRadioButton.Text = "Charisma";
            this.WeaponCharismaStatRadioButton.UseVisualStyleBackColor = true;
            this.WeaponCharismaStatRadioButton.CheckedChanged += new System.EventHandler(this.WeaponCharismaStatRadioButton_CheckedChanged);
            // 
            // WeaponWisdomStatRadioButton
            // 
            this.WeaponWisdomStatRadioButton.AutoSize = true;
            this.WeaponWisdomStatRadioButton.Location = new System.Drawing.Point(440, 130);
            this.WeaponWisdomStatRadioButton.Name = "WeaponWisdomStatRadioButton";
            this.WeaponWisdomStatRadioButton.Size = new System.Drawing.Size(63, 17);
            this.WeaponWisdomStatRadioButton.TabIndex = 24;
            this.WeaponWisdomStatRadioButton.TabStop = true;
            this.WeaponWisdomStatRadioButton.Text = "Wisdom";
            this.WeaponWisdomStatRadioButton.UseVisualStyleBackColor = true;
            this.WeaponWisdomStatRadioButton.CheckedChanged += new System.EventHandler(this.WeaponWisdomStatRadioButton_CheckedChanged);
            // 
            // WeaponIntelligenceStatRadioButton
            // 
            this.WeaponIntelligenceStatRadioButton.AutoSize = true;
            this.WeaponIntelligenceStatRadioButton.Location = new System.Drawing.Point(440, 107);
            this.WeaponIntelligenceStatRadioButton.Name = "WeaponIntelligenceStatRadioButton";
            this.WeaponIntelligenceStatRadioButton.Size = new System.Drawing.Size(79, 17);
            this.WeaponIntelligenceStatRadioButton.TabIndex = 23;
            this.WeaponIntelligenceStatRadioButton.TabStop = true;
            this.WeaponIntelligenceStatRadioButton.Text = "Intelligence";
            this.WeaponIntelligenceStatRadioButton.UseVisualStyleBackColor = true;
            this.WeaponIntelligenceStatRadioButton.CheckedChanged += new System.EventHandler(this.WeaponIntelligenceStatRadioButton_CheckedChanged);
            // 
            // WeaponConstitutionStatRadioButton
            // 
            this.WeaponConstitutionStatRadioButton.AutoSize = true;
            this.WeaponConstitutionStatRadioButton.Location = new System.Drawing.Point(440, 84);
            this.WeaponConstitutionStatRadioButton.Name = "WeaponConstitutionStatRadioButton";
            this.WeaponConstitutionStatRadioButton.Size = new System.Drawing.Size(80, 17);
            this.WeaponConstitutionStatRadioButton.TabIndex = 22;
            this.WeaponConstitutionStatRadioButton.TabStop = true;
            this.WeaponConstitutionStatRadioButton.Text = "Constitution";
            this.WeaponConstitutionStatRadioButton.UseVisualStyleBackColor = true;
            this.WeaponConstitutionStatRadioButton.CheckedChanged += new System.EventHandler(this.WeaponConstitutionStatRadioButton_CheckedChanged);
            // 
            // WeaponDexterityStatRadioButton
            // 
            this.WeaponDexterityStatRadioButton.AutoSize = true;
            this.WeaponDexterityStatRadioButton.Location = new System.Drawing.Point(440, 61);
            this.WeaponDexterityStatRadioButton.Name = "WeaponDexterityStatRadioButton";
            this.WeaponDexterityStatRadioButton.Size = new System.Drawing.Size(66, 17);
            this.WeaponDexterityStatRadioButton.TabIndex = 21;
            this.WeaponDexterityStatRadioButton.TabStop = true;
            this.WeaponDexterityStatRadioButton.Text = "Dexterity";
            this.WeaponDexterityStatRadioButton.UseVisualStyleBackColor = true;
            this.WeaponDexterityStatRadioButton.CheckedChanged += new System.EventHandler(this.WeaponDexterityStatRadioButton_CheckedChanged);
            // 
            // WeaponStrengthStatRadioButton
            // 
            this.WeaponStrengthStatRadioButton.AutoSize = true;
            this.WeaponStrengthStatRadioButton.Location = new System.Drawing.Point(440, 38);
            this.WeaponStrengthStatRadioButton.Name = "WeaponStrengthStatRadioButton";
            this.WeaponStrengthStatRadioButton.Size = new System.Drawing.Size(65, 17);
            this.WeaponStrengthStatRadioButton.TabIndex = 20;
            this.WeaponStrengthStatRadioButton.TabStop = true;
            this.WeaponStrengthStatRadioButton.Text = "Strength";
            this.WeaponStrengthStatRadioButton.UseVisualStyleBackColor = true;
            this.WeaponStrengthStatRadioButton.CheckedChanged += new System.EventHandler(this.WeaponStrengthStatRadioButton_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(342, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Description";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(139, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "ItemType";
            // 
            // WeaponDescriptionBox
            // 
            this.WeaponDescriptionBox.Location = new System.Drawing.Point(330, 39);
            this.WeaponDescriptionBox.Name = "WeaponDescriptionBox";
            this.WeaponDescriptionBox.Size = new System.Drawing.Size(82, 40);
            this.WeaponDescriptionBox.TabIndex = 18;
            this.WeaponDescriptionBox.Text = "";
            this.WeaponDescriptionBox.TextChanged += new System.EventHandler(this.WeaponDescriptionBox_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(230, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Weight Pr. Item";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(146, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Name";
            // 
            // WeaponDamageTypeBox
            // 
            this.WeaponDamageTypeBox.Location = new System.Drawing.Point(27, 82);
            this.WeaponDamageTypeBox.Name = "WeaponDamageTypeBox";
            this.WeaponDamageTypeBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponDamageTypeBox.TabIndex = 13;
            this.WeaponDamageTypeBox.TextChanged += new System.EventHandler(this.WeaponDamageTypeBox_TextChanged);
            // 
            // WeaponDamageBox
            // 
            this.WeaponDamageBox.Location = new System.Drawing.Point(131, 82);
            this.WeaponDamageBox.Name = "WeaponDamageBox";
            this.WeaponDamageBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponDamageBox.TabIndex = 12;
            this.WeaponDamageBox.TextChanged += new System.EventHandler(this.WeaponDamageBox_TextChanged);
            // 
            // WeaponRangeBox
            // 
            this.WeaponRangeBox.Location = new System.Drawing.Point(27, 127);
            this.WeaponRangeBox.Name = "WeaponRangeBox";
            this.WeaponRangeBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponRangeBox.TabIndex = 11;
            this.WeaponRangeBox.TextChanged += new System.EventHandler(this.WeaponRangeBox_TextChanged);
            // 
            // WeaponNameBox
            // 
            this.WeaponNameBox.Location = new System.Drawing.Point(27, 39);
            this.WeaponNameBox.Name = "WeaponNameBox";
            this.WeaponNameBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponNameBox.TabIndex = 10;
            this.WeaponNameBox.TextChanged += new System.EventHandler(this.WeaponNameBox_TextChanged);
            // 
            // WeaponAmountBox
            // 
            this.WeaponAmountBox.Location = new System.Drawing.Point(131, 38);
            this.WeaponAmountBox.Name = "WeaponAmountBox";
            this.WeaponAmountBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponAmountBox.TabIndex = 5;
            this.WeaponAmountBox.TextChanged += new System.EventHandler(this.WeaponAmountBox_TextChanged);
            // 
            // WeaponWeightBox
            // 
            this.WeaponWeightBox.Location = new System.Drawing.Point(233, 38);
            this.WeaponWeightBox.Name = "WeaponWeightBox";
            this.WeaponWeightBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponWeightBox.TabIndex = 4;
            this.WeaponWeightBox.TextChanged += new System.EventHandler(this.WeaponWeightBox_TextChanged);
            // 
            // WeaponTypeBox
            // 
            this.WeaponTypeBox.Location = new System.Drawing.Point(130, 127);
            this.WeaponTypeBox.Name = "WeaponTypeBox";
            this.WeaponTypeBox.Size = new System.Drawing.Size(71, 20);
            this.WeaponTypeBox.TabIndex = 3;
            this.WeaponTypeBox.TextChanged += new System.EventHandler(this.WeaponTypeBox_TextChanged);
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(682, 383);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(93, 49);
            this.AddItemButton.TabIndex = 2;
            this.AddItemButton.Text = "Add to Item";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // AddToInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddToInventoryForm";
            this.Text = "AddToInventoryForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox ItemDescriptionRichBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ItemAmountBox;
        private System.Windows.Forms.TextBox ItemTypeBox;
        private System.Windows.Forms.TextBox ItemweightBox;
        private System.Windows.Forms.TextBox ItemNameBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ArmorEquippedCheck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox ArmorDescriptionBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ArmorACBox;
        private System.Windows.Forms.TextBox ArmorTypeBox;
        private System.Windows.Forms.TextBox ArmorWeightBox;
        private System.Windows.Forms.TextBox ArmorNameBox;
        private System.Windows.Forms.TextBox ArmorAmountBox;
        private System.Windows.Forms.RadioButton WeaponWisdomStatRadioButton;
        private System.Windows.Forms.RadioButton WeaponIntelligenceStatRadioButton;
        private System.Windows.Forms.RadioButton WeaponConstitutionStatRadioButton;
        private System.Windows.Forms.RadioButton WeaponDexterityStatRadioButton;
        private System.Windows.Forms.RadioButton WeaponStrengthStatRadioButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox WeaponDescriptionBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox WeaponDamageTypeBox;
        private System.Windows.Forms.TextBox WeaponDamageBox;
        private System.Windows.Forms.TextBox WeaponRangeBox;
        private System.Windows.Forms.TextBox WeaponNameBox;
        private System.Windows.Forms.TextBox WeaponAmountBox;
        private System.Windows.Forms.TextBox WeaponWeightBox;
        private System.Windows.Forms.TextBox WeaponTypeBox;
        private System.Windows.Forms.RadioButton WeaponCharismaStatRadioButton;
        private System.Windows.Forms.CheckBox WeaponEquippedCheck;
        private System.Windows.Forms.CheckBox WeaponProficencyCheck;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button AddItemButton;
    }
}