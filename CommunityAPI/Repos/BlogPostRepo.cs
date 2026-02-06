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
    }
}
