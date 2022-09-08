using MediatR;
using Zestware.Domain.Entities;

namespace Zestware.Application.Artists.Commands;

public static class CreateArtist
{
    public record Command(string? Name, string? Overview, DateOnly? Formed, string? Location) : IRequest<Artist>;
    
    public class Handler : IRequestHandler<Command, Artist>
    {
        public Task<Artist> Handle(Command request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Artist());
        }
    }
}