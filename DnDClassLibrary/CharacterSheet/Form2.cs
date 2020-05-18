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
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCharacterForm RunCreateCharacter = new CreateCharacterForm();
            DnDDatabaseManagement ShitV2 = new DnDDatabaseManagement();
         //   ShitV2.BasicStarterItem();
            RunCreateCharacter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DnDDatabaseManagement ShitV2 = new DnDDatabaseManagement();
            var filePathCharacterInfo = string.Empty;
            var filePathCharacterInventoryInfo = string.Empty;
            MessageBox.Show("Choose your character file");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "json files (*.json)|*.json";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FileName = openFileDialog.Title;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathCharacterInfo = openFileDialog.FileName;
            }
            }
            string[] test2 = ShitV2.LoadCharacterInfo(filePathCharacterInfo);
            MessageBox.Show("Choose your Inventory file");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "json files (*.json)|*.json";
                
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathCharacterInventoryInfo = openFileDialog.FileName;
                }
            }
            
            ShitV2.InventoryList = ShitV2.DatabaseList(filePathCharacterInventoryInfo);


            this.Hide();

            Sheet LoadCharacter = new Sheet(ShitV2.InventoryList,test2);
            
            LoadCharacter.Show();  
        }
    }
}
