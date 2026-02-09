using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface ICommentService
    {
        Task CreateAsync(Comment comment);
    }
}
