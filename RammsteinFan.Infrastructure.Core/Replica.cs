using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Replica : DiscussionMessage, IReplica
    {
        public Replica()
        {

        }

        public Replica(string author, string text, int discussionSubjectId, int replicaId=0) :base(author, text)
        {
            DiscussionSubjectId = discussionSubjectId;
            ReplicaId = replicaId;
            if (DiscussionSubjectId == 0 & ReplicaId == 0)
                throw new Exception("Ответ ни к чему не привязан");
        }
        public int DiscussionSubjectId { get; set; }
        public int ReplicaId { get; set; }
    }
}
