using CommunityAPI.Interfaces.Repositories;
using CommunityAPI.Interfaces.Services;
using CommunityAPI.Models;

namespace CommunityAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;

        public CommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public async Task CreateAsync(Comment comment)
        {
            await _commentRepo.AddAsync(comment);
        }
    }
}
