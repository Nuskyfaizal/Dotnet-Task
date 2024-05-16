using AppProgram.Core;
using AppProgram.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppProgram.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : Controller
{
    private readonly IQuestionRepository _question;

    public QuestionController(IQuestionRepository question)
    {
        _question = question;
    }

    [HttpGet("QuestionTypes")]
    public async Task<ActionResult<QuestionType>> GetAllQuestionTypes()
    {
        var details = await _question.GetAllQuestionTypesAsync();

        return Ok(details);
    }

    [HttpPost("AddQuestion")]
    public async Task<ActionResult<string>> AddQuestion([FromBody] Questions question)
    {
        question.Id = Guid.NewGuid().ToString();

        var returnedId = await _question.AddQuestionAsync(question);
            
            
        if (!string.IsNullOrEmpty(returnedId))
            return Ok(returnedId);
        else
            return BadRequest();        
    }

    [HttpPut("EditQuestion/{id}")]
    public async Task<ActionResult<string>> EditQuestion([FromBody] Questions question, string id)
    {
        var returnedId = await _question.EditQuestionAsync(question, id);

        if (!string.IsNullOrEmpty(returnedId))
            return Ok(returnedId);
        else
            return BadRequest();
    }
}
