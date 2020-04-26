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
}
    


    

       


