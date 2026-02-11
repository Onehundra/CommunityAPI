using CommunityAPI.Interfaces.Repositories;
using CommunityAPI.Interfaces.Services;
using CommunityAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CommunityAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task CreateAsync(Category category)
        {
            await _categoryRepo.AddAsync(category);
        }

        public async Task <bool> ExistsAsync(int id)
        {
            return await _categoryRepo.ExistsAsync(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }

    }
}
