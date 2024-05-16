using Newtonsoft.Json;

namespace AppProgram.DTOs;
public class InformationDetailsDto
{
    [JsonProperty("informationDetailsId")]
    public string InformationDetailsId { get; set; }

    [JsonProperty("isInternal")]
    public bool IsInternal { get; set; }

    [JsonProperty("isHidden")]
    public bool IsHidden { get; set; }
}

