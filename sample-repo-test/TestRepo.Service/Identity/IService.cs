namespace TestRepo.Service.Identity;

public interface IService
{
    Task<Response.IdentityResponse> Login(string email, string password); 
}