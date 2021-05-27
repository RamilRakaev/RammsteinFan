using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class DiscussionSubject : DiscussionMessage, IDiscussionSubject
    {
        public DiscussionSubject()
        {

        }

        public DiscussionSubject(string topHeading, string topic, string author, string text) :base(author, text)
        {
            TopHeading = topHeading;
            Topic = topic;
        }
        public string TopHeading { get; set; }
        public string Topic { get; set; }
    }
}
