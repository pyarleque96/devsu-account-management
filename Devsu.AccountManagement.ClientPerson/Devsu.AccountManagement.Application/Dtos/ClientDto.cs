namespace Devsu.AccountManagement.Application.Dtos;

public class ClientDto
{
    public long Id { get; set; }
    public int PersonId { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }

    // Auditory Fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Virstual Objects
    public PersonDto Person { get; set; }
}
