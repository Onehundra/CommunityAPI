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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _blogPostService.GetAllAsync();
            return Ok(posts);
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
                CategoryId = dto.CategoryId
                
            };

            await _blogPostService.CreateAsync(post);
            return Ok(post);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBlogPostDto dto)
        {
            var post = await _blogPostService.GetByIdAsync(id);

            if (post == null) 
                return NotFound();


            if (post.UserId != dto.UserId) 
                return Forbid();

            post.Title = dto.Title;
            post.Content = dto.Content;

            await _blogPostService.UpdateAsync(post);
            return Ok(post);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id, [FromBody] int userId)
        {
            var post = await _blogPostService.GetByIdAsync(id);

            if(post == null)
                return NotFound();

            if (post.UserId != userId)
                return Forbid();

            await _blogPostService.DeleteAsync(post);
            return NoContent();
        }

        [HttpGet("search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
            var posts = await _blogPostService.SearchByTitleAsync(title);
            return Ok(posts);
        }


        [HttpGet("search/category/{categoryId}")]
        public async Task<IActionResult> SearchByCategory(int categoryId)
        {
            var posts = await _blogPostService.SearchByCategoryAsync(categoryId);
            return Ok(posts);
        }


    }
}
