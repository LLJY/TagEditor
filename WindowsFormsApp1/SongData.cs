using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SongData
    {
        public string FileName { get; set; }
        public Image AlbumArt { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public SongData(string fileName, Image albumArt, string album, string artist, string genre, string title)
        {
            FileName = fileName;
            AlbumArt = albumArt;
            Album = album;
            Artist = artist;
            Genre = genre;
            Title = title;
        }
    }
}
