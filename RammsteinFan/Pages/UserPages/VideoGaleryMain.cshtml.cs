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
    public class VideoGaleryMainModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public VideoGaleryMainModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public void OnGet()
        {
            Videos = userdb.GetContentForLocation("VideoGaleryMain").ToList();
        }

        public List<Content> Videos { get; set; }
    }
}
