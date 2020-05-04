using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Feat
    {
        private string featName;
        private string featDescription;

        public Feat()
        {
        }

        public Feat(string featName)
        { 
            this.featName = featName;
        }

        public string FeatName
        {
            get { return featName; }
            set { featName = value; }
        }

        public string FeatDescription
        {
            get { return featDescription; }
            set { featDescription = value; }
        }

    }
}
