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
    public class HistoryModel : GeneralUserPageTemplate
    {
        public HistoryModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role> _userdb) : base(_userdb)
        { }

        public List<Content> AllHistory { get; set; }
        public List<Content> History { get; set; }
        public int PageNumber { get; set; }

        public void OnGet(int pageNumber=1)
        {
            AllHistory = userdb.GetContentForType("HistoryText").ToList();
            PageNumber = pageNumber;
            
            var history = userdb.GetContentForLocation("History/" + PageNumber);
            if(history == null)
            {
                History = new List<Content>();
            }
            else
            {
                History = history.ToList();
            }
            
        }

        public List<string> SplitIntoParagraphs(string text)
        {
            if(text != null)
            {
                return text.Split("/n", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            return new List<string>();
        }
    }
}
