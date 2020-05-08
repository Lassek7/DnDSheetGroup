using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Skill
    {
        public bool[] proficiency = new bool[18];

        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();

        public Skill(CharacterAttributes Attribu, Character Charac)
        {
            myAttributes = Attribu;
            myCharacter = Charac;
        }

        public Skill()
        {
        }

        public int Acrobatics
        {
            get { return myAttributes.Modifiers[1] + (proficiency[0] ? myCharacter.proficiencyBonus : 0); }
        }
        public int AnimalHandling
        {
            get { return myAttributes.Modifiers[4] + (proficiency[1] ? myCharacter.proficiencyBonus : 0); }
        }
        public int Arcana
        {
            get { return myAttributes.Modifiers[3] + (proficiency[2] ? myCharacter.proficiencyBonus : 0); }
        }
        public int Athletics
        {
            get { return myAttributes.Modifiers[0] + (proficiency[3] ? myCharacter.proficiencyBonus : 0); }
        }
        public int Deception
        {
            get { return myAttributes.Modifiers[5] + (proficiency[4] ? myCharacter.proficiencyBonus : 0); }
        }
        public int History
        {
            get { return myAttributes.Modifiers[3] + (proficiency[5] ? myCharacter.proficiencyBonus : 0); }
        }
        public int Insight
        {
            get { return myAttributes.Modifiers[4] + (proficiency[6] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Intimidation
        {
            get { return myAttributes.Modifiers[5] + (proficiency[7] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Investigation
        {
            get { return myAttributes.Modifiers[3] + (proficiency[8] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Medicine
        {
            get { return myAttributes.Modifiers[4] + (proficiency[9] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Nature
        {
            get { return myAttributes.Modifiers[3] + (proficiency[10] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Perception
        {
            get { return myAttributes.Modifiers[4] + (proficiency[11] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Performance
        {
            get { return myAttributes.Modifiers[5] + (proficiency[12] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Persuasion
        {
            get { return myAttributes.Modifiers[5] + (proficiency[13] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Religion
        {
            get { return myAttributes.Modifiers[3] + (proficiency[14] ? myCharacter.proficiencyBonus : 0); }
        }

        public int SleightOfHand
        {
            get { return myAttributes.Modifiers[1] + (proficiency[15] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Stealth
        {
            get { return myAttributes.Modifiers[1] + (proficiency[16] ? myCharacter.proficiencyBonus : 0); }
        }

        public int Survival
        {
            get { return myAttributes.Modifiers[4] + (proficiency[17] ? myCharacter.proficiencyBonus : 0); }
        }
    }
}
