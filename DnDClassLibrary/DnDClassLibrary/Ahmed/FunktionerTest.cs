using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class FunktionerTest
    {
        public void Print()
        {
            //Skill PrintOut = new Skill(2, new int[] {0, 0, 0, 0}, false);
            SavingThrow PrintOut2 = new SavingThrow(2, new int [] { 0, 0});

            //bool equalSelf = PrintOut.Equals(PrintOut);
            //equalSelf = Object.Equals(PrintOut, PrintOut);

            //Console.WriteLine("Skill Result:\n\n" + PrintOut + "\n\n");
            Console.WriteLine("SavingThrow Result:\n\n" + PrintOut2);
          
        }         
    }             
}                