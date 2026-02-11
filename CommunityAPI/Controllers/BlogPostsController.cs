using CommunityAPI.DTOs;
using CommunityAPI.Interfaces;
using CommunityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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



        [SwaggerOperation(
            Summary = "Creates new blogpost", 
            Description = "Creates blogpost connected to user and category")]
        [SwaggerResponse(200, "Blogpost created")]
        [SwaggerResponse(400, "Wrong inputs")]
        [SwaggerResponse(404, "User or category not found")]
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



        [SwaggerOperation(
            Summary = "Updates a blogpost",
            Description = "Only the owner of the post can update the blogpost")]
        [SwaggerResponse(200,"The post was updated")]
        [SwaggerResponse(403,"You are not the owner of the post")]
        [SwaggerResponse(404,"Post not found")]
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

        [SwaggerOperation(
            Summary = "Deletes post",
            Description = "Only the owner of the post can delete it")]
        [SwaggerResponse(204,"Post deleted")]
        [SwaggerResponse(403,"You are not the owner")]
        [SwaggerResponse(404,"Post not found")]
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


        [HttpGet("search/category/{categoryName}")]
        public async Task<IActionResult> SearchByCategory(string categoryName)
        {
            var posts = await _blogPostService.SearchByCategoryAsync(categoryName);
            return Ok(posts);
        }


    }
}
