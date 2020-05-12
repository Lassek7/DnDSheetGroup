using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Feat features = new Feat();
        List<Feat> myFeatureList = new List<Feat>();
        List<Feat> myOtherFeatureList = new List<Feat>();
        int myListID;
        public AddFeatureForm()
        {
            InitializeComponent();
        }
       
        public AddFeatureForm(List<Feat> Features, List<Feat> OtherFeatures, String Slot1, string Slot2, int ID)
        {
            InitializeComponent();
            AddButton.Text = Slot1;
            CancelButton.Text = Slot2;
            myFeatureList = Features;
            myOtherFeatureList = OtherFeatures;
            myListID = ID; 
        }

        private void AddButton_Click(object sender, EventArgs e)
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FeatureNameTextBox_TextChanged(object sender, EventArgs e)
        {
            features.FeatName = FeatureNameTextBox.Text;

        }

        private void FeatureDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            features.FeatDescription = FeatureDescriptionTextBox.Text;

        }
    }
}
