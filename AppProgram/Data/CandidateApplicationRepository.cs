using AppProgram.Core;
using AppProgram.DTOs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace AppProgram.Data;
public class CandidateApplicationRepository :ICandidateApplicationRepository
{
    private readonly CosmosClient _cosmosClient;
    private readonly IConfiguration _configuration;
    private readonly Container _candidateApplicationContainer;
    private readonly Container _informationDetailContainer;
    private readonly Container _applicationProgramContainer;
    private readonly Container _questionContainer;
    public CandidateApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
    {
        _cosmosClient = cosmosClient;
        _configuration = configuration;
        var databaseName = configuration["CosmosDbSettings:DatabaseName"];
        var CandidateApplicationContainerName = "CandidateApplication";
        var questionContainerName = "Questions";
        var applicationProgramContainerName = "ApplicationProgram";
        var informationDetailContainerName = "InformationDetails";

        _applicationProgramContainer = cosmosClient.GetContainer(databaseName, applicationProgramContainerName);
        _candidateApplicationContainer = cosmosClient.GetContainer(databaseName, CandidateApplicationContainerName);
        _questionContainer = cosmosClient.GetContainer(databaseName, questionContainerName);
        _informationDetailContainer = cosmosClient.GetContainer(databaseName, informationDetailContainerName);
    }

    public async Task<ProgramFormDto> LoadProgramFormAsync(string programId)
    {
        try
        {
            var programForm = new ProgramFormDto();

            var applicationProgramQuery = _applicationProgramContainer
                .GetItemLinqQueryable<ProgramDetail>()
                .Where(i => i.Id == programId)
                .Take(1)
                .ToFeedIterator();

            var applicationProgramResponse = await applicationProgramQuery.ReadNextAsync();
            var applicationProgram = applicationProgramResponse.FirstOrDefault();

            programForm.ProgramId = applicationProgram.Id;
            programForm.ProgramTitle = applicationProgram.ProgramTitle;
            programForm.ProgramDescription = applicationProgram.ProgramDescription;

            var personalInformationForm = new List<PersonalInformatioFormDto>();

            foreach (var informationDetail in applicationProgram.InformationDetails)
            {
                if (informationDetail.IsHidden == false)
                {
                    var personalInformation = new PersonalInformatioFormDto
                    {
                        IsHidden = informationDetail.IsHidden,
                        IsInternal = informationDetail.IsInternal
                    };

                    var informationDetailsQuery = _informationDetailContainer
                        .GetItemLinqQueryable<InformationDetail>()
                        .Where(i => i.Id == informationDetail.InformationDetailsId)
                        .Take(1)
                        .ToFeedIterator();

                    var informationDetailsQueryResponse = await informationDetailsQuery.ReadNextAsync();
                    var informationDetails = informationDetailsQueryResponse.FirstOrDefault();

                    personalInformation.Field = informationDetails.Field;

                    personalInformationForm.Add(personalInformation);
                }
            }
            programForm.PersonalInformationForm = personalInformationForm;

            var additionalQuestions = new List<AdditionalQuestionsDto>();

            foreach (var question in applicationProgram.ProgramQuestions)
            {
                var additionalQuestion = new AdditionalQuestionsDto();

                var questionQuery = _questionContainer
                    .GetItemLinqQueryable<Questions>()
                    .Where(i => i.Id == question.QuestionId)
                    .Take(1)
                    .ToFeedIterator();

                var questionQuerysQueryResponse = await questionQuery.ReadNextAsync();
                var questions = questionQuerysQueryResponse.FirstOrDefault();

                additionalQuestion.QuestionId = questions.Id;
                additionalQuestion.Question = questions.Question;
                additionalQuestion.QuestionType = questions.QuestionType;
                additionalQuestion.IsOtherEnabled = questions.IsOtherEnabled;
                additionalQuestion.MaxChoicesAllowed = questions.MaxChoicesAllowed;
                additionalQuestion.Choices = questions.Choices;

                additionalQuestions.Add(additionalQuestion);
            }
            programForm.AdditionalQuestions = additionalQuestions;

            return programForm;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> SaveCandidateApplicationAsync(PersonalInformation personalInformation)
    {
        try
        {
            var createdCandidate = await _candidateApplicationContainer.CreateItemAsync(personalInformation);

            if (createdCandidate.Resource != null)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
