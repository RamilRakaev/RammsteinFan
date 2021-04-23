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
        public DbSet<Answer> Answers;
        public DbSet<Question> Questions;
        public DbSet<Content> DbContent;
    }
}
