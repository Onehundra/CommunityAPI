using CommunityAPI.Data;
using CommunityAPI.Interfaces.Repositories;
using CommunityAPI.Models;

namespace CommunityAPI.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly AppDbContext _db;
        public CommentRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();
        }
    }
}
