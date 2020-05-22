using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DnDClassLibrary
{
    public class EquippedItems : Inventory
    {

        public string WeaponOneName;
        public int WeaponOneATKBonus;
        public string WeaponOneDamage;
        public string WeaponOneDamageType;
        public string WeaponOneAttributeAssociation;

        public string WeaponTwoName;
        public int WeaponTwoATKBonus;
        public string WeaponTwoDamage;
        public string WeaponTwoDamageType;
        public string WeaponTwoAttributeAssociation;

        public string WeaponThreeName;
        public int WeaponThreeATKBonus;
        public string WeaponThreeDamage;
        public string WeaponThreeDamageType;
        public string WeaponThreeAttributeAssociation;

        public string ArmorSlotChest;
        public bool shieldEquipped;
        public int ACFromArmor;

        public string AttunementSlotOneName;
        public string AttunementSlotTwoName;        
        public string AttunementSlotThreeName;

        public string MagicItemOneName;
        public string MagicItemTwoName;
        public string MagicItemThreeName;

        #region METHODS       
        public int AtkBonusCalc(string modifier, bool Proficency, int ProficiencyBonus, int Strength, int Dexterity, int Constitution, int Intelligence, int Wisdom, int Charisma) // Udregner hvad attakbonusen er for et equipped våben.
        {
            int ATKBonus; 
            switch (modifier) // modifier er baseret på hvad brugeren har valgt som property til deres våben. 
            {
                case "Strength":
                    ATKBonus = Strength; // strength, dexterity, constitution osv. er baseret på characterens attribute modifier
                    break;
                case "Dexterity":
                    ATKBonus = Dexterity;
                    break;
                case "Constitution":
                    ATKBonus = Constitution;
                    break;
                case "Intelligence":
                    ATKBonus = Intelligence;
                    break;
                case "Wisdom":
                    ATKBonus = Wisdom;
                    break;
                case "Charisma":
                    ATKBonus = Charisma;
                    break;
                default:
                    ATKBonus = 0; // hvis våbnet ikke har en property tilknyttet, bliver der ikke føjet en ny værdi til ATKBONUS
                    break;
            }
            int BonusValue;
            if (Proficency == true)
            {
                BonusValue = ProficiencyBonus; // bonus value bliver lavet til en proficiency modifier hvis brugeren har proficency i det.
            }
            else
            {
                BonusValue = 0; // hvis brugeren ikke har proficiency bliver bonus valuen sat til 0
            }
            return ATKBonus + BonusValue; // returnere atkbonus sammen med bonusvalue
        }

        public int ACBonusCalc(int ArmorValue, bool Shield, int DexScore) // udregner brugerens Armor Class
        {
            int Armor;
            if(ArmorValue == 0) // hvis brugerens armor value er 0, bliver ARmor sat til 10 ellers bliver armor sat til ArmorValue
            {
                Armor = 10;
            }
            else
            {
                Armor = ArmorValue;
            }
            int ShieldBonus;
            if (Shield == true) // Hvis et skjold er equippet, bliver shieldbonus sat til 2 ellers 0
            {
                ShieldBonus = 2;
            }
            else
            {
                ShieldBonus = 0;
            }
            return Armor + ShieldBonus + DexScore; // returnerer ens Armor, shieldbonus og dexscore samlet for at få ens totale Armor Class
        }
        #endregion
    }
}
