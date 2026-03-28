using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Identity;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    private readonly IService _IdentityService;

    public IdentityController(IService identityService)
    {
        _IdentityService = identityService;
    }

    [HttpGet("identity")]
    public async Task<Response.IdentityResponse> Login(string email, string password)
    {
        var identity = await _IdentityService.Login(email, password);
        return identity;
        
    }
}