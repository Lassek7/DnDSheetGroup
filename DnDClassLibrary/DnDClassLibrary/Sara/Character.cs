using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Character
    {
        #region FIELD 
        string CharacterName;
        string PlayerName;
        string Race;
        string Background;
        int Level;
        string CharacterClass;
        string Ideals;
        string Flaws;
        string Bonds;
        string Traits;
        string Alignment;
        int DeathSaves;
        bool Inspiration;
        int Health;
        int TempHealth;
        int Speed;
        int Initiative;
        int ProficiencyBonus;
        int MaxHealth;

        public Character()
        {
        }

        public string characterName
        {
            get { return CharacterName; }

            set { CharacterName = value; }

        }
        public string playerName
        {
            get { return PlayerName; }
            set { PlayerName = value; }
        }
        public string race
        {
            get { return Race; }
            set { Race = value; }
        }
        public string background
        {
            get { return Background; }
            set { Background = value; }
        }
        public int level
        {
            get { return Level; }
            set { Level = value; }
        }
        public string characterClass
        {
            get { return CharacterClass; }
            set { CharacterClass = value; }
        }
        public string ideals
        {
            get { return Ideals; }
            set { Ideals = value; }
        }
        public string flaws
        {
            get { return Flaws; }
            set { Flaws = value; }
        }
        public string bonds
        {
            get { return Bonds; }
            set { Bonds = value; }
        }
        public string traits
        {
            get { return Traits; }
            set { Traits = value; }
        }
        public string alignment
        {
            get { return Alignment; }
            set { Alignment = value; }
        }
        public int deathSaves
        {
            get { return DeathSaves; }
            set { DeathSaves = value; }
        }
        public bool inspiration
        {
            get { return Inspiration; }
            set { Inspiration = value; }
        }
        public int health
        {
            get { return Health; }
            set { Health = value; }
        }
        public int tempHealth
        {
            get { return TempHealth; }
            set { TempHealth = value; }
        }
        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }
        public int initiative
        {
            get { return Initiative; }
            set { Initiative = value; }
        }
        public int proficiencyBonus
        {
            get { return ProficiencyBonus; }
            set { ProficiencyBonus = value; }
        }
        public int maxHealth
        {
            get { return MaxHealth; }
            set { MaxHealth = value; }
        }

        #endregion
        private void ProficiencyCalc()
        {
            if (Level < 1)
            {
                ProficiencyBonus = 1;
            }
            else if (Level < 5)
            {
                ProficiencyBonus = 2;

            }
            else if (Level < 9)
            {
                ProficiencyBonus = 3;
            }
            else if (Level < 13)
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
            //    Initiative = DexterityModifier;

        }


        private void EditSheet()
        {


        }

    }
}

