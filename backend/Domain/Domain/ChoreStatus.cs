using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Domain;

public class ChoreStatus
{
    public Guid Id { get; set; }
    public string CustomerChoreId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletedDate { get; set; }
    public string DoneBy { get; set; }
}