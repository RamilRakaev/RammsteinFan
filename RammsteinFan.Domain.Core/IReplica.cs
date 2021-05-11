using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Domain.Core
{
    public interface IReplica
    {
        /// <summary>
        /// Идентификатор вопроса, к которому привязано сообщение
        /// </summary>
        int DiscussionSubjectId { get; set; }

        /// <summary>
        /// Идентификатор ответа, к которому привязано сообщение
        /// </summary>
        int ReplicaId { get; set; }
    }
}
