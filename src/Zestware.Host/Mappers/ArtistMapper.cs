using Zestware.Domain.Entities;

namespace Zestware.Host.Mappers;

public class ArtistMapper
{
    public Dtos.Artist MapToDto(Artist artist)
    {
        return new Dtos.Artist
        {
            Id = artist.Id,
            Overview = artist.Overview,
            Formed = artist.Formed,
            Location = artist.Location
        };
    }
}