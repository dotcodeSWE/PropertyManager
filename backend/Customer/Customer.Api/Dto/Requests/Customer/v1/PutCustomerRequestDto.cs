namespace Customer.Api.Dto.Requests.Customer.v1
{
    public class PutCustomerRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        Guid AreaId { get; set; }
        Guid TeamId { get; set; }
    }
}