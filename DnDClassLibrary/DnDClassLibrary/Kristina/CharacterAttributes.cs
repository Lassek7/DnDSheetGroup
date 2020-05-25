using System;
using System.Linq;


namespace DnDClassLibrary
{
    public class CharacterAttributes
    {
        public int[] Attributes { get; set; } = new int[6];
        /*Select beregner nye elementer ud ifra elementerne i Attributes
         *De nye elementer kommer ud som IEnumerable og konverteres til et array med ToArray
         *Uendelig rekursion, da modifieres = værdi kalder modifieres{set}(altså sig selv) value keyword 
         * bliver brugt for at definere værdien assigned af "set" accessoren*/
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
}

    








