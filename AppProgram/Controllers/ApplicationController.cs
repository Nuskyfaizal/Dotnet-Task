using AppProgram.Core;
using AppProgram.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppProgram.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController : Controller
{
    private readonly IApplicationProgramRepository _applicationProgram;
        
    public ApplicationController(IApplicationProgramRepository applicationProgram)
    {
        _applicationProgram = applicationProgram;
    }       

    [HttpGet("InformationDetails")]
    public async Task<ActionResult<InformationDetail>> GetAllInformationDetails()
    {
        var details = await _applicationProgram.GetAllInformationDetailsAsync();

        return Ok(details);
    }

    [HttpPost("CreateProgram")]
    public async Task<ActionResult> CreateProgram([FromBody] ProgramDetail programDetail)
    {
        programDetail.Id = Guid.NewGuid().ToString();

        var returned = await _applicationProgram.CreateApplicationProgramAsync(programDetail);

        if (returned)
            return Ok();
        else
            return BadRequest();         
    } 
}
