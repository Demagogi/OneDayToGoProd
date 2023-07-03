using AutoMapper;
using OneDayToGoProd.Api.Dtos;
using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.Api.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
