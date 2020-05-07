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
        List<Item> InventoryList = new List<Item>();

        public AddToInventoryForm(List<Item> MyList)
        {
            InventoryList = MyList;

            InitializeComponent();

        }

        //public AddToInventoryForm()
        //{
        //   InitializeComponent();

        //}
        #region ADD ITEM
        private void ItemNameBox_TextChanged(object sender, EventArgs e)
        {
            myItem.ItemName = ItemNameBox.Text;
        }

        private void ItemAmountBox_TextChanged(object sender, EventArgs e)
        {
            myItem.AmountHeld = Convert.ToInt32(ItemAmountBox.Text);
        }

        private void ItemweightBox_TextChanged(object sender, EventArgs e)
        {
            myItem.WeightPerItem = Convert.ToInt32(ItemweightBox.Text);
        }

        private void ItemTypeBox_TextChanged(object sender, EventArgs e)
        {
            myItem.ItemType = ItemTypeBox.Text;
        }

        private void ItemDescriptionRichBox_TextChanged(object sender, EventArgs e)
        {
            myItem.Description = ItemDescriptionRichBox.Text;
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            myItem.ItemID = 1;
            InventoryList.Add(myItem);
            //myArmor.ItemID = 2;
            //InventoryList.Add(myArmor);
            //myWeapon.ItemID = 3;
            //InventoryList.Add(myWeapon);
            //this.Close();
        }
        #endregion

        private void ArmorNameBox_TextChanged(object sender, EventArgs e)
        {
            myArmor.ItemName = ArmorNameBox.Text;
        }

        private void ArmorAmountBox_TextChanged(object sender, EventArgs e)
        {
            myArmor.AmountHeld = Convert.ToInt32(ArmorAmountBox.Text);
        }

        private void ArmorWeightBox_TextChanged(object sender, EventArgs e)
        {
            myArmor.WeightPerItem = Convert.ToInt32(ArmorWeightBox.Text);
        }

        private void ArmorDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            myArmor.Description = ArmorDescriptionBox.Text;
        }

        private void ArmorTypeBox_TextChanged(object sender, EventArgs e)
        {
            myArmor.ItemType = ArmorTypeBox.Text;
        }

        private void ArmorACBox_TextChanged(object sender, EventArgs e)
        {
            myArmor.ACFromArmor = Convert.ToInt32(ArmorACBox.Text);
        }

        private void ArmorEquippedCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponNameBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.ItemName = WeaponNameBox.Text;
        }

        private void WeaponAmountBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.AmountHeld = Convert.ToInt32(WeaponAmountBox.Text);
        }

        private void WeaponWeightBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.WeightPerItem = Convert.ToInt32(WeaponWeightBox.Text);
        }

        private void WeaponDescriptionBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.Description = WeaponDescriptionBox.Text;
        }

        private void WeaponDamageTypeBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.DamageType = WeaponDamageTypeBox.Text;
        }

        private void WeaponDamageBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.Damage = WeaponDamageBox.Text;
        }

        private void WeaponRangeBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.Range = WeaponRangeBox.Text;
        }

        private void WeaponTypeBox_TextChanged(object sender, EventArgs e)
        {
            myWeapon.ItemType = WeaponTypeBox.Text;
        }

        private void WeaponProficencyCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponEquippedCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponStrengthStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponDexterityStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponConstitutionStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponIntelligenceStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponWisdomStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WeaponCharismaStatRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
