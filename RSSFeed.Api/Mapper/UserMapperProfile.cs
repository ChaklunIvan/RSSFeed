using AutoMapper;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;

namespace RSSFeed.Api.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}
