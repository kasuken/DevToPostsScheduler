using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DevToPostsScheduler.Func
{
    public static class PostsScheduler
    {
        [FunctionName("PostsScheduler")]
        public async static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"PostsScheduler function executed at: {DateTime.Now}");

            SchedulerRunner.Worker worker = new SchedulerRunner.Worker();

            await worker.Run("");
        }
    }
}
