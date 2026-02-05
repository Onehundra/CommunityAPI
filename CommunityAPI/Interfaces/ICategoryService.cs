using CommunityAPI.Models;
namespace CommunityAPI.Interfaces
{
    public interface ICategoryService
    {
        void Create(Category category);
        List<Category> GetAll();
    }
}
