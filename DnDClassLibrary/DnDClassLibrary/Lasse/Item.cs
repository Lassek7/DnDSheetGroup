using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Item // find en måde at gøre den private
    {
        private string itemName;
        private string itemType;
        private int amountHeld;
        private int weightPerItem;
        private string description;

        public Item()
        {
        }

        public Item(string itemName)
        {
            this.itemName = itemName;
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }
        public int AmountHeld
        {
            get { return amountHeld; }
            set { amountHeld = value; }
        }
        public int WeightPerItem
        {
            get { return weightPerItem; }
            set { weightPerItem = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
