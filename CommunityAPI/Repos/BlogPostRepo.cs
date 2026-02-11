using CommunityAPI.Data;
using CommunityAPI.Models;
using CommunityAPI.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CommunityAPI.Repos
    
{

    public class BlogPostRepo : IBlogPostRepo
    {
        private readonly AppDbContext _db;


        public BlogPostRepo(AppDbContext db)
        { 
            _db = db;
        }
        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _db.BlogPosts.Include(c=>c.Category).ToListAsync();
        }
        public async Task AddAsync(BlogPost post)
        {
            await _db.BlogPosts.AddAsync(post);
            await _db.SaveChangesAsync();
        }
        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _db.BlogPosts.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task UpdateAsync(BlogPost post)
        {
            _db.BlogPosts.Update(post);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(BlogPost post)
        {
            _db.BlogPosts.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<List<BlogPost>> SearchByTitleAsync(string title)
        {
            return await _db.BlogPosts.Include(c=>c.Category).Where(p=> p.Title.Contains(title)).ToListAsync();
        }

        public async Task<List<BlogPost>> SearchByCategoryAsync(string categoryName)
        {
            return await _db.BlogPosts.Include(p=> p.Category).Where(p=>p.Category.Name.ToLower() == categoryName.ToLower()).ToListAsync();
        }
    }
}
