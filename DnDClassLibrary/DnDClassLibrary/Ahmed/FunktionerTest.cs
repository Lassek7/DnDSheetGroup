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
            
            //bool equalSelf = PrintOut.Equals(PrintOut);
            //equalSelf = Object.Equals(PrintOut, PrintOut);

            Console.WriteLine("Result:\n\n" + PrintOut);
        }         
    }             
}                