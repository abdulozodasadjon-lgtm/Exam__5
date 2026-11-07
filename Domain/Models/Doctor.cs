namespace Domain.Models;

public class Doctor
{
    public int Id {get; set; }
    public string FullName {get; set; } = null!;
    public string Speciality {get; set; } = null!;
    public bool IsActive {get; set; } = true;
    public DateTime HireDate {get; set; } 
}
