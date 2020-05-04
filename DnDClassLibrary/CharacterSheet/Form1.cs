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
        Character myCharacter = new Character();
        bool CharacterNameDone = false;
        bool LvlDone = false;
        bool HealthDone = false;
        bool PlayerNameDone = false;
        bool RaceDone = false;
        bool ClassDone = false;
        bool AlignmentDone = false;
        bool BackgroundDone = false;
        bool IdealsDone = false;
        bool BondsDone = false;
        bool FlawsDone = false;
        bool PersonalTraitsDone = false;

        public CreateCharacterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void CharacterNameBox_TextChanged(object sender, EventArgs e)
        {
            CharacterNameDone = existcheck(myCharacter.characterName, CharacterNameBox.Text, CharacterNameDone);
            myCharacter.characterName = NewValue(CharacterNameDone, CharacterNameBox.Text);
        }
       
        private void PlayerNameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerNameDone = existcheck(myCharacter.playerName, PlayerNameBox.Text, PlayerNameDone);
            myCharacter.playerName = NewValue(PlayerNameDone, PlayerNameBox.Text);
        }

        private void RaceBox_TextChanged(object sender, EventArgs e)
        {
            RaceDone = existcheck(myCharacter.race, RaceBox.Text, RaceDone);
            myCharacter.race = NewValue(RaceDone, RaceBox.Text);
        }

        private void ClassBox_TextChanged(object sender, EventArgs e)
        {
            ClassDone = existcheck(myCharacter.characterClass, ClassBox.Text, ClassDone);
            myCharacter.characterClass = NewValue(ClassDone, ClassBox.Text);
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
              myCharacter.level = Convert.ToInt32(level);
              LvlDone = true;
          }
          else
          {
              LvlDone = false;
              MessageBox.Show("level must be between 1 and 20");
          }
        }

        private void AlignmentBox_TextChanged(object sender, EventArgs e)
        {
            AlignmentDone = existcheck(myCharacter.alignment, AlignmentBox.Text, AlignmentDone);
            myCharacter.alignment = NewValue(AlignmentDone, AlignmentBox.Text);
        }

        private void BackgroundBox_TextChanged(object sender, EventArgs e)
        {
            BackgroundDone = existcheck(myCharacter.background, BackgroundBox.Text, BackgroundDone);
            myCharacter.background = NewValue(BackgroundDone, BackgroundBox.Text);
        }

        private void MaxHealthBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(MaxHealthBox.Text);
            int Health = 0;
            if (OutOfReach != true)
            {
                Health = Int32.Parse(MaxHealthBox.Text);
                    if (Health >= 1)
                    {
                        HealthDone = true;
                        myCharacter.maxHealth = Convert.ToInt32(Health);
                    }
            }
            else
            {
                HealthDone = false;
            }
        }

        private void IdealsRichBox_TextChanged(object sender, EventArgs e)
        {
            IdealsDone = existcheck(myCharacter.ideals, IdealsRichBox.Text, IdealsDone);
            myCharacter.ideals = NewValue(IdealsDone, IdealsRichBox.Text);
            //IdealsDone = true;
            //myCharacter.ideals = IdealsRichBox.Text;
        }

        private void BondsRichBox_TextChanged(object sender, EventArgs e)
        {
            BondsDone = existcheck(myCharacter.bonds, BondsRichBox.Text, BondsDone);
            myCharacter.bonds = NewValue(BondsDone, BondsRichBox.Text);
        }

        private void FlawsRichBox_TextChanged(object sender, EventArgs e)
        {
            FlawsDone = existcheck(myCharacter.flaws, FlawsRichBox.Text, FlawsDone);
            myCharacter.flaws = NewValue(FlawsDone, FlawsRichBox.Text);
        }

        private void PersonalTraitsRichBox_TextChanged(object sender, EventArgs e)
        {
            PersonalTraitsDone = existcheck(myCharacter.traits, PersonalTraitsRichBox.Text, PersonalTraitsDone);
            myCharacter.traits = NewValue(PersonalTraitsDone, PersonalTraitsRichBox.Text);
        }
        private void CreateDoneButton_Click(object sender, EventArgs e)
        {

            if (HealthDone && LvlDone && CharacterNameDone && PlayerNameDone && RaceDone && ClassDone &&
               AlignmentDone && BackgroundDone && IdealsDone && BondsDone && FlawsDone && PersonalTraitsDone == true)
            {
                this.Hide();
                Sheet RunCharacterSheet = new Sheet(myCharacter); // laver et nyt sheet baseret på Character Classen
                RunCharacterSheet.Show();
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
        bool existcheck(string OldValue, string NewValue, bool ExistStatus) // tjekker om der er skrevet noget på en linje
        {
            bool OutOfReach = string.IsNullOrEmpty(NewValue);
            if (OutOfReach != true)
            {
                ExistStatus = true;
            }
            else
            {
                ExistStatus = false;
            }
            return ExistStatus;
        }
        string NewValue(bool exists, string UserInput) // giver en lije en ny værdi, hvis værdien ikke er null
        {
            if (exists == true)
            {
                return UserInput;
            }
            return null;
        }
    }


}
