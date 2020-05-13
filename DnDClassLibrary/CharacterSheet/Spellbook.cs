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
    public partial class Spellbook : Form
    {
        List<Spell> myPreparedSpells = new List<Spell>();
        List<Spell> myAvailableSpells = new List<Spell>();
        Spell mySpells = new Spell();

        public Spellbook(Character Charac, List<Spell> SpellList)
        {
            InitializeComponent();
            myPreparedSpells = SpellList;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }
        #region TEXTCHANGED
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(NameTextBox.Text);
            mySpells.SpellName = NewValue(OutOfReach, NameTextBox.Text);

        }

        private void LevelTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(LevelTextBox.Text);
            mySpells.SpellLevel = Convert.ToInt32(NewValue(OutOfReach, LevelTextBox.Text));
        }

        private void RangeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(RangeTextBox.Text);
            mySpells.Range = Convert.ToInt32(NewValue(OutOfReach, RangeTextBox.Text));
        }

        private void CastTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(CastTimeTextBox.Text);
            mySpells.CastTime = NewValue(OutOfReach, CastTimeTextBox.Text);
        }

        private void ComponentTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ComponentTextBox.Text);
            mySpells.Components = NewValue(OutOfReach, ComponentTextBox.Text);
        }

        private void SchoolTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(SchoolTextBox.Text);
            mySpells.SpellSchool = NewValue(OutOfReach, SchoolTextBox.Text);
        }

        private void DCTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DCTextBox.Text);
            mySpells.SpellDC = Convert.ToInt32(NewValue(OutOfReach, DCTextBox.Text));
        }

        private void DamageTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DamageTextBox.Text);
            mySpells.SpellDamage = Convert.ToInt32(NewValue(OutOfReach, DamageTextBox.Text));
        }
       
        private void DurationTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DurationTextBox.Text);
            mySpells.Duration = NewValue(OutOfReach, DurationTextBox.Text);
        }

        private void DamageTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DamageTypeTextBox.Text);
            mySpells.SpellDamageType = NewValue(OutOfReach, DamageTypeTextBox.Text);
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DescriptionTextBox.Text);
            mySpells.SpellDescription = NewValue(OutOfReach, DescriptionTextBox.Text);
        }
        #endregion
        #region COMBOBOXES
        private void SpellBonusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DamageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
        #region KEYPRESSEVENTS
        private void LevelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }
        private void RangeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }
        private void DCTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }
        private void DamageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyTakeNumbers(e);
        }
        #endregion

        #region METHODS
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
        void OnlyTakeNumbers(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion


    }
}
