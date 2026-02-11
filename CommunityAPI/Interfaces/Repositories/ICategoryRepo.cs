using CommunityAPI.Models;

namespace CommunityAPI.Interfaces.Repositories
{
    public interface ICategoryRepo
    {
        Task AddAsync (Category category);
        Task <List<Category>> GetAllAsync();
        Task <bool> ExistsAsync(int id);
    }
}
