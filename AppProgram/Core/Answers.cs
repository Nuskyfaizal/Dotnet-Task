using Newtonsoft.Json;

namespace AppProgram.Core;
public class Answers
{
    [JsonProperty("questionId")]
    public string QuestionId { get; set; }

    [JsonProperty("answer")]
    public List<string> Answer { get; set; }
}