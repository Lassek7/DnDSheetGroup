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
            this.label1 = new System.Windows.Forms.Label();
            this.BackgroundBox = new System.Windows.Forms.TextBox();
            this.MaxHealthBox = new System.Windows.Forms.TextBox();
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.RaceBox = new System.Windows.Forms.TextBox();
            this.ClassBox = new System.Windows.Forms.TextBox();
            this.LevelBox = new System.Windows.Forms.TextBox();
            this.AlignmentBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IdealsRichBox = new System.Windows.Forms.RichTextBox();
            this.BondsRichBox = new System.Windows.Forms.RichTextBox();
            this.FlawsRichBox = new System.Windows.Forms.RichTextBox();
            this.PersonalTraitsRichBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
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
            this.CreateDoneButton.Location = new System.Drawing.Point(344, 342);
            this.CreateDoneButton.Name = "CreateDoneButton";
            this.CreateDoneButton.Size = new System.Drawing.Size(95, 34);
            this.CreateDoneButton.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Race";
            // 
            // BackgroundBox
            // 
            this.BackgroundBox.Location = new System.Drawing.Point(104, 245);
            this.BackgroundBox.Name = "BackgroundBox";
            this.BackgroundBox.Size = new System.Drawing.Size(100, 20);
            this.BackgroundBox.TabIndex = 8;
            this.BackgroundBox.TextChanged += new System.EventHandler(this.BackgroundBox_TextChanged);
            // 
            // MaxHealthBox
            // 
            this.MaxHealthBox.Location = new System.Drawing.Point(104, 278);
            this.MaxHealthBox.Name = "MaxHealthBox";
            this.MaxHealthBox.Size = new System.Drawing.Size(100, 20);
            this.MaxHealthBox.TabIndex = 9;
            this.MaxHealthBox.TextChanged += new System.EventHandler(this.MaxHealthBox_TextChanged);
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Location = new System.Drawing.Point(104, 58);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(100, 20);
            this.PlayerNameBox.TabIndex = 12;
            this.PlayerNameBox.TextChanged += new System.EventHandler(this.PlayerNameBox_TextChanged);
            // 
            // RaceBox
            // 
            this.RaceBox.Location = new System.Drawing.Point(104, 95);
            this.RaceBox.Name = "RaceBox";
            this.RaceBox.Size = new System.Drawing.Size(100, 20);
            this.RaceBox.TabIndex = 13;
            this.RaceBox.TextChanged += new System.EventHandler(this.RaceBox_TextChanged);
            // 
            // ClassBox
            // 
            this.ClassBox.Location = new System.Drawing.Point(104, 135);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(100, 20);
            this.ClassBox.TabIndex = 14;
            this.ClassBox.TextChanged += new System.EventHandler(this.ClassBox_TextChanged);
            // 
            // LevelBox
            // 
            this.LevelBox.Location = new System.Drawing.Point(104, 173);
            this.LevelBox.Name = "LevelBox";
            this.LevelBox.Size = new System.Drawing.Size(100, 20);
            this.LevelBox.TabIndex = 15;
            this.LevelBox.TextChanged += new System.EventHandler(this.LevelBox_TextChanged);
            // 
            // AlignmentBox
            // 
            this.AlignmentBox.Location = new System.Drawing.Point(104, 209);
            this.AlignmentBox.Name = "AlignmentBox";
            this.AlignmentBox.Size = new System.Drawing.Size(100, 20);
            this.AlignmentBox.TabIndex = 18;
            this.AlignmentBox.TextChanged += new System.EventHandler(this.AlignmentBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ideals";
            // 
            // IdealsRichBox
            // 
            this.IdealsRichBox.Location = new System.Drawing.Point(317, 22);
            this.IdealsRichBox.Name = "IdealsRichBox";
            this.IdealsRichBox.Size = new System.Drawing.Size(154, 63);
            this.IdealsRichBox.TabIndex = 21;
            this.IdealsRichBox.Text = "";
            this.IdealsRichBox.TextChanged += new System.EventHandler(this.IdealsRichBox_TextChanged);
            // 
            // BondsRichBox
            // 
            this.BondsRichBox.Location = new System.Drawing.Point(317, 99);
            this.BondsRichBox.Name = "BondsRichBox";
            this.BondsRichBox.Size = new System.Drawing.Size(154, 63);
            this.BondsRichBox.TabIndex = 22;
            this.BondsRichBox.Text = "";
            this.BondsRichBox.TextChanged += new System.EventHandler(this.BondsRichBox_TextChanged);
            // 
            // FlawsRichBox
            // 
            this.FlawsRichBox.Location = new System.Drawing.Point(317, 177);
            this.FlawsRichBox.Name = "FlawsRichBox";
            this.FlawsRichBox.Size = new System.Drawing.Size(154, 63);
            this.FlawsRichBox.TabIndex = 23;
            this.FlawsRichBox.Text = "";
            this.FlawsRichBox.TextChanged += new System.EventHandler(this.FlawsRichBox_TextChanged);
            // 
            // PersonalTraitsRichBox
            // 
            this.PersonalTraitsRichBox.Location = new System.Drawing.Point(317, 255);
            this.PersonalTraitsRichBox.Name = "PersonalTraitsRichBox";
            this.PersonalTraitsRichBox.Size = new System.Drawing.Size(154, 63);
            this.PersonalTraitsRichBox.TabIndex = 24;
            this.PersonalTraitsRichBox.Text = "";
            this.PersonalTraitsRichBox.TextChanged += new System.EventHandler(this.PersonalTraitsRichBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Bonds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Flaws";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Personal Traits";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Background";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Level";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Alignment";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "MaxHealth";
            // 
            // CreateCharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 388);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PersonalTraitsRichBox);
            this.Controls.Add(this.FlawsRichBox);
            this.Controls.Add(this.BondsRichBox);
            this.Controls.Add(this.IdealsRichBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AlignmentBox);
            this.Controls.Add(this.LevelBox);
            this.Controls.Add(this.ClassBox);
            this.Controls.Add(this.RaceBox);
            this.Controls.Add(this.PlayerNameBox);
            this.Controls.Add(this.MaxHealthBox);
            this.Controls.Add(this.BackgroundBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.CreateDoneButton);
            this.Controls.Add(this.CharacterNameBox);
            this.Controls.Add(this.CharacterNameLabel);
            this.Name = "CreateCharacterForm";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BackgroundBox;
        private System.Windows.Forms.TextBox MaxHealthBox;
        private System.Windows.Forms.TextBox PlayerNameBox;
        private System.Windows.Forms.TextBox RaceBox;
        private System.Windows.Forms.TextBox ClassBox;
        private System.Windows.Forms.TextBox LevelBox;
        private System.Windows.Forms.TextBox AlignmentBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox IdealsRichBox;
        private System.Windows.Forms.RichTextBox BondsRichBox;
        private System.Windows.Forms.RichTextBox FlawsRichBox;
        private System.Windows.Forms.RichTextBox PersonalTraitsRichBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

