﻿using Chickeng.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chickeng.Infrastructure
{
    public class ChickengContext : DbContext
    {
        public DbSet<Vocabulary> Vocabularies { get; set; }

        public string DbPath { get; init; }
        public ChickengContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            DbPath = "Databases\\chickeng.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}