using RSSFeed.Models.Enums;

namespace RSSFeed.Models.Responses
{
    public class ArticleResponse
    {
        public string? Url { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public string? State { get; set; }
    }
}
