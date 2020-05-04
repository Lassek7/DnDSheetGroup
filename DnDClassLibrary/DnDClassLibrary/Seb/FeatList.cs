using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    class FeatList
    {
        public List<Feat> AvailableFeatList = new List<Feat>();
        UtillityMethods Utility = new UtillityMethods();

        void ChooseFeat() //adds a feat to the list of available feat
        {
            Feat NewFeat = new Feat(Utility.ReadTextInput("Enter Feat name"));

            for (int i = 0; i < AvailableFeatList.Count; i++)
            {
                Feat OldFeat = AvailableFeatList[i];

                if (OldFeat.featName.Equals(NewFeat.featName))  //Checker om feat allerede er valgt
                {
                    NewFeat.featDescription = Utility.ReadTextInput("Enter Feat Description");
                    AvailableFeatList.Add(NewFeat);  //tilføjer den indtastede feat til liste
                    break;
                }
                else
                {
                    Console.WriteLine("You have already chosen this feat");
                    break;
                }
            }
        }

        void RemoveFeat()  //metode til at fjerne en feat fra listen: AvailableFeatList
        {
            string FeatToRemove = Utility.ReadTextInput("Enter the name of the Feat you wish to remove");
            AvailableFeatList.Remove(new Feat(FeatToRemove)); //burde fjerne den indtastede feat fra feat listen, skal testes
            Console.WriteLine("Removed Feat: " + FeatToRemove);
        }

        void ShowAvailableFeats() //burde printe available feats
        {
            for (int i = 0; i < AvailableFeatList.Count; i++)
            {
                Feat NewFeat = AvailableFeatList[i];
                Console.WriteLine(NewFeat.featName);
            }
        }
    }
}
