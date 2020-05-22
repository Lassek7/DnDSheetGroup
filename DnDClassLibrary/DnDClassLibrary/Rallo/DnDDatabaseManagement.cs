using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DnDClassLibrary
{
    public class DnDDatabaseManagement
    {
        #region FIELDS & CONSTRUCTOR 
        /*Laver en ny instans af CharacterAttributes, Character, Item klassene samt danner et nyt object af klassene, 
         * samt laver den en nye instans af forskellige lister i klassen Character, CharacterAttributes og Item*/
        CharacterAttributes myAttributes = new CharacterAttributes();
        Character myCharacter = new Character();
        Item myItem = new Item();
        public List<Character> myCharacterInfo = new List<Character>();
        public List<CharacterAttributes> myListAttributes = new List<CharacterAttributes>();
        public string filePath;
        public List<Item> InventoryList = new List<Item>();
        // public List<Item> BasicStarterItemList = new List<Item>();

        // Konstruktor som tilskriver intans variablene af CharacterAttributes, Character, list af item og Items
        public DnDDatabaseManagement(CharacterAttributes atri, Character Charac, List<Item> MyList, Item ItemContent)
        {
            myAttributes = atri;
            myCharacter = Charac;
            InventoryList = MyList;
            myItem = ItemContent;

        }
        

        public DnDDatabaseManagement()
        {
            //Constructor for load json file
        }
       
        #endregion
        #region INVENTORYLIST
        public string CreateJsonPathPreSetItem()
        {
            string folderPath = filePath;
            string pathString = System.IO.Path.Combine(folderPath, "Backup Character");
            string fileName = "StarterItem" + ".json";

            string starterItemFile = System.IO.Path.Combine(pathString, fileName);
            return starterItemFile;
        }
        
        public void SaveCharacterToFile(string afilePath)
        {
            string myfilePath = afilePath;
            DataSet dataset = new DataSet();
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;
            DataColumn CN = new DataColumn("Character Name");
            DataColumn PN = new DataColumn("Player Name");
            DataColumn Race = new DataColumn("Race");
            DataColumn Class = new DataColumn("Class");
            DataColumn AM = new DataColumn("Alignment");
            DataColumn BG = new DataColumn("Background");
            DataColumn MH = new DataColumn("MaxHealth");
            DataColumn Level = new DataColumn("Level");
            DataColumn PT = new DataColumn("Personal Traits");
            DataColumn Bonds = new DataColumn("Bonds");
            DataColumn Ideals = new DataColumn("Ideals");
            DataColumn Flaws = new DataColumn("Flaws");
            DataColumn BS = new DataColumn("Backstory");
            DataColumn STR = new DataColumn("Strength");
            DataColumn DEX = new DataColumn("Dexterity");
            DataColumn CON = new DataColumn("Consititution");
            DataColumn INT = new DataColumn("Intelligence");
            DataColumn WIS = new DataColumn("Wisdom");
            DataColumn CHA = new DataColumn("Charisma");
            DataColumn CP = new DataColumn("Copper Pieces");
            DataColumn SP = new DataColumn("Silver Pieces");
            DataColumn EP = new DataColumn("Electrum Pieces");
            DataColumn GP = new DataColumn("Gold Pieces");
            DataColumn PP = new DataColumn("Platinum");
            table.Columns.Add(CN);
            table.Columns.Add(PN);
            table.Columns.Add(Race);
            table.Columns.Add(Class);
            table.Columns.Add(AM);
            table.Columns.Add(BG);
            table.Columns.Add(MH);
            table.Columns.Add(Level);
            table.Columns.Add(PT);
            table.Columns.Add(Bonds);
            table.Columns.Add(Ideals);
            table.Columns.Add(Flaws);
            table.Columns.Add(BS);
            table.Columns.Add(STR);
            table.Columns.Add(DEX);
            table.Columns.Add(CON);
            table.Columns.Add(INT);
            table.Columns.Add(WIS);
            table.Columns.Add(CHA);
            table.Columns.Add(CP);
            table.Columns.Add(SP);
            table.Columns.Add(EP);
            table.Columns.Add(GP);
            table.Columns.Add(PP);
            dataset.Tables.Add(table);
            using (FileStream fileStream = new FileStream(afilePath, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
            {
                using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                {

                    // Tilfører nu dataen fra listen til datasettet udfra antal items tilført til inventory
                    DataRow newRow = table.NewRow();
                    
                    newRow[CN] = myCharacter.characterName;
                    newRow[PN] = myCharacter.playerName;
                    newRow[Race] = myCharacter.race;
                    newRow[Class] = myCharacter.characterClass;
                    newRow[AM] = myCharacter.alignment;
                    newRow[BG] = myCharacter.background;
                    newRow[MH] = myCharacter.maxHealth;
                    newRow[Level] = myCharacter.level;
                    newRow[PT] = myCharacter.traits;
                    newRow[Bonds] = myCharacter.bonds;
                    newRow[Ideals] = myCharacter.ideals;
                    newRow[Flaws] = myCharacter.flaws;
                    newRow[BS] = myCharacter.backstory;
                    newRow[STR] = myAttributes.Attributes[0];
                    newRow[DEX] = myAttributes.Attributes[1];
                    newRow[CON] = myAttributes.Attributes[2];
                    newRow[INT] = myAttributes.Attributes[3];
                    newRow[WIS] = myAttributes.Attributes[4];
                    newRow[CHA] = myAttributes.Attributes[5];
                    newRow[CP] = myItem.Copper;
                    newRow[SP] = myItem.Silver;
                    newRow[EP] = myItem.Electrum;
                    newRow[GP] = myItem.Gold;
                    newRow[PP] = myItem.Platinum;
                    table.Rows.Add(newRow);

                    dataset.AcceptChanges();
                    JsonSerializer serializer = new JsonSerializer();
                    
                    serializer.Serialize(sw, dataset);
                    table = new DataTable();
                    int CharacterLength = myCharacter.characterName.Length;
                    filePath = afilePath.Replace(myCharacter.characterName + ".json", "").Replace(" ", " ");
                    
                }
            }
        }

        public string[] LoadCharacterInfo(string JsonCharData)
        {
            string[] CharacterInfoArray = new string[19];
            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            string JsonFileToString = File.ReadAllText(JsonCharData);
            dataset = JsonConvert.DeserializeObject<DataSet>(JsonFileToString);
            table = dataset.Tables["table1"];
            
            foreach (DataRow row in table.Rows)
            {

                for(int i =0; i < CharacterInfoArray.Length; i++) {
                CharacterInfoArray[i] = Convert.ToString(row.ItemArray[i]);          
                }
            }
            return CharacterInfoArray;
        }
        
        public void SaveDataToFile(string filePathInventory)
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
                        DataColumn IID = new DataColumn("Item ID");
                        DataColumn IN = new DataColumn("Item Name");
                        DataColumn IT = new DataColumn("Item Type");
                        DataColumn AH = new DataColumn("Amount Held");
                        DataColumn WPI = new DataColumn("Weight Per Item");
                        DataColumn D = new DataColumn("Description");
                        table.Columns.Add(IID);
                        table.Columns.Add(IN);
                        table.Columns.Add(IT);
                        table.Columns.Add(AH);
                        table.Columns.Add(WPI);
                        table.Columns.Add(D);
                        dataset.Tables.Add(table);

                        using (FileStream fileStream = new FileStream(filePathInventory, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                        {
                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                            {

                                // Tilfører nu dataen fra listen til datasettet udfra antal items tilført til inventory
                                DataRow newRow = table.NewRow();

                                newRow[IID] = Item.ItemID;
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
                        DataColumn AIID = new DataColumn("Item ID");
                        DataColumn AIN = new DataColumn("Item Name");
                        DataColumn AIT = new DataColumn("Item Type");
                        DataColumn AFA = new DataColumn("AC From Armor");
                        DataColumn AAH = new DataColumn("Amount Held");
                        DataColumn AWPI = new DataColumn("Weight Per Item");
                        DataColumn AD = new DataColumn("Description");
                        DataColumn AIE = new DataColumn("Item Equipped");
                        table.Columns.Add(AIID);
                        table.Columns.Add(AIN);
                        table.Columns.Add(AIT);
                        table.Columns.Add(AFA);
                        table.Columns.Add(AAH);
                        table.Columns.Add(AWPI);
                        table.Columns.Add(AD);
                        table.Columns.Add(AIE);
                        dataset.Tables.Add(table);
                        using (FileStream fileStream = new FileStream(filePathInventory, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                        {
                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                            {
                                DataRow newRow = table.NewRow();
                                Armor armor = (Armor)Item;

                                newRow[AIID] = armor.ItemID;
                                newRow[AIN] = armor.ItemName;
                                newRow[AIT] = armor.ItemType;
                                newRow[AFA] = armor.ACFromArmor;
                                newRow[AAH] = armor.AmountHeld;
                                newRow[AWPI] = armor.WeightPerItem;
                                newRow[AD] = armor.Description;
                                newRow[AIE] = armor.ItemEquipped;
                                table.Rows.Add(newRow);

                                dataset.AcceptChanges();
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(sw, dataset);
                                table = new DataTable();
                            }
                        }
                        
                        break;

                    case 3:
                        DataColumn WIID = new DataColumn("Item ID");
                        DataColumn WIN = new DataColumn("Item Name");
                        DataColumn WIT = new DataColumn("Item Type");
                        DataColumn WAH = new DataColumn("Amount Held");
                        DataColumn WWPI = new DataColumn("Weight Per Item");
                        DataColumn WD = new DataColumn("Description");
                        DataColumn WAA = new DataColumn("Attribute Association");
                        DataColumn WR = new DataColumn("Range");
                        DataColumn WDAM = new DataColumn("Damage");
                        DataColumn WDT = new DataColumn("Damage Type");
                        DataColumn WIE = new DataColumn("Item Equipped");
                        table.Columns.Add(WIID);
                        table.Columns.Add(WIN);
                        table.Columns.Add(WIT);
                        table.Columns.Add(WAH);
                        table.Columns.Add(WWPI);
                        table.Columns.Add(WD);
                        table.Columns.Add(WAA);
                        table.Columns.Add(WR);
                        table.Columns.Add(WDAM);
                        table.Columns.Add(WDT);
                        table.Columns.Add(WIE);
                        dataset.Tables.Add(table);

                        using (FileStream fileStream = new FileStream(filePathInventory, FileMode.OpenOrCreate)) // åbner filen så man kan tilfører elementer
                        {
                            using (StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8))
                            {
                                Weapon weapon = (Weapon)Item;
                                DataRow newRow = table.NewRow();

                                newRow[WIID] = weapon.ItemID;
                                newRow[WIN] = weapon.ItemName;
                                newRow[WIT] = weapon.ItemType;
                                newRow[WAH] = weapon.AmountHeld;
                                newRow[WWPI] = weapon.WeightPerItem;
                                newRow[WD] = weapon.Description;
                                newRow[WAA] = weapon.AttributeAssociation;
                                newRow[WR] = weapon.Range;
                                newRow[WDAM] = weapon.Damage;
                                newRow[WDT] = weapon.DamageType;
                                newRow[WIE] = weapon.ItemEquipped;
                                table.Rows.Add(newRow);

                                dataset.AcceptChanges();
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(sw, dataset);
                                table = new DataTable();
                            }
                        }
                        break;
                    default:
                        break;          
                }
            }
        }

        public List<Item> DatabaseList(string JsonItemData) // 
        {
            int ItemID;
            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            string test2 = File.ReadAllText(JsonItemData);
            dataset = JsonConvert.DeserializeObject<DataSet>(test2);
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;
            for (int i = 1; i <= dataset.Tables.Count; i++)
            {
                table = dataset.Tables["table" + i];
                foreach (DataRow row in table.Rows)
                {

                    ItemID = Convert.ToInt32(row["Item ID"]);
                    switch (ItemID)
                    {

                        case 1:
                            Item test = new Item();
                            test.ItemID = Convert.ToInt32(row["Item ID"]);
                            test.ItemName = Convert.ToString(row["Item Name"]);
                            test.ItemType = Convert.ToString(row["Item Type"]);
                            test.AmountHeld = Convert.ToInt32(row["Amount Held"]);
                            test.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
                            test.Description = Convert.ToString(row["Description"]);
                            InventoryList.Add(test);
                            test = new Item();
                            break;
                        case 2:
                            Armor armor = new Armor();

                            armor.ItemID = Convert.ToInt32(row["Item ID"]);
                            armor.ItemName = Convert.ToString(row["Item Name"]);
                            armor.ItemType = Convert.ToString(row["Item Type"]);
                            armor.ACFromArmor = Convert.ToInt32(row["AC From Armor"]);
                            armor.AmountHeld = Convert.ToInt32(row["Amount Held"]);
                            armor.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
                            armor.ItemEquipped = Convert.ToBoolean(row["Item Equipped"]);
                            InventoryList.Add(armor);

                            break;
                        case 3:
                            Weapon weapon = new Weapon();

                            weapon.ItemID = Convert.ToInt32(row["Item ID"]);
                            weapon.ItemName = Convert.ToString(row["Item Name"]);
                            weapon.ItemType = Convert.ToString(row["Item Type"]);
                            weapon.AmountHeld = Convert.ToInt32(row["Amount Held"]);
                            weapon.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
                            weapon.Description = Convert.ToString(row["Description"]);
                            weapon.AttributeAssociation = Convert.ToString(row["Attribute Association"]);
                            weapon.Range = Convert.ToString(row["Range"]);
                            weapon.Damage = Convert.ToString(row["Damage"]);
                            weapon.DamageType = Convert.ToString(row["Damage Type"]);
                            weapon.ItemEquipped = Convert.ToBoolean(row["Item Equipped"]);
                            InventoryList.Add(weapon);
                            break;
                        default:
                            break;
                    }
                }
            }
            return InventoryList;
        }
        /*Til videre Arbejde (Future Work)*/
//public List<Item> BasicStarterItem()
//{
//    int ItemID;
//    DataSet dataset = new DataSet("dataSet");
//    dataset.Namespace = "NetFrameWork";
//    DataTable table = new DataTable();
//    string basicStarterItem = File.ReadAllText(CreateJsonPathPreSetItem());
//    dataset = JsonConvert.DeserializeObject<DataSet>(basicStarterItem);
//    DataColumn idColumn = new DataColumn("id", typeof(int));
//    idColumn.AutoIncrement = true;
//    for (int i = 1; i <= dataset.Tables.Count; i++)
//    {
//        table = dataset.Tables["table" + i];
//        foreach (DataRow row in table.Rows)
//        {

//            ItemID = Convert.ToInt32(row["Item ID"]);
//            switch (ItemID)
//            {

//                case 1:
//                    Item test = new Item();
//                    test.ItemID = Convert.ToInt32(row["Item ID"]);
//                    test.ItemName = Convert.ToString(row["Item Name"]);
//                    test.ItemType = Convert.ToString(row["Item Type"]);
//                    test.AmountHeld = Convert.ToInt32(row["Amount Held"]);
//                    test.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
//                    test.Description = Convert.ToString(row["Description"]);
//                    BasicStarterItemList.Add(test);
//                    test = new Item();
//                    break;
//                case 2:
//                    Armor armor = new Armor();

//                    armor.ItemID = Convert.ToInt32(row["Item ID"]);
//                    armor.ItemName = Convert.ToString(row["Item Name"]);
//                    armor.ItemType = Convert.ToString(row["Item Type"]);
//                    armor.ACFromArmor = Convert.ToInt32(row["AC From Armor"]);
//                    armor.AmountHeld = Convert.ToInt32(row["Amount Held"]);
//                    armor.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
//                    armor.ItemEquipped = Convert.ToBoolean(row["Item Equipped"]);
//                    BasicStarterItemList.Add(armor);

//                    break;
//                case 3:
//                    Weapon weapon = new Weapon();

//                    weapon.ItemID = Convert.ToInt32(row["Item ID"]);
//                    weapon.ItemName = Convert.ToString(row["Item Name"]);
//                    weapon.ItemType = Convert.ToString(row["Item Type"]);
//                    weapon.AmountHeld = Convert.ToInt32(row["Amount Held"]);
//                    weapon.WeightPerItem = Convert.ToInt32(row["Weight Per Item"]);
//                    weapon.Description = Convert.ToString(row["Description"]);
//                    weapon.AttributeAssociation = Convert.ToString(row["Attribute Association"]);
//                    weapon.Range = Convert.ToString(row["Range"]);
//                    weapon.Damage = Convert.ToString(row["Damage"]);
//                    weapon.DamageType = Convert.ToString(row["Damage Type"]);
//                    weapon.ItemEquipped = Convert.ToBoolean(row["Item Equipped"]);
//                    BasicStarterItemList.Add(weapon);
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//    return BasicStarterItemList;
/*Code Referance
                https://www.newtonsoft.com/json/help/html/SerializeDataSet.htm
                 https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm
                 https://www.newtonsoft.com/json/help/html/FromObject.htm
                 https://www.newtonsoft.com/json/help/html/Introduction.htm
//}
}
}

#endregion



*/






