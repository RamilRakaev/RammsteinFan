using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RammsteinFan.Pages
{
    [Authorize (Roles="admin")]
    public class AdminIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public AdminIndexModel(ILogger<IndexModel> logger)
        {
            
            _logger = logger;
        }

        static public bool IsAdmin { get; set; }

        public void OnGet()
        {
            IsAdmin = true;
        }

    }
}
