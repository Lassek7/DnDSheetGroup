namespace CharacterSheet
{
    partial class CreateCharacterForm
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
            this.CharacterNameLabel = new System.Windows.Forms.Label();
            this.CharacterNameBox = new System.Windows.Forms.TextBox();
            this.CreateDoneButton = new System.Windows.Forms.Button();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.RaceLabel = new System.Windows.Forms.Label();
            this.BackgroundBox = new System.Windows.Forms.TextBox();
            this.MaxHealthBox = new System.Windows.Forms.TextBox();
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.RaceBox = new System.Windows.Forms.TextBox();
            this.ClassBox = new System.Windows.Forms.TextBox();
            this.AlignmentBox = new System.Windows.Forms.TextBox();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.IdealsLabel = new System.Windows.Forms.Label();
            this.IdealsRichBox = new System.Windows.Forms.RichTextBox();
            this.BondsRichBox = new System.Windows.Forms.RichTextBox();
            this.FlawsRichBox = new System.Windows.Forms.RichTextBox();
            this.PersonalTraitsRichBox = new System.Windows.Forms.RichTextBox();
            this.BondsLabel = new System.Windows.Forms.Label();
            this.FlawsLabel = new System.Windows.Forms.Label();
            this.PersonalTraitsLabel = new System.Windows.Forms.Label();
            this.BackgroundLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AlignmentLabel = new System.Windows.Forms.Label();
            this.MaxHealthLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.LevelBox = new System.Windows.Forms.TextBox();
            this.StrengthInputBox = new System.Windows.Forms.TextBox();
            this.DexterityInputBox = new System.Windows.Forms.TextBox();
            this.IntelligenceInputBox = new System.Windows.Forms.TextBox();
            this.ConstitutionInputBox = new System.Windows.Forms.TextBox();
            this.CharismaInputBox = new System.Windows.Forms.TextBox();
            this.WisdomInputBox = new System.Windows.Forms.TextBox();
            this.StrengthLabel = new System.Windows.Forms.Label();
            this.DexterityLabel = new System.Windows.Forms.Label();
            this.ConstitutionLabel = new System.Windows.Forms.Label();
            this.IntelligenceLabel = new System.Windows.Forms.Label();
            this.CharismaLabel = new System.Windows.Forms.Label();
            this.WisdomLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ResourceBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CharacterNameLabel
            // 
            this.CharacterNameLabel.AutoSize = true;
            this.CharacterNameLabel.Location = new System.Drawing.Point(12, 25);
            this.CharacterNameLabel.Name = "CharacterNameLabel";
            this.CharacterNameLabel.Size = new System.Drawing.Size(81, 13);
            this.CharacterNameLabel.TabIndex = 0;
            this.CharacterNameLabel.Text = "CharacterName";
            // 
            // CharacterNameBox
            // 
            this.CharacterNameBox.Location = new System.Drawing.Point(104, 25);
            this.CharacterNameBox.Name = "CharacterNameBox";
            this.CharacterNameBox.Size = new System.Drawing.Size(100, 20);
            this.CharacterNameBox.TabIndex = 1;
            this.CharacterNameBox.TextChanged += new System.EventHandler(this.CharacterNameBox_TextChanged);
            // 
            // CreateDoneButton
            // 
            this.CreateDoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateDoneButton.Location = new System.Drawing.Point(523, 342);
            this.CreateDoneButton.Name = "CreateDoneButton";
            this.CreateDoneButton.Size = new System.Drawing.Size(95, 34);
            this.CreateDoneButton.TabIndex = 19;
            this.CreateDoneButton.Text = "Create";
            this.CreateDoneButton.UseVisualStyleBackColor = true;
            this.CreateDoneButton.Click += new System.EventHandler(this.CreateDoneButton_Click);
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Location = new System.Drawing.Point(12, 58);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(64, 13);
            this.PlayerNameLabel.TabIndex = 3;
            this.PlayerNameLabel.Text = "PlayerName";
            // 
            // RaceLabel
            // 
            this.RaceLabel.AutoSize = true;
            this.RaceLabel.Location = new System.Drawing.Point(12, 90);
            this.RaceLabel.Name = "RaceLabel";
            this.RaceLabel.Size = new System.Drawing.Size(33, 13);
            this.RaceLabel.TabIndex = 5;
            this.RaceLabel.Text = "Race";
            // 
            // BackgroundBox
            // 
            this.BackgroundBox.Location = new System.Drawing.Point(104, 230);
            this.BackgroundBox.Name = "BackgroundBox";
            this.BackgroundBox.Size = new System.Drawing.Size(100, 20);
            this.BackgroundBox.TabIndex = 6;
            this.BackgroundBox.TextChanged += new System.EventHandler(this.BackgroundBox_TextChanged);
            // 
            // MaxHealthBox
            // 
            this.MaxHealthBox.Location = new System.Drawing.Point(104, 266);
            this.MaxHealthBox.Name = "MaxHealthBox";
            this.MaxHealthBox.Size = new System.Drawing.Size(100, 20);
            this.MaxHealthBox.TabIndex = 7;
            this.MaxHealthBox.TextChanged += new System.EventHandler(this.MaxHealthBox_TextChanged);
            this.MaxHealthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaxHealthBox_KeyPress);
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Location = new System.Drawing.Point(104, 58);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(100, 20);
            this.PlayerNameBox.TabIndex = 2;
            this.PlayerNameBox.TextChanged += new System.EventHandler(this.PlayerNameBox_TextChanged);
            // 
            // RaceBox
            // 
            this.RaceBox.Location = new System.Drawing.Point(104, 90);
            this.RaceBox.Name = "RaceBox";
            this.RaceBox.Size = new System.Drawing.Size(100, 20);
            this.RaceBox.TabIndex = 3;
            this.RaceBox.TextChanged += new System.EventHandler(this.RaceBox_TextChanged);
            // 
            // ClassBox
            // 
            this.ClassBox.Location = new System.Drawing.Point(104, 122);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(100, 20);
            this.ClassBox.TabIndex = 4;
            this.ClassBox.TextChanged += new System.EventHandler(this.ClassBox_TextChanged);
            // 
            // AlignmentBox
            // 
            this.AlignmentBox.Location = new System.Drawing.Point(104, 193);
            this.AlignmentBox.Name = "AlignmentBox";
            this.AlignmentBox.Size = new System.Drawing.Size(100, 20);
            this.AlignmentBox.TabIndex = 5;
            this.AlignmentBox.TextChanged += new System.EventHandler(this.AlignmentBox_TextChanged);
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Location = new System.Drawing.Point(13, 122);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(32, 13);
            this.ClassLabel.TabIndex = 19;
            this.ClassLabel.Text = "Class";
            // 
            // IdealsLabel
            // 
            this.IdealsLabel.AutoSize = true;
            this.IdealsLabel.Location = new System.Drawing.Point(240, 180);
            this.IdealsLabel.Name = "IdealsLabel";
            this.IdealsLabel.Size = new System.Drawing.Size(35, 13);
            this.IdealsLabel.TabIndex = 20;
            this.IdealsLabel.Text = "Ideals";
            // 
            // IdealsRichBox
            // 
            this.IdealsRichBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IdealsRichBox.Location = new System.Drawing.Point(333, 180);
            this.IdealsRichBox.Name = "IdealsRichBox";
            this.IdealsRichBox.Size = new System.Drawing.Size(154, 63);
            this.IdealsRichBox.TabIndex = 11;
            this.IdealsRichBox.Text = "";
            this.IdealsRichBox.TextChanged += new System.EventHandler(this.IdealsRichBox_TextChanged);
            // 
            // BondsRichBox
            // 
            this.BondsRichBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BondsRichBox.Location = new System.Drawing.Point(333, 102);
            this.BondsRichBox.Name = "BondsRichBox";
            this.BondsRichBox.Size = new System.Drawing.Size(154, 63);
            this.BondsRichBox.TabIndex = 10;
            this.BondsRichBox.Text = "";
            this.BondsRichBox.TextChanged += new System.EventHandler(this.BondsRichBox_TextChanged);
            // 
            // FlawsRichBox
            // 
            this.FlawsRichBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FlawsRichBox.Location = new System.Drawing.Point(333, 258);
            this.FlawsRichBox.Name = "FlawsRichBox";
            this.FlawsRichBox.Size = new System.Drawing.Size(154, 63);
            this.FlawsRichBox.TabIndex = 12;
            this.FlawsRichBox.Text = "";
            this.FlawsRichBox.TextChanged += new System.EventHandler(this.FlawsRichBox_TextChanged);
            // 
            // PersonalTraitsRichBox
            // 
            this.PersonalTraitsRichBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PersonalTraitsRichBox.Location = new System.Drawing.Point(333, 22);
            this.PersonalTraitsRichBox.Name = "PersonalTraitsRichBox";
            this.PersonalTraitsRichBox.Size = new System.Drawing.Size(154, 63);
            this.PersonalTraitsRichBox.TabIndex = 9;
            this.PersonalTraitsRichBox.Text = "";
            this.PersonalTraitsRichBox.TextChanged += new System.EventHandler(this.PersonalTraitsRichBox_TextChanged);
            // 
            // BondsLabel
            // 
            this.BondsLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BondsLabel.AutoSize = true;
            this.BondsLabel.Location = new System.Drawing.Point(237, 102);
            this.BondsLabel.Name = "BondsLabel";
            this.BondsLabel.Size = new System.Drawing.Size(37, 13);
            this.BondsLabel.TabIndex = 25;
            this.BondsLabel.Text = "Bonds";
            // 
            // FlawsLabel
            // 
            this.FlawsLabel.AutoSize = true;
            this.FlawsLabel.Location = new System.Drawing.Point(240, 255);
            this.FlawsLabel.Name = "FlawsLabel";
            this.FlawsLabel.Size = new System.Drawing.Size(34, 13);
            this.FlawsLabel.TabIndex = 26;
            this.FlawsLabel.Text = "Flaws";
            // 
            // PersonalTraitsLabel
            // 
            this.PersonalTraitsLabel.AutoSize = true;
            this.PersonalTraitsLabel.Location = new System.Drawing.Point(237, 25);
            this.PersonalTraitsLabel.Name = "PersonalTraitsLabel";
            this.PersonalTraitsLabel.Size = new System.Drawing.Size(77, 13);
            this.PersonalTraitsLabel.TabIndex = 27;
            this.PersonalTraitsLabel.Text = "Personal Traits";
            // 
            // BackgroundLabel
            // 
            this.BackgroundLabel.AutoSize = true;
            this.BackgroundLabel.Location = new System.Drawing.Point(11, 230);
            this.BackgroundLabel.Name = "BackgroundLabel";
            this.BackgroundLabel.Size = new System.Drawing.Size(65, 13);
            this.BackgroundLabel.TabIndex = 28;
            this.BackgroundLabel.Text = "Background";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 32;
            // 
            // AlignmentLabel
            // 
            this.AlignmentLabel.AutoSize = true;
            this.AlignmentLabel.Location = new System.Drawing.Point(12, 193);
            this.AlignmentLabel.Name = "AlignmentLabel";
            this.AlignmentLabel.Size = new System.Drawing.Size(53, 13);
            this.AlignmentLabel.TabIndex = 30;
            this.AlignmentLabel.Text = "Alignment";
            // 
            // MaxHealthLabel
            // 
            this.MaxHealthLabel.AutoSize = true;
            this.MaxHealthLabel.Location = new System.Drawing.Point(13, 266);
            this.MaxHealthLabel.Name = "MaxHealthLabel";
            this.MaxHealthLabel.Size = new System.Drawing.Size(58, 13);
            this.MaxHealthLabel.TabIndex = 31;
            this.MaxHealthLabel.Text = "MaxHealth";
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(13, 298);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(33, 13);
            this.LevelLabel.TabIndex = 33;
            this.LevelLabel.Text = "Level";
            // 
            // LevelBox
            // 
            this.LevelBox.Location = new System.Drawing.Point(104, 295);
            this.LevelBox.Name = "LevelBox";
            this.LevelBox.Size = new System.Drawing.Size(100, 20);
            this.LevelBox.TabIndex = 8;
            this.LevelBox.TextChanged += new System.EventHandler(this.LevelBox_TextChanged);
            this.LevelBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LevelBox_KeyPress);
            // 
            // StrengthInputBox
            // 
            this.StrengthInputBox.Location = new System.Drawing.Point(533, 38);
            this.StrengthInputBox.Name = "StrengthInputBox";
            this.StrengthInputBox.Size = new System.Drawing.Size(77, 20);
            this.StrengthInputBox.TabIndex = 13;
            this.StrengthInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StrengthInputBox.TextChanged += new System.EventHandler(this.StrengthInputBox_TextChanged);
            this.StrengthInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StrengthInputBox_KeyPress);
            // 
            // DexterityInputBox
            // 
            this.DexterityInputBox.Location = new System.Drawing.Point(532, 88);
            this.DexterityInputBox.Name = "DexterityInputBox";
            this.DexterityInputBox.Size = new System.Drawing.Size(77, 20);
            this.DexterityInputBox.TabIndex = 14;
            this.DexterityInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DexterityInputBox.TextChanged += new System.EventHandler(this.DexterityInputBox_TextChanged);
            this.DexterityInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DexterityInputBox_KeyPress);
            // 
            // IntelligenceInputBox
            // 
            this.IntelligenceInputBox.Location = new System.Drawing.Point(533, 196);
            this.IntelligenceInputBox.Name = "IntelligenceInputBox";
            this.IntelligenceInputBox.Size = new System.Drawing.Size(77, 20);
            this.IntelligenceInputBox.TabIndex = 16;
            this.IntelligenceInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IntelligenceInputBox.TextChanged += new System.EventHandler(this.IntelligenceInputBox_TextChanged);
            this.IntelligenceInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntelligenceInputBox_KeyPress);
            // 
            // ConstitutionInputBox
            // 
            this.ConstitutionInputBox.Location = new System.Drawing.Point(532, 141);
            this.ConstitutionInputBox.Name = "ConstitutionInputBox";
            this.ConstitutionInputBox.Size = new System.Drawing.Size(77, 20);
            this.ConstitutionInputBox.TabIndex = 15;
            this.ConstitutionInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConstitutionInputBox.TextChanged += new System.EventHandler(this.ConstitutionInputBox_TextChanged);
            this.ConstitutionInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConstitutionInputBox_KeyPress);
            // 
            // CharismaInputBox
            // 
            this.CharismaInputBox.Location = new System.Drawing.Point(533, 298);
            this.CharismaInputBox.Name = "CharismaInputBox";
            this.CharismaInputBox.Size = new System.Drawing.Size(77, 20);
            this.CharismaInputBox.TabIndex = 18;
            this.CharismaInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CharismaInputBox.TextChanged += new System.EventHandler(this.CharismaInputBox_TextChanged);
            this.CharismaInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CharismaInputBox_KeyPress);
            // 
            // WisdomInputBox
            // 
            this.WisdomInputBox.Location = new System.Drawing.Point(533, 246);
            this.WisdomInputBox.Name = "WisdomInputBox";
            this.WisdomInputBox.Size = new System.Drawing.Size(77, 20);
            this.WisdomInputBox.TabIndex = 17;
            this.WisdomInputBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WisdomInputBox.TextChanged += new System.EventHandler(this.WisdomInputBox_TextChanged);
            this.WisdomInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WisdomInputBox_KeyPress);
            // 
            // StrengthLabel
            // 
            this.StrengthLabel.AutoSize = true;
            this.StrengthLabel.Location = new System.Drawing.Point(544, 22);
            this.StrengthLabel.Name = "StrengthLabel";
            this.StrengthLabel.Size = new System.Drawing.Size(47, 13);
            this.StrengthLabel.TabIndex = 40;
            this.StrengthLabel.Text = "Strength";
            // 
            // DexterityLabel
            // 
            this.DexterityLabel.AutoSize = true;
            this.DexterityLabel.Location = new System.Drawing.Point(544, 72);
            this.DexterityLabel.Name = "DexterityLabel";
            this.DexterityLabel.Size = new System.Drawing.Size(48, 13);
            this.DexterityLabel.TabIndex = 41;
            this.DexterityLabel.Text = "Dexterity";
            // 
            // ConstitutionLabel
            // 
            this.ConstitutionLabel.AutoSize = true;
            this.ConstitutionLabel.Location = new System.Drawing.Point(543, 125);
            this.ConstitutionLabel.Name = "ConstitutionLabel";
            this.ConstitutionLabel.Size = new System.Drawing.Size(62, 13);
            this.ConstitutionLabel.TabIndex = 42;
            this.ConstitutionLabel.Text = "Constitution";
            // 
            // IntelligenceLabel
            // 
            this.IntelligenceLabel.AutoSize = true;
            this.IntelligenceLabel.Location = new System.Drawing.Point(544, 180);
            this.IntelligenceLabel.Name = "IntelligenceLabel";
            this.IntelligenceLabel.Size = new System.Drawing.Size(61, 13);
            this.IntelligenceLabel.TabIndex = 43;
            this.IntelligenceLabel.Text = "Intelligence";
            // 
            // CharismaLabel
            // 
            this.CharismaLabel.AutoSize = true;
            this.CharismaLabel.Location = new System.Drawing.Point(549, 282);
            this.CharismaLabel.Name = "CharismaLabel";
            this.CharismaLabel.Size = new System.Drawing.Size(50, 13);
            this.CharismaLabel.TabIndex = 44;
            this.CharismaLabel.Text = "Charisma";
            // 
            // WisdomLabel
            // 
            this.WisdomLabel.AutoSize = true;
            this.WisdomLabel.Location = new System.Drawing.Point(554, 230);
            this.WisdomLabel.Name = "WisdomLabel";
            this.WisdomLabel.Size = new System.Drawing.Size(45, 13);
            this.WisdomLabel.TabIndex = 45;
            this.WisdomLabel.Text = "Wisdom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Class Resource";
            // 
            // ResourceBox
            // 
            this.ResourceBox.Location = new System.Drawing.Point(104, 150);
            this.ResourceBox.Name = "ResourceBox";
            this.ResourceBox.Size = new System.Drawing.Size(100, 20);
            this.ResourceBox.TabIndex = 47;
            this.ResourceBox.TextChanged += new System.EventHandler(this.ResourceBox_TextChanged);
            // 
            // CreateCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 388);
            this.Controls.Add(this.ResourceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WisdomLabel);
            this.Controls.Add(this.CharismaLabel);
            this.Controls.Add(this.IntelligenceLabel);
            this.Controls.Add(this.ConstitutionLabel);
            this.Controls.Add(this.DexterityLabel);
            this.Controls.Add(this.StrengthLabel);
            this.Controls.Add(this.CharismaInputBox);
            this.Controls.Add(this.WisdomInputBox);
            this.Controls.Add(this.IntelligenceInputBox);
            this.Controls.Add(this.ConstitutionInputBox);
            this.Controls.Add(this.DexterityInputBox);
            this.Controls.Add(this.StrengthInputBox);
            this.Controls.Add(this.LevelBox);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.MaxHealthLabel);
            this.Controls.Add(this.AlignmentLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BackgroundLabel);
            this.Controls.Add(this.PersonalTraitsLabel);
            this.Controls.Add(this.FlawsLabel);
            this.Controls.Add(this.BondsLabel);
            this.Controls.Add(this.PersonalTraitsRichBox);
            this.Controls.Add(this.FlawsRichBox);
            this.Controls.Add(this.BondsRichBox);
            this.Controls.Add(this.IdealsRichBox);
            this.Controls.Add(this.IdealsLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.AlignmentBox);
            this.Controls.Add(this.ClassBox);
            this.Controls.Add(this.RaceBox);
            this.Controls.Add(this.PlayerNameBox);
            this.Controls.Add(this.MaxHealthBox);
            this.Controls.Add(this.BackgroundBox);
            this.Controls.Add(this.RaceLabel);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.CreateDoneButton);
            this.Controls.Add(this.CharacterNameBox);
            this.Controls.Add(this.CharacterNameLabel);
            this.Name = "CreateCharacterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateCharacter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CharacterNameLabel;
        private System.Windows.Forms.TextBox CharacterNameBox;
        private System.Windows.Forms.Button CreateDoneButton;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Label RaceLabel;
        private System.Windows.Forms.TextBox BackgroundBox;
        private System.Windows.Forms.TextBox MaxHealthBox;
        private System.Windows.Forms.TextBox PlayerNameBox;
        private System.Windows.Forms.TextBox RaceBox;
        private System.Windows.Forms.TextBox ClassBox;
        private System.Windows.Forms.TextBox AlignmentBox;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label IdealsLabel;
        private System.Windows.Forms.RichTextBox IdealsRichBox;
        private System.Windows.Forms.RichTextBox BondsRichBox;
        private System.Windows.Forms.RichTextBox FlawsRichBox;
        private System.Windows.Forms.RichTextBox PersonalTraitsRichBox;
        private System.Windows.Forms.Label BondsLabel;
        private System.Windows.Forms.Label FlawsLabel;
        private System.Windows.Forms.Label PersonalTraitsLabel;
        private System.Windows.Forms.Label BackgroundLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label AlignmentLabel;
        private System.Windows.Forms.Label MaxHealthLabel;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.TextBox LevelBox;
        private System.Windows.Forms.TextBox StrengthInputBox;
        private System.Windows.Forms.TextBox DexterityInputBox;
        private System.Windows.Forms.TextBox IntelligenceInputBox;
        private System.Windows.Forms.TextBox ConstitutionInputBox;
        private System.Windows.Forms.TextBox CharismaInputBox;
        private System.Windows.Forms.TextBox WisdomInputBox;
        private System.Windows.Forms.Label StrengthLabel;
        private System.Windows.Forms.Label DexterityLabel;
        private System.Windows.Forms.Label ConstitutionLabel;
        private System.Windows.Forms.Label IntelligenceLabel;
        private System.Windows.Forms.Label CharismaLabel;
        private System.Windows.Forms.Label WisdomLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ResourceBox;
    }
}

