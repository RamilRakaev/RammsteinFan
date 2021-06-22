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
    public class RemoveMessageModel : GeneralAdminPageTemplate
    {
        public RemoveMessageModel(IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _admindb):base(_admindb)
        { }

        /// <summary>
        /// Удалить тему обсуждений вместе со всеми реплиаками
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            admindb.RemoveSubject(id);
            return RedirectToPage("/UserPages/Discussions/DiscussionsMain");
        }

        /// <summary>
        /// Удалить реплику
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public IActionResult OnGetRemoveReplica(int id, int subjectId)
        {
            admindb.RemoveReplica(id);
            if(subjectId != 0)
                return RedirectToPage("/UserPages/Discussions/ConcreteDiscussion", new { id = subjectId });
            else
                return RedirectToPage("/UserPages/Discussions/DiscussionsMain");
        }
    }
}
