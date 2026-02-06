using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task <List<User>> GetAllUsersAsync();
        Task <User?> GetUserByIdAsync(int id);
        Task <User?> LoginAsync(string username, string password);
    }
}
