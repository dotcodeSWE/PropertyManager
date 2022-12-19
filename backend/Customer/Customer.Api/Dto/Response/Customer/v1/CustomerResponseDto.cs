namespace Customer.Api.Dto.Response.Customer.v1
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public Guid TeamId { get; set; }
    }
}