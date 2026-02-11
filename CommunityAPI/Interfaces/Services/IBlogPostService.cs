using CommunityAPI.Models;

namespace CommunityAPI.Interfaces.Services
{
    public interface IBlogPostService
    {
        Task<List<BlogPost>> GetAllAsync();
        Task CreateAsync(BlogPost post);
        Task<BlogPost?> GetByIdAsync(int id);
        Task UpdateAsync (BlogPost post);
        Task DeleteAsync(BlogPost post); 
        Task <List<BlogPost>> SearchByTitleAsync(string title);
        Task <List<BlogPost>> SearchByCategoryAsync(string categoryName);
    }
}
