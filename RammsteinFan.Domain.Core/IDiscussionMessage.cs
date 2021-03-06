using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IDiscussionMessage
    {
        int Id { get; set; }
        /// <summary>
        /// Автор сообщения
        /// </summary>
        string Author { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Дата публикации
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Количество голосов
        /// </summary>
        int Likes { get; set; }

        /// <summary>
        /// Количество голосов
        /// </summary>
        int Comments { get; set; }

        /// <summary>
        /// Количество просмотров
        /// </summary>
        int Views { get; set; }
    }
}
