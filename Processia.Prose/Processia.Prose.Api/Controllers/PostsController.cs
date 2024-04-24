using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Processia.Prose.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("new")]
    public async Task<ActionResult<CreatePostResponseDto>> CreatePost(CreatePostRequestDto dto)
    {
        var command = new CreatePostCommand(dto.Title, dto.Hook, dto.PublishDate, dto.LeadMagnet, (PostLength)dto.Length);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreatePost), new CreatePostResponseDto(result.PostId));
    }

    [HttpPost("generate")]
    public async Task<ActionResult<GeneratePostResponseDto>> GeneratePost(GeneratePostRequestDto dto)
    {
        var command = new GeneratePostCommand(dto.UserId, dto.Title, dto.Hook, dto.PublishDate, dto.LeadMagnet, (PostLength)dto.Length, dto.PersonalityType);
        var result = await _mediator.Send(command);
        return Ok(new GeneratePostResponseDto(result.Content));
    }

}

// Request and Response records
public record CreatePostRequestDto(string Title, string Hook, DateTime PublishDate, string LeadMagnet, PostLengthDto Length);

public record CreatePostResponseDto(Guid PostId);

public record GeneratePostRequestDto(Guid UserId, string Title, string Hook, DateTime PublishDate, string LeadMagnet, PostLengthDto Length, string PersonalityType);

public record GeneratePostResponseDto(string Content);

public enum PostLengthDto
{
    Short,
    Medium,
    Long
}
