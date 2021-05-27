using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;

namespace CookieAuthentication.Pages.Account
{
    [AutoValidateAntiforgeryToken]
    public class RegisterAccountModel : Account
    {
        public RegisterModel Register { get; set; }

        public RegisterAccountModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb) : base(_userdb)
        {
            Register = new RegisterModel();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                User user = await userdb.AccountByEmailAsync(register.EmailAdress);
                if (user == null)
                {
                    Role userRole = await userdb.UserRights();
                    if (userRole != null)
                    {
                        user = new User(
                            register.Name, 
                            register.EmailAdress, 
                            register.Age, 
                            register.Password, 
                            userRole);

                        await userdb.AddUserAsync(user);
                        await AuthenticateAsync(user);

                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Этот email уже зарегестрирован");
                }
            }
            return Page();
        }
    }
}
