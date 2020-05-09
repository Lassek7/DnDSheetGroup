using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class EquippedItems : Inventory
    {

            int WeaponSlotOne;
            int WeaponSlotTwo;
            int WeaponSlotThree;
            int ArmorSlotChest;
           public bool shieldEquipped;
            int AC;
            int ATKBonus;

        public EquippedItems(bool ShieldEquipped)
        {
            this.shieldEquipped = ShieldEquipped;
        }


        public int ShieldBonus(int CurrentAC)
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

        //public int AtkBonusCalc()
        //    { return ATKBonus; }
        
        public void test2()
        {
            Console.WriteLine(shieldEquipped);
            Console.WriteLine(AC);
        }

    }
}
