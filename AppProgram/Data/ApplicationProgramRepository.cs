using AppProgram.Core;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace AppProgram.Data;
public class ApplicationProgramRepository : IApplicationProgramRepository
{
    private readonly CosmosClient _cosmosClient;
    private readonly IConfiguration _configuration;
    private readonly Container _informationDetailContainer;
    private readonly Container _applicationProgramContainer;
    
    public ApplicationProgramRepository(CosmosClient cosmosClient, IConfiguration configuration)
    {
        _cosmosClient = cosmosClient;
        _configuration = configuration;
        var databaseName = configuration["CosmosDbSettings:DatabaseName"];
        var informationDetailContainerName = "InformationDetails";
        var applicationProgramContainerName = "ApplicationProgram";       
        
        _informationDetailContainer = cosmosClient.GetContainer(databaseName, informationDetailContainerName);
        _applicationProgramContainer = cosmosClient.GetContainer(databaseName, applicationProgramContainerName);     
    }

    public async Task<List<InformationDetail>> GetAllInformationDetailsAsync()
    {
        try
        {
            var feedIterator = _informationDetailContainer
                .GetItemLinqQueryable<InformationDetail>()
                .ToFeedIterator();

            var items = new List<InformationDetail>();

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

    public async Task<bool> CreateApplicationProgramAsync(ProgramDetail programDetail)
    {
        try
        {
            var createdProgram = await _applicationProgramContainer.CreateItemAsync(programDetail);

            if (createdProgram.Resource != null)
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