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
        public AlbumsMainModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}

        public void OnGet()
        {
            Albums = userdb.AlbumRating();
        }

        public Dictionary<string, int> Albums { get; set; }

        public void OnGetSetFavoriteAlbum(string title)
        {
            Albums = userdb.AlbumRating();
            if (User.Identity.IsAuthenticated)
            {
                userdb.SetFavoriteAlbum(User.Identity.Name, title);
                Albums = userdb.AlbumRating();
            }
        }
    }
}
