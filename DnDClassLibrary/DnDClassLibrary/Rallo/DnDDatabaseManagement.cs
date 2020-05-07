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
        private string PlayerName { get; set; }
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();
        public DnDDatabaseManagement(CharacterAttributes atri, Character Charac)
        {
            myAttributes = atri;
            myCharacter = Charac;

        }

        public void CharatorCreation()
        {
            bool RunApp = false;
            do
            {
                string answer;
                Console.WriteLine("Welcome To Dnd Charator Manager");
                Console.WriteLine("Type your Player name:");
                PlayerName = Console.ReadLine();
                Console.WriteLine("Your charator name is:" + PlayerName);
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
             1.1 lavet sådan at de enkelt værdiere i json filen bliver lagret i de forskellige værdier i koden(Evt i DndClassen) (DOne)
             2. Tilfører verison kontrol som tjekker efter backup filer
             3. tilfører attribute i json filen 
             4. laver en validering som overwritter den gamle fil
             5. tilføre en autosave knap evt 
             
            Spørgsmål til Shagen
            1. Hvordan kalder man en child igennem en list fra parent
             
             
             */
        }
        #region INVENTORYLIST
        public string UserFilePath()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName; // sætter path værdien til at være ens Windows brugere mappe i file explorer ex. (C:\Users\rallo\Backup Character)
            // I if statment tjekker den version af Windows OS om det er vista, windows 7 eller windows 10
            // Hvis Windows OS version er større eller ligmed 6 henter den rigtig placering af mappen og laver den til en string
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }
            return path;
        }
        public void DatabaseList() // 
        {
            Inventory inventory = new Inventory(); // andet navn
            inventory.RunInventory(); // kører Inventory manager


            string foldername = UserFilePath();
            string pathString = System.IO.Path.Combine(foldername, "Backup Character");
            string fileName = PlayerName + ".json"; // henter Navnet på spilleren og sætter navnet på backup filen til at være (PlayerName.json)

            System.IO.Directory.CreateDirectory(pathString); // laver mappen Backup Character 
            string createfile = System.IO.Path.Combine(pathString, fileName); // kombinere mappens placering og navnet på backup filen til en string ex.(C:\Users\rallo\Backup Character\PlayerName.json)

            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            //switch (inventory.invtypeDatabase)
            //{                                                                  // Linje 98 til 107 laver et dataset strukture 
            //    case "ITEM":
            //        DataColumn IN = new DataColumn("Item Name");
            //        DataColumn IT = new DataColumn("Item Type");
            //        DataColumn AH = new DataColumn("Amount Held");
            //        DataColumn WPI = new DataColumn("Weight Per Item");
            //        DataColumn D = new DataColumn("Description");
            //        table.Columns.Add(idColumn);
            //        table.Columns.Add(IN);
            //        table.Columns.Add(IT);
            //        table.Columns.Add(AH);
            //        table.Columns.Add(WPI);
            //        table.Columns.Add(D);
            //        dataset.Tables.Add(table);

            //        if (!System.IO.File.Exists(createfile))
            //        {
            //            using (FileStream fileStream = new FileStream(createfile, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
            //            {
            //                using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
            //                {
            //                    int i = 0;

            //                    do
            //                    {

            //                        // Tilfører nu dataen fra listen til datasettet udfra antal items tilført til inventory
            //                        DataRow newRow = table.NewRow();
            //                        string ID = Convert.ToString(i);
            //                        newRow["id"] = i;
            //                        newRow["Item Name"] = inventory.inventoryList[i];
            //                        newRow["Item Type"] = inventory.inventoryList[i].ItemType;
            //                        newRow["Amount Held"] = Convert.ToString(inventory.inventoryList[i].AmountHeld);
            //                        newRow["Weight Per Item"] = Convert.ToString(inventory.inventoryList[i].WeightPerItem);
            //                        newRow["Description"] = inventory.inventoryList[i].Description;
            //                        table.Rows.Add(newRow);
            //                        i++;
            //                    } while (i != inventory.inventoryList.Count);

            //                    dataset.AcceptChanges();
            //                    JsonSerializer serializer = new JsonSerializer();
            //                    serializer.Serialize(sw, dataset);
            //                }
            //            }
            //        }
            //                    else
            //                    {
            //                        Inventory inv = new Inventory();
            //                        Item aItem = new Item();
            //                        string test = File.ReadAllText(createfile);
            //                        dataset = JsonConvert.DeserializeObject<DataSet>(test);
            //                        table = dataset.Tables["table1"];
            //                        foreach (DataRow row in table.Rows)
            //                        {
            //                            aItem.ItemName = Convert.ToString(row["Item Name"]);
            //                            aItem.ItemType = Convert.ToString(row["Item type"]);
            //                            aItem.AmountHeld = Convert.ToInt32(row["Amount Held"]);
            //                            aItem.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
            //                            aItem.Description = Convert.ToString(row["Description"]);
            //                            inv.inventoryList.Add(aItem);
            //                            aItem = new Item();
            //                        }
            //                    }
            //                    break;
            //                case "ARMOR":
            //                    Armor aData = new Armor();

            //                    DataColumn AIT = new DataColumn("Item Type");
            //                    DataColumn AFA = new DataColumn("AC From Armor");
            //                    DataColumn AAH = new DataColumn("Amount Held");
            //                    DataColumn AWPI = new DataColumn("Weight Per Item");
            //                    DataColumn AD = new DataColumn("Description");
            //                    DataColumn AIE = new DataColumn("Item Equipped");
            //                    table.Columns.Add(idColumn);
            //                    table.Columns.Add(AIT);
            //                    table.Columns.Add(AFA);
            //                    table.Columns.Add(AAH);
            //                    table.Columns.Add(AWPI);
            //                    table.Columns.Add(AD);
            //                    table.Columns.Add(AIE);
            //                    dataset.Tables.Add(table);
            //                    if (!System.IO.File.Exists(createfile))
            //                    {
            //                        using (FileStream fileStream = new FileStream(createfile, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
            //                        {
            //                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
            //                            {
            //                                int i = 0;

            //                                do
            //                                {

            //                                    // Tilfører nu dataen fra listen til datasettet udfra antal items tilført til inventory
            //                                    DataRow newRow = table.NewRow();
            //                                    string ID = Convert.ToString(i);
            //                                    newRow["id"] = i;
            //                                    newRow["Item Type"] = inventory.inventoryList[i].ItemType;                                  // WIP
            //                                    newRow["AC From Armor"] = inventory.inventoryList[i].ItemType;
            //                                    newRow["Amount Held"] = Convert.ToString(inventory.inventoryList[i].AmountHeld);
            //                                    newRow["Weight Per Item"] = Convert.ToString(inventory.inventoryList[i].WeightPerItem);
            //                                    newRow["Description"] = inventory.inventoryList[i].Description;
            //                                    newRow["Item Equipped"] = Convert.ToString(inventory.inventoryList[i]);
            //                                    table.Rows.Add(newRow);
            //                                    i++;
            //                                } while (i != inventory.inventoryList.Count);

            //                                dataset.AcceptChanges();
            //                                JsonSerializer serializer = new JsonSerializer();
            //                                serializer.Serialize(sw, dataset);
            //                            }
            //                        }
            //                    }
            //                    break;
            //                case "WEAPON":
            //                    break;
            //                default:
            //                    break;
            //            }
        }
    }
}

#endregion


/*Code Referance
                        https://www.newtonsoft.com/json/help/html/SerializeDataSet.htm
                         https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm
                         https://www.newtonsoft.com/json/help/html/FromObject.htm
                         https://www.newtonsoft.com/json/help/html/Introduction.htm
*/






