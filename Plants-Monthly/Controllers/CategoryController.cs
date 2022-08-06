using Microsoft.AspNetCore.Mvc;
using Plants_Monthly.BLL.Interfaces;
using Plants_Monthly.DTO;

namespace Plants_Monthly.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryBLL _categoryBLL;

        public CategoryController(ILogger<CategoryController> logger, ICategoryBLL categoryBLL)
        {
            _logger = logger;
            _categoryBLL = categoryBLL;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> Get()
        {
            List<CategoryDTO> categoriesDTO = await _categoryBLL.GetCategoriesAsync();
            return Ok(categoriesDTO);
        }
    }
}