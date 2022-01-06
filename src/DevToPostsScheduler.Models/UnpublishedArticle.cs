using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DevToPostsScheduler.Models
{
    public class UnpublishedArticle
{
        [JsonProperty("type_of")]
        public string TypeOf { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("body_markdown")]
        public string BodyMarkdown { get; set; }

        [JsonProperty("cover_image")]
        public string CoverImage { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("tag_list")]
        public List<string> TagList { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("canonical_url")]
        public string CanonicalUrl { get; set; }

        [JsonProperty("comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty("reading_time_minutes")]
        public long ReadingTimeMinutes { get; set; }

        [JsonProperty("positive_reactions_count")]
        public long PositiveReactionsCount { get; set; }

        [JsonProperty("page_views_count")]
        public long PageViewsCount { get; set; }

        [JsonProperty("published_timestamp")]
        public DateTimeOffset? PublishedTimestamp { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("organization")]
        public Organization Organization { get; set; }

        [JsonProperty("flare_tag")]
        public FlareTag FlareTag { get; set; }
    }

    public class FlareTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bg_color_hex")]
        public string BgColorHex { get; set; }

        [JsonProperty("text_color_hex")]
        public string TextColorHex { get; set; }
    }

    public class Organization
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("profile_image_90")]
        public string ProfileImage90 { get; set; }
    }

    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty("github_username")]
        public string GithubUsername { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("profile_image_90")]
        public string ProfileImage90 { get; set; }
    }
}
