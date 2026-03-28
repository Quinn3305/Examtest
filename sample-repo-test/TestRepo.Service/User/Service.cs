using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;

namespace TestRepo.Service.User;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> CreateUser(Request.CreateUserRequest request)
    {
        var existingCategoryQuery = _dbContext.Users
            .Where(x => x.Email == request.Email);
        var isExist = await existingCategoryQuery.AnyAsync();
        
        if(isExist) throw new Exception("User already exists");
    
        var user = new Repository.Entity.User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Password = request.Password,
            Role = "User",
        };
        _dbContext.Users.Add(user);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)  return  "Add User Successfully";
        
        return "Add User Failed" ;
    }
}