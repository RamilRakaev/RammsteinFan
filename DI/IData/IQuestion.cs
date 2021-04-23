using System;
using System.Collections.Generic;
using System.Text;

namespace DI.IData
{
    public interface IQuestion:IDiscussion
    {
        /// <summary>
        /// Верхний заголовок
        /// </summary>
        string TopHeading { get; set; }

        /// <summary>
        /// Тема сообщения
        /// </summary>
        string Topic { get; set; }
    }
}
