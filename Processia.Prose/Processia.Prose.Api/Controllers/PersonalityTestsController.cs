//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace Processia.Prose.Api.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class PersonalityTestsController : ControllerBase
//{
//    private readonly IMediator _mediator;
//    public PersonalityTestsController(IMediator mediator)
//    {
//        _mediator = mediator;
//    }

//    [HttpGet("start")]
//    public async Task<ActionResult<StartPersonalityTestDto>> StartTest()
//    {
//        var query = new StartPersonalityTestQuery();
//        var result = await _mediator.Send(query);
//        return Ok(result);
//    }

//    [HttpPost("submit")]
//    public async Task<ActionResult<NextPersonalityQuestionDto>> SubmitAnswer(SubmitPersonalityTestAnswerDto dto)
//    {
//        var command = new SubmitPersonalityTestAnswerCommand(dto.QuestionId, dto.Answer);
//        var result = await _mediator.Send(command);
//        return Ok(result);
//    }

//    [HttpPost("results")]
//    public async Task<IActionResult> SaveResults(SavePersonalityTestResultsDto dto)
//    {
//        var command = new SavePersonalityTestResultsCommand(dto.UserId, new PersonalityTestResult(dto.Type, dto.Traits));
//        await _mediator.Send(command);
//        return Ok();
//    }
//}

//// Request and Response records
//public record StartPersonalityTestDto(string Question, string[] Options);

//public record SubmitPersonalityTestAnswerDto(Guid QuestionId, string Answer);

//public record NextPersonalityQuestionDto(Guid NextQuestionId, string NextQuestion, string[] Options);

//public record SavePersonalityTestResultsDto(Guid UserId, string Type, string[] Traits);
