using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RammsteinFan.Pages.UserPages
{
    public class AlbumsMainModel : PageModel
    {
        public readonly string chapter = "Альбомы";
        public void OnGet()
        {
        }
    }
}
