using CommunityAPI.Models;

namespace CommunityAPI.Interfaces

{
    public interface IUserRepo
    {
        void AddUser(User user);
        List<User> GetAllUsers();
    }
}
