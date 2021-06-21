using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.UserPages.Main
{
    public class ConcreteMemberModel : GeneralUserPageTemplate
    {
        public ConcreteMemberModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb) : base(_userdb)
        { }
        public Content Member { get; set; }

        public void OnGet(string member)
        {
            Member = userdb.GetContentByTitle(member, LineHandler.TypeMembers);
        }
    }
}
