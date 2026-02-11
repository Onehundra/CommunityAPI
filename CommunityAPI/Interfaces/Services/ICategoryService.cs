using CommunityAPI.Models;
namespace CommunityAPI.Interfaces.Services
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task <List<Category>> GetAllAsync();
        Task <bool> ExistsAsync(int id);
    }
}
