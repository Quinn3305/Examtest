namespace TestRepo.Repository.Abtraction;

public interface IAudictable
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}