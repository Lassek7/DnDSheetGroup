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
        #region GETTERS&SETTERS
        // Hver Getter og Setter tjekker om der er sat proficiency til eller ej
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
        #endregion
        #region METHODS
        public string CheckJackOfAllTradesToggle(int HalfBonus, bool ProficiencyToggle, bool JackToggle, int OldValue, string CurrentValue) // udregner værdien for JackOfAllTrades
        {
            int NewValue = HalfBonus / 2 + OldValue; // Giver NewValue værden af halvdelen af brugerens proficiency Bonus
            if (ProficiencyToggle == false && JackToggle == true) // hvis JAckofAllTrades er slået til, men der ikke er proficency, returnerers værdien af NewValue
            {
                return Convert.ToString(NewValue);
            }
            else if (ProficiencyToggle == true && JackToggle == true) // Hvis proficency er true og JackOfAllTrades er true, så returnerers den CurrentValue, som er værdien med proficency bonus, da Proficency trumfer JackOfAllTrades
            {
                return Convert.ToString(CurrentValue);
            }
            else if (ProficiencyToggle == true && JackToggle == false) // returnere Currentvalue, da Proficency er true
            {
                return Convert.ToString(CurrentValue);
            }
            else // ellers hvis ingen af dem er true, så returneres den originale værdi uden proficency Bonus
            {
                return Convert.ToString(OldValue);
            }
        }
        #endregion
    }
}
