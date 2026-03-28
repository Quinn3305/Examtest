namespace TestRepo.Service.Seller;

public class Request
{
    public class CreateUserRequest
    {
        public string tax_code { get; set; }
        public string companyName { get; set; }
    }
}