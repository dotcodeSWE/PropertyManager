using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Repository.Entities;

public class ChoreComment : BaseEntity 
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string CustomerChoreId { get; set; }
    public string UserId { get; set; }
}