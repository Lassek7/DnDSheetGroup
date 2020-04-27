using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
        public class Inventory
    {
        //int Strength;
        //string ItemName;
        //int CarryCapacity;
        //string ItemDescription;
        //int ItemAmount;
        //bool Encumbered;



        List<Item> InventoryList = new List<Item>();
        UtilityMethods Utillity = new UtilityMethods();

        public void AddToInv()
        {
            string invtype;
            invtype = Utillity.ReadTextInput("what would you like to add? 1 for Item, 2 for Armor, 3 for Weapon");
            switch (invtype)
            {
                case "Item":
                    Item item = new Item();

                    item.ItemName = Utillity.ReadTextInput("Please Enter item name");
                    item.ItemType = Utillity.ReadTextInput("Please Enter item type");
                    item.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                    item.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                    item.Description = Utillity.ReadTextInput("Please enter the description of the Item");

                    InventoryList.Add(item);
                    break;
                case "Armor":
                    Armor armor = new Armor();

                    armor.ItemName = Utillity.ReadTextInput("Please Enter item name");
                    armor.ItemType = Utillity.ReadTextInput("Please Enter item type");
                    armor.ACFromArmor = Utillity.ReadNumericInput("what is the AC?");
                    armor.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                    armor.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                    armor.Description = Utillity.ReadTextInput("Please enter the description of the Item");
                    armor.ItemEquipped = Utillity.ReadBoolInput("do you want to equip it?");

                    InventoryList.Add(armor);
                  
                    break;
                case "Weapon":
                    Weapon weapon = new Weapon();

                    weapon.ItemName = Utillity.ReadTextInput("Please Enter item name");
                    weapon.ItemType = Utillity.ReadTextInput("Please Enter item type");
                    weapon.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                    weapon.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                    weapon.Description = Utillity.ReadTextInput("Please enter the description of the Item");
                    weapon.AttributeAssociation = Utillity.ReadTextInput("what attribute is it associated with?");
                    weapon.AttackModifier = 2; // palceholder
                    weapon.Range = Utillity.ReadTextInput("What is the range?");
                    weapon.Damage = Utillity.ReadTextInput("How much damage does it deal?");
                    weapon.DamageType = Utillity.ReadTextInput("What damage type does it have?");
                    weapon.AttackBonus = 5; // placeholder
                    weapon.ItemEquipped = Utillity.ReadBoolInput("do you want to equip it?");
                    weapon.Proficiency = Utillity.ReadBoolInput("Do you have Proficiency in this weapon?");
                    weapon.ProficiencyModifier = 3; // Placeholder
                    
                    InventoryList.Add(weapon);
                    break;
                default:
                    break;
            }
            

        }
        public void CheckInventory()
        {
            foreach (var Item in InventoryList)
            {
                Console.WriteLine("test: {0}, {1}, {2}, {3}, {4}", Item.ItemName, Item.ItemType, Item.AmountHeld, Item.WeightPerItem, Item.Description);
            }
        }
        public void RemoveItem()
        {
            Item B1 = new Item();
            B1.ItemName = Utillity.ReadTextInput("Please Enter item to be modified");
            for (int i = 0; i < InventoryList.Count; i++)
            {
                Item Item = InventoryList[i];
                if (Item.ItemName.Equals(B1.ItemName))
                {
                    InventoryList.Remove(Item);
                    Console.WriteLine("true");
                    break;
                }
                else
                {
                    Console.WriteLine("False");
                    Console.WriteLine("{0}", Item.ItemName);
                    break;
                }
            }
        }

      
        //int CarryCapacityCalc()
        //{
        //    CarryCapacity = Strength * 15;

        //    return CarryCapacity;
        //}
        //int ItemWeightCalc()
        //{

        //}
    }
}
