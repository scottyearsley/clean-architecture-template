using Zestware.Application.Common.Interfaces;
using Zestware.Domain.Entities;

namespace Zestware.Infrastructure.Repositories;

public class InMemoryArtistRepository : IArtistRepository
{
    private readonly Dictionary<Guid, Artist> _repository = new();
    
    public Task Add(Artist artist)
    {
        _repository.Add(artist.Id, artist);
        return Task.CompletedTask;
    }

    public Task<Artist?> Get(Guid id)
    {
        return _repository.ContainsKey(id) 
            ? Task.FromResult<Artist?>(_repository[id]) 
            : Task.FromResult<Artist?>(null);
    }
}