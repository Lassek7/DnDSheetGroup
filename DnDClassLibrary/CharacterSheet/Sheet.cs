﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDClassLibrary;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CharacterSheet
{
    public partial class Sheet : Form
    {
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();
        EquippedItems myEquippedItems = new EquippedItems();
        Item myItem = new Item();
        List<Item> myInventoryList = new List<Item>();
        List<Feat> myFeatureList = new List<Feat>();
        List<Feat> myOtherFeatureList = new List<Feat>();
        List<Spell> myPreparedSpells = new List<Spell>();
        List<Spell> myAvilableSpells = new List<Spell>();
        public string[] CharacterInfo = new string[19];
        bool WeaponEquipSwitch;
        List<CharacterAttributes> characterAttributesInfo = new List<CharacterAttributes>();

        #region CONSTRUCTORS
        public Sheet(Character charac, CharacterAttributes Attri)
        {
            myCharacter = charac;
            myAttributes = Attri;
            InitializeComponent();
        }

        public Sheet(List<Item> InventoryList, string[] myCharacterInfo)
        {
            myInventoryList = InventoryList;
            CharacterInfo = myCharacterInfo;

            LoadCharacterInfoFromList();
            InitializeComponent();

        }
        #endregion

        #region SHEETLOAD
        private void Sheet_Load_1(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ColorLoad();
            RunInvList();
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
            DnDDatabaseManagement myDataBase = new DnDDatabaseManagement(myAttributes, myCharacter, myInventoryList, myItem);
            var filePathCharacterInfo = string.Empty;
            var filePathInventory = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save Sheet";
            saveFileDialog1.Filter = "Json files (.json)|.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = myCharacter.characterName;

            MessageBox.Show("Choose character file location");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathCharacterInfo = saveFileDialog1.FileName;
                myDataBase.SaveCharacterToFile(filePathCharacterInfo);
                if (File.Exists(filePathCharacterInfo))
                {
                    filePathInventory = myDataBase.filePath + myCharacter.characterName + "_Inventory" + ".json";

                    myDataBase.SaveDataToFile(filePathInventory);
                }
            }

        }

        private void EditInventoryButton_Click(object sender, EventArgs e)
        {
            AddToInventoryForm addToInventory = new AddToInventoryForm(myInventoryList, myAttributes, myEquippedItems);
            if (addToInventory.ShowDialog() == DialogResult.OK)
            {
                RunInvList();
                LoadEquippedItems();
            }
            else
            {
                MessageBox.Show("Character List has not been updated, please manually update the list");
            }
        }

        private void ShowListItemsButton_Click(object sender, EventArgs e)
        {
            InventoryListView.Columns.Clear();
            InventoryListView.Items.Clear();
            InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left);

            int i = 0;
            foreach (var Item in myInventoryList)
            {
                if (Item.ItemID == 1)
                {
                    InventoryListView.Items.Add(Item.ItemName, i);
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(Item.AmountHeld));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(Item.WeightPerItem));
                    InventoryListView.Items[i].SubItems.Add(Item.Description);

                    i++;
                }
                else
                {
                }
            }
        }
      
        private void ShowListArmorButton_Click(object sender, EventArgs e)
        {
           InventoryListView.Columns.Clear();
           InventoryListView.Items.Clear();
           InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("AC", 30, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Type", 40, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left);
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
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.ItemType));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.Description));
                    i++;
                }
                else
                {
                }
            }
        }

        private void ShowListWeaponsButton_Click(object sender, EventArgs e)
        {
            InventoryListView.Columns.Clear();
            InventoryListView.Items.Clear();
            InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Damage", 55, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("DamageType", 80, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("ItemType", 55, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Range", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Property", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left); 
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
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.DamageType));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.ItemType));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.Range));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.AttributeAssociation));
                    InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.Description));
                    i++;
                 }
                else
                {
                }
           }
            WeaponEquipSwitch = true;
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
        private void AddClassFeatureButton_Click(object sender, EventArgs e)
        {
            int ListID = 1;
            int i = 0;
            AddFeatureForm ClassFeatures = new AddFeatureForm(myFeatureList, myOtherFeatureList, "Add", "Cancel", ListID);

            ClassFeatureListView.Items.Clear();
            if (ClassFeatures.ShowDialog() == DialogResult.OK)
            {
                ClassFeatureListView.Items.Clear();
                foreach (var Item in myFeatureList)
                {
                    ClassFeatureListView.Items.Add(Item.FeatName, i);
                    ClassFeatureListView.Items[i].SubItems.Add(Convert.ToString(Item.FeatDescription));
                    i++;
                }
            }
            else
            {
                foreach (var Item in myFeatureList)
                {
                    ClassFeatureListView.Items.Add(Item.FeatName, i);
                    ClassFeatureListView.Items[i].SubItems.Add(Convert.ToString(Item.FeatDescription));
                    i++;
                }
            }
        }

        private void AddOtherFeaturesButton_Click(object sender, EventArgs e)
        {
            int ListID = 2;
            int i = 0;
            AddFeatureForm OtherFeatures = new AddFeatureForm(myFeatureList, myOtherFeatureList, "Add", "Cancel", ListID);

            OtherFeaturesListView.Items.Clear();
            if (OtherFeatures.ShowDialog() == DialogResult.OK)
            {
                OtherFeaturesListView.Items.Clear();
                foreach (var Item in myOtherFeatureList)
                {
                    OtherFeaturesListView.Items.Add(Item.FeatName, i);
                    OtherFeaturesListView.Items[i].SubItems.Add(Convert.ToString(Item.FeatDescription));
                    i++;
                }
            }
            else
            {
                foreach (var Item in myOtherFeatureList)
                {
                    OtherFeaturesListView.Items.Add(Item.FeatName, i);
                    OtherFeaturesListView.Items[i].SubItems.Add(Convert.ToString(Item.FeatDescription));
                    i++;
                }
            }
        }

        private void RemoveFeatureButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClassFeatureListView.Items.Count; i++)
            {
                if (ClassFeatureListView.Items[i].Selected)
                {
                    myFeatureList.RemoveAt(i);
                    ClassFeatureListView.Items[i].Remove();
                }
                else
                {
                }

            }
        }

        private void RemoveOtherFeaturesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < OtherFeaturesListView.Items.Count; i++)
            {
                if (OtherFeaturesListView.Items[i].Selected)
                {
                    myOtherFeatureList.RemoveAt(i);
                    OtherFeaturesListView.Items[i].Remove();
                }
                else
                {
                }

            }
        }

        private void AlItemsButton_Click(object sender, EventArgs e)
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
 
        private void EditSheetCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (EditSheetCheck.Checked == true)
            {
                EditSheetTrueWrite();
                EditSheetTrueColor();
            }
            else
            {
                EditSheetFalseRead();
                EditSheetFalseColor();
                LoadAttributes();
                LoadCharacterInfo();
                LoadSkills();
                LoadEquippedItems();
            }
        }
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
            ClassResourceLabel.Text = myCharacter.characterResources;

        }

        void OnlyTakeNumbers(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void EditSheetTrueColor()
        {
            RaceDisplayTextBox.BackColor = Color.White;
            ClassDisplayTextBox.BackColor = Color.White;
            BackgroundDisplayTextBox.BackColor = Color.White;
            AlignmentDisplayTextBox.BackColor = Color.White;
            ExperienceDisplayTextBox.BackColor = Color.White;
            LevelDisplayTextBox.BackColor = Color.White;

            StrengthAttributeDisplay.BackColor = Color.White;
            DexterityAttributeDisplay.BackColor = Color.White;
            ConstitutionAttributeDisplay.BackColor = Color.White;
            IntelligenceAttributeDisplay.BackColor = Color.White;
            WisdomAttributeDisplay.BackColor = Color.White;
            CharismaAttributeDisplay.BackColor = Color.White;

            MaxHealthDisplay.BackColor = Color.White;
            SpeedDisplay.BackColor = Color.White;

            IdealsDisplay.BackColor = Color.White;
            BondsDisplay.BackColor = Color.White;
            TraitsDisplay.BackColor = Color.White;
            FlawsDisplay.BackColor = Color.White;
            BackstoryBox.BackColor = Color.White;
        }

        void EditSheetFalseColor()
        {
            RaceDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ClassDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            BackgroundDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            AlignmentDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ExperienceDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            LevelDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");

            StrengthAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            DexterityAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            ConstitutionAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            IntelligenceAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            WisdomAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            CharismaAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");

            MaxHealthDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            SpeedDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");

            TraitsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            BondsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            IdealsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            FlawsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            BackstoryBox.BackColor = ColorTranslator.FromHtml("#777A88");
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
            BackstoryBox.Enabled = true;
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
            BackstoryBox.Enabled = false;
        }


        void LoadEquippedItems()
        {
            WeaponSlotOneNameDisplay.Text = myEquippedItems.WeaponOneName;
            WeaponSlotOneATKBonusDisplay.Text = Convert.ToString(myEquippedItems.AtkBonusCalc(myEquippedItems.WeaponOneAttributeAssociation, WeaponSlotOneProficiency.Checked, myCharacter.proficiencyBonus, myAttributes.Modifiers[0], myAttributes.Modifiers[1], myAttributes.Modifiers[2], myAttributes.Modifiers[3], myAttributes.Modifiers[4], myAttributes.Modifiers[5]));
            WeaponSlotOneDamageDisplay.Text = myEquippedItems.WeaponOneDamage;
            WeaponSlotOneDamageTypeDisplay.Text = myEquippedItems.WeaponOneDamageType;

            weapon2Label.Text = myEquippedItems.WeaponTwoName;
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
            WeaponEquipSwitch = false;
            InventoryListView.Columns.Clear();
            InventoryListView.Items.Clear();
            InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("AC/AttributeAssociation", 80, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left);

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
                        InventoryListView.Items[i].SubItems.Add("");
                        InventoryListView.Items[i].SubItems.Add(Item.Description);

                        i++;
                        break;
                    case 2:
                        Armor armor = (Armor)Item;
                        InventoryListView.Items.Add(armor.ItemName, i);
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.AmountHeld));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.WeightPerItem));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.ACFromArmor));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(armor.Description));
                        i++;
                        break;

                    case 3:
                        Weapon weapon = (Weapon)Item;
                        InventoryListView.Items.Add(weapon.ItemName, i);
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.AmountHeld));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.WeightPerItem));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.AttributeAssociation));
                        InventoryListView.Items[i].SubItems.Add(Convert.ToString(weapon.Description));
                        i++;
                        break;
                }
            }
        }

        private void RemoveFromInvButton_Click_1(object sender, EventArgs e)
        {
            for(int i = 0; i < InventoryListView.Items.Count; i++)
            {
               if (InventoryListView.Items[i].Selected)
                    {
                    for (int j = 0; j < myInventoryList.Count; j++)
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text))
                        {
                            myInventoryList.RemoveAt(j);
                            InventoryListView.Items[i].Remove();
                        }
               }
               else
               {
               }
            }
        }


        private void MinusOneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < InventoryListView.Items.Count; i++)
            {
                if (InventoryListView.Items[i].Selected)
                {
                    for (int j = 0; j < myInventoryList.Count; j++)
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text))
                        {
                            myInventoryList[j].AmountHeld -= 1;
                            InventoryListView.Items[i].SubItems[1].Text = Convert.ToString(myInventoryList[j].AmountHeld);

                            if (myInventoryList[j].AmountHeld <=0)
                            {
                                myInventoryList.RemoveAt(j);
                                RunInvList();
                            }
                        }
                }
                else
                {
                }
            }
        }

        private void AddOneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < InventoryListView.Items.Count; i++)
            {
                if (InventoryListView.Items[i].Selected)
                {
                    for (int j = 0; j < myInventoryList.Count; j++)
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text))
                        {
                            myInventoryList[j].AmountHeld += 1;
                            InventoryListView.Items[i].SubItems[1].Text = Convert.ToString(myInventoryList[j].AmountHeld);
                        }
                }
                else
                {
                }
            }
        }

        private void EquipItemButton_Click(object sender, EventArgs e)
        {
            int Attributes;
            for (int i = 0; i < InventoryListView.Items.Count; i++)
            {
                if (InventoryListView.Items[i].Selected)
                {
                    for (int j = 0; j < myInventoryList.Count; j++)
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text))
                        {
                            switch (myInventoryList[j].ItemID)
                            {
                                case 2:
                                    myEquippedItems.ACFromArmor = Convert.ToInt32(InventoryListView.Items[i].SubItems[3].Text);
                                    myEquippedItems.ArmorSlotChest = InventoryListView.Items[i].SubItems[0].Text;
                                    break;
                                case 3:
                                    int WeaponID = i;
    
                                    if (WeaponEquipSwitch == true)
                                    {
                                        Attributes = 7;
                                        EquipWeaponFromSheet WeaponEquip = new EquipWeaponFromSheet(Attributes, myEquippedItems, WeaponID, InventoryListView, "Where would you like to equip the weapon?", "WEapon slot 1", "Weapon slot 2", "Weapon slot 3");
                                        if (WeaponEquip.ShowDialog() == DialogResult.OK)
                                        {
                                            LoadEquippedItems();
                                        }
                                    }
                                    else
                                    {
                                        Attributes = 3;
                                        EquipWeaponFromSheet WeaponEquip = new EquipWeaponFromSheet(Attributes, myEquippedItems, WeaponID, InventoryListView, "Where would you like to equip the weapon?", "WEapon slot 1", "Weapon slot 2", "Weapon slot 3");
                                        if (WeaponEquip.ShowDialog() == DialogResult.OK)
                                        {
                                            LoadEquippedItems();
                                        }
                                    }

                                    break;
                                default:
                                    MessageBox.Show("Selected item cannot be equipped");
                                    break;
                            }

                        }
                }
                else
                {
                }
            }
            LoadEquippedItems();
        }

        void LoadCharacterInfoFromList() 
        {
            myCharacter.characterName = Convert.ToString(CharacterInfo[0]);
            myCharacter.playerName = Convert.ToString(CharacterInfo[1]);
            myCharacter.race = Convert.ToString(CharacterInfo[2]);
            myCharacter.characterClass = Convert.ToString(CharacterInfo[3]);
            myCharacter.alignment = Convert.ToString(CharacterInfo[4]);
            myCharacter.background = Convert.ToString(CharacterInfo[5]);
            myCharacter.maxHealth = Convert.ToInt32(CharacterInfo[6]);
            myCharacter.level = Convert.ToInt32(CharacterInfo[7]);
            myCharacter.traits = Convert.ToString(CharacterInfo[8]);
            myCharacter.bonds = Convert.ToString(CharacterInfo[9]);
            myCharacter.ideals = Convert.ToString(CharacterInfo[10]);
            myCharacter.flaws = Convert.ToString(CharacterInfo[11]);
            myCharacter.backstory = Convert.ToString(CharacterInfo[12]);
            myAttributes.Attributes[0] = Convert.ToInt32(CharacterInfo[13]);
            myAttributes.Attributes[1] = Convert.ToInt32(CharacterInfo[14]);
            myAttributes.Attributes[2] = Convert.ToInt32(CharacterInfo[15]);
            myAttributes.Attributes[3] = Convert.ToInt32(CharacterInfo[16]);
            myAttributes.Attributes[4] = Convert.ToInt32(CharacterInfo[17]);
            myAttributes.Attributes[5] = Convert.ToInt32(CharacterInfo[18]);
        }

        private void AttunementSlotOneTextBox_TextChanged(object sender, EventArgs e)
        {
            myEquippedItems.AttunementSlotOneName = AttunementSlotOneTextBox.Text;
        }

        private void AttunementSlotTwoTextBox_TextChanged(object sender, EventArgs e)
        {
            myEquippedItems.AttunementSlotTwoName = AttunementSlotTwoTextBox.Text;

        }

        private void AttunementSlotThreeTextBox_TextChanged(object sender, EventArgs e)
        {
            myEquippedItems.AttunementSlotThreeName = AttunementSlotThreeTextBox.Text;

        }

        private void MagicItemOneTextBox_TextChanged(object sender, EventArgs e)
        {
            myEquippedItems.MagicItemOneName = MagicItemOneTextBox.Text;
        }

        private void MagicItemTwoTextBox_TextChanged(object sender, EventArgs e)
        {
            myEquippedItems.MagicItemTwoName = MagicItemTwoTextBox.Text;

        }

        private void MagicItemThreeTextBox_TextChanged(object sender, EventArgs e)
        {
            myEquippedItems.MagicItemThreeName = MagicItemThreeTextBox.Text;

        }

        private void SpellsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Spellbook RunSpellBook = new Spellbook(myCharacter, myPreparedSpells, myAvilableSpells);
            if (RunSpellBook.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                RunPreparedSpells();
            }
            else
            {
                MessageBox.Show("Character List has not been updated, please manually update the list");
            }

        }
        void RunPreparedSpells()
        {
            SpellsListView.Items.Clear();
            int i = 0;
            foreach (var Spell in myPreparedSpells)
            {
                SpellsListView.Items.Add(Spell.SpellName, i);
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellLevel));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.Range));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellDC));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellBonus));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellDamage));
                SpellsListView.Items[i].SubItems.Add(Spell.SpellDamageType);
                i++;
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                pictureBox.ImageLocation = pic.FileName;
            }
        }

        private void SpellsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClassResourcesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ClassResourcesNumericUpDown.Value < 0)
            {
                ClassResourcesNumericUpDown.Value = 0;
            }
        }
        void ColorLoad()
        {
            EquipmentPanel.BackColor = ColorTranslator.FromHtml("#778899");
            SpellsListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            ClassFeatureListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            OtherFeaturesListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            AttributesPanel.BackColor = ColorTranslator.FromHtml("#CDBCB1");

            IdealsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            BondsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            FlawsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            IdealsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            BackstoryBox.BackColor = ColorTranslator.FromHtml("#777A88");

            StrengthAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            DexterityAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            ConstitutionAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            IntelligenceAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            WisdomAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            CharismaAttributeDisplay.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            RaceDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ClassDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            BackgroundDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            AlignmentDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ExperienceDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            LevelDisplayTextBox.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            
            SpeedDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            MaxHealthDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            CurrentHitPointsDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            numericUpDown2.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ClassResourcesNumericUpDown.BackColor = ColorTranslator.FromHtml("#D2D6D7");

            InventoryListView.BackColor = ColorTranslator.FromHtml("#778899");
            CopperCoinsDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            SilverCoinsDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            ElectrumCoinsDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            GoldCoinsDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            PlatinumCoinsDisplay.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            TraitsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            BondsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            IdealsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            FlawsDisplay.BackColor = ColorTranslator.FromHtml("#777A88");
            BackstoryBox.BackColor = ColorTranslator.FromHtml("#777A88");

            MagicItemOneTextBox.BackColor = ColorTranslator.FromHtml("#778899");
            MagicItemThreeTextBox.BackColor = ColorTranslator.FromHtml("#778899");
            MagicItemTwoTextBox.BackColor = ColorTranslator.FromHtml("#778899");
            AttunementSlotOneTextBox.BackColor = ColorTranslator.FromHtml("#778899");
            AttunementSlotTwoTextBox.BackColor = ColorTranslator.FromHtml("#778899");
            AttunementSlotThreeTextBox.BackColor = ColorTranslator.FromHtml("#778899");

            FirstWeaponPanel.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            SecondWeaponPanel.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            ThirdWeaponPanel.BackColor = ColorTranslator.FromHtml("#CDBCB1");
        }
    }
}
