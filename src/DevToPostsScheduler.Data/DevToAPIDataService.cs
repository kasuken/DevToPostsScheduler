﻿using DevToPostsScheduler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", accessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            article.Published = true;
            var content = new StringContent(JsonConvert.SerializeObject(article), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://dev.to/api/articles/{article.Id}", content);

            return response.IsSuccessStatusCode;
        }
    }
}
