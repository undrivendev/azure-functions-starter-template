using System.Threading.Tasks;
using AzureFunctionsStarterTemplate.Bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace AzureFunctionsStarterTemplate.FunctionHost
{
    public class FunctionCollection
    {
        private readonly ILogger<FunctionCollection> _logger;
        private readonly WorkerService _workerService;

        public FunctionCollection(ILogger<FunctionCollection> logger, WorkerService workerService)
        {
            _logger = logger;
            _workerService = workerService;
        }
        
        [FunctionName("ProcessQueueMessage")]
        [return: Queue("%OutputAzureStorageQueueName%", Connection = "OutputAzureStorageConnectionString")]
        public async Task<string> ProcessQueueMessage([QueueTrigger("%InputAzureStorageQueueName%", Connection = "InputAzureStorageConnectionString")] CloudQueueMessage input)
        {
            _logger.LogInformation($"Got message from queue:  {new { input.Id, input.DequeueCount, input.InsertionTime, input.ExpirationTime, input.NextVisibleTime }}");
            
            var deserializedMessageData = JsonConvert.DeserializeObject<MessageData>(input.AsString);
            var result = await _workerService.DoWork(deserializedMessageData);
            return JsonConvert.SerializeObject(result);
        }
    }
}