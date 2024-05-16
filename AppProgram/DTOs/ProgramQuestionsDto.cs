using Newtonsoft.Json;

namespace AppProgram.DTOs;
public class ProgramQuestionsDto
{
    [JsonProperty("questionId")]
    public string QuestionId { get; set; }
}
