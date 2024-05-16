using AppProgram.DTOs;
using Newtonsoft.Json;

namespace AppProgram.Core;
public class ProgramDetail
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("programTitle")]
    public string ProgramTitle { get; set; }

    [JsonProperty("programDescription")]
    public string ProgramDescription { get; set; }

    [JsonProperty("informationDetails")]
    public List<InformationDetailsDto> InformationDetails { get; set; }

    [JsonProperty("programQuestions")]
    public List<ProgramQuestionsDto> ProgramQuestions { get; set; }
}
