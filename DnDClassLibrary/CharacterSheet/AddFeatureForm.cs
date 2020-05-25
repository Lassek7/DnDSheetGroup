using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDClassLibrary;

namespace CharacterSheet
{
    public partial class AddFeatureForm : Form
    {
        #region FIELDS
        //Laver en ny instans af Feat klassen danner et nyt object af klassen Feat 
        Feat features = new Feat();
        List<Feat> myFeatureList = new List<Feat>();
        List<Feat> myOtherFeatureList = new List<Feat>();
        UtillityMethods myUtillities = new UtillityMethods();
        int myListID;
        //Initialisere Backgroundsfarven i Class feature fromen 
        public AddFeatureForm() 
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
        }
        #endregion
        #region CONSTRUKTOR
        //Initialisering af konstruktor, som initialisere instans variablene til et nyt objekt
        public AddFeatureForm(List<Feat> Features, List<Feat> OtherFeatures, String Slot1, string Slot2, int ID) 
        {
            InitializeComponent();
            AddButton.Text = Slot1;
            CancelButton.Text = Slot2;
            myFeatureList = Features;
            myOtherFeatureList = OtherFeatures;
            myListID = ID; 
        }
        #endregion
        #region CLICKEVENTS
        /*Methode som tilfører de tilført værdier fra brugeren og til dem til myFeatureList list i Feat Klassen,
          samt tjekker methoden også om brugeren har indtastet feature værdier*/
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (features.FeatName != null)
            {
                if (myListID == 1)
                {
                    myFeatureList.Add(features);
                }
                else
                {
                    myOtherFeatureList.Add(features);
                }
                this.Hide();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Input a name for the feature");
            }
        }
        //Methoden Cancelbutton afslutter AddFeatureForm, som lukker dialog vinduet 
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion
        #region TEXTCHANGED
        /*Methods som tager den inputtet text (Navnet på feature) 
        fra brugeren og assigner det til værdien FeatName i klassen feat*/
        private void FeatureNameTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(FeatureNameTextBox.Text);

            features.FeatName = myUtillities.NewValue(OutOfReach, FeatureNameTextBox.Text);
        }
        /*Methods som tager den inputtet text (Navnet på feature) 
        fra brugeren og assigner det til værdien FeatName i klassen feat*/
        private void FeatureDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            bool OutOfReach = string.IsNullOrEmpty(FeatureDescriptionTextBox.Text);

            features.FeatDescription = myUtillities.NewValue(OutOfReach, FeatureDescriptionTextBox.Text);
        }
        #endregion
    }
}
