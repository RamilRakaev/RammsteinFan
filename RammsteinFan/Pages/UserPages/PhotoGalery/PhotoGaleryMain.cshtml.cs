using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan;

namespace RammsteinFan.Pages.UserPages
{
    public class PhotoGaleryModel : GeneralUserPageTemplate
    {
        public PhotoGaleryModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb):base(_userdb)
        {}

        public List<string> PhotoGalery { set; get; }

        public void OnGet()
        {
            var galery = userdb.GetContentByTitle("photoGalery", "albumsGalleries");
            if (galery != null)
                PhotoGalery = LineHandler.SplitSpaces(galery.Text).ToList();
            else
                PhotoGalery = new List<string>();
        }
    }
}
