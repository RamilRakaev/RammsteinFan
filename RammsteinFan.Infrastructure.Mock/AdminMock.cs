using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RammsteinFan.Infrastructure.Mock
{
    public class AdminMock:UserMock,IAdminRepository<DiscussionSubject, Replica, Content>
    {

        #region Добавить, удалить
        public void AddContent(string title, string type, string text, string location)
        {
            db.DbContent.Add(new Content(title, type, text, location));
        }

        public void RemoveContent(int id)
        {
            db.DbContent.Remove(db.DbContent.Where(c=>c.Id== id).FirstOrDefault());
        }

        public void RemoveReplica(int id)
        {
            db.Replicas.Remove(db.Replicas.Where(c => c.Id == id).FirstOrDefault());
            db.Replicas = db.Replicas.Where(a => a.QuestionId != id).ToList();
        }

        public void RemoveSubject(int id)
        {
            db.DiscussionSubjects.Remove(db.DiscussionSubjects.Where(c => c.Id == id).FirstOrDefault());
            db.Replicas=db.Replicas.Where(a => a.QuestionId != id).ToList();
        }
        #endregion

        #region Редактировать определённые значения
        public void EditTextContent(int id, string text)
        {
            db.DbContent.Where(c => c.Id == id).DefaultIfEmpty(new Content("","","","")).First().Text = text;
        }

        public void ChangeLocationContent(int id, string newLocation)
        {
            db.DbContent.Where(c => c.Id == id).FirstOrDefault().Location = newLocation;
        }
        #endregion

    }
}
