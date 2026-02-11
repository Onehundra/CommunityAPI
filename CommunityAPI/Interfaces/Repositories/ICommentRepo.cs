using CommunityAPI.Models;

namespace CommunityAPI.Interfaces.Repositories
{
    public interface ICommentRepo
    {
        Task AddAsync(Comment comment);
    }
}
