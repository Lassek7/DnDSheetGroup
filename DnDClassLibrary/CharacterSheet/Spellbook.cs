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
        SpellBook mySpellBook = new SpellBook();
        List<Spell> myPreparedSpells = new List<Spell>();
        List<Spell> myAvailableSpells = new List<Spell>();
        UtillityMethods myUtillities = new UtillityMethods();
        Spell mySpells = new Spell();

        public Spellbook(Character Charac, List<Spell> PreparedSpellList, List<Spell> AvailableSpellsList)
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
            myPreparedSpells = PreparedSpellList;
            myAvailableSpells = AvailableSpellsList;
            RunColors();
            RunAvailableSpellsList();
        }
        #region CLICKEVENTS

        private void MenuButton_Click(object sender, EventArgs e) // sender brugeren tilbage til Character Sheetet
        {
            myPreparedSpells.Clear();
            AddToPreparedSpells(CantripsListView, myAvailableSpells, myPreparedSpells); // tilføjer Cantrips til Preparedspellslisten
            AddToPreparedSpells(FirstLevelListView, myAvailableSpells, myPreparedSpells); // tilføjer 1st lvl spells til Preparedspellslisten
            AddToPreparedSpells(SecondLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(ThirdLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(FourthLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(FifthLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(SixthLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(SeventhLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(EightLevelListView, myAvailableSpells, myPreparedSpells);
            AddToPreparedSpells(NinthLevelListView, myAvailableSpells, myPreparedSpells);
            DialogResult = DialogResult.OK; //Giver DialogResult en værdi af ok, som gør at spells listen går tilbage til og opdaterer sheetet.

        }

        private void AddButton_Click(object sender, EventArgs e) // Tilføjer en spell til en liste.
        {
            bool Exists = false;
            Exists = mySpellBook.ConditionalNewValue(myAvailableSpells, Exists, mySpells.SpellName); // tjekker om en spell allerede eksitere
            DnDClassLibrary.Spell NewSpell = mySpellBook.AddSpell(Exists, mySpells.SpellName, mySpells.SpellLevel, mySpells.Range, mySpells.CastTime, mySpells.Components, mySpells.SpellSchool, mySpells.SpellDC, 
                                                      mySpells.SpellBonus, mySpells.SpellDamage, mySpells.Duration, mySpells.SpellDamageType, mySpells.SpellDescription); // tilføjer en nye spell i form af objektet NewSpell
            if (NewSpell == null) // hvis null NewSpell's værdi er Null, så kommer der en prompt om at det allerede existere.
            {
                MessageBox.Show("Item Already exists");
            }
            else
            {
                myAvailableSpells.Add(NewSpell); // hvis NewSpell ikke er Null Bliver den tilføjet til Available spells.
                ClearTextBoxes(this.Controls); // rydder alle bokse, så der kan skrive nyt i dem.
            }
            RunAvailableSpellsList();
        }

        // fjerner spells fra den specifikke liste og fra available spells list.
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
            bool OutOfReach = string.IsNullOrEmpty(NameTextBox.Text); // tjekker om Tekstboksen er tom
            mySpells.SpellName = myUtillities.NewValue(OutOfReach, NameTextBox.Text); // hvis tekstboksen ikke er tom, så ændre værdien i mySpells.Spellname sig til det givne værdi

        }

        private void LevelTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(LevelTextBox.Text);
            if(OutOfReach == false && Convert.ToInt32(LevelTextBox.Text) >= 0 && Convert.ToInt32(LevelTextBox.Text) <= 9) // tjekker om spell lvl'et er fra 0 - 9
            {
                mySpells.SpellLevel = Convert.ToInt32(myUtillities.NewValue(OutOfReach, LevelTextBox.Text));  
            }
            else if(OutOfReach == false) // Hvis lvlet ikke er fra  0 - 9  bliver den sat til 1
            {
                MessageBox.Show("level Must be within range 0 to 9");
                LevelTextBox.Text = "1";
            }
        }

        private void RangeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(RangeTextBox.Text);
            mySpells.Range = myUtillities.NewValue(OutOfReach, RangeTextBox.Text)+"ft.";
        }

        private void CastTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(CastTimeTextBox.Text);
            mySpells.CastTime = myUtillities.NewValue(OutOfReach, CastTimeTextBox.Text);
        }

        private void ComponentTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(ComponentTextBox.Text);
            mySpells.Components = myUtillities.NewValue(OutOfReach, ComponentTextBox.Text);
        }

        private void SchoolTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(SchoolTextBox.Text);
            mySpells.SpellSchool = myUtillities.NewValue(OutOfReach, SchoolTextBox.Text);
        }

        private void DCTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DCTextBox.Text);
            mySpells.SpellDC = Convert.ToInt32(myUtillities.NewValue(OutOfReach, DCTextBox.Text));
        }

        private void DamageTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DamageTextBox.Text);
            mySpells.SpellDamage = myUtillities.NewValue(OutOfReach, DamageTextBox.Text) + DamageComboBox.Text;
        }
       
        private void DurationTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DurationTextBox.Text);
            mySpells.Duration = myUtillities.NewValue(OutOfReach, DurationTextBox.Text);
        }

        private void DamageTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DamageTypeTextBox.Text);
            mySpells.SpellDamageType = myUtillities.NewValue(OutOfReach, DamageTypeTextBox.Text);
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(DescriptionTextBox.Text);
            mySpells.SpellDescription = myUtillities.NewValue(OutOfReach, DescriptionTextBox.Text);
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
     
        void OnlyTakeNumbers(KeyPressEventArgs e) // Sørger for, at der kun kan skrives tal i tekstboksen
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // Hvis værdien der indputtes er et tal(knappen man trykker), bliver e.handled sat til true og inputtet accepteret.
            {
                e.Handled = true;
            }
        }
       
        void ClearTextBoxes(Control.ControlCollection Spellbook) // rydder alle tekstbokse
        {
            foreach (Control TextBox in Spellbook) 
            {
                if (TextBox is TextBoxBase) // 
                {
                    TextBox.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(TextBox.Controls);
                }
            }
        }
      
        void RunAvailableSpellsList() // Viser spellsne der er added i deres respektive lister.
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
      
        void AvailableSpellsList(int SpellLvl, ListView ListToFill)  // Fylder en liste med de spells der hører til i den.
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
                    MessageBox.Show("All Spells from the list have been added.");
                }
            }
        }
      
        void AddToPreparedSpells(ListView ListViewTotakeFrom, List<Spell> AvailableSpells, List<Spell> PreparedList) // Tilføjer spells fra listview boksene til prepared spells
        {
            for (int i = 0; i < ListViewTotakeFrom.Items.Count; i++)  // Kører et forloop igennem op til mængden af items i Listview
            {
                if (ListViewTotakeFrom.Items[i].Checked == true) // Hvis der er sat et checkmark på udfor et item på listen kører et nyt forloop
                {
                    for (int j = 0; j < AvailableSpells.Count; j++) // Listen af available spells bliver kørt igennem
                    {
                        if (AvailableSpells[j].SpellName.Equals(ListViewTotakeFrom.Items[i].Text)) // Hvis listview spell navnet der er tjekket findes i Availablespells bliver den tilføjet til prepared spells
                        {
                            PreparedList.Add(AvailableSpells[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < myPreparedSpells.Count; j++) // Hvis der ikke er et checkmark udfor en spell, vil available spellslist blivet set igennem for spellen, hvorefter den fjernes fra listen
                    {
                        if (myPreparedSpells[j].SpellName.Equals(ListViewTotakeFrom.Items[i].Text))
                        {
                            PreparedList.Remove(myPreparedSpells[j]);
                        }
                    }
                }

            }
        }

        void RemoveFromList(ListView ListToRemoveFrom) // fjerner en spell fra listview og available spells listen
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
       
        void RunColors() // kører farverne i spellBooken
        {
            CantripsListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            FirstLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            SecondLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            ThirdLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            FourthLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            FifthLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            SixthLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            SeventhLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            EightLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
            NinthLevelListView.BackColor = ColorTranslator.FromHtml("#CDBCB1");
        }


        #endregion

    }
}
