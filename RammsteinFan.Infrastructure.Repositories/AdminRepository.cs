using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class AdminRepository :UserRepository, IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage>
    {
        public AdminRepository(DataContext context):base(context)
        {}

        #region Добавить, удалить
        public void RemoveUser(int id) => db.Users.Remove(db.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id && u.Role == UserRights()));

        public void AddContent(string title, string type, string location, string text)
        {
            db.DbContent.Add(new Content(title, type, location, text));
            db.SaveChanges();
        }

        public void AddContent(Content newContent)
        {
            db.DbContent.Add(newContent);
            db.SaveChanges();
        }

        public void RemoveContent(int id)
        {
            var content = db.DbContent.FirstOrDefault(c => c.Id == id);
            if (content != null && content.CanRemoved) 
            { 
                db.DbContent.Remove(content);
                db.SaveChanges();
            }
        }

        public void RemoveContent(string title, string type)
        {
            var content = GetContentByTitle(title, type);
            if (content != null && content.CanRemoved)
            {
                db.DbContent.Remove(content);
                db.SaveChanges();
            }
        }

        public void RemoveReplica(int id)
        {
            db.Replicas.Remove(db.Replicas.FirstOrDefault(c => c.Id == id));
            db.SaveChanges();
        }

        public void RemoveSubject(int id)
        {
            var replicas = GetReplicasBySubject(id);
            foreach (var message in replicas)
            {
                db.Replicas.Remove(message);
            }
            db.DiscussionSubjects.Remove(db.DiscussionSubjects.FirstOrDefault(c => c.Id == id));
            db.SaveChanges();
        }

        public void RemoveUserMessage(int id) 
        {
            db.UserMessages.Remove(db.UserMessages.FirstOrDefault(m => m.Id == id));
            db.SaveChanges();
        }
        #endregion

        #region Редактирование
        public void ReplaceContent(int id, Content newContent)
        {
            foreach (Content content in db.DbContent)
            {
                if (content.Id == id) 
                { 
                    content.Title = newContent.Title;
                    content.Text = newContent.Text;
                    content.Location = newContent.Location;
                    content.Type = newContent.Type;
                    break;
                }
            }
            db.SaveChanges();
        }

        public void ChangeTitleContent(int id, string newTitle)
        {
            db.DbContent.DefaultIfEmpty(new Content("", "", "", "")).FirstOrDefault(c => c.Id == id).Title = newTitle;
            db.SaveChanges();
        }

        public void EditTextContent(int id, string text)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if (content != null)
            {
                content.Text = text;
                db.SaveChanges();
            }
        }

        public void ChangeLocationContent(int id, string newLocation)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if (content != null)
            {
                content.Location = newLocation;
                db.SaveChanges();
            }
        }

        public void ChangeTypeContent(int id, string newType)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
            if (content != null && content.CanChangeType)
            {
                content.Type = newType;
                db.SaveChanges();
            }
        }
        #endregion

        #region Вернуть данные
        public IEnumerable<string> GetTypes() => GetAllContent().Select(c => c.Type).Where(t => t != null).Distinct();

        public IEnumerable<string> GetLocations() => GetAllContent().Select(c => c.Location).Where(l => l!=null).Distinct();

        public IEnumerable<UserMessage> GetAllUserMessages() => db.UserMessages;
        #endregion

        #region Авторизация
        public bool PermissionEnter(string name, string password)
        {
            if (db.Users.Where(u => u.Name == name && u.Password == password).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public string ErrorAuthorizationMessage(string name, string password)
        {
            string message = "";
            if (db.Users.Where(u => u.Name == name).Count() == 0)
            {
                message += "это имя не зарегестрировано ";
            }
            if (db.Users.Where(u => u.Name == name).Count() == 0)
            {
                message += "такого пароля не существует";
            }
            return message;
        }
        #endregion

    }
}
