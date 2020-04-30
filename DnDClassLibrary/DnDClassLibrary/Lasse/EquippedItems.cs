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


            public int ACCalc()
            { 
            if (shieldEquipped == true)
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
            Console.WriteLine(shieldEquipped);
            Console.WriteLine(AC);
        }

    }
}
