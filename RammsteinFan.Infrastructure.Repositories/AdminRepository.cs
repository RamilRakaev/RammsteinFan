using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System.Linq;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class AdminRepository :UserRepository, IAdminRepository<DiscussionSubject, Replica, Content, User, Role>
    {
        public AdminRepository(DataContext context):base(context)
        {}

        #region Добавить, удалить
        public void AddContent(string title, string type, string text, string location)
        {
            db.DbContent.Add(new Content(title, type, text, location));
            db.SaveChanges();
        }

        public void RemoveContent(int id)
        {
            var content = db.DbContent.Where(c => c.Id == id).FirstOrDefault();
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
            db.DiscussionSubjects.Remove(db.DiscussionSubjects.FirstOrDefault(c => c.Id == id));
            db.SaveChanges();
        }
        #endregion

        #region Редактировать определённые значения
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
