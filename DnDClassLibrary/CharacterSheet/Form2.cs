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
            string testfile1 = @"C:\Users\rallo\Backup Character\BobInventory.json";
            string testfile2 = @"C:\Users\rallo\Backup Character\Bob.json";
            DnDDatabaseManagement ShitV2 = new DnDDatabaseManagement();
            string[] test2 = ShitV2.LoadCharacterInfo(testfile2);
            ShitV2.InventoryList = ShitV2.DatabaseList(testfile1);
            this.Hide();

            Sheet LoadCharacter = new Sheet(ShitV2.InventoryList,test2);
            
            LoadCharacter.Show();
            
        }
    }
}
