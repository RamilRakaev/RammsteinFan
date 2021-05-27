using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.UserPages
{
    public class ConcreteAlbumModel : GeneralUserPageTemplate
    {
        public ConcreteAlbumModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}

        public void OnGet(string title)
        {
            
            Album = userdb.GetContentForTitle(title, "AlbumDescription");
            if (Album != null)
            {
                Songs = LineHandler.SplitSpaces(userdb.GetContentForTitle(title, "AlbumTitles").Text);
            }
            else
            {
                Album = new Content("", "", "", "");
                Songs = new List<string>();
            }
        }

        public Content Album { get; set; }
        public List<string> Songs { get; set; }

    }
}
