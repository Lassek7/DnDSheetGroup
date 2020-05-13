using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Spell
    {
        string spellName;
        int spellLevel; // cantrip = 0
        string range;
        string castTime;
        string components;
        string spellSchool;
        int spellDC;
        string spellBonus;
        string spellDamage;
        string duration;
        string spellDamageType;
        string spellDescription;

        public Spell()
        {
        }

        public Spell(string spellName)
        {
            this.spellName = spellName;
        }

        // Get - Set
        public string SpellName
        {
            get { return spellName; }
            set { spellName = value; }
        }

        public string Components
        {
            get { return components; }
            set { components = value; }
        }
        public string SpellDamage
        {
            get { return spellDamage; }
            set { spellDamage = value; }
        }
        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string CastTime
        {
            get { return castTime; }
            set { castTime = value; }
        }

        public string Range
        {
            get { return range; }
            set { range = value; }
        }

        public int SpellLevel
        {
            get { return spellLevel; }
            set { spellLevel = value; }
        }

        public string SpellSchool
        {
            get { return spellSchool; }
            set { spellSchool = value; }
        }

        public string SpellDescription
        {
            get { return spellDescription; }
            set { spellDescription = value; }
        }

        public string SpellDamageType
        {
            get { return spellDamageType; }
            set { spellDamageType = value; }
        }

        public int SpellDC
        {
            get { return spellDC; }
            set { spellDC = value; }
        }

        public string SpellBonus
        {
            get { return spellBonus; }
            set { spellBonus = value; }
        }
    }
}

