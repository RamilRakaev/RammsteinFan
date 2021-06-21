using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IUserMessage
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string EmailAdress { get; set; }


        /// <summary>
        /// Формат изображения
        /// </summary>
        public string TextMessage { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime SendingDate { get; set; }
    }
}
