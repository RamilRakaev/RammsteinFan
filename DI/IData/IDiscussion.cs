using System;
using System.Collections.Generic;
using System.Text;

namespace DI.IData
{
    public interface IDiscussion
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
        uint Likes { get; set; }

        /// <summary>
        /// Количество просмотров
        /// </summary>
        uint Views { get; set; }
    }
}
