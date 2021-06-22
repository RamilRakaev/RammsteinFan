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
        public TranslationSongModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb):base(_userdb)
        {}

        public string Title { set; get; }
        public List<string> Lyrics { get; set; }
        public List<string> SongTranslation { get; set; }
        public string SongDescription { get; set; }
        public void OnGet(string title)
        {
            Title = title;
            var lyrics = userdb.GetContentByTitle(title, "Lyrics");
            var songTranslation = userdb.GetContentByTitle(title, "SongTranslation");
            var songDescription = userdb.GetContentByTitle(title, "SongDescription");
            if(lyrics !=null && songTranslation!=null && songDescription != null)
            {
                Lyrics = lyrics.Text.Split("\n").ToList();
                
                SongTranslation = songTranslation.Text.Split("\n").ToList();

                for (int i = 0; i < Lyrics.Count(); i++)
                {
                    if (Lyrics[i] == "\r" && SongTranslation[i] == "\r")
                    {
                        SongTranslation[i] = "\n";
                        Lyrics[i] = "\n";
                    }
                }
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
