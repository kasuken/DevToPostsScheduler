using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DevToPostsScheduler.Func
{
    public static class PostsScheduler
    {
        [FunctionName("PostsScheduler")]
        public static async Task Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"PostsScheduler function start at: {DateTime.Now}");

            var worker = new SchedulerRunner.Worker();

            await worker.Run(Environment.GetEnvironmentVariable("DevToApiKey"));

            log.LogInformation($"PostsScheduler function finished at: {DateTime.Now}");
        }
    }
}
