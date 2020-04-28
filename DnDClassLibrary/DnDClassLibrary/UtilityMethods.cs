using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class UtilityMethods
    {
        public string ReadTextInput(string aMessage)
        {
            string returnValue;

            Console.WriteLine(aMessage);
            returnValue = Console.ReadLine();

            return returnValue;
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
