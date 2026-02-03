using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User? Login(string username, string password);
    }
}
