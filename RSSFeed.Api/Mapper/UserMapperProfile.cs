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
            CreateMap<RegisterRequest, User>().ForMember(mem => mem.PasswordHash, opt => opt.MapFrom(u => HashPassword(u.Password)));
        }

        private string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100000, 256 / 8));
            return hash;
        }
    }
}
