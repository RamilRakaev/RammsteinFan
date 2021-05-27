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
    public class TranslationSongModel : GeneralUserPageTemplate
    {
        public TranslationSongModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}

        public string Title { set; get; }
        public List<string> Lyrics { get; set; }
        public List<string> SongTranslation { get; set; }
        public string SongDescription { get; set; }
        public void OnGet(string title)
        {
            Title = title;
            var lyrics = userdb.GetContentForTitle(title, "Lyrics");
            var songTranslation = userdb.GetContentForTitle(title, "SongTranslation");
            var songDescription = userdb.GetContentForTitle(title, "SongDescription");
            if(lyrics !=null && songTranslation!=null && songDescription != null)
            {
                Lyrics = lyrics.Text.Split("\n").ToList();
                SongTranslation = songTranslation.Text.Split("\n").ToList();
                SongDescription = songDescription.Text;
            }
            else
            {
                Lyrics = new List<string>();
                SongTranslation = new List<string>();
                SongDescription = "";
            }
        }

        
    }
}
