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
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if(content != null && content.CanRemoved)
            db.DbContent.Remove(content);
        }

        public void RemoveReplica(int id)
        {
            db.Replicas.Remove(db.Replicas.Where(c => c.Id == id).FirstOrDefault());
            db.Replicas = db.Replicas.Where(a => a.DiscussionSubjectId != id).ToList();
        }

        public void RemoveSubject(int id)
        {
            db.DiscussionSubjects.Remove(db.DiscussionSubjects.Where(c => c.Id == id).FirstOrDefault());
            db.Replicas=db.Replicas.Where(a => a.DiscussionSubjectId != id).ToList();
        }
        #endregion

        #region Редактировать определённые значения
        public void ReplaceContent(int id, Content newContent)
        {
            foreach(Content content in db.DbContent)
            {
                if (content.Id == id)
                    content.ReplaceContent(newContent);
            }
        }

        public void ChangeTitleContent(int id, string newTitle)
        {
            db.DbContent.Where(c => c.Id == id).DefaultIfEmpty(new Content("","","","")).First().Title = newTitle;
        }

        public void EditTextContent(int id, string text)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if(content != null)
                content.Text = text;
        }

        public void ChangeLocationContent(int id, string newLocation)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if (content != null)
                content.Location = newLocation;
        }

        public void ChangeTypeContent(int id, string newType)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if(content != null && content.CanChangeType)
            content.Type = newType;
        }
        #endregion

        #region Авторизация
        public bool PermissionEnter(string name, string password)
        {
            if(db.Users.Where(u=>u.Name == name && u.Password == password).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public string ErrorAuthorizationMessage(string name, string password)
        {
            string message = "";
            if(db.Users.Where(u=>u.Name == name).Count() == 0)
            {
                message += "это имя не зарегестрировано ";
            }
            if(db.Users.Where(u=>u.Name == name).Count() == 0)
            {
                message += "такого пароля не существует";
            }
            return message;
        }
        #endregion
    }
}
