using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using RSSFeed.Models.Entities;
using RSSFeed.Models.Requests;
using System.Security.Cryptography;

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
