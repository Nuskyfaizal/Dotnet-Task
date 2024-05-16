using AppProgram.Core;
using AppProgram.DTOs;

namespace AppProgram.Data;
public interface ICandidateApplicationRepository
{
    Task<ProgramFormDto> LoadProgramFormAsync(string programId);

    Task<bool> SaveCandidateApplicationAsync(PersonalInformation personalInformation);
}

