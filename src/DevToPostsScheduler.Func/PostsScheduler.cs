using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevToPostsScheduler.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevToPostsScheduler.Func
{
    public class PostsScheduler
    {
        private readonly ILogger _logger;

        //Example: ##ToPublishOn:2019-12-21 08:00AM##
        private const string PublishDateRegEx = "##ToPublishOn:(.*)##";

        public PostsScheduler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PostsScheduler>();
        }

        [Function("PostsScheduler")]
        public async Task Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"PostsScheduler executed at: {DateTime.Now}");

            var apiKey = Environment.GetEnvironmentVariable("DevToApiKey");

            var dataService = new DevToAPIDataService();

            var articles = await dataService.LoadDraftArticles(apiKey);

            foreach (var article in articles)
            {
                var pubDateString = FindPublishedDateInText(article.BodyMarkdown);

                if (pubDateString is { Length: > 0})
                {
                    var pubDate = DateTime.Parse(pubDateString);

                    if (pubDate < DateTime.Now)
                    {
                        var item = articles.Where(c => c.Id == article.Id).FirstOrDefault();

                        item.BodyMarkdown = RemovePublishedDateInText(article.BodyMarkdown);

                        await dataService.PublishArticle(apiKey, item);
                    }
                }
            }
        }

        private string FindPublishedDateInText(string markdown)
        {
            var regex = new Regex(PublishDateRegEx);
            var m = regex.Match(markdown);
            string date = m.Groups[1].ToString();

            return date;
        }

        private string RemovePublishedDateInText(string markdown)
        {
            var regex = new Regex(PublishDateRegEx);
            var m = regex.Match(markdown);

            markdown = markdown.Replace(m.Value, "");

            return markdown;
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
