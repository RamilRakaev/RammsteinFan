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
    public class AlbumsMainModel : GeneralUserPageTemplate
    {
        public AlbumsMainModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb):base(_userdb)
        {}

        readonly private string location = "photoGalery/Albums";
        public void OnGet()
        {
            Albums = userdb.AlbumRating(location);
            Albums.Remove("Albums.jpg");
        }

        public Dictionary<string, int> Albums { get; set; }

        public void OnGetSetFavoriteAlbum(string title)
        {
            Albums = userdb.AlbumRating(location);
            Albums.Remove("Albums.jpg");
            if (User.Identity.IsAuthenticated)
            {
                userdb.SetFavoriteAlbum(User.Identity.Name, title);
                Albums = userdb.AlbumRating(location);
            }
        }

    }
}
