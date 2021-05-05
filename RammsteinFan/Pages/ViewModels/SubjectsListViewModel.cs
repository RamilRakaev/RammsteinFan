using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RammsteinFan.Pages.ViewModels
{
    public class SubjectsListViewModel
    {
        public SubjectsListViewModel(List<DiscussionSubject>questionsList)
        {
            GetDiscussionSubjects= questionsList;
        }
        public string TopHeading { 
            get {
                if (GetDiscussionSubjects != null & GetDiscussionSubjects.Count > 0)
                    return GetDiscussionSubjects[0].TopHeading;
                else
                    return "";
            } 
        }
        public List<DiscussionSubject> GetDiscussionSubjects { get; set; }
        
    }
}
