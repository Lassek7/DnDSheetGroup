using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Inventory
    {
        public Item myItem = new Item();
        public Armor myArmor = new Armor();
        public Weapon myWeapon = new Weapon();
        List<Item> myInventoryList = new List<Item>();
        public DnDClassLibrary.Item AddItem(string ItemName, int AmountHeld, int WeightPerItem, string ItemType, string Description)
        {
            Item NewItem = new Item();

            NewItem.ItemID = 1;
            NewItem.ItemName = ItemName;
            NewItem.AmountHeld = AmountHeld;
            NewItem.WeightPerItem = WeightPerItem;
            NewItem.ItemType = ItemType;
            NewItem.Description = Description;

            return NewItem;
        }
        public DnDClassLibrary.Item AddArmor(string ItemName, int AmountHeld, int WeightPerItem, string ItemType, int ACFromArmor, string Description, bool ItemEquipped)
        {
            Armor NewArmor = new Armor();
            NewArmor.ItemID = 2;
            NewArmor.ItemName = ItemName;
            NewArmor.AmountHeld = AmountHeld;
            NewArmor.WeightPerItem = WeightPerItem;
            NewArmor.ItemType = ItemType;
            NewArmor.ACFromArmor = ACFromArmor;
            NewArmor.Description = Description;
            NewArmor.ItemEquipped = ItemEquipped;
            return NewArmor;
        }
        public DnDClassLibrary.Weapon AddWeapon(string ItemName, int AmountHeld, int WeightPerItem, string DamageType, string Damage, string Range, string ItemType, string Description, bool ItemEquipped, string AttributeAssociation)
        {
            Weapon NewWeapon = new Weapon();
            NewWeapon.ItemID = 3;
            NewWeapon.ItemName = ItemName;
            NewWeapon.AmountHeld = AmountHeld;
            NewWeapon.WeightPerItem = WeightPerItem;
            NewWeapon.DamageType = DamageType;
            NewWeapon.Damage = Damage;
            NewWeapon.Range = Range;
            NewWeapon.ItemType = ItemType;
            NewWeapon.Description = Description;
            NewWeapon.ItemEquipped = ItemEquipped;
            NewWeapon.AttributeAssociation = AttributeAssociation;

            return NewWeapon;
        }
    }
}
