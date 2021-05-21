using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IContent
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        string Title{get;set;}

        /// <summary>
        /// Тип контента
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Текст контента
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Расположение контента относительно друхих разделов контента
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Разрешение на удаление
        /// </summary>
        bool CanRemoved { get; set; }

        /// <summary>
        /// Разрешение на изменение типа
        /// </summary>
        bool CanChangeType { get; set; }
    }
}
