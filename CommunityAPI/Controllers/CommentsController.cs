using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Models;
using CommunityAPI.DTOs;
using CommunityAPI.Services;
using System.Xml;
using Swashbuckle.AspNetCore.Annotations;
using CommunityAPI.Interfaces.Services;

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



        [SwaggerOperation(
            Summary = "Creates a comment",
            Description ="User can comment others blogpost but not their own blogpost")]
        [SwaggerResponse(200,"Creates comment")]
        [SwaggerResponse(400,"Wrong input details")]
        [SwaggerResponse(403,"You can't comment your own blogpost")]
        [SwaggerResponse(404,"Blogpost not found")]
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
                BlogPostId = dto.BlogPostId
            };
            await _commentService.CreateAsync(comment);
            return Ok(comment);
        }
    }
}
