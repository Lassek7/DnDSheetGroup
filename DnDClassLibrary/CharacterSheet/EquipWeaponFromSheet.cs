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
    public partial class EquipWeaponFromSheet : Form
    {
        EquippedItems myEquippedItems = new EquippedItems();
        int WeaponID;
        int AttributeLocation;
        ListView myListView = new ListView();
        public EquipWeaponFromSheet(int AttributesPlacement, EquippedItems Equipped, int ID, ListView ListToTakeFrom, string LabelText, string ButtonOne, string ButtonTwo, string ButtonThree)
        {
            InitializeComponent();
            FormLabelText.Text = LabelText;
            SlotOneButton.Text = ButtonOne;
            SlotTwoButton.Text = ButtonTwo;
            SlotThreeButton.Text = ButtonThree;
            myEquippedItems = Equipped;
            myListView = ListToTakeFrom;
            WeaponID = ID;
            AttributeLocation = AttributesPlacement;
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");

        }

        private void SlotOneButton_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponOneName = myListView.Items[WeaponID].SubItems[0].Text;
            myEquippedItems.WeaponOneAttributeAssociation = myListView.Items[WeaponID].SubItems[AttributeLocation].Text;
            myEquippedItems.WeaponOneDamageType = myListView.Items[WeaponID].SubItems[4].Text;
            myEquippedItems.WeaponOneDamage = myListView.Items[WeaponID].SubItems[3].Text;
            this.Hide();
        }
        private void SlotTwoButton_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponTwoName = myListView.Items[WeaponID].SubItems[0].Text;
            myEquippedItems.WeaponTwoAttributeAssociation = myListView.Items[WeaponID].SubItems[AttributeLocation].Text;
            myEquippedItems.WeaponTwoDamageType = myListView.Items[WeaponID].SubItems[4].Text;
            myEquippedItems.WeaponTwoDamage = myListView.Items[WeaponID].SubItems[3].Text;
            this.Hide();
        }

        private void SlotThreeButton_Click(object sender, EventArgs e)
        {
            myEquippedItems.WeaponThreeName = myListView.Items[WeaponID].SubItems[0].Text;
            myEquippedItems.WeaponThreeAttributeAssociation = myListView.Items[WeaponID].SubItems[AttributeLocation].Text;
            myEquippedItems.WeaponThreeDamageType = myListView.Items[WeaponID].SubItems[4].Text;
            myEquippedItems.WeaponThreeDamage = myListView.Items[WeaponID].SubItems[3].Text;
            this.Hide();
        }
    }
}
