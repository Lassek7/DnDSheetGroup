using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class UtillityMethods // bruges til at forenkle brugen af WriteLine kombinered med Readline. 
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
        public string NewValue(bool exists, string UserInput) // giver en lije en ny værdi, hvis værdien ikke er null
        {
            if (exists == true)
            {
                return UserInput;
            }
            return null;
        }
        public bool existcheck(string OldValue, string NewValue, bool ExistStatus) // tjekker om der er skrevet noget på en linje
        {
            bool OutOfReach = string.IsNullOrEmpty(NewValue);
            if (OutOfReach != true)
            {
                ExistStatus = true;
            }
            else
            {
                ExistStatus = false;
            }
            return ExistStatus;
        }
    }
}
