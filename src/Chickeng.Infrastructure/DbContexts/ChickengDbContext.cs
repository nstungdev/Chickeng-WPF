using Chickeng.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure.DbContexts
{
    public class ChickengDbContext : DbContext
    {
        public ChickengDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\\MasterSpaces\\Projects\\chickeng\\db\\chickeng-dev.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
