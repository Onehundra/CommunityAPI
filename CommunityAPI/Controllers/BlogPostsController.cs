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
        private readonly ICategoryService _categoryService;

        public BlogPostsController(IBlogPostService blogPostService, 
            ICategoryService categoryService)
        {
            _blogPostService = blogPostService;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogPostDto dto)
        {
            if(!await _categoryService.ExistsAsync(dto.CategoryId))
                return BadRequest($"Category with Id: {dto.CategoryId} does not exist");



            var post = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = dto.UserId,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.UtcNow,
            };

            await _blogPostService.CreateAsync(post);
            return Ok(post);

        }

    }
}
