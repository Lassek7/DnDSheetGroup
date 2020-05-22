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
    public partial class EquipSlotCheck : Form
    {
        #region FIELDS
        /*Laver en ny instans af EquippedItems, Item, Weapon, klassene samt danner et nyt object af klassene, 
         * samt laver den en ny instans af en list i klassen Item*/
        EquippedItems myEquippedItems = new EquippedItems();
        List<Item> myInventory = new List<Item>();
        Weapon myWeapon = new Weapon();
        #endregion
        #region CONSTRUCTOR
        // Konstruktor som tilskriver intans variablene samt Initialisering baggroundsfarven til EquipSlotCheck form Design
        public EquipSlotCheck(Weapon Weapon ,EquippedItems EquipmentChoice, string message, string Slot1, string Slot2, string Slot3)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            label1.Text = message;
            WeaponSlotOne.Text = Slot1;
            WeaponSlotTwo.Text = Slot2;
            WeaponSlotThree.Text = Slot3;
            myEquippedItems = EquipmentChoice;
            myWeapon = Weapon;
        }
        #endregion
        #region METHODS
        /*Methoder som assigner de angivet værdier fra de Weapon,
        til den angivet slot brugeren har valgt*/
        private void WeaponSlotOne_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponOneName = myWeapon.ItemName;
            myEquippedItems.WeaponOneAttributeAssociation = myWeapon.AttributeAssociation;
            myEquippedItems.WeaponOneDamageType = myWeapon.DamageType;
            myEquippedItems.WeaponOneDamage = myWeapon.Damage;
            this.Hide();
        }

        private void WeaponSlotTwo_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponTwoName = myWeapon.ItemName;
            myEquippedItems.WeaponTwoAttributeAssociation = myWeapon.AttributeAssociation;
            myEquippedItems.WeaponTwoDamageType = myWeapon.DamageType;
            myEquippedItems.WeaponTwoDamage = myWeapon.Damage;
            this.Hide();
        }

        private void WeaponSlotThree_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponThreeName = myWeapon.ItemName;
            myEquippedItems.WeaponThreeAttributeAssociation = myWeapon.AttributeAssociation;
            myEquippedItems.WeaponThreeDamageType = myWeapon.DamageType;
            myEquippedItems.WeaponThreeDamage = myWeapon.Damage;
            this.Hide();
        }
        #endregion
    }
}
