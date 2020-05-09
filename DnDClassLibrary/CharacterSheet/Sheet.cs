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
        List<Item> myInventoryList = new List<Item>();
        String ItemDetails = "{0,-10}{1,-20}";
        String WeaponDetails = "{0,-10}{1,-20}";
        String ArmorDetails = "{0,-10}{1,-20}";

        #region CONSTRUCTORS
        public Sheet(Character charac, CharacterAttributes Attri)
        {
            myCharacter = charac;
            myAttributes = Attri;
            InitializeComponent();
        }

        public Sheet(List<Item> InventoryList)
        {
            myInventoryList = InventoryList;
            InitializeComponent();

        }
        #endregion

        #region SHEETLOAD
        private void Sheet_Load_1(object sender, EventArgs e)
        {
            LoadCharacterInfo();
            LoadAttributes();
            LoadSkills();
        }
        #endregion

        #region CLICKEVENTS
        private void SaveCharacterButton_Click(object sender, EventArgs e)
        {
            DnDDatabaseManagement myDataBase = new DnDDatabaseManagement(myAttributes, myCharacter, myInventoryList);
            myDataBase.SaveCharacterToFile();
            myDataBase.SaveDataToFile();
           
        }

        private void EditInventoryButton_Click(object sender, EventArgs e)
        {
            AddToInventoryForm addToInventory = new AddToInventoryForm(myInventoryList);
            addToInventory.Show();
        }

        private void ShowListItemsButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (var Item in myInventoryList)
            {
                int ID = Item.ItemID;
                if (ID == 1)
                {
                    listBox.Items.Add(Item.ItemID + " " + Item.ItemName);
                }
            }
        }

        private void ShowListArmorButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (var Item in myInventoryList)
            {
                int ID = Item.ItemID;
                if (ID == 2)
                {
                    Armor armor = (Armor)Item; // typecast objectet item over til armor classen
                    listBox.Items.Add(armor.ItemID + " " + armor.ItemName);
                }
            }
        }

        private void ShowListWeaponsButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (var Item in myInventoryList)
            {
                int ID = Item.ItemID;
                if (ID == 3)
                {
                    Weapon weapon = (Weapon)Item;
                    listBox.Items.Add(weapon.ItemID + " " + weapon.ItemName);
                }
            }
        }

        private void UpdateInvButton_Click(object sender, EventArgs e) // ændres
        {
            RunInvList();
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
            PersuasionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PersuasionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Persuasion, PersuasionLabel.Text);
        }
        private void EditSheetCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EditSheetCheck.Checked == true)
            {
                EditSheetTrueWrite();
            }
            else
            {
                EditSheetFalseRead();
                LoadAttributes();
                LoadCharacterInfo();
                LoadSkills();
            }
        }
        #endregion

        #region TEXTCHANGED
        private void TraitsDisplay_TextChanged(object sender, EventArgs e)
        {
            myCharacter.traits = TraitsDisplay.Text;
        }

        private void BondsDisplay_TextChanged(object sender, EventArgs e)
        {
            myCharacter.bonds = BondsDisplay.Text;

        }

        private void IdealsDisplay_TextChanged(object sender, EventArgs e)
        {
            myCharacter.ideals = IdealsDisplay.Text;

        }

        private void FlawsDisplay_TextChanged(object sender, EventArgs e)
        {
            myCharacter.flaws = FlawsDisplay.Text;
        }

        private void BackstoryBox_TextChanged(object sender, EventArgs e)
        {
            myCharacter.backstory = BackstoryBox.Text;
        }

        private void ExperienceDisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ExperienceDisplayTextBox.Text);
            if (OutOfReach == false)
            {
                myCharacter.experience = ExperienceDisplayTextBox.Text;
            }
            else
            {
                ExperienceDisplayTextBox.Text = myCharacter.experience;
                MessageBox.Show("Must have a value");
            }
        }

        private void RaceDisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            myCharacter.race = RaceDisplayTextBox.Text;
        }

        private void ClassDisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            myCharacter.characterClass = ClassDisplayTextBox.Text;
        }

        private void BackgroundDisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            myCharacter.background = BackgroundDisplayTextBox.Text;
        }

        private void AlignmentDisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            myCharacter.alignment = AlignmentDisplayTextBox.Text;
        }

        private void LevelDisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(LevelDisplayTextBox.Text);
            if (OutOfReach == false && Convert.ToInt32(LevelDisplayTextBox.Text) <= 20 && Convert.ToInt32(LevelDisplayTextBox.Text) >= 1)
            {
                myCharacter.level = Convert.ToInt32(LevelDisplayTextBox.Text);
            }
            else
            {
                LevelDisplayTextBox.Text = Convert.ToString(myCharacter.level);
                MessageBox.Show("Level must be within range 1 and 20");
            }
        }

        private void CharismaAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(CharismaAttributeDisplay.Text);
            int Range = 0;
            if (OutOfReach == false)
            {
                Range = Int32.Parse(CharismaAttributeDisplay.Text);
            }
            else
            {
            }
            if (Range >= 0 && Range <= 20)
            {
                myAttributes.Attributes[5] = Convert.ToInt32(Range);
            }
            else
            {
                CharismaAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[5]);
                MessageBox.Show("Strength must be within range 0 and 20");
            }
        }

        private void WisdomAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WisdomAttributeDisplay.Text);
            int Range = 0;
            if (OutOfReach == false)
            {
                Range = Int32.Parse(WisdomAttributeDisplay.Text);
            }
            else
            {
            }
            if (Range >= 0 && Range <= 20)
            {
                myAttributes.Attributes[4] = Convert.ToInt32(Range);
            }
            else
            {
                WisdomAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[4]);
                MessageBox.Show("Wisdom must be within range 0 and 20");
            }
        }

        private void IntelligenceAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(IntelligenceAttributeDisplay.Text);
            int Range = 0;
            if (OutOfReach == false)
            {
                Range = Int32.Parse(IntelligenceAttributeDisplay.Text);
            }
            else
            {
            }
            if (Range >= 0 && Range <= 20)
            {
                myAttributes.Attributes[3] = Convert.ToInt32(Range);
            }
            else
            {
                IntelligenceAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[3]);
                MessageBox.Show("Intelligence must be within range 0 and 20");
            }
        }

        private void ConstitutionAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ConstitutionAttributeDisplay.Text);
            int Range = 0;
            if (OutOfReach == false)
            {
                Range = Int32.Parse(ConstitutionAttributeDisplay.Text);
            }
            else
            {
            }
            if (Range >= 0 && Range <= 20)
            {
                myAttributes.Attributes[2] = Convert.ToInt32(Range);
            }
            else
            {
                ConstitutionAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[2]);
                MessageBox.Show("Constitution must be within range 0 and 20");
            }
        }

        private void DexterityAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DexterityAttributeDisplay.Text);
            int Range = 0;
            if (OutOfReach == false)
            {
                Range = Int32.Parse(DexterityAttributeDisplay.Text);
            }
            else
            {
            }
            if (Range >= 0 && Range <= 20)
            {
                myAttributes.Attributes[1] = Convert.ToInt32(Range);
            }
            else
            {
                DexterityAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[1]);
                MessageBox.Show("Dexterity must be within range 0 and 20");
            }
        }

        private void StrengthAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(StrengthAttributeDisplay.Text);
            int Range = 0;
            if (OutOfReach == false)
            {
                Range = Int32.Parse(StrengthAttributeDisplay.Text);
            }
            else
            {
            }
            if (Range >= 0 && Range <= 20)
            {
                myAttributes.Attributes[0] = Convert.ToInt32(Range);
            }
            else
            {
                StrengthAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[0]);
                MessageBox.Show("Strength must be within range 0 and 20");
            }
        }

        private void SpeedDisplay_TextChanged(object sender, EventArgs e)
        {
            myCharacter.speed = Convert.ToInt32(SpeedDisplay.Text);
        }

        private void MaxHealthDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(MaxHealthDisplay.Text);
            int Health = 0;
            if (OutOfReach == false)
            {
                Health = Int32.Parse(MaxHealthDisplay.Text);
                if (Health >= 1)
                {
                    myCharacter.maxHealth = Convert.ToInt32(Health);
                }
            }
            else
            {
                MaxHealthDisplay.Text = "";
            }
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

        private void ArcanaProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[2] = ArcanaProficiencyToggle.Checked;
            ArcanaLabel.Text = CheckProficiencyToggle(mySkill.Arcana, ArcanaProficiencyToggle.Checked);
        }

        private void HistoryProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[5] = HistoryProficiencyToggle.Checked;
            HistoryLabel.Text = CheckProficiencyToggle(mySkill.History, HistoryProficiencyToggle.Checked);
        }

        private void NatureProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[10] = NatureProficiencyToggle.Checked;
            NatureLabel.Text = CheckProficiencyToggle(mySkill.Nature, NatureProficiencyToggle.Checked);
        }

        private void InvestigationProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[8] = InvestigationProficiencyToggle.Checked;
            InvestigationLabel.Text = CheckProficiencyToggle(mySkill.Investigation, InvestigationProficiencyToggle.Checked);
        }

        private void ReligionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[14] = ReligionProficiencyToggle.Checked;
            ReligionLabel.Text = CheckProficiencyToggle(mySkill.Religion, ReligionProficiencyToggle.Checked);
        }

        private void AnimalHandlingProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[1] = AnimalHandlingProficiencyToggle.Checked;
            AnimalHandlingLabel.Text = CheckProficiencyToggle(mySkill.AnimalHandling, AnimalHandlingProficiencyToggle.Checked);
        }

        private void InsightProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[6] = InsightProficiencyToggle.Checked;
            InsightLabel.Text = CheckProficiencyToggle(mySkill.Insight, InsightProficiencyToggle.Checked);
        }

        private void MedicineProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[9] = MedicineProficiencyToggle.Checked;
            MedicineLabel.Text = CheckProficiencyToggle(mySkill.Medicine, MedicineProficiencyToggle.Checked);
        }

        private void PerceptionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[11] = PerceptionProficiencyToggle.Checked;
            PerceptionLabel.Text = CheckProficiencyToggle(mySkill.Perception, PerceptionProficiencyToggle.Checked);
        }

        private void SurvivalProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[17] = SurvivalProficiencyToggle.Checked;
            SurvivalLabel.Text = CheckProficiencyToggle(mySkill.Survival, SurvivalProficiencyToggle.Checked);
        }

        private void DeceptionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[4] = DeceptionProficiencyToggle.Checked;
            DeceptionLabel.Text = CheckProficiencyToggle(mySkill.Deception, DeceptionProficiencyToggle.Checked);
        }

        private void IntimidationProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[7] = IntimidationProficiencyToggle.Checked;
            IntimidationLabel.Text = CheckProficiencyToggle(mySkill.Intimidation, IntimidationProficiencyToggle.Checked);
        }

        private void PerformanceProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[12] = PerformanceProficiencyToggle.Checked;
            PerformanceLabel.Text = CheckProficiencyToggle(mySkill.Performance, PerformanceProficiencyToggle.Checked);
        }

        private void PersuasionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[13] = PersuasionProficiencyToggle.Checked;
            PersuasionLabel.Text = CheckProficiencyToggle(mySkill.Persuasion, PersuasionProficiencyToggle.Checked);
        }
        #endregion

        #region KEYPRESSEVENTS
        private void LevelDisplayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void CharismaAttributeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void WisdomAttributeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void IntelligenceAttributeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void ConstitutionAttributeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void DexterityAttributeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void StrengthAttributeDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void SpeedDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void MaxHealthDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void ExperienceDisplayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
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

        public void RunInvList()
        {
            listBox.Items.Clear();
            foreach (var Item in myInventoryList)
            {
                int ID = Item.ItemID;
                switch (ID)
                {
                    case 1:
                        listBox.Items.Add(Item.ItemID + " " + Item.ItemName);
                        break;
                    case 2:
                        Armor armor = (Armor)Item; // typecast objectet item over til armor classen
                        listBox.Items.Add(Item);
                        break;

                    case 3:
                        Weapon weapon = (Weapon)Item;
                        listBox.Items.Add(Item);
                        break;
                }
            }

        } // fjernes

        void LoadAttributes()
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);

            StrengthAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[0]);
            DexterityAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[1]);
            ConstitutionAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[2]);
            IntelligenceAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[3]);
            WisdomAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[4]);
            CharismaAttributeDisplay.Text = Convert.ToString(myAttributes.Attributes[5]);

            StrengthModifierLabel.Text = Convert.ToString(myAttributes.Modifiers[0]);
            DexterityModifierLabel.Text = Convert.ToString(myAttributes.Modifiers[1]);
            ConstitutionModifierLabel.Text = Convert.ToString(myAttributes.Modifiers[2]);
            IntelligenceModifierLabel.Text = Convert.ToString(myAttributes.Modifiers[3]);
            WisdomModifierLabel.Text = Convert.ToString(myAttributes.Modifiers[4]);
            CharismaModifierLabel.Text = Convert.ToString(myAttributes.Modifiers[5]);

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
            ArcanaLabel.Text = Convert.ToString(mySkill.Arcana);
            HistoryLabel.Text = Convert.ToString(mySkill.History);
            InvestigationLabel.Text = Convert.ToString(mySkill.Investigation);
            NatureLabel.Text = Convert.ToString(mySkill.Nature);
            ReligionLabel.Text = Convert.ToString(mySkill.Religion);
            AnimalHandlingLabel.Text = Convert.ToString(mySkill.AnimalHandling);
            InsightLabel.Text = Convert.ToString(mySkill.Insight);
            MedicineLabel.Text = Convert.ToString(mySkill.Medicine);
            PerceptionLabel.Text = Convert.ToString(mySkill.Perception);
            SurvivalLabel.Text = Convert.ToString(mySkill.Survival);
            DeceptionLabel.Text = Convert.ToString(mySkill.Deception);
            IntimidationLabel.Text = Convert.ToString(mySkill.Intimidation);
            PerformanceLabel.Text = Convert.ToString(mySkill.Performance);
            PersuasionLabel.Text = Convert.ToString(mySkill.Persuasion);

            JackOfAllTradesCheck.CheckStateChanged += JackOfAllTradesCheck_CheckedChanged;
            AthleticsProficiencyToggle.CheckStateChanged += AthleticsProficiencyToggle_CheckedChanged;
            AcrobaticsProficiencyToggle.CheckStateChanged += AcrobaticsProficiencyToggle_CheckedChanged;
            SleightOfHandProficiencyToggle.CheckStateChanged += SleightOfHandProficiencyToggle_CheckedChanged;
            StealthProficiencyToggle.CheckStateChanged += StealthProficiencyToggle_CheckedChanged;
            ArcanaProficiencyToggle.CheckStateChanged += ArcanaProficiencyToggle_CheckedChanged;
            HistoryProficiencyToggle.CheckStateChanged += HistoryProficiencyToggle_CheckedChanged;
            InvestigationProficiencyToggle.CheckStateChanged += InvestigationProficiencyToggle_CheckedChanged;
            NatureProficiencyToggle.CheckStateChanged += NatureProficiencyToggle_CheckedChanged;
            ReligionProficiencyToggle.CheckStateChanged += ReligionProficiencyToggle_CheckedChanged;
            AnimalHandlingProficiencyToggle.CheckStateChanged += AnimalHandlingProficiencyToggle_CheckedChanged;
            InsightProficiencyToggle.CheckStateChanged += InsightProficiencyToggle_CheckedChanged;
            MedicineProficiencyToggle.CheckStateChanged += MedicineProficiencyToggle_CheckedChanged;
            PerceptionProficiencyToggle.CheckStateChanged += PerceptionProficiencyToggle_CheckedChanged;
            SurvivalProficiencyToggle.CheckStateChanged += SurvivalProficiencyToggle_CheckedChanged;
            DeceptionProficiencyToggle.CheckStateChanged += DeceptionProficiencyToggle_CheckedChanged;
            IntimidationProficiencyToggle.CheckStateChanged += IntimidationProficiencyToggle_CheckedChanged;
            PerformanceProficiencyToggle.CheckStateChanged += PerformanceProficiencyToggle_CheckedChanged;
            PersuasionProficiencyToggle.CheckStateChanged += PersuasionProficiencyToggle_CheckedChanged;

        }

        void LoadCharacterInfo()
        {
            RaceDisplayTextBox.Text = myCharacter.race;
            LevelDisplayTextBox.Text = Convert.ToString(myCharacter.level);
            AlignmentDisplayTextBox.Text = myCharacter.alignment;
            ClassDisplayTextBox.Text = myCharacter.characterClass;
            BackgroundDisplayTextBox.Text = myCharacter.background;
            ExperienceDisplayTextBox.Text = "0";

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

        void OnlyTakeNumbers(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void EditSheetTrueWrite()
        {
            RaceDisplayTextBox.Enabled = true;
            ClassDisplayTextBox.Enabled = true;
            BackgroundDisplayTextBox.Enabled = true;
            AlignmentDisplayTextBox.Enabled = true;
            ExperienceDisplayTextBox.Enabled = true;
            LevelDisplayTextBox.Enabled = true;

            StrengthAttributeDisplay.Enabled = true;
            DexterityAttributeDisplay.Enabled = true;
            ConstitutionAttributeDisplay.Enabled = true;
            IntelligenceAttributeDisplay.Enabled = true;
            WisdomAttributeDisplay.Enabled = true;
            CharismaAttributeDisplay.Enabled = true;

            MaxHealthDisplay.Enabled = true;
            SpeedDisplay.Enabled = true;

            IdealsDisplay.Enabled = true;
            BondsDisplay.Enabled = true;
            TraitsDisplay.Enabled = true;
            FlawsDisplay.Enabled = true;
            BackgroundDisplayTextBox.Enabled = true;
        }

        void EditSheetFalseRead()
        {
            RaceDisplayTextBox.Enabled = false;
            ClassDisplayTextBox.Enabled = false;
            BackgroundDisplayTextBox.Enabled = false;
            AlignmentDisplayTextBox.Enabled = false;
            ExperienceDisplayTextBox.Enabled = false;
            LevelDisplayTextBox.Enabled = false;

            StrengthAttributeDisplay.Enabled = false;
            DexterityAttributeDisplay.Enabled = false;
            ConstitutionAttributeDisplay.Enabled = false;
            IntelligenceAttributeDisplay.Enabled = false;
            WisdomAttributeDisplay.Enabled = false;
            CharismaAttributeDisplay.Enabled = false;

            MaxHealthDisplay.Enabled = false;
            SpeedDisplay.Enabled = false;

            IdealsDisplay.Enabled = false;
            BondsDisplay.Enabled = false;
            TraitsDisplay.Enabled = false;
            FlawsDisplay.Enabled = false;
            BackgroundDisplayTextBox.Enabled = false;
        }

        #endregion
    }
}
