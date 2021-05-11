using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class DiscussionMessage : IDiscussionMessage
    {
        public DiscussionMessage(string author,string text)
        {
            CreationDate = DateTime.Now;
            Author = author;
            Text = text;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public uint Likes { get; set; }
        public uint Comments { get; set; }
        public uint Views { get; set; }
    }
}
