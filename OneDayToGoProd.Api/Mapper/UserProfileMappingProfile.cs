using AutoMapper;
using OneDayToGoProd.Api.Dtos;
using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.Api.Mapper
{
    public class UserProfileMappingProfile : Profile
    {
        public UserProfileMappingProfile()
        {
            CreateMap<CreateUserProfileDto, UserProfile>();
            CreateMap<UpdateUserProfileDto, UserProfile>();
            CreateMap<UserProfile, UserProfileDto>();
        }
    }
}
