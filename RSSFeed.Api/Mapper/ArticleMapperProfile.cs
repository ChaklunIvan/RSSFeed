using AutoMapper;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Responses;

namespace RSSFeed.Api.Mapper
{
    public class ArticleMapperProfile : Profile
    {
        public ArticleMapperProfile()
        {
            CreateMap<Article, ArticleResponse>();
        }
    }
}
