using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Content : IContent
    {
        public Content()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="type">Тип контента</param>
        /// <param name="location">Расположение контента</param>
        /// <param name="text">текст содержимого</param>
        /// <param name="canRemoved">Возможность удалять контент</param>
        public Content(string title, string type, string location, string text, bool canRemoved = true)
        {
            Title = title;
            Type = type;
            Location = location;
            Text = text;
            CanRemoved = canRemoved;
            CanChangeType = canRemoved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="type">Тип контента</param>
        /// <param name="location">Расположение контента</param>
        /// <param name="text">текст содержимого</param>
        /// <param name="canRemoved">Возможность удалять контент</param>
        /// <param name="canChangeType">Возможность изменять тип контента</param>
        public Content(string title, string type, string location, string text, bool canRemoved, bool canChangeType)
        {
            Title = title;
            Type = type;
            Location = location;
            Text = text;
            CanRemoved = canRemoved;
            CanChangeType = canChangeType;
        }

        public void ReplaceContent(Content newContent)
        {
            this.Title = newContent.Title;
            this.Text = newContent.Text;
            this.Location = newContent.Location;
            this.Type = newContent.Type;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public bool CanRemoved { get; set; }
        public bool CanChangeType { get; set; }
    }
}
