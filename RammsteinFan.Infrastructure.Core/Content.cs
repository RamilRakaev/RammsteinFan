using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Content : IContent
    {
        public Content(string title, string type, string text, string location)
        {
            Title = title;
            Type = type;
            Text = text;
            Location = location;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
    }
}
