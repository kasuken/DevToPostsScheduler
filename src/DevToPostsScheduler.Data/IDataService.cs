using DevToPostsScheduler.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevToPostsScheduler.Data
{
    public interface IDataService
    {

        Task<UnpublishedArticle> LoadPublishedArticle(string accessToken, string id);

        Task<List<UnpublishedArticle>> LoadDraftArticles(string accessToken);

        Task<bool> PublishArticle(string accessToken, UnpublishedArticle article);
    }
}
