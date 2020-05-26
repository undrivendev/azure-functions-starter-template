using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsStarterTemplate.Bll
{
    public  class WorkerService
    {
        private readonly ILogger<WorkerService> _logger;

        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// This is just a sample
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MessageData> DoWork(MessageData input)
        {
            _logger.LogInformation("Doing work...");
            // ... DELETE NEXT LINES AND DO MEANINGFUL WORK HERE ...
            await Task.Delay(5000);
            return new MessageData(input.Id,  new string(input.Value.Reverse().ToArray()));
        }
    }
}