﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class Character
    {
        #region FIELD 
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
            get { return race; }
            set { Race = value; }
        }
            public string background
        {
            get {return Background; }
            set { Background = value; }
        }
            public int level
        {
            get { return Level; }
            set { Level = value; }
        }
            public string CcharacterClass
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
            get {return Alignment; }
            set { Alignment = value; }
        }
            public int deathSaves
{
            get {return DeathSaves; }
            set { DeathSaves = value; }
        }
            public bool inspiration
{
            get {return Inspiration; }
            set { Inspiration = value; }
        }
            public int health
{
            get {return Health; }
            set { Health = value; }
        }
            public int tempHealth
{
            get {return TempHealth; }
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
            get {return ProficiencyBonus; }
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
                ProficiencyBonus = 0;
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
