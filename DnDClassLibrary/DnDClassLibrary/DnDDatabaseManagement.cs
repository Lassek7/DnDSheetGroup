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

            File.WriteAllText(@"C:\Users\rallo\source\repos\LAK258\DnDSheetGroup\DnDClassLibrary\DnDClassLibrary\videogames.json", JsonConvert.SerializeObject(Inventory.InventoryList));
            using (StreamWriter file = File.CreateText(@"C:\Users\rallo\source\repos\LAK258\DnDSheetGroup\DnDClassLibrary\DnDClassLibrary\videogames.json"))
            {
                for (int i = 0; i < Inventory.InventoryList.Count; i++)
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(file, Inventory.InventoryList[i]);
                }
            }


        }
    }
}





