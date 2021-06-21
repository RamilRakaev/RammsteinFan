using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.UserPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan.Pages
{
    public class IndexModel : GeneralUserPageTemplate
    {
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb, ILogger<IndexModel> logger):base(_userdb)
        {
            
            _logger = logger;
        }

        static public bool AuthorizedUser { get; set; }
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
                AuthorizedUser = true;
            else
                AuthorizedUser = false;
        }

        public void OnPost(UserMessage message)
        {
            userdb.SendMessage(message);
        }
    }
}
