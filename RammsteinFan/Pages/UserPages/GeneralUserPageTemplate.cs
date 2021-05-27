using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.UserPages
{
    public class GeneralUserPageTemplate:PageModel
    {
        readonly protected IUserRepository<DiscussionSubject, Replica, Content, User, Role> userdb;
        public GeneralUserPageTemplate(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb)
        {
            userdb = _userdb;
        }
    }
}
