using System;
using System.Collections.Generic;
using System.Text;

namespace DnDClassLibrary
{
    public class Feat
    {
        private string FeatName;
        private string FeatDescription;

        public Feat()
        {
        }

        public Feat(string featName)
        { 
            this.featName = featName;
        }

        public string featName
        {
            get { return featName; }
            set { featName = value; }
        }

        public string featDescription
        {
            get { return featDescription; }
            set { featDescription = value; }
        }

    }
}
