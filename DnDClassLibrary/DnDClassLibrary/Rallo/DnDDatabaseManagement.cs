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

        public void DatabaseList()
        {
            Inventory cat = new Inventory(); // andet navn


            cat.RunInventory();



            File.WriteAllText(@"C:\Users\lasse\OneDrive\Dokumenter\P4\DnDSheetGroup\DnDClassLibrary\DnDClassLibrary\videogames.json", JsonConvert.SerializeObject(cat.InventoryList));
            using (StreamWriter file = File.CreateText(@"C:\Users\lasse\OneDrive\Dokumenter\P4\DnDSheetGroup\DnDClassLibrary\DnDClassLibrary\videogames.json"))
            {
                for (int i = 0; i < cat.InventoryList.Count; i++)
                {

                    JsonSerializer jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(file, cat.InventoryList[i]);
                }
            }


        }
    }
}





