using CommunityAPI.Models;

namespace CommunityAPI.Interfaces
{
    public interface ICategoryRepo
    {
        void Add (Category category);
        List<Category> GetAll();
    }
}
