using MediatR;
using Zestware.Application.Common.Interfaces;
using Zestware.Domain.Entities;

namespace Zestware.Application.Artists.Commands;

public static class CreateArtist
{
    public record Command(string? Name, string? Overview, string FormedDate, string? Location) : IRequest<Artist>;
    
    public class Handler : IRequestHandler<Command, Artist>
    {
        private readonly IArtistRepository _repository;

        public Handler(IArtistRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Artist> Handle(Command request, CancellationToken cancellationToken)
        {
            var artist = new Artist(
                request.Name!, 
                request.Overview!, 
                DateOnly.Parse(request.FormedDate), 
                request.Location!);

            await _repository.Add(artist);

            return artist;
        }
    }
}