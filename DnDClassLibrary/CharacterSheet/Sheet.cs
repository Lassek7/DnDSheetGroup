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
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();
        public Sheet(Character charac, CharacterAttributes Attri) 
        {
            myCharacter = charac;
            myAttributes = Attri;
            InitializeComponent();
 
        }

        private void Sheet_Load(object sender, EventArgs e) //slettes måske????? idk what it is
        {
        }
        
        private void Sheet_Load_1(object sender, EventArgs e)
        {
            LoadCharacterInfo();

        }

        private void groupBox3_Enter(object sender, EventArgs e)    //slettes
        {

        }
      
        void LoadCharacterInfo()
        {
            RaceLabel.Text = myCharacter.race;
            LevelLabel.Text = Convert.ToString(myCharacter.level);
            AlignmentLabel.Text = myCharacter.alignment;
            ClassLabel.Text = myCharacter.characterClass;
            BackgroundLabel.Text = myCharacter.background;

            CharacterNameLabel.Text = myCharacter.characterName;
            BondsDisplay.Text = myCharacter.bonds;
            FlawsDisplay.Text = myCharacter.flaws;
            IdealsDisplay.Text = myCharacter.ideals;
            TraitsDisplay.Text = myCharacter.traits;
            MaxHealthDisplay.Text = Convert.ToString(myCharacter.maxHealth);


            ProficiencyBonusDisplay.Text = Convert.ToString(myCharacter.ProficiencyCalc(myCharacter.level));
        }
        void LoadAttributes()
        {
            StrengthAttributeDisplay.Text = Convert.ToString(myAttributes.Modifiers[0]);
            DexterityAttributeDisplay.Text = Convert.ToString(myCharacter.dexterity);
            ConstitutionAttributeDisplay.Text = Convert.ToString(myCharacter.constitution);
            IntelligenceAttributeDisplay.Text = Convert.ToString(myCharacter.intelligence);
            WisdomAttributeDisplay.Text = Convert.ToString(myCharacter.wisdom);
            CharismaAttributeDisplay.Text = Convert.ToString(myCharacter.charisma);
        }
        void LoadSkills()
        {

        }
    }
}
