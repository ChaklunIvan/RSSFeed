using RSSFeed.Models.Entities;
using RSSFeed.Models.Pagination;

namespace RSSFeed.Services.Interfaces
{
    public interface IFeedService
    {
        Task AddArticleAsync(string url, CancellationToken cancellationToken);
        Task<PagedModel<Article>> GetArticleListAsync(PagingSettings pagingSettings, CancellationToken cancellationToken);
        Task<PagedModel<Article>> GetArticleListByDateAsync(DateTime date, PagingSettings pagingSettings, CancellationToken cancellationToken);
        Task ReadArticleAsync(int articleId, CancellationToken cancellationToken);
    }
}
