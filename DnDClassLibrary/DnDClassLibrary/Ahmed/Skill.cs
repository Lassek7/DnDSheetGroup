using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Skill
    {
        public int DexterityModifier;
        public int StrengthModifier;
        public int ConstitutionModifier;
        public int IntelligenceModifier;
        public int WisdomModifier;
        public int CharismaModifier;
        public int ProficiencyBonus;

        private int Jack;
        private bool[] proficiency = new bool[18];

        public Skill(int StrengthModifier, int DexterityModifier, int ConstitutionModifier, int IntelligenceModifier,
            int WisdomModifier, int CharismaModifier, int ProficiencyBonus, int[] proficiencyEnabled, bool JackOfAllTrades)
        {
            this.StrengthModifier = StrengthModifier;
            this.DexterityModifier = DexterityModifier;
            this.ConstitutionModifier = ConstitutionModifier;
            this.IntelligenceModifier = IntelligenceModifier;
            this.WisdomModifier = WisdomModifier;
            this.CharismaModifier = CharismaModifier;
            this.ProficiencyBonus = ProficiencyBonus;

         if (JackOfAllTrades == true)
            {
                foreach (int index in proficiencyEnabled)
                    proficiency[index] = true;
                Jack = ProficiencyBonus / 2;

            } else if (JackOfAllTrades == false)
            {
                foreach (int index in proficiencyEnabled)
                    proficiency[index] = true;
                Jack = 0;
            }
        }
        public Skill() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Acrobatics " + Acrobatics + "\n");
            sb.Append("AnimalHandling " + AnimalHandling + "\n");
            sb.Append("Arcana " + Arcana + "\n");
            sb.Append("Athletics " + Athletics + "\n");
            sb.Append("Deception " + Deception + "\n");
            sb.Append("History " + History + "\n");
            sb.Append("Insight " + Insight + "\n");
            sb.Append("Intimidation " + Intimidation + "\n");
            sb.Append("Investigation " + Investigation + "\n");
            sb.Append("Medicine " + Medicine + "\n");
            sb.Append("Performance " + Performance + "\n");
            sb.Append("Persuasion " + Persuasion + "\n");
            sb.Append("Religion " + Religion + "\n");
            sb.Append("Sleight of Hand " + SleightOfHand + "\n");
            sb.Append("Stealth " + Stealth + "\n");
            sb.Append("Survival " + Survival + "\n");
            return sb.ToString();
        }

        public int Acrobatics
        {
            get { return DexterityModifier + (proficiency[0] ? ProficiencyBonus : Jack ) ; }
        }
        public int AnimalHandling
        {
            get { return WisdomModifier + (proficiency[1] ? ProficiencyBonus : Jack) ; }
        }
        public int Arcana
        {
            get { return IntelligenceModifier + (proficiency[2] ? ProficiencyBonus : Jack) ; }
        }
        public int Athletics
        {
            get { return StrengthModifier + (proficiency[3] ? ProficiencyBonus : Jack) ; }
        }
        public int Deception
        {
            get { return CharismaModifier + (proficiency[4] ? ProficiencyBonus : Jack) ; }
        }
        public int History
        {
            get { return IntelligenceModifier + (proficiency[5] ? ProficiencyBonus : Jack) ; }
        }

        public int Insight
        {
            get { return WisdomModifier + (proficiency[6] ? ProficiencyBonus : Jack) ; }
        }

        public int Intimidation
        {
            get { return CharismaModifier + (proficiency[7] ? ProficiencyBonus : Jack) ; }
        }

        public int Investigation
        {
            get { return IntelligenceModifier + (proficiency[8] ? ProficiencyBonus : Jack) ; }
        }

        public int Medicine
        {
            get { return WisdomModifier + (proficiency[9] ? ProficiencyBonus : Jack) ; }
        }

        public int Nature
        {
            get { return IntelligenceModifier + (proficiency[10] ? ProficiencyBonus : Jack) ; }
        }

        public int Perception
        {
            get { return WisdomModifier + (proficiency[11] ? ProficiencyBonus : Jack) ; }
        }

        public int Performance
        {
            get { return CharismaModifier + (proficiency[12] ? ProficiencyBonus : Jack) ; }
        }

        public int Persuasion
        {
            get { return CharismaModifier + (proficiency[13] ? ProficiencyBonus : Jack) ; }
        }

        public int Religion
        {
            get { return IntelligenceModifier + (proficiency[14] ? ProficiencyBonus : Jack) ; }
        }

        public int SleightOfHand
        {
            get { return DexterityModifier + (proficiency[15] ? ProficiencyBonus : Jack) ; }
        }

        public int Stealth
        {
            get { return DexterityModifier + (proficiency[16] ? ProficiencyBonus : Jack) ; }
        }

        public int Survival
        {
            get { return WisdomModifier + (proficiency[17] ? ProficiencyBonus : Jack) ; }
        }
    }
}
