using CommunityAPI.Data;
using CommunityAPI.Interfaces.Repositories;
using CommunityAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CommunityAPI.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _db;

        public CategoryRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
