using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan.Pages.ViewModels
{
    public class TranslateViewModel
    {
        public TranslateViewModel()
        {
                
        }

        public TranslateViewModel(string title, string lyrics, string songTranslation, string songDescription, ref string album)
        {
            Title = title;
            Album = album;
            Lyrics = lyrics;
            SongTranslation = songTranslation;
            SongDescription = songDescription;
        }

        public string Title { get; set; }
        public string Album { get; set; }
        public string Lyrics { get; set; }
        public string SongTranslation { get; set; }
        public string SongDescription { get; set; }

    }
}
