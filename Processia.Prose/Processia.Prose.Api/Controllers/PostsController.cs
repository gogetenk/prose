using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Processia.Prose.Application.UseCases.Posts.Commands;

//namespace Processia.Prose.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreatePost(CreatePostCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreatePost), result);
    }

//    [HttpPost("generate")]
//    public async Task<ActionResult<GeneratePostResponseDto>> GeneratePost(GeneratePostRequestDto dto)
//    {
//        var command = new GeneratePostCommand(dto.UserId, dto.Title, dto.Hook, dto.PublishDate, dto.LeadMagnet, (PostLength)dto.Length, dto.PersonalityType);
//        var result = await _mediator.Send(command);
//        return Ok(new GeneratePostResponseDto(result.Content));
//    }

//}

public record GeneratePostRequestDto(Guid UserId, string Title, string Hook, DateTime PublishDate, string LeadMagnet, PostLengthDto Length, string PersonalityType);

//public record GeneratePostResponseDto(string Content);

//public enum PostLengthDto
//{
//    Short,
//    Medium,
//    Long
//}
