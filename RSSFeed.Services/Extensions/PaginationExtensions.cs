using Microsoft.EntityFrameworkCore;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Pagination;

namespace RSSFeed.Services.Extensions
{
    public static class PaginationExtensions
    {
        public static Task<IQueryable<TModel>> ToPagedListAsync<TModel>(this IQueryable<TModel> items, PagingSettings pagingSettings)
        {
            var pagedList = items.Skip((pagingSettings.CurrentPage - 1) * pagingSettings.PageSize)
                                 .Take(pagingSettings.PageSize);

            
            return Task.FromResult(pagedList);
        }

        public static Task<PagedModel<TModel>> ToPagedModelAsync<TModel>(this IEnumerable<TModel> items, PagingSettings pagingSettings)
        {
            var count = items.Count();

            var pagedModel = new PagedModel<TModel>()
            {
                CurrentPage = pagingSettings.CurrentPage,
                PageSize = pagingSettings.PageSize,
                Items = items,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pagingSettings.PageSize)
            };

            return Task.FromResult(pagedModel);
        } 
    }
}
