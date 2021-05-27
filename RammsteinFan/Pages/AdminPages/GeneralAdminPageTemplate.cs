using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.AdminPages
{
    public class GeneralAdminPageTemplate: PageModel
    {
        readonly protected IAdminRepository<DiscussionSubject, Replica, Content, User, Role> admindb;
        public GeneralAdminPageTemplate(IAdminRepository<DiscussionSubject, Replica, Content, User, Role> _admindb)
        {
            admindb = _admindb;
        }
    }
}
