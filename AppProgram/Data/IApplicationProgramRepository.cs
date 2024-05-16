using AppProgram.Core;

namespace AppProgram.Data;
public interface IApplicationProgramRepository
{
    Task<List<InformationDetail>> GetAllInformationDetailsAsync();

    Task<bool> CreateApplicationProgramAsync(ProgramDetail programDetail);
}
