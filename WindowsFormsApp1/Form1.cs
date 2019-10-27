using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private async void folder_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                //check if result is ok
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)){
                    string[] allFiles = Directory.GetFiles(fbd.SelectedPath);
                    //async to not stall the application.
                    audioFiles = await listFiles(allFiles);
                    //check if list is empty, return error if it is empty
                    if (!audioFiles.Any())
                    {
                        //list is empty.
                        MessageBox.Show("No audio files found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //if invalid, show dialog
                    MessageBox.Show("Invalid folder path selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task<List<string>> listFiles(string[] files)
        {
            List<string> filteredFiles = new List<string>();
            foreach (var item in files)
            {
                //check if contains the audio files we support
                if (item.Contains(".flac") || item.Contains(".mp3:"))
                {
                    filteredFiles.Add(item);
                }
            }
            return filteredFiles;
        }
        //if folder or fileis chosen
        private bool multipleChosen;
        private List<string> audioFiles;
    }
}
