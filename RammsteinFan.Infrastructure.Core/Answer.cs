﻿using RammsteinFan.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RammsteinFan.Infrastructure.Core
{
    public class Answer : DiscussionMessage, IAnswer
    {
        public Answer(string author, string text, int questionId=0, int answerId=0) :base(author, text)
        {
            QuestionId = questionId;
            AnswerId = answerId;
            if (QuestionId == 0 & AnswerId == 0)
                throw new Exception("Ответ ни к чему не привязан");
        }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
