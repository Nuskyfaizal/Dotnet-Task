using Newtonsoft.Json;

namespace AppProgram.Core;
public class Choices
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("choice")]
    public string Choice { get; set; }

    public Choices(string id, string choice)
    {
        Id = id;
        Choice = choice;
    }

    public Choices()
    {
        Id = Guid.NewGuid().ToString();
    }
}
