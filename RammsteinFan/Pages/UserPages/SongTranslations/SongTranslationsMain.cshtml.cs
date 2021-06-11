using System.Collections.Generic;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;

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
                var titles = LineHandler.SplitSpaces(list.Text);
                Albums.Add(new ListSongsViewModel(list.Title, titles));
            }
        }
    }
}