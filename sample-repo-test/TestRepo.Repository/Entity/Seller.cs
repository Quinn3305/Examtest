using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class Seller: BaseEntity<Guid>, IAudictable
{
    public string TaxCode  { get; set; }
    public string CompanyName { get; set; }
    public  string CompanyAddress { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}