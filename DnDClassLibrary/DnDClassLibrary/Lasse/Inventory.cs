using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Inventory
    {
        int TempStrength = 5; // temporary
        int TotalWeight;
        string Encumbered = "You are not Encumbered";

        public static List<Item> InventoryList = new List<Item>(); // temp public/static
        UtilityMethods Utillity = new UtilityMethods();

        public void RunInventory()
        {
            AddToInv();
        }

        void AddToInv()
        {
            string invtype;
            invtype = Utillity.ReadTextInput("what would you like to add? 1 for Item, 2 for Armor, 3 for Weapon");
            switch (invtype)
            {
                case "Item":
                    AddItemToList();
                    break;
                case "Armor":
                    AddArmorToList();
                    break;
                case "Weapon":
                    AddWeaponToList();
                    break;
                default:
                    break;
            }
            ItemWeightCalc();
            EncumberCheck();
            checkWeight();


        }
        public void CheckInventory() // laves Private Senere
        {
            foreach (var Item in InventoryList)
            {
                Console.WriteLine("test: {0}, {1}, {2}, {3}, {4}", Item.ItemName, Item.ItemType, Item.AmountHeld, Item.WeightPerItem, Item.Description);
            }
        }
        public void RemoveItem() // laves Private Senere
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

        void AddItemToList()
        {
            Item NewItem = new Item();
           
            NewItem.ItemName = Utillity.ReadTextInput("Please Enter item name");
            
            bool ItemExist = ExistCheck(NewItem);
            
            if (ItemExist != true)
            {
                NewItem.ItemType = Utillity.ReadTextInput("Please Enter item type");
                NewItem.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                NewItem.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                NewItem.Description = Utillity.ReadTextInput("Please enter the description of the Item");
                
                InventoryList.Add(NewItem);
            }            
        }
        void AddArmorToList()
        {
            Armor NewItem = new Armor();

            NewItem.ItemName = Utillity.ReadTextInput("Please Enter item name");
            bool ItemExist = ExistCheck(NewItem);

            if (ItemExist != true)
            {
                NewItem.ItemType = Utillity.ReadTextInput("Please Enter item type");
                NewItem.ACFromArmor = Utillity.ReadNumericInput("what is the AC?");
                NewItem.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                NewItem.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                NewItem.Description = Utillity.ReadTextInput("Please enter the description of the Item");
                NewItem.ItemEquipped = Utillity.ReadBoolInput("do you want to equip it?");

                InventoryList.Add(NewItem);
            }

        }
        void AddWeaponToList()
        {
            Weapon NewItem = new Weapon();

            NewItem.ItemName = Utillity.ReadTextInput("Please Enter item name");
            bool ItemExist = ExistCheck(NewItem);
            
            if (ItemExist != true)
            {
                NewItem.ItemType = Utillity.ReadTextInput("Please Enter item type");
                NewItem.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                NewItem.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                NewItem.Description = Utillity.ReadTextInput("Please enter the description of the Item");
                NewItem.AttributeAssociation = Utillity.ReadTextInput("what attribute is it associated with?");
                NewItem.AttackModifier = 2; // palceholder
                NewItem.Range = Utillity.ReadTextInput("What is the range?");
                NewItem.Damage = Utillity.ReadTextInput("How much damage does it deal?");
                NewItem.DamageType = Utillity.ReadTextInput("What damage type does it have?");
                NewItem.AttackBonus = 5; // placeholder
                NewItem.ItemEquipped = Utillity.ReadBoolInput("do you want to equip it?");
                NewItem.Proficiency = Utillity.ReadBoolInput("Do you have Proficiency in this weapon?");
                NewItem.ProficiencyModifier = 3; // Placeholder

                InventoryList.Add(NewItem);
            }
        }
        string EncumberCheck()
        {
            
            if (TotalWeight >= TempStrength * 5)
            {
                Encumbered = "you are heavily Encumbered";
            }
            else if (TotalWeight >= TempStrength * 2)
            {
                Encumbered = "you are slightly encumbered";
            }
            else
            {
                Encumbered = "you are not encumbered";
            }

            return Encumbered;
        }

        void checkWeight() // temporary checker
        {
            Console.WriteLine(TotalWeight);
            Console.WriteLine(Encumbered);
        }
        int ItemWeightCalc()
        {
           TotalWeight = 0;
           for (int i = 0; i < InventoryList.Count; i++)
            {
                Item Item = InventoryList[i];
                TotalWeight += Item.WeightPerItem * Item.AmountHeld;
            }
            return TotalWeight;
        }
        bool ExistCheck(Item NewItem)
        {
            bool ItemExist = false;
            for (int i = 0; i < InventoryList.Count; i++)
            {
                Item OldItems = InventoryList[i];
                if (OldItems.ItemName.Equals(NewItem.ItemName))
                {
                    ItemExist = true;
                    OldItems.AmountHeld += Utillity.ReadNumericInput("Item already exists, how many would you like to add?");
                    break;
                }
                else
                {
                    ItemExist = false;
                }
            }
            return ItemExist;
        }
    }
}
