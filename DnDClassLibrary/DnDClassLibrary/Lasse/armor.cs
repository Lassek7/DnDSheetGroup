using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class Armor : Item
    {

        private bool itemEquipped;
        private int baseAC;
        private int aCFromArmor;

        public bool ItemEquipped
        {
            get { return itemEquipped; }
            set { itemEquipped = value; }

        }
        public int BaseAC
        {
            get { return baseAC; }
            set { baseAC = value; }

        }
        public int ACFromArmor
        {
            get { return aCFromArmor; }
            set { aCFromArmor = value; }

        }

    }
      
}

