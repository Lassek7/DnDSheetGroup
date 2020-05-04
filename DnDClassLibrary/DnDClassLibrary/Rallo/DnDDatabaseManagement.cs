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
        
        private string PlayerName { get; set; }
        public DnDDatabaseManagement()
        {
        }
        public void CharatorCreation()
        {
            bool RunApp = false;
            do {
                string answer;
                
//                Console.WriteLine("Welcome To Dnd Charator Manager");
//                Console.WriteLine("Type your Player name:");
//                PlayerName = Console.ReadLine();
//                Console.WriteLine("Your charator name is:"+ PlayerName);
//                Console.WriteLine("Confirm charator name by typing Yes or No");
//                answer = Console.ReadLine();
//                if (answer.ToUpper() == "YES")
//                {
//                    Console.WriteLine("Do you want to add start equipment? Type Yes or No");
//                    answer = Console.ReadLine();
//                    if (answer.ToUpper() == "YES")
//                    {
//                        DatabaseList();
//                        Console.WriteLine("Added Items to Backup File");
//                        RunApp = true;
//                    }
//                    else if (answer.ToUpper() == "NO")
//                    {
//                        Console.WriteLine("Starting Campaign");
//                        RunApp = true;
//                    }
//                } 

//        } while (RunApp != true);

//            /* To doooooooooooooooo 
//             1. tilfører sådan at ens Charator navn er navnet på json filen samt i en mappe for sig selv 
//             1.1 lavet sådan at de enkelt værdiere i json filen bliver lagret i de forskellige værdier i koden(Evt i DndClassen)
//             2. Tilfører verison kontrol som tjekker efter backup filer
//             3. tilfører attribute i json filen 
//             4. laver en validering som overwritter den gamle fil
             
             
             */
        }
        #region INVENTORYLIST
        public void DatabaseList() // 
        {
            Inventory inventory = new Inventory(); // andet navn
            inventory.RunInventory(); // kører Inventory manager
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName; // sætter path værdien til at være ens Windows brugere mappe i file explorer ex. (C:\Users\rallo\Backup Character)
            // I if statment tjekker den version af Windows OS om det er vista, windows 7 eller windows 10
            // Hvis Windows OS version er større eller ligmed 6 henter den rigtig placering af mappen og laver den til en string
            if (Environment.OSVersion.Version.Major >= 6)
                { 
                path = Directory.GetParent(path).ToString(); 
                }

//            string foldername = path;
//            string pathString = System.IO.Path.Combine(foldername, "Backup Character");

            string fileName = PlayerName +".json"; // henter Navnet på spilleren og sætter navnet på backup filen til at være (PlayerName.json)
            
            System.IO.Directory.CreateDirectory(pathString); // laver mappen Backup Character 
            string createfile = System.IO.Path.Combine(pathString, fileName); // kombinere mappens placering og navnet på backup filen til en string ex.(C:\Users\rallo\Backup Character\PlayerName.json)
            if (!System.IO.File.Exists(createfile))
                {
                

                    //File.WriteAllText(@"\\Backup Character\\", JsonConvert.SerializeObject(inventory.inventoryList));// Opretter JSON filen 
                    using (StreamWriter file = File.CreateText(createfile)) // åbner filen så man kan tilfører elementer
                    {
                        for (int i = 0; i < inventory.inventoryList.Count; i++)
                        {

                            JsonSerializer jsonSerializer = new JsonSerializer(); // Laver en ny instance
                            jsonSerializer(file, inventory.inventoryList[i]);// tilførere de angivende Items/Equipment til Json filen på en linje
                        }
                    }
                
                }else
                {
                //for(int i = 0; i < 2; i++)
                //{
                //    string jsonfilecontent = File.ReadAllText(createfile);
                //    jsonfilecontent
                //    Console.WriteLine();
                //}

                //Console.WriteLine("File \"{0}\" already existis", fileName);

                //using (StreamReader file = File.OpenText(createfile))
                //{
                //    string json = file.ReadToEnd();
                //    //JsonSerializer jsonSerializer = new JsonSerializer();
                //    json = JsonConvert.DeserializeObject<Inventory>(json);
                //    //Item inventories = (Item)jsonSerializer.Deserialize(file, typeof(Item));

                //    Console.WriteLine();
                //}

                ////Inventory l1 = JsonConvert.DeserializeObject<Inventory>(createfile);
                //for (int i = 0; i < i; i++)
                //{
                //    Console.WriteLine();
                //}
            }
            

        }
        #endregion

    }
}





