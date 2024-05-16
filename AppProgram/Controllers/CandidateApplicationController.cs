using AppProgram.Core;
using AppProgram.Data;
using AppProgram.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppProgram.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateApplicationController : Controller
{
    private readonly ICandidateApplicationRepository _candidateApplication;


    public CandidateApplicationController(ICandidateApplicationRepository candidateApplication)
    {
        _candidateApplication = candidateApplication;
    }
    [HttpGet("GetProgramForm/{programId}")]
    public async Task<ActionResult<ProgramFormDto>> LoadProgramForm(string programId)
    {
        var form = await _candidateApplication.LoadProgramFormAsync(programId);

        if (form != null)
            return Ok(form);
        else
            return BadRequest();
    }

    [HttpPost("SaveCandidateApplication")]
    public async Task<ActionResult> SaveCandidateApplication([FromBody] PersonalInformation personalInformation)
    {
        personalInformation.Id = Guid.NewGuid().ToString();

        var returned = await _candidateApplication.SaveCandidateApplicationAsync(personalInformation);

        if (returned)
            return Ok();
        else
            return BadRequest();
    }
}
