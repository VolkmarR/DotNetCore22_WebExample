using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuestionsApp.Web.DB
{
    public class QuestionsContext : DbContext
    {
        public QuestionsContext(DbContextOptions options) : base(options)
        { }

        public DbSet<QuestionDB> Questions { get; set; }
        public DbSet<VoteDB> Votes { get; set; }
    }
}
