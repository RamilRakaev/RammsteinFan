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
    public class SongTranslationsMainModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public SongTranslationsMainModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public List<ListSongsViewModel> Albums { get; set; }

        public void OnGet()
        {
            Albums = new List<ListSongsViewModel>();
            foreach (var list in userdb.GetContentForLocation("AlbumTitles"))
            {
                var titles = RammsteinFan.LineHandler.SplitSpaces(list.Text);
                Albums.Add(new ListSongsViewModel(list.Title, titles));
            }
        }

      
    }
}
