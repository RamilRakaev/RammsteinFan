using System.ComponentModel.DataAnnotations;

namespace RammsteinFan.Pages.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Не указан возраст")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

    }
}
