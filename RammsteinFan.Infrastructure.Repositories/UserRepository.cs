﻿using RammsteinFan.Domain.Repositories;
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
        public void AddAnswer(string author, string Text, int questionId, int answerId=0)
        {
            db.Replicas.Add(new Replica(author, Text, questionId, answerId));
            db.SaveChanges();
        }

        public void AddQuestion(string topHeading, string topic, string author, string text)
        {
            db.DiscussionSubjects.Add(new DiscussionSubject(topHeading, topic, author, text));
            db.SaveChanges();
        }
        #endregion

        #region Вернуть данные из бд
        public IEnumerable<DiscussionSubject> GetAllDiscussionSubjects() => db.DiscussionSubjects;

        public DiscussionSubject GetDiscussionSubject(int id) => db.DiscussionSubjects.Find(id);

        public IEnumerable<Replica> GetReplicas(int id) => db.Replicas.Where(a => a.ReplicaId == id || a.DiscussionSubjectId == id).OrderBy(c=>c.CreationDate);

        public IEnumerable<Content> GetAllContent() => db.DbContent;

        public IEnumerable<Content> GetContentForType(string type) => db.DbContent.Where(c => c.Type == type);

        public IEnumerable<Content> GetContentForLocation(string location) => db.DbContent.Where(c => c.Location == location);

        public Content GetContentForTitle(string title, string type) => db.DbContent.Where(c => c.Title == title & c.Type == type).FirstOrDefault();
        #endregion
    }
}