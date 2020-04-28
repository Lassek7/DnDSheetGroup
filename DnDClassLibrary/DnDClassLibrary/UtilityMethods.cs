using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class UtilityMethods // bruges til at forenkle brugen af WriteLine kombinered med Readline. 
    {
        public string ReadTextInput(string aMessage)  // indlæser en besked, skrevet i metodens brug
        {
            string returnValue;

            Console.WriteLine(aMessage); // bruger beskeden der er indlæst og viser den til brugeren
            returnValue = Console.ReadLine(); // giver brugerens input som værdi til returnValue

            return returnValue; // returnere værdien som brugeren har givet.
        }

        public int ReadNumericInput(string aMessage)
        {
            int returnValue;

            Console.WriteLine(aMessage);
            returnValue = Convert.ToInt32(Console.ReadLine());

            return returnValue;
        }
        public bool ReadBoolInput(string aMessage)
        {
            bool returnValue;

            Console.WriteLine(aMessage);
            returnValue = Convert.ToBoolean(Console.ReadLine());

            return returnValue;

        }
    }
}
