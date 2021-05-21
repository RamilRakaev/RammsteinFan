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
	public class AddNewSubjectModel : PageModel
	{

		readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
		public AddNewSubjectModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
		{
			userdb = _userdb;
		}

		public void OnGet()
		{

		}

		public void OnPost(string topHeading, string topic, string author,string text)
		{
			userdb.AddDiscussionSubject(topHeading, topic, author, text);
		}
	}
}
