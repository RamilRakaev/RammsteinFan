using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository<DiscussionSubject,Replica,Content>
    {
        public UserRepository(DataContext context)
        {
            db = context;
        }
        readonly protected DataContext db;

        #region Добавить
        public void AddReplica(string author, string Text, int discussionSubjectId, int replicaId =0)
        {
            db.Replicas.Add(new Replica(author, Text, discussionSubjectId, replicaId));
            if (replicaId != 0)
            {
                GetDiscussionSubject(discussionSubjectId).Comments++;
                GetReplica(replicaId).Comments++;
            }
            else
            {
                GetDiscussionSubject(discussionSubjectId).Comments++;
            }
            db.SaveChanges();
        }

        public void AddDiscussionSubject(string topHeading, string topic, string author, string text)
        {
            db.DiscussionSubjects.Add(new DiscussionSubject(topHeading, topic, author, text));
            db.SaveChanges();
        }
        #endregion

        #region Вернуть данные из бд
        public IEnumerable<DiscussionSubject> GetAllDiscussionSubjects() => db.DiscussionSubjects;

        public DiscussionSubject GetDiscussionSubject(int id) => db.DiscussionSubjects.Find(id);

        public Replica GetReplica(int id) => db.Replicas.Where(ds => ds.Id == id).FirstOrDefault();

        public IEnumerable<Replica> GetReplicas(int id) => db.Replicas.Where(a => a.ReplicaId == id || a.DiscussionSubjectId == id).OrderBy(c=>c.CreationDate);

        public IEnumerable<Content> GetAllContent() => db.DbContent;

        public IEnumerable<Content> GetContentForType(string type) => db.DbContent.Where(c => c.Type == type);

        public IEnumerable<Content> GetContentForLocation(string location) => db.DbContent.Where(c => c.Location == location);

        public Content GetContentForTitle(string title, string type) => db.DbContent.Where(c => c.Title == title & c.Type == type).FirstOrDefault();
        #endregion
    }
}
