using System;
using System.Collections;
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
        List<Item> InventoryList = new List<Item>();

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
            LoadAttributes();
            LoadSkills();
        }
        #region CLICKEVENTS
        private void SaveCharacterButton_Click(object sender, EventArgs e)
        {
            DnDDatabaseManagement myDataBase = new DnDDatabaseManagement(myAttributes, myCharacter, InventoryList);
            // myDataBase.SaveDataToFile();
           
        }
        private void EditInventoryButton_Click(object sender, EventArgs e)
        {
            AddToInventoryForm addToInventory = new AddToInventoryForm(InventoryList);
            addToInventory.Show();
        }

        private void UpdateInvButton_Click(object sender, EventArgs e)
        {
            RunInvList();
            InventoryList.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        #endregion
        #region SAVINGTHROWPROFICIENCYTOGGLES
        private void StrengthSaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
            mySavingthrow.proficiency[0] = StrengthSaveProficiencyToggle.Checked;
            StrengthSaveLabel.Text = CheckProficiencyToggle(mySavingthrow.StrengthSave, StrengthSaveProficiencyToggle.Checked);
        }

        private void DexteritySaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
            mySavingthrow.proficiency[1] = DexteritySaveProficiencyToggle.Checked;
            DexteritySaveLabel.Text = CheckProficiencyToggle(mySavingthrow.DexteritySave, DexteritySaveProficiencyToggle.Checked);
        }

        private void ConstitutionSaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
            mySavingthrow.proficiency[2] = ConstitutionSaveProficiencyToggle.Checked;
            ConstitutionSaveLabel.Text = CheckProficiencyToggle(mySavingthrow.ConstitutionSave, ConstitutionSaveProficiencyToggle.Checked);
        }

        private void IntelligenceSaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
            mySavingthrow.proficiency[3] = IntelligenceSaveProficiencyToggle.Checked;
            IntelligenceSaveLabel.Text = CheckProficiencyToggle(mySavingthrow.IntelligenceSave, IntelligenceSaveProficiencyToggle.Checked);
        }

        private void WisdomSaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
            mySavingthrow.proficiency[4] = WisdomSaveProficiencyToggle.Checked;
            WisdomSaveLabel.Text = CheckProficiencyToggle(mySavingthrow.WisdomSave, WisdomSaveProficiencyToggle.Checked);
        }

        private void CharismaSaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
            mySavingthrow.proficiency[5] = CharismaSaveProficiencyToggle.Checked;
            CharismaSaveLabel.Text = CheckProficiencyToggle(mySavingthrow.CharismaSave, CharismaSaveProficiencyToggle.Checked);   
        }
        #endregion
        #region CHECKCHANGED
        private void JackOfAllTradesCheck_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            
            AthleticsLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AthleticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Athletics, AthleticsLabel.Text);
            AcrobaticsLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AcrobaticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Acrobatics, AcrobaticsLabel.Text);
            SleightOfHandLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SleightOfHandProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.SleightOfHand, SleightOfHandLabel.Text);
            StealthLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, StealthProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Stealth, StealthLabel.Text);
            ArcanaLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ArcanaProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Arcana, ArcanaLabel.Text);
            HistoryLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, HistoryProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.History, HistoryLabel.Text);
            InvestigationLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InvestigationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Investigation, InvestigationLabel.Text);
            NatureLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, NatureProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Nature, NatureLabel.Text);
            ReligionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ReligionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Religion, ReligionLabel.Text);
            AnimalHandlingLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AnimalHandlingProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.AnimalHandling, AnimalHandlingLabel.Text);
            InsightLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InsightProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Insight, InsightLabel.Text);
            MedicineLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, MedicineProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Medicine, MedicineLabel.Text);
            PerceptionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PerceptionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Perception, PerceptionLabel.Text);
            SurvivalLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SurvivalProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Survival, SurvivalLabel.Text);
            DeceptionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, DeceptionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Deception, DeceptionLabel.Text);
            IntimidationLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, IntimidationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Intimidation, IntimidationLabel.Text);
            PerformanceLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PerformanceProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Performance, PerformanceLabel.Text);
            PersuasionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PersuationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Persuasion, PersuasionLabel.Text);       //Stavefejl i ProficiencyToggle
        }
        #endregion
        #region SKILLPROFICIENCYTOGGLE
        private void AthleticsProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[3] = AthleticsProficiencyToggle.Checked;
            AthleticsLabel.Text = CheckProficiencyToggle(mySkill.Athletics, AthleticsProficiencyToggle.Checked);
        }

        private void AcrobaticsProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[0] = AcrobaticsProficiencyToggle.Checked;
            AcrobaticsLabel.Text = CheckProficiencyToggle(mySkill.Acrobatics, AthleticsProficiencyToggle.Checked);
        }

        private void SleightOfHandProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[15] = SleightOfHandProficiencyToggle.Checked;
            SleightOfHandLabel.Text = CheckProficiencyToggle(mySkill.SleightOfHand, AthleticsProficiencyToggle.Checked);
        }

        private void StealthProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[16] = StealthProficiencyToggle.Checked;
            StealthLabel.Text = CheckProficiencyToggle(mySkill.Stealth, AthleticsProficiencyToggle.Checked);
        }

        #endregion
        #region METHODS
        string CheckJackOfAllTradesToggle(int HalfBonus, bool ProficiencyToggle, bool JackToggle, int OldValue, string CurrentValue)
        {
            int NewValue = HalfBonus / 2 + OldValue;//Skal lige laves til en float og tilføjes en if statement for at undgå komma tal.
            if (ProficiencyToggle == false && JackToggle == true)
            {
                return Convert.ToString(NewValue);
            }
            else if (ProficiencyToggle == true && JackToggle == true)
            {
                return Convert.ToString(CurrentValue);
            }
            else if (ProficiencyToggle == true && JackToggle == false)
            {
                return Convert.ToString(CurrentValue);
            }
            else
            {
                return Convert.ToString(OldValue);
            }
        }

        string CheckProficiencyToggle(int SavingthrowSave, bool ProficiencyToggle)
        {
            if (ProficiencyToggle == false)
            {
                return Convert.ToString(SavingthrowSave);
            }
            else
            {
                return Convert.ToString(SavingthrowSave);
            }
        }

        void RunInvList()
        {
            listBox1.Items.Clear();
            foreach (var Item in InventoryList)
            {
                int ID = Item.ItemID;
                switch (ID)
                {
                    case 1:
                        listBox1.Items.Add(Item.ItemID + " " + Item.ItemName);
                        break;
                    case 2:
                        Armor armor = (Armor)Item; // typecast objectet item over til armor classen
                        listBox1.Items.Add(Item);
                        break;

                    case 3:
                        Weapon weapon = (Weapon)Item;
                        listBox1.Items.Add(Item);
                        break;
                }
            }

        }

        void LoadAttributes()
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);

            StrengthAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[0]);
            DexterityAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[1]);
            ConstitutionAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[2]);
            IntelligenceAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[3]);
            WisdomAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[4]);
            CharismaAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[5]);

            StrengthSaveLabel.Text = Convert.ToString(mySavingthrow.StrengthSave);
            DexteritySaveLabel.Text = Convert.ToString(mySavingthrow.DexteritySave);
            ConstitutionSaveLabel.Text = Convert.ToString(mySavingthrow.ConstitutionSave);
            IntelligenceSaveLabel.Text = Convert.ToString(mySavingthrow.IntelligenceSave);
            WisdomSaveLabel.Text = Convert.ToString(mySavingthrow.WisdomSave);
            CharismaSaveLabel.Text = Convert.ToString(mySavingthrow.CharismaSave);

            StrengthSaveProficiencyToggle.CheckStateChanged += StrengthSaveProficiencyToggle_CheckedChanged;
            DexteritySaveProficiencyToggle.CheckStateChanged += DexteritySaveProficiencyToggle_CheckedChanged;
            ConstitutionSaveProficiencyToggle.CheckStateChanged += ConstitutionSaveProficiencyToggle_CheckedChanged;
            IntelligenceSaveProficiencyToggle.CheckStateChanged += IntelligenceSaveProficiencyToggle_CheckedChanged;
            WisdomSaveProficiencyToggle.CheckStateChanged += WisdomSaveProficiencyToggle_CheckedChanged;
            CharismaSaveProficiencyToggle.CheckStateChanged += CharismaSaveProficiencyToggle_CheckedChanged;
        }

        void LoadSkills()
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);

            AthleticsLabel.Text = Convert.ToString(mySkill.Athletics);
            AcrobaticsLabel.Text = Convert.ToString(mySkill.Acrobatics);
            SleightOfHandLabel.Text = Convert.ToString(mySkill.SleightOfHand);
            StealthLabel.Text = Convert.ToString(mySkill.Stealth);

            JackOfAllTradesCheck.CheckStateChanged += JackOfAllTradesCheck_CheckedChanged;
            AthleticsProficiencyToggle.CheckStateChanged += AthleticsProficiencyToggle_CheckedChanged;
            AcrobaticsProficiencyToggle.CheckStateChanged += AcrobaticsProficiencyToggle_CheckedChanged;
            SleightOfHandProficiencyToggle.CheckStateChanged += SleightOfHandProficiencyToggle_CheckedChanged;
            StealthProficiencyToggle.CheckStateChanged += StealthProficiencyToggle_CheckedChanged;

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
            PassivePerceptionDisplay.Text = Convert.ToString(myAttributes.Modifiers[4] + 10);
            InitiativeDisplay.Text = Convert.ToString(myAttributes.Modifiers[1]);
            myCharacter.proficiencyBonus = Convert.ToInt32(ProficiencyBonusDisplay.Text);
        }
        #endregion
    }
}
