using System;

namespace CharacterDND
{
    
    
    class Character
    {
        private string CharacterName;
        private string PlayerName;
        public string Race;
        public string Background;
        public int Level;
        public string CharacterClass;
        private string Ideals;
        private string Flaws;
        private string Bonds;
        private string Traits;
        private string Alignment;
        private int DeathSaves;
        private bool Inspiration;
        private int Health;
        private int TempHealth;
        private int Speed;
        private int Initiative;
        public int ProficiencyBonus;
        private int MaxHealth;


        private void ProficiencyCalc()
        { 
        if(Level < 1)
            {
                ProficiencyBonus = 0;
            }
        else if(Level < 5)
            {
                ProficiencyBonus = 2;

            }
        else if(Level < 9)
            {
                ProficiencyBonus = 3;
            }
        else if(Level < 13)
            {
                ProficiencyBonus = 4;
            }
        else if (Level < 17)
            {
                ProficiencyBonus = 5;
            }
        else
            {
                ProficiencyBonus = 6;
            }

        }

        private void InitiativeCalc()
        {
            Initiative = DexterityModifier;

        }


        private void EditSheet()
        {


        }









    }
}
