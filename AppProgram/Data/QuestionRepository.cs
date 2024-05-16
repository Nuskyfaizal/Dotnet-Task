using AppProgram.Core;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace AppProgram.Data;
public class QuestionRepository : IQuestionRepository
{
    private readonly CosmosClient _cosmosClient;
    private readonly IConfiguration _configuration;
    private readonly Container _questionTypeContainer;
    private readonly Container _questionContainer;

    public QuestionRepository(CosmosClient cosmosClient, IConfiguration configuration)
    {
        _cosmosClient = cosmosClient;
        _configuration = configuration;
        var databaseName = configuration["CosmosDbSettings:DatabaseName"];
        var questionTypeContainerName = "QuestionType";
        var questionContainerName = "Questions";

        _questionTypeContainer = cosmosClient.GetContainer(databaseName, questionTypeContainerName);
        _questionContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
    }

    public async Task<List<QuestionType>> GetAllQuestionTypesAsync()
    {       
        try
        {
            var feedIterator = _questionTypeContainer.GetItemLinqQueryable<QuestionType>().ToFeedIterator();
            var items = new List<QuestionType>();

            while (feedIterator.HasMoreResults)
            {
                var response = await feedIterator.ReadNextAsync();
                items.AddRange(response);
            }

            return items;
        }
        catch (Exception)
        {

            throw;
        }
            
    }

    public async Task<string> AddQuestionAsync(Questions question)
    {
        try
        {
            var insertedQuestion = await _questionContainer.CreateItemAsync(question);

            if (insertedQuestion.Resource != null)
                return insertedQuestion.Resource.Id;
            else
                return string.Empty;              
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<string> EditQuestionAsync(Questions question, string id)
    {
        try
        {
            var existingQuestionItem = await _questionContainer.ReadItemAsync<Questions>(id, new PartitionKey(id));

            if (existingQuestionItem.Resource != null)
            {
                Questions existingQuestion = existingQuestionItem.Resource;
                existingQuestion.QuestionType = question.QuestionType;
                existingQuestion.Question = question.Question;
                existingQuestion.MaxChoicesAllowed = question.MaxChoicesAllowed;
                existingQuestion.IsOtherEnabled = question.IsOtherEnabled;
                existingQuestion.Choices = question.Choices;

                ItemResponse<Questions> updatedItemResponse = await _questionContainer.ReplaceItemAsync(existingQuestion, id, new PartitionKey(id));

                if (updatedItemResponse.Resource != null)
                    return updatedItemResponse.Resource.Id;
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }
        catch (Exception)
        {
            throw;
        }
    }
}

