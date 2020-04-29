using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDClassLibrary;

namespace DemoApp
{
    class TestTing // Lavet til at teste kode.
    {
        static void Main(string[] args)
        {
           
           
            DnDDatabaseManagement I2 = new DnDDatabaseManagement();
            int test = 0;
            Inventory I1 = new Inventory();
            while (test != 4)
            {
                Console.WriteLine("1: add item. 2: check items: 3 Remove item:");
                test = Convert.ToInt32(Console.ReadLine());

                
                switch (test)
                {
                    case 1:
                        I1.RunInventory();
                        
                        break;
                    case 2:
                        I1.CheckInventory();
                        break;
                    case 3:
                        I1.RemoveItem();
                        break;
                    default:
                        break;
                }
            }
            //I2.DatabaseList();
            Console.ReadKey();
        }
        
    }
}
