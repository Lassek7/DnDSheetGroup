using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class FeatList
    {
        public List<Feat> AvailableFeatList = new List<Feat>();
        UtillityMethods Utility = new UtillityMethods();

        public void ChooseFeat() //adds a feat to the list of available feat
        {
            Feat NewFeat = new Feat();
                
            NewFeat.FeatName = Utility.ReadTextInput("Enter Feat name");

            bool FeatExist = CheckFeatList(NewFeat);

            if(FeatExist == true)
            {
                Console.WriteLine("You already have chosen this feat");
            }
            else
            {
                NewFeat.FeatDescription = Utility.ReadTextInput("Enter Feat Description");
                AvailableFeatList.Add(NewFeat);  //tilføjer den indtastede feat til liste
            }
        }

        public void RemoveFeat()  //metode til at fjerne en feat fra listen: AvailableFeatList
        {
            string FeatToRemove = Utility.ReadTextInput("Enter the name of the Feat you wish to remove");

            for (int i = 0; i < AvailableFeatList.Count; i++)
            {
                Feat OldFeat = AvailableFeatList[i];

                if (OldFeat.FeatName.Equals(FeatToRemove))
                {
                    AvailableFeatList.Remove(OldFeat); //burde fjerne den indtastede feat fra feat listen, skal testes
                    Console.WriteLine("Removed Feat: {0}", FeatToRemove);
                    break;
                }
                else if (i == AvailableFeatList.Count-1)
                {
                    Console.WriteLine("You do not have this feat");
                    break;
                }
            }
        }


        public void ShowAvailableFeats() //printer navnene på feat  
        {
            foreach (var Feat in AvailableFeatList)
            {
                Console.WriteLine("Feats:{0}", Feat.FeatName);
            }
        }
        private bool CheckFeatList(Feat NewFeat)
        {
            bool FeatExist = false;
            for (int i = 0; i < AvailableFeatList.Count; i++)
            {
                Feat OldFeat = AvailableFeatList[i];
                if (OldFeat.FeatName.Equals(NewFeat.FeatName))
                {
                    FeatExist = true;
                }
            }
            return FeatExist;
        }
    }
}
