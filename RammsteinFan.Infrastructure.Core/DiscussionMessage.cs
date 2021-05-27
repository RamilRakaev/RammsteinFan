using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class DiscussionMessage : IDiscussionMessage
    {
        public DiscussionMessage()
        {

        }

        public DiscussionMessage(string author,string text)
        {
            CreationDate = DateTime.Now;
            Author = author;
            Text = text;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        [Column(TypeName= "datetime")]
        public DateTime CreationDate { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
        public int Views { get; set; }
    }
}
