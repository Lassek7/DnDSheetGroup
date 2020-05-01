using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class SpellBook
    {

        public List<Spell> AvailableSpellList = new List<Spell>(); // indlæs alle tilgængelige spells fra database? gør måske static??
        public List<Spell> PreparedSpellList = new List<Spell>(); //liste over prepared spells
        UtilityMethods Utility = new UtilityMethods();


        void AddAvailableSpell() //adds a spell to the list of available spells
        {
            Spell     NewSpell     = new Spell();
            Character NewCharacter = new Character();

            NewSpell.SpellName        = Utility.ReadTextInput("Enter Spell name");
            NewSpell.SpellLevel       = Utility.ReadNumericInput("Enter Spell level");
           
            if (NewCharacter.level >= NewSpell.SpellLevel) //Check om character er i højt nok level for den intastede spell
            {
                NewSpell.Components = Utility.ReadTextInput("Enter Required Components");
                NewSpell.Duration = Utility.ReadTextInput("Enter Spell duration");
                NewSpell.CastTime = Utility.ReadTextInput("Enter Cast time");
                NewSpell.Range = Utility.ReadNumericInput("Enter Spell Range");
                NewSpell.SpellSchool = Utility.ReadTextInput("Enter Spell School");
                NewSpell.SpellDescription = Utility.ReadTextInput("Enter Spell Description");
                NewSpell.Resources = Utility.ReadNumericInput("Enter required resources");
                NewSpell.SpellDC = Utility.ReadNumericInput("Enter Spell DC");
                NewSpell.SpellBonus = Utility.ReadNumericInput("Enter Spell bonus");

                AvailableSpellList.Add(NewSpell);
            }
            else
            {
                Console.WriteLine("This spell is too high level for your character");
            }
       
        }

        void PrepareSpell() //Adds an available spell to the PreparedSpellList
        {
            Spell NewSpell = new Spell(Utility.ReadTextInput("Enter the name of the spell you want to prepare"));

            for (int i = 0; i < AvailableSpellList.Count; i++)
            {
                Spell OldSpell = AvailableSpellList[i];
                if (OldSpell.SpellName.Equals(NewSpell.SpellName))  //Check om spell er på AvailableSpellList
                {
                    PreparedSpellList.Add(NewSpell);
                    break;
                }
                else
                {
                    Console.WriteLine("You do not have this spell available");
                    break;
                }
            }
        }

        void UnPrepareSpell() 
        {
            string SpellToUnprepare = Utility.ReadTextInput("Enter Spell name of the spell you wish to no longer prepare");
            PreparedSpellList.Remove(new Spell(SpellToUnprepare)); //burde fjerne den indtastede spell fra Prepared Spells listen, skal testes
            Console.WriteLine("No longer preparing " + SpellToUnprepare);
        }

        void ShowAvailableSpells() //burde printe available spells
        {
            for (int i = 0; i < AvailableSpellList.Count; i++)
            {
                Spell NewSpell = AvailableSpellList[i];
                Console.WriteLine(NewSpell.SpellName);
            }
        }

        void ShowPreparedSpells() //burde printe prepared spells
        {
            for (int i = 0; i < PreparedSpellList.Count; i++)
            {
                Spell NewSpell = PreparedSpellList[i];
                Console.WriteLine(NewSpell.SpellName);
            }
        }



    }
}
