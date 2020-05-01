using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDClassLibrary;

namespace CharacterSheet
{
    public partial class CreateCharacterForm : Form
    {
        Character Character = new Character();
        bool lvl = false;
        bool health = false;
        public CreateCharacterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void CharacterNameBox_TextChanged(object sender, EventArgs e)
        {

            Character.characterName = CharacterNameBox.Text;

        }

        private void PlayerNameBox_TextChanged(object sender, EventArgs e)
        {
            Character.playerName = PlayerNameBox.Text;
        }

        private void RaceBox_TextChanged(object sender, EventArgs e)
        {
            Character.race = RaceBox.Text;
        }

        private void ClassBox_TextChanged(object sender, EventArgs e)
        {
            Character.characterClass = ClassBox.Text;

        }
        private void LevelBox_TextChanged(object sender, EventArgs e)
        {
          bool OutOfReach = string.IsNullOrEmpty(LevelBox.Text);
          int level = 1;
          if (OutOfReach != true)
          {
              level = Int32.Parse(LevelBox.Text);
          }
          else
          {
          }
          if (level >= 1 && level <= 20)
          {
              Character.level = Convert.ToInt32(level);
              lvl = true;
          }
          else
          {
              lvl = false;
              MessageBox.Show("level must be between 1 and 20");
          }
        }

        private void AlignmentBox_TextChanged(object sender, EventArgs e)
        {
            Character.alignment = AlignmentBox.Text;
        }

        private void BackgroundBox_TextChanged(object sender, EventArgs e)
        {
            Character.background = BackgroundBox.Text;
        }

        private void MaxHealthBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(MaxHealthBox.Text);
            int Health = 1;
            if (OutOfReach != true)
            {
                Health = Int32.Parse(MaxHealthBox.Text);
            }
            else
            {

            }
            if (Health >= 1)
            {
                health = true;
                Character.maxHealth = Convert.ToInt32(Health);
            }
            else
            {
                MessageBox.Show("Your health must be more than 0");
                health = false;
            }
            
        }

        private void IdealsRichBox_TextChanged(object sender, EventArgs e)
        {
            Character.ideals = IdealsRichBox.Text;
        }

        private void BondsRichBox_TextChanged(object sender, EventArgs e)
        {
            Character.bonds = BondsRichBox.Text;
        }

        private void FlawsRichBox_TextChanged(object sender, EventArgs e)
        {
            Character.flaws = FlawsRichBox.Text;
        }

        private void PersonalTraitsRichBox_TextChanged(object sender, EventArgs e)
        {
            Character.traits = PersonalTraitsRichBox.Text;
        }
        private void CreateDoneButton_Click(object sender, EventArgs e)
        {

            if(health == true && lvl == true)
            {
                MessageBox.Show(Convert.ToString(Character.level), Convert.ToString(Character.maxHealth));
            }
            else
            {
                MessageBox.Show("please input health and lvl");
            }
            
        }

        private void MaxHealthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LevelBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }


}
