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

            CharacterAttributes c = new CharacterAttributes();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Enum.GetNames(typeof(CharacterAttributes.Fields))[i]}: ");
                c.Attributes[i] = int.Parse(Console.ReadLine());

            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Enum.GetNames(typeof(CharacterAttributes.Fields))[i]} modifier: ");
                Console.WriteLine(c.Modifiers[i]);
            }


            //Ahmed start
            FunktionerTest bom = new FunktionerTest();
            bom.Print();
            Console.ReadLine();
            //Ahmed slut
        }
    }
}
