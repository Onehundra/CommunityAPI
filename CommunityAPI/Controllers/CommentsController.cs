using CommunityAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Models;
using CommunityAPI.DTOs;
using CommunityAPI.Services;
using System.Xml;

namespace CommunityAPI.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IBlogPostService _blogPostService;

        public CommentsController(ICommentService commentService, IBlogPostService blogPostService)
        {
            _commentService = commentService;
            _blogPostService = blogPostService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto dto)
        {
            var post = await _blogPostService.GetByIdAsync(dto.BlogPostId);

            if (post == null)
                return NotFound("Blog post not found");


            if (post.UserId == dto.UserId)
                return BadRequest("You cant comment your own post");

            var comment = new Comment
            {
                Text = dto.Text,
                UserId = dto.UserId,
                BlogPostId = dto.BlogPostId,
                CreatedAt = DateTime.UtcNow
            };
            await _commentService.CreateAsync(comment);
            return Ok(comment);
        }
    }
}
