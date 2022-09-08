namespace Zestware.Domain.Entities;

public class Artist
{
    public Artist(string name, string overview, DateOnly formed, string location)
    {
        Id = Guid.NewGuid();
        Name = name;
        Overview = overview;
        Formed = formed;
        Location = location;
    }
    
    public Guid Id { get; }
    
    public string Name { get; }
    
    public string Overview { get; }
    
    public DateOnly Formed { get; }
    
    public string Location { get; }
}