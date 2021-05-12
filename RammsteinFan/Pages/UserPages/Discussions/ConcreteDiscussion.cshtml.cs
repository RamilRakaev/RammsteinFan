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
    public class ConcreteDiscussionModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public ConcreteDiscussionModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public DiscussionSubject DiscussionSubject { get; set; }

        public List<Replica> Replicas { get; set; }
        public List<Replica> Comments { get; set; }

        public List<Replica> SetComments (int id)=> Comments = Replicas.Where(c => c.ReplicaId == id).ToList();
        public void OnGet(int id)
        {
            DiscussionSubject = userdb.GetDiscussionSubject(id);
            Replicas = userdb.GetReplicas(id).ToList();
        }

        public IActionResult OnPost(string author, string text, int id, int subjectId, int replicaId = 0)
        {
            userdb.AddReplica(author, text, subjectId, replicaId);
            var url = Url.Page("ConcreteDiscussion", new { id = id });
            return Redirect(url);
        }
    }
}
