using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.User;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IService _categoryService;

    public UserController(IService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CreateUserRequest request)
    {
        var user = await _categoryService.CreateUser(request);
        return Ok(user);
    }
}