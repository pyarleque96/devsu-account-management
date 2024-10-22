namespace Devsu.AccountManagement.Domain.Entities;

public class Movement
{
    public long Id { get; set; } // PK
    public long AccountId { get; set; } // FK
    public DateTime Date { get; set; }
    public string MovementType { get; set; }
    public decimal Value { get; set; }
    public decimal Balance { get; set; }
    
    // Auditory Fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Virstual Objects
    public Account Account { get; set; }
}