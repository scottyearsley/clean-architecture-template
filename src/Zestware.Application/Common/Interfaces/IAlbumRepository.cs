using Zestware.Domain.Entities;

namespace Zestware.Application.Common.Interfaces;

public interface IAlbumRepository
{
    Task Add(Album album);

    Task<Album?> Get(Guid id);
}