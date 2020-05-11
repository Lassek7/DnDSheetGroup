using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Weapon : Item
    {
        private string attributeAssociation;
        private int attackModifier;
        private string range;
        private string damage;
        private string damageType;
        private int attackBonus;
        private bool itemEquipped;
        private bool proficiency;
        private int proficiencyModifier;


        
        public string AttributeAssociation // validering tilføjes senere
        {
            get { return attributeAssociation; }
            set { attributeAssociation = value; }
        }
         public int AttackModifier
        {
            get { return attackModifier; }
            set { attackModifier = value; }
        }
        public string Range
        {
            get { return range; }
            set { range = value; }
        }
        public string Damage
        {
            get { return damage; }
            set { damage = value; }
        }
         public string DamageType
        {
            get { return damageType; }
            set { damageType = value; }
        }
         public int AttackBonus
        {
            get { return attackBonus; }
            set { attackBonus = value; }
        }
        public bool ItemEquipped
        {
            get { return itemEquipped; }
            set { itemEquipped = value; }
        }
        public bool Proficiency
        {
            get { return proficiency; }
            set { proficiency = value; }
        }
        public int ProficiencyModifier
        {
            get {return proficiencyModifier;}
            set {proficiencyModifier = value;}
        }
    }
}
