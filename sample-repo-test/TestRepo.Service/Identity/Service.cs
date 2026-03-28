using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestRepo.Repository;
using TestRepo.Service.JwtService;

namespace TestRepo.Service.Identity;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _jwtService;
    private readonly JwtOptions _jwtOptions = new();

    public Service(AppDbContext dbContext,IConfiguration configuration, JwtService.IService jwtService)
    {
        _dbContext = dbContext;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOptions);
        _jwtService = jwtService;
    }

    public async Task<Response.IdentityResponse> Login(string email, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x=> x.Email == email);
        if (user == null) throw new Exception("User not found");
        if (user.Password != password) throw new Exception("Invalidate Password");
        var claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim("Role", user.Role),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Expired, DateTimeOffset.UtcNow.AddMinutes(_jwtOptions.ExpireMinutes).ToString())
        };
        var token = _jwtService.GenerateAccessToken(claims);
        var result = new Response.IdentityResponse()
        {
            AccessToken =  token,
        };
        return result;
    }
}