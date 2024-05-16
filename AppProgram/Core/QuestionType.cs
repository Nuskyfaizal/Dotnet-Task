using Newtonsoft.Json;

namespace AppProgram.Core;
public class QuestionType
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}
