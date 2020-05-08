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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCharacterForm RunCreateCharacter = new CreateCharacterForm();
            RunCreateCharacter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Item> InventoryList = new List<Item>();
            this.Hide();
            DnDDatabaseManagement ShitV2 = new DnDDatabaseManagement();
            string test = @"C:\Users\rallo\Backup Character\test4.json";

            InventoryList = ShitV2.DatabaseList(test);
            //MessageBox.Show(ShitV2.InventoryList[0].ItemName);
            
            Sheet LoadCharacter = new Sheet(InventoryList);
            
            LoadCharacter.Show();
            
        }
    }
}
