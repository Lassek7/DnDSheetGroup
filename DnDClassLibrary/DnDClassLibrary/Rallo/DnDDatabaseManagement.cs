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
        List<Item> InventoryList = new List<Item>();
        
        public DnDDatabaseManagement(CharacterAttributes atri, Character Charac, List<Item> MyList)
        {
            myAttributes = atri;
            myCharacter = Charac;
            InventoryList = MyList; 

        }
        


        public void CharatorCreation()
        {
            bool RunApp = false;
            do
            {
                string answer;
                Console.WriteLine("Welcome To Dnd Charator Manager");
                Console.WriteLine("Type your Player name:");
                PlayerName = myCharacter.playerName;
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
        // kombinere mappens placering og navnet på backup filen til en string ex.(C:\Users\rallo\Backup Character\PlayerName.json)
        public string CreateFolder()
        {
            string foldername = UserFilePath();
            string pathString = System.IO.Path.Combine(foldername, "Backup Character");
            string fileName = myCharacter.playerName + ".json"; // henter Navnet på spilleren og sætter navnet på backup filen til at være (PlayerName.json)

            System.IO.Directory.CreateDirectory(pathString); // laver mappen Backup Character 
            string createfile = System.IO.Path.Combine(pathString, fileName);
            return createfile;
        }
        
        public void RunInvList()
        {

            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;
            foreach (var Item in InventoryList)
            {

                int ID = Item.ItemID;
                switch (ID)
                {
                    case 1:
                        DataColumn IN = new DataColumn("Item Name");
                        DataColumn IT = new DataColumn("Item Type");
                        DataColumn AH = new DataColumn("Amount Held");
                        DataColumn WPI = new DataColumn("Weight Per Item");
                        DataColumn D = new DataColumn("Description");
                        table.Columns.Add(IN);
                        table.Columns.Add(IT);
                        table.Columns.Add(AH);
                        table.Columns.Add(WPI);
                        table.Columns.Add(D);
                        dataset.Tables.Add(table);

                        using (FileStream fileStream = new FileStream(CreateFolder(), FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                        {
                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                            {

                                // Tilfører nu dataen fra listen til datasettet udfra antal items tilført til inventory
                                DataRow newRow = table.NewRow();

                                newRow[IN] = Item.ItemName;
                                newRow[IT] = Item.ItemType;
                                newRow[AH] = Item.AmountHeld;
                                newRow[WPI] = Item.WeightPerItem;
                                newRow[D] = Item.Description;
                                table.Rows.Add(newRow);

                                dataset.AcceptChanges();
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(sw, dataset);
                                table = new DataTable();
                            }
                        }
                        break;
                    case 2:
                         // typecast objectet item over til armor classen
                        DataColumn AIT = new DataColumn("Item Type");
                        DataColumn AFA = new DataColumn("AC From Armor");
                        DataColumn AAH = new DataColumn("Amount Held");
                        DataColumn AWPI = new DataColumn("Weight Per Item");
                        DataColumn AD = new DataColumn("Description");
                        DataColumn AIE = new DataColumn("Item Equipped");
                        table.Columns.Add(AIT);
                        table.Columns.Add(AFA);
                        table.Columns.Add(AAH);
                        table.Columns.Add(AWPI);
                        table.Columns.Add(AD);
                        table.Columns.Add(AIE);
                        dataset.Tables.Add(table);
                        using (FileStream fileStream = new FileStream(CreateFolder(), FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                        {
                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                            {
            
                                    DataRow newRow = table.NewRow();
                                    Armor armor = (Armor)Item;

                                    newRow["Item Type"] = armor.ItemType;
                                    newRow["AC From Armor"] = armor.ACFromArmor;
                                    newRow["Amount Held"] = armor.AmountHeld;
                                    newRow["Weight Per Item"] = armor.WeightPerItem;
                                    newRow["Description"] = armor.Description;
                                    newRow["Item Equipped"] = armor.ItemEquipped;
                                    table.Rows.Add(newRow);

                                dataset.AcceptChanges();
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(sw, dataset);
                                table = new DataTable();
                            }
                        }
                        //InvList += armor.ItemName + " " + armor.AmountHeld + " " + armor.WeightPerItem + " " + armor.Description + " " + armor.ItemType + " " + armor.ACFromArmor + Environment.NewLine;
                        break;

                    case 3:
                        DataColumn WIT = new DataColumn("Item Type");
                        DataColumn WAH = new DataColumn("Amount Held");
                        DataColumn WWPI = new DataColumn("Weight Per Item");
                        DataColumn WD = new DataColumn("Description");
                        DataColumn WAA = new DataColumn("Attribute Association");
                        DataColumn WR = new DataColumn("Range");
                        DataColumn WDAM = new DataColumn("Damage");
                        DataColumn WDT = new DataColumn("Damage Type");
                        DataColumn WIE = new DataColumn("Item Equipped");
                        table.Columns.Add(WIT);
                        table.Columns.Add(WAH);
                        table.Columns.Add(WWPI);
                        table.Columns.Add(WD);
                        table.Columns.Add(WAA);
                        table.Columns.Add(WR);
                        table.Columns.Add(WDAM);
                        table.Columns.Add(WDT);
                        table.Columns.Add(WIE);
                        

                        using (FileStream fileStream = new FileStream(CreateFolder(), FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                        {
                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                            {
                                Weapon weapon = (Weapon)Item;
                                DataRow newRow = table.NewRow();

                                newRow[WIT] = weapon.ItemType;
                                newRow[WAH] = weapon.AmountHeld;
                                newRow[WWPI] = weapon.WeightPerItem;
                                newRow[WD] = weapon.Description;
                                newRow[WAA] = weapon.AttributeAssociation;
                                newRow[WR] = weapon.Range;
                                newRow[WDAM] = weapon.Damage;
                                newRow[WDT] = weapon.DamageType;
                                newRow[WIE] = weapon.ItemEquipped;
                                dataset.AcceptChanges();
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(sw, dataset);
                                table = new DataTable();
                            }
                        }
                        
                        break;
                }

            }
        }
        public void DatabaseList() // 
        {
          
                   // Setup for deserialize aka load filen til programmet igen
                        //Inventory inv = new Inventory();
                        //Item aItem = new Item();
                        //string test = File.ReadAllText(CreateFolder());
                        //dataset = JsonConvert.DeserializeObject<DataSet>(test);
                        //table = dataset.Tables["table1"];
                        //foreach (DataRow row in table.Rows)
                        //{
                        //    aItem.ItemName = Convert.ToString(row["Item Name"]);
                        //    aItem.ItemType = Convert.ToString(row["Item type"]);
                        //    aItem.AmountHeld = Convert.ToInt32(row["Amount Held"]);
                        //    aItem.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
                        //    aItem.Description = Convert.ToString(row["Description"]);
                        //    inv.inventoryList.Add(aItem);
                        //    aItem = new Item();
                        
                        //}
               
                       
            
            
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






