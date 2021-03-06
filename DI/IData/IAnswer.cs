using System;
using System.Collections.Generic;
using System.Text;

namespace DI.IData
{
    public interface IAnswer
    {
        /// <summary>
        /// Идентификатор вопроса, к которому привязано сообщение
        /// </summary>
        int QuestionId { get; set; }

        /// <summary>
        /// Идентификатор ответа, к которому привязано сообщение
        /// </summary>
        int AnswerId { get; set; }
    }
}
