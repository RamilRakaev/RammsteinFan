using System.ComponentModel.DataAnnotations.Schema;

namespace RammsteinFan.Domain.Core
{
    public interface IUser
    {
        int Id { get; set; }

        public int? RoleId { get; set; }

        #region Данные пользователя
        /// <summary>
        /// Имя пользователя
        /// </summary>
        string Name { get; set; }

        
        /// <summary>
        /// Возраст пользователя
        /// </summary>
        byte Age { get; set; }
        #endregion

        #region Данные для аутентификации
        /// <summary>
        /// Пароль для входа
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        string EmailAdress { get; set; }
        #endregion

        #region Статистика
        /// <summary>
        /// Любимый альбом пользователя
        /// </summary>
        string FavoriteAlbum { get; set; }

        /// <summary>
        /// Любимая песня пользователя
        /// </summary>
        string FavoriteSong { get; set; }
        #endregion

    }
    
}
