namespace Devsu.AccountManagement.Domain.Entities;

public class Account
{
    public long Id { get; set; } // PK
    public string AccountNumber { get; set; } 
    public string AccountType { get; set; } // Account Type (such SAVINGS, CHEKING, etc.)
    public decimal InitialBalance { get; set; }
    public bool IsActive { get; set; }

    // Copy relevant data from the account owner
    public long ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientAddress { get; set; }

    // Auditory Fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
