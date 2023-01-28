using RSSFeed.Models.Entities;
using RSSFeed.Models.Pagination;
using RSSFeed.Models.Responses;

namespace RSSFeed.Services.Interfaces
{
    public interface IFeedService
    {
        Task AddArticleAsync(string url, CancellationToken cancellationToken);
        Task<PagedModel<ArticleResponse>> GetArticleListAsync(PagingSettings pagingSettings, CancellationToken cancellationToken);
        Task<PagedModel<ArticleResponse>> GetArticleListByDateAsync(DateTime date, PagingSettings pagingSettings, CancellationToken cancellationToken);
        Task ReadArticleAsync(int articleId, CancellationToken cancellationToken);
    }
}
