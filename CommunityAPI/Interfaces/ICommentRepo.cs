using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface ICommentRepo
    {
        Task AddAsync(Comment comment);
    }
}
