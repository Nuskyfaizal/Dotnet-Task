using AppProgram.Core;

namespace AppProgram.Data;
public interface IQuestionRepository
{
    Task<List<QuestionType>> GetAllQuestionTypesAsync();

    Task<string> AddQuestionAsync(Questions question);

    Task<string> EditQuestionAsync(Questions question, string id);
}
