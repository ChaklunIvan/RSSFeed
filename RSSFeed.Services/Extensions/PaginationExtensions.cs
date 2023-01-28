using Microsoft.EntityFrameworkCore;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Pagination;

namespace RSSFeed.Services.Extensions
{
    public static class PaginationExtensions
    {
        public static Task<PagedModel<TModel>> ToPagedListAsync<TModel>(this IQueryable<TModel> items, PagingSettings pagingSettings)
        {
            var count = items.Count();
            var pagedList = items.Skip((pagingSettings.CurrentPage - 1) * pagingSettings.PageSize)
                                 .Take(pagingSettings.PageSize);

            var pagedModel = new PagedModel<TModel>()
            {
                CurrentPage = pagingSettings.CurrentPage,
                PageSize = pagingSettings.PageSize,
                Items = pagedList,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pagingSettings.PageSize)
            };
            return Task.FromResult(pagedModel);
        }
    }
}
