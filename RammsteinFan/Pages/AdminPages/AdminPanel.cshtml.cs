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
    public class AdminPanelModel : PageModel
    {
        readonly private IAdminRepository<DiscussionSubject, Replica, Content> admindb;
        public AdminPanelModel(IAdminRepository<DiscussionSubject, Replica, Content> _admindb)
        {
            admindb = _admindb;
        }

        public List<Content> Contents { get; set; }
        public void OnGet()
        {
            Contents = admindb.GetAllContent().ToList();
            TrimmingContentVariables();
        }

        /// <summary>
        /// Обрезка свойств контента
        /// </summary>
        private void TrimmingContentVariables()
        {
            foreach(var content in Contents)
            {
                content.Title = TrimmingString(content.Title);
                content.Text = TrimmingString(content.Text, 100);
                content.Location = TrimmingString(content.Location);
                content.Type = TrimmingString(content.Type);
            }
        }

        private string TrimmingString(string text, int length = 15)
        {
            if(text.Length > length)
            {
                return text.Substring(0, length) + "...";
            }
            return text;
        }
    }
}
