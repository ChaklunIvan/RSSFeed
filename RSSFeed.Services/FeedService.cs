using RSSFeed.Db;
using RSSFeed.Models.Entities;
using RSSFeed.Services.Interfaces;

namespace RSSFeed.Services
{
    public class FeedService : IFeedService
    {
        private readonly ApplicationDbContext _context;

        public FeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddArticleAsync(string url, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetArticleListAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetArticleListByDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReadArticleAsync(Article article, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
