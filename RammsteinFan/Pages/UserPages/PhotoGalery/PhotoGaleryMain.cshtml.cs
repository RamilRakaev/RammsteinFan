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
        public PhotoGaleryModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {}

        public List<string> PhotoGalery { set; get; }

        public void OnGet()
        {
            var galery = userdb.GetContentForTitle("PhotoGalery", "PhotoGalery");
            PhotoGalery = LineHandler.SplitSpaces(galery.Text).ToList();
        }
    }
}
