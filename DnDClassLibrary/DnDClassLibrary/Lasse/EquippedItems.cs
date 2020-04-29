using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class EquippedItems : Inventory
    {

            int WeaponSlotOne;
            public int WeaponSlotTwo;
            int WeaponSlotThree;
            int ArmorSlotChest;
            public bool ShieldEquipped;
            int AC;
            int ATKBonus;

        public EquippedItems(bool ShieldEquipped)
            {
            this.ShieldEquipped = ShieldEquipped;
            }


            public int ACCalc()
            { 
            if (ShieldEquipped == true)
            {
                AC = 2;
            }
            else
            {
                AC = 0;
            }

            return AC; 
            }

           public  int AtkBonusCalc()
            { return ATKBonus; }
        public void test2()
        {
            Console.WriteLine(ShieldEquipped);
            Console.WriteLine(AC);
        }

    }
}
