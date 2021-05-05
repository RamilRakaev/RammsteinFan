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
            QuestionId = questionId;
            ReplicaId = answerId;
            if (QuestionId == 0 & ReplicaId == 0)
                throw new Exception("Ответ ни к чему не привязан");
        }
        public int QuestionId { get; set; }
        public int ReplicaId { get; set; }
    }
}
