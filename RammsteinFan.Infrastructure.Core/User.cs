using RammsteinFan.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace RammsteinFan.Infrastructure.Core
{
    public class User : IUser
    {
        public User()
        {
                
        }

        public User(string name, string email, byte age, string password, Role role)
        {
            Name = name;
            EmailAdress = email;
            Age = age;
            Password = password;
            Role = role;
            RoleId = role.Id;
        }

        public int Id { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public string Name { get; set ; }
        [Column(TypeName = "tinyint")]
        public byte Age { get; set; }

        public string Password { get; set; }
        public string EmailAdress { get; set; }


        public string FavoriteAlbum { get; set; } = "No favorite";
        public string FavoriteSong { get; set; } = "No favorite";
    }

}
