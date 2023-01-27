using RSSFeed.Models.Enums;

namespace RSSFeed.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public StateType State { get; set; }
    }
}
