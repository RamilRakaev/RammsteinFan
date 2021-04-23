using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class AdminRepos :UserRepos, IAdminRepos<Question,Answer,Content>
    {
        public AdminRepos(DataContext context):base(context)
        {}

        #region Добавить, удалить
        public void AddContent(string title, string type, string text, string location)
        {
            db.DbContent.Add(new Content(title,type,text,location));
            db.SaveChanges();
        }

        public void RemoveContent(int id)
        {
            db.DbContent.Remove(db.DbContent.Find(id));
            db.SaveChanges();
        }

        public void RemoveAnswer(int id)
        {
            db.Answers.Remove(db.Answers.Find(id));
            db.Answers.RemoveRange(db.Answers.Where(a =>a.AnswerId == id));
            db.SaveChanges();
        }

        public void RemoveQuestion(int id)
        {
            db.Questions.Remove(db.Questions.Find(id));
            db.Answers.RemoveRange(db.Answers.Where(a => a.QuestionId == id));
            db.SaveChanges();
        }
        #endregion

        #region Редактировать определённые значения
        public void EditTextContent(int id, string text)
        {
            db.DbContent.Find(id).Text = text;
            db.SaveChanges();
        }

        public void ChangeLocationContent(int id, string newLocation)
        {
            db.DbContent.Find(id).Location = newLocation;
            db.SaveChanges();
        }
        #endregion

    }
}
