using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Skill
    {
        public bool[] proficiency = new bool[18];
        //public bool JackOfAllTrades;
        public int Jack;

        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();

        public Skill(CharacterAttributes Attribu, Character Charac)
        {
            myAttributes = Attribu;
            myCharacter = Charac;
        }

        public Skill()
        {
         //if (JackOfAllTrades == true)
         //   {
         //       Jack = myCharacter.proficiencyBonus / 2;

         //   } else if (JackOfAllTrades == false)
         //   {
         //       Jack = 0;
         //   }
        }

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
