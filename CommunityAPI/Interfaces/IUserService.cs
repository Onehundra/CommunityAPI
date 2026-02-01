using CommunityAPI.Models;
//hej
namespace CommunityAPI.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
    }
}
