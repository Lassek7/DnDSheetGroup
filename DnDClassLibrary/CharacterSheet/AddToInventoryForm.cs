using DnDClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet
{
    public partial class AddToInventoryForm : Form
    {
        #region FIELDS
        /*Laver en ny instans af Item, Armor, Weapon, CharacterAttributes klassene samt danner et nyt object af klassene, 
         * samt laver den en ny instans af en list i klassen Item*/
        Item myItem = new Item();
        Armor myArmor = new Armor();
        Weapon myWeapon = new Weapon();
        EquippedItems myEquippedItems = new EquippedItems();
        CharacterAttributes myAttributes = new CharacterAttributes();
        List<Item> myInventoryList = new List<Item>();
        Inventory myInventory = new Inventory();
        UtillityMethods myUtillities = new UtillityMethods();
        #endregion
        #region CONSTRUKTOR
        // Konstruktor som tilskriver intans variablene samt køre methoden RunInvList
        public AddToInventoryForm(List<Item> MyList, CharacterAttributes Attri, EquippedItems EQ)
        {
            myInventoryList = MyList;
            myAttributes = Attri;
            myEquippedItems = EQ;
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            RunInvList();
        }
        #endregion
        #region ADD ITEM
        /*Methoder som tager den inputtet text 
        fra brugeren og assigner det til værdierne i objectet myItem som er placeret i klassen Item*/
        private void ItemNameBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemNameBox.Text);
            myItem.ItemName = myUtillities.NewValue(OutOfReach, ItemNameBox.Text);
        }
        private void ItemAmountBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemAmountBox.Text);
            myItem.AmountHeld = Convert.ToInt32(myUtillities.NewValue(OutOfReach, ItemAmountBox.Text));
        }
 
        private void ItemweightBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemweightBox.Text);
            myItem.WeightPerItem = Convert.ToInt32(myUtillities.NewValue(OutOfReach, ItemweightBox.Text));
        }

        private void ItemTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemTypeBox.Text);
            myItem.ItemType = myUtillities.NewValue(OutOfReach, ItemTypeBox.Text);
        }

        private void ItemDescriptionRichBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemDescriptionRichBox.Text);
            myItem.Description = myUtillities.NewValue(OutOfReach, ItemDescriptionRichBox.Text);
        }


        #endregion
        #region ADDARMOR
        /*Methoder som tager den inputtet text 
        fra brugeren og assigner det til værdierne i objectet myArmor som er placeret i klassen Armor*/
        private void ArmorNameBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorNameBox.Text);
            myArmor.ItemName = myUtillities.NewValue(OutOfReach, ArmorNameBox.Text);
        }

        private void ArmorAmountBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorAmountBox.Text);
            myArmor.AmountHeld = Convert.ToInt32(myUtillities.NewValue(OutOfReach, ArmorAmountBox.Text));
        }

        private void ArmorWeightBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorWeightBox.Text);
            myArmor.WeightPerItem = Convert.ToInt32(myUtillities.NewValue(OutOfReach, ArmorWeightBox.Text));
        }

        private void ArmorDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorDescriptionBox.Text);
            myArmor.Description = myUtillities.NewValue(OutOfReach, ArmorDescriptionBox.Text);
        }

        private void ArmorTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorTypeBox.Text);
            myArmor.ItemType = myUtillities.NewValue(OutOfReach, ArmorTypeBox.Text);
        }

        private void ArmorACBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorACBox.Text);
            myArmor.ACFromArmor = Convert.ToInt32(myUtillities.NewValue(OutOfReach, ArmorACBox.Text));
        }

        #endregion
        #region ADDWEAPON
        /*Methoder som tager den inputtet text 
        fra brugeren og assigner det til værdierne i objectet myWeapon som er placeret i klassen Weapon*/
        private void WeaponNameBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponNameBox.Text);
            myWeapon.ItemName = myUtillities.NewValue(OutOfReach, WeaponNameBox.Text);
        }

        private void WeaponAmountBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponAmountBox.Text);
            myWeapon.AmountHeld = Convert.ToInt32(myUtillities.NewValue(OutOfReach, WeaponAmountBox.Text));
        }

        private void WeaponWeightBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponWeightBox.Text);
            myWeapon.WeightPerItem = Convert.ToInt32(myUtillities.NewValue(OutOfReach, WeaponWeightBox.Text));
        }

        private void WeaponDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponDescriptionBox.Text);
            myWeapon.Description = myUtillities.NewValue(OutOfReach, WeaponDescriptionBox.Text);
        }

        private void WeaponDamageTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponDamageTypeBox.Text);
            myWeapon.DamageType = myUtillities.NewValue(OutOfReach, WeaponDamageTypeBox.Text);
        }

        private void WeaponDamageBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponDamageBox.Text);
            myWeapon.Damage = myUtillities.NewValue(OutOfReach, WeaponDamageBox.Text) + DamageComboBox.Text;
        }

        private void WeaponRangeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponRangeBox.Text);
            myWeapon.Range = myUtillities.NewValue(OutOfReach, WeaponRangeBox.Text)+"ft.";
        }

        private void WeaponTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponTypeBox.Text);
            myWeapon.ItemType = myUtillities.NewValue(OutOfReach, WeaponTypeBox.Text);
        }

        private void WeaponStrengthStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            myWeapon.AttributeAssociation = "Strength";
        }

        private void WeaponDexterityStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            myWeapon.AttributeAssociation = "Dexterity";
        }

        private void WeaponConstitutionStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            myWeapon.AttributeAssociation = "Constitution";
        }

        private void WeaponIntelligenceStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            myWeapon.AttributeAssociation = "Intelligence";
        }

        private void WeaponWisdomStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            myWeapon.AttributeAssociation = "Wisdom";
        }

        private void WeaponCharismaStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            myWeapon.AttributeAssociation = "Charisma";
        }
        private void DamageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            myWeapon.Damage = WeaponDamageBox.Text + DamageComboBox.Text;
        }

        #endregion
        #region KEYPRESS
        private void ItemAmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
          
        }

        private void ArmorAmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void ItemweightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void ArmorWeightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void ArmorACBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void WeaponAmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void WeaponWeightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }
        private void WeaponDamageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        private void WeaponRangeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }

        #endregion
        #region CLICKEVENTS
        //Methode som afslutter AddToInventory form dialog vinduet når brugen trykker på knappen (Close)
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        /*Methoden AddItemButton_Click tjekker hvilken givet input er givet fra brugeren, 
          derefter tilfører methoden så Item,Armor og Weapon til listen i formen. Methoden tjekker også om brugen har angivet om Weapon eller armor skal equips i Sheetet
         
             */
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(myItem.ItemName) == false && myItem.AmountHeld > 0)  // laves til metoder
            {
                myInventoryList.Add
                    (myInventory.AddItem(myItem.ItemName, myItem.AmountHeld, myItem.WeightPerItem, myItem.ItemType, myItem.Description));
            }

            if (string.IsNullOrEmpty(myArmor.ItemName) == false && myArmor.AmountHeld > 0)
            {
                DnDClassLibrary.Armor newArmor =  myInventory.AddArmor(myArmor.ItemName, myArmor.AmountHeld, myArmor.WeightPerItem, myArmor.ItemType, myArmor.ACFromArmor, myArmor.Description, myArmor.ItemEquipped);
                myInventoryList.Add(newArmor);
                // tjekker om brugeren har angivet at det angivet Armor skal equippes til sheet 
                if (ArmorEquippedCheck.Checked == true)
                {
                    ArmorEquippedCheck.Checked = false;
                    myEquippedItems.ACFromArmor = myArmor.ACFromArmor;  
                    myEquippedItems.ArmorSlotChest = myArmor.ItemName;
                }
            }
            if (string.IsNullOrEmpty(myWeapon.ItemName) == false && myWeapon.AmountHeld > 0)
            {
                
                DnDClassLibrary.Weapon newWeapon = myInventory.AddWeapon(myWeapon.ItemName, myWeapon.AmountHeld, myWeapon.WeightPerItem, myWeapon.DamageType, myWeapon.Damage,
                                          myWeapon.Range, myWeapon.ItemType, myWeapon.Description, myWeapon.ItemEquipped, myWeapon.AttributeAssociation);
                myInventoryList.Add(newWeapon);
                // tjekker om brugeren har angivet at det angivet Armor skal equippes til sheet 
                if (WeaponEquippedCheck.Checked == true)
                {
                    
                    WeaponEquippedCheck.Checked = false;
                    EquipSlotCheck SlotChoice = new EquipSlotCheck(newWeapon, myEquippedItems, "Where would you like to equip the weapon?", "WEapon slot 1", "Weapon slot 2", "Weapon slot 3");
                    SlotChoice.ShowDialog();
                }
            }
            ClearTextBoxes(this.Controls);
            RunInvList();

        }
        //Methode som går igennem liste og fjerene det valgte værdi som bruger har markered
        private void RemoveFromListButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AddToInvListView.Items.Count; i++)
            {
                if (AddToInvListView.Items[i].Selected)
                {
                    myInventoryList.RemoveAt(i);
                    AddToInvListView.Items[i].Remove();
                }
                else
                {
                }

            }
            RunInvList();
        }
        //Methode som øger mængden af bestemt item i listen med 1
        private void IncreaseByOneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AddToInvListView.Items.Count; i++)
            {
                if (AddToInvListView.Items[i].Selected)
                {
                    myInventoryList[i].AmountHeld += 1;
                    AddToInvListView.Items[i].SubItems[1].Text = Convert.ToString(myInventoryList[i].AmountHeld);

                }
                else
                {
                }
            }
        }
        //Methode som formindsker mængden af bestemt item i listen med 1
        private void DecreaseByOneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AddToInvListView.Items.Count; i++)
            {
                if (AddToInvListView.Items[i].Selected)
                {
                    myInventoryList[i].AmountHeld -= 1;
                    AddToInvListView.Items[i].SubItems[1].Text = Convert.ToString(myInventoryList[i].AmountHeld);
                    if (myInventoryList[i].AmountHeld >= 0)
                    {
                        myInventoryList.RemoveAt(i);
                    }
                }
                else
                {
                }
            }
        }

        #endregion
        #region METHODS
        //Methode som kontroller at det kun nummer som bliver tastet i de felter som kun kan modtage integer værdier AmountHeld Etc.
        void OnlyTakeNumbers(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //Methode som rydder string værdierne i text bokserne
        public void ClearTextBoxes(Control.ControlCollection EditInventory)
        {
            foreach (Control TextBox in EditInventory)
            {
                if (TextBox is TextBoxBase)
                {
                    TextBox.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(TextBox.Controls);
                }
            }
        }

        //Methode som tilfører forskellige værdier fra Item, Armor og weapon klasses ind i ListView i formen design som brugeren kan se
        public void RunInvList()
        {
            AddToInvListView.Items.Clear();
            int i = 0;
            foreach (var Item in myInventoryList)
            {
                int ID = Item.ItemID;

             
                switch (Item.ItemID)
                {
                    case 1:
                        AddToInvListView.Items.Add(Item.ItemName, i);
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(Item.AmountHeld));
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(Item.WeightPerItem));
                            i++;
                        break;
                    case 2:
                        Armor armor = (Armor)Item;
                        AddToInvListView.Items.Add(armor.ItemName, i);
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(armor.AmountHeld));
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(armor.WeightPerItem));
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(armor.ACFromArmor));
                        i++;
                        break;

                    case 3:
                        Weapon weapon = (Weapon)Item;
                        AddToInvListView.Items.Add(weapon.ItemName, i);
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(weapon.AmountHeld));
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(weapon.WeightPerItem));
                        AddToInvListView.Items[i].SubItems.Add(weapon.Damage);
                        i++;
                        break;
                }
            }
            CurrentWeightLabel.Text = Convert.ToString(ItemWeightCalc());
            MaxWeightLabel.Text = Convert.ToString(myAttributes.Attributes[0] * 5);
            EncumberStatusLabel.Text = EncumberCheck(Convert.ToInt32(CurrentWeightLabel.Text), myAttributes.Attributes[0]);
        }
        //methoden tjekker om ens character er "Encumbered" udfra forskellige parameter.
        string EncumberCheck(int CurrentWeightTotal, int Strength) 
        {
            string Encumbered;
            if (CurrentWeightTotal >= Strength * 5)
            {
                Encumbered = "Heavily Encumbered";
            }
            else if (CurrentWeightTotal >= Strength * 2)
            {
                Encumbered = "Slightly encumbered";
            }
            else
            {
                Encumbered = "Not encumbered";
            }

            return Encumbered;
        }

        int ItemWeightCalc() // udregner hvor meget ens items vejer samlet
        {
            int CurrentWeightTotal = 0;
            for (int i = 0; i < myInventoryList.Count; i++)
            {
                Item Item = myInventoryList[i];
                CurrentWeightTotal += Item.WeightPerItem * Item.AmountHeld;
            }
            return CurrentWeightTotal;
        }

        #endregion



    }
}
