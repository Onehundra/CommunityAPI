using CommunityAPI.Data;
using CommunityAPI.Interfaces.Repositories;
using CommunityAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CommunityAPI.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task <User?> LoginAsync(string username, string password)
        {
            return await _db.Users.FirstOrDefaultAsync( u => u.Username == username && u.Password == password);
        }
    }
}
