using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Content : IContent
    {
        public Content(string title, string type, string location, string text)
        {
            Title = title;
            Type = type;
            Location = location;
            Text = text;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
    }
}
