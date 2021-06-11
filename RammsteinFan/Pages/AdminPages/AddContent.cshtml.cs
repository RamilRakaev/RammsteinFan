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
    public class AddContentModel : GeneralAdminPageTemplate
    {
        public AddContentModel(IAdminRepository<DiscussionSubject, Replica, Content, User, Role> _userdb) : base(_userdb)
        {
            
        }

        public List<string> Types { get; set; }
        public List<string> Locations { get; set; }

        public void OnGet()
        {
            Types = admindb.GetTypes().ToList();
            Types.Remove("image");
            Locations = admindb.GetLocations().ToList();
            foreach(var loc in Locations.ToList())
            {
                if (loc.StartsWith("photoGalery") || loc.StartsWith("videoGalery"))
                    Locations.Remove(loc);
            }
        }

        public IActionResult OnPost(Content newContent)
        {
            admindb.AddContent(newContent);
            return RedirectToPage("AdminPanel");
        }
        
    }
}
