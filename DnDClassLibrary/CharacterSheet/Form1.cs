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
            Character.playerName = CharacterNameBox.Text;
        }

        private void RaceBox_TextChanged(object sender, EventArgs e)
        {
            Character.race = CharacterNameBox.Text;
        }

        private void ClassBox_TextChanged(object sender, EventArgs e)
        {
            Character.clas = CharacterNameBox.Text;

        }

        private void LevelBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AlignmentBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaxHealthBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IdealsRichBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BondsRichBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FlawsRichBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PersonalTraitsRichBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void CreateDoneButton_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show(Character.characterName);

        }
    }
}
