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
        private void folder_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                //check if result is ok
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)){
                    files = Directory.GetFiles(fbd.SelectedPath);
                }
                else
                {
                    //if invalid, show dialog
                    MessageBox.Show("Invalid folder path selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task<List<string>> listFiles(string dir)
        {
            return null;
        }
        //if folder or fileis chosen
        private bool multipleChosen;
        private string[] files;
    }
}
