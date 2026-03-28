namespace TestRepo.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.CreateCategoryRequest request);
    public Task<List<Response.GetCategory>> GetCategory();
    public Task<List<Response.GetCategoryById>> GetCategoryById(Guid id);
}