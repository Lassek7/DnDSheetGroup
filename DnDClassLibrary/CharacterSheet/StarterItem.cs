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
    public partial class StarterItem : Form
    {
        List<Item> BasicStarterItemList = new List<Item>();
        List<Item> InventoryList = new List<Item>();
        
        public StarterItem(List<Item> myBasicStarterItemList, List<Item> myInventoryList)
        {
            BasicStarterItemList = myBasicStarterItemList;
            InventoryList = myInventoryList;

            InitializeComponent();
        }
     
        // inplementere Starter Item til listen over til InventoryList
        private void button1_Click(object sender, EventArgs e)
        {
            if(Club.Checked == true)
            {
                
                InventoryList.Add(BasicStarterItemList[1]);
            }
            if(PaddedArmor.Checked == true)
            {

            }
            if(Dagger.Checked == true)
            {

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Quarterstaff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Handaxe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LightCrossbow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Dart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Shortbow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Sling_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Battleaxe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Greataxe_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Greatsword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Shortsword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Blowgun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HandCrossbow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HeavyCrossbow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LongBow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LeatherArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void StuddedLeatherArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HideArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChainShirtArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ScaleMailArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BreastplateArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HalfPlateArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RingMailArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChainMailArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SplintArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PlateArmor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Shield_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
