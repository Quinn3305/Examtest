namespace TestRepo.Repository.Abtraction;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public  bool isDeleted { get; set; }  
}