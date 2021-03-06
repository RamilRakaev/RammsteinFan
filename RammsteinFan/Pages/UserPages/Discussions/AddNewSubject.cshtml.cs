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
	public class AddNewSubjectModel : GeneralUserPageTemplate
	{
		public AddNewSubjectModel(IUserRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> _userdb):base(_userdb)
		{}

		public void OnGet()
		{

		}

		public IActionResult OnPost(string topHeading, string topic, string author,string text)
		{
			userdb.AddDiscussionSubject(topHeading, topic, author, text);
			return RedirectToPage("/UserPages/Discussions/DiscussionsMain");
		}
	}
}
