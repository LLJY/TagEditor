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
        //if folder or fileis chosen
        private bool multipleChosen;
        private List<SongData> audioFiles;
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
                    //set the values of ui elements to element 0
                    await updateUI(true, 0);
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
                    string title = file.Tag.Title;
                    MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                    Image albumArt = Image.FromStream(ms);
                    SongData sd = new SongData(item, albumArt, album, artist, genre, title);
                    audioFiles[0] = sd;
                }
                else
                {
                    MessageBox.Show("Invalid file selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            updateUI(false, index);
        }

        private async void Confirm_Click(object sender, EventArgs e)
        {
            await applyAll();
            MessageBox.Show("Successfully applied!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ConfirmSingle_Click(object sender, EventArgs e)
        {

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
                    string title = file.Tag.Title;
                    Image albumArt = null;
                    try
                    {
                        MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                        albumArt = Image.FromStream(ms);
                    }
                    catch(Exception)
                    {
                        //no albumart found
                        throw;
                    }
                    SongData sd = new SongData(item, albumArt, album, artist, genre, title);
                    filteredFiles.Add(sd);
                }
            }
            return filteredFiles;
        }

        public async Task updateUI(bool updateCombo, int index)
        {
            artist.Text = audioFiles[index].Artist;
            albumArt.Image = audioFiles[index].AlbumArt;
            album.Text = audioFiles[index].Album;
            genre.Text = audioFiles[index].Genre;
            songTitle.Text = audioFiles[index].Title;
            if (updateCombo == true)
            {
                foreach (var item in audioFiles)
                {
                    comboBox1.Items.Add(item.Title);
                }
                comboBox1.SelectedItem = audioFiles[index].Title;
            }
        }
        private async Task applyAll()
        {
            progressBar1.Step = 1;
            //method to apply changes to all songs
            //since we are not stupid, we will only apply Artist, Genre and Album Art
            progressBar1.Maximum = audioFiles.Count;
            foreach (var item in audioFiles)
            {
                TagLib.File f = TagLib.File.Create(item.FileName);
                f.Tag.Album = album.Text;
                for (int i = 0; i < f.Tag.Artists.Length; i++)
                {
                    f.Tag.Artists[i] = artist.Text;
                }
                for (int i = 0; i < f.Tag.Genres.Length; i++)
                {
                    //set every genre to the genre.
                    f.Tag.Genres[i] = genre.Text;
                }
                MemoryStream ms = new MemoryStream();
                albumArt.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] myBytes = ms.ToArray();
                ByteVector byteVector = new ByteVector(myBytes, myBytes.Length);
                TagLib.Picture picture = new Picture(byteVector);
                TagLib.Id3v2.AttachedPictureFrame albumCoverPictFrame = new TagLib.Id3v2.AttachedPictureFrame(picture);
                albumCoverPictFrame.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
                albumCoverPictFrame.Type = TagLib.PictureType.FrontCover;
                IPicture converted = (IPicture)albumCoverPictFrame;
                for (int i = 0; i < f.Tag.Pictures.Length; i++)
                {
                    f.Tag.Pictures[i] = converted;
                }
                f.Save();
                progressBar1.PerformStep();
            }
        }

    }
}
