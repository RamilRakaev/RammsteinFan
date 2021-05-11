using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Replica : DiscussionMessage, IReplica
    {
        public Replica(string author, string text, int questionId=0, int answerId=0) :base(author, text)
        {
            DiscussionSubjectId = questionId;
            ReplicaId = answerId;
            if (DiscussionSubjectId == 0 & ReplicaId == 0)
                throw new Exception("Ответ ни к чему не привязан");
        }
        public int DiscussionSubjectId { get; set; }
        public int ReplicaId { get; set; }
    }
}
