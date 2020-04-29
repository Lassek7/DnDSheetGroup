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
           
           
            DnDDatabaseManagement RunInv = new DnDDatabaseManagement();
            Inventory k = new Inventory();
            k.Test();

            // RunInv.DatabaseList();
            Console.ReadKey();
        }
        
    }
}
