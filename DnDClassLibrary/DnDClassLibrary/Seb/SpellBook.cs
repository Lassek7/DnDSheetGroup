using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class SpellBook
    {

        public List<Spell> AvailableSpellList = new List<Spell>(); // indlæs alle tilgængelige spells fra database? gør måske static??
        public List<Spell> PreparedSpellList = new List<Spell>(); //liste over prepared spells
        UtilityMethods Utillity = new UtilityMethods();

        void PrepareSpell() //add a spell to the "PreparedSpells" list
        {
            Spell NewSpell = new Spell();

            NewSpell.SpellName = Utillity.ReadTextInput("Enter Spell name");
            NewSpell.Components = Utillity.ReadTextInput("Enter Required Components");
            NewSpell.Duration = Utillity.ReadTextInput("Enter Spell duration");
            NewSpell.CastTime = Utillity.ReadTextInput("Enter Cast time");
            NewSpell.Range = Utillity.ReadNumericInput("Enter Spell Range");
            NewSpell.SpellLevel = Utillity.ReadTextInput("Enter Spell level");
            NewSpell.SpellSchool = Utillity.ReadTextInput("Enter Spell School");
            NewSpell.SpellDescription = Utillity.ReadTextInput("Enter Spell Description");
            NewSpell.SpellPrepared = true;
            NewSpell.Resources = Utillity.ReadNumericInput("Enter required resources");
            NewSpell.SpellDC = Utillity.ReadNumericInput("Enter Spell DC");
            NewSpell.SpellBonus = Utillity.ReadNumericInput("Enter Spell bonus");

            PreparedSpellList.Add(NewSpell);
        }

        void UnPrepareSpell()
        {
            string SpellToUnprepare = Utillity.ReadTextInput("Enter Spell name of the spell you wish to no longer prepare");
            PreparedSpellList.Remove(new Spell(SpellToUnprepare)); //burde fjerne den indtastede spell fra Prepared Spells listen, skal testes
            Console.WriteLine("No longer preparing " + SpellToUnprepare);
            SpellToUnprepare = null; // reset variabel

        }

        void ShowPreparedSpells()
        {
            PreparedSpellList.ForEach(Console.WriteLine);
        }

    }
}
