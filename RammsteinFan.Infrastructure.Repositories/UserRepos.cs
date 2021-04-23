using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class UserRepos:IUserRepos<Question,Answer,Content>
    {
        public UserRepos(DataContext context)
        {
            db = context;
        }
        readonly protected DataContext db;

        #region Добавить, удалить
        public void AddAnswer(string author, string Text, int questionId, int answerId=0)
        {
            db.Answers.Add(new Answer(author, Text, questionId, answerId));
            db.SaveChanges();
        }

        public void AddQuestion(string topHeading, string topic, string author, string text)
        {
            db.Questions.Add(new Question(topHeading, topic, author, text));
        }
        #endregion

        #region Вернуть данные из бд
        public IEnumerable<Question> GetAllQuestions() => db.Questions;

        public IEnumerable<Answer> GetAnswer(int id) => db.Answers.Where(a => a.AnswerId == id | a.QuestionId == id);

        public IEnumerable<Content> GetAllContent() => db.DbContent;

        public IEnumerable<Content> GetContent(string type, string location) => db.DbContent.Where(c => c.Type == type & c.Location == location);
        #endregion
    }
}
