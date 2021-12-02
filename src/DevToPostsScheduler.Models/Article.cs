using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToPostsScheduler.Models
{
    public partial class ArticleContainer
    {
        [JsonProperty("article")]
        public Article Article { get; set; }
    }

    public class Article
    {
        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; set; }
    }
}
