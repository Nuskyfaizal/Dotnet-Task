namespace AppProgram.DTOs;
public class ProgramFormDto
{
    public string ProgramId { get; set; }
    public string ProgramTitle { get; set; }
    public string ProgramDescription { get; set; }
    public List<PersonalInformatioFormDto> PersonalInformationForm { get; set; }
    public List<AdditionalQuestionsDto> AdditionalQuestions { get; set; }
}
