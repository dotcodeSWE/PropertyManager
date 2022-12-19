using DotCode.RepositoryUtils.Entities;

namespace Customer.Core.Repository.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AreaId { get; set; }
        public string TeamId { get; set; }
    }
}
