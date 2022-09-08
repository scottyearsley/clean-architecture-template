using Zestware.Domain.Entities;

namespace Zestware.Application.Common.Interfaces;

public interface IArtistRepository
{
    Task Add(Artist artist);

    Task<Artist?> Get(Guid id);
}