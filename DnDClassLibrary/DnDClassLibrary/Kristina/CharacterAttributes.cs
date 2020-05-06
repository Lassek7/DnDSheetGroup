using System;
using System.Linq;


namespace DnDClassLibrary
{
   public class CharacterAttributes
    {
        public int[] Attributes { get; set; } = new int[6];
        public int[] Modifiers

        {
            get
            {
                return Attributes.Select(attr => (attr - 10) / 2).ToArray();
            }
            set
            {
                Modifiers = value;
            }
        }

        public enum Fields
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }
    }

    /* Til at prøve det af i Main
            //Kristina start
            for (int i = 0; i < 6; i++)
            {
                Console.Write($"{Enum.GetNames(typeof(CharacterAttributes.Fields))[i]}: ");
                CharacterAttributes.Attributes[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 6; i++)
            {
                Console.Write($"{Enum.GetNames(typeof(CharacterAttributes.Fields))[i]} modifier: ");
                Console.WriteLine(CharacterAttributes.Modifiers[i]);
            }
            //Kristina slut
     */
}








