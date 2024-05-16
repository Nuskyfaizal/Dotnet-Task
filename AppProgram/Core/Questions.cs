using Newtonsoft.Json;

namespace AppProgram.Core;
public class Questions
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("questionType")]
    public string QuestionType { get; set; }

    [JsonProperty("question")]
    public string Question { get; set; }

    [JsonProperty("maxChoicesAllowed")]
    public int MaxChoicesAllowed { get; set; }

    [JsonProperty("isOtherEnabled")]
    public bool IsOtherEnabled { get; set; }

    [JsonProperty("choices")]
    public List<Choices> Choices { get; set; } = [];
}
