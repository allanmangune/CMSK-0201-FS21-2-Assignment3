using Core.Interfaces;
using EF3Data.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Infrastructure
{
    public class DataSeeder : IDataSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        public DataSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SeedDataAsync()
        {
            try
            {
                var name = "mangunea@mymacewan.ca";
                var dataCreator = new DataCreator(name);
                var container = dataCreator.GetData();
                var users = _dbContext.Users.ToList();
                if (users.Count() == 0)
                {
                    _dbContext.Users.AddRange(container.Users);
                    _dbContext.PostTypes.AddRange(container.PostTypes);
                    _dbContext.BlogTypes.AddRange(container.BlogTypes);
                    _dbContext.Blogs.AddRange(container.Blogs);
                    _dbContext.Posts.AddRange(container.Posts);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
