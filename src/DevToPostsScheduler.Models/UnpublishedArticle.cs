using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevToPostsScheduler.Models
{
    public class UnpublishedArticle
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }
    }

}
