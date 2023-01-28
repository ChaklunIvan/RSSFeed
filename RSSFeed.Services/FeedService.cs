using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RSSFeed.Db;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Enums;
using RSSFeed.Models.Pagination;
using RSSFeed.Services.Extensions;
using RSSFeed.Services.Interfaces;
using System.Security.Cryptography;

namespace RSSFeed.Services
{
    public class FeedService : IFeedService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FeedService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddArticleAsync(string url, CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Url = url,
                State = StateType.Unread,
                SubscriptionDate = DateTime.Now
            };

            await _context.AddAsync(article, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<PagedModel<Article>> GetArticleListAsync(PagingSettings pagingSettings, CancellationToken cancellationToken)
        {
            var articles = _context.Articles.ToPagedListAsync(pagingSettings);

            return articles;
        }

        public Task<PagedModel<Article>> GetArticleListByDateAsync(DateTime date, PagingSettings pagingSettings, CancellationToken cancellationToken)
        {
            var articles = _context.Articles.Where(a => a.SubscriptionDate.Day == date.Day
                                                     && a.SubscriptionDate.Month == date.Month
                                                     && a.SubscriptionDate.Year == date.Year
                                                     && a.State == StateType.Unread)
                                            .ToPagedListAsync(pagingSettings);
            return articles;
        }

        public async Task ReadArticleAsync(int articleId, CancellationToken cancellationToken)
        {
            var article = await _context.Articles.FindAsync(articleId, cancellationToken);
            if(article != null)
            {
                article.State = StateType.Read;
                _context.Articles.Update(article);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
