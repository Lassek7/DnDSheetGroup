using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class Skill
    {
        
        private int ProficiencyBonus;
        private int Jack;
        private bool[] proficiency = new bool[18];

        public Skill(int ProficiencyBonus, int[] proficiencyEnabled, bool JackOfAllTrades)
        {
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

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Acrobatics " + Acrobatics + "\n");
        //    sb.Append("AnimalHandling " + AnimalHandling + "\n");
        //    sb.Append("Arcana " + Arcana + "\n");
        //    sb.Append("Athletics " + Athletics + "\n");
        //    sb.Append("Deception " + Deception + "\n");
        //    sb.Append("History " + History + "\n");
        //    sb.Append("Insight " + Insight + "\n");
        //    sb.Append("Intimidation " + Intimidation + "\n");
        //    sb.Append("Investigation " + Investigation + "\n");
        //    sb.Append("Medicine " + Medicine + "\n");
        //    sb.Append("Nature " + Nature + "\n");
        //    sb.Append("Perception " + Perception + "\n");
        //    sb.Append("Performance " + Performance + "\n");
        //    sb.Append("Persuasion " + Persuasion + "\n");
        //    sb.Append("Religion " + Religion + "\n");
        //    sb.Append("Sleight of Hand " + SleightOfHand + "\n");
        //    sb.Append("Stealth " + Stealth + "\n");
        //    sb.Append("Survival " + Survival + "\n");
        //    return sb.ToString();
        //}

        //public int Acrobatics
        //{
        //    get { return CharacterAttributes.Modifiers[1] + (proficiency[0] ? ProficiencyBonus : Jack ) ; }
        //}
        //public int AnimalHandling
        //{
        //    get { return CharacterAttributes.Modifiers[4] + (proficiency[1] ? ProficiencyBonus : Jack) ; }
        //}
        //public int Arcana
        //{
        //    get { return CharacterAttributes.Modifiers[3] + (proficiency[2] ? ProficiencyBonus : Jack) ; }
        //}
        //public int Athletics
        //{
        //    get { return CharacterAttributes.Modifiers[0] + (proficiency[3] ? ProficiencyBonus : Jack) ; }
        //}
        //public int Deception
        //{
        //    get { return CharacterAttributes.Modifiers[5] + (proficiency[4] ? ProficiencyBonus : Jack) ; }
        //}
        //public int History
        //{
        //    get { return CharacterAttributes.Modifiers[3] + (proficiency[5] ? ProficiencyBonus : Jack) ; }
        //}
        //public int Insight
        //{
        //    get { return CharacterAttributes.Modifiers[4] + (proficiency[6] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Intimidation
        //{
        //    get { return CharacterAttributes.Modifiers[5] + (proficiency[7] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Investigation
        //{
        //    get { return CharacterAttributes.Modifiers[3] + (proficiency[8] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Medicine
        //{
        //    get { return CharacterAttributes.Modifiers[4] + (proficiency[9] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Nature
        //{
        //    get { return CharacterAttributes.Modifiers[3] + (proficiency[10] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Perception
        //{
        //    get { return CharacterAttributes.Modifiers[4] + (proficiency[11] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Performance
        //{
        //    get { return CharacterAttributes.Modifiers[5] + (proficiency[12] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Persuasion
        //{
        //    get { return CharacterAttributes.Modifiers[5] + (proficiency[13] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Religion
        //{
        //    get { return CharacterAttributes.Modifiers[3] + (proficiency[14] ? ProficiencyBonus : Jack) ; }
        //}

        //public int SleightOfHand
        //{
        //    get { return CharacterAttributes.Modifiers[1] + (proficiency[15] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Stealth
        //{
        //    get { return CharacterAttributes.Modifiers[1] + (proficiency[16] ? ProficiencyBonus : Jack) ; }
        //}

        //public int Survival
        //{
        //    get { return CharacterAttributes.Modifiers[4] + (proficiency[17] ? ProficiencyBonus : Jack) ; }
        //}
    }
}
