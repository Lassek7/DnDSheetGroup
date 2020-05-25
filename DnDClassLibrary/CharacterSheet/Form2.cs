using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDClassLibrary;

namespace CharacterSheet
{
    public partial class Form2 : Form
    {
        #region CONSTRUCTOR
        public Form2()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#D2D6D7");
        }
        #endregion

        #region METHODS
        /*Methoderne Button1_click & Button2_Click kørere forskellige klasses alt ud efter om brugeren
         * skal lave en ny character eller skal load en allerede eksisterende character
         * button1_Click Methode:
         * Når brugeren trykker på knappen laver den en ny instans af klassen CreateCharacterForm 
         * og viser det til brugeren
         * button2_Click methode:
         * Når brugeren trykker på laver den en ny instans af Sheet 
         * med de følgende parameter fra methoderne InventoryList og LoadCharacterInfo
         * InventoryList returnere en List af klassen Item
         * LoadCharacterInfo returnere et array 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateCharacterForm RunCreateCharacter = new CreateCharacterForm();
            RunCreateCharacter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sheet LoadCharacter = new Sheet(InventoryList(), LoadCharacterInfo());
            LoadCharacter.Show();  
        }
        
        /* Methoden LoadCharacterInfo
         * Laver en ny instans af DndDatabaseManagement klassen
         * Samt kalder methoden på objectet OpenFileDialog fra klassen System.Windows.Forms og laver en ny instans af dialogen
         * Derefter assigner methoden hvor henne dialog vinduet skal åbne samt hvilken file type den skal åbne som er (.Json)
         * hvor brugeren vælger den angivet Json file som indholder værdierne alle de forskellige Items, Weapon og Armor 
         * som der var gemt i filen 
         * samt kalder LoadCharacterInfo methoden LoadCharacterInfo fra klassen DndDatabasemangement og assigner det til
         * string array i formen
         * Methoden returner et string array 
        */
        string[] LoadCharacterInfo()
        {
            DnDDatabaseManagement DatabaseDialog = new DnDDatabaseManagement();
            var filePathCharacterInfo = string.Empty;
            
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
            string[] CharacterInfoFromJsonFile = DatabaseDialog.LoadCharacterInfo(filePathCharacterInfo);
            return CharacterInfoFromJsonFile;
        }
        /* Methoden InventoryList:
         * Laver en ny instans af DndDatabaseManagement klassen
         * Samt kalder methoden på objectet OpenFileDialog fra klassen System.Windows.Forms og laver en ny instans af dialogen
         * Derefter assigner methoden hvor henne dialog vinduet skal åbne samt hvilken file type den skal åbne som er (.Json)
         * Efter brugeren har trykket på button2_click methoden åbner et dialog vindue,
         * hvor brugeren vælger den angivet Json file som indholder værdierne alle de forskellige Items, Weapon og Armor 
         * som der var gemt i filen 
         * samt kalder  Inventorylist methoden DatabaseList fra klassen DndDatabasemangement og assigner det til listen i klassen
         * Methoden returner en liste 
        */
        List<Item> InventoryList()
        {
            DnDDatabaseManagement DatabaseDialog = new DnDDatabaseManagement();
            var filePathCharacterInventoryInfo = string.Empty;
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

            DatabaseDialog.InventoryList = DatabaseDialog.DatabaseList(filePathCharacterInventoryInfo);
            return DatabaseDialog.InventoryList;
        }
        #endregion
    }
}
