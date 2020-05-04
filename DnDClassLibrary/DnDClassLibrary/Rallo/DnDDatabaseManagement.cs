using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DnDClassLibrary
{
    public class DnDDatabaseManagement
    {
        private object itemName;

        private string PlayerName { get; set; }
        public List<string> Inventories { get; private set; }
        

        public DnDDatabaseManagement()
        {
        }
        
public void CharatorCreation()
        {
            bool RunApp = false;
            do {
                string answer;
                
                Console.WriteLine("Welcome To Dnd Charator Manager");
                Console.WriteLine("Type your Player name:");
                PlayerName = Console.ReadLine();
                Console.WriteLine("Your charator name is:"+ PlayerName);
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
             4. laver en validering som overwritter den gamle fil
             
             
             */
        }
        #region INVENTORYLIST
        public void DatabaseList() // 
        {
        Inventory inventory = new Inventory(); // andet navn
            
        inventory.RunInventory(); // kører Inventory manager
            
            string ItemName;
            string ItemType;
            string AmountHeld;
            string WeightPerItem;
            string Description;
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName; // sætter path værdien til at være ens Windows brugere mappe i file explorer ex. (C:\Users\rallo\Backup Character)
            // I if statment tjekker den version af Windows OS om det er vista, windows 7 eller windows 10
            // Hvis Windows OS version er større eller ligmed 6 henter den rigtig placering af mappen og laver den til en string
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            string foldername = path;
            string pathString = System.IO.Path.Combine(foldername, "Backup Character");

            string fileName = PlayerName + ".json"; // henter Navnet på spilleren og sætter navnet på backup filen til at være (PlayerName.json)

            System.IO.Directory.CreateDirectory(pathString); // laver mappen Backup Character 
            string createfile = System.IO.Path.Combine(pathString, fileName); // kombinere mappens placering og navnet på backup filen til en string ex.(C:\Users\rallo\Backup Character\PlayerName.json)
                                                                              // Linje 98 til 107 laver et dataset strukture 
            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            DataColumn IN = new DataColumn("Item Name");
            DataColumn IT = new DataColumn("Item Type");
            DataColumn AH = new DataColumn("Amount Held");
            DataColumn WPI = new DataColumn("Weight Per Item");
            DataColumn D = new DataColumn("Description");
            table.Columns.Add(idColumn);
            table.Columns.Add(IN);
            table.Columns.Add(IT);
            table.Columns.Add(AH);
            table.Columns.Add(WPI);
            table.Columns.Add(D);
            dataset.Tables.Add(table);
            if (!System.IO.File.Exists(createfile))
            {
                using (FileStream fileStream = new FileStream(createfile, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                {
                    using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8)) { 
                    int i = 0;
                    do
                        {
                            // Tilfører nu dataen fra listen til datasettet udfra antal items tilført til inventory
                            DataRow newRow = table.NewRow();
                            string ID = Convert.ToString(i);
                            ItemName = inventory.inventoryList[i].ItemName;
                            ItemType = inventory.inventoryList[i].ItemType;
                            AmountHeld = Convert.ToString(inventory.inventoryList[i].AmountHeld);
                            WeightPerItem = Convert.ToString(inventory.inventoryList[i].WeightPerItem);
                            Description = inventory.inventoryList[i].Description;
                            newRow["id"] = i;
                            newRow["Item Name"] = ItemName;
                            newRow["Item Type"] = ItemType;
                            newRow["Amount Held"] = AmountHeld;
                            newRow["Weight Per Item"] = WeightPerItem;
                            newRow["Description"] = Description;
                            table.Rows.Add(newRow);
                            i++;
                        } while (i != inventory.inventoryList.Count);
                     dataset.AcceptChanges();
                   
                    
                    JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(sw, dataset);
                    }
                }
            }
            else
            {

                //string test = File.ReadAllText(createfile);
                
                //dataset = JsonConvert.DeserializeObject<DataSet>(test);
                
                //using(StreamReader sr = new StreamReader(createfile))
                //{

                //}
                //foreach(DataRow row in table.Rows)
                //{
                    
                    
                   
                //}
                //
                //foreach(DataRow row in table.Rows)
                //{

                 //  
                //}
            }

                

                for (int i = 0; i < inventory.inventoryList.Count; i++)
                    {

                        
                    }
                
                
            }

        
}
        #endregion

    }
/*Code Referance
                        https://www.newtonsoft.com/json/help/html/SerializeDataSet.htm
                         https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm
                         https://www.newtonsoft.com/json/help/html/FromObject.htm
                         https://www.newtonsoft.com/json/help/html/Introduction.htm
*/






