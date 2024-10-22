namespace Devsu.AccountManagement.Application.Dtos;

public class MovementDto
{
    public long Id { get; set; } // PK
    public long AccountId { get; set; } // FK
    public string MovementType { get; set; }
    public decimal Value { get; set; }
    public decimal Balance { get; set; }

    // Auditory Fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Virstual Objects
    public AccountDto Account { get; set; }
}
