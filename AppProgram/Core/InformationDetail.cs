using Newtonsoft.Json;

namespace AppProgram.Core;
public class InformationDetail
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("fields")]
    public string Field { get; set; }     
}
