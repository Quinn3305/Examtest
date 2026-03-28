using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class Product: BaseEntity<Guid>, IAudictable
{
    public string Name { get; set; }
    public string Price { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}