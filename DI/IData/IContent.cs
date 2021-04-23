using System;
using System.Collections.Generic;
using System.Text;

namespace IData.DI
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
        /// Расположение контента
        /// </summary>
        string Location { get; set; }

    }
}
