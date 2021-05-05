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
