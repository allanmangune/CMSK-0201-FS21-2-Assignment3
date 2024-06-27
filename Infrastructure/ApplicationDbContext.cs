using EF3Data.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
            DbPath = "database.db";
        }

        public ApplicationDbContext()
        {
            DbPath = "database.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseLazyLoadingProxies();
            options.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostType> PostTypes { get; set; }

        public DbSet<User> Users { get; set; }

        public string DbPath { get; set; }
    }
}
