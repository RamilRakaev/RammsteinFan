using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;

namespace RammsteinFan.Pages.UserPages
{
    public class DiscussionsMainModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public DiscussionsMainModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }
        
        public List<DiscussionSubject> DiscussionSubjects { get; set; } 

        public List<SubjectsListViewModel> SubjectsListViewModel { get; set; }
        public void OnGet()
        {
            DiscussionSubjects = userdb.GetAllDiscussionSubjects().ToList();
            Classification();
        }

        private void Classification()
        {
            SubjectsListViewModel = new List<SubjectsListViewModel>();
            IEnumerable<string> topHeadings = (from subject in DiscussionSubjects
                                        select subject.TopHeading).Distinct();
           
            foreach(string topHeading in topHeadings)
            {
                SubjectsListViewModel.Add(
                    new SubjectsListViewModel(
                        DiscussionSubjects.Where(d => d.TopHeading == topHeading).ToList()
                        )
                    );
            }
        }
    }
}
