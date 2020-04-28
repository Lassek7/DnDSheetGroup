using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class FunktionerTest
    {
        public void Print()
        {
            Skill PrintOut = new Skill(3, 1, 3, 0, 2, 4, 2, new int[] {1, 3, 6, 17}, false);
            SavingThrow PrintOut2 = new SavingThrow(3, 1, 3, 0, 2, 4, 2, new int[] {4, 5}, false);
            
            //bool equalSelf = PrintOut.Equals(PrintOut);
            //equalSelf = Object.Equals(PrintOut, PrintOut);

            Console.WriteLine("Skill Result:\n\n" + PrintOut + "\n\n");
            Console.WriteLine("SavingThrow Result:\n\n" + PrintOut2);
        }         
    }             
}                