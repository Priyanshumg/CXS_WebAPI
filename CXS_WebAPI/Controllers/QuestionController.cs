using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CXS_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _service;

    public QuestionController(IQuestionService service)
    {
        _service = service;
    }

    [HttpGet("GetAllQuestions")]
    public async Task<IActionResult> GetAllQuestions()
    {
        try
        {
            var questions = await _service.GetAllAsync();
            return Ok(questions);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving questions. {ex}");
        }
    }
}