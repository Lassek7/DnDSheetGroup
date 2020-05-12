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

        public EquippedItems()
        {

        }

        public int AtkBonusCalc(string modifier, bool Proficency, int ProficiencyBonus, int Strength, int Dexterity, int Constitution, int Intelligence, int Wisdom, int Charisma)
        {
            int ATKBonus;
            switch (modifier)
            {
                case "Strength":
                    ATKBonus = Strength;
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
                    ATKBonus = 0;
                    break;
            }
            int BonusValue;
            if (Proficency == true)
            {
                BonusValue = ProficiencyBonus;
            }
            else
            {
                BonusValue = 0;
            }
            return ATKBonus + BonusValue;
        }

        public int ACBonusCalc(int ArmorValue, bool Shield, int DexScore)
        {
            int Armor;
            if(ArmorValue == 0)
            {
                Armor = 10;
            }
            else
            {
                Armor = ArmorValue;
            }
            int ShieldBonus;
            if (Shield == true)
            {
                ShieldBonus = 2;
            }
            else
            {
                ShieldBonus = 0;
            }
            return Armor + ShieldBonus + DexScore;
        }
    }
}
