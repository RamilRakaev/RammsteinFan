using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;
using RammsteinFan;

namespace RammsteinFan.Pages.UserPages.SongTranslations
{
    public class SongTranslationsMainModel : GeneralUserPageTemplate
    {
        public SongTranslationsMainModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}

        public List<ListSongsViewModel> Albums { get; set; }

        public void OnGet()
        {
            Albums = new List<ListSongsViewModel>();
            foreach (var list in userdb.GetContentForType("AlbumTitles"))
            {
                var titles = RammsteinFan.LineHandler.SplitSpaces(list.Text);
                Albums.Add(new ListSongsViewModel(list.Title, titles));
            }
        }

      
    }
}
//Albums = new List<ListSongsViewModel>();
//var songList = userdb.GetContentForType("SongTranslation");
//foreach (var song in songList)
//{
//    if (Albums.Where(a => a.AlbumTitle == song.Title) == null)
//    {
//        Albums.Add(
//            songList.FirstOrDefault(s => s.Type == "SongTranslation")

//            songList.FirstOrDefault(s => s.Type == "SongText"))
//                }
//    var titles = LineHandler.SplitSpaces(song.Text);
//    Albums.Add(new ListSongsViewModel(song.Title, titles));
//}