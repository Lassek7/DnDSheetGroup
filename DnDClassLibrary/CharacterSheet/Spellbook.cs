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

        public Spellbook(Character Charac, List<Spell> PreparedSpellList, List<Spell> AvailableSpellsList)
        {
            InitializeComponent();
            myPreparedSpells = PreparedSpellList;
            myAvailableSpells = AvailableSpellsList;
            RunAvailableSpellsList();
        }
        #region CLICKEVENTS

        private void MenuButton_Click(object sender, EventArgs e)
        {
            AddToPreparedSpells(CantripsListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(FirstLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(SecondLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(ThirdLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(FourthLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(FifthLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(SixthLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(SeventhLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(EightLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(NinthLevelListView, myAvailableSpells, myPreparedSpells);
            DialogResult = DialogResult.OK;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bool Exists = false;
            foreach (var spell in myAvailableSpells)
            {
                if (string.IsNullOrEmpty(mySpells.SpellName) == false && spell.SpellName.Equals(mySpells.SpellName))
                {
                    Exists = true;
                }
                else
                {
                    Exists = false;
                }
            }

            if (Exists == false) 
            {

                Spell NewSpell = new Spell();
                NewSpell.SpellName = mySpells.SpellName;
                NewSpell.SpellLevel = mySpells.SpellLevel; // cantrip = 0
                NewSpell.Range = mySpells.Range;
                NewSpell.CastTime = mySpells.CastTime;
                NewSpell.Components = mySpells.Components;
                NewSpell.SpellSchool = mySpells.SpellSchool;
                NewSpell.SpellDC = mySpells.SpellDC;
                NewSpell.SpellBonus = mySpells.SpellBonus;
                NewSpell.SpellDamage = mySpells.SpellDamage;
                NewSpell.Duration = mySpells.Duration;
                NewSpell.SpellDamageType = mySpells.SpellDamageType;
                NewSpell.SpellDescription = mySpells.SpellDescription;

                myAvailableSpells.Add(NewSpell);
                ClearTextBoxes(this.Controls);
            }
            else
            {
                MessageBox.Show("Item Already exsits");
            }
            RunAvailableSpellsList();

        }

        private void CantripsRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(CantripsListView);
        }

        private void FirstRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(FirstLevelListView);
        }

        private void SecondRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(SecondLevelListView);
        }

        private void ThirdRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(ThirdLevelListView);
        }

        private void FourthRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(FourthLevelListView);
        }

        private void FifthRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(FifthLevelListView);
        }

        private void SixthRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(SixthLevelListView);
        }

        private void SeventhRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(SeventhLevelListView);
        }

        private void EightRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(EightLevelListView);
        }

        private void NinthRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromList(NinthLevelListView);
        }

        #endregion

        #region TEXTCHANGED
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(NameTextBox.Text);
            mySpells.SpellName = NewValue(OutOfReach, NameTextBox.Text);

        }

        private void LevelTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(LevelTextBox.Text);
            if(OutOfReach == false && Convert.ToInt32(LevelTextBox.Text) >= 0 && Convert.ToInt32(LevelTextBox.Text) <= 9)
            {
                mySpells.SpellLevel = Convert.ToInt32(NewValue(OutOfReach, LevelTextBox.Text));
            }
            else if(OutOfReach == false)
            {
                MessageBox.Show("level Must be within range 0 to 9");
                LevelTextBox.Text = "1";
            }
        }

        private void RangeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(RangeTextBox.Text);
            mySpells.Range = NewValue(OutOfReach, RangeTextBox.Text)+"ft.";
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
            mySpells.SpellDamage = NewValue(OutOfReach, DamageTextBox.Text) + DamageComboBox.Text;
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
            SpellBonusComboBox.Text = SpellBonusComboBox.SelectedText;
        }

        private void DamageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mySpells.SpellDamage = DamageTextBox.Text + DamageComboBox.Text;
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
        void ClearTextBoxes(Control.ControlCollection Spellbook)
        {
            foreach (Control TextBox in Spellbook)
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
        void RunAvailableSpellsList()
        {
            foreach (var Spell in myAvailableSpells)
            switch (Spell.SpellLevel)
            {
                case 0:
                    AvailableSpellsList(0, CantripsListView);
                    break;
                case 1:
                    AvailableSpellsList(1, FirstLevelListView);
                    break;
                case 2:
                    AvailableSpellsList(2, SecondLevelListView);
                    break;
                case 3:
                    AvailableSpellsList(3, ThirdLevelListView);
                    break;
                case 4:
                    AvailableSpellsList(4, FourthLevelListView);
                    break;
                case 5:
                    AvailableSpellsList(5, FifthLevelListView);
                    break;
                case 6:
                    AvailableSpellsList(6, SixthLevelListView);
                    break;
                case 7:
                    AvailableSpellsList(7,SeventhLevelListView);
                    break;
                case 8:
                    AvailableSpellsList(8, EightLevelListView);
                    break;
                case 9:
                    AvailableSpellsList(9, NinthLevelListView);
                    break;
                default:
                    break;
            }
        }
        void AvailableSpellsList(int SpellLvl, ListView ListToFill)
        {
            ListToFill.Items.Clear();
            int i = 0;
            foreach (var Spell in myAvailableSpells)
            {
                if (Spell.SpellLevel == SpellLvl)
                {
                    ListToFill.Items.Add(Spell.SpellName,i);
                    ListToFill.Items[i].SubItems.Add(Convert.ToString(Spell.SpellLevel));
                    ListToFill.Items[i].SubItems.Add(Convert.ToString(Spell.Range));
                    ListToFill.Items[i].SubItems.Add(Spell.CastTime);
                    ListToFill.Items[i].SubItems.Add(Spell.Components);
                    ListToFill.Items[i].SubItems.Add(Spell.SpellSchool);
                    ListToFill.Items[i].SubItems.Add(Convert.ToString(Spell.SpellDC));
                    ListToFill.Items[i].SubItems.Add(Convert.ToString(Spell.SpellBonus));
                    ListToFill.Items[i].SubItems.Add(Convert.ToString(Spell.SpellDamage));
                    ListToFill.Items[i].SubItems.Add(Spell.Duration);
                    ListToFill.Items[i].SubItems.Add(Spell.SpellDamageType);
                    ListToFill.Items[i].SubItems.Add(Spell.SpellDescription);
                    i++;
                }
                else
                {
                }
            }
        }
        void AddToPreparedSpells(ListView ListViewTotakeFrom, List<Spell> AvailableSpells, List<Spell> PreparedList)
        {
            for (int i = 0; i < ListViewTotakeFrom.Items.Count; i++)
            {
                if (ListViewTotakeFrom.Items[i].Checked == true)
                {
                    for (int j = 0; j < AvailableSpells.Count; j++)
                    {
                        if (AvailableSpells[j].SpellName.Equals(ListViewTotakeFrom.Items[i].Text))
                        {
                            PreparedList.Add(AvailableSpells[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < AvailableSpells.Count; j++)
                    {
                        if (AvailableSpells[j].SpellName.Equals(ListViewTotakeFrom.Items[i].Text))
                        {
                            PreparedList.Remove(AvailableSpells[j]);
                        }
                    }
                }

            }
        }

        void RemoveFromList(ListView ListToRemoveFrom)
        {
            for (int i = 0; i < ListToRemoveFrom.Items.Count; i++)
            {
                if (ListToRemoveFrom.Items[i].Selected)
                {
                    for (int j = 0; j < myAvailableSpells.Count; j++)
                        if (myAvailableSpells[j].SpellName.Equals(ListToRemoveFrom.Items[i].Text))
                        {
                            myAvailableSpells.RemoveAt(j);
                            ListToRemoveFrom.Items[i].Remove();
                        }
                }
                else
                {
                }
            }
            RunAvailableSpellsList();
        }



        #endregion

    }
}
