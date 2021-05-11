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
    public class AlbumsMainModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public AlbumsMainModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public void OnGet()
        {
            Albums = userdb.GetContentForLocation("SongTranslationsMain&AlbumsMain").Select(c=>c.Title).ToList();
        }

        public List<string> Albums { get; set; }
    }
}
