using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IUser
    {
        int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Возраст пользователя
        /// </summary>
        byte Age { get; set; }

        /// <summary>
        /// Пароль для входа
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        string EmailAdress { get; set; }

        /// <summary>
        /// статус пользователя
        /// </summary>
        string Status { get; set; }
    }
    
}
