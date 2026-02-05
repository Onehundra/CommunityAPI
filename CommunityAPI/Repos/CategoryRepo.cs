using CommunityAPI.Data;
using CommunityAPI.Interfaces;
using CommunityAPI.Models;
namespace CommunityAPI.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _db;

        public CategoryRepo(AppDbContext db)
        {
            _db = db;
        }
        public void Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }
        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}
