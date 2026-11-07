namespace Domain.Models;

public class Patient
{
    public int Id {get; set; }
    public string FullName {get; set; } = null!;
    public string Phone {get; set; } = null!;
    public DateOnly BirthDate {get; set; }
    public bool IsActive {get; set; } = true;
    public DateTime CreatedAt {get; set; } = DateTime.Now;
}
