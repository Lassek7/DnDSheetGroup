using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class SavingThrow
    {
        private bool[] proficiency = new bool[6];
        private int ProficiencyBonus;
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();

        public SavingThrow(int ProficiencyBonus, int[] proficiencyEnabled)
        {
            this.ProficiencyBonus = ProficiencyBonus;

            foreach (int index in proficiencyEnabled)
                proficiency[index] = true;
        }
        public SavingThrow(CharacterAttributes Attribu, Character Charac)
        {
            myAttributes = Attribu;
            myCharacter = Charac;

        }
        public override string ToString()
        {
            StringBuilder sbb = new StringBuilder();
            sbb.Append("Strength " + StrengthSave + "\n");
            sbb.Append("Dexterity " + DexteritySave + "\n");
            sbb.Append("Constitution " + ConstitutionSave + "\n");
            sbb.Append("Intelligence " + IntelligenceSave + "\n");
            sbb.Append("Wisdom " + WisdomSave + "\n");
            sbb.Append("Charisma " + CharismaSave + "\n");
            return sbb.ToString();
        }

        public int StrengthSave
        {
            get { return myAttributes.Modifiers[0] + (proficiency[0] ? ProficiencyBonus : 0); }
        }
        public int DexteritySave
        {
            get { return myAttributes.Modifiers[1] + (proficiency[1] ? ProficiencyBonus : 0); }
        }
        public int ConstitutionSave
        {
            get { return myAttributes.Modifiers[2] + (proficiency[2] ? ProficiencyBonus : 0); }
        }
        public int IntelligenceSave
        {
            get { return myAttributes.Modifiers[3] + (proficiency[3] ? ProficiencyBonus : 0); }
        }
        public int WisdomSave
        {
            get { return myAttributes.Modifiers[4] + (proficiency[4] ? ProficiencyBonus : 0); }
        }
        public int CharismaSave
        {
            get { return myAttributes.Modifiers[5] + (proficiency[5] ? ProficiencyBonus : 0); }
        }
    }
}
