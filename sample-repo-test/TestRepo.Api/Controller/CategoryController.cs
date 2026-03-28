using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Category;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IService _categoryService;

    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CreateCategoryRequest request)
    {
        var category = await _categoryService.CreateCategory(request);
        return Ok(category);
    }
    [HttpGet("")]
    public async Task<OkObjectResult> GetCategory()
    {
        var category = await _categoryService.GetCategory();
        return Ok(category);
    }

    [HttpGet("{id}/parentId")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _categoryService.GetCategoryById(id);
        return Ok(category);
    }
}