using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zestware.Application.Artists.Commands;
using Zestware.Application.Artists.Queries;
using Zestware.Host.Dtos;
using Zestware.Host.Mappers;

namespace Zestware.Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ArtistMapper _mapper;
    private readonly ILogger<ArtistsController> _logger;

    public ArtistsController(IMediator mediator, ArtistMapper mapper, ILogger<ArtistsController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpPost(Name = "Create Artist")]
    public async Task<IActionResult> Create([FromBody]Artist artistRequest, CancellationToken ct)
    {
        var command = new CreateArtist.Command(
            artistRequest.Name,
            artistRequest.Overview,
            artistRequest.Formed,
            artistRequest.Location);

        var result = await _mediator.Send(command, ct);

        return Ok(_mapper.MapToDto(result));
    }

    [HttpGet("{id}", Name = "Get Artist")]
    public async Task<IActionResult> GetArtist(Guid id)
    {
        var query = new GetArtist.Query(id);

        var result = await _mediator.Send(query);

        return result != null 
            ? Ok(_mapper.MapToDto(result)) 
            : NotFound();
    }
}