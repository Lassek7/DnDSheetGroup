using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Skill
    {
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();

        public Skill(CharacterAttributes Attribu, Character Charac)
        {
            myAttributes = Attribu;
            myCharacter = Charac;

        }
        private int Jack;
        private bool[] proficiency = new bool[18];

        public Skill(int[] proficiencyEnabled, bool JackOfAllTrades)
        {

         if (JackOfAllTrades == true)
            {
                foreach (int index in proficiencyEnabled)
                    proficiency[index] = true;
                Jack = myCharacter.proficiencyBonus / 2;

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

        public int Acrobatics
        {
            get { return myAttributes.Modifiers[1] + (proficiency[0] ? myCharacter.proficiencyBonus : Jack); }
        }
        public int AnimalHandling
        {
            get { return myAttributes.Modifiers[4] + (proficiency[1] ? myCharacter.proficiencyBonus : Jack); }
        }
        public int Arcana
        {
            get { return myAttributes.Modifiers[3] + (proficiency[2] ? myCharacter.proficiencyBonus : Jack); }
        }
        public int Athletics
        {
            get { return myAttributes.Modifiers[0] + (proficiency[3] ? myCharacter.proficiencyBonus : Jack); }
        }
        public int Deception
        {
            get { return myAttributes.Modifiers[5] + (proficiency[4] ? myCharacter.proficiencyBonus : Jack); }
        }
        public int History
        {
            get { return myAttributes.Modifiers[3] + (proficiency[5] ? myCharacter.proficiencyBonus : Jack); }
        }
        public int Insight
        {
            get { return myAttributes.Modifiers[4] + (proficiency[6] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Intimidation
        {
            get { return myAttributes.Modifiers[5] + (proficiency[7] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Investigation
        {
            get { return myAttributes.Modifiers[3] + (proficiency[8] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Medicine
        {
            get { return myAttributes.Modifiers[4] + (proficiency[9] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Nature
        {
            get { return myAttributes.Modifiers[3] + (proficiency[10] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Perception
        {
            get { return myAttributes.Modifiers[4] + (proficiency[11] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Performance
        {
            get { return myAttributes.Modifiers[5] + (proficiency[12] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Persuasion
        {
            get { return myAttributes.Modifiers[5] + (proficiency[13] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Religion
        {
            get { return myAttributes.Modifiers[3] + (proficiency[14] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int SleightOfHand
        {
            get { return myAttributes.Modifiers[1] + (proficiency[15] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Stealth
        {
            get { return myAttributes.Modifiers[1] + (proficiency[16] ? myCharacter.proficiencyBonus : Jack); }
        }

        public int Survival
        {
            get { return myAttributes.Modifiers[4] + (proficiency[17] ? myCharacter.proficiencyBonus : Jack); }
        }
    }
}
