using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class SavingThrow
    {
        private bool[] proficiency = new bool[6];
        private int ProficiencyBonus;

        public SavingThrow(int ProficiencyBonus, int[] proficiencyEnabled)
        {
            this.ProficiencyBonus = ProficiencyBonus;

            foreach (int index in proficiencyEnabled)
                proficiency[index] = true;
        }        

        public override string ToString()
        {
            StringBuilder sbb = new StringBuilder();
            sbb.Append("Strength " + Strength + "\n");
            sbb.Append("Dexterity " + Dexterity + "\n");
            sbb.Append("Constitution " + Constitution + "\n");
            sbb.Append("Intelligence " + Intelligence + "\n");
            sbb.Append("Wisdom " + Wisdom + "\n");
            sbb.Append("Charisma " + Charisma + "\n");
            return sbb.ToString();
        }

        public int Strength
        {
            get { return CharacterAttributes.Modifiers[0] (proficiency[0] ? ProficiencyBonus : 0); }
        }
        public int Dexterity
        {
            get { return CharacterAttributes.Modifiers[1] + (proficiency[1] ? ProficiencyBonus : 0); }
        }
        public int Constitution
        {
            get { return CharacterAttributes.Modifiers[2] + (proficiency[2] ? ProficiencyBonus : 0); }
        }
        public int Intelligence
        {
            get { return CharacterAttributes.Modifiers[3] + (proficiency[3] ? ProficiencyBonus : 0); }
        }
        public int Wisdom
        {
            get { return CharacterAttributes.Modifiers[4] + (proficiency[4] ? ProficiencyBonus : 0); }
        }
        public int Charisma
        {
            get { return CharacterAttributes.Modifiers[5] + (proficiency[5] ? ProficiencyBonus : 0); }
        }
    }
}
