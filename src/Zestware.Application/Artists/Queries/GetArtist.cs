using MediatR;
using Microsoft.Extensions.Logging;
using Zestware.Application.Common.Interfaces;
using Zestware.Domain.Entities;

namespace Zestware.Application.Artists.Queries;

public static class GetArtist
{
    public record Query(Guid Id) : IRequest<Artist?>;

    public class Handler : IRequestHandler<Query, Artist?>
    {
        private readonly IArtistRepository _repository;

        public Handler(IArtistRepository repository, ILogger<Handler> logger)
        {
            _repository = repository;
        }
        
        public Task<Artist?> Handle(Query request, CancellationToken cancellationToken)
        {
            return _repository.Get(request.Id);
        }
    }
}