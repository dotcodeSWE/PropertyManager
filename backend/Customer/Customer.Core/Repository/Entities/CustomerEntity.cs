using DotCode.RepositoryUtils.Entities;

namespace Customer.Core.Repository.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AreaId { get; set; }
        public Guid TeamId { get; set; }
    }
}
