namespace CharacterSheet
{
    partial class EquipSlotCheck
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
            this.WeaponSlotOne = new System.Windows.Forms.Button();
            this.WeaponSlotTwo = new System.Windows.Forms.Button();
            this.WeaponSlotThree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WeaponSlotOne
            // 
            this.WeaponSlotOne.Location = new System.Drawing.Point(14, 75);
            this.WeaponSlotOne.Name = "WeaponSlotOne";
            this.WeaponSlotOne.Size = new System.Drawing.Size(94, 35);
            this.WeaponSlotOne.TabIndex = 0;
            this.WeaponSlotOne.Text = "button1";
            this.WeaponSlotOne.UseVisualStyleBackColor = true;
            this.WeaponSlotOne.Click += new System.EventHandler(this.WeaponSlotOne_Click);
            // 
            // WeaponSlotTwo
            // 
            this.WeaponSlotTwo.Location = new System.Drawing.Point(114, 75);
            this.WeaponSlotTwo.Name = "WeaponSlotTwo";
            this.WeaponSlotTwo.Size = new System.Drawing.Size(89, 34);
            this.WeaponSlotTwo.TabIndex = 1;
            this.WeaponSlotTwo.Text = "button2";
            this.WeaponSlotTwo.UseVisualStyleBackColor = true;
            this.WeaponSlotTwo.Click += new System.EventHandler(this.WeaponSlotTwo_Click);
            // 
            // WeaponSlotThree
            // 
            this.WeaponSlotThree.Location = new System.Drawing.Point(209, 75);
            this.WeaponSlotThree.Name = "WeaponSlotThree";
            this.WeaponSlotThree.Size = new System.Drawing.Size(85, 34);
            this.WeaponSlotThree.TabIndex = 2;
            this.WeaponSlotThree.Text = "button3";
            this.WeaponSlotThree.UseVisualStyleBackColor = true;
            this.WeaponSlotThree.Click += new System.EventHandler(this.WeaponSlotThree_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wherer to equip?";
            // 
            // EquipSlotCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(304, 130);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WeaponSlotThree);
            this.Controls.Add(this.WeaponSlotTwo);
            this.Controls.Add(this.WeaponSlotOne);
            this.Name = "EquipSlotCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EquipSlotCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WeaponSlotOne;
        private System.Windows.Forms.Button WeaponSlotTwo;
        private System.Windows.Forms.Button WeaponSlotThree;
        private System.Windows.Forms.Label label1;
    }
}