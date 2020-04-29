using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class SavingThrow : Skill
    {
        private bool[] proficiency = new bool[6];

        public SavingThrow(int StrengthModifier, int DexterityModifier, int ConstitutionModifier, int IntelligenceModifier,
            int WisdomModifier, int CharismaModifier, int ProficiencyBonus, int[] proficiencyEnabled, bool JackOfAllTrades) 
        : base(StrengthModifier, DexterityModifier, ConstitutionModifier, IntelligenceModifier,
            WisdomModifier, CharismaModifier, ProficiencyBonus, proficiencyEnabled, JackOfAllTrades)
        {

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
            get { return StrengthModifier + (proficiency[0] ? ProficiencyBonus : 0); }
        }
        public int Dexterity
        {
            get { return DexterityModifier + (proficiency[1] ? ProficiencyBonus : 0); }
        }
        public int Constitution
        {
            get { return ConstitutionModifier + (proficiency[2] ? ProficiencyBonus : 0); }
        }
        public int Intelligence
        {
            get { return IntelligenceModifier + (proficiency[3] ? ProficiencyBonus : 0); }
        }
        public int Wisdom
        {
            get { return WisdomModifier + (proficiency[4] ? ProficiencyBonus : 0); }
        }
        public int Charisma
        {
            get { return CharismaModifier + (proficiency[5] ? ProficiencyBonus : 0); }
        }
    }
}
