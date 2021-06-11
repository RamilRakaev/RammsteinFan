using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RammsteinFan.Pages.ViewModels;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace CookieAuthentication.Pages.Account
{
    [ValidateAntiForgeryToken]
    public class LoginAccountModel : Account
    {
        public LoginAccountModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb):base(_userdb)
        {
            Login = new LoginModel();
        }

        public void OnGet()
        {
            
        }

        public LoginModel Login { get; set; }

        
        public async Task<IActionResult> OnPost(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                User user = await userdb.GetUserAsync(login.EmailAdress, login.Password);
                if (user != null)
                {
                    await AuthenticateAsync(user); // аутентификация

                    if(User.Identity.Name == "user")
                        return RedirectToPage("/Index");
                    else if(user.Role.Name == "admin")
                        return RedirectToPage("/AdminIndex");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return Page();
        }
    }
}
