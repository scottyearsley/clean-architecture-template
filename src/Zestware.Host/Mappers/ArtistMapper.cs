using Zestware.Domain.Entities;

namespace Zestware.Host.Mappers;

public class ArtistMapper
{
    public Dtos.Artist MapToDto(Artist artist)
    {
        return new Dtos.Artist
        {
            Id = artist.Id,
            Name = artist.Name,
            Overview = artist.Overview,
            Formed = artist.Formed.ToString("O"),
            Location = artist.Location
        };
    }
}