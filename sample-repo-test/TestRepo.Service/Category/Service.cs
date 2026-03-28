using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;

namespace TestRepo.Service.Category;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> CreateCategory(Request.CreateCategoryRequest request)
    {
        var existingCategoryQuery = _dbContext.Categories
            .Where(x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim());
        var isExist = await existingCategoryQuery.AnyAsync();
        
        if(isExist) throw new Exception("Category already exists");
    
        var category = new Repository.Entity.Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ParentId = request.ParentId,
        };
        _dbContext.Categories.Add(category);
        var result = await _dbContext.SaveChangesAsync();
        if (result > 0)  return  "Add Category Successfully";
        
        return "Add Category Failed" ;
    }

    public async Task<List<Response.GetCategory>> GetCategory()
    {
        var query = _dbContext.Categories.Where(x => true);
        query = query.OrderBy(x=> x.Name);
        var selectedQuery = query.Select(x=> new Response.GetCategory()
        {
            Id = x.Id,
            Name = x.Name,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }

    public async Task<List<Response.GetCategoryById>> GetCategoryById(Guid id)
    {
        var query = _dbContext.Categories.Where(x => x.Id == id);
        query = query.OrderBy(x=> x.Name);
        var selectedQuery = query.Select(x=> new Response.GetCategoryById(id)
        {
            Id = x.Id,
            Name = x.Name,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }
}