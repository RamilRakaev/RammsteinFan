using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan.Pages.ViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel(Replica replica)
        {
            Message = replica;
            IsReplica = true;
        }

        public CommentViewModel(DiscussionSubject discussionSubject)
        {
            Message = discussionSubject;
            IsReplica = false;
        }

        public DiscussionMessage Message { get; set; }
        public bool IsReplica { get; set; }
    }
}
