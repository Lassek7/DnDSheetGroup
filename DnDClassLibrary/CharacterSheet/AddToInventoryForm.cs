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
        Item myItem = new Item();
        Armor myArmor = new Armor();
        Weapon myWeapon = new Weapon();
        EquippedItems myEquippedItems = new EquippedItems();
        CharacterAttributes myAttributes = new CharacterAttributes();
        List<Item> myInventoryList = new List<Item>();
        string DamageDie;

        public AddToInventoryForm(List<Item> MyList, CharacterAttributes Attri, EquippedItems EQ)
        {
            myInventoryList = MyList;
            myAttributes = Attri;
            myEquippedItems = EQ;
            InitializeComponent();
            RunInvList();
        }
        #region ADD ITEM
        private void ItemNameBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemNameBox.Text);
            myItem.ItemName = NewValue(OutOfReach, ItemNameBox.Text);
        }
        private void ItemAmountBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemAmountBox.Text);
            myItem.AmountHeld = Convert.ToInt32(NewValue(OutOfReach, ItemAmountBox.Text));
        }
 
        private void ItemweightBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemweightBox.Text);
            myItem.WeightPerItem = Convert.ToInt32(NewValue(OutOfReach, ItemweightBox.Text));
        }

        private void ItemTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemTypeBox.Text);
            myItem.ItemType = NewValue(OutOfReach, ItemTypeBox.Text);
        }

        private void ItemDescriptionRichBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ItemDescriptionRichBox.Text);
            myItem.Description = NewValue(OutOfReach, ItemDescriptionRichBox.Text);
        }


        #endregion
        #region ADDARMOR

        private void ArmorNameBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorNameBox.Text);
            myArmor.ItemName = NewValue(OutOfReach, ArmorNameBox.Text);
        }

        private void ArmorAmountBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorAmountBox.Text);
            myArmor.AmountHeld = Convert.ToInt32(NewValue(OutOfReach, ArmorAmountBox.Text));
        }

        private void ArmorWeightBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorWeightBox.Text);
            myArmor.WeightPerItem = Convert.ToInt32(NewValue(OutOfReach, ArmorWeightBox.Text));
        }

        private void ArmorDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorDescriptionBox.Text);
            myArmor.Description = NewValue(OutOfReach, ArmorDescriptionBox.Text);
        }

        private void ArmorTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorTypeBox.Text);
            myArmor.ItemType = NewValue(OutOfReach, ArmorTypeBox.Text);
        }

        private void ArmorACBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ArmorACBox.Text);
            myArmor.ACFromArmor = Convert.ToInt32(NewValue(OutOfReach, ArmorACBox.Text));
        }

        #endregion
        #region ADDWEAPON
        private void WeaponNameBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponNameBox.Text);
            myWeapon.ItemName = NewValue(OutOfReach, WeaponNameBox.Text);
        }

        private void WeaponAmountBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponAmountBox.Text);
            myWeapon.AmountHeld = Convert.ToInt32(NewValue(OutOfReach, WeaponAmountBox.Text));
        }

        private void WeaponWeightBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponWeightBox.Text);
            myWeapon.WeightPerItem = Convert.ToInt32(NewValue(OutOfReach, WeaponWeightBox.Text));
        }

        private void WeaponDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponDescriptionBox.Text);
            myWeapon.Description = NewValue(OutOfReach, WeaponDescriptionBox.Text);
        }

        private void WeaponDamageTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponDamageTypeBox.Text);
            myWeapon.DamageType = NewValue(OutOfReach, WeaponDamageTypeBox.Text);
        }

        private void WeaponDamageBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponDamageBox.Text);
            myWeapon.Damage = NewValue(OutOfReach, WeaponDamageBox.Text) + DamageComboBox.Text;
        }

        private void WeaponRangeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponRangeBox.Text);
            myWeapon.Range = NewValue(OutOfReach, WeaponRangeBox.Text)+"ft.";
        }

        private void WeaponTypeBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(WeaponTypeBox.Text);
            myWeapon.ItemType = NewValue(OutOfReach, WeaponTypeBox.Text);
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
        #endregion
        #region CLICKEVENTS
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(myItem.ItemName) == false && myItem.AmountHeld > 0)  // laves til metoder
            {
                Item NewItem = new Item();
                NewItem.ItemID = 1;
                NewItem.ItemName = myItem.ItemName;
                NewItem.AmountHeld = myItem.AmountHeld;
                NewItem.WeightPerItem = myItem.WeightPerItem;
                NewItem.ItemType = myItem.ItemType;
                NewItem.Description = myItem.Description;
                myInventoryList.Add(NewItem);
            }
            if (string.IsNullOrEmpty(myArmor.ItemName) == false && myArmor.AmountHeld > 0)
            {
                Armor NewArmor = new Armor();
                NewArmor.ItemID = 2;
                NewArmor.ItemName = myArmor.ItemName;
                NewArmor.AmountHeld = myArmor.AmountHeld;
                NewArmor.WeightPerItem = myArmor.WeightPerItem;
                NewArmor.ItemType = myArmor.ItemType;
                NewArmor.ACFromArmor = myArmor.ACFromArmor;
                NewArmor.Description = myArmor.Description;
                NewArmor.ItemEquipped = myArmor.ItemEquipped;

                    myInventoryList.Add(NewArmor);
                if (ArmorEquippedCheck.Checked == true)
                {
                    ArmorEquippedCheck.Checked = false;
                    myEquippedItems.ACFromArmor = myArmor.ACFromArmor; 
                    myEquippedItems.ArmorSlotChest = myArmor.ItemName;
                }
            }
            if (string.IsNullOrEmpty(myWeapon.ItemName) == false && myWeapon.AmountHeld > 0)
            {
                Weapon NewWeapon = new Weapon();
                NewWeapon.ItemID = 3;
                NewWeapon.ItemName = myWeapon.ItemName;
                NewWeapon.AmountHeld = myWeapon.AmountHeld;
                NewWeapon.WeightPerItem = myWeapon.WeightPerItem;
                NewWeapon.DamageType = myWeapon.DamageType;
                NewWeapon.Damage = myWeapon.Damage;
                NewWeapon.Range = myWeapon.Range;
                NewWeapon.ItemType = myWeapon.ItemType;
                NewWeapon.Description = myWeapon.Description;
                NewWeapon.ItemEquipped = myWeapon.ItemEquipped;
                NewWeapon.AttributeAssociation = myWeapon.AttributeAssociation;
                
                
                myInventoryList.Add(NewWeapon);
                if (WeaponEquippedCheck.Checked == true)
                {
                    WeaponEquippedCheck.Checked = false;
                    EquipSlotCheck SlotChoice = new EquipSlotCheck(NewWeapon, myEquippedItems, "Where to Equip?", "Slot 1", "Slot 2", "Slot 3");
                    SlotChoice.ShowDialog();
                }
            }
            ClearTextBoxes(this.Controls);
            RunInvList();

        }

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

        void OnlyTakeNumbers(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        string NewValue(bool OutOfReach, string UserInput) // giver en linje en ny værdi, hvis værdien ikke er null
        {
            if (OutOfReach == false)
            {
                return UserInput;
            }
            else
            {
                return null;
            }
        }

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

        public void RunInvList() // mangler en sorting function og tabs
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
                        AddToInvListView.Items[i].SubItems.Add(Convert.ToString(weapon.Damage));
                        i++;
                        break;
                }
            }
            CurrentWeightLabel.Text = Convert.ToString(ItemWeightCalc());
            MaxWeightLabel.Text = Convert.ToString(myAttributes.Attributes[0] * 5);
            EncumberStatusLabel.Text = EncumberCheck(Convert.ToInt32(CurrentWeightLabel.Text), myAttributes.Attributes[0]);
        }

        string EncumberCheck(int CurrentWeightTotal, int Strength) // tjekker om man har for meget vægt
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DamageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           myWeapon.Damage = WeaponDamageBox.Text + DamageComboBox.Text;
        }
    }
}
