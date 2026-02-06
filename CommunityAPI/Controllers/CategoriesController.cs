using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Interfaces;
using CommunityAPI.Models;

namespace CommunityAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
      

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Category category)
        {
            await _categoryService.CreateAsync(category);
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(_categoryService.GetAllAsync());
        }
    }
}
