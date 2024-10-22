namespace Devsu.AccountManagement.Application.Dtos;

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Gender { get; set; }
    public int Age { get; set; }
    public string Identification { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }

    // Auditory Fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
