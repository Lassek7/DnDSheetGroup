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
        EquippedItems myEquippedItems = new EquippedItems();
        Item myItem = new Item();
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
            LoadEquippedItems();
            LoadInventory();
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
            AddToInventoryForm addToInventory = new AddToInventoryForm(myInventoryList, myAttributes, myEquippedItems);
            addToInventory.Show();
        }

        private void ShowListItemsButton_Click(object sender, EventArgs e)
        {
            InventoryListView.Items.Clear();
            int i = 0;
            foreach (var Item in myInventoryList)
            {
                if (Item.ItemID == 1)
                {
                    InventoryListView.Items.Add(Item.ItemName, i);
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(Item.AmountHeld));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(Item.WeightPerItem));
                    i++;
                }
                else
                {
                }
            }
        }
        private void ShowListArmorButton_Click(object sender, EventArgs e)
        {
           InventoryListView.Items.Clear();
           int i = 0;
           foreach (var Item in myInventoryList)
            {
                
                if (Item.ItemID == 2)
                {
                    Armor armor = (Armor)Item;
                    InventoryListView.Items.Add(armor.ItemName, i);
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.AmountHeld));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.WeightPerItem));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.ACFromArmor));
                    i++;
                }
                else
                {
                }
            }
        }

        private void ShowListWeaponsButton_Click(object sender, EventArgs e)
        {
           InventoryListView.Items.Clear();
           int i = 0;
           foreach (var Item in myInventoryList)
           {
                if (Item.ItemID == 3)
                {
                    Weapon weapon = (Weapon)Item;
                    InventoryListView.Items.Add(weapon.ItemName, i);
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.AmountHeld));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.WeightPerItem));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.Damage));
                    i++;
                 }
                else
                {
                }
            }
        }
        private void RemoveSlotOne_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponOneName = "";
            myEquippedItems.WeaponOneAttributeAssociation = "";
            myEquippedItems.WeaponOneDamageType = "";
            myEquippedItems.WeaponOneDamage = "";

            WeaponSlotOneProficiency.Checked = false;
            LoadEquippedItems();
        }

        private void RemoveSlotTwo_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponTwoName = "";
            myEquippedItems.WeaponTwoAttributeAssociation = "";
            myEquippedItems.WeaponTwoDamageType = "";
            myEquippedItems.WeaponTwoDamage = "";

            WeaponSlotTwoProficiency.Checked = false;
            LoadEquippedItems();
        }

        private void RemoveSlotThree_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponThreeName = "";
            myEquippedItems.WeaponThreeAttributeAssociation = "";
            myEquippedItems.WeaponThreeDamageType = "";
            myEquippedItems.WeaponThreeDamage = "";

            WeaponSlotThreeProficiency.Checked = false;
            LoadEquippedItems();
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
                LoadEquippedItems();
            }
        }
        #endregion
        private void JackOfAllTradesCheck_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);

            AthleticsLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AthleticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Athletics, AthleticsLabel.Text);
            AcrobaticsLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AcrobaticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Acrobatics, AcrobaticsLabel.Text);
            SleightOfHandLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SleightOfHandProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.SleightOfHand, SleightOfHandLabel.Text);
            StealthLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, StealthProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Stealth, StealthLabel.Text);
            ArcanaLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ArcanaProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Arcana, ArcanaLabel.Text);
            HistoryLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, HistoryProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.History, HistoryLabel.Text);
            NatureLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, NatureProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Nature, NatureLabel.Text);
            InvestigationLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InvestigationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Investigation, InvestigationLabel.Text);
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

        private void ShieldEquippedCheck_CheckedChanged(object sender, EventArgs e)
        {
            myEquippedItems.shieldEquipped = ShieldEquippedCheck.Checked;
            LoadEquippedItems();
        }

        private void WeaponSlotOneProficiency_CheckedChanged(object sender, EventArgs e)
        {
            LoadEquippedItems();
        }

        private void WeaponSlotTwoProficiency_CheckedChanged(object sender, EventArgs e)
        {
            LoadEquippedItems();
        }

        private void WeaponSlotThreeProficiency_CheckedChanged(object sender, EventArgs e)
        {
            LoadEquippedItems();
        }



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
        private void CopperCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(CopperCoinsDisplay.Text);
            if (OutOfReach == false)
            {
                myItem.Copper = Convert.ToInt32(CopperCoinsDisplay.Text);
            }
            else
            {
                myItem.Copper = myItem.Copper;
            }
        }

        private void SilverCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(SilverCoinsDisplay.Text);
            if (OutOfReach == false)
            {
                myItem.Silver = Convert.ToInt32(SilverCoinsDisplay.Text);
            }
            else
            {
                myItem.Silver = myItem.Silver;
            }
        }

        private void ElectrumCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ElectrumCoinsDisplay.Text);
            if (OutOfReach == false)
            {
                myItem.Electrum = Convert.ToInt32(ElectrumCoinsDisplay.Text);
            }
            else
            {
                myItem.Electrum = myItem.Electrum;
            }
        }

        private void GoldCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(GoldCoinsDisplay.Text);
            if (OutOfReach == false)
            {
                myItem.Gold = Convert.ToInt32(GoldCoinsDisplay.Text);
            }
            else
            {
                myItem.Gold = myItem.Gold;
            }
        }

        private void PlatinumCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(PlatinumCoinsDisplay.Text);
            if (OutOfReach == false)
            {
                myItem.Platinum = Convert.ToInt32(PlatinumCoinsDisplay.Text);
            }
            else
            {
                myItem.Gold = myItem.Platinum;
            }
        }
        #endregion

        #region SKILLPROFICIENCYTOGGLE
        private void AthleticsProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[3] = AthleticsProficiencyToggle.Checked;
            if (AthleticsProficiencyToggle.Checked == true)
            {
                AthleticsLabel.Text = CheckProficiencyToggle(mySkill.Athletics, AthleticsProficiencyToggle.Checked);
            }
            else
            {
                AthleticsLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AthleticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Athletics, AthleticsLabel.Text);
            }

        }

        private void AcrobaticsProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[0] = AcrobaticsProficiencyToggle.Checked;
            if (AcrobaticsProficiencyToggle.Checked == true)
            {
                AcrobaticsLabel.Text = CheckProficiencyToggle(mySkill.Acrobatics, AcrobaticsProficiencyToggle.Checked);
            }
            else
            {
                AcrobaticsLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AcrobaticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Acrobatics, AcrobaticsLabel.Text);
            }
        }

        private void SleightOfHandProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[15] = SleightOfHandProficiencyToggle.Checked;
            if (SleightOfHandProficiencyToggle.Checked == true)
            {
                SleightOfHandLabel.Text = CheckProficiencyToggle(mySkill.SleightOfHand, SleightOfHandProficiencyToggle.Checked);
            }
            else
            {
                SleightOfHandLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SleightOfHandProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.SleightOfHand, SleightOfHandLabel.Text);
            }
        }

        private void StealthProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[16] = StealthProficiencyToggle.Checked;
            if (StealthProficiencyToggle.Checked == true)
            {
                StealthLabel.Text = CheckProficiencyToggle(mySkill.Stealth, StealthProficiencyToggle.Checked);
            }
            else
            {
                StealthLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, StealthProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Stealth, StealthLabel.Text);
            }
        }

        private void ArcanaProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[2] = ArcanaProficiencyToggle.Checked;
            if (ArcanaProficiencyToggle.Checked == true)
            {
                ArcanaLabel.Text = CheckProficiencyToggle(mySkill.Arcana, ArcanaProficiencyToggle.Checked);
            }
            else
            {
                ArcanaLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ArcanaProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Arcana, ArcanaLabel.Text);
            }
        }

        private void HistoryProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[5] = HistoryProficiencyToggle.Checked;
            if (HistoryProficiencyToggle.Checked == true)
            {
                HistoryLabel.Text = CheckProficiencyToggle(mySkill.History, HistoryProficiencyToggle.Checked);
            }
            else
            {
                HistoryLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, HistoryProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.History, HistoryLabel.Text);
            }
        }

        private void NatureProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[10] = NatureProficiencyToggle.Checked;
            NatureLabel.Text = CheckProficiencyToggle(mySkill.Nature, NatureProficiencyToggle.Checked);
            if (NatureProficiencyToggle.Checked == true)
            {
                NatureLabel.Text = CheckProficiencyToggle(mySkill.Nature, NatureProficiencyToggle.Checked);
            }
            else
            {
                NatureLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, NatureProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Nature, NatureLabel.Text);
            }
        }

        private void InvestigationProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[8] = InvestigationProficiencyToggle.Checked;
            if (InvestigationProficiencyToggle.Checked == true)
            {
                InvestigationLabel.Text = CheckProficiencyToggle(mySkill.Investigation, InvestigationProficiencyToggle.Checked);
            }
            else
            {
                InvestigationLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InvestigationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Investigation, InvestigationLabel.Text);
            }
        }

        private void ReligionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[14] = ReligionProficiencyToggle.Checked;
            if (ReligionProficiencyToggle.Checked == true)
            {
                ReligionLabel.Text = CheckProficiencyToggle(mySkill.Religion, ReligionProficiencyToggle.Checked);
            }
            else
            {
                ReligionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ReligionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Religion, ReligionLabel.Text);
            }
        }

        private void AnimalHandlingProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[1] = AnimalHandlingProficiencyToggle.Checked;
            if (AnimalHandlingProficiencyToggle.Checked == true)
            {
                AnimalHandlingLabel.Text = CheckProficiencyToggle(mySkill.AnimalHandling, AnimalHandlingProficiencyToggle.Checked);
            }
            else
            {
                AnimalHandlingLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AnimalHandlingProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.AnimalHandling, AnimalHandlingLabel.Text);
            }
        }

        private void InsightProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[6] = InsightProficiencyToggle.Checked;
            if (InsightProficiencyToggle.Checked == true)
            {
                InsightLabel.Text = CheckProficiencyToggle(mySkill.Insight, InsightProficiencyToggle.Checked);
            }
            else
            {
                InsightLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InsightProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Insight, InsightLabel.Text);
            }
        }

        private void MedicineProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[9] = MedicineProficiencyToggle.Checked;
            if (MedicineProficiencyToggle.Checked == true)
            {
                MedicineLabel.Text = CheckProficiencyToggle(mySkill.Medicine, MedicineProficiencyToggle.Checked);
            }
            else
            {
                MedicineLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, MedicineProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Medicine, MedicineLabel.Text);
            }
        }

        private void PerceptionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[11] = PerceptionProficiencyToggle.Checked;
            if (PerceptionProficiencyToggle.Checked == true)
            {
                PerceptionLabel.Text = CheckProficiencyToggle(mySkill.Perception, PerceptionProficiencyToggle.Checked);
            }
            else
            {
                PerceptionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PerceptionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Perception, PerceptionLabel.Text);
            }
        }

        private void SurvivalProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[17] = SurvivalProficiencyToggle.Checked;
            if (SurvivalProficiencyToggle.Checked == true)
            {
                SurvivalLabel.Text = CheckProficiencyToggle(mySkill.Survival, SurvivalProficiencyToggle.Checked);
            }
            else
            {
                SurvivalLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SurvivalProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Survival, SurvivalLabel.Text);
            }
        }

        private void DeceptionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[4] = DeceptionProficiencyToggle.Checked;
            if (DeceptionProficiencyToggle.Checked == true)
            {
                DeceptionLabel.Text = CheckProficiencyToggle(mySkill.Deception, DeceptionProficiencyToggle.Checked);
            }
            else
            {
                DeceptionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, DeceptionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Deception, DeceptionLabel.Text);
            }
        }

        private void IntimidationProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[7] = IntimidationProficiencyToggle.Checked;
            if (IntimidationProficiencyToggle.Checked == true)
            {
                IntimidationLabel.Text = CheckProficiencyToggle(mySkill.Intimidation, IntimidationProficiencyToggle.Checked);
            }
            else
            {
                IntimidationLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, IntimidationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Intimidation, IntimidationLabel.Text);
            }
        }

        private void PerformanceProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[12] = PerformanceProficiencyToggle.Checked;
            if (PerformanceProficiencyToggle.Checked == true)
            {
                PerformanceLabel.Text = CheckProficiencyToggle(mySkill.Performance, PerformanceProficiencyToggle.Checked);
            }
            else
            {
                PerformanceLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PerformanceProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Performance, PerformanceLabel.Text);
            }
        }

        private void PersuasionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[13] = PersuasionProficiencyToggle.Checked;
            if (PersuasionProficiencyToggle.Checked == true)
            {
                PersuasionLabel.Text = CheckProficiencyToggle(mySkill.Persuasion, PersuasionProficiencyToggle.Checked);
            }
            else
            {
                PersuasionLabel.Text = CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PersuasionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Persuasion, PersuasionLabel.Text);
            }
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

        private void CopperCoinsDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void SilverCoinsDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void ElectrumCoinsDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void GoldCoinsDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void PlatinumCoinsDisplay_KeyPress(object sender, KeyPressEventArgs e)
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

        void LoadEquippedItems()
        {
            WeaponSlotOneNameDisplay.Text = myEquippedItems.WeaponOneName;
            WeaponSlotOneATKBonusDisplay.Text = Convert.ToString(myEquippedItems.AtkBonusCalc(myEquippedItems.WeaponOneAttributeAssociation, WeaponSlotOneProficiency.Checked, myCharacter.proficiencyBonus, myAttributes.Modifiers[0], myAttributes.Modifiers[1], myAttributes.Modifiers[2], myAttributes.Modifiers[3], myAttributes.Modifiers[4], myAttributes.Modifiers[5]));
            WeaponSlotOneDamageDisplay.Text = myEquippedItems.WeaponOneDamage;
            WeaponSlotOneDamageTypeDisplay.Text = myEquippedItems.WeaponOneDamageType;

            WeaponSlotTwoNameDisplay.Text = myEquippedItems.WeaponTwoName;
            WeaponSlotTwoATKBonusDisplay.Text = Convert.ToString(myEquippedItems.AtkBonusCalc(myEquippedItems.WeaponTwoAttributeAssociation, WeaponSlotTwoProficiency.Checked, myCharacter.proficiencyBonus, myAttributes.Modifiers[0], myAttributes.Modifiers[1], myAttributes.Modifiers[2], myAttributes.Modifiers[3], myAttributes.Modifiers[4], myAttributes.Modifiers[5]));
            WeaponSlotTwoDamageDisplay.Text = myEquippedItems.WeaponTwoDamage;
            WeaponSlotTwoDamageTypeDisplay.Text = myEquippedItems.WeaponTwoDamageType;

            WeaponSlotThreeNameDisplay.Text = myEquippedItems.WeaponThreeName;
            WeaponSlotThreeATKBonusDisplay.Text = Convert.ToString(myEquippedItems.AtkBonusCalc(myEquippedItems.WeaponThreeAttributeAssociation, WeaponSlotThreeProficiency.Checked, myCharacter.proficiencyBonus, myAttributes.Modifiers[0], myAttributes.Modifiers[1], myAttributes.Modifiers[2], myAttributes.Modifiers[3], myAttributes.Modifiers[4], myAttributes.Modifiers[5]));
            WeaponSlotThreeDamageDisplay.Text = myEquippedItems.WeaponThreeDamage;
            WeaponSlotThreeDamageTypeDisplay.Text = myEquippedItems.WeaponThreeDamageType;

            EquippedArmorDisplay.Text = myEquippedItems.ArmorSlotChest;
            ArmorClassDisplay.Text = Convert.ToString(myEquippedItems.ACBonusCalc(myEquippedItems.ACFromArmor, myEquippedItems.shieldEquipped, myAttributes.Modifiers[1]));

        }

        void LoadInventory()
        {
            CopperCoinsDisplay.Text = Convert.ToString(myItem.Copper);
            SilverCoinsDisplay.Text = Convert.ToString(myItem.Silver);
            ElectrumCoinsDisplay.Text = Convert.ToString(myItem.Electrum);
            GoldCoinsDisplay.Text = Convert.ToString(myItem.Gold);
            PlatinumCoinsDisplay.Text = Convert.ToString(myItem.Platinum);
        }



        #endregion

        private void CurrentHitPointsDisplay_ValueChanged(object sender, EventArgs e)
        {
            CurrentHitPointsDisplay.Maximum = Convert.ToInt32(MaxHealthDisplay.Text);

            if (CurrentHitPointsDisplay.Value > Convert.ToInt32(MaxHealthDisplay.Text))
            {
                CurrentHitPointsDisplay.Value = 12;

            }
            else if (CurrentHitPointsDisplay.Value < 0) 
            {
                CurrentHitPointsDisplay.Value = 0;
            }
            myCharacter.currentHealth = Convert.ToInt32(CurrentHitPointsDisplay.Value);
        }

        void RunInvList()
        {
            InventoryListView.Items.Clear();
            int i = 0;
            foreach (var Item in myInventoryList)
            {
                int ID = Item.ItemID;


                switch (Item.ItemID)
                {
                    case 1:
                        InventoryListView.Items.Add(Item.ItemName, i);
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(Item.AmountHeld));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(Item.WeightPerItem));
                        i++;
                        break;
                    case 2:
                        Armor armor = (Armor)Item;
                        InventoryListView.Items.Add(armor.ItemName, i);
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.AmountHeld));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.WeightPerItem));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.ACFromArmor));
                        i++;
                        break;

                    case 3:
                        Weapon weapon = (Weapon)Item;
                        InventoryListView.Items.Add(weapon.ItemName, i);
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.AmountHeld));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.WeightPerItem));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.Damage));
                        i++;
                        break;
                }
            }
        }

        private void RemoveFromInvButton_Click_1(object sender, EventArgs e)
        {
            //for (int i = 0; i < InventoryListView.Items.Count; i++)
            //{
            //    if (InventoryListView.Items[i].Selected)
            //    {
            //        myInventoryList.RemoveAt(i);
            //        InventoryListView.Items[i].Remove();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Select an item from the list to remove");
            //    }

            //}
            //RunInvList();
        }

        private void MinusOneButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < InventoryListView.Items.Count; i++)
            //{
            //    if (InventoryListView.Items[i].Selected)
            //    {
            //        myInventoryList[i].AmountHeld -= 1;
            //        if (myInventoryList[i].AmountHeld == 0)
            //        {
            //            myInventoryList.RemoveAt(i);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Select an item from the list to decrease");
            //    }
            //}
            //RunInvList();
        }

        private void AddOneButton_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < InventoryListView.Items.Count; i++)
            //{
            //    if (InventoryListView.Items[i].Selected)
            //    {
            //        myInventoryList[i].AmountHeld += 1;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Select an item from the list to increase");
            //    }
            //}
            //RunInvList();
        }
    }
}
