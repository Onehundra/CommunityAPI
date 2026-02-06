using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface IBlogPostRepo
    {
        Task AddAsync(BlogPost post);
        Task <BlogPost?> GetByIdAsync(int id);
        Task UpdateAsync(BlogPost post);
        Task DeleteAsync(BlogPost post);
    }
}
