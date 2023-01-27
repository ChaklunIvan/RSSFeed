using RSSFeed.Models.Entities;

namespace RSSFeed.Services.Interfaces
{
    public interface IFeedService
    {
        Task AddArticleAsync(string url, CancellationToken cancellationToken);
        Task<IEnumerable<Article>> GetArticleListAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Article>> GetArticleListByDateAsync(DateTime date, CancellationToken cancellationToken);
        Task ReadArticleAsync(int articleId, CancellationToken cancellationToken);
    }
}
