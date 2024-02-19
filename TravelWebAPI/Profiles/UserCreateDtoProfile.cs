using AutoMapper;
using TravelWebAPI.Dto;
using TravelWebAPI.Models;

namespace TravelWebAPI.Profiles
{
    public class UserCreateDtoProfile : Profile
    {
        public UserCreateDtoProfile()
        {
            CreateMap<UserCreateDto, User>();
        }
    }
}
