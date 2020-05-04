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
            //seb start
            //FeatList MyFeatlist = new FeatList();
            //MyFeatlist.ChooseFeat();
            //MyFeatlist.ChooseFeat();
            //MyFeatlist.ShowAvailableFeats();
            //MyFeatlist.RemoveFeat();
            //MyFeatlist.ShowAvailableFeats();
            //Console.ReadKey();

            //SpellBook mySpellBook = new SpellBook();
            //mySpellBook.AddAvailableSpell();
            //mySpellBook.AddAvailableSpell();
            //mySpellBook.ShowAvailableSpells();
            //mySpellBook.PrepareSpell();
            //mySpellBook.UnPrepareSpell();
            //mySpellBook.ShowPreparedSpells();
            //Console.ReadKey();
            //seb slut

            DnDDatabaseManagement RunInv = new DnDDatabaseManagement();
            RunInv.CharatorCreation();
            Console.ReadKey();


            //Kristina start
            //for (int i = 0; i < 6; i++)
            //{
            //    Console.Write($"{Enum.GetNames(typeof(CharacterAttributes.Fields))[i]}: ");
            //    CharacterAttributes.Attributes[i] = int.Parse(Console.ReadLine());
            //}

            //for (int i = 0; i < 6; i++)
            //{
            //    Console.Write($"{Enum.GetNames(typeof(CharacterAttributes.Fields))[i]} modifier: ");
            //    Console.WriteLine(CharacterAttributes.Modifiers[i]);
            //}
            //Kristina slut


            //Ahmed start
            //FunktionerTest bom = new FunktionerTest();
            //bom.Print();
            //Console.ReadLine();
            //Ahmed slut
        }
    }
}
