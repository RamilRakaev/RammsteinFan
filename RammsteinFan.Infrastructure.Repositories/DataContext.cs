using RammsteinFan.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace RammsteinFan.Infrastructure.Repositories
{
    public class DataContext:DbContext
    {
        public DataContext()
        {

        }
        public DbSet<Replica> Replicas;
        public DbSet<DiscussionSubject> DiscussionSubjects;
        public DbSet<Content> DbContent;
        public DbSet<User> Users;
    }
}
