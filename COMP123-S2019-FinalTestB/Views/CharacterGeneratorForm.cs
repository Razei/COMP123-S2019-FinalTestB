using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*
 * STUDENT NAME: Jarod Lavine
 * STUDENT ID: 301037634
 * DESCRIPTION: This is the Character Generator Form - the main form of the application
 */

namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        public List <string> FirstNameList;
        public List <string> LastNameList;
        public List<string> InventoryList;
        public Random randomString;
        public Random randomNumber;

        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }
        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            FirstNameList = new List<string>();
            LastNameList = new List<string>();
            InventoryList = new List<string>();
            randomString = new Random();
            randomNumber = new Random();
            LoadNames();
            GenerateNames();
            GenerateAbilities();
            LoadInventory();
        }

        /// <summary>
        /// This is the event handler for the BackButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        private void LoadNames()
        {
            var FirstNames = File.ReadAllLines("..\\..\\Data\\firstNames.txt");
            var LastNames = File.ReadAllLines("..\\..\\Data\\lastNames.txt");

            for (int i = 0; i < FirstNames.Length; i++)
            {
                FirstNameList.Add(FirstNames[i]);
            }

            for (int i = 0; i < LastNames.Length; i++)
            {
                LastNameList.Add(LastNames[i]);
            }

        }

        private void GenerateNames()
        {
            int index = randomString.Next(FirstNameList.Count);
            FirstNameDataLabel.Text = FirstNameList[index];

            index = randomString.Next(LastNameList.Count);
            LastNameDataLabel.Text = LastNameList[index];
        }



        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            GenerateNames();
            Program.character.FirstName = FirstNameDataLabel.Text;
            Program.character.LastName = LastNameDataLabel.Text;
        }

        private void GenerateAbilities()
        {
            int numInput = 0;

            numInput = randomNumber.Next(3, 18);
            StrengthDataLabel.Text = numInput.ToString();
            Program.character.Strength = StrengthDataLabel.Text;

            numInput = randomNumber.Next(3, 18);
            DexterityDataLabel.Text = numInput.ToString();
            Program.character.Dexterity = DexterityDataLabel.Text;

            numInput = randomNumber.Next(3, 18);
            ConstitutionDataLabel.Text = numInput.ToString();
            Program.character.Constitution = ConstitutionDataLabel.Text;

            numInput = randomNumber.Next(3, 18);
            IntelligenceDataLabel.Text = numInput.ToString();
            Program.character.Intelligence = IntelligenceDataLabel.Text;

            numInput = randomNumber.Next(3, 18);
            WisdomDataLabel.Text = numInput.ToString();
            Program.character.Wisdom = WisdomDataLabel.Text;

            numInput = randomNumber.Next(3, 18);
            CharismaDataLabel.Text = numInput.ToString();
            Program.character.Charisma = CharismaDataLabel.Text;
        }

        private void LoadInventory()
        {
            var inventory = File.ReadAllLines("..\\..\\Data\\inventory.txt");

            for (int i = 0; i < inventory.Length; i++)
            {
                InventoryList.Add(inventory[i]);
            }
        }

        public void GenerateRandomInventory()
        {
            int index = randomString.Next(InventoryList.Count);
            InventoryLabel1.Text = InventoryList[index];
            Program.character.Inventory.Add(InventoryLabel1.Text);

            index = randomString.Next(InventoryList.Count);
            InventoryLabel2.Text = InventoryList[index];
            Program.character.Inventory.Add(InventoryLabel2.Text);

            index = randomString.Next(InventoryList.Count);
            InventoryLabel3.Text = InventoryList[index];
            Program.character.Inventory.Add(InventoryLabel3.Text);

            index = randomString.Next(InventoryList.Count);
            InventoryLabel4.Text = InventoryList[index];
            Program.character.Inventory.Add(InventoryLabel4.Text);
        }

        private void GenerateInventoryButton_Click(object sender, EventArgs e)
        {
            GenerateRandomInventory();
        }

        private void MainTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 3)
            {
                NameCharLabel.Text = Program.character.FirstName + " " + Program.character.LastName;
                StrengthCharDataLabel.Text = Program.character.Strength;
                DexterityCharDataLabel.Text = Program.character.Dexterity;
                ConstitutionCharDataLabel.Text = Program.character.Constitution;
                IntelligenceCharDataLabel.Text = Program.character.Intelligence;
                WisdomCharDataLabel.Text = Program.character.Wisdom;
                CharismaCharDataLabel.Text = Program.character.Charisma;
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            // configure the file dialog
            CharacterSaveFileDialog.FileName = "Character.txt";
            CharacterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open file dialog - Modal Form
            var result = CharacterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                //open file to write
                using (StreamWriter outputStream = new StreamWriter(
                    File.Open(CharacterSaveFileDialog.FileName, FileMode.Create)))
                {
                    //write stuff to the file
                    outputStream.WriteLine(Program.character.FirstName);
                    outputStream.WriteLine(Program.character.Strength);
                    outputStream.WriteLine(Program.character.Dexterity);
                    outputStream.WriteLine(Program.character.Constitution);
                    outputStream.WriteLine(Program.character.Intelligence);
                    outputStream.WriteLine(Program.character.Wisdom);
                    outputStream.WriteLine(Program.character.Charisma);
                    outputStream.WriteLine(Program.character.Inventory[0]);
                    outputStream.WriteLine(Program.character.Inventory[1]);
                    outputStream.WriteLine(Program.character.Inventory[2]);
                    outputStream.WriteLine(Program.character.Inventory[3]);

                    //close the file
                    outputStream.Close();

                    //dispose of the memory
                    outputStream.Dispose();
                }

                MessageBox.Show("File Saved", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            // configure the file dialog
            CharacterSaveFileDialog.FileName = "Character.txt";
            CharacterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharacterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            //open file dialog - Modal Form
            var result = CharacterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                //open file to write
                using (StreamReader InputStream = new StreamReader(
                    File.Open(CharacterSaveFileDialog.FileName, FileMode.Create)))
                {
                    //write stuff to the file
                    Program.character.FirstName = InputStream.ReadLine();
                    (Program.character.Strength);outputStream.WriteLine
                    (Program.character.Dexterity);outputStream.WriteLine
                    (Program.character.Constitution)outputStream.WriteLine;
                    (Program.character.Intelligence)outputStream.WriteLine;
                    (Program.character.Wisdom);outputStream.WriteLine
                    (Program.character.Charisma);outputStream.WriteLine
                    (Program.character.Inventory[0])outputStream.WriteLine;
                    (Program.character.Inventory[1])outputStream.WriteLine;
                    (Program.character.Inventory[2])outputStream.WriteLine;
                    (Program.character.Inventory[3])outputStream.WriteLine;

                    //close the file
                    outputStream.Close();

                    //dispose of the memory
                    outputStream.Dispose();
                }

                MessageBox.Show("File Saved", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
