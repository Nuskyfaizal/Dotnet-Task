using Newtonsoft.Json;

namespace AppProgram.Core;
public class PersonalInformation
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("programId")]
    public string ProgramId { get; set; }
    
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    
    [JsonProperty("email")]
    public string Email { get; set; }
    
    [JsonProperty("phone")]
    public string Phone { get; set; }
    
    [JsonProperty("nationality")]
    public string Nationality { get; set; }
    
    [JsonProperty("currentResidence")]
    public string CurrentResidence { get; set; }
   
    [JsonProperty("iDNumber")]
    public int IDNumber { get; set; }
   
    [JsonProperty("dateOfBirth")]
    public DateTime DateOfBirth { get; set; }
    
    [JsonProperty("gender")]
    public string Gender { get; set; }
    
    [JsonProperty("answers")]
    public List<Answers> Answers { get; set; }
}
