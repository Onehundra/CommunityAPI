using CommunityAPI.Data;
using CommunityAPI.Interfaces;
using CommunityAPI.Models;

namespace CommunityAPI.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext db)
        {
            _db = db;
        }
        public void AddUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }
    }
}
