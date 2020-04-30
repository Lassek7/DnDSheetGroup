using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DnDClassLibrary
{
    public class DnDDatabaseManagement
    {
        public DnDDatabaseManagement()
        {
        }
        public void CharatorCreation()
        {
            bool RunApp = false;
            do {
                string answer;
                string CharatorName;
                Console.WriteLine("Welcome To Dnd Charator Manager");
                Console.WriteLine("Type your charactor name:");
                CharatorName = Console.ReadLine();
                Console.WriteLine("Your charator name is:"+ CharatorName);
                Console.WriteLine("Confirm charator name by typing Yes or No");
                answer = Console.ReadLine();
                if (answer.ToUpper() == "YES")
                {
                    Console.WriteLine("Do you want to add start equipment? Type Yes or No");
                    answer = Console.ReadLine();
                    if (answer.ToUpper() == "YES")
                    {
                        DatabaseList();
                        Console.WriteLine("Added Items to Backup File");
                        RunApp = true;
                    }
                    else if (answer.ToUpper() == "NO")
                    {
                        Console.WriteLine("Starting Campaign");
                        RunApp = true;
                    }
                } 

        } while (RunApp != true);

            /* To doooooooooooooooo 
             1. tilfører sådan at ens Charator navn er navnet på json filen samt i en mappe for sig selv 
             1.1 lavet sådan at de enkelt værdiere i json filen bliver lagret i de forskellige værdier i koden(Evt i DndClassen)
             2. Tilfører verison kontrol som tjekker efter backup filer
             3. tilfører attribute i json filen 
             
             
             */
        }
        #region INVENTORYLIST
        public void DatabaseList() // 
        {
            Inventory inventory = new Inventory(); // andet navn


            inventory.RunInventory(); // kører Inventory manager

            
            string FilePath = "";
            File.WriteAllText(@"C:\Users\rallo\Source\Repos\LAK258\DnDSheetGroup\DnDClassLibrary\DnDClassLibrary\videogames.json", JsonConvert.SerializeObject(inventory.inventoryList));// Opretter JSON filen 
            using (StreamWriter file = File.CreateText(@"C:\Users\rallo\Source\Repos\LAK258\DnDSheetGroup\DnDClassLibrary\DnDClassLibrary\videogames.json")) // åbner filen så man kan tilfører elementer
            {
                for (int i = 0; i < inventory.inventoryList.Count; i++)
                {

                    JsonSerializer jsonSerializer = new JsonSerializer(); // Laver en ny instance
                    jsonSerializer.Serialize(file, inventory.inventoryList[i]);// tilførere de angivende Items/Equipment til Json filen på en linje
                }
            }

        }
        #endregion

    }
}





