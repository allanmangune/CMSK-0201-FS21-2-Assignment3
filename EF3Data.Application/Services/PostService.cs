using Core.Interfaces;
using EF3Data.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Application.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<UserPostGroupDto>> GetPostsWithDetailsAsync()
        {
            var posts = await _postRepository.GetPostsWithDetailsAsync();
            var groupedPosts = posts
                .GroupBy(p => p.User)
                .OrderBy(g => g.Key.Name)
                .Select(g => new UserPostGroupDto
                {
                    UserName = g.Key.Name,
                    UserEmail = g.Key.EmailAddress,
                    PostCount = g.Count(),
                    Posts = g.Select(p => new PostDetailDto
                    {
                        BlogUrl = p.Blog.Url,
                        BlogIsPublic = p.Blog.IsPublic,
                        BlogTypeName = p.Blog.BlogType.Name,
                        PostTypeName = p.PostType.Name,
                        PostContent = p.Content
                    }).ToList()
                });

            return groupedPosts.ToList();
        }
    }
}
