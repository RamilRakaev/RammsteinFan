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
        public HistoryModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb) : base(_userdb)
        { }

        public List<Content> AllHistory { get; set; }
        public Content History { get; set; }
        public int PageNumber { get; set; }

        public void OnGet(int pageNumber=1)
        {
            AllHistory = userdb.GetContentByType("HistoryText").ToList();
            if (pageNumber >= AllHistory.Count)
                PageNumber = 1;
            else if (pageNumber <= 0)
                PageNumber = AllHistory.Count() - 1;
            else
                PageNumber = pageNumber;
            
            var history = userdb.GetContentByLocation("History/" + PageNumber).FirstOrDefault();
            if(history == null)
            {
                History = new Content("", "", "", "");
            }
            else
            {
                History = history;
            }
            
        }

        public List<string> SplitIntoParagraphs(string text)
        {
            if(text != null)
            {
                return text.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            return new List<string>();
        }
    }
}
