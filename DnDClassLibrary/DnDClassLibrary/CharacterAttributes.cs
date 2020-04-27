using System;
using System.Linq;


namespace CharacterAttributesModifiers
{
    class CharacterAttributes
    {
        public int[] Attributes { get; set; }
        public int[] Modifiers
        {
            get
            {
                return Attributes.Select(attr => (attr - 10) / 2).ToArray();
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
        public CharacterAttributes()
        {
            Attributes = new int[6];
        }
    }

    /* Til at prøve det af i Main
            CharacterAttributes c = new CharacterAttributes();

            for(int i= 0; i <6; i++)
            {
                Write($"{Enum.GetNames(typeof(Fields))[i]}: ");
                c.Attributes[i] = int.Parse(ReadLine());
            }

            for (int i = 0; i < 6; i++)
            {
                Write($"{Enum.GetNames(typeof(Fields))[i]} modifier: ");
                WriteLine(c.Modifiers[i]);
            }

    
     */
}








