using TestRepo.Repository.Abtraction;

namespace TestRepo.Repository.Entity;

public class User: BaseEntity<Guid>, IAudictable
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Role { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public Seller? Seller { get; set; }
}