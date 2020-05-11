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
        int AC;

        //public EquippedItems(bool ShieldEquipped)
        //{
        //    this.shieldEquipped = ShieldEquipped;
        //}
        public EquippedItems()
        {

        }


        public int ShieldBonus(int CurrentAC, bool ShieldEquipped)
        {
            if (shieldEquipped == true)
            {
                int NewAC = CurrentAC + 2;
                return NewAC;
            }
            else
            {
                return CurrentAC += 0;
            }
        }

        public int AtkBonusCalc()
        {

            int ATKBonus = 0;

            return ATKBonus;
        }

        public int ACBonusCalc(int Armor, bool Shield)
        {
            int ACBonus = 0;

            return ACBonus;
        }


    }
}
