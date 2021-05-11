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
    public class ConcreteAlbumModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public ConcreteAlbumModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public void OnGet(string title)
        {
            Album = userdb.GetContentForTitle(title, "AlbumDescription");
            Songs = RammsteinFan.LineHandler.SplitSpaces(userdb.GetContentForTitle(title, "AlbumTitles").Text);
        }

        public Content Album { get; set; }
        public List<string> Songs { get; set; }

    }
}
