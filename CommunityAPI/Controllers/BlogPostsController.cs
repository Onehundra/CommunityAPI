using CommunityAPI.DTOs;
using CommunityAPI.Interfaces;
using CommunityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CommunityAPI.Controllers
{
    [ApiController]
    [Route("api/blogposts")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBlogPostDto dto)
        {
            var post = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow,
            };

            _blogPostService.Create(post);
            return Ok(post);

        }
    }
}
