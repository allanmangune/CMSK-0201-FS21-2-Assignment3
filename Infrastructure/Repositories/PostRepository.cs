using Core.Interfaces;
using EF3Data.Application.Dtos;
using EF3Data.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPostsWithDetailsAsync()
        {
            var posts = await _context.Posts
                .Include(p => p.Blog)
                    .ThenInclude(b => b.BlogType)
                .Include(p => p.PostType)
                .Include(p => p.User)
                .Where(p => !p.IsDeleted
                            && p.PostType.Status == Statuses.Active
                            && !p.Blog.IsDeleted
                            && p.Blog.BlogType.Status == Statuses.Active)
                .ToListAsync();

            return posts;
        }
    }
}
