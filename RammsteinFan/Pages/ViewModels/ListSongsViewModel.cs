using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan.Pages.ViewModels
{
    public class ListSongsViewModel
    {
        public ListSongsViewModel(string _AlbumTitle, List<string> _SongsList)
        {
            AlbumTitle = _AlbumTitle;
            SongsList = _SongsList;
        }

        public string AlbumTitle { get; set; }
        public List<string> SongsList { get; set; }
        
    }
}
//public ListSongsViewModel(string _AlbumTitle, List<string> songTranslation, List<string> songText)
//{
//    AlbumTitle = _AlbumTitle;
//    SongTranslation = songTranslation;
//    SongText = songText;
//}

//public string AlbumTitle { get; set; }
//public List<string> SongTranslation { get; set; }
//public List<string> SongText { get; set; }