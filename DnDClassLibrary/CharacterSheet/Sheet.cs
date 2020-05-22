using System;
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
        // Instansierer de forskellige fields, arrays, lister osv.
        #region INSTANSIATIONS
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();
        EquippedItems myEquippedItems = new EquippedItems();
        UtillityMethods myUtillities = new UtillityMethods();
        Item myItem = new Item();
        List<Item> myInventoryList = new List<Item>();
        List<Feat> myFeatureList = new List<Feat>();
        List<Feat> myOtherFeatureList = new List<Feat>();
        List<Spell> myPreparedSpells = new List<Spell>();
        List<Spell> myAvilableSpells = new List<Spell>();
        public string[] CharacterInfo = new string[19];
        bool WeaponEquipSwitch;
        List<CharacterAttributes> characterAttributesInfo = new List<CharacterAttributes>();

        #endregion

        // De forskellige constructors der laver sheetet
        #region CONSTRUCTORS
        public Sheet(Character charac, CharacterAttributes Attri) // konstruerer sheetet og giver character og attributes værdier fra Hvor sheetet er konstrueret fra.
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

        // Loader Sheetet med dets værdier
        #region SHEETLOAD
        private void Sheet_Load_1(object sender, EventArgs e) // loader sheetets information ind, som farver og værdier til karakteren
        {
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7"); // giver charactersheet baggrunden en farve ud fra hexadecimale tal og konverterer det til RGB
            ColorLoad();
            RunInvList();
            LoadCharacterInfo();
            LoadAttributes();
            LoadSkills();
            LoadEquippedItems();
            LoadInventory();
        }
        #endregion

        // Beskriver hvad der sker når der trykkes på en ting, enten med enkelt eller dobbeltklik
        #region CLICKEVENTS
        private void SaveCharacterButton_Click(object sender, EventArgs e) // gemmer Spillerens karakter
        {
            DnDDatabaseManagement myDataBase = new DnDDatabaseManagement(myAttributes, myCharacter, myInventoryList, myItem); // opretter et nyt object af databasen med værdier den skal bruge
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

        private void EditInventoryButton_Click(object sender, EventArgs e) // åbner add to inventory Form, som kan tilføje våben, items og armnor til ens inventory
        {
            AddToInventoryForm addToInventory = new AddToInventoryForm(myInventoryList, myAttributes, myEquippedItems); // laver instance af formen
            if (addToInventory.ShowDialog() == DialogResult.OK) // åbner formen i form af en dialog boks, som når værdien er DIalogResult.OK lukkes og opdatere charactersheetets inventory og equipped items.
            {
                RunInvList();
                LoadEquippedItems();
            }
            else // hvis den ikke lukkes ordentligt, får brugeren en besked der siger, at de manuelt skal opdaterer listen
            {
                MessageBox.Show("Character List has not been updated, please manually update the list");
            }
        }

        private void ShowListItemsButton_Click(object sender, EventArgs e) // filtrerer til kun at vise items i inventory listen
        {
            InventoryListView.Columns.Clear(); // rydder gamle columns
            InventoryListView.Items.Clear(); // rydder gamle items

            //laver nye columns, med navn, placering og alignment af tekst.
            InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left);

            int i = 0; // bruges til at vælge placeringen af items i listen
            foreach (var Item in myInventoryList) // kører igennem inventorylisten og tilføjer kun objekter hvis Item ID er 1, som er Items.
            {
                if (Item.ItemID == 1)
                {
                    InventoryListView.Items.Add(Item.ItemName, i); // tilføjer Itemsne i listen på i'ne placering. Første item er Main Item som er navnet, resten er sub items, der tilføjes på samme placering, men i næste column
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
      
        private void ShowListArmorButton_Click(object sender, EventArgs e) // filtrerer til kun at vise Armor i inventory listen
        {
           InventoryListView.Columns.Clear(); // rydder gamle columns
           InventoryListView.Items.Clear(); // rydder gamle items
                                            
           //laver nye columns, med navn, placering og alignment af tekst.
           InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("AC", 30, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Type", 40, HorizontalAlignment.Left);
           InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left);
           
           int i = 0; // bruges til at vælge placeringen af armor items i listen
           foreach (var Item in myInventoryList) // kører igennem inventorylisten og tilføjer kun objekter hvis Item ID er 2, som er Armor
            {
                
                if (Item.ItemID == 2)
                {
                    Armor armor = (Armor)Item; // typecaster Armor, som et item. Da Armor klassen er et child af Item, kan den typecastes og ses som et item, hvilket giver adgang til dets fields.
                    InventoryListView.Items.Add(armor.ItemName, i); // tilføjer Itemsne i listen på i'ne placering. Første item er Main Item som er navnet, resten er sub items, der tilføjes på samme placering, men i næste column
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

        private void ShowListWeaponsButton_Click(object sender, EventArgs e) // filtrerer til kun at vise Armor i inventory listen
        {
            InventoryListView.Columns.Clear(); // rydder gamle columns
            InventoryListView.Items.Clear(); // rydder gamle items

            //laver nye columns, med navn, placering og alignment af tekst.
            InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Damage", 55, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("DamageType", 80, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("ItemType", 55, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Range", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Property", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left); 

            int i = 0; // bruges til at vælge placeringen af weapon items i listen

           foreach (var Item in myInventoryList) // kører igennem inventorylisten og tilføjer kun objekter hvis Item ID er 3, som er våben
            {
                if (Item.ItemID == 3)
                {
                    Weapon weapon = (Weapon)Item; // typecaster Weapon, som et item. Da Weapon klassen er et child af Item, kan den typecastes og ses som et item, hvilket giver adgang til dets fields.
                    InventoryListView.Items.Add(weapon.ItemName, i); // tilføjer Itemsne i listen på i'ne placering. Første item er Main Item som er navnet, resten er sub items, der tilføjes på samme placering, men i næste column
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
            WeaponEquipSwitch = true; // sætter en værdi for WeaponSwitch, som bruges til at aføre hvilken værdi der bruges under EquipFromInventory
        }
      
        private void RemoveSlotOne_Click(object sender, EventArgs e) // fjerner værdierne fra equipped våben.
        {
            myEquippedItems.WeaponOneName = "Weapon one";
            myEquippedItems.WeaponOneAttributeAssociation = "";
            myEquippedItems.WeaponOneDamageType = "";
            myEquippedItems.WeaponOneDamage = "0";

            WeaponSlotOneProficiency.Checked = false;
            LoadEquippedItems();
        }

        private void RemoveSlotTwo_Click(object sender, EventArgs e) // fjerner værdierne fra equipped våben.
        {
            myEquippedItems.WeaponTwoName = "Weapon Two";
            myEquippedItems.WeaponTwoAttributeAssociation = "";
            myEquippedItems.WeaponTwoDamageType = "";
            myEquippedItems.WeaponTwoDamage = "0";

            WeaponSlotTwoProficiency.Checked = false;
            LoadEquippedItems();
        }

        private void RemoveSlotThree_Click(object sender, EventArgs e) // fjerner værdierne fra equipped våben.
        {
            myEquippedItems.WeaponThreeName = "Weapon three";
            myEquippedItems.WeaponThreeAttributeAssociation = "";
            myEquippedItems.WeaponThreeDamageType = "";
            myEquippedItems.WeaponThreeDamage = "0";

            WeaponSlotThreeProficiency.Checked = false;
            LoadEquippedItems();
        }

        private void AddClassFeatureButton_Click(object sender, EventArgs e) // tilføjer items til ClassFeature listen
        {
            AddFeatureToList(1, myFeatureList, myOtherFeatureList, ClassFeatureListView, myFeatureList);
        }

        private void AddOtherFeaturesButton_Click(object sender, EventArgs e) // tilføjer items til other Feature listen
        {
            AddFeatureToList(2, myFeatureList, myOtherFeatureList, OtherFeaturesListView, myOtherFeatureList);
        }

        void AddFeatureToList(int ListID, List<Feat> ClassList, List<Feat> OtherList, ListView CurrentListView, List<Feat> CurrentList) // add the chosen features to the list
        {
            int i = 0; 
            AddFeatureForm Feature = new AddFeatureForm(ClassList, OtherList, "Add", "Cancel", ListID);  // laver en ny instance af form AddFeatureForm

            if (Feature.ShowDialog() == DialogResult.OK) // åbner AddFeatureForm og venter på Dialog Result bliver OK
            {
                CurrentListView.Items.Clear(); // rydder listen
                foreach (var Item in CurrentList) // kigger igennem listen og tilføjer navn og beskrivelse til listen
                {
                    CurrentListView.Items.Add(Item.FeatName, i); 
                    CurrentListView.Items[i].SubItems.Add(Convert.ToString(Item.FeatDescription));
                    i++;
                }
            }
            else // hvis dialogResult ikke er OK, så rydder og displayer den stadig listen.
            {
                CurrentListView.Items.Clear(); // rydder listen
                foreach (var Item in CurrentList)
                {
                    CurrentListView.Items.Add(Item.FeatName, i);
                    CurrentListView.Items[i].SubItems.Add(Convert.ToString(Item.FeatDescription));
                    i++;
                }
            }
        }

        private void RemoveFeatureButton_Click(object sender, EventArgs e) // fjerner class features
        {
            RemoveFeatures(ClassFeatureListView, myFeatureList);
        }

        private void RemoveOtherFeaturesButton_Click(object sender, EventArgs e) // fjerner other features
        {
            RemoveFeatures(OtherFeaturesListView, myOtherFeatureList);
        }
      
        private void AlItemsButton_Click(object sender, EventArgs e) // kører RunInvList, som viser den fulde inventory liste
        {
            RunInvList();
        }

        private void SpellsButton_Click(object sender, EventArgs e) // åbner spellbooken
        {
            this.Hide(); // skjuler charactersheetet
            Spellbook RunSpellBook = new Spellbook(myCharacter, myPreparedSpells, myAvilableSpells); // laver en instance af spellbooken
            if (RunSpellBook.ShowDialog() == DialogResult.OK) // Viser spellbooken og venter på dialog Result bliver OK
            {
                this.Show(); // skjuler spellbooken
                RunPreparedSpells(); // viser prepared spells fra spellbooken 
            }
            else
            {
                MessageBox.Show("Character List has not been updated, please manually update the list"); //Hvis lukket forkert, vises denne besked
            }
        }


        private void pictureBox_DoubleClick(object sender, EventArgs e) // åbner en openfile dialog boks, som lader brugeren vælge et billede til sin karakter, når den dobbeltklikkes på
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                pictureBox.ImageLocation = pic.FileName;
            }
        }
        #endregion

        // tjekker hver skill proficidncy igennem for om de har proficiency, jack og all trades eller ingen bonuser.
        #region SAVINGTHROWPROFICIENCYTOGGLES
        private void StrengthSaveProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter); // instansiater Saving throw
            mySavingthrow.proficiency[0] = StrengthSaveProficiencyToggle.Checked; // giver Savingthrow en bool værdi af enten true eller false
            StrengthSaveLabel.Text = CheckProficiencyToggle(mySavingthrow.StrengthSave, StrengthSaveProficiencyToggle.Checked); // Udregner om der er Proficency eller ej
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

        // checker igennem om der er sat flueben udfor en checkboks, og hvad der sker derefter.
        #region CHECKCHANGED
 
        private void EditSheetCheck_CheckedChanged(object sender, EventArgs e) // gør sheetet editbvart og hvis hvad der kan edittes.
        {
            if (EditSheetCheck.Checked == true) 
            {
                EditSheetTrueWrite(); // gør at man kan skrive i udvalgte steder i sheetet
                EditSheetTrueColor(); // ændre farven på de udvalgte steder
            }
            else
            {
                EditSheetFalseRead(); // fjerner muligheden for at skrive i de udvalgte steder
                EditSheetFalseColor(); // sætter farven på de udvalgte steder tilbage til originalen

                // resten her opdaterer sheetet med de nye informationer.
                LoadAttributes();
                LoadCharacterInfo();
                LoadSkills();
                LoadEquippedItems();
            }
        }
       
        private void JackOfAllTradesCheck_CheckedChanged(object sender, EventArgs e) // tjekker om JAck Of All Trades er slået til
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);

            // Hvis jack of all trades er slået til, går den hver skill igennem og tjekker hvorvidt om de har proficiency. 
            // Hvis de ikke har, så får de værdien af jack of all trades, hvis de har proficency får de den værdi i  stedet.

            AthleticsLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AthleticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Athletics, AthleticsLabel.Text);
            AcrobaticsLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AcrobaticsProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Acrobatics, AcrobaticsLabel.Text);
            SleightOfHandLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SleightOfHandProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.SleightOfHand, SleightOfHandLabel.Text);
            StealthLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, StealthProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Stealth, StealthLabel.Text);
            ArcanaLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ArcanaProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Arcana, ArcanaLabel.Text);
            HistoryLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, HistoryProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.History, HistoryLabel.Text);
            NatureLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, NatureProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Nature, NatureLabel.Text);
            InvestigationLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InvestigationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Investigation, InvestigationLabel.Text);
            ReligionLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, ReligionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Religion, ReligionLabel.Text);
            AnimalHandlingLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, AnimalHandlingProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.AnimalHandling, AnimalHandlingLabel.Text);
            InsightLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, InsightProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Insight, InsightLabel.Text);
            MedicineLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, MedicineProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Medicine, MedicineLabel.Text);
            PerceptionLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PerceptionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Perception, PerceptionLabel.Text);
            SurvivalLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, SurvivalProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Survival, SurvivalLabel.Text);
            DeceptionLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, DeceptionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Deception, DeceptionLabel.Text);
            IntimidationLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, IntimidationProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Intimidation, IntimidationLabel.Text);
            PerformanceLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PerformanceProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Performance, PerformanceLabel.Text);
            PersuasionLabel.Text = mySkill.CheckJackOfAllTradesToggle(myCharacter.proficiencyBonus, PersuasionProficiencyToggle.Checked, JackOfAllTradesCheck.Checked, mySkill.Persuasion, PersuasionLabel.Text);
        }

        private void ShieldEquippedCheck_CheckedChanged(object sender, EventArgs e) // tjekker om et skjold er equippet og genloader equipped items, med den nye Armor Class værdi.
        {
            myEquippedItems.shieldEquipped = ShieldEquippedCheck.Checked;
            LoadEquippedItems();
        }

        private void WeaponSlotOneProficiency_CheckedChanged(object sender, EventArgs e) // tjekker om der er proficency i første våben equipped.
        {
            LoadEquippedItems();
        }

        private void WeaponSlotTwoProficiency_CheckedChanged(object sender, EventArgs e) // tjekker om der er proficency i andet våben equipped.
        {
            LoadEquippedItems();
        }

        private void WeaponSlotThreeProficiency_CheckedChanged(object sender, EventArgs e) // tjekker om der er proficency i tredje våben equipped.
        {
            LoadEquippedItems();
        }
        #endregion

        // ændre værdien på funktioner der fungerer med en numeric up/down value, som nuværende liv og ens resources.
        #region VALUECHANGE

        private void CurrentHitPointsDisplay_ValueChanged(object sender, EventArgs e) // sætter værdien for current HP.
        {
            CurrentHitPointsDisplay.Maximum = Convert.ToInt32(MaxHealthDisplay.Text); // sætter den max værdi som CurrentHP kan sættes med, vha pil op og ned.

            if (CurrentHitPointsDisplay.Value > Convert.ToInt32(MaxHealthDisplay.Text)) // Hvis den skrevne mængde er over MAxHP, vil værdien sættes til maxhps værdi
            {
                CurrentHitPointsDisplay.Value = 12;

            }
            else if (CurrentHitPointsDisplay.Value < 0) // Hvis værdien går under nul, vil den sættes til 0;
            {
                CurrentHitPointsDisplay.Value = 0;
            }
            myCharacter.currentHealth = Convert.ToInt32(CurrentHitPointsDisplay.Value);
        }

        private void ClassResourcesNumericUpDown_ValueChanged(object sender, EventArgs e) // giver værdi til Class Resources. Hvis værdien er under nul, sættes den til nul
        {
            if (ClassResourcesNumericUpDown.Value < 0)
            {
                ClassResourcesNumericUpDown.Value = 0;
            }
        }
        #endregion

        // ændrer teksten i følgende områder på sheetet.
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
            bool OutOfReach = string.IsNullOrEmpty(ExperienceDisplayTextBox.Text); // tjekker om der er en value
            if (OutOfReach == false)
            {
                myCharacter.experience = ExperienceDisplayTextBox.Text; // hvis værdien er okay, sættes værdien i MyCharacter til det der er skrevet i boksen
            }
            else
            {
                ExperienceDisplayTextBox.Text = myCharacter.experience; // ellers sættes det til dens sidste accepterede værdi og en popup kommer.
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
            if (OutOfReach == false && Convert.ToInt32(LevelDisplayTextBox.Text) <= 20 && Convert.ToInt32(LevelDisplayTextBox.Text) >= 1) // tjekker om lvl skrevet er indenfor 1 og 20
            {
                myCharacter.level = Convert.ToInt32(LevelDisplayTextBox.Text); // sætter værdien hvis den er valid
            }
            else
            {
                LevelDisplayTextBox.Text = Convert.ToString(myCharacter.level); // ellers sættes den til sidst accepterede værdi og en popup kommer.
                MessageBox.Show("Level must be within range 1 and 20");
            }
        }

        private void CharismaAttributeDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(CharismaAttributeDisplay.Text);
            int Range = 0;
            Range = myCharacter.AttributeRangeChecker(OutOfReach, Range, CharismaAttributeDisplay.Text);
       
            if (Range >= 0 && Range <= 20) // tjekker om attributen er indenfor 1 - 20, hvis den er får den ny værdi eller får den, den gamle vædi.
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
            Range = myCharacter.AttributeRangeChecker(OutOfReach, Range, WisdomAttributeDisplay.Text);
        
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
            Range = myCharacter.AttributeRangeChecker(OutOfReach, Range, IntelligenceAttributeDisplay.Text);

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
            Range = myCharacter.AttributeRangeChecker(OutOfReach, Range, ConstitutionAttributeDisplay.Text);

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
            Range = myCharacter.AttributeRangeChecker(OutOfReach, Range, DexterityAttributeDisplay.Text);

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
            Range = myCharacter.AttributeRangeChecker(OutOfReach, Range, StrengthAttributeDisplay.Text);

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
            myItem.Copper = Convert.ToInt32(myUtillities.NewValue(OutOfReach, CopperCoinsDisplay.Text)); // lægger en ny værdi i coins, udfra user input
        }

        private void SilverCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(SilverCoinsDisplay.Text);
            myItem.Silver = Convert.ToInt32(myUtillities.NewValue(OutOfReach, SilverCoinsDisplay.Text));
        }

        private void ElectrumCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ElectrumCoinsDisplay.Text);
            myItem.Electrum = Convert.ToInt32(myUtillities.NewValue(OutOfReach, ElectrumCoinsDisplay.Text));
        }

        private void GoldCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(GoldCoinsDisplay.Text);
            myItem.Gold = Convert.ToInt32(myUtillities.NewValue(OutOfReach, GoldCoinsDisplay.Text));
        }

        private void PlatinumCoinsDisplay_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(PlatinumCoinsDisplay.Text);
            myItem.Platinum = Convert.ToInt32(myUtillities.NewValue(OutOfReach, PlatinumCoinsDisplay.Text));
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
        #endregion

        // tjekker hver skill proficidncy igennem for om de har proficiency, jack og all trades eller ingen bonuser.
        #region SKILLPROFICIENCYTOGGLE

        private void AthleticsProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter); // Starter med en instance af skillen
            mySkill.proficiency[3] = AthleticsProficiencyToggle.Checked; // efterfulgt af et check om der skal være proficency eller ej
            AthleticsLabel.Text = ProficencyDisplayCalc(AthleticsProficiencyToggle.Checked, AthleticsLabel.Text, mySkill.Athletics, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked); //  og slutter med en udregning deraf
        }

        private void AcrobaticsProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[0] = AcrobaticsProficiencyToggle.Checked;
            AcrobaticsLabel.Text = ProficencyDisplayCalc(AcrobaticsProficiencyToggle.Checked, AcrobaticsLabel.Text, mySkill.Acrobatics, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void SleightOfHandProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[15] = SleightOfHandProficiencyToggle.Checked;
            SleightOfHandLabel.Text = ProficencyDisplayCalc(SleightOfHandProficiencyToggle.Checked, SleightOfHandLabel.Text, mySkill.SleightOfHand, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void StealthProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[16] = StealthProficiencyToggle.Checked;
            StealthLabel.Text = ProficencyDisplayCalc(StealthProficiencyToggle.Checked, StealthLabel.Text, mySkill.Stealth, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void ArcanaProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[2] = ArcanaProficiencyToggle.Checked;
            ArcanaLabel.Text = ProficencyDisplayCalc(ArcanaProficiencyToggle.Checked, ArcanaLabel.Text, mySkill.Arcana, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void HistoryProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[5] = HistoryProficiencyToggle.Checked;
            HistoryLabel.Text = ProficencyDisplayCalc(HistoryProficiencyToggle.Checked, HistoryLabel.Text, mySkill.History, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void NatureProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[10] = NatureProficiencyToggle.Checked;
            NatureLabel.Text = ProficencyDisplayCalc(NatureProficiencyToggle.Checked, NatureLabel.Text, mySkill.Nature, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void InvestigationProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[8] = InvestigationProficiencyToggle.Checked;
            InvestigationLabel.Text = ProficencyDisplayCalc(InvestigationProficiencyToggle.Checked, InvestigationLabel.Text, mySkill.Investigation, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void ReligionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[14] = ReligionProficiencyToggle.Checked;
            ReligionLabel.Text = ProficencyDisplayCalc(ReligionProficiencyToggle.Checked, ReligionLabel.Text, mySkill.Religion, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void AnimalHandlingProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[1] = AnimalHandlingProficiencyToggle.Checked;
            AnimalHandlingLabel.Text = ProficencyDisplayCalc(AnimalHandlingProficiencyToggle.Checked, AnimalHandlingLabel.Text, mySkill.AnimalHandling, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void InsightProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[6] = InsightProficiencyToggle.Checked;
            InsightLabel.Text = ProficencyDisplayCalc(InsightProficiencyToggle.Checked, InsightLabel.Text, mySkill.Insight, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void MedicineProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[9] = MedicineProficiencyToggle.Checked;
            MedicineLabel.Text = ProficencyDisplayCalc(MedicineProficiencyToggle.Checked, MedicineLabel.Text, mySkill.Medicine, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void PerceptionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[11] = PerceptionProficiencyToggle.Checked;
            PerceptionLabel.Text = ProficencyDisplayCalc(PerceptionProficiencyToggle.Checked, PerceptionLabel.Text, mySkill.Perception, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void SurvivalProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[17] = SurvivalProficiencyToggle.Checked;
            SurvivalLabel.Text = ProficencyDisplayCalc(SurvivalProficiencyToggle.Checked, SurvivalLabel.Text, mySkill.Survival, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void DeceptionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[4] = DeceptionProficiencyToggle.Checked;
            DeceptionLabel.Text = ProficencyDisplayCalc(DeceptionProficiencyToggle.Checked, DeceptionLabel.Text, mySkill.Deception, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void IntimidationProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[7] = IntimidationProficiencyToggle.Checked;
            IntimidationLabel.Text = ProficencyDisplayCalc(IntimidationProficiencyToggle.Checked, IntimidationLabel.Text, mySkill.Intimidation, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void PerformanceProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[12] = PerformanceProficiencyToggle.Checked;
            PerformanceLabel.Text = ProficencyDisplayCalc(PerformanceProficiencyToggle.Checked, PerformanceLabel.Text, mySkill.Performance, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);
        }

        private void PersuasionProficiencyToggle_CheckedChanged(object sender, EventArgs e)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            mySkill.proficiency[13] = PersuasionProficiencyToggle.Checked;
            PersuasionLabel.Text = ProficencyDisplayCalc(PersuasionProficiencyToggle.Checked, PersuasionLabel.Text, mySkill.Persuasion, myCharacter.proficiencyBonus, JackOfAllTradesCheck.Checked);      
        }
        #endregion

        // Tjekker hvilke knapper der trykkes på, når brugeren skriver i programmet.
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

        // Metoder lavet til at køre forskellige funktionaliteter af programmet.
        #region METHODS

        void RemoveFeatures(ListView CurrentListView, List<Feat> FeatList) // Fjerner Features fra listen
        {
            for (int i = 0; i < CurrentListView.Items.Count; i++) // kører igennem den valgte liste
            {
                if (CurrentListView.Items[i].Selected) // hvis itemmet er fundet fjernes den fra listview og listen
                {
                    FeatList.RemoveAt(i);
                    CurrentListView.Items[i].Remove();
                }
                else
                {
                }

            }
        }

        string CheckProficiencyToggle(int SkillToCheck, bool ProficiencyToggle) // Tjekker om proficency er slået til
        {
            if (ProficiencyToggle == false)
            {
                return Convert.ToString(SkillToCheck); // returnerer SKillToCheck uden proficency, som udregnes i Skill classen baseret på Proficienytogglen
            }
            else
            {
                return Convert.ToString(SkillToCheck); // returnerer SKillToCheck med proficency, som udregnes i Skill classen baseret på Proficienytogglen
            }
        }
       
        string ProficencyDisplayCalc(bool ProficencyState, string TextToDisplay, int SkillToUse, int CharacterProficency, bool JackOfAllTradesState)
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            if (ProficencyState == true) // checker om Proficency er slået til
            {
                return CheckProficiencyToggle(SkillToUse, ProficencyState); // Hvis proficency er slået til, returneres Værdien af skille,sammen med proficency bonus.
            }
            else // ellers returneres værdien med jack of all trades¨, som enten er slået til eller fra. 
            {
                return mySkill.CheckJackOfAllTradesToggle(CharacterProficency, ProficencyState, JackOfAllTradesState, SkillToUse, TextToDisplay);
            }
        }
       
        void LoadAttributes() // Loader character equipmentets værdier fra Savingthrows classen og lægger det over i de respektive pladser i Charactersheetet converteret til strings og tjekker om proficency er slået til eller ej.
        {
            SavingThrow mySavingthrow = new SavingThrow(myAttributes, myCharacter);
      
            // lægger værdier i respektive pladser
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
            
            //Tjekker om Proficency er slået til
            StrengthSaveProficiencyToggle.CheckStateChanged += StrengthSaveProficiencyToggle_CheckedChanged;
            DexteritySaveProficiencyToggle.CheckStateChanged += DexteritySaveProficiencyToggle_CheckedChanged;
            ConstitutionSaveProficiencyToggle.CheckStateChanged += ConstitutionSaveProficiencyToggle_CheckedChanged;
            IntelligenceSaveProficiencyToggle.CheckStateChanged += IntelligenceSaveProficiencyToggle_CheckedChanged;
            WisdomSaveProficiencyToggle.CheckStateChanged += WisdomSaveProficiencyToggle_CheckedChanged;
            CharismaSaveProficiencyToggle.CheckStateChanged += CharismaSaveProficiencyToggle_CheckedChanged;
        }

        void LoadSkills() // Loader character equipmentets værdier fra Skills classen og lægger det over i de respektive pladser i Charactersheetet converteret til strings og tjekker om Proficency er slået til eller ej.
        {
            Skill mySkill = new Skill(myAttributes, myCharacter);
            // lægger værdier i respektive pladser
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

            //Tjekker om Proficency er slået til
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

        void LoadCharacterInfo() // Loader character equipmentets værdier fra EQuipemntclassen og lægger det over i de respektive pladser i Charactersheetet converteret til strings.
        {
            RaceDisplayTextBox.Text = myCharacter.race;
            LevelDisplayTextBox.Text = Convert.ToString(myCharacter.level);
            AlignmentDisplayTextBox.Text = myCharacter.alignment;
            ClassDisplayTextBox.Text = myCharacter.characterClass;
            BackgroundDisplayTextBox.Text = myCharacter.background;
            ExperienceDisplayTextBox.Text = myCharacter.experience;

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

        void OnlyTakeNumbers(KeyPressEventArgs e) // Sørger for at brugeren kun kan skrive tal i tekstbokse
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // tjekker hvad brugeren har af input, hvis det er et tal, bliver e.handled sat til true og inputtet accepteres.
            {
                e.Handled = true;
            }
        }

        void EditSheetTrueColor() // Hvis edit sheets værdier er sat til true, så sættes følgende variables farve til hvid, så brugeren kan se de kan ændres
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

        void EditSheetFalseColor() // Hvis EditSheet værdi er sat til false, ændres farverne i følgende variabler tilbage til deres originale farver
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
        void EditSheetTrueWrite() // Hvis editsheet er sat til true, kan følgende værdier i sheetet ændres.
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

        void EditSheetFalseRead() // Hvis Editsheet er slået fra, fjernes muligheden for at ændre i følgende værdier på sheetet.
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

        void LoadEquippedItems() // lægger værdierne fra Inventory Classen hen i deres respektive placeringer i Sheetet converteret til strings. 
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

        void LoadInventory() // lægger værdierne fra Inventory Classen hen i deres respektive placeringer i Sheetet converteret til strings. 
        {
            CopperCoinsDisplay.Text = Convert.ToString(myItem.Copper);
            SilverCoinsDisplay.Text = Convert.ToString(myItem.Silver);
            ElectrumCoinsDisplay.Text = Convert.ToString(myItem.Electrum);
            GoldCoinsDisplay.Text = Convert.ToString(myItem.Gold);
            PlatinumCoinsDisplay.Text = Convert.ToString(myItem.Platinum);
        }

        void RunInvList() // Kører inventorylsisten med alle typer af items.
        {
            WeaponEquipSwitch = false; // Sætter WeaoinEquipSwitch til false, så EquipfromInventory metoden tager den rigtige værdi til våbnet der skal equippes.
            InventoryListView.Columns.Clear(); // rydder Inventorylistviews rækker
            InventoryListView.Items.Clear(); // rydder inventory list objekter i arrayet
            // laver columns til listviewet
            InventoryListView.Columns.Add("Name", 45, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Amount", 50, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Lbs", 30, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("AC/AttributeAssociation", 80, HorizontalAlignment.Left);
            InventoryListView.Columns.Add("Description", 80, HorizontalAlignment.Left);

            int i = 0; 
            foreach (var Item in myInventoryList) // kigger igennem alle inventorylistens objekter
            {
                int ID = Item.ItemID; // bruger item id til at se om det er et 1: Item, 2: Armor eller 3: våben


                switch (Item.ItemID)  // tilføjer item, armor eller våben til placering i, i listen og konverterer dem der ikke er strings til strings, bagefter øger den i med en
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

        private void RemoveFromInvButton_Click_1(object sender, EventArgs e) // Fjerner et Item Fra Listen oog Listviewet
        {
            for (int i = 0; i < InventoryListView.Items.Count; i++)  // kører igennem listview og hvis det item der er valgt eksisterr, så pauser for loopet of går ind i if statementen
            {
                if (InventoryListView.Items[i].Selected)
                {
                    for (int j = 0; j < myInventoryList.Count; j++) // her tjekkes inventorylisten igennen efter et objekt med samme navn
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text))  // hvis den findes fjernes den fra listen og inventorylisten
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

        private void MinusOneButton_Click(object sender, EventArgs e)// sænker mængden af et Objekts "AmountHeld" med en, hvis det er valgt.
        {
            for (int i = 0; i < InventoryListView.Items.Count; i++) // kører igennem listview og hvis det item der er valgt eksisterr, så pauser for loopet of går ind i if statementen
            {
                if (InventoryListView.Items[i].Selected)
                {
                    for (int j = 0; j < myInventoryList.Count; j++) // her tjekkes inventorylisten igennen efter et objekt med samme navn
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text)) // Hvis det findes Sænkes mængden af "AmountHeld" med 1, hvis den ender på nul eller lavere, så Fjernes den fra listen og listviewet
                        {
                            myInventoryList[j].AmountHeld -= 1;
                            InventoryListView.Items[i].SubItems[1].Text = Convert.ToString(myInventoryList[j].AmountHeld);

                            if (myInventoryList[j].AmountHeld <= 0)
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

        private void AddOneButton_Click(object sender, EventArgs e)// øger mængden af et Objekts "AmountHeld" med en, hvis det er valgt.
        {
            for (int i = 0; i < InventoryListView.Items.Count; i++) // kører igennem listview og hvis det item der er valgt eksisterr, så pauser for loopet of går ind i if statementen
            {
                if (InventoryListView.Items[i].Selected)
                {
                    for (int j = 0; j < myInventoryList.Count; j++) // her tjekkes inventorylisten igennen efter et objekt med samme navn
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text)) // Hvis det eksisterer så øges "AmountHeld med 1 og "AmountHeld" i listview opdateres.
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

        private void EquipItemButton_Click(object sender, EventArgs e) // Equipper et item man har valgt fra CharacterSheetet
        {
            int Attributes; 
            for (int i = 0; i < InventoryListView.Items.Count; i++) // Kører i igennem Listview igennem et item ad gangen
            {
                if (InventoryListView.Items[i].Selected) //  Hvis det objekt man har trykket på i listen findes er det på i'ne plads i arrayet
                {
                    for (int j = 0; j < myInventoryList.Count; j++) // kører nu igennem inventorylisten med j
                        if (myInventoryList[j].ItemName.Equals(InventoryListView.Items[i].Text)) // Hvis et objekt i Inventorylisten findés med samme navn som objekter i, stopper for loopet ved objekt j.
                        {
                            switch (myInventoryList[j].ItemID) //  Switchen tjekker om objekt j er et 1: Item, 2: Armor: 3: våben og kører en switch case.
                            {
                                case 2: // Hvis det er et Armor, tages værdiern fra AC og og navn og lægges i den equipped armors fields og vises på Character sheetet.
                                    myEquippedItems.ACFromArmor = Convert.ToInt32(InventoryListView.Items[i].SubItems[3].Text);
                                    myEquippedItems.ArmorSlotChest = InventoryListView.Items[i].SubItems[0].Text;
                                    break;
                                case 3:// ved våben er der to muligheder, da invenotry listen på sheetet kan sorteres på to forskellige måder skal der to cases frem WeaponID true og false, som har forskellige Attribute placeringer
                                    int WeaponID = i;
                                    // begge tager attribute værdierne, myEquipped items værdierne, weapon ID og Inventorylistviews værdier og pbner en doalog boksm som spørger hvor det skal equippes. Derefter kører loadequippedITems(); som reloader equipped items i sheetet
                                    if (WeaponEquipSwitch == true)
                                    {
                                        Attributes = 7;
                                        EquipWeaponFromSheet WeaponEquip = new EquipWeaponFromSheet(Attributes, myEquippedItems, WeaponID, InventoryListView, "Where would you like to equip the weapon?", "Weapon slot 1", "Weapon slot 2", "Weapon slot 3");
                                        if (WeaponEquip.ShowDialog() == DialogResult.OK)
                                        {
                                            LoadEquippedItems();
                                        }
                                    }
                                    else
                                    {
                                        Attributes = 3;
                                        EquipWeaponFromSheet WeaponEquip = new EquipWeaponFromSheet(Attributes, myEquippedItems, WeaponID, InventoryListView, "Where would you like to equip the weapon?", "Weapon slot 1", "Weapon slot 2", "Weapon slot 3");
                                        if (WeaponEquip.ShowDialog() == DialogResult.OK)
                                        {
                                            LoadEquippedItems();
                                        }
                                    }
                                    // Hvis itemet ikke er våben eller armor kommer følgende besked
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

        void LoadCharacterInfoFromList() // Loader Character informationer ind i backend fieldsne, fra array der er gemt i Json Filen
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

        void RunPreparedSpells() // Kører spells listen på sheetet.
        {
            SpellsListView.Items.Clear(); // rydder spelllisten, så den ikke bliver skrevet flere gange.
            int i = 0; // initiere 0
            foreach (var Spell in myPreparedSpells) // Går igennem hver spell object i spellListen
            {
                SpellsListView.Items.Add(Spell.SpellName, i); // Tilføjer hoved elementet efter fulgt af Subelementer på plads i 9 listview arrayet.
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellLevel));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.Range));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellDC));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellBonus));
                SpellsListView.Items[i].SubItems.Add(Convert.ToString(Spell.SpellDamage));
                SpellsListView.Items[i].SubItems.Add(Spell.SpellDamageType);
                i++; // øger i med en, så den næste spell ikke bliver lagt ovenpå den gamle.
            }
        }

        void ColorLoad() // denne metode assigner farverne til de forskellige dele af sheetet baseret på Hexadecimale tal..
        {
            EquipmentPanel.BackColor = ColorTranslator.FromHtml("#778899"); // Converterer Hexadecimal til RGB
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
        #endregion
    }
}
