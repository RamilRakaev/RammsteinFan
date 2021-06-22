using Microsoft.VisualStudio.TestTools.UnitTesting;
using RammsteinFan.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RammsteinFan.Domain.Repositories;
using RammsteinFan.Infrastructure.Core;
using System;

namespace UnitTestRammsteinFans
{
    [TestClass]
    public class RepositoryTest
    {

        IAdminRepository<DiscussionSubject, Replica, Content, User, Role, UserMessage> db;
        DataContext context;
        /// <summary>
        /// Настройка и загрузка бд
        /// </summary>
        void Start()
        {
            DbContextOptions<DataContext> options = 
                new DbContextOptionsBuilder<DataContext>().
                UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RammsteinFans;Trusted_Connection=True;").
                Options;
            context = new DataContext(options);
            this.db = new AdminRepository(context);

            
        }
        /// <summary>
        /// Закрытие соединения и освобождение ресурсов
        /// </summary>
        void Finish()
        {
            context.Database.CloseConnection();
            context.Dispose();
        }

        [TestMethod]
        public void ContentManagementTest()
        {
            Start();
            string title = "testContent";
            string type = "testText";
            string text = "this is the test";
            string location = "locationTestContent";
            string newTitle = "newTestContent";
            Content content = new Content(title, type, location, text);
            //Content management
            db.AddContent(content);

            var contentForLocation = db.GetContentByLocation(location).ElementAt(0);
            Assert.AreEqual(contentForLocation.Title, title);

            var contentForTitle = db.GetContentByTitle(title, type);
            Assert.AreEqual(contentForTitle.Text, text);

            var contentForType = db.GetContentByType(type).ElementAt(0);
            Assert.AreEqual(contentForType.Title, title);

            db.ReplaceContent(contentForTitle.Id, new Content(newTitle, type, location, text));
            Assert.AreEqual(db.GetContentById(contentForTitle.Id).Title, newTitle);

            Assert.AreEqual(db.GetContentByFirstLetter("newTes").ElementAt(0).Type, type);

            db.RemoveContent(newTitle, type);
            Assert.IsNull(db.GetContentById(contentForTitle.Id));

            db.AddContent(title, type, location, text);
            var nextContent = db.GetContentByTitle(title, type);
            Assert.AreEqual(nextContent.Text, text);

            db.RemoveContent(nextContent.Id);
            Assert.IsNull(db.GetContentById(nextContent.Id));
            Finish();
        }

        [TestMethod]
        public void DiscussionMessagesTest()
        {
            Start();
            //DisscussionSubjects
            string author = "Great Daniel Salazaros2";
            string textReplica = "This is a test";

            string topHeading = "top heading";
            string topic = "topic";
            string textSubject = "This is a test?";

            int countOfSubjects = db.GetAllDiscussionSubjects().Count();

            db.AddDiscussionSubject(topHeading, topic, author, textSubject);
            var discussion = db.GetDiscussionSubject(topic);
            Assert.IsNotNull(discussion);

            Assert.AreEqual(db.GetAllDiscussionSubjects().Count(), countOfSubjects + 1);

            Assert.AreEqual(db.GetDiscussionSubject(discussion.Id).Topic, topic);


            //Replicas
            db.AddReplica(author, textReplica, discussion.Id);
            Replica replica = db.GetReplicasByFirstLetter(textReplica).FirstOrDefault();
            Assert.AreEqual(replica.Author, author);

            Assert.AreEqual(db.GetDiscussionSubject(topic).Comments, 1);

            Assert.AreEqual(db.GetReplicasBySubject(discussion.Id).Count(), 1);

            db.RemoveReplica(replica.Id);
            Assert.AreEqual(db.GetReplicasBySubject(discussion.Topic).Count(), 0);

            db.RemoveSubject(discussion.Id);
            Assert.AreEqual(db.GetAllDiscussionSubjects().Count(), countOfSubjects);

            Finish();
        }

        [TestMethod]
        public void AuthorizationTest()
        {

        }
    }
}
