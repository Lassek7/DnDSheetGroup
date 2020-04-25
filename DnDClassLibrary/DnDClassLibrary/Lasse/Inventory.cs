using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class Inventory
    {
        //int Strength;
        //string ItemName;
        //int CarryCapacity;
        //string ItemDescription;
        //int ItemAmount;
        //bool Encumbered;



        List<Item> InventoryList = new List<Item>();
        UtilityMethods b2 = new UtilityMethods();

        public void AddToInv()
        {
            Item B1 = new Item();

            B1.ItemName = b2.ReadTextInput("Please Enter item name");
            B1.ItemType = b2.ReadTextInput("Please Enter item type");
            B1.AmountHeld = b2.ReadNumericInput("Please enter amount");
            B1.WeightPerItem = b2.ReadNumericInput("Please enter weight per item");
            B1.Description = b2.ReadTextInput("Please enter the description of the Item");

            InventoryList.Add(B1);

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
            B1.ItemName = b2.ReadTextInput("Please Enter item to be modified");
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
