using CommunityAPI.Models;

namespace CommunityAPI.Interfaces.Repositories
{
    public interface IBlogPostRepo
    {
        Task<List<BlogPost>> GetAllAsync();
        Task AddAsync(BlogPost post);
        Task <BlogPost?> GetByIdAsync(int id);
        Task UpdateAsync(BlogPost post);
        Task DeleteAsync(BlogPost post);
        Task<List<BlogPost>> SearchByTitleAsync(string title);
        Task<List<BlogPost>> SearchByCategoryAsync(string categoryName);
    }
}
