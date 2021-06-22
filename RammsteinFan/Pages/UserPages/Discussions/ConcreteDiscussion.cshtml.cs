using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.UserPages.Discussions
{
    public class ConcreteDiscussionModel : GeneralUserPageTemplate
    {
        public ConcreteDiscussionModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb):base(_userdb)
        {}

        public DiscussionSubject DiscussionSubject { get; set; }

        public List<Replica> Replicas { get; set; }
        public List<Replica> Comments { get; set; }

        public List<Replica> SetComments (int id)=> Comments = Replicas.Where(c => c.ReplicaId == id).ToList();

        public void OnGet(int id)
        {
            DiscussionSubject = userdb.GetDiscussionSubject(id);
            Replicas = userdb.GetReplicasBySubject(id).ToList();
        }

        public IActionResult OnPost(string author, string text, int id, int subjectId, int replicaId = 0)
        {
            userdb.AddReplica(author, text, subjectId, replicaId);
            var url = Url.Page("ConcreteDiscussion", new { id = id });
            return Redirect(url);
        }

        public void OnPostLike(int id, int idSubject)
        {
            if(User.Identity.IsAuthenticated)
            userdb.VoteReply(id);

            DiscussionSubject = userdb.GetDiscussionSubject(idSubject);
            Replicas = userdb.GetReplicasBySubject(idSubject).ToList();
        }

        public void OnPostLikeSubject(int id)
        {
            if(User.Identity.IsAuthenticated)
            userdb.VoteSubject(id);

            DiscussionSubject = userdb.GetDiscussionSubject(id);
            Replicas = userdb.GetReplicasBySubject(id).ToList();
        }
    }
}
