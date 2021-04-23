using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Question : DiscussionMessage, IQuestion
    {
        public Question(string topHeading, string topic, string author, string text) :base(author, text)
        {
            TopHeading = topHeading;
            Topic = topic;
        }
        public string TopHeading { get; set; }
        public string Topic { get; set; }
    }
}
