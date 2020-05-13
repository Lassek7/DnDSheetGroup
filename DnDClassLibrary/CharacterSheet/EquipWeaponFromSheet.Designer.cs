namespace CharacterSheet
{
    partial class EquipWeaponFromSheet
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
            this.SlotOneButton = new System.Windows.Forms.Button();
            this.SlotTwoButton = new System.Windows.Forms.Button();
            this.SlotThreeButton = new System.Windows.Forms.Button();
            this.FormLabelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SlotOneButton
            // 
            this.SlotOneButton.Location = new System.Drawing.Point(12, 112);
            this.SlotOneButton.Name = "SlotOneButton";
            this.SlotOneButton.Size = new System.Drawing.Size(99, 37);
            this.SlotOneButton.TabIndex = 0;
            this.SlotOneButton.Text = "Slot 1";
            this.SlotOneButton.UseVisualStyleBackColor = true;
            this.SlotOneButton.Click += new System.EventHandler(this.SlotOneButton_Click);
            // 
            // SlotTwoButton
            // 
            this.SlotTwoButton.Location = new System.Drawing.Point(127, 112);
            this.SlotTwoButton.Name = "SlotTwoButton";
            this.SlotTwoButton.Size = new System.Drawing.Size(99, 39);
            this.SlotTwoButton.TabIndex = 1;
            this.SlotTwoButton.Text = "Slot 2";
            this.SlotTwoButton.UseVisualStyleBackColor = true;
            this.SlotTwoButton.Click += new System.EventHandler(this.SlotTwoButton_Click);
            // 
            // SlotThreeButton
            // 
            this.SlotThreeButton.Location = new System.Drawing.Point(250, 112);
            this.SlotThreeButton.Name = "SlotThreeButton";
            this.SlotThreeButton.Size = new System.Drawing.Size(99, 39);
            this.SlotThreeButton.TabIndex = 2;
            this.SlotThreeButton.Text = "Slot 3";
            this.SlotThreeButton.UseVisualStyleBackColor = true;
            this.SlotThreeButton.Click += new System.EventHandler(this.SlotThreeButton_Click);
            // 
            // FormLabelText
            // 
            this.FormLabelText.AutoSize = true;
            this.FormLabelText.Location = new System.Drawing.Point(42, 63);
            this.FormLabelText.Name = "FormLabelText";
            this.FormLabelText.Size = new System.Drawing.Size(35, 13);
            this.FormLabelText.TabIndex = 3;
            this.FormLabelText.Text = "label1";
            // 
            // EquipWeaponFromSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 176);
            this.Controls.Add(this.FormLabelText);
            this.Controls.Add(this.SlotThreeButton);
            this.Controls.Add(this.SlotTwoButton);
            this.Controls.Add(this.SlotOneButton);
            this.Name = "EquipWeaponFromSheet";
            this.Text = "EquipWeaponFromSheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SlotOneButton;
        private System.Windows.Forms.Button SlotTwoButton;
        private System.Windows.Forms.Button SlotThreeButton;
        private System.Windows.Forms.Label FormLabelText;
    }
}