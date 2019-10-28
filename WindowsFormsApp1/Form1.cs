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
using TagLib;

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
            multipleChosen = true;
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
                    //set the values of the picture and textboxes to the first element
                    artist.Text = audioFiles[0].Artist;
                    albumArt.Image = audioFiles[0].AlbumArt;
                    album.Text = audioFiles[0].Album;
                    genre.Text = audioFiles[0].Genre;
                }
                else
                {
                    //if invalid, show dialog
                    MessageBox.Show("Invalid folder path selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void file_Click(object sender, EventArgs e)
        {
            multipleChosen = false;
            using(var ofd = new OpenFileDialog())
            {
                //start in the C: drive
                ofd.InitialDirectory = @"c:\";
                ofd.FilterIndex = 2;
                ofd.Filter = "mp3 files (*.mp3)|*.mp3|flac lossless music (*.flac)|*.flac";
                ofd.RestoreDirectory = true;
                DialogResult result = ofd.ShowDialog();
                if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    string item = ofd.FileName;
                    TagLib.File file = TagLib.File.Create(item);
                    //let's only support first genre for now...
                    string artist = file.Tag.FirstArtist;
                    string album = file.Tag.Album;
                    string genre = file.Tag.FirstGenre;
                    MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                    Image albumArt = Image.FromStream(ms);
                    SongData sd = new SongData(item, albumArt, album, artist, genre);
                    audioFiles[0] = sd;
                }
                else
                {
                    MessageBox.Show("Invalid file selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task<List<SongData>> listFiles(string[] files)
        {
            List<SongData> filteredFiles = new List<SongData>();
            foreach (var item in files)
            {
                //check if contains the audio files we support
                if (item.Contains(".flac") || item.Contains(".mp3:"))
                {
                    TagLib.File file = TagLib.File.Create(item);
                    //let's only support first genre for now...
                    string artist = file.Tag.FirstArtist;
                    string album = file.Tag.Album;
                    string genre = file.Tag.FirstGenre;
                    try
                    {
                        MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                        Image albumArt = Image.FromStream(ms);
                    }
                    catch
                    {
                        //no albumart found
                        Image albumArt = null;
                    }
                    SongData sd = new SongData(item, albumArt, album, artist, genre);
                    filteredFiles.Add(sd);
                }
            }
            return filteredFiles;
        }
        //if folder or fileis chosen
        private bool multipleChosen;
        private List<SongData> audioFiles;
    }
}
