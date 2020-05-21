using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Armor : Item
    {

        private bool itemEquipped;
        private int aCFromArmor;

        public bool ItemEquipped
        {
            get { return itemEquipped; }
            set { itemEquipped = value; }

        }
        public int ACFromArmor
        {
            get { return aCFromArmor; }
            set { aCFromArmor = value; }

        }

    }
      
}

