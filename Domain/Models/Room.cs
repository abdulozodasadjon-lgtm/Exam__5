namespace Domain.Models;

public class Room
{
    public int Id {get; set; }
    public string Name {get; set; } = null!;
    public bool IsActive {get; set; } = true;
}
