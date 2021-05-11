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
    public class PhotoGaleryModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject,Replica,Content> userdb;
        public PhotoGaleryModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public List<string> PhotoGalery { set; get; }

        public void OnGet()
        {
            PhotoGalery = LineHandler.SplitSpaces(userdb.GetContentForTitle("PhotoGalery", "PhotoGalery").Text).ToList();
        }
    }
}
