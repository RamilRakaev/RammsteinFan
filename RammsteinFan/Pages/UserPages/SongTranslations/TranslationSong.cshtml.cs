using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;

namespace RammsteinFan.Pages.UserPages.SongTranslations
{
    public class TranslationSongModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public TranslationSongModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public string Title { set; get; }
        public List<string> Lyrics { get; set; }
        public List<string> SongTranslation { get; set; }
        public string SongDescription { get; set; }
        public void OnGet(string title)
        {
            Title = title;
            Lyrics = userdb.GetContentForTitle(title, "Lyrics").Text.Split("\n").ToList();
            SongTranslation = userdb.GetContentForTitle(title, "SongTranslation").Text.Split("\n").ToList();
            SongDescription = userdb.GetContentForTitle(title, "SongDescription").Text;
        }

        
    }
}
