using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Item // find en måde at gøre den private
    {
        int itemID;
        string itemName;
        string itemType;
        int amountHeld;
        int weightPerItem;
        string description;
        int copper;
        int silver;
        int electrum;
        int gold;
        int platinum;

        public Item()
        {
        }

        public Item(string itemName) // validering tilføjes senere+
        {
            this.itemName = itemName;
        }
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
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
        public int Copper
        {
            get { return copper; }
            set { copper = value; }
        }
        public int Silver
        {
            get { return silver; }
            set { silver = value; }
        }
        public int Electrum
        {
            get { return electrum; }
            set { electrum = value; }
        }
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        public int Platinum
        {
            get { return platinum; }
            set { platinum = value; }

        }
    }
}
