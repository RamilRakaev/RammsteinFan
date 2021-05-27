using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RammsteinFan.Infrastructure.Mock
{
//    public class UserMock : IUserRepository<DiscussionSubject, Replica, Content, User, Role>
//    {
//        #region Авторизация и права пользователя
//        public Task<User> GetUserAsync(string emailAdress, string password)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<User> AccountByEmailAsync(string emailAdress)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Role> UserRights()
//        {
//            throw new NotImplementedException();
//        }

//        public Task AddUserAsync(User user)
//        {
//            throw new NotImplementedException();
//        }
//        #endregion

//        #region Добавить
//        public void AddReplica(string author, string Text, int discussionSubjectId, int replicaId = 0)
//        {
//            db.Replicas.Add(new Replica(author, Text, discussionSubjectId, replicaId) { Id = new Random().Next(1000) });
//            if(replicaId != 0)
//            {
//                GetDiscussionSubject(discussionSubjectId).Comments++;
//                GetReplica(replicaId).Comments++;
//            }
//            else
//            {
//                GetDiscussionSubject(discussionSubjectId).Comments++;
//            }
//        }

//        public void AddDiscussionSubject(string topHeading, string topic, string author, string text)
//        {
//            db.DiscussionSubjects.Add(new DiscussionSubject(topHeading, topic, author, text) { Id = new Random().Next(1000) });
//        }
//        #endregion

//        #region Вернуть данные из бд
//        public IEnumerable<DiscussionSubject> GetAllDiscussionSubjects() => db.DiscussionSubjects;

//        public DiscussionSubject GetDiscussionSubject(int id) => db.DiscussionSubjects.FirstOrDefault(ds => ds.Id == id);

//        public Replica GetReplica(int id) => db.Replicas.FirstOrDefault(ds => ds.Id == id);

//        public IEnumerable<Replica> GetReplicas(int id) => db.Replicas.Where(a => a.ReplicaId == id || a.DiscussionSubjectId == id).OrderByDescending(c => c.CreationDate);

//        public IEnumerable<Content> GetAllContent() => db.DbContent;

//        public Content GetContentForId(int id) => db.DbContent.FirstOrDefault(c => c.Id == id);

//        public IEnumerable<Content> GetContentForType(string type) => db.DbContent.Where(c => c.Type == type);

//        public IEnumerable<Content> GetContentForLocation(string location) => db.DbContent.Where(c => c.Location == location);

//        public Content GetContentForTitle(string title, string type) => db.DbContent.DefaultIfEmpty(new Content("","","","")).FirstOrDefault(c => c.Title == title & c.Type == type);

//        public Dictionary<string, int> AlbumRating()
//        {
//            throw new NotImplementedException();
//        }

//        public void SetFavoriteAlbum(string emailAdress, string titleAlbum)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
}
