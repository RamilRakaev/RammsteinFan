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
    public class EditContentModel : PageModel
    {
        readonly IAdminRepository<DiscussionSubject,Replica,Content> admindb;
        public EditContentModel(IAdminRepository<DiscussionSubject, Replica, Content> _admindb)
        {
            admindb = _admindb;
        }
        public void OnGet(int id)
        {
            OriginalContent = admindb.GetContentForId(id);
        }

        public ActionResult OnPost(Content newContent)
        {
            admindb.ReplaceContent(newContent.Id, newContent);
            return RedirectToPage("AdminPanel");
        }

        [BindProperty]
        public Content OriginalContent { get; set; }
    }
}
