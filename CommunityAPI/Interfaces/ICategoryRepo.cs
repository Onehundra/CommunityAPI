using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface ICategoryRepo
    {
        Task AddAsync (Category category);
        Task <List<Category>> GetAllAsync();
        Task <bool> ExistsAsync(int id);
    }
}
