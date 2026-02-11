using CommunityAPI.Models;

namespace CommunityAPI.Interfaces.Services
{
    public interface ICommentService
    {
        Task CreateAsync(Comment comment);
    }
}
