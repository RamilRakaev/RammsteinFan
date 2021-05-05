using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;

namespace RammsteinFan.Pages.UserPages
{
    public class DiscussionsMainModel : PageModel
    {
        public DiscussionsMainModel()
        {
            Classification();
        }
        public List<DiscussionSubject> GetDiscussionSubjects { get; set; } = new List<DiscussionSubject>()
        {
            new DiscussionSubject(
                "��������� ������",
                "��� ����� ������ ���� ��� ������?",
                "����",
                "� ����� ������� ����������� ������ �������� ������, � ������ ���� �������� ������� ����������."),
            new DiscussionSubject(
                "��������� ������",
                "�������",
                "����",
                "������ ������ ������� ������?")
        };

        public List<SubjectsListViewModel> SubjectsListViewModel { get; set; }
        public void OnGet()
        {
           
        }

        private void Classification()
        {
            SubjectsListViewModel = new List<SubjectsListViewModel>();
            IEnumerable<string> topHeadings = (from subject in GetDiscussionSubjects
                                        select subject.TopHeading).Distinct();
           
            foreach(string topHeading in topHeadings)
            {
                SubjectsListViewModel.Add(
                    new SubjectsListViewModel(
                        GetDiscussionSubjects.Where(d => d.TopHeading == topHeading).ToList()
                        )
                    );
            }
        }
    }
}
