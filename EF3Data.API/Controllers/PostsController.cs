using EF3Data.Application.Dtos;
using EF3Data.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF3Data.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPostGroupDto>>> GetPosts()
        {
            var posts = await _postService.GetPostsWithDetailsAsync();
            return Ok(posts);
        }
    }
}
