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
        public AddContentModel(IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb) : base(_userdb)
        { }

        public List<string> Types { get; set; }
        public List<string> Locations { get; set; }

        public void OnGet()
        {
            Types = admindb.GetTypes().ToList();
            Types.Remove("image");
            Locations = admindb.GetLocations().ToList();
            for(int i =0; i< Locations.ToList().Count(); i++)
            {
                if(Locations[i].Contains('/'))
                Locations[i] = Locations[i].Substring(0, Locations[i].LastIndexOf('/'));
                if (Locations[i].StartsWith("photoGalery") || Locations[i].StartsWith("videoGalery"))
                    Locations.RemoveAt(i);
            }
            Locations.Distinct();
        }

        public IActionResult OnPost(Content newContent)
        {
            newContent.Location = newContent.Location + "/" + newContent.Title;
            admindb.AddContent(newContent);
            return RedirectToPage("AdminPanel");
        }
        
    }
}
