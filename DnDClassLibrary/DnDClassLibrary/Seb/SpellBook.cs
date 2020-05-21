using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class SpellBook
    {

        List<Spell> AvailableSpellList = new List<Spell>(); // indlæs alle tilgængelige spells fra database? gør måske static??
        List<Spell> PreparedSpellList = new List<Spell>(); //liste over prepared spells
        UtillityMethods Utility = new UtillityMethods();

        public bool ConditionalNewValue(List<Spell> mySpellList, bool Exists, string SpellsName) // tjekker om et objekt med navnet ekstisterer
        {
            foreach (var spell in mySpellList) // kigger spellListen igennem efter objektet med givne navn
            {
                if (string.IsNullOrEmpty(SpellsName) == false && spell.SpellName.Equals(SpellsName))
                {
                    Exists = true;
                }
            }
            return Exists;
        }

        // Laver og returnerer et object, som derefter tilføjes til en liste
        public DnDClassLibrary.Spell AddSpell(bool Exists, string SpellName, int SpellLevel, string Range, string CastTime, string Components, string SpellSchool, int SpellDC, string SpellBonus, string SpellDamage, string Duration, string DamageType, string Description)
        {
            if (Exists == false) // hvis objectet ikke allerede ekssisterer laver den det.
            {
                Spell NewSpell = new Spell(); // laver en ny instance af Spell classen
                NewSpell.SpellName = SpellName;
                NewSpell.SpellLevel = SpellLevel; // cantrip = 0
                NewSpell.Range = Range;
                NewSpell.CastTime = CastTime;
                NewSpell.Components = Components;
                NewSpell.SpellSchool = SpellSchool;
                NewSpell.SpellDC = SpellDC;
                NewSpell.SpellBonus = SpellBonus;
                NewSpell.SpellDamage = SpellDamage;
                NewSpell.Duration = Duration;
                NewSpell.SpellDamageType = DamageType;
                NewSpell.SpellDescription = Description;
                return NewSpell; // returnere hele objectet

            }
            else
            {
                return null; // returnerer null hvis objektet eksisterer
            }
        }
    }
}
