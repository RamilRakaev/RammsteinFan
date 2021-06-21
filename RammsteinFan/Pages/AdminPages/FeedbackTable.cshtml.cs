using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.AdminPages
{
    public class FeedbackTableModel : GeneralAdminPageTemplate
    {
        public FeedbackTableModel(IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _admindb) : base(_admindb)
        { }

        public List<UserMessage> Messages { get; set; }

        public void OnGet()
        {
            Messages = admindb.GetAllUserMessages().ToList();
        }

        public void OnGetRemove(int id)
        {
            admindb.RemoveUserMessage(id);
            Messages = admindb.GetAllUserMessages().ToList();
        }
    }
}
