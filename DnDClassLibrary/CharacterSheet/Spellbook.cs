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

        public Spellbook(Character Charac, List<Spell> SpellList)
        {
            InitializeComponent();
            myPreparedSpells = SpellList;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
