using CommunityAPI.Interfaces;
using CommunityAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CommunityAPI.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepo _blogPostRepo;

        public BlogPostService(IBlogPostRepo blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public async Task CreateAsync(BlogPost post)
        {
            await _blogPostRepo.AddAsync(post);
        }
        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _blogPostRepo.GetByIdAsync(id);
        }
        public async Task UpdateAsync (BlogPost post)
        {
            await _blogPostRepo.UpdateAsync(post);
        }
        public async Task DeleteAsync (BlogPost post)
        {
            await _blogPostRepo.DeleteAsync(post);
        }
    }
}
