using Zestware.Application.Common.Interfaces;
using Zestware.Domain.Entities;

namespace Zestware.Infrastructure.Repositories;

public class InMemoryAlbumRepository : IAlbumRepository
{
    private readonly Dictionary<Guid, Album> _repository = new();

    public Task Add(Album album)
    {
        _repository.Add(album.Id, album);
        return Task.CompletedTask;
    }

    public Task<Album?> Get(Guid id)
    {
        return _repository.ContainsKey(id) 
            ? Task.FromResult<Album?>(_repository[id]) 
            : Task.FromResult<Album?>(null);
    }
}