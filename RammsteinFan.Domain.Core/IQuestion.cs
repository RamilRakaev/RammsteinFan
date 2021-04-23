using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IQuestion:IDiscussionMessage
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
