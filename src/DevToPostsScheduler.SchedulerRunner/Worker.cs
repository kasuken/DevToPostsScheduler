using DevToPostsScheduler.Data;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevToPostsScheduler.SchedulerRunner
{
    public class Worker
    {
        public async Task Run(string token)
        {
            var dataService = new DevToAPIDataService();

            var articles = await dataService.LoadDraftArticles(token);

            foreach (var article in articles)
            {
                var pubDateString = FindPublishedDateInText(article.BodyMarkdown);

                if (!string.IsNullOrEmpty(pubDateString))
                {
                    var pubDate = DateTime.Parse(pubDateString);

                    if (pubDate < DateTime.Now)
                    {
                        var item = articles.Where(c => c.Id == article.Id).FirstOrDefault();

                        item.BodyMarkdown = RemovePublishedDateInText(article.BodyMarkdown);

                        //await dataService.PublishArticle(token, item);
                    }
                }
            }
        }

        private string FindPublishedDateInText(string markdown)
        {
            var regex = new Regex("##PublishedDate(.*)##");
            var v = regex.Match(markdown);
            string s = v.Groups[1].ToString();

            return s;
        }

        private string RemovePublishedDateInText(string markdown)
        {
            var regex = new Regex("##PublishedDate(.*)##");
            var v = regex.Match(markdown);

            markdown = markdown.Replace(v.Value, "");

            return markdown;
        }
    }
}
