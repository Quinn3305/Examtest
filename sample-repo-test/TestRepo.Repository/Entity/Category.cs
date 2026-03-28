using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class Category: BaseEntity<Guid>, IAudictable
{
    public string Name { get; set; }
    
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}