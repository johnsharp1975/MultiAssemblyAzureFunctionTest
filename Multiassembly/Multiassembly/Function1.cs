using System;
using ClassLibrary1;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Multiassembly
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("myqueue-items", Connection = "my-conn-str")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var queueItemAsModel = System.Text.Json.JsonSerializer.Deserialize<Model>(myQueueItem);

            Console.WriteLine(queueItemAsModel.name);
        }
    }
}
