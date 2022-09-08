namespace Zestware.Domain.Entities;

public class Artist
{
    public Guid Id { get; set; }
    
    public string? Overview { get; set; }
    
    public DateOnly? Formed { get; set; }
    
    public string? Location { get; set; }
}