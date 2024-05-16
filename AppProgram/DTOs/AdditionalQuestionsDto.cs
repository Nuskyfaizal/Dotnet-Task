using AppProgram.Core;

namespace AppProgram.DTOs;
public class AdditionalQuestionsDto
{
    public string QuestionId { get; set; }
    public string QuestionType { get; set; }
    public string Question { get; set; }
    public int MaxChoicesAllowed { get; set; }
    public bool IsOtherEnabled { get; set; }
    public List<Choices> Choices { get; set; } = [];
}