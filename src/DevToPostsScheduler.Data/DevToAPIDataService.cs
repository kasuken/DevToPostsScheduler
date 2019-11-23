using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DevToPostsScheduler.Models;
using Newtonsoft.Json;

namespace DevToPostsScheduler.Data
{
    public class DevToAPIDataService : IDataService
    {
        public async Task<List<UnpublishedArticle>> LoadDraftArticles(string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", accessToken);

            var response = await client.GetStringAsync("https://dev.to/api/articles/me/unpublished");
            var articles = JsonConvert.DeserializeObject<List<UnpublishedArticle>>(response);

            return articles;
        }

        public async Task<UnpublishedArticle> LoadPublishedArticle(string accessToken, string id)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", accessToken);

            var response = await client.GetStringAsync($"https://dev.to/api/articles/{id}");
            var article = JsonConvert.DeserializeObject<UnpublishedArticle>(response);

            return article;
        }

        public async Task<bool> PublishArticle(string accessToken, UnpublishedArticle article)
        {
            article.Published = true;

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", accessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var myContent = JsonConvert.SerializeObject(article);

            var content = new StringContent(myContent, Encoding.UTF8, "application/json");

            //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            //var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"https://dev.to/api/articles/{article.Id}", content);

            return true;
        }
    }
}
