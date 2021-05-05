using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RammsteinFan.Infrastructure.Mock;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using RammsteinFan.Pages.ViewModels;

namespace RammsteinFan.Pages.UserPages.SongTranslations
{
    public class SongTranslationsMainModel : PageModel
    {
        readonly private IUserRepository<DiscussionSubject, Replica, Content> userdb;
        public SongTranslationsMainModel(IUserRepository<DiscussionSubject, Replica, Content> _userdb)
        {
            userdb = _userdb;
        }

        public List<ListSongsViewModel> Albums { get; set; }
        public List<string> Songs { get; set; }
        public List<string> SongTranslations { get; set; }

        public void OnGet()
        {
            Albums = new List<ListSongsViewModel>();
            foreach(var list in userdb.GetContentForType("AlbumWithSongs"))
            {
                Albums.Add(new ListSongsViewModel(list.Title, SplitSpaces(list.Text).Split(',').ToList()));
            }
        }

        /// <summary>
        /// Удаляет пробелы после запятых
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        private string SplitSpaces(string inputText)
        {
            var text = inputText;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == ' ' & text[i - 1] == ',')
                {
                    text=text.Remove(i,1);
                }
            }
            return text;
        }
    }
}
