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
            invtype = Utillity.ReadTextInput("what would you like to add? 1 for Item, 2 for Armor, 3 for Weapon"); // tager iøjeblikket kun mod: "Item" "Armor" og "Weapon" som input
            switch (invtype) // tjekker hvilken type item der er tilføjet til inventory
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
            checkWeight(); // slettes senere


        }
        public void CheckInventory() // Bruges bare til at checke om den har loaded filer
        {
            foreach (var Item in InventoryList)
            {
                Console.WriteLine("test: {0}, {1}, {2}, {3}, {4}", Item.ItemName, Item.ItemType, Item.AmountHeld, Item.WeightPerItem, Item.Description);
            }
        }
        public void RemoveItem() // laves Private Senere // Fjerner et item fra listen, skal senere laves til at kun fjerne og reducere objekters Amoundheld
        {
            Item NewItem = new Item();
            NewItem.ItemName = Utillity.ReadTextInput("Please Enter item to be modified"); // kører en method der spørger brugeren om et input og lagrer det derefter i fieldet
            for (int i = 0; i < InventoryList.Count; i++)
            {
                Item OldItem = InventoryList[i];
                if (OldItem.ItemName.Equals(NewItem.ItemName))  // tjekker om den nye fil allerede eksistere i listen
                {
                    bool Remove = Utillity.ReadBoolInput("Do you want to remove(true) it or modify it(false)?");
                    if(Remove == true)
                    {
                        Console.WriteLine("The item {0} has been removed", OldItem.ItemName);
                        InventoryList.Remove(OldItem); // fjerner filen fra listen.
                       
                    }
                    else
                    {
                        OldItem.AmountHeld -= Utillity.ReadNumericInput("Item already exists, how many would you like to remove?");
                        Console.WriteLine("You now have {0} of the item {1} left", OldItem.AmountHeld, OldItem.ItemName);
                        if (OldItem.AmountHeld == 0)
                        {

                            InventoryList.Remove(OldItem); // fjerner filen fra listen.
                            Console.WriteLine("The item {0} has been removed", OldItem.ItemName);
                        }
                    }    
                
                }
                else if(i == InventoryList.Count-1)// slettes senere, bruges til test
                { 
                     Console.WriteLine("The item Does not exist");
                }
            }
        }

        void AddItemToList() // tilføjer et "Item" til inventory
        {
            Item NewItem = new Item();
           
            NewItem.ItemName = Utillity.ReadTextInput("Please Enter item name");
            
            bool ItemExist = ExistCheck(NewItem); // hvis denne er true, vil mængden af et specifikt item blive større.
            
            if (ItemExist != true) // Hvis itemmet ikke allerede eksistere køres dette og der laves et nyt item.
            {
                NewItem.ItemType = Utillity.ReadTextInput("Please Enter item type");
                NewItem.AmountHeld = Utillity.ReadNumericInput("Please enter amount");
                NewItem.WeightPerItem = Utillity.ReadNumericInput("Please enter weight per item");
                NewItem.Description = Utillity.ReadTextInput("Please enter the description of the Item");
                
                InventoryList.Add(NewItem);
            }            
        }
        void AddArmorToList() // virker ligesom Add Item to list
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
        void AddWeaponToList() // fungere ligesom add item to list
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
        string EncumberCheck() // tjekker om man har for meget vægt
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

        void checkWeight() // temporary checker // slettes senere
        {
            Console.WriteLine(TotalWeight);
            Console.WriteLine(Encumbered);
        }
        int ItemWeightCalc() // udregner hvor meget ens items vejer samlet
        {
           TotalWeight = 0;
           for (int i = 0; i < InventoryList.Count; i++)
            {
                Item Item = InventoryList[i];
                TotalWeight += Item.WeightPerItem * Item.AmountHeld;
            }
            return TotalWeight;
        }
        bool ExistCheck(Item NewItem) // tjekker om itemmet existere, når et nyt skal tilføjes.
        {
            bool ItemExist = false;
            for (int i = 0; i < InventoryList.Count; i++)
            {
                Item OldItems = InventoryList[i];
                if (OldItems.ItemName.Equals(NewItem.ItemName)) // hvis det eksistere, ændrer den bare hvor mange der er, ved at lægge ekstra oveni
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
