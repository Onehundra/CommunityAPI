using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using CommunityAPI.Interfaces.Services;

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


        [SwaggerOperation(
            Summary = "Creates a new category",
            Description ="Adds a new category that blogposts can connect to")]
        [SwaggerResponse(200,"Category created")]
        [SwaggerResponse(400,"Wrong input details")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Category category)
        {
            await _categoryService.CreateAsync(category);
            return Ok(category);
        }



        [SwaggerOperation(
            Summary ="Gets all categories",
            Description ="Returns a list with all categories")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
    }
}
