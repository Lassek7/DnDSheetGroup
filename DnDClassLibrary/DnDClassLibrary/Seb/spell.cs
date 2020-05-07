using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Spell
    {
        private string spellName;
        private string components;
        private string duration;
        private string castTime;
        private int range;
        private int spellLevel; // cantrip = 0
        private string spellSchool;
        private string spellDescription;
        private int resources;
        private int spellDC;
        private int spellBonus;

        public Spell()
        {
        }

        public Spell(string spellName)
        {
            this.spellName = spellName;
        }

        public Spell(string spellName,
            string components,
            string duration,
            string castTime,
            int range,
            int spellLevel,
            string spellSchool,
            string spellDescription,
            int resources,
            int spellDC,
            int spellBonus)
        {
            this.spellName = spellName;
            this.components = components;
            this.duration = duration;
            this.castTime = castTime;
            this.range = range;
            this.spellLevel = spellLevel;
            this.spellSchool = spellSchool;
            this.spellDescription = spellDescription;
            this.resources = resources;
            this.spellDC = spellDC;
            this.spellBonus = spellBonus;

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

        public int Range
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

        public int Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        public int SpellDC
        {
            get { return spellDC; }
            set { spellDC = value; }
        }

        public int SpellBonus
        {
            get { return spellBonus; }
            set { spellBonus = value; }
        }
    }
}

