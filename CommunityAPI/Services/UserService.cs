using CommunityAPI.Interfaces;
using CommunityAPI.Models;

namespace CommunityAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public void CreateUser(User user)
        {
            _userRepo.AddUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User? GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }
        public User? Login(string username, string password)
        {
            return _userRepo.Login(username, password);
        }

    }
}
