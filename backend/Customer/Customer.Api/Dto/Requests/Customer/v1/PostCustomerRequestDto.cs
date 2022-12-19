namespace Customer.Api.Dto.Requests.Customer.v1
{
    public class PostCustomerRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public Guid TeamId { get; set; }
    }
}