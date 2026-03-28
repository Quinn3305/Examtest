namespace TestRepo.Service.Category;

public class Response
{
    public class GetCategory
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
    public class GetCategoryById(Guid ParentId)
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }

}