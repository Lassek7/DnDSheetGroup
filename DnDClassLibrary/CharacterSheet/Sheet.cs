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
    public partial class Sheet : Form
    {
        Character myCharacter = new Character();        
        public Sheet(Character charac) 
        {
            myCharacter = charac;
            InitializeComponent();
        }

        private void Sheet_Load(object sender, EventArgs e)
        {
    
        }
        
        private void Sheet_Load_1(object sender, EventArgs e)
        {

            RaceLabel.Text = myCharacter.race;
            LevelLabel.Text = Convert.ToString((myCharacter.level));
            AlignmentLabel.Text = myCharacter.alignment;
            ClassLabel.Text = myCharacter.characterClass;
            BackgroundLabel.Text = myCharacter.background;
            CharacterNameLabel.Text = myCharacter.characterName;
            

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void RaceLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
