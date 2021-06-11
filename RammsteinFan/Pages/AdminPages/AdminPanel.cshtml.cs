using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;

namespace RammsteinFan.Pages.AdminPages
{

    [Authorize]
    public class AdminPanelModel : GeneralAdminPageTemplate
    {
        public AdminPanelModel(IAdminRepository<DiscussionSubject, Replica, Content, User, Role> _admindb):base(_admindb)
        {
            Types = admindb.GetAllContent().Select(t => t.Type).Distinct().ToList();
        }

        public List<Content> Contents { get; set; }
        public List<string> Types { get; set; }
        public SelectList SelectType { get; set; }


        public void OnGet()
        {
            EstablishSelectContent();
        }
        public void OnPost(string type)
        {
            EstablishSelectContent(type);
        }

        /// <summary>
        /// Фильтровка выборки контента
        /// </summary>
        /// <param name="_type"></param>
        private void EstablishSelectContent(string _type = "AllContent")
        {
            if (_type == "AllContent")
                Contents = admindb.GetAllContent().ToList();
            else
                Contents = admindb.GetContentForType(_type).ToList();
            SelectType = new SelectList(Types, _type);
            TrimmingContentVariables();
        }

        /// <summary>
        /// Обрезка свойств контента
        /// </summary>
        private void TrimmingContentVariables()
        {
            foreach(var content in Contents)
            {
                content.Title = TrimmingString(content.Title);
                content.Text = TrimmingString(content.Text, 100);
                content.Location = TrimmingString(content.Location);
                content.Type = TrimmingString(content.Type);
            }
        }

        /// <summary>
        /// Обрезка одного свойства контента
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length">длина по умолчанию</param>
        /// <returns></returns>
        private string TrimmingString(string text, int length = 15)
        {
            if(text != null)
            if(text.Length > length)
            {
                return text.Substring(0, length) + "...";
            }
            return text;
        }
    }
}
